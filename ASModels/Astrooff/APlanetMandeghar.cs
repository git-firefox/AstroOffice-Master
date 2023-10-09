using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ASModels.Astrooff
{
    [Table("a_planet_mandeghar")]
    public partial class APlanetMandeghar
    {
        [Key]
        [Column("sno")]
        public int Sno { get; set; }
        [Column("planet")]
        public int? Planet { get; set; }
        [Column("house")]
        public int House { get; set; }

        [ForeignKey("Planet")]
        [InverseProperty("APlanetMandeghars")]
        public virtual APlanetOld? PlanetNavigation { get; set; }
    }
}
