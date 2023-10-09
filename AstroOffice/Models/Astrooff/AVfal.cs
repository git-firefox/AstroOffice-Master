using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AstroOffice.Models.Astrooff
{
    [Keyless]
    [Table("A_vfal")]
    public partial class AVfal
    {
        [Column("ruleno", TypeName = "decimal(19, 0)")]
        public decimal? Ruleno { get; set; }
        [Column("pred")]
        public string? Pred { get; set; }
    }
}
