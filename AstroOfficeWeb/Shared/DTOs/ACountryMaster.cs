using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AstroOfficeWeb.Shared.Models;

namespace AstroOfficeWeb.Shared.DTOs
{
    public class ACountryMaster
    {
        public long Sno { get; set; }
        public string CountryCode { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string? StartBoundaryOfLatitude { get; set; }
        public string? EndBoundaryOfLatitude { get; set; }
        public string? StartBoundaryOfLongitude { get; set; }
        public string? EndBoundaryOfLongitude { get; set; }
        public string? TimeCorrectionCode { get; set; }
        public string? ZoneStart { get; set; }
        public string? ZoneEnd { get; set; }
    }
}
