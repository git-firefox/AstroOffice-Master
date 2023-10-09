using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AstroOffice.Models.MatchMaking
{
    [Keyless]
    [Table("A_kp")]
    public partial class AKp
    {
        [Column("sno")]
        public long Sno { get; set; }
        [Column("kpno")]
        public long? Kpno { get; set; }
        [Column("planet1")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Planet1 { get; set; }
        [Column("planet2")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Planet2 { get; set; }
        [Column("planet3")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Planet3 { get; set; }
        [Column("kp_work", TypeName = "text")]
        public string? KpWork { get; set; }
    }
}
