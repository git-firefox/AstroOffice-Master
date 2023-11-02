using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroShared.DTOs
{
    public class TokenTransactionDTO
    {
        public DateTime? TimestampCreated { get; set; }
        public decimal Amount { get; set; }
        public string? Description { get; set; }
        public string? StatusType { get; set; }
        public string? Action { get; set; }
    }
}
