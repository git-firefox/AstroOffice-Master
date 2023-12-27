using AstroOfficeWeb.Client.Shared;
using AstroOfficeWeb.Components;
using AstroOfficeWeb.Shared.ComponentModels;
using AstroOfficeWeb.Shared.DTOs;
using AstroOfficeWeb.Shared.Helper;
using AstroOfficeWeb.Shared.Utilities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.Options;
using MudBlazor;
using MudBlazor.Extensions;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text.Json;
using static MudBlazor.CategoryTypes;

namespace AstroOfficeWeb.Client.Pages.Product
{
    public enum ActionMode
    {
        Add,
        Edit,
        Delete,
        Cancel
    }
    public class ProductImage
    {
        public string? Src { get; set; }
        public string Alt { get; set; } = null!;



        [Required(ErrorMessage = "Please select a file.")]
        //[MinLength(1, ErrorMessage = "Upload atleast 1 image.")]
        [MaxLength(10, ErrorMessage = "Can only upload max 10 images.")]

        public List<string> FileNames { get; set; } = new();
    }

    //public class MetaData
    //{
    //    public int Number { get; set; }
    //    public string MetaTitle { get; set; } = string.Empty;
    //    public string MetaKeyword { get; set; } = string.Empty;

    //    public string? MetaDescription { get; set; }
    //}
    public partial class SaveProduct
    {
        [Parameter]
        public long Sno { get; set; }

        
        private int Counter = 0;

        public ElementReference ER_AGeneralInfo { get; set; }
        public ElementReference ER_AProductImage { get; set; }
        public ElementReference ER_AMetaData { get; set; }

        //public ElementReference? Test1 { get; set; }
        //public DeleteConfirmationDialog? DeleteConfirmationDialog { get; set; }


        public List<ImagesDTO> BrowserFiles { get; set; } = new();


        public SaveProductDTO? SaveProductModel { get; set; }

       
        public ProductDTO ProductModel { get; set; } = new();

        public ProductImage? ProductImage { get; set; } = new();

        public MetaDataDTO MetaData { get; set; } = new();
        public MetaDataDTO? SelectedMetaData { get; set; }
        private ActionMode MetaDataAction { get; set; }
        private List<MetaDataDTO> MetaDataList { get; set; } = new List<MetaDataDTO>();
        private List<CategoryDialoge> CategoryDTOs { get; set; } = new();



        //public ProductDTO ViewProductDTO { get; set; } = new();

        MudMessageBox MessageBox { get; set; } = null!;

        public bool IsImageLoaded { get; set; }
        public ImagesDTO? SelectedImage { get; set; }
        bool success;
        string[] errors = { };
        MudForm form;
        string fileValidation = "none";
        private int CharacterCount { get; set; } = 0;

        protected override void OnInitialized()
        {
            var d = Enum.GetNames<ProductStatus>();
            base.OnInitialized();
        }

        protected override async Task OnInitializedAsync()
        {
            CategoryDTOs = await ProductService.GetCategories();
            if (Sno != 0)
            {
                ProductModel = await ProductService.GetProductBySno(Sno) ?? new();
                BrowserFiles = ProductModel.ProductImages ??= new();
                MetaDataList = ProductModel.MetaDatas ??= new();
                CharacterCount = ProductModel.Summary?.Length ?? 0;
            }
        }



        private void UpdateCharacterCount(ChangeEventArgs args)
        {
            string summary = args.Value?.ToString() ?? string.Empty;
            CharacterCount = summary.Length;
        }
        protected override Task OnAfterRenderAsync(bool firstRender)
        {
            return base.OnAfterRenderAsync(firstRender);
        }


        private List<FileData> FileData { get; set; } = new List<FileData>();

        private async Task OnChange_InputFile(InputFileChangeEventArgs e)
        {
            if (e.FileCount > 10)
            {
                await JSRuntime.ShowToastAsync($"The maximum number of files accepted is 10, but {e.FileCount} were supplied.", SwalIcon.Error);
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


                using (var memoryStream = new MemoryStream())
                {
                    await file.OpenReadStream(file.Size).CopyToAsync(memoryStream);

                    var buffer = memoryStream.ToArray();

                    FileData.Add(new FileData { File = file.OpenReadStream(file.Size), FileName = file.Name, Name = Path.GetFileNameWithoutExtension(file.Name.ToLower()), ContentType = file.ContentType });

                    var base64String = Convert.ToBase64String(buffer);

                    BrowserFiles.Add(new ImagesDTO { ImageURL = $"data:{file.ContentType};base64," + base64String, ImageName = file.Name });
                    ProductImage?.FileNames.Add(file.Name);
                    SaveProductModel?.FileNames.Add(file.Name);
                }
            }
            IsImageLoaded = true;
        }

        enum ProceedSaveProduct
        {
            General,
            ProductImage,
            Metadata
        }
        DialogOptions closeButton = new DialogOptions() { CloseButton = true };

