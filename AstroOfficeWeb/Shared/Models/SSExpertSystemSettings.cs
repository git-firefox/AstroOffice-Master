using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroOfficeWeb.Shared.Models
{
    public class SSExpertSystemSettings
    {
        public static string SSExpertSystemSection = "SSExpertSystemConfiguration";
        public string APIKey { get; set; } = string.Empty;
        public string ClientId { get; set; } = string.Empty;
    }
}
