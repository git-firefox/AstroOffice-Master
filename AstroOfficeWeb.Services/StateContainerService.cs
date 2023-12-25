using AstroOfficeWeb.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroOfficeServices
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
