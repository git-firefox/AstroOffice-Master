using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AstroShared.Models;

namespace AstroOfficeWeb.Shared.Models
{
    public class GenImageRequest
    {
        public string Lagna { get; set; }
        public List<KPPlanetMappingVO>? Lkmv { get; set; }
        public string Online_Result { get; set; }
        public bool Bhav_Chalit { get; set; }
        public short Kund_Size { get; set; }
        public string Lang { get; set; }

    }
}
