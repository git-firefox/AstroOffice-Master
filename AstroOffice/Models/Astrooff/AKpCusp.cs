using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AstroOffice.Models.Astrooff
{
    [Keyless]
    [Table("A_kp_cusp")]
    public partial class AKpCusp
    {
        [Column("sno")]
        public short Sno { get; set; }
        [Column("house")]
        public short? House { get; set; }
        [Column("sublord")]
        public short? Sublord { get; set; }
        [Column("pred_hindi")]
        public string? PredHindi { get; set; }
        [Column("pred_english", TypeName = "text")]
        public string? PredEnglish { get; set; }
        [Column("isbad")]
        public bool? Isbad { get; set; }
        [Column("verybad")]
        public bool? Verybad { get; set; }
        [Column("wealth")]
        public bool? Wealth { get; set; }
        [Column("children")]
        public bool? Children { get; set; }
        [Column("married")]
        public bool? Married { get; set; }
        [Column("occupation")]
        public bool? Occupation { get; set; }
        [Column("disease")]
        public bool? Disease { get; set; }
        [Column("love_affair")]
        public bool? LoveAffair { get; set; }
        [Column("general")]
        public bool? General { get; set; }
        [Column("brother")]
        public bool? Brother { get; set; }
        [Column("mother_father")]
        public bool? MotherFather { get; set; }
        [Column("common")]
        public bool? Common { get; set; }
        [Column("male")]
        public bool? Male { get; set; }
        [Column("female")]
        public bool? Female { get; set; }
        [Column("shishu")]
        public bool? Shishu { get; set; }
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
        [Column("ptype")]
        [StringLength(20)]
        [Unicode(false)]
        public string? Ptype { get; set; }
        [Column("ruletype")]
        [StringLength(20)]
        [Unicode(false)]
        public string? Ruletype { get; set; }
    }
}
