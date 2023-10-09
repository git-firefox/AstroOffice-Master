using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ASModels.Astrooff
{
    [Table("a_soye_greh_jagao")]
    public partial class ASoyeGrehJagao
    {
        [Key]
        [Column("sno")]
        public int Sno { get; set; }
        [Column("planet")]
        public int? Planet { get; set; }
        [Column("jagao")]
        [StringLength(500)]
        [Unicode(false)]
        public string? Jagao { get; set; }
        [Column("jagao_eng", TypeName = "text")]
        public string? JagaoEng { get; set; }
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
        [Column("gujarati", TypeName = "text")]
        public string? Gujarati { get; set; }
        [Column("punjabi", TypeName = "text")]
        public string? Punjabi { get; set; }
    }
}
