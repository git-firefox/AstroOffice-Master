using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ASModels.Astrooff
{
    [Keyless]
    [Table("A_lagna")]
    public partial class ALagna
    {
        [Column("sno", TypeName = "decimal(19, 0)")]
        public decimal Sno { get; set; }
        [Column("rashi")]
        public int? Rashi { get; set; }
        [Column("planet1")]
        public int? Planet1 { get; set; }
        [Column("house")]
        public int? House { get; set; }
        [Column("planet2")]
        public int? Planet2 { get; set; }
        [Column("pred")]
        public string? Pred { get; set; }
    }
}
