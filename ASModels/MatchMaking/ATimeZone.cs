using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ASModels.MatchMaking
{
    [Keyless]
    [Table("A_time_zone")]
    public partial class ATimeZone
    {
        [Column("sno")]
        public int Sno { get; set; }
        [Column("gmt")]
        public double? Gmt { get; set; }
        [Column("location")]
        [StringLength(255)]
        public string? Location { get; set; }
    }
}
