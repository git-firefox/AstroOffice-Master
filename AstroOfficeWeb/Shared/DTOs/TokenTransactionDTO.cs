using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroOfficeWeb.Shared.DTOs
{
    public class TokenTransactionDTO
    {
        public DateTime? TimestampCreated { get; set; }
        public decimal Amount { get; set; }
        public string? Description { get; set; }
        public string? StatusType { get; set; }
    }
}
