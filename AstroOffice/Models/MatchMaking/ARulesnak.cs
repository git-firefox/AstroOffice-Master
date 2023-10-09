using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AstroOffice.Models.MatchMaking
{
    [Keyless]
    [Table("A_rulesnak")]
    public partial class ARulesnak
    {
        [Column("sno")]
        public long Sno { get; set; }
        [Column("charan1", TypeName = "text")]
        public string? Charan1 { get; set; }
        [Column("charan2", TypeName = "text")]
        public string? Charan2 { get; set; }
        [Column("charan3", TypeName = "text")]
        public string? Charan3 { get; set; }
        [Column("charan4", TypeName = "text")]
        public string? Charan4 { get; set; }
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
        [Column("marriage1")]
        public int? Marriage1 { get; set; }
        [Column("death1")]
        public int? Death1 { get; set; }
        [Column("affair1")]
        public int? Affair1 { get; set; }
        [Column("marriage2")]
        public int? Marriage2 { get; set; }
        [Column("death2")]
        public int? Death2 { get; set; }
        [Column("affair2")]
        public int? Affair2 { get; set; }
        [Column("marriage3")]
        public int? Marriage3 { get; set; }
        [Column("death3")]
        public int? Death3 { get; set; }
        [Column("affair3")]
        public int? Affair3 { get; set; }
        [Column("marriage4")]
        public int? Marriage4 { get; set; }
        [Column("death4")]
        public int? Death4 { get; set; }
        [Column("affair4")]
        public int? Affair4 { get; set; }
        [Column("rating")]
        public int? Rating { get; set; }
        [Column("rating1")]
        public int? Rating1 { get; set; }
        [Column("rating2")]
        public int? Rating2 { get; set; }
        [Column("rating3")]
        public int? Rating3 { get; set; }
        [Column("rating4")]
        public int? Rating4 { get; set; }
    }
}
