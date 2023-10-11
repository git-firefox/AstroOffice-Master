using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AstroShared.Models;

namespace AstroOfficeWeb.Shared.Models
{
    public class GetFalDoubleAntarHyphenWalaRequest
    {
        public string? AntarString { get; set; }
        public string? AgeString { get; set; }
        public short PlanetNo { get; set; }
        public short MahaPlanetNo { get; set; }
        public ProductSettingsVO? Prod { get; set; }
        public KundliVO? PersKV { get; set; }
    }
}
