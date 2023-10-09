using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AstroOfficeWeb.Shared.Models
{
    public class BirthCity
    {
        public long Sno { get; set; }
        public string? Place { get; set; }
        public string? CountryCode { get; set; }
        public string? Latitude { get; set; }
        public string? StateOrCountryCode { get; set; }
        public string? Longitude { get; set; }
        public string? TimeCorrectionCode { get; set; }

    }
}
