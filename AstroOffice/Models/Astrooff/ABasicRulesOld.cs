using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AstroOffice.Models.Astrooff
{
    [Table("a_basic_rules_old")]
    public partial class ABasicRulesOld
    {
        [Key]
        [Column("sno")]
        public long Sno { get; set; }
        [Column("house")]
        public int? House { get; set; }
        [Column("planet")]
        public int? Planet { get; set; }
        [Column("basicrule", TypeName = "ntext")]
        public string? Basicrule { get; set; }

        [ForeignKey("Planet")]
        [InverseProperty("ABasicRulesOlds")]
        public virtual APlanetOld? PlanetNavigation { get; set; }
    }
}
