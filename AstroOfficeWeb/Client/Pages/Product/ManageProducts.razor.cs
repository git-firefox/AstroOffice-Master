
using AstroOfficeWeb.Client.Shared;
using AstroOfficeWeb.Shared.DTOs;
using AstroOfficeWeb.Shared.Helper;


using static MudBlazor.CategoryTypes;

namespace AstroOfficeWeb.Client.Pages.Product
{
    public partial class ManageProducts
    {
        public List<ViewProductDTO>? Products { get; set; }
        public ConfirmationModal Confirmation { get; set; } = null!;
        public ViewProductDTO? SelectedProduct { get; set; }
        public string _searchString { get; set; }
        protected override void OnInitialized()
        {
            StateContainerService.OnStateChange += StateHasChanged;
        }

        protected override async Task OnInitializedAsync()
        {
            StateContainerService.SetSelectedProduct(null);
            Products = await ProductService.GetProducts();
        }

        private void OnClick_BtnAdd()
        {
            NavigationManager.NavigateTo("/save-product");
        }

        private async Task OnClick_BtnShow(ViewProductDTO productDTO)
        {
            SelectedProduct = productDTO;
            StateContainerService.SetSelectedProduct(productDTO);
            await LocalStorage.SetItemAsync<ViewProductDTO>(ApplicationConst.Local_SelectedProduct, productDTO);
            NavigationManager.NavigateTo($"/product/{productDTO.Sno}/{productDTO.Name.Replace(" ", "-").ToLower()}");
        }

        private async Task OnClick_BtnDelete(ViewProductDTO productDTO)
        {
            SelectedProduct = productDTO;
            await Confirmation.ShowAsync();
        }

        private async void OnConfirmationChanged(bool isConfirm)
        {
            if (isConfirm)
            {
                if (await ProductService.IsDeletedSelectdProduct(SelectedProduct!.Sno))
                {
                    Products?.Remove(SelectedProduct);
                    SelectedProduct = null;
                    StateHasChanged();
                }
            }
            await Confirmation.CloseAsync();
        }

        private async void OnClick_BtnEdit(ViewProductDTO productDTO)
        {
            SelectedProduct = productDTO;
            StateContainerService.SetSelectedProduct(productDTO);
            await LocalStorage.SetItemAsync<ViewProductDTO>(ApplicationConst.Local_SelectedProduct, productDTO);
            NavigationManager.NavigateTo($"/save-product/{productDTO.Sno}");
        }

        private Func<ViewProductDTO, bool> _quickFilter => x =>
        {
            if (string.IsNullOrWhiteSpace(_searchString))
                return true;

            if (x.Name.Contains(_searchString, StringComparison.OrdinalIgnoreCase))
                return true;

            if ($"{x.Price} {x.StockQuantity}".Contains(_searchString))
                return true;

            return false;
        };

    }
}
