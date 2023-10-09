using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AstroOffice.Models.Astrooff
{
    [Keyless]
    [Table("A_upay1")]
    public partial class AUpay1
    {
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
    }
}
