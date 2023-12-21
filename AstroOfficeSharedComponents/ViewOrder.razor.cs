using AstroOfficeWeb.Shared.Models;
using AstroShared.Utilities;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroOfficeSharedComponents
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
