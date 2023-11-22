
using AstroOfficeWeb.Client.Shared;
using AstroShared.DTOs;

namespace AstroOfficeWeb.Client.Pages.Product
{
    public partial class ManageProducts
    {
        public List<ViewProductDTO>? Products { get; set; }
        public ConfirmationModal Confirmation { get; set; } = null!;
        public ViewProductDTO? SelectedProduct { get; set; }
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

        private void OnClick_BtnShow(ViewProductDTO productDTO) 
        {
            SelectedProduct = productDTO;
            StateContainerService.SetSelectedProduct(productDTO);
            NavigationManager.NavigateTo($"/view-product/{productDTO.Sno}");
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

        private void OnClick_BtnEdit(ViewProductDTO productDTO) 
        {
            SelectedProduct = productDTO;
            StateContainerService.SetSelectedProduct(productDTO);
            NavigationManager.NavigateTo($"/save-product/{productDTO.Sno}");
        }
    }
}
