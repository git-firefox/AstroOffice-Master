using System.Globalization;
using AstroShared.DTOs;
using AstroShared.Helper;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace AstroOfficeWeb.Client.Pages.Product
{
    public partial class ViewProduct
    {

        [Parameter]
        public long Sno { get; set; }

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
            ViewProductDTO = await ProductService.GetProductBySno(Sno) ?? new();
            BrowserFiles = ViewProductDTO.ProductImages ??= new();
            MetaDataList = ViewProductDTO.MetaDatas ??= new();
            SelectedImage = new ImagesDTO { ImageName = ViewProductDTO?.Name ?? "", ImageURL = ViewProductDTO?.ImageUrl ?? "" };
        }

        private async Task OnClick_BtnAddToWishlist(MouseEventArgs e)
        {
            await ProductService.AddToWishList(Sno);
        }

        private async Task OnClick_BtnAddToCart(MouseEventArgs e)
        {
            bool isAddedToCart = await ProductService.IsAddToCart(Sno);
            if (isAddedToCart)
            {
                await JSRuntime.ShowToastAsync($"\"{ViewProductDTO!.Name}\" added to your cart.", SwalIcon.Success);
            }
        }
    }
}
