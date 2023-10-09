using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroOfficeWeb.Shared.DTOs
{
    public class KPNAKVO
    {
        public string Assamese { get; set; }
        public string Bangla { get; set; }
        public string English { get; set; }
        public string Gujarati { get; set; }
        public string Hindi { get; set; }
        public string Kannada { get; set; }
        public string Malayalam { get; set; }
        public string Marathi { get; set; }
        public short NakNumber { get; set; }
        public string Oriya { get; set; }
        public string Punjabi { get; set; }
        public short Swami { get; set; }
        public string Tamil { get; set; }
        public string Telugu { get; set; }
        public List<KPDashaRashiVO> DashaRashi { get; set; } = new List<KPDashaRashiVO>();

    }
}
