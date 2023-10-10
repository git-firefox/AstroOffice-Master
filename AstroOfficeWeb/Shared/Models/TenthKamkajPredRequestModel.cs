using AstroShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroOfficeWeb.Shared.Models
{
    public class TenthKamkajPredRequestModel
    {
        public List<KPHouseMappingVO>? CuspHouse { get; set; }
        public List<KPPlanetMappingVO>? KPChart { get; set; }
        public KundliVO? PersonalKundli { get; set; }
    }
}
