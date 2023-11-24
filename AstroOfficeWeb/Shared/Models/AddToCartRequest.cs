using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroOfficeWeb.Shared.Models
{
    public class AddToCartRequest
    {
        public  int Quantity { get; set; }
        public  long ProductSno { get; set; }
    }
}
