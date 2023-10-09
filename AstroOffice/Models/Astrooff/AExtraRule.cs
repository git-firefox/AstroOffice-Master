using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AstroOffice.Models.Astrooff
{
    [Keyless]
    [Table("A_extra_rules")]
    [Index("Sno", Name = "IX_A_extra_rules", IsUnique = true)]
    public partial class AExtraRule
    {
        [Column("sno")]
        public int Sno { get; set; }
        [Column("ruleno")]
        public int? Ruleno { get; set; }
        [Column("good")]
        public bool? Good { get; set; }
        [Column("planet")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Planet { get; set; }
        [Column("isplanet")]
        public bool? Isplanet { get; set; }
    }
}
