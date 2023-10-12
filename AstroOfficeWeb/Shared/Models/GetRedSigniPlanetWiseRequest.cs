using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AstroShared.Models;

namespace AstroOfficeWeb.Shared.Models
{
    public class GetRedSigniPlanetWiseRequest
    {
        public List<KPPlanetMappingVO>? KPChart { get; set; }
        public List<KPHouseMappingVO>? CuspHouse { get; set; }
        public ProductSettingsVO? ProductSettings { get; set; }
        public KundliVO? PersonalKundli { get; set; }
        public short Planet { get; set; }
    }
}
