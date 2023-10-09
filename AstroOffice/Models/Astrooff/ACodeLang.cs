using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AstroOffice.Models.Astrooff
{
    [Table("A_code_lang")]
    public partial class ACodeLang
    {
        [Key]
        [Column("sno")]
        public long Sno { get; set; }
        [Column("rulecode")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Rulecode { get; set; }
        [Column("hindi", TypeName = "text")]
        public string? Hindi { get; set; }
        [Column("english", TypeName = "text")]
        public string? English { get; set; }
        [Column("tamil", TypeName = "text")]
        public string? Tamil { get; set; }
        [Column("kannada", TypeName = "text")]
        public string? Kannada { get; set; }
        [Column("bangla", TypeName = "text")]
        public string? Bangla { get; set; }
        [Column("marathi", TypeName = "text")]
        public string? Marathi { get; set; }
        [Column("punjabi", TypeName = "text")]
        public string? Punjabi { get; set; }
        [Column("telugu", TypeName = "text")]
        public string? Telugu { get; set; }
        [Column("gujrati", TypeName = "text")]
        public string? Gujrati { get; set; }
        [Column("hindi_unicode")]
        public string? HindiUnicode { get; set; }
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
