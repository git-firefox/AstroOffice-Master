using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ASModels.Astrooff
{
    [Keyless]
    [Table("A_hindi_mobile")]
    public partial class AHindiMobile
    {
        [Column("sno")]
        public long Sno { get; set; }
        [Column("ruleno")]
        public double? Ruleno { get; set; }
        [Column("common_pred")]
        [StringLength(4000)]
        public string? CommonPred { get; set; }
        [Column("male_pred")]
        [StringLength(4000)]
        public string? MalePred { get; set; }
        [Column("female_pred")]
        [StringLength(4000)]
        public string? FemalePred { get; set; }
        [Column("child_pred")]
        [StringLength(4000)]
        public string? ChildPred { get; set; }
    }
}
