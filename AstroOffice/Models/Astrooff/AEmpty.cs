using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AstroOffice.Models.Astrooff
{
    [Keyless]
    [Table("A_empty")]
    public partial class AEmpty
    {
        [Column("sno")]
        public double? Sno { get; set; }
        [Column("ruleformula")]
        [StringLength(255)]
        public string? Ruleformula { get; set; }
        [Column("actualformula")]
        public string? Actualformula { get; set; }
    }
}
