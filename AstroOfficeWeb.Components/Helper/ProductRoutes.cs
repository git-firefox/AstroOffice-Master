using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AstroOfficeWeb.Shared.Helper;

namespace AstroOfficeWeb.Components.Helper
{
    public class ProductRoutes
    {
        public static string ProductsByCategory(long categorySno, string categoryTitle) => $"/products/{categorySno}/{categoryTitle.ToUrlFriendlyString()}";
        public static string ViewProduct(long productSno, string productName) => $"/product/{productSno}/{productName.ToUrlFriendlyString()}";
    }
}
