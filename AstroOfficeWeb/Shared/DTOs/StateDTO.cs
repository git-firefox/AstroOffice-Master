using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroOfficeWeb.Shared.DTOs
{
    public class StateDTO
    {
        public long Sno { get; set; }
        public string? CountryCode { get; set; }
        public string? StateCode { get; set; }
        public string? StateName { get; set; }
        public string? BoundaryStartOfLatitude { get; set; }
        public string? BoundaryEndOfLatitude { get; set; }
        public string? BoundaryStartOfLongitude { get; set; }
        public string? BoundaryEndOfLongitude { get; set; }
        public string? TimeCorrectionCode { get; set; }
        public string? Zone { get; set; }
    }
}
