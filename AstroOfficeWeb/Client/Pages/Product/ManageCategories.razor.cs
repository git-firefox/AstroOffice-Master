using AstroOfficeWeb.Client.Shared;
using AstroShared.DTOs;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using static AstroOfficeWeb.Client.Shared.CategoryDialog;
using static System.Formats.Asn1.AsnWriter;

namespace AstroOfficeWeb.Client.Pages.Product
{

    public class CategoryDialoge 
    {
        public string? Title { get; set; }

        public string? Slug { get; set; }

        public string? FileUpload { get; set; }

        public string? ParentCategory { get; set; }

        public string? Description { get; set; }

        public string? Status { get; set; }
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




            CategoryList.Add(new CategoryDialoge
            {
                
            });
            //CategoryDialoge = new CategoryDialoge();


            //CategoryList.Add(new CategoryDialoge
            //{
            //    Title = CategoryDialoge!.Title,
            //    Slug = CategoryDialoge!.Slug,
            //    FileUpload = CategoryDialoge!.FileUpload,
            //    ParentCategory = CategoryDialoge!.ParentCategory,
            //    Description = CategoryDialoge!.Description,
            //    Status = CategoryDialoge!.Status,
            //});
            //CategoryDialoge = new CategoryDialoge();
        }

    }
}
