using AstroOfficeWeb.Services.IServices;
using AstroOfficeWeb.Shared.ComponentModels;
using AstroOfficeWeb.Shared.DTOs;
using AstroOfficeWeb.Shared.Helper;
using AstroOfficeWeb.Shared.Models;
using AstroOfficeWeb.Shared.Utilities;
using Microsoft.AspNetCore.Components;
//using Stripe;
using System.Collections.Generic;

namespace AstroOfficeWeb.Services
{
    public class ProductService
    {
        private readonly ISwaggerApiService _swagger;
        private readonly ISnackbarService? _snackbar;
        private readonly NavigationManager _navigation;

        public ProductService(ISwaggerApiService swagger, NavigationManager navigation, ISnackbarService? snackbar = null)
        {
            _swagger = swagger;
            _snackbar = snackbar;
            _navigation = navigation;
        }


        public async Task<(BaseProductDTO? GeneralInformation, List<MediaFileDTO>? ProductMediaFiles, List<MetaDataDTO>? ProductMetaDatas)> InitialiseProductBySno(long sno)
        {
            var queryParams = new Dictionary<string, string>()
            {
                { "Sno", sno.ToString()}
            };

            var response = await _swagger.GetAsync<GetProductResponse>(ProductApiConst.GET_ProductBySno, queryParams);
            return (response?.GeneralInformation, response?.ProductMediaFiles, response?.ProductMetaDatas);
        }

        public async Task<List<ViewProductDTO>?> GetProducts(long? categorySno = null)
        {
            List<ViewProductDTO>? products = null;

            if (categorySno != null)
            {
                var queryParams = new Dictionary<string, string>()
                {
                    { "categorySno", categorySno!.ToStringX()}
                };

                products = await _swagger.GetAsync<List<ViewProductDTO>>(ProductApiConst.GET_Products, queryParams);
            }
            else
            {

                products = await _swagger.GetAsync<List<ViewProductDTO>>(ProductApiConst.GET_Products);
            }
            return products;
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
            }; var response = await _swagger.GetAsync<ApiResponse<List<ImagesDTO>>>(ProductApiConst.GET_ProductImages, queryParams);
            if (!response!.Success)
            {
                _snackbar?.ShowErrorSnackbar(response.Message);
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
                _snackbar?.ShowSuccessSnackbar(response.Message);
                _navigation.NavigateTo("/manage-products");
            }
            else
            {
                _snackbar?.ShowErrorSnackbar(response.Message);
            }
        }

        public async Task SaveProductImages(ProductDTO req, List<MediaFile> saveProduct)
        {
            var response = await _swagger.PostWithMultipartFormDataContentAsync<ProductDTO, ApiResponse<string>>(FileApiConst.POST_SaveProductImages, req, saveProduct);
            if (response!.Success)
            {
                _snackbar?.ShowSuccessSnackbar(response.Message);
            }
            else
            {
                _snackbar?.ShowErrorSnackbar(response.Message);
            }
        }


        public async Task UpdateProduct(ProductDTO saveProduct, long sno)
        {
            var response = await _swagger.PutAsync<ProductDTO, ApiResponse<ViewProductDTO>>(ProductApiConst.PUT_UpdateProduct + "?sno=" + sno, saveProduct);
            if (response!.Success)
            {
                _snackbar?.ShowSuccessSnackbar(response.Message);
                _navigation.NavigateTo("/manage-products");
            }
            else
            {
                _snackbar?.ShowErrorSnackbar(response.Message);
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
                _snackbar?.ShowSuccessSnackbar(response.Message);
                return true;
            }
            else
            {
                _snackbar?.ShowErrorSnackbar(response.Message);
                return false;
            }
        }

