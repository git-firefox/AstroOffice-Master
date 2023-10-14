using AstroShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroOfficeWeb.Shared.Models
{
    public class GetVarshaphalKundliMappingRequest
    {
        public int Age { get; set; }
        public KundliVO? PersKV { get; set; }
        public List<KPPlanetMappingVO>? KP_Chart { get; set; }

    }
}
