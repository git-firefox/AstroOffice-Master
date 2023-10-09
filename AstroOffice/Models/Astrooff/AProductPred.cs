using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AstroOffice.Models.Astrooff
{
    [Table("a_productPred")]
    public partial class AProductPred
    {
        [Key]
        [Column("sno")]
        public long Sno { get; set; }
        [Column("ruleno", TypeName = "numeric(18, 0)")]
        public decimal? Ruleno { get; set; }
        [Column("producttype")]
        [StringLength(200)]
        [Unicode(false)]
        public string? Producttype { get; set; }
    }
}
