using AstroOfficeWeb.Shared.DTOs;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroOfficeWeb.Components.ProductComponents
{
    public partial class UserOrders
    {
        [Parameter]
        public bool IsDataUrl { get; set; } = false;
        private IEnumerable<OrderDTO>? OrderDTOs { get; set; }
        protected override void OnInitialized()
        {
            base.OnInitialized();
        }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            OrderDTOs = await ProductService.GetUserOrders(IsDataUrl);
        }

        private void OnClick_DivElement(OrderDTO order)
        {
            NavigationManager.NavigateTo($"/view-order/{order.OrderId}");
        }
    }
}
