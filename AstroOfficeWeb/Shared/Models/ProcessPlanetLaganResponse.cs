using AstroShared.Models;

namespace AstroOfficeWeb.Shared.Models
{
    public class ProcessPlanetLaganResponse
    {
        public List<KPPlanetMappingVO> KpChart { get; set; }
        public List<KPHouseMappingVO> CuspHouse { get; set; }
    }
}
