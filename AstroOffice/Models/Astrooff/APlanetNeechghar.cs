using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AstroOffice.Models.Astrooff
{
    [Table("a_planet_neechghar")]
    public partial class APlanetNeechghar
    {
        [Key]
        [Column("sno")]
        public int Sno { get; set; }
        [Column("planet")]
        public int? Planet { get; set; }
        [Column("house")]
        public int? House { get; set; }

        [ForeignKey("Planet")]
        [InverseProperty("APlanetNeechghars")]
        public virtual APlanetOld? PlanetNavigation { get; set; }
    }
}
