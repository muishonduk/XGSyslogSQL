namespace SyslogReceiver
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ContentFilter")]
    public partial class ContentFilter
    {
        public long id { get; set; }

        [Required]
        [StringLength(20)]
        public string device_id { get; set; }

        public DateTime datet { get; set; }

        [Required]
        [StringLength(5)]
        public string timezone { get; set; }

        [StringLength(20)]
        public string log_id { get; set; }

        [StringLength(20)]
        public string log_component { get; set; }

        [StringLength(20)]
        public string log_subtype { get; set; }

        [StringLength(20)]
        public string status { get; set; }

        [StringLength(20)]
        public string priority { get; set; }

        public int? fw_rule_id { get; set; }

        [StringLength(20)]
        public string user_name { get; set; }

        [StringLength(30)]
        public string user_gp { get; set; }

		public int? application_filter_policy { get; set; }

		[StringLength(30)]
		public string application_name { get; set; }

		public int? application_risk { get; set; }

		[StringLength(20)]
		public string application_technology { get; set; }

		[StringLength(20)]
		public string application_category { get; set; }

		[StringLength(10)]
		public string src_country_code { get; set; }

		[StringLength(10)]
		public string dst_country_code { get; set; }

		public int? iap { get; set; }

        [StringLength(30)]
        public string category { get; set; }

        [StringLength(20)]
        public string category_type { get; set; }

        public string url { get; set; }

        [StringLength(150)]
        public string contenttype { get; set; }

        [StringLength(20)]
        public string override_token { get; set; }

        [StringLength(20)]
        public string httpresponsecode { get; set; }

        [StringLength(48)]
        public string src_ip { get; set; }

        [StringLength(48)]
        public string dst_ip { get; set; }

        [StringLength(10)]
        public string protocol { get; set; }

        public int? src_port { get; set; }

        public int? dst_port { get; set; }

        public int? sent_bytes { get; set; }

        public int? recv_bytes { get; set; }

        [StringLength(200)]
        public string domain { get; set; }

		public string otherdata { get; set; }
    }
}
