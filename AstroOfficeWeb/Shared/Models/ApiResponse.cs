using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AstroOfficeWeb.Shared.Models
{
    //[JsonArray]
    public class ApiResponse<TResponse> : ApiResponseBase
    {
        public TResponse? Data { get; set; }
    }
}
