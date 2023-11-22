using AstroOfficeWeb.Client.Services.IService;
using AstroOfficeWeb.Shared.Models;
using AstroShared.DTOs;
using AstroShared.Helper;
using Microsoft.JSInterop;

namespace AstroOfficeWeb.Client.Services
{
    public class ProductService
    {
        private readonly ISwaggerApiService _swagger;
        private readonly IJSRuntime _jsRuntime;

        public ProductService(ISwaggerApiService swagger, IJSRuntime jsRuntime)
        {
            _swagger = swagger;
            _jsRuntime = jsRuntime;
        }

        public async Task<List<ViewProductDTO>?> GetProducts()
        {
            var productDTOs = await _swagger.GetAsync<List<ViewProductDTO>>(ProductApiConst.GET_Products);
            return productDTOs;
        }

        public async Task<List<ViewProductDTO>?> GetUserAddedProducts()
        {
            var productDTOs = await _swagger.GetAsync<List<ViewProductDTO>>(ProductApiConst.GET_UserAddedProducts);
            return productDTOs;
        }

        public async Task<ViewProductDTO?> GetProductBySno(long sno)
        {
            var queryParams = new Dictionary<string, string>()
            {
                { "Sno", sno.ToString()}
            };

            var response = await _swagger.GetAsync<ApiResponse<ViewProductDTO>>(ProductApiConst.GET_ProductBySno, queryParams);
            
            return response?.Data;
        }
        public async Task AddProduct()
        {
            var response = await _swagger.GetAsync<ApiResponse<ViewProductDTO>>(ProductApiConst.POST_AddProduct);
            if (response!.Success)
            {
                await _jsRuntime.ShowToastAsync(response.Message);
            }
            else
            {
                await _jsRuntime.ShowToastAsync(response.Message, SwalIcon.Error);
            }
        }
        public async Task UpdateProduct()
        {
            var response = await _swagger.GetAsync<ApiResponse<ViewProductDTO>>(ProductApiConst.PUT_UpdateProduct);
            if (response!.Success)
            {
                await _jsRuntime.ShowToastAsync(response.Message);
            }
            else
            {
                await _jsRuntime.ShowToastAsync(response.Message, SwalIcon.Error);
            }
        }
        public async Task<bool> IsDeletedSelectdProduct(long sno)
        {
            var queryParams = new Dictionary<string, string>()
            {
                { "Sno", sno.ToString()}
            };

            var response = await _swagger.DeleteAsync<ApiResponse<ViewProductDTO>>(ProductApiConst.DELETE_Product, queryParams);
            if (response!.Success)
            {
                await _jsRuntime.ShowToastAsync(response.Message);
                return true;
            }
            else
            {
                await _jsRuntime.ShowToastAsync(response.Message, SwalIcon.Error);
                return false;
            }
        }
    }
}
