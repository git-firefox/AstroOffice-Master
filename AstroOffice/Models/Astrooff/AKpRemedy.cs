using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AstroOffice.Models.Astrooff
{
    [Table("A_kp_remedy")]
    public partial class AKpRemedy
    {
        [Key]
        [Column("sno")]
        public long Sno { get; set; }
        [Column("rulecode")]
        public int? Rulecode { get; set; }
        [Column("planet")]
        public int? Planet { get; set; }
        [Column("house")]
        public int? House { get; set; }
        [Column("pred_hindi")]
        public string? PredHindi { get; set; }
        [Column("pred_english", TypeName = "text")]
        public string? PredEnglish { get; set; }
        [Column("ptype")]
        [StringLength(10)]
        [Unicode(false)]
        public string? Ptype { get; set; }
        [Column("planethouse")]
        [StringLength(20)]
        [Unicode(false)]
        public string? Planethouse { get; set; }
        [Column("pred_punjabi")]
        public string? PredPunjabi { get; set; }
        [Column("pred_tamil")]
        public string? PredTamil { get; set; }
        [Column("pred_telugu")]
        public string? PredTelugu { get; set; }
        [Column("pred_oriya")]
        public string? PredOriya { get; set; }
        [Column("pred_bengali")]
        public string? PredBengali { get; set; }
        [Column("pred_malayalam")]
        public string? PredMalayalam { get; set; }
        [Column("pred_marathi")]
        public string? PredMarathi { get; set; }
        [Column("pred_assamese")]
        public string? PredAssamese { get; set; }
        [Column("pred_gujarati")]
        public string? PredGujarati { get; set; }
        [Column("pred_kannada")]
        public string? PredKannada { get; set; }
    }
}
