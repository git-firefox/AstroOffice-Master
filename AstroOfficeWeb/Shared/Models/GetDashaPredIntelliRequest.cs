using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AstroShared.Models;

namespace AstroOfficeWeb.Shared.Models
{
    public class GetDashaPredIntelliRequest
    {
        public short Planet { get; set; }
        public string? Houses { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public KundliVO? PersKV { get; set; }
        public string? PType { get; set; }
        public ProductSettingsVO? Prod { get; set; }
        public List<KPPlanetMappingVO>? KPChart { get; set; }
        public short ActualPlanet { get; set; }
        public short ActualPlanetHouse { get; set; }
        public short NakSwamiHouse { get; set; }
    }
}