        public async Task<bool> IsDeletedSelectedCategory(long sno)
        {
            var queryParams = new Dictionary<string, string>()
            {
                { "sno", sno.ToString() }
            };
            var response = await _swagger.DeleteAsync<ApiResponse<CategoryDTO>>(ProductApiConst.DELETE_Category, queryParams);
            if (response!.Success)
            {
                _snackbar?.ShowSuccessSnackbar(response.Message);
                return true;
            }
            else
            {
                _snackbar?.ShowErrorSnackbar(response.Message);
                return false;
            }
        }


        public async Task<bool> IsAddToCart(long productSno, int quantity = 1)
        {
            var request = new AddToCartRequest() { ProductSno = productSno, Quantity = quantity };
            var response = await _swagger.PostAsync<AddToCartRequest, ApiResponse<string>>(ProductApiConst.POST_AddToShoppingCart, request);
            if (!response!.Success)
            {
                _snackbar?.ShowErrorSnackbar(response.Message);
                return false;
            }
            return true;
        }

        public async Task<List<CartItemDTO>?> GetCartItems()
        {
            var response = await _swagger.GetAsync<ApiResponse<List<CartItemDTO>>>(ProductApiConst.GET_UserShoppingCart);
            if (!response!.Success)
            {
                _snackbar?.ShowErrorSnackbar(response.Message);
                return null;
            }
            return response?.Data;
        }

        public async Task<bool> UpdateShoppingCart(List<CartItemDTO>? cartItemDTOs)
        {
            var response = await _swagger.PutAsync<List<CartItemDTO>, ApiResponse<string>>(ProductApiConst.PUT_UpdateShoppingCart, cartItemDTOs!);
            if (!response!.Success)
            {
                _snackbar?.ShowErrorSnackbar(response.Message);
                return false;
            }
            return response!.Success;
        }


        public async Task<List<AddressDTO>?> GetUserAddresses()
        {
            var response = await _swagger.GetAsync<ApiResponse<List<AddressDTO>>>(ProductApiConst.GET_UserAddresses);
            if (!response!.Success)
            {
                _snackbar?.ShowErrorSnackbar(response.Message);
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
                _snackbar?.ShowSuccessSnackbar(response.Message);
            }
            else
            {
                _snackbar?.ShowErrorSnackbar(response.Message);
            }
        }

        public async Task<bool> IsDeletedSelectdAddress(long addressSno)
        {
            var response = await _swagger.DeleteAsync<ApiResponse<string>>(ProductApiConst.DELETE_UserAddress, new Dictionary<string, string> { { "addressSno", addressSno.ToString() } });
            if (response!.Success)
            {
                return true;
            }
            _snackbar?.ShowErrorSnackbar(response.Message);
            return false;
        }

        public async Task SaveAndUpdateCategory(CategoryListItem categoryDTO)
        {
            var response = await _swagger.PostAsync<CategoryDTO, ApiResponse<CategoryDTO>>(ProductApiConst.POST_SaveAndUpdateCategory, categoryDTO);
            if (response!.Success)
            {
                categoryDTO.AddedDate = response!.Data!.AddedDate;
                categoryDTO.LastModifiedDate = response!.Data!.LastModifiedDate;
                categoryDTO.Sno = response!.Data!.Sno;
                _snackbar?.ShowSuccessSnackbar(response.Message);
            }
            else
            {
                _snackbar?.ShowErrorSnackbar(response.Message);
            }
        }

        public async Task SaveProductImages(List<ImagesDTO> imagesDTO)
        {
            var response = await _swagger.PostAsync<List<ImagesDTO>, ApiResponse<List<ImagesDTO>>>(ProductApiConst.POST_SaveProductImages, imagesDTO);
        }

        public async Task PlaceOrder(PlaceOrderRequest request)
        {
            request.OrderDate = DateTime.Now;
            //request.PaymentMethod = AstroShared.PaymentMethod.PayPal;
            request.ShippingMethod = ShippingMethod.Standard;
            var response = await _swagger.PostAsync<PlaceOrderRequest, ApiResponse<string>>(ProductApiConst.POST_PlaceOrder, request);
            if (response!.Success)
            {
                _snackbar?.ShowSuccessSnackbar(response.Message);
                _navigation.NavigateTo("/order-success", true, true);
            }
            else
            {
                _snackbar?.ShowErrorSnackbar(response.Message);
            }
        }

