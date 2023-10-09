using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AstroOffice.Models.Astrooff
{
    [Keyless]
    [Table("A_rulesDump")]
    public partial class ARulesDump
    {
        [Column("sno")]
        public long Sno { get; set; }
        [Column("ruleformula")]
        [StringLength(1000)]
        [Unicode(false)]
        public string? Ruleformula { get; set; }
        [Column("isbad")]
        public bool? Isbad { get; set; }
        [Column("title")]
        [StringLength(2000)]
        [Unicode(false)]
        public string? Title { get; set; }
        [Column("actualformula", TypeName = "text")]
        public string? Actualformula { get; set; }
        [Column("reference")]
        [StringLength(500)]
        [Unicode(false)]
        public string? Reference { get; set; }
        [Column("ruletype")]
        [StringLength(20)]
        [Unicode(false)]
        public string? Ruletype { get; set; }
        [Column("planettime")]
        public int? Planettime { get; set; }
        [Column("profit")]
        public int? Profit { get; set; }
        [Column("santan")]
        public int? Santan { get; set; }
        [Column("married")]
        public int? Married { get; set; }
        [Column("occupation")]
        public int? Occupation { get; set; }
        [Column("disease")]
        public int? Disease { get; set; }
        [Column("love_affair")]
        public int? LoveAffair { get; set; }
        [Column("confidence")]
        public int? Confidence { get; set; }
        [Column("brother")]
        public int? Brother { get; set; }
        [Column("mother_father")]
        public int? MotherFather { get; set; }
        [Column("family")]
        public int? Family { get; set; }
        [Column("memory")]
        public int? Memory { get; set; }
    }
}
