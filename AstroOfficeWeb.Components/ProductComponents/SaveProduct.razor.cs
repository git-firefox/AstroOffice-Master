using AstroOfficeWeb.Components.MyComponents;
using AstroOfficeWeb.Shared.DTOs;
using AstroOfficeWeb.Shared.Utilities;
using Microsoft.AspNetCore.Components;
using System.ComponentModel;

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

    public partial class SaveProduct : ComponentBase
    {
        [Parameter]
        public long Sno { get; set; } = 0;

        [Parameter]
        public ActionMode Mode { get; set; }

        [Parameter]
        public string? Name { get; set; }

        [Parameter]
        public EventCallback<bool> Loaded { get; set; }

        private bool IsCompleted { get; set; } = false;
        private BSNavItem BSNavGeneralInfo { get; set; } = null!;
        private BSNavItem BSNavProductImages { get; set; } = null!;
        private BSNavItem BSNavMetaData { get; set; } = null!;
        private ProductGeneralInfo GeneralInfoRef { get; set; } = null!;

        private BaseProductDTO? GeneralInfo { get; set; }
        private List<MediaFileDTO>? MediaFiles { get; set; }
        private List<MetaDataDTO>? MetaDatas { get; set; }
        private IEnumerable<Option> CategoryOptions { get; set; } = Enumerable.Empty<Option>();

        protected override void OnInitialized()
        {
            base.OnInitialized();
        }

        protected override async Task OnInitializedAsync()
        {
            IsCompleted = false;
            CategoryOptions = await LookupService.GetCategoryOptions();
            if (Sno != 0)
            {
                var productInfo = await ProductService.InitialiseProductBySno(Sno);
                GeneralInfo = productInfo.GeneralInformation;
                MediaFiles = productInfo.ProductMediaFiles;
                MetaDatas = productInfo.ProductMetaDatas;
            }
            IsCompleted = true;
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

            //if (!GeneralInfoRef.GeneralInformationContext.Validate())
            //{
            //    await OnClick_BtnProceed(SaveProductTab.General);
            //    return;
            //}

            if (!MediaFiles!.Any())
            {
                Snackbar.ShowErrorSnackbar("Upload atleast 1 image.");
                await OnClick_BtnProceed(SaveProductTab.ProductImages);
                return;
            }

            //if (!MediaFiles!.Any())
            //{
            //    Snackbar.ShowErrorSnackbar("");
            //    return;
            //}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    
            await ProductService.SaveProduct(GeneralInfo!, MediaFiles!,MetaDatas!, Sno);
        }
    }
}