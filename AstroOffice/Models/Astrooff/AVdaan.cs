using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AstroOffice.Models.Astrooff
{
    [Table("a_vdaan")]
    public partial class AVdaan
    {
        [Key]
        [Column("sno")]
        public long Sno { get; set; }
        [Column("planet")]
        [StringLength(10)]
        [Unicode(false)]
        public string? Planet { get; set; }
        [Column("vdaan")]
        [StringLength(500)]
        [Unicode(false)]
        public string? Vdaan { get; set; }
        [Column("color")]
        [StringLength(500)]
        [Unicode(false)]
        public string? Color { get; set; }
        [Column("english_vdaan")]
        [StringLength(500)]
        [Unicode(false)]
        public string? EnglishVdaan { get; set; }
        [Column("english_color")]
        [StringLength(500)]
        [Unicode(false)]
        public string? EnglishColor { get; set; }
        [Column("tamil_vdaan")]
        [StringLength(500)]
        [Unicode(false)]
        public string? TamilVdaan { get; set; }
        [Column("tamil_color")]
        [StringLength(500)]
        [Unicode(false)]
        public string? TamilColor { get; set; }
        [Column("telugu_vdaan")]
        [StringLength(500)]
        [Unicode(false)]
        public string? TeluguVdaan { get; set; }
        [Column("telugu_color")]
        [StringLength(500)]
        [Unicode(false)]
        public string? TeluguColor { get; set; }
        [Column("bangla_vdaan")]
        [StringLength(500)]
        [Unicode(false)]
        public string? BanglaVdaan { get; set; }
        [Column("bangla_color")]
        [StringLength(500)]
        [Unicode(false)]
        public string? BanglaColor { get; set; }
        [Column("kannada_vdaan")]
        [StringLength(500)]
        [Unicode(false)]
        public string? KannadaVdaan { get; set; }
        [Column("kannada_color")]
        [StringLength(500)]
        [Unicode(false)]
        public string? KannadaColor { get; set; }
        [Column("marathi_vdaan")]
        [StringLength(500)]
        [Unicode(false)]
        public string? MarathiVdaan { get; set; }
        [Column("marathi_color")]
        [StringLength(500)]
        [Unicode(false)]
        public string? MarathiColor { get; set; }
        [Column("punjabi_vdaan")]
        [StringLength(500)]
        [Unicode(false)]
        public string? PunjabiVdaan { get; set; }
        [Column("punjabi_color")]
        [StringLength(500)]
        [Unicode(false)]
        public string? PunjabiColor { get; set; }
        [Column("gujarati_vdaan")]
        [StringLength(500)]
        [Unicode(false)]
        public string? GujaratiVdaan { get; set; }
        [Column("gujarati_color")]
        [StringLength(500)]
        [Unicode(false)]
        public string? GujaratiColor { get; set; }
        [Column("inhouse")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Inhouse { get; set; }
        [Column("outhouse")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Outhouse { get; set; }
        [Column("vdaan_unicode")]
        public string? VdaanUnicode { get; set; }
        [Column("color_unicode")]
        public string? ColorUnicode { get; set; }
        [Column("punjabi_vdaan_unicode")]
        public string? PunjabiVdaanUnicode { get; set; }
        [Column("punjabi_color_unicode")]
        public string? PunjabiColorUnicode { get; set; }
        [Column("tamil_vdaan_unicode")]
        public string? TamilVdaanUnicode { get; set; }
        [Column("tamil_color_unicode")]
        public string? TamilColorUnicode { get; set; }
        [Column("telugu_vdaan_unicode")]
        public string? TeluguVdaanUnicode { get; set; }
        [Column("telugu_color_unicode")]
        public string? TeluguColorUnicode { get; set; }
        [Column("oriya_vdaan_unicode")]
        public string? OriyaVdaanUnicode { get; set; }
        [Column("oriya_color_unicode")]
        public string? OriyaColorUnicode { get; set; }
        [Column("bangla_vdaan_unicode")]
        public string? BanglaVdaanUnicode { get; set; }
        [Column("bangla_color_unicode")]
        public string? BanglaColorUnicode { get; set; }
        [Column("malayalam_vdaan_unicode")]
        public string? MalayalamVdaanUnicode { get; set; }
        [Column("malayalam_color_unicode")]
        public string? MalayalamColorUnicode { get; set; }
        [Column("marathi_vdaan_unicode")]
        public string? MarathiVdaanUnicode { get; set; }
        [Column("marathi_color_unicode")]
        public string? MarathiColorUnicode { get; set; }
        [Column("assamese_vdaan_unicode")]
        public string? AssameseVdaanUnicode { get; set; }
        [Column("assamese_color_unicode")]
        public string? AssameseColorUnicode { get; set; }
        [Column("gujarati_vdaan_unicode")]
        public string? GujaratiVdaanUnicode { get; set; }
        [Column("gujarati_color_unicode")]
        public string? GujaratiColorUnicode { get; set; }
        [Column("kannada_vdaan_unicode")]
        public string? KannadaVdaanUnicode { get; set; }
        [Column("kannada_color_unicode")]
        public string? KannadaColorUnicode { get; set; }
    }
}
