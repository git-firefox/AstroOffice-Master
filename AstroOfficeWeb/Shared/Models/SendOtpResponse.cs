using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroOfficeWeb.Shared.Models
{
    public class SendOtpResponse
    {
        public int MessageErrorCode { get; set; }
        public string MessageErrorDescription { get; set; }
        public string MobileNumber { get; set; }
        public string MessageId { get; set; }
        public object Custom { get; set; }
    }
}
