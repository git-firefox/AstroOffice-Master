using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ASModels.Astrooff
{
    [Table("A_Karyesh")]
    public partial class AKaryesh
    {
        [Key]
        [Column("sno")]
        public int Sno { get; set; }
        [Column("ktype")]
        [StringLength(255)]
        public string? Ktype { get; set; }
        [Column("main_house")]
        public int? MainHouse { get; set; }
        [Column("pos_house")]
        [StringLength(50)]
        [Unicode(false)]
        public string? PosHouse { get; set; }
        [Column("neg_house")]
        [StringLength(50)]
        [Unicode(false)]
        public string? NegHouse { get; set; }
    }
}
