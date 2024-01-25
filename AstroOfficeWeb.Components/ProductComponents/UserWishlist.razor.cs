using AstroOfficeWeb.Shared.DTOs;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroOfficeWeb.Components.ProductComponents
{
    public partial class UserWishlist
    {
        [Parameter]
        public bool IsDataUrl { get; set; } = false;

        [Parameter]
        public string Breakpoint { get; set; } = "row-cols-1 row-cols-sm-3 row-cols-md-3 row-cols-xl-5";

        private List<ViewProductDTO>? ViewProductDTOs { get; set; }
        protected override void OnInitialized()
        {
            base.OnInitialized();
        }

        protected override async Task OnInitializedAsync()
        {
            ViewProductDTOs = await ProductService.GetUserWishList(IsDataUrl);
        }

        private async Task OnCLick_ALickViewProdcut(ViewProductDTO productDTO)
        {
            //await LocalStorage.SetItemAsync<ViewProductDTO>(ApplicationConst.Local_SelectedProduct, productDTO);
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
            Snackbar.Configuration.PositionClass = Defaults.Classes.Position.BottomCenter;
            if (tempQuantity < 1 || tempQuantity > 5)
            {
                Snackbar.Add($"Unable to add more products to your cart. Limit exceeded.", Severity.Error);
                return;
            }
            var result = await ProductService.IsAddToCart(productDTO.Sno);
            if (result)
            {
                productDTO!.ProductQuantity += 1;
                Snackbar.Add($"{productDTO.Name} Added to your cart.", Severity.Success);
            }
        }
     

    }
}
