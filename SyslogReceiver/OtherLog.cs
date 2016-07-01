namespace SyslogReceiver
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OtherLog")]
    public partial class OtherLog
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
        public string log_type { get; set; }

        [StringLength(20)]
        public string log_component { get; set; }

        [StringLength(20)]
        public string log_subtype { get; set; }

        [StringLength(20)]
        public string status { get; set; }

        [StringLength(20)]
        public string priority { get; set; }

        [StringLength(20)]
        public string user_name { get; set; }

        public string rawdata { get; set; }
    }
}
