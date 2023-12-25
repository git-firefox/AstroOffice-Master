using AstroOfficeWeb.Shared.DTOs;


namespace AstroOfficeWeb.Client.Services
{
    public class StateContainerService
    {
        private ViewProductDTO? _selectedProduct;
        public event Action OnStateChange = null!;
        public void SetSelectedProduct(ViewProductDTO? value)
        {
            this._selectedProduct = value;
            NotifyStateChanged();
        }

        public ViewProductDTO? GetSelectedProduct()
        {
            return this._selectedProduct;
        }

        private void NotifyStateChanged() => OnStateChange?.Invoke();

    }
}
