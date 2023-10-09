using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ASModels.Astrooff
{
    [Keyless]
    [Table("A_kp_karyesh_pred")]
    public partial class AKpKaryeshPred
    {
        [Column("sno")]
        public long Sno { get; set; }
        [Column("house")]
        public int? House { get; set; }
        [Column("karyesh")]
        [StringLength(10)]
        [Unicode(false)]
        public string? Karyesh { get; set; }
        [Column("pred_hindi", TypeName = "text")]
        public string? PredHindi { get; set; }
    }
}
