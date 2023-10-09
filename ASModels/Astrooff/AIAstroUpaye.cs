using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ASModels.Astrooff
{
    [Table("a_iAstroUpaye")]
    public partial class AIAstroUpaye
    {
        [Key]
        [Column("sno")]
        public long Sno { get; set; }
        [Column("ruleno")]
        public long? Ruleno { get; set; }
        [Column("skip")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Skip { get; set; }
        [Column("vfal")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Vfal { get; set; }
        [Column("pred", TypeName = "text")]
        public string? Pred { get; set; }
        [Column("pred_english", TypeName = "text")]
        public string? PredEnglish { get; set; }
        [Column("pred_marathi", TypeName = "text")]
        public string? PredMarathi { get; set; }
        [Column("pred_punjabi", TypeName = "text")]
        public string? PredPunjabi { get; set; }
        [Column("pred_gujarati", TypeName = "text")]
        public string? PredGujarati { get; set; }
        [Column("pred_tamil", TypeName = "text")]
        public string? PredTamil { get; set; }
        [Column("pred_telugu", TypeName = "text")]
        public string? PredTelugu { get; set; }
        [Column("pred_bangla", TypeName = "text")]
        public string? PredBangla { get; set; }
        [Column("pred_kannada", TypeName = "text")]
        public string? PredKannada { get; set; }
    }
}
