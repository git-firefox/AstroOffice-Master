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
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AstroOfficeWeb.Components.ProductComponents
{


    public class ProductImage
    {

        public string? Src { get; set; }
        public string Alt { get; set; } = null!;



        [Required(ErrorMessage = "Please select a file.")]
        //[MinLength(1, ErrorMessage = "Upload atleast 1 image.")]
        [MaxLength(10, ErrorMessage = "Can only upload max 10 images.")]
        [MinLength(1)]

        public List<string> FileNames { get; set; } = new();
    }

    public partial class SaveProduct
    {

        [Parameter]
        public long Sno { get; set; } = 0;

        [Parameter]
        public ActionMode Mode { get; set; }

        [Parameter]
        public string? Name { get; set; }

        private ElementReference ER_AGeneralInfo { get; set; }
        private ElementReference ER_AProductImage { get; set; }
        private ElementReference ER_AMetaData { get; set; }


        private ProductGeneralInformationModel? GeneralInformation { get; set; }
        private ProductMediaFilesModel? ProductMedia { get; set; }
        private ProductMetaDatasModel? ProductMeta { get; set; }


       
        private EditContext SaveProductImageInfoContext { get; set; } = null!;
    

       

        public BaseProductDTO GeneralInfo { get; set; } = new();





        private int Counter = 0;

        public List<ImagesDTO> BrowserFiles { get; set; } = new();


        public SaveProductDTO? SaveProductModel { get; set; }
        public ProductImage ProductImage { get; set; } = new();




        //public ProductDTO ViewProductDTO { get; set; } = new();

        MudMessageBox MessageBox { get; set; } = null!;

        public bool IsImageLoaded { get; set; }
        public ImagesDTO? SelectedImage { get; set; }
        bool success;
        string[] errors = { };
        //MudForm form;
        string fileValidation = "none";
       

        protected override void OnInitialized()
        {
            base.OnInitialized();

            //GeneralInformationContext = new EditContext(GeneralInfo);
            //SaveProductImageInfoContext = new EditContext(ProductMedia);
            //SaveProductMetadataInfoContext = new EditContext(ProductMeta);

        }

        protected override async Task OnInitializedAsync()
        {
            //var productInfo = await ProductService.InitialiseProductBySno(Sno);


            //GeneralInformationContext = new EditContext(productInfo.GeneralInformation);
            //SaveProductImageInfoContext = new EditContext(ProductImage);
            //SaveProductMetadataInfoContext = new EditContext(MetaData);

            //CategoryDTOs = await ProductService.GetCategories();

            //if (productDTO != null)
            //{
            //    ProductModel = productDTO;
            //    BrowserFiles = ProductModel.ProductImages ??= new();
            //    MetaDataList = ProductModel.MetaDatas ??= new();
            //    CharacterCount = Convert.ToInt32(ProductModel.Summary?.Length);
            //}

        }



        
        protected override Task OnAfterRenderAsync(bool firstRender)
        {
            return base.OnAfterRenderAsync(firstRender);
        }


        private List<MediaFile> FileData { get; set; } = new List<MediaFile>();

        private async Task OnChange_InputFile(InputFileChangeEventArgs e)
        {
            Snackbar.Configuration.PositionClass = Defaults.Classes.Position.BottomCenter;
            if (e.FileCount > 10)
            {
                Snackbar.Add("$\"The maximum number of files accepted is 10, but {e.FileCount} were supplied.", Severity.Error);
                //await JSRuntime.ShowToastAsync($"The maximum number of files accepted is 10, but {e.FileCount} were supplied.", SwalIcon.Error);

                return;
            }

            if (ProductImage?.FileNames == null)
            {
                ProductImage!.FileNames = new List<string>();
            }
            else
            {
                ProductImage?.FileNames.Clear();
            }

            IsImageLoaded = false;
            foreach (IBrowserFile file in e.GetMultipleFiles(10))
            {
                using var memoryStream = new MemoryStream();
                await file.OpenReadStream(file.Size).CopyToAsync(memoryStream);

                var buffer = memoryStream.ToArray();
                var base64String = Convert.ToBase64String(buffer);

                FileData.Add(new MediaFile { File = file.OpenReadStream(file.Size), MediaName = file.Name, ContentType = file.ContentType });


                BrowserFiles.Add(new ImagesDTO { ImageURL = $"data:{file.ContentType};base64," + base64String, ImageName = file.Name });
                ProductImage?.FileNames.Add(file.Name);
                SaveProductModel?.FileNames.Add(file.Name);
            }
            IsImageLoaded = true;

            SaveProductImageInfoContext.Validate();

        }

        enum ProceedSaveProduct
        {
            General,
            ProductImage,
            Metadata
        }
        DialogOptions closeButton = new DialogOptions() { CloseButton = true };

        //private async Task OpenDeleteConfirmationDialog(MetaDataDTO metaDataDTO)
        //{

        //    if (MetaDataList.Contains(metaDataDTO))
        //    {

        //        var data = Dialog.Show<DeleteConfirmationDialog>("Confirmation", closeButton);
        //        if (data != null)
        //        {

        //            MetaDataList.Remove(metaDataDTO);
        //            StateHasChanged();
        //        }

        //    }



        //}




        private async Task OnClick_BtnProceed(ProceedSaveProduct mode)
        {

            //if (!SaveProductInfoContext.Validate())
            //{
            //    await JSRuntime.ShowTabAsync(ER_AGeneralInfo);
            //}
            //if (!SaveProductImageInfoContext.Validate())
            //{
            //    await JSRuntime.ShowTabAsync(ER_AProductImage);
            //}

            //if (!SaveProductMetadataInfoContext.Validate())
            //{
            //    await JSRuntime.ShowTabAsync(ER_AMetaData);
            //}



            if (mode == ProceedSaveProduct.General)
            {
                await JSRuntime.ShowTabAsync(ER_AGeneralInfo);
            }
            else if (mode == ProceedSaveProduct.ProductImage)
            {
                await JSRuntime.ShowTabAsync(ER_AProductImage);
            }
            else if (mode == ProceedSaveProduct.Metadata)
            {
                await JSRuntime.ShowTabAsync(ER_AMetaData);
            }

        }



        private async Task OnSubmit_EditForm(EditContext context)
        {
            if (context.Validate())
                await JSRuntime.ShowTabAsync(ER_AProductImage);
        }
        //private async Task OnInvalidSubmit_EditForm(EditContext context)
        //{
        //    //await JSRuntime.ShowTabAsync(ER_AProductImage);
        //}
        private async Task OnSubmit_ProductImage(EditContext context)
        {
            await JSRuntime.ShowTabAsync(ER_AMetaData);
        }
        //private async Task OnInvalidSubmit_ProductImage(EditContext context)
        //{
        //    //await JSRuntime.ShowTabAsync(ER_AProductImage);
        //}

        //private async Task OnSubmit_MetaData(EditContext context)
        //{

        //}
        //private async Task OnInvalidSubmit_MetaData(EditContext context)
        //{

        //}

        private async Task OnClick_BtnPublished()
        {
            //if (!SaveProductInfoContext.Validate())
            //{
            //    await JSRuntime.ShowTabAsync(ER_AGeneralInfo);
            //    return;
            //}


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


        private void OnClick_ImageItems(ImagesDTO value)
        {
            SelectedImage = value;
        }

        private void OnClick_RemoveImage(ImagesDTO value)
        {
            BrowserFiles.Remove(value);
            ProductImage?.FileNames?.Remove(value!.ImageName);
            SaveProductModel?.FileNames.Remove(value!.ImageName);
            if (SelectedImage == value)
                SelectedImage = null;
        }


        private async Task OnClick_BtnSetAsMain(MouseEventArgs e)
        {
            if (SelectedImage == null)
            {
                Snackbar.Configuration.PositionClass = Defaults.Classes.Position.BottomCenter;
                if (BrowserFiles.Count == 0)
                {
                    Snackbar.Add("Please add images", Severity.Error);
                    //await JSRuntime.ShowToastAsync("Please add image(s)", SwalIcon.Error);
                    return;
                }

                Snackbar.Add("Please select image from list", Severity.Error);
                //await JSRuntime.ShowToastAsync("Please select image from list", SwalIcon.Error);
            }
            else
            {
                //ProductModel!.ImageUrl = SelectedImage.ImageURL;
                //Snackbar.Add("The current selected image has been set as the main image successfully", Severity.Success);
                //await JSRuntime.ShowToastAsync("The current selected image has been set as the main image successfully", SwalIcon.Success);
            }

        }
       
        
    }
}