using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AstroOffice.Models.MatchMaking
{
    [Keyless]
    [Table("A_NakGrahDrishtihindi")]
    public partial class ANakGrahDrishtihindi
    {
        [Column("sno", TypeName = "decimal(19, 0)")]
        public decimal Sno { get; set; }
        [Column("nak")]
        public int? Nak { get; set; }
        [Column("planet1")]
        public int? Planet1 { get; set; }
        [Column("planet2")]
        public int? Planet2 { get; set; }
        [Column("male")]
        public string? Male { get; set; }
        [Column("female")]
        public string? Female { get; set; }
        [Column("pred")]
        public string? Pred { get; set; }
        [Column("eng_pred")]
        public string? EngPred { get; set; }
        [Column("reference")]
        public string? Reference { get; set; }
        [Column("marriage", TypeName = "decimal(18, 0)")]
        public decimal? Marriage { get; set; }
        [Column("death", TypeName = "decimal(18, 0)")]
        public decimal? Death { get; set; }
        [Column("affair", TypeName = "decimal(18, 0)")]
        public decimal? Affair { get; set; }
        [Column("rating", TypeName = "decimal(18, 0)")]
        public decimal? Rating { get; set; }
    }
}
