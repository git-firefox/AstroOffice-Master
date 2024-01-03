
//using AstroOfficeWeb.Shared.DTOs;


//namespace AstroOfficeWeb.Client.Pages.Product
//{
//    public partial class UserOrders
//    {
//        private IEnumerable<OrderDTO>? OrderDTOs { get; set; }
//        protected override void OnInitialized()
//        {
//            base.OnInitialized();
//        }

//        protected override async Task OnInitializedAsync()
//        {
//            await base.OnInitializedAsync();

//            OrderDTOs = await ProductService.GetUserOrders();
//        }

//        private void OnClick_DivElement(OrderDTO order)
//        {
//            NavigationManager.NavigateTo($"/view-order/{order.OrderId}");
//        }
//    }
//}
