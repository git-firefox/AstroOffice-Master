using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AstroOfficeWeb.Shared.VOs;

namespace AstroOfficeWeb.Shared.Models
{
    public class GenImageRequest
    {
        public string Lagna { get; set; } = string.Empty;
        public List<KPPlanetMappingVO>? Lkmv { get; set; }
        public string Online_Result { get; set; } = string.Empty;
        public bool Bhav_Chalit { get; set; }
        public short Kund_Size { get; set; }
        public string Lang { get; set; } = string.Empty;

    }
}
