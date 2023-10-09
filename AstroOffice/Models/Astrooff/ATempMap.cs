using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AstroOffice.Models.Astrooff
{
    [Table("a_temp_map")]
    public partial class ATempMap
    {
        [Key]
        [Column("sno")]
        public long Sno { get; set; }
        [Column("map_name")]
        [StringLength(150)]
        [Unicode(false)]
        public string? MapName { get; set; }
    }
}
