using AstroShared.DTOs;
using AstroShared.Helper;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor;
using System.Reflection;

namespace AstroOfficeWeb.Client.Pages.Product
{
    //public class ImgData
    //{
    //    public string? Src { get; set; }
    //    public string Alt { get; set; } = null!;
    //}
    public partial class SaveProduct
    {
        [Parameter]
        public long Sno { get; set; }

        public InputTextArea? ER_TextEditor { get; set; }

        public List<ImagesDTO> BrowserFiles { get; set; } = new();

        public SaveProductDTO? SaveProductModel { get; set; }

        public ViewProductDTO? ViewProductDTO { get; set; }

        public List<string>? FileNames { get; set; }

        public bool IsImageLoaded { get; set; }
        public ImagesDTO? SelectedImage { get; set; }
        bool success;
        string[] errors = { };
        MudForm form;
        string fileValidation = "none";
        protected override void OnInitialized()
        {
            //base.OnInitialized();

            ViewProductDTO = StateContainerService.GetSelectedProduct();

            if (ViewProductDTO != null)
            {
                SaveProductModel = new SaveProductDTO()
                {
                    Price = ViewProductDTO.Price,
                    Name = ViewProductDTO.Name,
                    Description = ViewProductDTO.Description,
                    ImageUrl = ViewProductDTO.ImageUrl,
                    StockQuantity = ViewProductDTO.StockQuantity,
                    AddedDate = ViewProductDTO.AddedDate,
                    LastModifiedDate = ViewProductDTO.LastModifiedDate,
                    IsActive = ViewProductDTO.IsActive
                };

                SelectedImage = new ImagesDTO { ImageName = SaveProductModel.Name, ImageURL = SaveProductModel?.ImageUrl };
            }
            else
            {
                SaveProductModel = new SaveProductDTO();
                //SelectedImage = new ImgData { Alt = "No Product Image", Src = "images/image-not-found.png" };
            }
        }

        protected override async Task OnInitializedAsync()
        {

            //if (Sno != 0)
            //{
            //    var viewProductDTO = await ProductService.GetProductBySno(Sno);

            //    SaveProductModel = new SaveProductDTO()
            //    {
            //        Price = viewProductDTO!.Price,
            //        Name = viewProductDTO.Name,
            //        Description = viewProductDTO.Description,
            //        ImageUrl = viewProductDTO.ImageUrl,
            //        StockQuantity = viewProductDTO.StockQuantity,
            //        AddedDate = viewProductDTO.AddedDate,
            //        LastModifiedDate = viewProductDTO.LastModifiedDate,
            //        IsActive = viewProductDTO.IsActive
            //    };
            //}
            await base.OnInitializedAsync();


            BrowserFiles = await ProductService.GetImagesByProductIds(Sno) ?? new();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await JSRuntime.LoadEditorAsync(ER_TextEditor?.Element);
                StateHasChanged();
            }
        }

        private async Task OnChange_InputFile(InputFileChangeEventArgs e)
        {
            if (e.FileCount > 10)
            {
                await JSRuntime.ShowToastAsync($"The maximum number of files accepted is 10, but {e.FileCount} were supplied.", SwalIcon.Error);
                return;
            }

            if (FileNames == null)
            {
                FileNames = new List<string>();
            }
            else
            {
                FileNames.Clear();
            }

            IsImageLoaded = false;
            foreach (IBrowserFile file in e.GetMultipleFiles(10))
            {
                using (var memoryStream = new MemoryStream())
                {
                    await file.OpenReadStream(file.Size).CopyToAsync(memoryStream);

                    var buffer = memoryStream.ToArray();

                    var base64String = Convert.ToBase64String(buffer);

                    BrowserFiles.Add(new ImagesDTO { ImageURL = $"data:{file.ContentType};base64," + base64String, ImageName = file.Name });
                    FileNames.Add(file.Name);
                    SaveProductModel?.FileNames.Add(file.Name);
                }
            }
            IsImageLoaded = true;
        }

        private async Task OnSubmit_EditForm(EditContext context)
        {
            SaveProductModel!.Description = await JSRuntime.GetEditorValue(ER_TextEditor?.Element);
            if (context.Validate())
            {
                SaveProductModel.ProductImages = BrowserFiles;
                if (Sno == 0)
                {
                    await ProductService.AddProduct(SaveProductModel);
                    //await ProductService.SaveProductImages(BrowserFiles);
                }
                else
                {
                    await ProductService.UpdateProduct(SaveProductModel, Sno);
                }
                NavigationManager.NavigateTo("manage-products");
            }
        }

        private void OnClick_ImageItems(ImagesDTO value)
        {
            SelectedImage = value;
        }

        private void OnClick_RemoveImage(ImagesDTO value)
        {
            BrowserFiles.Remove(value);
            FileNames?.Remove(value.ImageName);
            SaveProductModel?.FileNames.Remove(value.ImageName);
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
                SaveProductModel!.ImageUrl = SelectedImage.ImageURL;
                await JSRuntime.ShowToastAsync("The current selected image has been set as the main image successfully", SwalIcon.Success);
            }
        }
    }
}
