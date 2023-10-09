using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroOfficeWeb.Shared.DTOs
{
    public class KPHouseMappingVO
    {
        public string DegreeHouse { get; set; }
        public double DegreeHouseDecimal { get; set; }
        public short House { get; set; }
        public bool IsManda { get; set; }
        public short LaganRashi { get; set; }
        public short NakLord { get; set; }
        public short Rashi { get; set; }
        public short RashiLord { get; set; }
        public List<KPSigniVO> Signi { get; set; }
        public short SubLord { get; set; }
        public short SubSubLord { get; set; }
    }
}
