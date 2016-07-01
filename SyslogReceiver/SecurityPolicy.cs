namespace SyslogReceiver
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SecurityPolicy")]
    public partial class SecurityPolicy
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

        public int? duration { get; set; }

        public int? fw_rule_id { get; set; }

        public int? policy_type { get; set; }

        [StringLength(20)]
        public string user_name { get; set; }

        [StringLength(30)]
        public string user_gp { get; set; }

        public int? iap { get; set; }

        public int? ips_policy_id { get; set; }

        public int? appfilter_policy_id { get; set; }

        [StringLength(50)]
        public string application { get; set; }

        public int? application_risk { get; set; }

        [StringLength(50)]
        public string application_technology { get; set; }

        [StringLength(50)]
        public string application_category { get; set; }

        [StringLength(20)]
        public string in_interface { get; set; }

        [StringLength(20)]
        public string out_interface { get; set; }

        [StringLength(48)]
        public string src_mac { get; set; }

        [StringLength(48)]
        public string src_ip { get; set; }

        [StringLength(10)]
        public string src_country_code { get; set; }

        [StringLength(48)]
        public string dst_ip { get; set; }

        [StringLength(10)]
        public string dst_country_code { get; set; }

        [StringLength(10)]
        public string protocol { get; set; }

        public int? src_port { get; set; }

        public int? dst_port { get; set; }

        public int? sent_pkts { get; set; }

        public int? recv_pkts { get; set; }

        public int? sent_bytes { get; set; }

        public int? recv_bytes { get; set; }

        [StringLength(48)]
        public string tran_src_ip { get; set; }

        public int? tran_src_port { get; set; }

        [StringLength(48)]
        public string tran_dst_ip { get; set; }

        public int? tran_dst_port { get; set; }

        [StringLength(20)]
        public string srczone { get; set; }

        [StringLength(20)]
        public string dstzone { get; set; }

        [StringLength(20)]
        public string dir_disp { get; set; }

        [StringLength(20)]
        public string connid { get; set; }

        [StringLength(20)]
        public string vconnid { get; set; }

        [StringLength(20)]
        public string hb_health { get; set; }

		public string otherdata { get; set; }
	}
}
