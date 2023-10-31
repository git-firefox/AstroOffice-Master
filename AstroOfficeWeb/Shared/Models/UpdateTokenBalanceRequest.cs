using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroOfficeWeb.Shared.Models
{
    public class UpdateTokenBalanceRequest
    {
        public TransactionType TransactionType { get; set; }
        public decimal Amount { get; set; }
        public string? Description { get; set; }
        public DateTime PaymentDate { get; set; }
        public string? Action { get; set; }
    }

    public enum TransactionType
    {
        Deposit = 1,
        Withdrawal = 2,
        Transfer = 3,
        Purchase = 4,
        Refund = 5,
        Other = 6
    }

}
