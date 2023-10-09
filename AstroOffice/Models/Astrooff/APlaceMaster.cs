using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AstroOffice.Models.Astrooff
{
    [Keyless]
    [Table("a_place_master")]
    public partial class APlaceMaster
    {
        [Column("sno")]
        public long Sno { get; set; }
        [Column("Place-Hindi")]
        [StringLength(50)]
        public string? PlaceHindi { get; set; }
        [Column("place")]
        [StringLength(50)]
        public string? Place { get; set; }
        [Column("district")]
        [StringLength(50)]
        public string? District { get; set; }
        [Column("latitude")]
        [StringLength(50)]
        public string? Latitude { get; set; }
        [Column("longitude")]
        [StringLength(50)]
        public string? Longitude { get; set; }
        [Column("country code")]
        [StringLength(50)]
        public string? CountryCode { get; set; }
        [Column("state or country code")]
        [StringLength(50)]
        public string? StateOrCountryCode { get; set; }
        [Column("time correction code")]
        [StringLength(50)]
        public string? TimeCorrectionCode { get; set; }
    }
}
