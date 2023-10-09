using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AstroOffice.Models.Astrooff
{
    [Table("a_planet_uchghar")]
    public partial class APlanetUchghar
    {
        [Key]
        [Column("sno")]
        public int Sno { get; set; }
        [Column("planet")]
        public int? Planet { get; set; }
        [Column("house")]
        public int? House { get; set; }

        [ForeignKey("Planet")]
        [InverseProperty("APlanetUchghars")]
        public virtual APlanetOld? PlanetNavigation { get; set; }
    }
}
