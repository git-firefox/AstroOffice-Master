using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ASModels.Astrooff
{
    [Table("A_kp_sublord_pred")]
    public partial class AKpSublordPred
    {
        [Key]
        [Column("sno")]
        public long Sno { get; set; }
        [Column("house")]
        public int? House { get; set; }
        [Column("sublord")]
        public int? Sublord { get; set; }
        [Column("pred_hindi")]
        public string? PredHindi { get; set; }
        [Column("pred_english", TypeName = "text")]
        public string? PredEnglish { get; set; }
        [Column("punjabi_unicode")]
        public string? PunjabiUnicode { get; set; }
        [Column("tamil_unicode")]
        public string? TamilUnicode { get; set; }
        [Column("telugu_unicode")]
        public string? TeluguUnicode { get; set; }
        [Column("oriya_unicode")]
        public string? OriyaUnicode { get; set; }
        [Column("bangla_unicode")]
        public string? BanglaUnicode { get; set; }
        [Column("malayalam_unicode")]
        public string? MalayalamUnicode { get; set; }
        [Column("marathi_unicode")]
        public string? MarathiUnicode { get; set; }
        [Column("assamese_unicode")]
        public string? AssameseUnicode { get; set; }
        [Column("gujarati_unicode")]
        public string? GujaratiUnicode { get; set; }
        [Column("kannada_unicode")]
        public string? KannadaUnicode { get; set; }
    }
}
