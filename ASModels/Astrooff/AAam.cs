using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ASModels.Astrooff
{
    [Keyless]
    [Table("A_aam")]
    public partial class AAam
    {
        [Column("years")]
        public int? Years { get; set; }
        [Column("planet")]
        [StringLength(20)]
        public string? Planet { get; set; }
        [Column("antar")]
        [StringLength(50)]
        public string? Antar { get; set; }
    }
}
