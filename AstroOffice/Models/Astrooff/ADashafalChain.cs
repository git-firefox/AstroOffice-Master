using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AstroOffice.Models.Astrooff
{
    [Keyless]
    [Table("A_dashafal_chain")]
    public partial class ADashafalChain
    {
        [Column("sno")]
        public int Sno { get; set; }
        [Column("signi")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Signi { get; set; }
        [Column("pred_hindi")]
        public string? PredHindi { get; set; }
        [Column("ptype")]
        [StringLength(10)]
        [Unicode(false)]
        public string? Ptype { get; set; }
    }
}
