using AstroShared.DTOs;
using AstroShared.Helper;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;

namespace AstroOfficeWeb.Client.Pages.Product
{
    public class ImgData
    {
        public string? Src { get; set; }
        public string Alt { get; set; } = null!;
    }
    public partial class SaveProduct
    {
        [Parameter]
        public long Sno { get; set; }

        public InputTextArea? ER_TextEditor { get; set; }

        public List<ImgData> BrowserFiles { get; set; } = new();

        public SaveProductDTO? SaveProductModel { get; set; }

        public ViewProductDTO? ViewProductDTO { get; set; }

        public List<string>? FileNames { get; set; }

        public bool IsImageLoaded { get; set; }
        public ImgData? SelectedImage { get; set; }

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

                SelectedImage = new ImgData { Alt = SaveProductModel.Name, Src = SaveProductModel?.ImageUrl  };
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

                    BrowserFiles.Add(new ImgData { Src = $"data:{file.ContentType};base64," + base64String, Alt = file.Name });
                    FileNames.Add(file.Name);
                }
            }
            IsImageLoaded = true;
        }

        private async Task OnSubmit_EditForm(EditContext context)
        {
            if (context.Validate())
            {
                SaveProductModel!.Description = await JSRuntime.GetEditorValue(ER_TextEditor?.Element);
                if (Sno == 0)
                {
                    await ProductService.AddProduct(SaveProductModel);
                }
                else
                {
                    await ProductService.UpdateProduct(SaveProductModel, Sno);
                }
            }
        }

        private void OnClick_ImageItems(ImgData value)
        {
            SelectedImage = value;
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
                SaveProductModel!.ImageUrl = SelectedImage.Src;
                await JSRuntime.ShowToastAsync("The current selected image has been set as the main image successfully", SwalIcon.Success);
            }
        }
    }
}
