using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroOfficeWeb.Shared.DTOs
{
    public class KPPlanetMappingVO
    {

        public short Bhav_Chalit_House { get; set; }
        public short Bhav_Chalit_House_New { get; set; }
        public short Bhav_Chalit_Rashi { get; set; }
        public string DegreePlanet { get; set; }
        public double DegreePlanet_Decimal { get; set; }
        public short House { get; set; }
        public bool isbad { get; set; }
        public bool isJadKharab { get; set; }
        public bool isManda { get; set; }
        public bool IsPakka { get; set; }
        public bool IsVeryBad { get; set; }
        public short Nak_Lord { get; set; }
        public short Planet { get; set; }
        public short Rashi { get; set; }
        public short Rashi_Lord { get; set; }
        public List<KPSigniVO> Signi { get; set; }
        public short Sub_Lord { get; set; }
        public short Sub_Sub_Lord { get; set; }
    }
}
