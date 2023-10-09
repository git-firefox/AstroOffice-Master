using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ASModels.Astrooff
{
    [Table("A_vfal_upay")]
    public partial class AVfalUpay
    {
        [Key]
        [Column("sno")]
        public long Sno { get; set; }
        [Column("ruleno1")]
        public int Ruleno1 { get; set; }
        [Column("ruleno2")]
        public int? Ruleno2 { get; set; }
        [Column("hindi", TypeName = "text")]
        public string? Hindi { get; set; }
        [Column("eng", TypeName = "text")]
        public string? Eng { get; set; }
        [Column("tamil", TypeName = "text")]
        public string? Tamil { get; set; }
        [Column("telugu", TypeName = "text")]
        public string? Telugu { get; set; }
        [Column("kannada", TypeName = "text")]
        public string? Kannada { get; set; }
        [Column("bangla", TypeName = "text")]
        public string? Bangla { get; set; }
        [Column("marathi", TypeName = "text")]
        public string? Marathi { get; set; }
        [Column("punjabi", TypeName = "text")]
        public string? Punjabi { get; set; }
        [Column("gujarati", TypeName = "text")]
        public string? Gujarati { get; set; }
        [Column("child_hindi", TypeName = "text")]
        public string? ChildHindi { get; set; }
        [Column("child_eng", TypeName = "text")]
        public string? ChildEng { get; set; }
        [Column("child_tamil", TypeName = "text")]
        public string? ChildTamil { get; set; }
        [Column("child_telugu", TypeName = "text")]
        public string? ChildTelugu { get; set; }
        [Column("child_kannada", TypeName = "text")]
        public string? ChildKannada { get; set; }
        [Column("child_bangla", TypeName = "text")]
        public string? ChildBangla { get; set; }
        [Column("child_marathi", TypeName = "text")]
        public string? ChildMarathi { get; set; }
        [Column("child_punjabi", TypeName = "text")]
        public string? ChildPunjabi { get; set; }
        [Column("child_gujarati", TypeName = "text")]
        public string? ChildGujarati { get; set; }
        [Column("hindi_unicode")]
        public string? HindiUnicode { get; set; }
        [Column("child_hindi_unicode")]
        public string? ChildHindiUnicode { get; set; }
    }
}
