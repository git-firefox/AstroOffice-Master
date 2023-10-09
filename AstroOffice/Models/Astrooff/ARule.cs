using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AstroOffice.Models.Astrooff
{
    [Table("A_rules")]
    public partial class ARule
    {
        [Key]
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
        [StringLength(50)]
        [Unicode(false)]
        public string? Ruletype { get; set; }
        [Column("planettime")]
        public int? Planettime { get; set; }
        [Column("profit")]
        public bool? Profit { get; set; }
        [Column("santan")]
        public bool? Santan { get; set; }
        [Column("married")]
        public bool? Married { get; set; }
        [Column("occupation")]
        public bool Occupation { get; set; }
        [Column("disease")]
        public bool? Disease { get; set; }
        [Column("love_affair")]
        public bool? LoveAffair { get; set; }
        [Column("confidence")]
        public bool? Confidence { get; set; }
        [Column("brother")]
        public bool Brother { get; set; }
        [Column("mother_father")]
        public bool? MotherFather { get; set; }
        [Column("family")]
        public bool? Family { get; set; }
        [Column("memory")]
        public bool? Memory { get; set; }
        [Column("upay")]
        public int? Upay { get; set; }
        [Column("priority")]
        public int? Priority { get; set; }
        [Column("refno")]
        public long? Refno { get; set; }
        [Column("rulenature")]
        public int? Rulenature { get; set; }
        [Column("vfalyears", TypeName = "text")]
        public string? Vfalyears { get; set; }
        [Column("common")]
        public bool? Common { get; set; }
        [Column("male")]
        public bool? Male { get; set; }
        [Column("female")]
        public bool? Female { get; set; }
        [Column("bachpan")]
        public bool? Bachpan { get; set; }
        [Column("kishor")]
        public bool? Kishor { get; set; }
        [Column("yuva")]
        public bool? Yuva { get; set; }
        [Column("madhya")]
        public bool? Madhya { get; set; }
        [Column("budhapa")]
        public bool? Budhapa { get; set; }
        [Column("mainplanet")]
        public int? Mainplanet { get; set; }
        [Column("shishu")]
        public bool? Shishu { get; set; }
        [Column("good")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Good { get; set; }
        [Column("bad")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Bad { get; set; }
        [Column("kayam")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Kayam { get; set; }
        [Column("multiupay")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Multiupay { get; set; }
        [Column("planetupay")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Planetupay { get; set; }
        [Column("lagan")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Lagan { get; set; }
        [Column("rashi")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Rashi { get; set; }
    }
}
