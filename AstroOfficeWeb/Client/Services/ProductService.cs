using AstroOfficeWeb.Client.Services.IService;
using AstroOfficeWeb.Shared.Models;
using AstroShared;
using AstroShared.DTOs;
using AstroShared.Helper;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Collections.Generic;

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

        public async Task<List<ImagesDTO>?> GetImagesByProductIds(long sno)
        {
            var queryParams = new Dictionary<string, string>
            {
                { "productId" , sno.ToString() },
            };
            var response = await _swagger.GetAsync<ApiResponse<List<ImagesDTO>>>(ProductApiConst.GET_ProductImages, queryParams);
            if (!response!.Success)
            {
                await _jsRuntime.ShowToastAsync(response.Message, SwalIcon.Error);
                return null;
            }
            return response.Data;
        }

        public async Task<ProductDTO?> GetProductBySno(long sno)
        {
            var queryParams = new Dictionary<string, string>()
            {
                { "Sno", sno.ToString()}
            };

            var response = await _swagger.GetAsync<ApiResponse<ProductDTO>>(ProductApiConst.GET_ProductBySno, queryParams);

            return response?.Data;
        }
        public async Task AddProduct(ProductDTO saveProduct)
        {
            var response = await _swagger.PostAsync<ProductDTO, ApiResponse<ViewProductDTO>>(ProductApiConst.POST_AddProduct, saveProduct);
            if (response!.Success)
            {
                await _jsRuntime.ShowToastAsync(response.Message);
                _navigation.NavigateTo("/manage-products", true, true);
            }
            else
            {
                await _jsRuntime.ShowToastAsync(response.Message, SwalIcon.Error);
            }
        }
        public async Task UpdateProduct(ProductDTO saveProduct, long sno)
        {
            var response = await _swagger.PutAsync<ProductDTO, ApiResponse<ViewProductDTO>>(ProductApiConst.PUT_UpdateProduct + "?sno=" + sno, saveProduct);
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

        public async Task<bool> IsAddToCart(ViewProductDTO product, int quantity = 1)
        {
            var request = new AddToCartRequest() { ProductSno = product.Sno, Quantity = quantity };
            var response = await _swagger.PostAsync<AddToCartRequest, ApiResponse<string>>(ProductApiConst.POST_AddToShoppingCart, request);
            if (!response!.Success)
            {
                await _jsRuntime.ShowToastAsync(response.Message, SwalIcon.Error);
                return false;
            }
            return true;
        }

        public async Task<List<CartItemDTO>?> GetCartItems()
        {
            var response = await _swagger.GetAsync<ApiResponse<List<CartItemDTO>>>(ProductApiConst.GET_UserShoppingCart);
            if (!response!.Success)
            {
                await _jsRuntime.ShowToastAsync(response.Message, SwalIcon.Error);
                return null;
            }
            return response?.Data;
        }

        public async Task<List<AddressDTO>?> GetUserAddresses()
        {
            var response = await _swagger.GetAsync<ApiResponse<List<AddressDTO>>>(ProductApiConst.GET_UserAddresses);
            if (!response!.Success)
            {
                await _jsRuntime.ShowToastAsync(response.Message, SwalIcon.Error);
                return null;
            }
            return response?.Data;
        }

        public async Task SaveUserAddress(AddressDTO addressDTO)
        {
            var response = await _swagger.PostAsync<AddressDTO, ApiResponse<AddressDTO>>(ProductApiConst.POST_SaveUserAddress, addressDTO);
            if (response!.Success)
            {
                addressDTO.Sno = response!.Data!.Sno;
                await _jsRuntime.ShowToastAsync(response.Message, SwalIcon.Success);
            }
            else
            {
                await _jsRuntime.ShowToastAsync(response.Message, SwalIcon.Error);
            }
        }

        public async Task SaveProductImages(List<ImagesDTO> imagesDTO)
        {
            var response = await _swagger.PostAsync<List<ImagesDTO>, ApiResponse<List<ImagesDTO>>>(ProductApiConst.POST_SaveProductImages, imagesDTO);
        }

        public async Task PlaceOrder(PlaceOrderRequest request)
        {
            request.OrderDate = DateTime.Now;
            request.PaymentMethod = PaymentMethod.PayPal;
            request.ShippingMethod = ShippingMethod.Standard;
            var response = await _swagger.PostAsync<PlaceOrderRequest, ApiResponse<string>>(ProductApiConst.POST_PlaceOrder, request);
            if (response!.Success)
            {
                await _jsRuntime.ShowToastAsync(response.Message, SwalIcon.Success);
            }
            else
            {
                await _jsRuntime.ShowToastAsync(response.Message, SwalIcon.Error);
            }
        }

        public bool IsInShoppingCart(List<CartItemDTO> cartItems, long productSno)
        {
            return cartItems.Any(ci => ci.ProductSno == productSno);
        }
    }
}
