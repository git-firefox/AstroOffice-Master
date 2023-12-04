using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroShared.DTOs
{
    public class CartItemDTO
    {
        public long ProductSno { get; set; }
        public string ProductName { get; set; } = null!;
        public decimal ProductPrice { get; set; }
        public string? ProductImageSrc { get; set; }
        public int ProductQuantity { get; set; }
    }

    public class OrderItemDTO : CartItemDTO
    {

    }
}
