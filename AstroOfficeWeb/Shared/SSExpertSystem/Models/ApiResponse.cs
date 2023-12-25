using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace AstroOfficeWeb.Shared.SSExpertSystem.Models
{
    public class ApiSSExpertSystemResponse
    {
        public int ErrorCode { get; set; }
        public string? ErrorDescription { get; set; }
        public JArray? Data { get; set; }
    }
}
