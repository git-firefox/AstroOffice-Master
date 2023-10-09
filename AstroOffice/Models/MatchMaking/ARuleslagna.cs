using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AstroOffice.Models.MatchMaking
{
    [Keyless]
    [Table("A_ruleslagna")]
    public partial class ARuleslagna
    {
        [Column("sno")]
        public long Sno { get; set; }
        [Column("male", TypeName = "text")]
        public string? Male { get; set; }
        [Column("female", TypeName = "text")]
        public string? Female { get; set; }
        [Column("pred", TypeName = "text")]
        public string? Pred { get; set; }
        [Column("reference")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Reference { get; set; }
        [Column("marriage")]
        public int? Marriage { get; set; }
        [Column("death")]
        public int? Death { get; set; }
        [Column("affair")]
        public int? Affair { get; set; }
        [Column("rating")]
        public int? Rating { get; set; }
    }
}
