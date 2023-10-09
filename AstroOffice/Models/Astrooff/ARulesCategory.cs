using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AstroOffice.Models.Astrooff
{
    [Table("a_rules_category")]
    public partial class ARulesCategory
    {
        [Key]
        [Column("sno")]
        public int Sno { get; set; }
        [Column("category")]
        [StringLength(150)]
        [Unicode(false)]
        public string? Category { get; set; }
    }
}
