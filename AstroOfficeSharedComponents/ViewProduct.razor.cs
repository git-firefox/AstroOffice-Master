using AstroShared.DTOs;
using AstroShared.Helper;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MudBlazor;

namespace AstroOfficeSharedComponents
{
    public partial class ViewProduct
    {

        [Parameter]
        public long ProductSno { get; set; }

        [Parameter]
        public string? ProductName { get; set; }

        public ImagesDTO? SelectedImage { get; set; } = new ImagesDTO();

        public List<ImagesDTO> BrowserFiles { get; set; } = new();
        public CultureInfo CultureInfo { get; set; } = new CultureInfo("en-IN");

        public ProductDTO? ViewProductDTO { get; set; } = new ViewProductDTO();

        private List<MetaDataDTO> MetaDataList { get; set; } = new List<MetaDataDTO>();

        protected override void OnInitialized()
        {
            base.OnInitialized();
        }

        protected override async Task OnInitializedAsync()
        {
            ViewProductDTO = await ProductService.GetProductBySno(ProductSno) ?? new();
            BrowserFiles = ViewProductDTO.ProductImages ??= new();
            MetaDataList = ViewProductDTO.MetaDatas ??= new();
            SelectedImage = new ImagesDTO { ImageName = ViewProductDTO?.Name ?? "", ImageURL = ViewProductDTO?.ImageUrl ?? "" };
        }

        private async Task OnClick_BtnAddToWishlist(MouseEventArgs e)
        {
            await ProductService.AddToWishList(ProductSno);
        }

        private async Task OnClick_BtnAddToCart(MouseEventArgs e)
        {
            var tempQuantity = ViewProductDTO!.ProductQuantity + 1;
            Snackbar.Configuration.PositionClass = Defaults.Classes.Position.BottomCenter;
            if (tempQuantity < 1 || tempQuantity > 5)
            {
                Snackbar.Add("Unable to add more products to your cart. Limit exceeded.", Severity.Error);

                return;
            }

            bool isAddedToCart = await ProductService.IsAddToCart(ProductSno);

            if (isAddedToCart)
            {
                ViewProductDTO!.ProductQuantity += 1;
                Snackbar.Add($"\"{ViewProductDTO!.Name}\" added to your cart.", Severity.Success);
               
            }
        }
    }
}
