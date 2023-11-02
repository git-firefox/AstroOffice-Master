using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroShared.DTOs
{
    public class PaymentInfoDto
    {
        public string? CcavenueResponse { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? PaymentDate { get; set; }
        public DateTime? TimestampCreated { get; set; }
        public string? StatusName { get; set; }
    }
}
