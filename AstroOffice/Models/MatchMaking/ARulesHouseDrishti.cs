using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AstroOffice.Models.MatchMaking
{
    [Keyless]
    [Table("A_RulesHouseDrishti")]
    public partial class ARulesHouseDrishti
    {
        [Column("sno")]
        public long Sno { get; set; }
        [Column("house")]
        public int? House { get; set; }
        [Column("planet")]
        public int? Planet { get; set; }
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
        [Column("marriage", TypeName = "numeric(18, 0)")]
        public decimal? Marriage { get; set; }
        [Column("death", TypeName = "numeric(18, 0)")]
        public decimal? Death { get; set; }
        [Column("affair", TypeName = "numeric(18, 0)")]
        public decimal? Affair { get; set; }
        [Column("rating")]
        public int? Rating { get; set; }
    }
}
