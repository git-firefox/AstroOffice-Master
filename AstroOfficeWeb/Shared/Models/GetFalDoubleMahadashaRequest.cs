using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AstroOfficeWeb.Shared.VOs;

namespace AstroOfficeWeb.Shared.Models
{
    public class GetFalDoubleMahadashaRequest
    {
        public short PlanetNo { get; set; }
        public KundliVO? PersonalKundli { get; set; }
        public string? OnlineResult { get; set; }
        public ProductSettingsVO? TemporaryProduct { get; set; }
    }
}
