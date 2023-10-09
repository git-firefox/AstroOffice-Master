using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ASModels.Astrooff
{
    [Keyless]
    [Table("A_kp_planet_pred")]
    public partial class AKpPlanetPred
    {
        [Column("sno")]
        public long Sno { get; set; }
        [Column("planet")]
        public int? Planet { get; set; }
        [Column("house")]
        public int? House { get; set; }
        [Column("pred_hindi", TypeName = "text")]
        public string? PredHindi { get; set; }
    }
}
