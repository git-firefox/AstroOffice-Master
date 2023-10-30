using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroOfficeWeb.Shared.Models
{
    public class JWTSettings
    {
        public string SecretKey { get; set; } = string.Empty;
        public string ValidAudience { get; set; } = string.Empty;
        public string ValidIssuer { get; set; } = string.Empty;
    }
}
