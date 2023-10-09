using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AstroOffice.Models.Astrooff
{
    [Keyless]
    [Table("A_kundli_mapping")]
    public partial class AKundliMapping
    {
        [Column("sno")]
        public long Sno { get; set; }
        [Column("kundliid")]
        public long? Kundliid { get; set; }
        [Column("house")]
        public int? House { get; set; }
        [Column("rashi")]
        public int? Rashi { get; set; }
        [Column("planet")]
        public int? Planet { get; set; }
        [Column("degree", TypeName = "money")]
        public decimal? Degree { get; set; }
    }
}
