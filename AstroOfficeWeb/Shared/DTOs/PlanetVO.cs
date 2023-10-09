using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroOfficeWeb.Shared.DTOs
{
    public class PlanetVO
    {
        public int Sno { get; set; }
        public string? Planetname { get; set; }
        public string? PlanetnameHindi { get; set; }
        public string? PlanetnameEnglish { get; set; }
        public int Pakka_ghar { get; set; }
        public string? Color { get; set; }
        public string? Karya { get; set; }
        public string? Samay { get; set; }
        public string? Din { get; set; }
        public int Gender { get; set; }
    }
}
