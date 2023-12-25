using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AstroOfficeWeb.Shared.VOs;

namespace AstroOfficeWeb.Shared.Models
{
    public class GetPlanetNakPlanetSublordFalRequest
    {
        public KundliVO? PersKV { get; set; }
        public short House { get; set; }
        public string? Houses { get; set; }
    }
}
