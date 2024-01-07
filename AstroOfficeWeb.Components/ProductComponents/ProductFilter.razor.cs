using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AstroOfficeWeb.Shared.Utilities;
using AstroOfficeWeb.Shared.ViewModels;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor;

namespace AstroOfficeWeb.Components.ProductComponents
{
    public partial class ProductFilter
    {
        MudForm Form { get; set; } = null!;
        ProductFilterViewModel ProductFilterModal { get; set; } = new();
        private async Task OnTextChanged_InputSearch(string value)
        {
            //await OnSearchChanged.InvokeAsync(value);
            ProductFilterModal.Search = value;
            await OnFilterChanged.InvokeAsync(ProductFilterModal);
        }

        private async Task SelectedValuesChanged_InputSorting(IEnumerable<ProductSorting> values)
        {

            //await OnSortingChanged.InvokeAsync(values.First());
            ProductFilterModal.Sorting = values.First();
            await OnFilterChanged.InvokeAsync(ProductFilterModal);
        }

        private async Task SelectedValuesChanged_InputPage(IEnumerable<int> values)
        {
            //await OnPageChanged.InvokeAsync(values.First());
            ProductFilterModal.Page = values.First();
            await OnFilterChanged.InvokeAsync(ProductFilterModal);
        } 
        
        private async Task OnClick_BtnReset(MouseEventArgs args)
        {
            await Form.ResetAsync();
            await OnFilterReset.InvokeAsync(args);
        }
    }
}
