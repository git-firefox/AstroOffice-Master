
using AstroShared.DTOs;
using AstroShared.Utilities;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;

namespace AstroOfficeWeb.Client.Pages.Product
{
    public class ProductCartViewModel
    {
        public List<CartItemDTO>? CartItems { get; set; }
    }

    public partial class ProductCart
    {
        //private List<CartItemDTO>? CartItems { get; set; }
        private EditContext CartItemEditContext { get; set; } = null!;
        private CalculateOrderSummary OrderSummary { get; set; } = null!;

        ProductCartViewModel ProductCartViewModel { get; set; } = new();
        protected override void OnInitialized()
        {
            base.OnInitialized();

            CartItemEditContext = new EditContext(ProductCartViewModel);
        }

        protected override async Task OnInitializedAsync()
        {
            //CartItems = await ProductService.GetCartItems();
            ProductCartViewModel.CartItems = await ProductService.GetCartItems();
            if (ProductCartViewModel.CartItems != null)
                UpdateOrderSummary();
        }

        private void OnClick_UpdateQuantity(CartItemDTO cartItem, int quantity)
        {

            var tempQuantity = cartItem.ProductQuantity + quantity;
            if (tempQuantity < 1 || tempQuantity > 5)
                return;
            cartItem.ProductQuantity += quantity;
            UpdateOrderSummary();
        }

        private async Task OnClick_ARemoveItem(CartItemDTO cartItem)
        {
            ProductCartViewModel.CartItems!.Remove(cartItem);
            UpdateOrderSummary();
            if (ProductCartViewModel.CartItems.Count == 0)
            {
                await ProductService.UpdateShoppingCart(ProductCartViewModel.CartItems);
            }
        }

        private async Task OnClik_BtnCheckout(MouseEventArgs e)
        {
            var isCartUpdated = await ProductService.UpdateShoppingCart(ProductCartViewModel.CartItems);
            if (isCartUpdated)
                NavigationManager.NavigateTo("checkout");
        }

        private void UpdateOrderSummary()
        {
            OrderSummary = new(ProductCartViewModel.CartItems!.Sum(ci => ci.ProductQuantity * ci.ProductPrice));
        }
    }
}
