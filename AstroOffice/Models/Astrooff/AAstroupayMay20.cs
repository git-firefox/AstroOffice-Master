using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AstroOffice.Models.Astrooff
{
    [Keyless]
    [Table("A_astroupayMay20")]
    public partial class AAstroupayMay20
    {
        [Column("sno")]
        public long Sno { get; set; }
        [Column("ruleformula")]
        [StringLength(500)]
        [Unicode(false)]
        public string? Ruleformula { get; set; }
        [Column(TypeName = "text")]
        public string? Upay { get; set; }
        [Column("upay_marathi", TypeName = "text")]
        public string? UpayMarathi { get; set; }
        [Column("upay_punjabi", TypeName = "text")]
        public string? UpayPunjabi { get; set; }
        [Column("upay_english", TypeName = "text")]
        public string? UpayEnglish { get; set; }
        [Column("upay_gujarati", TypeName = "text")]
        public string? UpayGujarati { get; set; }
        [Column("upay_tamil", TypeName = "text")]
        public string? UpayTamil { get; set; }
        [Column("upay_telugu", TypeName = "text")]
        public string? UpayTelugu { get; set; }
        [Column("upay_bangla", TypeName = "text")]
        public string? UpayBangla { get; set; }
        [Column("upay_kannada", TypeName = "text")]
        public string? UpayKannada { get; set; }
    }
}
