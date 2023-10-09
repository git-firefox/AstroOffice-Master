using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASModels = AstroShared.Models;

namespace AstroOfficeWeb.Shared.DTOs
{
    public class GetFalDoubleMahadashaRequest
    {
        public short PlanetNo { get; set; }
        public ASModels.KundliVO? PersonalKundli { get; set; }
        public string? OnlineResult { get; set; }
        public ASModels.ProductSettingsVO? TemporaryProduct { get; set; }
    }
}
