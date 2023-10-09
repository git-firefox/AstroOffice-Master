using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AstroOffice.Models.Astrooff
{
    [Keyless]
    [Table("a_state_master")]
    [Index("StateCode", Name = "IX_a_state_master_1")]
    [Index("CountryCode", Name = "IX_a_state_master_2")]
    public partial class AStateMaster
    {
        [Column("sno")]
        public long Sno { get; set; }
        [Column("country code")]
        [StringLength(50)]
        public string? CountryCode { get; set; }
        [Column("state code")]
        [StringLength(50)]
        public string? StateCode { get; set; }
        [Column("state name")]
        [StringLength(50)]
        public string? StateName { get; set; }
        [Column("boundary start of latitude")]
        [StringLength(50)]
        public string? BoundaryStartOfLatitude { get; set; }
        [Column("boundary end of latitude")]
        [StringLength(50)]
        public string? BoundaryEndOfLatitude { get; set; }
        [Column("boundary start of longitude")]
        [StringLength(50)]
        public string? BoundaryStartOfLongitude { get; set; }
        [Column("boundary end of longitude")]
        [StringLength(50)]
        public string? BoundaryEndOfLongitude { get; set; }
        [Column("time correction code")]
        [StringLength(50)]
        public string? TimeCorrectionCode { get; set; }
        [StringLength(50)]
        public string? Zone { get; set; }
    }
}
