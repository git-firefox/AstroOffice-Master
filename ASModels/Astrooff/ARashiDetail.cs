using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ASModels.Astrooff
{
    [Keyless]
    [Table("A_rashi_details")]
    public partial class ARashiDetail
    {
        [Column("sno")]
        public int Sno { get; set; }
        [Column("rcode")]
        public int? Rcode { get; set; }
        [Column("relative", TypeName = "text")]
        public string? Relative { get; set; }
        [Column("quality", TypeName = "text")]
        public string? Quality { get; set; }
        [Column("works", TypeName = "text")]
        public string? Works { get; set; }
        [Column("bodypart", TypeName = "text")]
        public string? Bodypart { get; set; }
        [Column("place", TypeName = "text")]
        public string? Place { get; set; }
        [Column("things", TypeName = "text")]
        public string? Things { get; set; }
    }
}
