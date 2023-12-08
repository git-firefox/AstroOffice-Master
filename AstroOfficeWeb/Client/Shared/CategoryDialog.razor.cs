using AstroOfficeWeb.Client.Pages.Product;
using AstroShared.DTOs;
using AstroShared.Helper;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using MudBlazor;

namespace AstroOfficeWeb.Client.Shared
{
    public partial class CategoryDialog
    {
        [CascadingParameter] MudDialogInstance? MudDialog { get; set; }

        [Parameter] public CategoryDialoge Category { get; set; } = new CategoryDialoge();

        [Parameter] public IEnumerable<CategoryDialoge> CategoryDTOs { get; set; } = new List<CategoryDialoge>();

        public string CategoryImage { get; set; }

        //public CategoryImageDTO BrowserFiles { get; set; } = new();

        //public List<string> FileNames { get; set; } = new();

        private List<CategoryDialoge> CategoryList { get; set; } = new List<CategoryDialoge>();

        MudForm form;

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
            //TODO upload the files to the server
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




        public void AddCategory(EditContext context)
        {
            StateHasChanged();
            Random random = new Random();

            // Generate a random number between 0 and 2000
            //In a real world scenario this bool would probably be a service to delete the item from api/database
            CategoryList.Add(new CategoryDialoge
            {
                Title = Category!.Title,
                Slug = Category!.Slug,
                FileUpload = Category!.FileUpload,
                ParentCategory = Category!.ParentCategory,
                Descriptions = Category!.Descriptions,
                Status = Category!.Status,
                TotalEarning = random.Next(0, 2001),
                TotalProducts = random.Next(0, 2001)
            });

            Snackbar.Add("Category Added", Severity.Success);
            MudDialog.Close(DialogResult.Ok(Category));
        }
    }
}
