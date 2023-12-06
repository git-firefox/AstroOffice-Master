using AstroOfficeWeb.Client.Shared;
using AstroShared.DTOs;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using static AstroOfficeWeb.Client.Shared.CategoryDialog;
using static System.Formats.Asn1.AsnWriter;

namespace AstroOfficeWeb.Client.Pages.Product
{

    public class CategoryDialoge 
    {
        public string Title { get; set; } = string.Empty;

        public string Slug { get; set; } = string.Empty;

        public IBrowserFile FileUpload { get; set; }

        public string ParentCategory { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Status { get; set; } = string.Empty;
    }

    public partial class ManageCategories
    {
        [CascadingParameter]
        public CategoryDialoge CategoryDialoge { get; set; } = new();

        private List<CategoryDialoge> CategoryList { get; set; } = new List<CategoryDialoge>();

        private IEnumerable<OrderDTO>? OrderDTOs { get; set; }

        [Parameter]
        public EventCallback<CategoryDialoge> OnSelectCategoryChanged { get; set; }


        protected override void OnInitialized()
        {
            base.OnInitialized();
        }

        protected override async Task OnInitializedAsync()
        {
            OrderDTOs = await ProductService.GetOrders();
        }

        private void OnClick_BtnViewOrder(OrderDTO order)
        {
            NavigationManager.NavigateTo($"/view-order/{order.OrderId}");
        }

        
        public async Task Onclick_AddMetaData()
        {
            var parameters = new DialogParameters();
            parameters.Add("Category", CategoryDialoge);

            var dialog = await DialogService.ShowAsync<CategoryDialog>("Add Category", parameters, new DialogOptions() { MaxWidth = MaxWidth.Large, CloseButton = true });

            var result = await dialog.Result;

            if (!result.Canceled)
            {
                CategoryList.Add((CategoryDialoge)result.Data);
            }
        }

        public async Task<string> CategoryImages(IBrowserFile file)
        {
            using (var memoryStream = new MemoryStream())
            {
                await file.OpenReadStream(file.Size).CopyToAsync(memoryStream);

                var buffer = memoryStream.ToArray();

                var base64String = Convert.ToBase64String(buffer);

                return $"data:{file.ContentType};base64," + base64String;
            }
        }

    }
}
