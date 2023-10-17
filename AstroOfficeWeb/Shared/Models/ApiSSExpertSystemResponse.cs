using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroOfficeWeb.Shared.Models
{
    public class ApiSSExpertSystemResponse<TResponse> where TResponse : class
    {
        public int ErrorCode { get; set; }
        public object ErrorDescription { get; set; }
        public TResponse Data { get; set; }
    }
}
