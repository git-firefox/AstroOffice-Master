using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroShared.Services.SSExpertSystem.Models
{
    public class SendOtpResponse
    {
        public string? MobileNumber { get; set; }
        public string? MessageId { get; set; }
    }
}
