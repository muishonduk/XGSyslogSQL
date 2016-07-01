namespace SyslogReceiver
{
	using System;
	using System.Data.Entity;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Linq;

	public partial class LogModel : DbContext
	{
		public LogModel()
			: base("name=LogModel")
		{
		}

		public virtual DbSet<ContentFilter> ContentFilters { get; set; }
		public virtual DbSet<OtherLog> OtherLogs { get; set; }
		public virtual DbSet<SecurityPolicy> SecurityPolicies { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<ContentFilter>()
				.Property(e => e.device_id)
				.IsUnicode(false);

			modelBuilder.Entity<ContentFilter>()
				.Property(e => e.timezone)
				.IsUnicode(false);

			modelBuilder.Entity<ContentFilter>()
				.Property(e => e.log_id)
				.IsUnicode(false);

			modelBuilder.Entity<ContentFilter>()
				.Property(e => e.log_component)
				.IsUnicode(false);

			modelBuilder.Entity<ContentFilter>()
				.Property(e => e.log_subtype)
				.IsUnicode(false);

			modelBuilder.Entity<ContentFilter>()
				.Property(e => e.status)
				.IsUnicode(false);

			modelBuilder.Entity<ContentFilter>()
				.Property(e => e.priority)
				.IsUnicode(false);

			modelBuilder.Entity<ContentFilter>()
				.Property(e => e.user_name)
				.IsUnicode(false);

			modelBuilder.Entity<ContentFilter>()
				.Property(e => e.user_gp)
				.IsUnicode(false);

			modelBuilder.Entity<ContentFilter>()
				.Property(e => e.application_name)
				.IsUnicode(false);

			modelBuilder.Entity<ContentFilter>()
				.Property(e => e.application_technology)
				.IsUnicode(false);

			modelBuilder.Entity<ContentFilter>()
				.Property(e => e.application_category)
				.IsUnicode(false);

			modelBuilder.Entity<ContentFilter>()
				.Property(e => e.src_country_code)
				.IsUnicode(false);

			modelBuilder.Entity<ContentFilter>()
				.Property(e => e.dst_country_code)
				.IsUnicode(false);

			modelBuilder.Entity<ContentFilter>()
				.Property(e => e.category)
				.IsUnicode(false);

			modelBuilder.Entity<ContentFilter>()
				.Property(e => e.category_type)
				.IsUnicode(false);

			modelBuilder.Entity<ContentFilter>()
				.Property(e => e.url)
				.IsUnicode(false);

			modelBuilder.Entity<ContentFilter>()
				.Property(e => e.contenttype)
				.IsUnicode(false);

			modelBuilder.Entity<ContentFilter>()
				.Property(e => e.override_token)
				.IsUnicode(false);

			modelBuilder.Entity<ContentFilter>()
				.Property(e => e.httpresponsecode)
				.IsUnicode(false);

			modelBuilder.Entity<ContentFilter>()
				.Property(e => e.src_ip)
				.IsUnicode(false);

			modelBuilder.Entity<ContentFilter>()
				.Property(e => e.dst_ip)
				.IsUnicode(false);

			modelBuilder.Entity<ContentFilter>()
				.Property(e => e.protocol)
				.IsUnicode(false);

			modelBuilder.Entity<ContentFilter>()
				.Property(e => e.domain)
				.IsUnicode(false);

			modelBuilder.Entity<ContentFilter>()
				.Property(e => e.otherdata)
				.IsUnicode(false);

			modelBuilder.Entity<OtherLog>()
				.Property(e => e.device_id)
				.IsUnicode(false);

			modelBuilder.Entity<OtherLog>()
				.Property(e => e.timezone)
				.IsUnicode(false);

			modelBuilder.Entity<OtherLog>()
				.Property(e => e.log_id)
				.IsUnicode(false);

			modelBuilder.Entity<OtherLog>()
				.Property(e => e.log_type)
				.IsUnicode(false);

			modelBuilder.Entity<OtherLog>()
				.Property(e => e.log_component)
				.IsUnicode(false);

			modelBuilder.Entity<OtherLog>()
				.Property(e => e.log_subtype)
				.IsUnicode(false);

			modelBuilder.Entity<OtherLog>()
				.Property(e => e.status)
				.IsUnicode(false);

			modelBuilder.Entity<OtherLog>()
				.Property(e => e.priority)
				.IsUnicode(false);

			modelBuilder.Entity<OtherLog>()
				.Property(e => e.user_name)
				.IsUnicode(false);

			modelBuilder.Entity<OtherLog>()
				.Property(e => e.rawdata)
				.IsUnicode(false);

			modelBuilder.Entity<SecurityPolicy>()
				.Property(e => e.device_id)
				.IsUnicode(false);

			modelBuilder.Entity<SecurityPolicy>()
				.Property(e => e.timezone)
				.IsUnicode(false);

			modelBuilder.Entity<SecurityPolicy>()
				.Property(e => e.log_id)
				.IsUnicode(false);

			modelBuilder.Entity<SecurityPolicy>()
				.Property(e => e.log_component)
				.IsUnicode(false);

			modelBuilder.Entity<SecurityPolicy>()
				.Property(e => e.log_subtype)
				.IsUnicode(false);

			modelBuilder.Entity<SecurityPolicy>()
				.Property(e => e.status)
				.IsUnicode(false);

			modelBuilder.Entity<SecurityPolicy>()
				.Property(e => e.priority)
				.IsUnicode(false);

			modelBuilder.Entity<SecurityPolicy>()
				.Property(e => e.user_name)
				.IsUnicode(false);

			modelBuilder.Entity<SecurityPolicy>()
				.Property(e => e.user_gp)
				.IsUnicode(false);

			modelBuilder.Entity<SecurityPolicy>()
				.Property(e => e.application)
				.IsUnicode(false);

			modelBuilder.Entity<SecurityPolicy>()
				.Property(e => e.application_technology)
				.IsUnicode(false);

			modelBuilder.Entity<SecurityPolicy>()
				.Property(e => e.application_category)
				.IsUnicode(false);

			modelBuilder.Entity<SecurityPolicy>()
				.Property(e => e.in_interface)
				.IsUnicode(false);

			modelBuilder.Entity<SecurityPolicy>()
				.Property(e => e.out_interface)
				.IsUnicode(false);

			modelBuilder.Entity<SecurityPolicy>()
				.Property(e => e.src_mac)
				.IsUnicode(false);

			modelBuilder.Entity<SecurityPolicy>()
				.Property(e => e.src_ip)
				.IsUnicode(false);

			modelBuilder.Entity<SecurityPolicy>()
				.Property(e => e.src_country_code)
				.IsUnicode(false);

			modelBuilder.Entity<SecurityPolicy>()
				.Property(e => e.dst_ip)
				.IsUnicode(false);

			modelBuilder.Entity<SecurityPolicy>()
				.Property(e => e.dst_country_code)
				.IsUnicode(false);

			modelBuilder.Entity<SecurityPolicy>()
				.Property(e => e.protocol)
				.IsUnicode(false);

			modelBuilder.Entity<SecurityPolicy>()
				.Property(e => e.tran_src_ip)
				.IsUnicode(false);

			modelBuilder.Entity<SecurityPolicy>()
				.Property(e => e.tran_dst_ip)
				.IsUnicode(false);

			modelBuilder.Entity<SecurityPolicy>()
				.Property(e => e.srczone)
				.IsUnicode(false);

			modelBuilder.Entity<SecurityPolicy>()
				.Property(e => e.dstzone)
				.IsUnicode(false);

			modelBuilder.Entity<SecurityPolicy>()
				.Property(e => e.dir_disp)
				.IsUnicode(false);

			modelBuilder.Entity<SecurityPolicy>()
				.Property(e => e.connid)
				.IsUnicode(false);

			modelBuilder.Entity<SecurityPolicy>()
				.Property(e => e.vconnid)
				.IsUnicode(false);

			modelBuilder.Entity<SecurityPolicy>()
				.Property(e => e.hb_health)
				.IsUnicode(false);

			modelBuilder.Entity<SecurityPolicy>()
				.Property(e => e.otherdata)
				.IsUnicode(false);
		}
	}
}
