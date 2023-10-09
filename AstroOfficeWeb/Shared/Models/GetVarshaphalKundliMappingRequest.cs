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
        public int age { get; set; }
        public KundliVO? persKV { get; set; }
        public List<KPPlanetMappingVO>? kp_chart { get; set; }

    }
}
