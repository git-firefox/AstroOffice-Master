using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AstroOffice.Models.Astrooff
{
    [Keyless]
    [Table("A_35years")]
    public partial class A35year
    {
        [Column("sno")]
        public int? Sno { get; set; }
        [Column("planet")]
        [StringLength(50)]
        public string? Planet { get; set; }
        [Column("years")]
        public int? Years { get; set; }
        [Column("mid1")]
        [StringLength(20)]
        public string? Mid1 { get; set; }
        [Column("mid2")]
        [StringLength(20)]
        public string? Mid2 { get; set; }
        [Column("mid3")]
        [StringLength(20)]
        public string? Mid3 { get; set; }
    }
}
