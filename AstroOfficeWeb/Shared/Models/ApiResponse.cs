using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AstroOfficeWeb.Shared.Models
{
    //[JsonArray]
    public class ApiResponse<TType> : ApiResponseBase
    {
        public TType? Data { get; set; }
    }
}
