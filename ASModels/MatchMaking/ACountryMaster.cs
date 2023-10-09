using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ASModels.MatchMaking
{
    [Keyless]
    [Table("a_country_master")]
    public partial class ACountryMaster
    {
        [Column("sno")]
        public long Sno { get; set; }
        [Column("country code")]
        [StringLength(50)]
        public string? CountryCode { get; set; }
        [Column("country")]
        [StringLength(50)]
        public string? Country { get; set; }
        [Column("start boundary of latitude")]
        [StringLength(50)]
        public string? StartBoundaryOfLatitude { get; set; }
        [Column("end boundary of latitude")]
        [StringLength(50)]
        public string? EndBoundaryOfLatitude { get; set; }
        [Column("start boundary of longitude")]
        [StringLength(50)]
        public string? StartBoundaryOfLongitude { get; set; }
        [Column("end boundary of longitude")]
        [StringLength(50)]
        public string? EndBoundaryOfLongitude { get; set; }
        [Column("time correction code")]
        [StringLength(50)]
        public string? TimeCorrectionCode { get; set; }
        [Column("Zone Start")]
        [StringLength(50)]
        public string? ZoneStart { get; set; }
        [Column("Zone End")]
        [StringLength(50)]
        public string? ZoneEnd { get; set; }
    }
}
