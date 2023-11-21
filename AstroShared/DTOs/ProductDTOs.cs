using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroShared.DTOs
{
    public abstract class ProductDTOBase
    {
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public int StockQuantity { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
    }
    public class ViewProductDTO : ProductDTOBase
    {
        public long Sno { get; set; }
    }

    public class SaveProductDTO : ProductDTOBase
    {

    }
}
