using AstroOfficeWeb.Components.MyComponents;
using AstroOfficeWeb.Shared.ComponentModels;
using AstroOfficeWeb.Shared.DTOs;
using AstroOfficeWeb.Shared.Utilities;
using AstroOfficeWeb.Shared.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AstroOfficeWeb.Components.ProductComponents
{
    enum SaveProductTab
    {
        [Description("General Information")]
        General,
        [Description("Product Images")]
        ProductImages,
        [Description("Metadata")]
        Metadata
    }

    public partial class SaveProduct
    {
        [Parameter]
        public long Sno { get; set; } = 0;

        [Parameter]
        public ActionMode Mode { get; set; }

        [Parameter]
        public string? Name { get; set; }

        [Parameter]
        public EventCallback<bool> IsLoaded { get; set; }


        private BSNavItem BSNavGeneralInfo { get; set; } = null!;
        private BSNavItem BSNavProductImages { get; set; } = null!;
        private BSNavItem BSNavMetaData { get; set; } = null!;

        private BaseProductDTO? GeneralInfo { get; set; }
        private List<MediaFileDTO>? MediaFiles { get; set; }
        private List<MetaDataDTO>? MetaDatas { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();

            //GeneralInformationContext = new EditContext(GeneralInfo);
            //SaveProductImageInfoContext = new EditContext(ProductMedia);
            //SaveProductMetadataInfoContext = new EditContext(ProductMeta);

        }

        protected override async Task OnInitializedAsync()
        {
            await ProductService.GetCategories();
            if (Sno != 0)
            {
                var productInfo = await ProductService.InitialiseProductBySno(Sno);
                GeneralInfo = productInfo.GeneralInformation;
                MediaFiles = productInfo.ProductMediaFiles;
                MetaDatas = productInfo.ProductMetaDatas;
            }
        }

        protected override Task OnAfterRenderAsync(bool firstRender)
        {
            return base.OnAfterRenderAsync(firstRender);
        }

        private async Task OnClick_BtnProceed(SaveProductTab mode)
        {
            if (mode == SaveProductTab.ProductImages)
            {
                await JSRuntime.ShowTabAsync(BSNavProductImages.Reference);
            }
            else if (mode == SaveProductTab.Metadata)
            {
                await JSRuntime.ShowTabAsync(BSNavMetaData.Reference);
            }
            else
            {
                await JSRuntime.ShowTabAsync(BSNavGeneralInfo.Reference);
            }
        }

        private async Task OnClick_BtnPublish()
        {
            await OnClick_BtnProceed(SaveProductTab.General);


            //if (!SaveProductImageInfoContext.Validate() && (ProductModel?.ProductImages?.Count == 0))
            //{
            //    await JSRuntime.ShowTabAsync(ER_AProductImage);
            //    return;
            //}

            //if (!SaveProductMetadataInfoContext.Validate() && (ProductModel?.MetaDatas?.Count == 0))
            //{
            //    await JSRuntime.ShowTabAsync(ER_AMetaData);
            //    return;
            //}


            //GeneralInfo.ProductImages = BrowserFiles;
            //GeneralInfo.MetaDatas = MetaDataList;
            ////if (FileData.Any())
            //{
            //await ProductService.SaveProductImages(GeneralInfo, FileData);

            //}
            //if (Sno == 0)
            //{
            //    await ProductService.AddProduct(ProductModel);
            //}
            //else
            //{
            //    await ProductService.UpdateProduct(ProductModel, Sno);
            //}
        }
    }
}