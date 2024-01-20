
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AstroOfficeWeb.Shared.DTOs;
using AstroOfficeWeb.Shared.ComponentModels;
using AstroOfficeWeb.Shared.Utilities;
using AstroOfficeWeb.Components.ModalComponents;

namespace AstroOfficeWeb.Components.ProductComponents
{
    public partial class ManageCategories
    {
        [Parameter]
        public EventCallback<bool> Loaded { get; set; }

        private string? SearchString { get; set; }

        private Func<CategoryListItem, bool> QuickFilter => x =>
        {
            if (string.IsNullOrWhiteSpace(SearchString))
                return true;

            if (x.Title?.Contains(SearchString, StringComparison.OrdinalIgnoreCase) == true)
                return true;

            if (x.Descriptions?.Contains(SearchString, StringComparison.OrdinalIgnoreCase) == true)
                return true;

            return false;
        };

        private List<CategoryListItem>? Categories { get; set; }
        private IEnumerable<Option>? CategoryOptions { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
        }

        protected override async Task OnInitializedAsync()
        {
            Categories = await ProductService.GetCategories();
            CategoryOptions = Categories?.Select(cl => new Option(cl.Title, cl.Sno));
        }

        private async Task OnClick_DeleteCategory(CategoryListItem category)
        {
            bool? result = await Dialog.ShowMessageBox(title: "Alert", message: "Are you sure you want to delete?", yesText: "Delete", noText: "", cancelText: "Cancel", new DialogOptions() { FullWidth = true });

            if (result.GetValueOrDefault())
            {
                var response = await ProductService.IsDeletedSelectedCategory(category.Sno);
                if (response)
                {
                    Categories?.Remove(category);
                    StateHasChanged();
                }
            }
        }

        private async Task OnClick_UpdateCategory(ActionMode mode = ActionMode.Add, CategoryListItem? categoryDTO = null)
        {
            var parameters = new DialogParameters();
            parameters.Add("Category", categoryDTO ?? new CategoryListItem());
            parameters.Add("CategoryOptions", CategoryOptions);

            var dialog = await Dialog.ShowAsync<SaveCategoryModal>(mode.ToString() + "Category", parameters, new DialogOptions() { FullScreen = true, CloseButton = true });

            var result = await dialog.Result;

            if (result.Data is MyDialogResult<CategoryListItem> myResult)
            {
                UpdateLocalCategory(myResult.Data!);
            }
        }

        private void UpdateLocalCategory(CategoryListItem item)
        {
            if (Categories?.FirstOrDefault(cl => cl.Sno == item.Sno) is CategoryListItem category)
            {

            }
            else
            {

            }
        }
    }
}
