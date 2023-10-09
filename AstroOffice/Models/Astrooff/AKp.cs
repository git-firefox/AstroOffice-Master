using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AstroOffice.Models.Astrooff
{
    [Keyless]
    [Table("A_kp")]
    public partial class AKp
    {
        [Column("sno")]
        public long Sno { get; set; }
        [Column("kpno")]
        public long? Kpno { get; set; }
        [Column("planet1")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Planet1 { get; set; }
        [Column("planet2")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Planet2 { get; set; }
        [Column("planet3")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Planet3 { get; set; }
        [Column("hindi")]
        public string? Hindi { get; set; }
        [Column("english", TypeName = "text")]
        public string? English { get; set; }
        [Column("bangla", TypeName = "text")]
        public string? Bangla { get; set; }
        [Column("tamil", TypeName = "text")]
        public string? Tamil { get; set; }
        [Column("telugu", TypeName = "text")]
        public string? Telugu { get; set; }
        [Column("kannada", TypeName = "text")]
        public string? Kannada { get; set; }
        [Column("marathi", TypeName = "text")]
        public string? Marathi { get; set; }
        [Column("punjabi", TypeName = "text")]
        public string? Punjabi { get; set; }
        [Column("gujarati", TypeName = "text")]
        public string? Gujarati { get; set; }
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
