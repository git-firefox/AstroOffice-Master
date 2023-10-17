using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroOfficeWeb.Shared.Models
{
    public class BalanceListResponse
    {
        public int ErrorCode { get; set; }
        public string ErrorDescription { get; set; }
        public List<BalanceResponse> Data { get; set; }
    }
}
