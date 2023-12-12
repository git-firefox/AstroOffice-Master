
using AstroShared.DTOs;
using AstroShared.Utilities;
using Microsoft.AspNetCore.Components.Web;

namespace AstroOfficeWeb.Client.Pages.Product
{

    public partial class ProductCart
    {
        private List<CartItemDTO>? CartItems { get; set; }
        private CalculateOrderSummary OrderSummary { get; set; } = null!;
        protected override void OnInitialized()
        {
            base.OnInitialized();
        }

        protected override async Task OnInitializedAsync()
        {
            CartItems = await ProductService.GetCartItems();
            UpdateOrderSummary();
        }

        private void OnClick_UpdateQuantity(CartItemDTO cartItem, int quantity)
        {
            cartItem.ProductQuantity += quantity;
            UpdateOrderSummary();
        }

        private void OnClick_ARemoveItem(CartItemDTO cartItem)
        {
            CartItems!.Remove(cartItem);
            UpdateOrderSummary();
        }

        private async Task OnClik_BtnCheckout(MouseEventArgs e)
        {
            var isCartUpdated = await ProductService.UpdateShoppingCart(CartItems);
            if (isCartUpdated)
                NavigationManager.NavigateTo("checkout");
        }

        private void UpdateOrderSummary()
        {
            OrderSummary = new(CartItems!.Sum(ci => ci.ProductQuantity * ci.ProductPrice));
        }
    }
}
