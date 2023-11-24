using AstroShared.DTOs;

namespace AstroOfficeWeb.Client.Pages.Product
{
    public partial class ViewProducts
    {
        public List<ViewProductDTO>? Products { get; set; }

        public ViewProductDTO? SelectedProduct { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
        }
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            Products = await ProductService.GetProducts();
        }
    }
}
