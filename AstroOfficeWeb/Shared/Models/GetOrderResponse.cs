using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AstroShared.DTOs;

namespace AstroOfficeWeb.Shared.Models
{
    public class GetOrderResponse : ApiResponseBase
    {
        public AddressDTO ShippingInformation { get; set; } = null!;
        public AddressDTO BillingInformation { get; set; } = null!;
        public OrderDTO Order { get; set; } = null!;
        public List<OrderItemDTO> OrderItems { get; set; } = null!;
    }
}
