using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ASModels.Astrooff
{
    [Table("a_planet_relations")]
    public partial class APlanetRelation
    {
        [Key]
        [Column("sno")]
        public int Sno { get; set; }
        [Column("planet1")]
        public int? Planet1 { get; set; }
        [Column("planet2")]
        public int? Planet2 { get; set; }
        [Column("relation")]
        public int? Relation { get; set; }
    }
}
