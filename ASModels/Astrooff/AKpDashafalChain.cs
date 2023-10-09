using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ASModels.Astrooff
{
    [Keyless]
    [Table("A_kp_dashafal_chain")]
    public partial class AKpDashafalChain
    {
        [Column("sno")]
        public long? Sno { get; set; }
        [Column("signi")]
        [StringLength(20)]
        [Unicode(false)]
        public string? Signi { get; set; }
        [Column("pred_hindi")]
        public string? PredHindi { get; set; }
        [Column("ptype")]
        [StringLength(10)]
        [Unicode(false)]
        public string? Ptype { get; set; }
        [Column("isbad")]
        public bool? Isbad { get; set; }
        [Column("common")]
        public bool? Common { get; set; }
        [Column("male")]
        public bool? Male { get; set; }
        [Column("female")]
        public bool? Female { get; set; }
        [Column("shishu")]
        public bool? Shishu { get; set; }
        [Column("bachpan")]
        public bool? Bachpan { get; set; }
        [Column("kishor")]
        public bool? Kishor { get; set; }
        [Column("yuva")]
        public bool? Yuva { get; set; }
        [Column("madhya")]
        public bool? Madhya { get; set; }
        [Column("budhapa")]
        public bool? Budhapa { get; set; }
        [Column("pred_english", TypeName = "text")]
        public string? PredEnglish { get; set; }
    }
}
