using System;
using System.Collections.Generic;
using System.Linq;
using AstroOfficeWeb.Shared.DTOs;
using Microsoft.AspNetCore.Components;

namespace AstroOfficeWeb.Components.ProductComponents
{
    public partial class ViewCategories : ComponentBase
    {
        private List<PCategoryDTO>? CategoryDTOs { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            CategoryDTOs = await ProductService.GetShopCategories();
        }

        private async Task OnClick_CategoryListItem(BaseCategoryDTO category)
        {
            await OnCategorySelected.InvokeAsync(category);
        }

    }
}
