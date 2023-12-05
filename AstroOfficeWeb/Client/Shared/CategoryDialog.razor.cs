using AstroOfficeWeb.Client.Pages.Product;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace AstroOfficeWeb.Client.Shared
{
    public partial class CategoryDialog 
    {
        [CascadingParameter] MudDialogInstance? MudDialog { get; set; }

        [Parameter] public CategoryDialoge Category { get; set; } = new CategoryDialoge();
       


        private List<CategoryDialoge> CategoryList { get; set; } = new List<CategoryDialoge>();
        private void Cancel()
        {
            MudDialog!.Cancel();
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
            MudDialog!.Close(DialogResult.Ok(Category.Title));
        }
    }
}
