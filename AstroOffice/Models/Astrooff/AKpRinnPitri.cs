using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AstroOffice.Models.Astrooff
{
    [Keyless]
    [Table("A_kp_rinn_pitri")]
    public partial class AKpRinnPitri
    {
        [Column("sno")]
        public int Sno { get; set; }
        [Column("outhouse", TypeName = "text")]
        public string? Outhouse { get; set; }
        [Column("inhouse", TypeName = "text")]
        public string? Inhouse { get; set; }
        [Column("pred_hindi")]
        public string? PredHindi { get; set; }
        [Column("pred_english", TypeName = "text")]
        public string? PredEnglish { get; set; }
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
        [Column("pred_kannada")]
        public string? PredKannada { get; set; }
        [Column("pred_gujarati")]
        public string? PredGujarati { get; set; }
    }
}
