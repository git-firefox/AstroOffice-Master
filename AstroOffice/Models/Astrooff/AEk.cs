using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AstroOffice.Models.Astrooff
{
    [Table("a_ek")]
    public partial class AEk
    {
        [Key]
        [Column("sno")]
        public long Sno { get; set; }
        [Column("ek")]
        [StringLength(500)]
        [Unicode(false)]
        public string? Ek { get; set; }
        [Column("date1", TypeName = "datetime")]
        public DateTime? Date1 { get; set; }
        [Column("date2", TypeName = "datetime")]
        public DateTime? Date2 { get; set; }
    }
}
