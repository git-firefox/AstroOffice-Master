using AstroShared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroOfficeSharedComponents
{
    public partial class UserOrders
    {
        private IEnumerable<OrderDTO>? OrderDTOs { get; set; }
        protected override void OnInitialized()
        {
            base.OnInitialized();
        }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            OrderDTOs = await ProductService.GetUserOrders();
        }

        private void OnClick_DivElement(OrderDTO order)
        {
            NavigationManager.NavigateTo($"/view-order/{order.OrderId}");
        }
    }
}
