//using AstroOfficeWeb.Client.Shared;
//using AstroOfficeWeb.Shared.ComponentModels;
//using AstroOfficeWeb.Shared.DTOs;

//using Microsoft.AspNetCore.Components;
//using Microsoft.AspNetCore.Components.Forms;
//using MudBlazor;
//using System.ComponentModel.DataAnnotations;
//using static AstroOfficeWeb.Client.Shared.CategoryDialog;
//using static MudBlazor.CategoryTypes;
//using static System.Formats.Asn1.AsnWriter;

//namespace AstroOfficeWeb.Client.Pages.Product
//{

//    public partial class ManageCategories
//    {
//        [CascadingParameter]
//        public CategoryDialoge CategoryDialoge { get; set; } = new();
//        //[CascadingParameter] ManageCategories obj { get; set; } = this;

//        private List<CategoryDialoge> CategoryList { get; set; } = new List<CategoryDialoge>();

//        private IEnumerable<OrderDTO>? OrderDTOs { get; set; }
//        private List<CategoryDialoge>? categoryList { get; set; }

//        //private List<CategoryDialoge> cateList;

//        [Parameter]
//        public EventCallback<CategoryDialoge> OnSelectCategoryChanged { get; set; }

//        private string _searchString;

//        protected override void OnInitialized()
//        {
//            base.OnInitialized();
//        }

//        private Func<CategoryDialoge, bool> _quickFilter => x =>
//        {
//            if (string.IsNullOrWhiteSpace(_searchString))
//                return true;

//            if (x.Title.Contains(_searchString, StringComparison.OrdinalIgnoreCase))
//                return true;

//            if (x.Descriptions.Contains(_searchString, StringComparison.OrdinalIgnoreCase))
//                return true;

//            if ($"{x.TotalProducts} {x.TotalEarning}".Contains(_searchString))
//                return true;

//            return false;
//        };



//        protected override async Task OnInitializedAsync()
//        {

//            categoryList = await ProductService.GetCategories();

//        }

//        private void OnClick_BtnViewOrder(OrderDTO order)
//        {
//            NavigationManager.NavigateTo($"/view-order/{order.OrderId}");
//        }


//        public async Task Onclick_AddMetaData()
//        {
//            var parameters = new DialogParameters();
//            parameters.Add("CategoryDTOs", categoryList);
//            parameters.Add("Mode", ActionMode.Add);

//            var dialog = await DialogService.ShowAsync<CategoryDialog>("Add Category", parameters, new DialogOptions() { MaxWidth = MaxWidth.Large, CloseButton = true });

//            var result = await dialog.Result;

//            if (!result.Canceled)
//            {
//                CategoryList.Add((CategoryDialoge)result.Data);

//                //Add code to add data in Database here
//            }
//        }

//        public async Task<string> CategoryImages(IBrowserFile file)
//        {
//            if (file == null)
//                return "images/image-not-found.png";
//            using (var memoryStream = new MemoryStream())
//            {
//                await file.OpenReadStream(file.Size).CopyToAsync(memoryStream);

//                var buffer = memoryStream.ToArray();

//                var base64String = Convert.ToBase64String(buffer);

//                return $"data:{file.ContentType};base64," + base64String;
//            }
//        }

//        private async Task OnClick_DeleteCategory(CategoryDialoge category)
//        {
//            bool? result = await DialogService.ShowMessageBox(title: "Alert", message: "Are you sure you want to delete?", yesText: "Delete", noText: "", cancelText: "Cancel", new DialogOptions() { FullWidth = true });

//            if (result.GetValueOrDefault())
//            {
//                var response = await ProductService.IsDeletedSelectedCategory(category.Sno);
//                if (response)
//                {
//                    categoryList?.Remove(category);
//                    StateHasChanged();
//                }
//            }
//        }


//        private async Task OnClick_CategoryEdit(CategoryDTO categoryDTO)
//        {
//            var parameters = new DialogParameters();
//            parameters.Add("Category", categoryDTO);
//            parameters.Add("CategoryDTOs", categoryList);
//            parameters.Add("Mode", ActionMode.Edit);

//            var dialog = await DialogService.ShowAsync<CategoryDialog>("Edit Category", parameters, new DialogOptions() { MaxWidth = MaxWidth.Large, CloseButton = true });

//            var result = await dialog.Result;

//        }
//    }
//}