        public async Task<GetOrderResponse?> GetUserOrder(long orderSno)
        {
            var response = await _swagger.GetAsync<GetOrderResponse>(ProductApiConst.GET_UserOrder, new Dictionary<string, string> { { "orderSno", orderSno.ToStringX() } });
            if (!response!.Success)
            {
                _snackbar?.ShowErrorSnackbar(response.Message);
                return default;
            }
            return (response);
        }
        public async Task<List<OrderDTO>?> GetUserOrders()
        {
            var response = await _swagger.GetAsync<ApiResponse<List<OrderDTO>>>(ProductApiConst.GET_UserOrders);

            if (!response!.Success)
            {
                _snackbar?.ShowErrorSnackbar(response.Message);
                return null;
            }
            return response.Data;
        }

        public async Task<List<CategoryListItem>?> GetCategories()
        {
            var response = await _swagger.GetAsync<ApiResponse<List<CategoryListItem>>>(ProductApiConst.GET_Categories);
            if (!response!.Success)
            {
                _snackbar?.ShowErrorSnackbar(response.Message);
                return null;
            }
            return response.Data;
        }

        public async Task<List<PCategoryDTO>?> GetShopCategories()
        {
            var response = await _swagger.GetAsync<ApiResponse<List<PCategoryDTO>>>(ProductApiConst.GET_ShopCategories);
            if (!response!.Success)
            {
                _snackbar?.ShowErrorSnackbar(response.Message);
                return null;
            }
            return response.Data;
        }

        public async Task<List<OrderDTO>?> GetOrders()
        {
            var response = await _swagger.GetAsync<ApiResponse<List<OrderDTO>>>(ProductApiConst.GET_Orders);

            if (!response!.Success)
            {
                _snackbar?.ShowErrorSnackbar(response.Message);
                return null;
            }
            return response.Data;
        }

        public async Task<List<ViewProductDTO>?> GetUserWishList()
        {
            var response = await _swagger.GetAsync<ApiResponse<List<ViewProductDTO>>>(ProductApiConst.GET_UserWishList);

            if (!response!.Success)
            {
                _snackbar?.ShowErrorSnackbar(response.Message);
                return null;
            }
            return response.Data;
        }
        public async Task<bool> IsDeletedFromWishList(long productSno)
        {
            var response = await _swagger.DeleteAsync<ApiResponse<string>>(ProductApiConst.DELETE_FromWishList, new Dictionary<string, string> { { "productSno", productSno.ToStringX() } });

            if (!response!.Success)
            {
                _snackbar?.ShowErrorSnackbar(response.Message);
                return false;
            }
            return response.Success;
        }

        public async Task AddToWishList(long productSno)
        {
            var response = await _swagger.PutAsync<AddToWishlistRequest, ApiResponse<string>>(ProductApiConst.PUT_AddToWishList, new AddToWishlistRequest { ProductSno = productSno });

            if (!response!.Success)
            {
                _snackbar?.ShowErrorSnackbar(response.Message);
            }
            else
            {
                _snackbar?.ShowSuccessSnackbar(response.Message);
            }
        }

        public async Task CreateCheckoutSession()
        {
            var response = await _swagger.PostAsync<object, ApiResponse<string>>(ProductApiConst.POST_CreateCheckoutSession, new { Success = "Test" });

            if (!response!.Success)
            {
                _snackbar?.ShowErrorSnackbar(response.Message);
            }
            else
            {
                _navigation.NavigateTo(response!.Data!);
            }
        }


        public bool IsInShoppingCart(List<CartItemDTO> cartItems, long productSno)
        {
            return cartItems.Any(ci => ci.ProductSno == productSno);
        }
    }
}
