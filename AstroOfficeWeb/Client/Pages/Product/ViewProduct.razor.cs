using System.Globalization;
using AstroShared.DTOs;
using AstroShared.Helper;
using Microsoft.AspNetCore.Components;

namespace AstroOfficeWeb.Client.Pages.Product
{
    public partial class ViewProduct
    {

        [Parameter]
        public long Sno { get; set; }

        public ImgData? SelectedImage { get; set; } = new ImgData();

        public List<ImgData> BrowserFiles { get; set; } = new();
        public CultureInfo CultureInfo { get; set; } = new CultureInfo("en-IN");

        public ViewProductDTO? ViewProductDTO { get; set; } = new ViewProductDTO();

        //protected override void OnInitialized()
        //{
        //    ViewProductDTO = StateContainerService.GetSelectedProduct();
        //    SelectedImage = new ImgData { Alt = ViewProductDTO?.Name ?? "", Src = ViewProductDTO?.ImageUrl ?? "" };
        //}

        protected override async Task OnInitializedAsync()
        {
            ViewProductDTO = await LocalStorage.GetItemAsync<ViewProductDTO>(ApplicationConst.Local_SelectedProduct);
            SelectedImage = new ImgData { Alt = ViewProductDTO?.Name ?? "", Src = ViewProductDTO?.ImageUrl ?? "" };
        }
    }
}
