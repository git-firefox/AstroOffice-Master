using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroOfficeWeb.Shared.SSExpertSystem.Models
{
    public class MessageStatusResponse
    {
        public string? MobileNumber { get; set; }
        public string? SenderId { get; set; }
        public string? Message { get; set; }
        public string? SubmitDate { get; set; }
        public string? DoneDate { get; set; }
        public string? MessageId { get; set; }
        public string? Status { get; set; }
        public string? ErrorCode { get; set; }
    }
}
