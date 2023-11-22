using AstroShared.DTOs;
using AstroShared.Helper;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace AstroOfficeWeb.Client.Pages.Product
{
    public partial class SaveProduct
    {
        [Parameter]
        public long Sno { get; set; }

        public ElementReference ER_TextEditor { get; set; }
        public SaveProductDTO? SaveProductDTO { get; set; }
        public ViewProductDTO? ViewProductDTO { get; set; }

        protected override void OnInitialized()
        {
            //base.OnInitialized();

            ViewProductDTO = StateContainerService.GetSelectedProduct();

            if (ViewProductDTO != null)
            {
                SaveProductDTO = new SaveProductDTO()
                {
                    Price = ViewProductDTO.Price,
                    Name = ViewProductDTO.Name,
                    Description = ViewProductDTO.Description,
                    ImageUrl = ViewProductDTO.ImageUrl,
                    StockQuantity = ViewProductDTO.StockQuantity,
                    AddedDate = ViewProductDTO.AddedDate,
                    LastModifiedDate = ViewProductDTO.LastModifiedDate,
                    IsActive = ViewProductDTO.IsActive
                };
            }
            else
            {
                SaveProductDTO = new SaveProductDTO();
            }
        }

        protected override async Task OnInitializedAsync()
        {
            //if (Sno != 0)
            //{
            //    var viewProductDTO = await ProductService.GetProductBySno(Sno);

            //    SaveProductDTO = new SaveProductDTO()
            //    {
            //        Price = viewProductDTO!.Price,
            //        Name = viewProductDTO.Name,
            //        Description = viewProductDTO.Description,
            //        ImageUrl = viewProductDTO.ImageUrl,
            //        StockQuantity = viewProductDTO.StockQuantity,
            //        AddedDate = viewProductDTO.AddedDate,
            //        LastModifiedDate = viewProductDTO.LastModifiedDate,
            //        IsActive = viewProductDTO.IsActive
            //    };
            //}

            await base.OnInitializedAsync();
        }

        protected override async void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {
                await JSRuntime.LoadEditorAsync(ER_TextEditor);
            }
        }

        private void OnChange_InputFile(ChangeEventArgs e)
        {
            var fileList = e.Value as IEnumerable<IBrowserFile>;

            if (fileList == null || !fileList.Any()) return;

            var imageFile = fileList.First();

        }
    }

}
