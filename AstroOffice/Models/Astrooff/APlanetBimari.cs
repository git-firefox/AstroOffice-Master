using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AstroOffice.Models.Astrooff
{
    [Table("a_planet_bimari")]
    public partial class APlanetBimari
    {
        [Key]
        [Column("sno")]
        public long Sno { get; set; }
        [Column("planet")]
        public int? Planet { get; set; }
        [Column("bimari")]
        [StringLength(250)]
        [Unicode(false)]
        public string? Bimari { get; set; }

        [ForeignKey("Planet")]
        [InverseProperty("APlanetBimaris")]
        public virtual APlanetOld? PlanetNavigation { get; set; }
    }
}
