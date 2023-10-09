using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ASModels.Astrooff
{
    [Table("a_shatru_planet")]
    public partial class AShatruPlanet
    {
        [Key]
        [Column("sno")]
        public int Sno { get; set; }
        [Column("planet")]
        public int? Planet { get; set; }
        [Column("shatru")]
        public int? Shatru { get; set; }
    }
}
