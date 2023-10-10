using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AstroShared.Models;

namespace AstroOfficeWeb.Shared.Models
{
    public class ProcessPlanetLaganRequest
    {
        public string OnlineResult { get; set; }
        public List<KPPlanetMappingVO>? KpChart { get; set; }
        public List<KPHouseMappingVO>? CuspHouse { get; set; }
        public short Rotate { get; set; }
        public bool BhavChalit { get; set; }
    }
}
