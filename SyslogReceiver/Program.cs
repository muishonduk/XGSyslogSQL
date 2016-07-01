using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Configuration;

namespace SyslogReceiver
{
	// Core UDP code taken from
	// http://www.codeproject.com/Tips/441233/Multithreaded-Customizable-SysLog-Server-Csharp

	public class Program
	{
		public static TimeSpan TickPeriod;
		public static IPAddress RemoteAddress { get; private set; }

		private static ConcurrentQueue<byte[]> queue;

		static void Main(string[] args)
		{
			try
			{
				RemoteAddress = IPAddress.Parse(ConfigurationManager.AppSettings["xgaddress"]);

				int seconds = int.Parse(ConfigurationManager.AppSettings["tickperiod"]);
				if (seconds < 1 || seconds > 30) throw new Exception("Tick period should be between 1 and 30 seconds");
				TickPeriod = TimeSpan.FromSeconds(seconds);

				queue = new ConcurrentQueue<byte[]>();

				var dbhandler = new DBHandler(queue);
				var processor = new MessageProcessor(queue);

				processor.StartListening();

				Console.WriteLine($"Listening for XG at {RemoteAddress}, DB update every {seconds} sec(s), type STOP to stop...");

				string input;
				do
				{
					input = Console.ReadLine();
				}
				while (input == null || input.ToLowerInvariant() != "stop");

				Console.WriteLine("Stopping...");
				processor.StopListening();
			}
			catch(Exception ex)
			{
				Console.WriteLine(ex.Message);

				string fname = string.Format("Log {0:yy-MM-dd}.txt", DateTime.UtcNow);
				File.AppendAllText(fname, ex.Message);
			}
		}
	}

	/// <summary>
	/// Take messages from concurrent queue, and save them into a database
	/// </summary>
	public class DBHandler
	{
		private object syncobj = new object();

		private bool saving;
		private Timer timer;
		private ConcurrentQueue<byte[]> queue;


		public DBHandler(ConcurrentQueue<byte[]> q)
		{
			this.saving = false;
			this.queue = q;

			this.timer = new Timer(DBWorker, null, Program.TickPeriod, Program.TickPeriod);
		}

		//public void ProcessLogFile(string fname)
		//{
		//	var lines = File.ReadAllLines(fname);

		//	foreach (string l in lines)
		//	{
		//		int i = l.IndexOf("device=");

		//		ProcessLine(l.Substring(i));
		//	}
		//}

		private void DBWorker(object state)
		{
			lock (syncobj)
			{
				// to prevent re-entrance
				if (saving) return;
				saving = true;
			}

			try
			{
				try
				{
					InnerWorker();
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
				}
			}
			finally
			{
				lock (syncobj)
				{
					saving = false;
				}
			}
		}

		private void InnerWorker()
		{
			if (queue.IsEmpty) return;

			int count = 0;
			string fname = string.Format("Log {0:yy-MM-dd}.txt", DateTime.UtcNow);

			using (StreamWriter file = File.AppendText(fname))
			using (var con = new LogModel())
			{
				bool fileerror = false;
				byte[] raw;
				string line;

				while (queue.TryDequeue(out raw))
				{
					line = Encoding.ASCII.GetString(raw);
					if (string.IsNullOrEmpty(line)) continue;

					++count;
					try
					{
						Parser.Handle(line, con);
					}
					catch (Exception ex)
					{
						Console.WriteLine($"ERROR during parse: {ex.Message}");
					}

					try
					{
						file.WriteLine(line);
					}
					catch (Exception ex)
					{
						if (!fileerror)
							Console.WriteLine($"ERROR during file save: {ex.Message}");

						fileerror = true;
					}
				}

				try
				{
					con.SaveChanges();
				}
				catch (Exception ex)
				{
					Console.WriteLine($"ERROR during database save: {ex.Message}");
				}
			}

			// show on screen
			Console.WriteLine($"{count} record(s)");
		}
	}

	/// <summary>
	/// Receive UDP messages and save them to a concurrent queue
	/// </summary>
	public class MessageProcessor
	{
		private Thread worker;
		private bool runworker;
		private ConcurrentQueue<byte[]> queue;

		public MessageProcessor(ConcurrentQueue<byte[]> q)
		{
			this.queue = q;

			worker = new Thread(WorkerCode);
			worker.Priority = ThreadPriority.AboveNormal;
			worker.IsBackground = true;
		}

		public void StartListening()
		{
			runworker = true;
			worker.Start();
		}

		public void StopListening()
		{
			runworker = false;
		}

		private void WorkerCode()
		{
			IPEndPoint anyIP = new IPEndPoint(Program.RemoteAddress, 0);
			//long counter = 0;

			using (UdpClient udpListener = new UdpClient(514))
			{
				byte[] rawdata;
				//string sourceIP;

				// Listen for incoming data on udp port 514 (default for SysLog events)
				while (runworker)
				{
					try
					{
						rawdata = udpListener.Receive(ref anyIP);

						//sourceIP = anyIP.Address.ToString();

						queue.Enqueue(rawdata);
						//++counter;
					}
					catch (Exception ex)
					{
						queue.Enqueue(Encoding.ASCII.GetBytes($"device_id=\"workerexcept\" message=\"{ex.ToString().Replace('"','\'')}\""));
					}
				}
			}
		}
	}
}
