using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroShared.Services.SSExpertSystem.Models
{
    public class BaseBalanceResponse
    {
        public string? CurrencySymbol { get; set; }
        public int ProductType { get; set; }
        public string? ProductTypeName { get; set; }
        public double Credits { get; set; }
        public string? TotalCredits { get; set; }
    }
    public class BalanceResponse
    {
        public string? PluginType { get; set; }
        public string? Credits { get; set; }
    }
}
