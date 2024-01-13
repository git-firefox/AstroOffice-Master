
using AstroOfficeWeb.Components.Helper;
using AstroOfficeWeb.Components.MyComponents;
using AstroOfficeWeb.Shared.DTOs;
using AstroOfficeWeb.Shared.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroOfficeWeb.Components.ProductComponents
{
    public partial class ManageProducts
    {
        public List<ViewProductDTO>? Products { get; set; }
        public string? SearchString { get; set; }

        protected override async Task OnInitializedAsync()
        {

            Products = await ProductService.GetProducts();
        }

        private void OnClick_BtnAdd()
        {
            NavigationManager.NavigateTo(ProductRoutes.SaveProduct(mode: ActionMode.Add));
        }

        private void OnClick_BtnShow(ViewProductDTO productDTO)
        {

            NavigationManager.NavigateTo(ProductRoutes.ViewProduct(productDTO.Sno, productDTO!.Name));
        }

        private async Task OnClick_BtnDelete(ViewProductDTO productDTO)
        {
            var confirm = await Dialog.ShowMessageBox("Delete Confirmation", "Are you sure you want to delete this Product?", yesText: "Delete", noText: "Cancel");
            if (confirm.GetValueOrDefault())
            {
                if (await ProductService.IsDeletedSelectdProduct(productDTO.Sno))
                {
                    Products?.Remove(productDTO);
                    StateHasChanged();
                }
            }
        }

        private void OnClick_BtnEdit(ViewProductDTO productDTO)
        {
            NavigationManager.NavigateTo(ProductRoutes.SaveProduct(productDTO.Sno, productDTO.Name, ActionMode.Edit));
        }

        private Func<ViewProductDTO, bool> QuickFilter => x =>
        {
            if (string.IsNullOrWhiteSpace(SearchString))
                return true;

            if (x.Name.Contains(SearchString, StringComparison.OrdinalIgnoreCase))
                return true;

            //if ($"{x.Price} {x.StockQuantity}".Contains(SearchString))
            //    return true;

            return false;
        };
    }
}
