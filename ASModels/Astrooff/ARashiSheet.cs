using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ASModels.Astrooff
{
    [Keyless]
    [Table("A_rashi_sheet")]
    public partial class ARashiSheet
    {
        [Column("sno")]
        public int Sno { get; set; }
        [Column("house")]
        public int? House { get; set; }
        [Column("from_hour")]
        public int? FromHour { get; set; }
        [Column("from_minute")]
        public int? FromMinute { get; set; }
        [Column("from_second")]
        public int? FromSecond { get; set; }
        [Column("to_hour")]
        public int? ToHour { get; set; }
        [Column("to_minute")]
        public int? ToMinute { get; set; }
        [Column("to_second")]
        public int? ToSecond { get; set; }
        [Column("planet1")]
        public int? Planet1 { get; set; }
        [Column("planet2")]
        public int? Planet2 { get; set; }
        [Column("planet3")]
        public int? Planet3 { get; set; }
    }
}
