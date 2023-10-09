using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AstroOffice.Models.MatchMaking
{
    [Keyless]
    [Table("A_NakGrahDrishti")]
    public partial class ANakGrahDrishti
    {
        [Column("sno")]
        public long Sno { get; set; }
        [Column("nak")]
        public int? Nak { get; set; }
        [Column("planet1")]
        public int? Planet1 { get; set; }
        [Column("planet2")]
        public int? Planet2 { get; set; }
        [Column("pred", TypeName = "text")]
        public string? Pred { get; set; }
        [Column("reference")]
        [StringLength(500)]
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
