using AstroShared.DTOs;
using AstroShared.Helper;
using Microsoft.AspNetCore.Components.Web;

namespace AstroOfficeWeb.Client.Pages.Product
{
    public partial class ViewProducts
    {
        public List<ViewProductDTO>? Products { get; set; }

        public ViewProductDTO? SelectedProduct { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
        }
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            Products = await ProductService.GetProducts();
        }

        private async Task OnClick_BtnAddToCart(ViewProductDTO product)
        {
            bool isAddedToCart = await ProductService.IsAddToCart(product);
            if (isAddedToCart)
            {
                await JSRuntime.ShowToastAsync($"\"{product.Name}\" added to your cart.", SwalIcon.Success);
            }
        }
    }
}
