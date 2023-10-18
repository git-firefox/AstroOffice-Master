using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroOfficeWeb.Shared
{
    public class UpdateUserPasswordByOtpRequest
    {
        public string? MobileNumber { get; set; } 
        public string? Otp { get; set; } 
        public string? NewPassword { get; set; } 
    }
}
