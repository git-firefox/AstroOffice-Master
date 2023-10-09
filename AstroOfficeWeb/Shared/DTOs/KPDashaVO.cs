using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroOfficeWeb.Shared.DTOs
{
    public class KPDashaVO
    {
        public long Days { get; set; }
        public string Duration { get; set; }
        public DateTime EndDate { get; set; }
        public string Nak_Signi_String { get; set; }
        public List<KPSigniVO> NakSigni { get; set; } = new List<KPSigniVO>();
        public short Planet { get; set; }
        public List<KPSigniVO> Signi { get; set; } = new List<KPSigniVO>();
        public string Signi_String { get; set; }
        public short SNo { get; set; }
        public DateTime StartDate { get; set; }
    }
}
