using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AstroOffice.Models.Astrooff
{
    [Table("a_additionalrules")]
    public partial class AAdditionalrule
    {
        [Key]
        [Column("sno")]
        public long Sno { get; set; }
        [Column("ruleno")]
        public long? Ruleno { get; set; }
        [Column("lagan")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Lagan { get; set; }
        [Column("rashi")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Rashi { get; set; }
    }
}
