
using AstroOfficeWeb.Shared.DTOs;
using AstroOfficeWeb.Shared.Helper;



namespace AstroOfficeWeb.Client.Pages.Product
{
    public partial class UserWishlist
    {

        private List<ViewProductDTO>? ViewProductDTOs { get; set; }
        protected override void OnInitialized()
        {
            base.OnInitialized();
        }

        protected override async Task OnInitializedAsync()
        {
            ViewProductDTOs = await ProductService.GetUserWishList();
        }

        private async Task OnCLick_ALickViewProdcut(ViewProductDTO productDTO)
        {
            await LocalStorage.SetItemAsync<ViewProductDTO>(ApplicationConst.Local_SelectedProduct, productDTO);
            NavigationManager.NavigateTo($"/product/{productDTO.Sno}/{productDTO.Name.Replace(" ", "-").ToLower()}");

        }
        private async Task OnCLick_ALickVRemoveWishlist(ViewProductDTO productDTO)
        {

            var result = await ProductService.IsDeletedFromWishList(productDTO.Sno);
            if (result)
            {
                ViewProductDTOs?.Remove(productDTO);
            }
        }
        private async Task OnCLick_BtnAddToCart(ViewProductDTO productDTO)
        {
            var tempQuantity = productDTO!.ProductQuantity + 1;
            if (tempQuantity < 1 || tempQuantity > 5)
            {
                await JSRuntime.ShowToastAsync($"Unable to add more products to your cart. Limit exceeded.", SwalIcon.Error);
                return;
            }
            var result = await ProductService.IsAddToCart(productDTO.Sno);
            if (result)
            {
                productDTO!.ProductQuantity += 1;
                await JSRuntime.ShowToastAsync($"{productDTO.Name} Added to your cart.", SwalIcon.Success);
            }
        }
    }
}
