using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ASModels.Astrooff
{
    [Table("A_upayindex")]
    public partial class AUpayindex
    {
        [Key]
        [Column("sno")]
        public long Sno { get; set; }
        [Column("hindi", TypeName = "text")]
        public string? Hindi { get; set; }
        [Column("english", TypeName = "text")]
        public string? English { get; set; }
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
        [Column("hindi_unicode")]
        public string? HindiUnicode { get; set; }
        [Column("marathi_unicode")]
        public string? MarathiUnicode { get; set; }
    }
}
