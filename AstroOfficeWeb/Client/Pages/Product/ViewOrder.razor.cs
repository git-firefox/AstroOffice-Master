using AstroOfficeWeb.Shared.Models;
using AstroOfficeWeb.Shared.Utilities;


using Microsoft.AspNetCore.Components;

namespace AstroOfficeWeb.Client.Pages.Product
{
    public partial class ViewOrder
    {

        [Parameter]
        public long OrderId { get; set; }
        public GetOrderResponse? Order { get; set; }
        public CalculateOrderSummary? OrderSummary { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
        }

        protected override async Task OnInitializedAsync()
        {
            Order = await ProductService.GetUserOrder(OrderId);
            OrderSummary = new(Order!.OrderItems.Sum(oi => oi.ProductQuantity * oi.ProductPrice));
        }
    }
}
