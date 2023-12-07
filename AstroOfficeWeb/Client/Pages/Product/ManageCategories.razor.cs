using AstroOfficeWeb.Client.Shared;
using AstroShared.DTOs;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using System.ComponentModel.DataAnnotations;
using static AstroOfficeWeb.Client.Shared.CategoryDialog;
using static MudBlazor.CategoryTypes;
using static System.Formats.Asn1.AsnWriter;

namespace AstroOfficeWeb.Client.Pages.Product
{

    public class CategoryDialoge 
    {
        [Required]
        public string Title { get; set; } = string.Empty;
        [Required]
        public string Slug { get; set; } = string.Empty;

        public string FileUpload { get; set; }

        public string ParentCategory { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
         [Required]
        public string Status { get; set; } = string.Empty;

        public int TotalProducts { get; set; } = 0;

        public int TotalEarning { get; set; } = 0;
    }

    public partial class ManageCategories
    {
        [CascadingParameter]
        public CategoryDialoge CategoryDialoge { get; set; } = new();

        private List<CategoryDialoge> CategoryList { get; set; } = new List<CategoryDialoge>();

        private IEnumerable<OrderDTO>? OrderDTOs { get; set; }

        [Parameter]
        public EventCallback<CategoryDialoge> OnSelectCategoryChanged { get; set; }

        private string _searchString;

        protected override void OnInitialized()
        {
            base.OnInitialized();
        }

        private Func<CategoryDialoge, bool> _quickFilter => x =>
        {
            if (string.IsNullOrWhiteSpace(_searchString))
                return true;

            if (x.Title.Contains(_searchString, StringComparison.OrdinalIgnoreCase))
                return true;

            if (x.Description.Contains(_searchString, StringComparison.OrdinalIgnoreCase))
                return true;

            if ($"{x.TotalProducts} {x.TotalEarning}".Contains(_searchString))
                return true;

            return false;
        };

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
                //Add code to add data in Database here
            }
        }

        public async Task<string> CategoryImages(IBrowserFile file)
        {
            if (file == null)
                return "images/image-not-found.png";
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
