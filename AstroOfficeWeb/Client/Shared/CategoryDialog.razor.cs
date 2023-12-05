using AstroOfficeWeb.Client.Pages.Product;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace AstroOfficeWeb.Client.Shared
{
    public partial class CategoryDialog 
    {
        [CascadingParameter] MudDialogInstance? MudDialog { get; set; }

        [Parameter] public CategoryDialoge Category { get; set; } = new CategoryDialoge();


        private void Cancel()
        {
            MudDialog!.Cancel();
        }

        private void AddCategory()
        {
            //In a real world scenario this bool would probably be a service to delete the item from api/database
            Snackbar.Add("Category Added", Severity.Success);
            MudDialog!.Close(DialogResult.Ok(Category.Title));
        }
    }
}
