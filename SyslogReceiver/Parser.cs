using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyslogReceiver
{
	public static class Parser
	{
		public static void Handle(string line, LogModel model)
		{
			if (string.IsNullOrEmpty(line)) return;

			if (line.Contains(" log_type=\"Content Filtering\" "))
				ParseContentFilter(line, model);
			else
			if (line.Contains(" log_type=\"Security Policy\" "))
				ParseSecurityPolicy(line, model);
			else
			//if (line.Contains(" log_type=\"Event\" "))
			//	ParseEvent(line, model);
			//else
				ParseOther(line, model);
		}

		private static void ParseContentFilter(string s, LogModel model)
		{
			var d = BreakApart(s);
			var r = new ContentFilter();

			r.datet = GetDate(d);
			r.timezone = d.TryGet("timezone", 5);
			r.device_id = d.TryGet("device_id", 20);
			r.log_id = d.TryGet("log_id", 20);
			r.log_component = d.TryGet("log_component", 20);
			r.log_subtype = d.TryGet("log_subtype", 20);
			r.status = d.TryGet("status", 20);
			r.priority = d.TryGet("priority", 20);
			r.fw_rule_id = d.TryGetInt("fw_rule_id");
			r.user_name = d.TryGet("user_name", 20);
			r.user_gp = d.TryGet("user_gp", 30);

			// application filter fields, not always present
			r.application_filter_policy = d.TryGetInt("application_filter_policy");
			r.application_name = d.TryGet("application_name", 30);
			r.application_risk = d.TryGetInt("application_risk");
			r.application_technology = d.TryGet("application_technology", 20);
			r.application_category = d.TryGet("application_category", 20);
			r.src_country_code = d.TryGet("src_country_code", 10);
			r.dst_country_code = d.TryGet("dst_country_code", 10);

			r.iap = d.TryGetInt("iap");
			r.category = d.TryGet("category", 30);
			r.category_type = d.TryGet("category_type", 20);
			r.url = d.TryGet("url");
			r.contenttype = d.TryGet("contenttype", 150);
			r.override_token = d.TryGet("override_token", 20);
			r.httpresponsecode = d.TryGet("httpresponsecode", 20);
			r.src_ip = d.TryGet("src_ip", 48);
			r.dst_ip = d.TryGet("dst_ip", 48);
			r.protocol = d.TryGet("protocol", 10);
			r.src_port = d.TryGetInt("src_port");
			r.dst_port = d.TryGetInt("dst_port");
			r.sent_bytes = d.TryGetInt("sent_bytes");
			r.recv_bytes = d.TryGetInt("recv_bytes");
			r.domain = d.TryGet("domain", 200);

			r.otherdata = Helpers.GetOtherData(d);

			model.ContentFilters.Add(r);
		}

		private static void ParseSecurityPolicy(string s, LogModel model)
		{
			s = s.Replace("=00: 0:00: 0:00: 0", "=00:0:00:0:00:0");

			var d = BreakApart(s);
			var r = new SecurityPolicy();

			r.datet = GetDate(d);
			r.timezone = d.TryGet("timezone", 5);
			r.device_id = d.TryGet("device_id", 20);
			r.log_id = d.TryGet("log_id", 20);
			r.log_component = d.TryGet("log_component", 20);
			r.log_subtype = d.TryGet("log_subtype", 20);
			r.status = d.TryGet("status", 20);
			r.priority = d.TryGet("priority", 20);
			r.fw_rule_id = d.TryGetInt("fw_rule_id");
			r.user_name = d.TryGet("user_name", 20);
			r.user_gp = d.TryGet("user_gp", 30);
			r.iap = d.TryGetInt("iap");

			r.duration = d.TryGetInt("duration");
			r.policy_type = d.TryGetInt("policy_type");
			r.ips_policy_id = d.TryGetInt("ips_policy_id");
			r.appfilter_policy_id = d.TryGetInt("appfilter_policy_id");
			r.application = d.TryGet("application", 50);
			r.application_risk = d.TryGetInt("application_risk");
			r.application_technology = d.TryGet("application_technology", 50);
			r.application_category = d.TryGet("application_category", 20);
			r.in_interface = d.TryGet("in_interface", 20);
			r.out_interface = d.TryGet("out_interface", 20);
			r.src_mac = d.TryGet("src_mac", 48);
			r.src_country_code = d.TryGet("src_country_code", 10);
			r.dst_country_code = d.TryGet("dst_country_code", 10);
			r.sent_pkts = d.TryGetInt("sent_pkts");
			r.recv_pkts = d.TryGetInt("recv_pkts");
			r.tran_src_ip = d.TryGet("trans_src_ip", 48);
			r.tran_src_port = d.TryGetInt("trans_src_port");
			r.tran_dst_ip = d.TryGet("trans_dst_ip", 48);
			r.tran_dst_port = d.TryGetInt("trans_dst_port");
			r.srczone = d.TryGet("srczone", 20);
			r.dstzone = d.TryGet("dstzone", 20);
			r.dir_disp = d.TryGet("dir_disp", 20);
			r.connid = d.TryGet("connid", 20);
			r.vconnid = d.TryGet("vconnid", 20);
			r.hb_health = d.TryGet("hb_health", 20);

			r.src_ip = d.TryGet("src_ip", 48);
			r.dst_ip = d.TryGet("dst_ip", 48);
			r.protocol = d.TryGet("protocol", 10);
			r.src_port = d.TryGetInt("src_port");
			r.dst_port = d.TryGetInt("dst_port");
			r.sent_bytes = d.TryGetInt("sent_bytes");
			r.recv_bytes = d.TryGetInt("recv_bytes");

			r.otherdata = Helpers.GetOtherData(d);

			model.SecurityPolicies.Add(r);
		}

		private static void ParseEvent(string s, LogModel model)
		{
		}

		private static void ParseOther(string s, LogModel model)
		{
			var d = BreakApart(s);
			var r = new OtherLog();

			r.datet = GetDate(d);
			r.timezone = d.TryGet("timezone", 5);
			r.device_id = d.TryGet("device_id", 20);
			r.log_id = d.TryGet("log_id", 20);
			r.log_component = d.TryGet("log_component", 20);
			r.log_type = d.TryGet("log_type", 20);
			r.log_subtype = d.TryGet("log_subtype", 20);
			r.status = d.TryGet("status", 20);
			r.priority = d.TryGet("priority", 20);
			r.user_name = d.TryGet("user_name", 20);

			int i = s.IndexOf(' ') + 1;
			if (i < 6)
				r.rawdata = s.Substring(i);
			else
				r.rawdata = s;

			model.OtherLogs.Add(r);
		}


		private static DateTime GetDate(Dictionary<string, string> dict)
		{
			return DateTime.Parse(string.Format("{0} {1}", dict["date"], dict["time"]));
		}

		/// <summary>
		/// Turn line into a collection of key/value pairs
		/// </summary>
		private static Dictionary<string, string> BreakApart(string s)
		{
			var dict = new Dictionary<string, string>(15);
			int start = s.IndexOf(' ') + 1;

			while (true)
			{
				int endloc = FindExpressionEnd(s, start);
				if (endloc == -1 || start == endloc) break;

				var kv = GetKeyVal(s, start, endloc);
				if (kv.Key != null)
					dict[kv.Key] = kv.Value;

				start = endloc + 1;
			}

			return dict;
		}

		/// <summary>
		/// Extract a single key/value from the line
		/// </summary>
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		private static KeyValuePair<string, string> GetKeyVal(string orig, int start, int end)
		{
			int equ = orig.IndexOf('=', start, end - start);
			if (equ == -1) return new KeyValuePair<string, string>(null, null);

			string key = orig.Substring(start, equ - start).ToLowerInvariant();
			string value = orig.Substring(equ + 1, end - equ - 1).Trim('"');

			return new KeyValuePair<string, string>(key, value);
		}

		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		private static int FindExpressionEnd(string orig, int start)
		{
			if (start >= orig.Length) return -1;

			bool indoublequote = false;
			char last = char.MinValue;

			int p = start;
			int endloc = -1;

			while (endloc == -1 && p < orig.Length)
			{
				char cur = orig[p];
				switch (cur)
				{
					case ' ':
						if (!indoublequote)
							endloc = p;
						break;

					case '"':
						if (last != '\\')
							indoublequote = !indoublequote;
						break;

					default:
						break;
				}

				last = cur;
				++p;
			}

			if (endloc == -1)
				endloc = orig.Length;

			return endloc;
		}
	}

	public static class Helpers
	{
		public static string GetOtherData(Dictionary<string, string> dict)
		{
			StringBuilder b = null;
			foreach(var kv in dict)
			{
				switch (kv.Key)
				{
					case "date":
					case "time":
					case "device":
					case "device_name":
					case "log_type":
						break;

					default:
						// an interesting key, that we have not delt with
						if (b == null)
							b = new StringBuilder(50);
						else
							b.Append(' ');

						b.Append(kv.Key);
						b.Append("=\"");
						b.Append(kv.Value);
						b.Append('"');
						break;
				}
			}

			if (b == null)
				return null;
			else
				return b.ToString();
		}

		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public static string Trunc(string s, int maxlength)
		{
			if (string.IsNullOrEmpty(s)) return s;

			if (s.Length > maxlength)
				return s.Substring(0, maxlength);
			else
				return s;
		}

		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public static string TryGet(this Dictionary<string, string> dict, string key, int maxlength = -1)
		{
			string s;
			if (dict.TryGetValue(key, out s))
			{
				dict.Remove(key);

				if (string.IsNullOrEmpty(s)) return null;

				if (maxlength != -1)
					return Trunc(s, maxlength);
				else
					return s;
			}
			else
				return null;
		}

		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public static int? TryGetInt(this Dictionary<string, string> dict, string key)
		{
			string s = dict.TryGet(key);
			if (string.IsNullOrEmpty(s)) return null;

			int i;
			if (int.TryParse(s, out i))
				return i;
			else
				return null;
		}
	}
}
