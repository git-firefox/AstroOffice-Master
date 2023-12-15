
using AstroShared.DTOs;
using AstroShared.Helper;

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
            NavigationManager.NavigateTo($"/view-product/{productDTO.Sno}");

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
            var result = await ProductService.IsAddToCart(productDTO.Sno);
            if (result)
            {
                await JSRuntime.ShowToastAsync($"{productDTO.Name} Added to your cart.", SwalIcon.Success);
            }
        }
    }
}
