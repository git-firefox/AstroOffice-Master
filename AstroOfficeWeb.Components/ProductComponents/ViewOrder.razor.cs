﻿using AstroOfficeWeb.Shared.Models;
using AstroOfficeWeb.Shared.Utilities;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroOfficeWeb.Components.ProductComponents
{
    public partial class ViewOrder
    {

        [Parameter]
        public long OrderId { get; set; }
        [Parameter]
        public bool IsDataUrl { get; set; } = false;
        public GetOrderResponse? Order { get; set; }
        public CalculateOrderSummary? OrderSummary { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
        }

        protected override async Task OnInitializedAsync()
        {
            Order = await ProductService.GetUserOrder(OrderId, IsDataUrl);
            OrderSummary = new(Order!.OrderItems.Sum(oi => oi.ProductQuantity * oi.ProductPrice));
        }
    }
}
