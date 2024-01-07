using System.Security.Cryptography.X509Certificates;
using AstroOfficeWeb.Components.Helper;
using AstroOfficeWeb.Shared.DTOs;
using AstroOfficeWeb.Shared.Helper;
using AstroOfficeWeb.Shared.Utilities;
using AstroOfficeWeb.Shared.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor;

namespace AstroOfficeWeb.Components.ProductComponents
{
    public partial class ViewProducts
    {
        private List<ViewProductDTO>? Products { get; set; }
        private List<ViewProductDTO>? FilteredProducts { get; set; }
        private List<ViewProductDTO> VisiableProducts { get; set; } = new();

        private int PageSize { get; set; } = 25;
        private int TotalPages => (int)Math.Ceiling((double)(FilteredProducts ?? new()).Count / PageSize);

        protected override void OnInitialized()
        {
            base.OnInitialized();
        }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            Products = await ProductService.GetProducts();
            if (Products is not null)
            {
                OnFilterChanged(new());
            }
        }

        private void PageChanged(int pageNo)
        {
            CurrentPage = pageNo;
            UpdateVisibleItems();
        }

        private async Task OnCategorySelected(BaseCategoryDTO category)
        {
            Products = await ProductService.GetProducts(category.Sno);
            OnFilterChanged(new());
            NavigationManager.NavigateTo(ProductRoutes.ProductsByCategory(category.Sno, category!.Title!));
        }

        private async Task OnClick_BtnAddToCart(ViewProductDTO product)
        {
            var tempQuantity = product!.ProductQuantity + 1;
            if (tempQuantity < 1 || tempQuantity > 5)
            {
                Snackbar.ShowErrorSnackbar($"Unable to add more products to your cart. Limit exceeded.");
                return;
            }

            bool isAddedToCart = await ProductService.IsAddToCart(product.Sno);
            if (isAddedToCart)
            {
                product.ProductQuantity += 1;
                Snackbar.ShowSuccessSnackbar($"\"{product.Name}\" added to your cart.");
            }
        }

        private void OnClick_ALinkView(ViewProductDTO product)
        {
            NavigationManager.NavigateTo(ProductRoutes.ViewProduct(product.Sno, product.Name));
        }

        private void OnFilterChanged(ProductFilterViewModel filterViewModel)
        {
            FilteredProducts = (Products ?? new()).ToList();

            if (!string.IsNullOrEmpty(filterViewModel.Search))
            {
                FilteredProducts = Products!.Where(item => item.Name.Contains(filterViewModel.Search, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            if (filterViewModel.Sorting == ProductSorting.PriceAscending)
            {
                FilteredProducts = FilteredProducts.OrderBy(x => x.Price).ToList();
            }
            else if (filterViewModel.Sorting == ProductSorting.PriceDescending)
            {
                FilteredProducts = FilteredProducts.OrderByDescending(x => x.Price).ToList();
            }
            else
            {
                FilteredProducts = FilteredProducts.OrderBy(x => x.Name).ToList();
            }

            PageSize = filterViewModel.Page;
            CurrentPage = 1;
            UpdateVisibleItems();
        }

        private void UpdateVisibleItems()
        {
            int startIndex = (CurrentPage - 1) * PageSize;
            VisiableProducts = (FilteredProducts ?? new()).Skip(startIndex).Take(PageSize).ToList();
        }

        private async Task OnFilterReset(MouseEventArgs args)
        {
            Products = await ProductService.GetProducts();
            if (Products is not null)
            {
                OnFilterChanged(new ());
            }
        }
    }
}