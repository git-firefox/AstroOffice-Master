
using AstroShared.DTOs;

namespace AstroOfficeWeb.Client.Pages.Product
{
    public partial class ProductCart
    {
        public List<CartItemDTO>? CartItems { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
        }

        protected override async Task OnInitializedAsync()
        {
            CartItems = await ProductService.GetCartItems();
        }
    }
}
