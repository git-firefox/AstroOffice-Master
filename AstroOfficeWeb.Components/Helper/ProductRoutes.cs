using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AstroOfficeWeb.Shared.Helper;
using AstroOfficeWeb.Shared.Utilities;

namespace AstroOfficeWeb.Components.Helper
{
    public class ProductRoutes
    {
        public static string ProductsByCategory(long categorySno, string categoryTitle) => $"/products/{categorySno}/{categoryTitle.ToUrlFriendlyString()}";
        public static string ViewProduct(long productSno, string productName) => $"/product/{productSno}/{productName.ToUrlFriendlyString()}";
        public static string SaveProduct(long productSno = 0, string? productName = null, ActionMode mode = ActionMode.Add)
        {
            var sb = new StringBuilder("/manage-products/");

            sb.Append($"{mode.ToString().ToLower()}/product");

            if (productSno != 0)
            {
                sb.Append($"/{productSno}");
            }

            if (!string.IsNullOrEmpty(productName))
            {
                sb.Append($"/{productName.ToUrlFriendlyString()}");
            }

            return sb.ToString();
        }
    }
}
