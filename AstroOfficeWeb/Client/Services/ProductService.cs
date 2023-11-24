using AstroOfficeWeb.Client.Services.IService;
using AstroOfficeWeb.Shared.Models;
using AstroShared.DTOs;
using AstroShared.Helper;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace AstroOfficeWeb.Client.Services
{
    public class ProductService
    {
        private readonly ISwaggerApiService _swagger;
        private readonly IJSRuntime _jsRuntime;
        private readonly NavigationManager _navigation;

        public ProductService(ISwaggerApiService swagger, IJSRuntime jsRuntime, NavigationManager navigation)
        {
            _swagger = swagger;
            _jsRuntime = jsRuntime;
            _navigation = navigation;
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
        public async Task AddProduct(SaveProductDTO saveProduct)
        {
            var response = await _swagger.PostAsync<SaveProductDTO, ApiResponse<ViewProductDTO>>(ProductApiConst.POST_AddProduct, saveProduct);
            if (response!.Success)
            {
                await _jsRuntime.ShowToastAsync(response.ErrorMessage);
                _navigation.NavigateTo("/manage-products", true, true);
            }
            else
            {
                await _jsRuntime.ShowToastAsync(response.ErrorMessage, SwalIcon.Error);
            }
        }
        public async Task UpdateProduct(SaveProductDTO saveProduct, long sno)
        {
            var response = await _swagger.PutAsync<SaveProductDTO, ApiResponse<ViewProductDTO>>(ProductApiConst.PUT_UpdateProduct + "?sno=" + sno, saveProduct);
            if (response!.Success)
            {
                await _jsRuntime.ShowToastAsync(response.ErrorMessage);
            }
            else
            {
                await _jsRuntime.ShowToastAsync(response.ErrorMessage, SwalIcon.Error);
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
                await _jsRuntime.ShowToastAsync(response.ErrorMessage);
                return true;
            }
            else
            {
                await _jsRuntime.ShowToastAsync(response.ErrorMessage, SwalIcon.Error);
                return false;
            }
        }
    }
}
