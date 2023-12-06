using AstroOfficeWeb.Client.Pages.Product;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;

namespace AstroOfficeWeb.Client.Shared
{
    public partial class CategoryDialog 
    {
        [CascadingParameter] MudDialogInstance? MudDialog { get; set; }

        [Parameter] public CategoryDialoge Category { get; set; } = new CategoryDialoge();
       
        List<IBrowserFile> Files { get; set; } = new List<IBrowserFile>();

        private List<CategoryDialoge> CategoryList { get; set; } = new List<CategoryDialoge>();
        private void Cancel()
        {
            MudDialog!.Cancel();
        }

        private void UploadFiles(IBrowserFile file)
        {
            Files.Add(file);
            Category.FileUpload = file;
            //TODO upload the files to the server
        }

        public  void AddCategory()
        {
            //In a real world scenario this bool would probably be a service to delete the item from api/database
            CategoryList.Add(new CategoryDialoge
            {
                Title = Category!.Title,
                Slug = Category!.Slug,
                 FileUpload = Category!.FileUpload,
                ParentCategory = Category!.ParentCategory,
                Description = Category!.Description,
                Status = Category!.Status
            });
            
            Snackbar.Add("Category Added", Severity.Success);
            MudDialog.Close(DialogResult.Ok(Category));
        }
    }
}
