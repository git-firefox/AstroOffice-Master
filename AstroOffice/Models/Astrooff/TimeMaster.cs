using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AstroOffice.Models.Astrooff
{
    [Table("time_master")]
    public partial class TimeMaster
    {
        [Key]
        [Column("sno")]
        public long Sno { get; set; }
        [Column("slot")]
        public int? Slot { get; set; }
        [Column("begintime")]
        [StringLength(5)]
        [Unicode(false)]
        public string? Begintime { get; set; }
        [Column("endtime")]
        [StringLength(5)]
        [Unicode(false)]
        public string? Endtime { get; set; }
        [Column("interval")]
        [StringLength(5)]
        [Unicode(false)]
        public string? Interval { get; set; }
        [Column("slotstatus")]
        public bool? Slotstatus { get; set; }
    }
}
