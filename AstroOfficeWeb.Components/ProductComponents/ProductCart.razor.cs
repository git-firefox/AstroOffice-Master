using AstroOfficeWeb.Shared.DTOs;
using AstroOfficeWeb.Shared.Utilities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroOfficeWeb.Components.ProductComponents
{
    public partial class ProductCart
    {
        [Parameter]
        public EventCallback<bool> HandleEmptyCart { get; set; }
        private CalculateOrderSummary OrderSummary { get; set; } = null!;

        public List<CartItemDTO>? CartItems { get; set; }
        protected override void OnInitialized()
        {
            base.OnInitialized();
        }

        protected override async Task OnInitializedAsync()
        {
            //CartItems = await ProductService.GetCartItems();
            CartItems = await ProductService.GetCartItems();
            if (CartItems != null)
                UpdateOrderSummary();
            await HandleEmptyCart.InvokeAsync(CartItems?.Any() == true);
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
            Snackbar.Configuration.PositionClass = Defaults.Classes.Position.BottomCenter;
            CartItems!.Remove(cartItem);
            Snackbar.Add($"{cartItem.ProductName} removed successfully.", Severity.Success);
            UpdateOrderSummary();
            if (CartItems.Count == 0)
            {
                await ProductService.UpdateShoppingCart(CartItems);
                await HandleEmptyCart.InvokeAsync(CartItems?.Any() == true);
            }
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
