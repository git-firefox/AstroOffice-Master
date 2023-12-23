﻿using AstroShared.DTOs;
using AstroShared.Helper;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroOfficeSharedComponents
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