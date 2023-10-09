using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ASModels.Astrooff
{
    [Keyless]
    [Table("a_planet")]
    public partial class APlanet
    {
        [Column("sno")]
        public int Sno { get; set; }
        [Column("planet")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Planet { get; set; }
        [Column("pakka_ghar")]
        public int? PakkaGhar { get; set; }
        [Column("color")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Color { get; set; }
        [Column("karya")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Karya { get; set; }
        [Column("samay")]
        [MaxLength(50)]
        public byte[]? Samay { get; set; }
        [Column("din")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Din { get; set; }
        [Column("gender")]
        public int? Gender { get; set; }
        [Column("planethindi", TypeName = "text")]
        public string? Planethindi { get; set; }
        [Column("planetenglish")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Planetenglish { get; set; }
        [Column("planet_lord")]
        [StringLength(50)]
        [Unicode(false)]
        public string? PlanetLord { get; set; }
    }
}
