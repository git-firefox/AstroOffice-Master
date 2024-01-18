using System;
using System.Collections.Generic;
using System.Linq;
using AstroOfficeWeb.Shared.ComponentModels;
using AstroOfficeWeb.Shared.Utilities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor;

namespace AstroOfficeWeb.Components.ModalComponents
{
    public partial class SaveCategoryModal : ComponentBase
    {
        [CascadingParameter]
        MudDialogInstance MudDialog { get; set; } = null!;

        [Parameter]
        public CategoryListItem Category { get; set; } = null!;

        [Parameter]
        public IEnumerable<Option> CategoryOptions { get; set; } = Enumerable.Empty<Option>();

        private void Cancel(MouseEventArgs args)
        {
            MudDialog!.Cancel();
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
            }

            IsImageLoaded = true;
        }

        public void AddCategory(EditContext context)
        {
            MudDialog.Close(DialogResult.Ok(new MyDialogResult<CategoryListItem>()
            {
                Result = true,
                Data = Category
            }));
        }
    }
}
