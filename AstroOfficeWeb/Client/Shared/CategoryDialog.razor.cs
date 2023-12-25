using AstroOfficeWeb.Client.Pages.Product;
using AstroOfficeWeb.Client.Services;


using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using MudBlazor;

namespace AstroOfficeWeb.Client.Shared
{
    public partial class CategoryDialog
    {
        [CascadingParameter] MudDialogInstance MudDialog { get; set; } = null!;

        [Parameter] public CategoryDialoge Category { get; set; } = new CategoryDialoge();

        [Parameter] public List<CategoryDialoge> CategoryDTOs { get; set; } = null!;
        [Parameter] public ActionMode Mode { get; set; }

        public string? CategoryImage { get; set; }

        private void Cancel()
        {
            MudDialog!.Cancel();
        }

        private async Task UploadFiles(IBrowserFile file)
        {
            using (var memoryStream = new MemoryStream())
            {
                await file.OpenReadStream(file.Size).CopyToAsync(memoryStream);

                var buffer = memoryStream.ToArray();

                var base64String = Convert.ToBase64String(buffer);
                CategoryImage = file.Name;

                Category.FileUpload = $"data:{file.ContentType};base64," + base64String;
            }
        }


        public bool IsImageLoaded { get; set; }
        private async Task OnChange_InputFile(InputFileChangeEventArgs e)
        {

            IsImageLoaded = false;
            IBrowserFile file = e.File;

            using (var memoryStream = new MemoryStream())
            {
                await file.OpenReadStream(file.Size).CopyToAsync(memoryStream);

                var buffer = memoryStream.ToArray();
                var base64String = Convert.ToBase64String(buffer);

                Category.ImageUrl = $"data:{file.ContentType};base64," + base64String;
                CategoryImage = file.Name;
            }

            IsImageLoaded = true;
        }


        public async Task AddCategory(EditContext context)
        {
            await ProductService.SaveAndUpdateCategory(Category);
            if (Mode == ActionMode.Add)
            {
                CategoryDTOs.Add(Category);
            }
            MudDialog.Close(DialogResult.Ok(Category));
        }
    }
}
