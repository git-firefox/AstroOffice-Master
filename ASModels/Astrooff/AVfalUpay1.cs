using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ASModels.Astrooff
{
    [Keyless]
    [Table("A_vfal_upay1")]
    public partial class AVfalUpay1
    {
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
    }
}
