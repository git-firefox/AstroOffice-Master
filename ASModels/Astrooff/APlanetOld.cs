using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ASModels.Astrooff
{
    [Table("a_planet_old")]
    public partial class APlanetOld
    {
        public APlanetOld()
        {
            ABasicRules = new HashSet<ABasicRule>();
            ABasicRulesOlds = new HashSet<ABasicRulesOld>();
            APlanetBimaris = new HashSet<APlanetBimari>();
            APlanetMandeghars = new HashSet<APlanetMandeghar>();
            APlanetNeechghars = new HashSet<APlanetNeechghar>();
            APlanetShreshtghars = new HashSet<APlanetShreshtghar>();
            APlanetUchghars = new HashSet<APlanetUchghar>();
        }

        [Key]
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
        [StringLength(1000)]
        [Unicode(false)]
        public string? Karya { get; set; }
        [Column("samay")]
        [StringLength(250)]
        [Unicode(false)]
        public string? Samay { get; set; }
        [Column("din")]
        [StringLength(250)]
        [Unicode(false)]
        public string? Din { get; set; }
        [Column("gender")]
        public int? Gender { get; set; }
        [Column("planethindi", TypeName = "ntext")]
        public string? Planethindi { get; set; }

        [InverseProperty("PlanetNavigation")]
        public virtual ICollection<ABasicRule> ABasicRules { get; set; }
        [InverseProperty("PlanetNavigation")]
        public virtual ICollection<ABasicRulesOld> ABasicRulesOlds { get; set; }
        [InverseProperty("PlanetNavigation")]
        public virtual ICollection<APlanetBimari> APlanetBimaris { get; set; }
        [InverseProperty("PlanetNavigation")]
        public virtual ICollection<APlanetMandeghar> APlanetMandeghars { get; set; }
        [InverseProperty("PlanetNavigation")]
        public virtual ICollection<APlanetNeechghar> APlanetNeechghars { get; set; }
        [InverseProperty("PlanetNavigation")]
        public virtual ICollection<APlanetShreshtghar> APlanetShreshtghars { get; set; }
        [InverseProperty("PlanetNavigation")]
        public virtual ICollection<APlanetUchghar> APlanetUchghars { get; set; }
    }
}
