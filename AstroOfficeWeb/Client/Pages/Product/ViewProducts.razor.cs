using AstroShared.DTOs;
using AstroShared.Helper;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;

namespace AstroOfficeWeb.Client.Pages.Product
{
    public partial class ViewProducts
    {
        public List<ViewProductDTO>? Products { get; set; } = new List<ViewProductDTO>();

        public ViewProductDTO? SelectedProduct { get; set; }

        private List<ViewProductDTO> filteredProducts = new List<ViewProductDTO>();
        private List<ViewProductDTO> listedProducts = new List<ViewProductDTO>();
        private List<CategoryDialoge> CategoryDTOs { get; set; } = new();

        private int pageSize = 40;
        private int currentPage { get; set; } = 1;
        private string filterValue = "";

        private int totalPages => (int)Math.Ceiling((double)filteredProducts.Count / pageSize);

        private bool IsFirstPage { get; set; }
        private bool IsLastPage { get; set; }

        [Inject] IJSRuntime JS { get; set; }

        private void OnTextFieldValueChanged(string? newValue)
        {
            Console.WriteLine($"Text field value changed to: {newValue}");
        }
        private void OnSelectValueChanged(string newValue)
        {
            Console.WriteLine($"Selected option changed to: {newValue}");
        }
        protected override void OnInitialized()
        {
            base.OnInitialized();
        }
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            CategoryDTOs = await ProductService.GetCategories();
            Products = await ProductService.GetProducts();
            await ApplyFilter();
        }

        private async Task OnClick_BtnAddToCart(ViewProductDTO product)
        {
            bool isAddedToCart = await ProductService.IsAddToCart(product.Sno);
            if (isAddedToCart)
            {
                await JSRuntime.ShowToastAsync($"\"{product.Name}\" added to your cart.", SwalIcon.Success);
            }
        }

        private async Task OnClick_ALinkView(ViewProductDTO product)
        {
            await LocalStorage.SetItemAsync<ViewProductDTO>(ApplicationConst.Local_SelectedProduct, product);
            NavigationManager.NavigateTo($"/view-product/{product.Sno}");
        }

        private async Task ApplyFilter()
        {
            filteredProducts = Products.ToList();
            var searchString = await JS.InvokeAsync<string>("getSearchboxValue");
            var filter = await JS.InvokeAsync<string>("getDropdownValue");
            var size = await JS.InvokeAsync<string>("getPageSizeValue");
            pageSize = string.IsNullOrEmpty(size) ? 24 : Convert.ToInt32(size);
            if (!string.IsNullOrEmpty(searchString))
                filteredProducts = Products
                .Where(item => item.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (filter == "Low-Max")
                filteredProducts = filteredProducts.OrderBy(x => x.Price).ToList();
            else if (filter == "Max-Low")
                filteredProducts = filteredProducts.OrderByDescending(x => x.Price).ToList();

            currentPage = 1;
            //totalPages = (int)Math.Ceiling((double)filteredItems.Count / pageSize);// Reset to the first page after filtering
            UpdateVisibleItems();
        }

        private void UpdateVisibleItems()
        {
            int startIndex = (currentPage - 1) * pageSize;
            listedProducts = filteredProducts.Skip(startIndex).Take(pageSize).ToList();
            IsFirstPage = currentPage == 1;
            IsLastPage = currentPage == totalPages;
        }

        private void NextPage()
        {
            currentPage++;
            if (!IsLastPage)
            {

                UpdateVisibleItems();
            }
        }

        private void PreviousPage()
        {
            if (!IsFirstPage)
            {
                currentPage--;
                UpdateVisibleItems();
            }
        }
    }
}
