using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroShared.DTOs
{
    public class OrderDTO
    {
        public long OrderId { get; set; }

        public string BillingName { get; set; } = null!;
        public string ShippingAddress { get; set; } = null!;

        public DateTime? Date { get; set; }

        public PaymentStatus PaymentStatus { get; set; }

        public decimal? Total { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public List<OrderItemDTO> OrderItems { get; set; } = null!;
    }
}
