using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AstroOffice.Models.Astrooff
{
    [Table("a_country")]
    public partial class ACountry
    {
        [Key]
        [Column("sno")]
        public long Sno { get; set; }
        [Column("country")]
        [StringLength(250)]
        [Unicode(false)]
        public string? Country { get; set; }
    }
}
