
using AstroOfficeWeb.Shared.VOs;

namespace AstroOfficeWeb.Shared.Models
{
    public class ProcessKPChartGoodBadRequest
    {
        public List<KPPlanetMappingVO> KpChart { get; set; } = new();
        public KundliVO PersKV { get; set; } = new();
        public ProductSettingsVO Prod { get; set; } = new();
    }
}