        private async Task OpenDeleteConfirmationDialog(MetaDataDTO metaDataDTO)
        {

            if (MetaDataList.Contains(metaDataDTO))
            {

                var data = Dialog.Show<DeleteConfirmationDialog>("Confirmation", closeButton);
                if (data != null)
                {

                    MetaDataList.Remove(metaDataDTO);
                    StateHasChanged();
                }

            }



        }
        private async Task OnClick_BtnProceed(ProceedSaveProduct mode)
        {
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
        private async Task OnInvalidSubmit_EditForm(EditContext context)
        {
            //await JSRuntime.ShowTabAsync(ER_AProductImage);
        }
        private async Task OnSubmit_ProductImage(EditContext context)
        {
            await JSRuntime.ShowTabAsync(ER_AMetaData);
        }
        private async Task OnInvalidSubmit_ProductImage(EditContext context)
        {
            //await JSRuntime.ShowTabAsync(ER_AProductImage);
        }

        private async Task OnSubmit_MetaData(EditContext context)
        {

        }
        private async Task OnInvalidSubmit_MetaData(EditContext context)
        {

        }

        private async Task OnClick_BtnPublished()
        {
            ProductModel.ProductImages = BrowserFiles;
            ProductModel.MetaDatas = MetaDataList;

            //await ProductService.SaveProductImages(BrowserFiles);
            if (Sno == 0)
            {
                await ProductService.AddProduct(ProductModel);
            }
            else
            {
                await ProductService.UpdateProduct(ProductModel, Sno);
            }
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
                if (BrowserFiles.Count == 0)
                {
                    await JSRuntime.ShowToastAsync("Please add image(s)", SwalIcon.Error);
                    return;
                }

                await JSRuntime.ShowToastAsync("Please select image from list", SwalIcon.Error);
            }
            else
            {
                ProductModel!.ImageUrl = SelectedImage.ImageURL;
                await JSRuntime.ShowToastAsync("The current selected image has been set as the main image successfully", SwalIcon.Success);
            }

        }
        public string searchString = string.Empty;
        public void Onclick_AddMetaData()
        {
            // Add the current MetaDataDTO to the list
            MetaDataList.Add(new MetaDataDTO
            {
                MetaValue = MetaData!.MetaValue,
                MetaKeyword = MetaData.MetaKeyword,
            });
            MetaData = new MetaDataDTO();
        }
        private bool FilterFunc(MetaDataDTO element)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return true;
            if (element.MetaKeyword!.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            return false;
        }

        private async Task OnClick_DeleteMetaData(MetaDataDTO data)
        {
            bool? result = await Dialog.ShowMessageBox(title: "Alert", message: "Are you sure you want to delete?", yesText: "Delete", noText: "", cancelText: "Cancel", new DialogOptions() { FullWidth = true });

            if (result.GetValueOrDefault())
            {
                MetaDataList.Remove(data);
                StateHasChanged();
            }
        }

        private string SearchMetaTitle { get; set; } = string.Empty;
        private Func<string, bool> QuickFilter => x =>
        {
            return x.Contains(SearchMetaTitle, StringComparison.OrdinalIgnoreCase);
        };

        private MetaDataDTO? elementBeforeEdit;

        private void AddEditionEvent(string message)
        {

            StateHasChanged();
        }
        private void BackupItem(object element)
        {
            //elementBeforeEdit = element.As<MetaData>(); 
            //AddEditionEvent($"RowEditPreview event: made a backup of Element {((MetaData)element).MetaTitle}");
            if (element is MetaDataDTO metaData)
            {
                // Serialize and then deserialize to create a deep copy
                var serializedElement = JsonSerializer.Serialize(metaData);
                elementBeforeEdit = JsonSerializer.Deserialize<MetaDataDTO>(serializedElement);

                AddEditionEvent($"RowEditPreview event: made a backup of Element {metaData.MetaValue}");
            }
        }

        private void ResetItemToOriginalValues(object? element)
        {

            //element = elementBeforeEdit; 
            ////element.As<MetaDataDTO>();
            ////MetaDataDTO.MetaKeyword = elementBeforeEdit!.MetaKeyword;
            ////MetaData.MetaTitle = elementBeforeEdit.MetaTitle;
            //AddEditionEvent($"RowEditCancel event: Editing of Element {((MetaData)element).MetaTitle} canceled");




            if (element is MetaDataDTO metaDataElement)
            {
                // Make a copy or create a new instance
                MetaDataDTO originalValues = new MetaDataDTO
                {
                    MetaKeyword = elementBeforeEdit?.MetaKeyword,
                    MetaValue = elementBeforeEdit?.MetaValue,
                    // Copy other properties as needed
                };

                // Reset MetaDataDTO properties using values from the copy
                metaDataElement.MetaKeyword = originalValues.MetaKeyword;
                metaDataElement.MetaValue = originalValues.MetaValue;

                AddEditionEvent($"RowEditCancel event: Editing of Element {metaDataElement.MetaValue} canceled");
            }

        }

        private void ItemHasBeenCommitted(object element)
        {
            AddEditionEvent($"RowEditCommit event: Changes to Element {((MetaDataDTO)element).MetaValue} committed");
        }
    }
}
