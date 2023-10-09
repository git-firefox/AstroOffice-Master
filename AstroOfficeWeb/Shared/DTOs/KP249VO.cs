using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroOfficeWeb.Shared.DTOs
{
    public class KP249VO
    {
        public short Sno { get; set; }
        public short Rashi { get; set; }
        public string From_Degree { get; set; }
        public string To_Degree { get; set; }
        public double From_Degree_Decimal { get; set; }
        public double To_Degree_Decimal { get; set; }
        public short Rashi_Lord { get; set; }
        public short Nak_Lord { get; set; }
        public short Sub_Lord { get; set; }
        public List<KP249SubSubLordVO> Sub_Sub_Lord { get; set; } = new List<KP249SubSubLordVO>();
    }
}
