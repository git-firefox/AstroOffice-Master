using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AstroOffice.Models.Astrooff
{
    [Keyless]
    [Table("a_city")]
    public partial class ACity
    {
        [Column("code")]
        public int Code { get; set; }
        [Column("ccode")]
        public int? Ccode { get; set; }
        [Column("city")]
        [StringLength(200)]
        [Unicode(false)]
        public string? City { get; set; }
        [Column("longitude")]
        public double? Longitude { get; set; }
        [Column("latitude")]
        public double? Latitude { get; set; }
    }
}
