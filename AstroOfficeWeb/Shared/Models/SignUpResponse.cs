using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroOfficeWeb.Shared.Models
{
    public class SignUpResponse : ApiResponse<int>
    {
        public bool IsRegisterationSuccessful { get; set; }
    }
}
