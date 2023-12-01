using System.Linq.Expressions;
using ASModels;
using ASModels.Astrooff;
using AstroOfficeWeb.Server.Helper;
using AstroOfficeWeb.Shared.Models;
using AstroShared;
using AstroShared.DTOs;
using AstroShared.Utilities;
using AutoMapper;
using AutoMapper.Configuration.Annotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AstroOfficeWeb.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly AstrooffContext _context;
        private readonly IMapper _mapper;

        public ProductController(AstrooffContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public IActionResult GetProducts()
        {
            var aProducts = _context.AProducts.Where(p => p.IsActive == true).OrderByDescending(p => p.Sno).ToList();
            var productDTOs = _mapper.Map<List<ViewProductDTO>>(aProducts);
            return Ok(productDTOs);
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetUserAddedProducts()
        {
            var aProducts = _context.AProducts.Where(p => p.AddedByAUsersSno == User.GetUserSno() && p.IsActive == true).ToList();
            var productDTOs = _mapper.Map<List<ViewProductDTO>>(aProducts);
            return Ok(productDTOs);
        }

        // GET api/<ProductController>/5
        [HttpGet]
        public IActionResult GetProductBySno(long sno)
        {
            var apiResponse = new ApiResponse<ProductDTO> { Data = null };

            var aProduct = _context.AProducts.Include(a => a.ProductImages).FirstOrDefault(p => p.Sno == sno && p.IsActive == true);

            if (aProduct == null)
            {
                apiResponse.ErrorNo = 1;
                apiResponse.Success = false;
                apiResponse.Message = ProductMessageConst.NotFoundProduct;
                return Ok(apiResponse);
            }

            apiResponse.Success = true;
            var productDTO = _mapper.Map<ProductDTO>(aProduct);
            apiResponse.Data = productDTO;

            return Ok(apiResponse);
        }
        [HttpGet]

        public IActionResult GetImagesByProductId(long productId)
        {
            var response = new ApiResponse<List<ImagesDTO>> { Data = null };
            try
            {
                var aProduct = _context.ProductImages.Where(p => p.ProductId == productId).ToList();
                var imagesDTOs = _mapper.Map<List<ImagesDTO>>(aProduct);
                response.Data = imagesDTOs;
            }
            catch (Exception ex)
            {
                response.ErrorNo = 1;
                response.Success = false;
                response.Message = ex.Message;

            }
            return Ok(response);
        }

        // POST api/<ProductController>
        [Authorize]
        [HttpPost]
        public IActionResult AddProduct([FromBody] SaveProductDTO productDTO)
        {
            var apiResponse = new ApiResponse<ViewProductDTO> { Data = null };
            try
            {
                AProduct aProduct = _mapper.Map<AProduct>(productDTO);
                aProduct.AddedByAUsersSno = User.GetUserSno();
                aProduct.AddedDate = DateTime.Now;
                _context.AProducts.Add(aProduct);

                _context.SaveChanges();

                apiResponse.Message = ProductMessageConst.AddProduct;
                apiResponse.Success = true;
                var viewProduct = _mapper.Map<ViewProductDTO>(aProduct);
                apiResponse.Data = viewProduct;

                if (productDTO.ProductImages != null)
                {

                    var productImages = productDTO.ProductImages.Select(a => new ProductImage
                    {
                        ImageUrl = a.ImageURL,
                        ImageName = Path.GetFileNameWithoutExtension(a.ImageName),
                        ProductId = aProduct.Sno
                    });

                    _context.ProductImages.AddRange(productImages);
                    _context.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                apiResponse.Success = false;
                apiResponse.Message = ex.Message;
            }
            return Ok(apiResponse);
        }

        // PUT api/<ProductController>/5
        [Authorize]
        [HttpPut]
        public IActionResult UpdateProduct(long sno, [FromBody] SaveProductDTO productDTO)
        {
            var apiResponse = new ApiResponse<ViewProductDTO> { Data = null };
            try
            {
                if (_context.AProducts.FirstOrDefault(ap => ap.Sno == sno && ap.IsActive == true) is AProduct existedProduct)
                {
                    _context.Entry(existedProduct).State = EntityState.Detached;

                    AProduct aProduct = _mapper.Map<AProduct>(productDTO);
                    aProduct.Sno = sno;
                    aProduct.AddedByAUsersSno = existedProduct.AddedByAUsersSno;
                    aProduct.AddedDate = existedProduct.AddedDate;
                    aProduct.ModifiedByAUsersSno = User.GetUserSno();
                    aProduct.LastModifiedDate = DateTime.Now;
                    //aProduct.IsActive = true;

                    _context.AProducts.Update(aProduct);
                    _context.SaveChanges();

                    apiResponse.Message = ProductMessageConst.UpdateProduct;
                    apiResponse.Success = true;


                    var viewProduct = _mapper.Map<ViewProductDTO>(aProduct);



                    if (productDTO.ProductImages != null)
                    {

                        var existsImages = _context.ProductImages.Where(p => p.ProductId == aProduct.Sno).ToList();

                        var doNotingImageSnos = productDTO.ProductImages.Where(pi => pi.Sno != 0).Select(pi => pi.Sno).ToList();

                        var imagesNeedToDelete = existsImages.Where(ei => !doNotingImageSnos.Contains(ei.Sno));

                        var imagesNeedToAdd = productDTO.ProductImages.Where(pi => !doNotingImageSnos.Contains(pi.Sno)).Select(pi => new ProductImage
                        {
                            ImageUrl = pi.ImageURL,
                            ImageName = Path.GetFileNameWithoutExtension(pi.ImageName),
                            ProductId = aProduct.Sno
                        });

                        _context.ProductImages.RemoveRange(imagesNeedToDelete);

                        if (imagesNeedToAdd.Any())
                        {
                            foreach (var pi in imagesNeedToAdd)
                            {
                                _context.Add(pi);
                                _context.SaveChanges();

                                var imagesDTO = _mapper.Map<ImagesDTO>(pi);
                                viewProduct?.ProductImages?.Add(imagesDTO);
                            }

                        }
                        _context.SaveChanges();
                    }
                    apiResponse.Data = viewProduct;
                }
                else
                {
                    apiResponse.ErrorNo = 1;
                    apiResponse.Success = false;
                    apiResponse.Message = ProductMessageConst.NotFoundProduct;
                    return Ok(apiResponse);
                }
            }
            catch (Exception ex)
            {
                apiResponse.ErrorNo = 2;
                apiResponse.Success = false;
                apiResponse.Message = ex.Message;
            }

            return Ok(apiResponse);
        }

        // DELETE api/<ProductController>/5
        [Authorize]
        [HttpDelete]
        public IActionResult DeleteProduct(long sno)
        {
            var apiResponse = new ApiResponse<ViewProductDTO> { Data = null };
            try
            {
                var existedProduct = _context.AProducts.FirstOrDefault(a => a.Sno == sno && a.IsActive == true);

                if (existedProduct == null)
                {
                    apiResponse.ErrorNo = 1;
                    apiResponse.Success = false;
                    apiResponse.Message = ProductMessageConst.NotFoundProduct;
                    return Ok(apiResponse);
                }

                existedProduct.IsActive = false;
                existedProduct.ModifiedByAUsersSno = User.GetUserSno();

                _context.AProducts.Update(existedProduct);
                _context.SaveChanges();

                apiResponse.Message = ProductMessageConst.DeleteProduct;
                apiResponse.Success = true;
                var viewProduct = _mapper.Map<ViewProductDTO>(existedProduct);
                apiResponse.Data = viewProduct;
            }
            catch (Exception ex)
            {
                apiResponse.Success = false;
                apiResponse.Message = ex.Message;
            }
            return Ok(apiResponse);
        }

        [Authorize(Roles = "User")]
        [HttpPost]
        public IActionResult AddToShoppingCart(AddToCartRequest request)
        {
            var response = new ApiResponse<string>();
            var shoppingCart = _context.ShoppingCarts.FirstOrDefault(a => a.AUsersSno == User.GetUserSno());

            if (shoppingCart == null)
            {
                shoppingCart = new ShoppingCart() { AUsersSno = User.GetUserSno() };
                _context.ShoppingCarts.Add(shoppingCart);
                _context.SaveChanges();
            }

            var cartItem = _context.CartItems.FirstOrDefault(ci => ci.ShoppingCartsSno == shoppingCart.Sno && ci.AProductsSno == request.ProductSno);

            if (cartItem == null)
            {
                cartItem = new CartItem() { AProductsSno = request.ProductSno, Quantity = request.Quantity, ShoppingCartsSno = shoppingCart?.Sno, };
                _context.CartItems.Add(cartItem);
            }
            else
            {
                cartItem.Quantity += request.Quantity;
            }

            _context.SaveChanges();

            response.Data = "Product added to your cart.";
            return Ok(response);
        }

        [Authorize(Roles = "User")]
        [HttpGet]
        public IActionResult GetUserShoppingCart()
        {
            var response = new ApiResponse<List<CartItemDTO>>();
            var shoppingCart = _context.ShoppingCarts.Include(sc => sc.CartItems).ThenInclude(sc => sc.AProductsSnoNavigation).FirstOrDefault(a => a.AUsersSno == User.GetUserSno());

            var cartItems = shoppingCart?.CartItems.Select(ci => new CartItemDTO
            {
                ProductSno = ci.AProductsSno ?? 0,
                ProductName = ci.AProductsSnoNavigation?.Name ?? "",
                ProductQuantity = ci.Quantity ?? 0,
                ProductImageSrc = ci.AProductsSnoNavigation?.ImageUrl,
                ProductPrice = ci.AProductsSnoNavigation?.Price ?? 0
            }).ToList();

            response.Data = cartItems;
            return Ok(response);
        }

        [Authorize(Roles = "User")]
        [HttpGet]
        public IActionResult GetUserAddresses()
        {
            var response = new ApiResponse<List<AddressDTO>>();
            var addresses = _context.Addresses.Include(sc => sc.ACountrySnoNavigation).Where(a => a.AUsersSno == User.GetUserSno() && a.IsActive == true).OrderBy(a => a.Sno);
            response.Data = _mapper.Map<List<AddressDTO>>(addresses);
            return Ok(response);
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetUserAddress()
        {
            var response = new ApiResponse<List<AddressDTO>>();
            var addresses = _context.Addresses.Include(sc => sc.ACountrySnoNavigation).FirstOrDefault(a => a.AUsersSno == User.GetUserSno() && a.IsActive == true);
            response.Data = _mapper.Map<List<AddressDTO>>(addresses);
            return Ok(response);
        }

        [Authorize(Roles = "User")]
        [HttpPost]
        public IActionResult SaveUserAddress(AddressDTO addressDTO)
        {
            var response = new ApiResponse<AddressDTO>();
            var existingAddress = _context.Addresses.FirstOrDefault(a => a.Sno == addressDTO.Sno && a.AUsersSno == User.GetUserSno() && a.IsActive == true);

            if (existingAddress == null)
            {
                var address = _mapper.Map<Address>(addressDTO);
                address.AUsersSno = User.GetUserSno();

                _context.Addresses.Add(address);
                _context.SaveChanges();

                addressDTO.Sno = address.Sno;

                response.Data = addressDTO;
                response.Message = "Address saved to user account";
            }
            else
            {
                // Update the existing entity with data from addressDTO
                _mapper.Map(addressDTO, existingAddress);

                // Make sure to set any additional properties that should not be updated
                existingAddress.AUsersSno = User.GetUserSno();

                // No need to attach or update, the context is already tracking the entity
                _context.SaveChanges();

                response.Data = addressDTO;
                response.Message = "Address updated in user account";
            }

            return Ok(response);
        }

        [Authorize(Roles = "User")]
        [HttpPost]
        public IActionResult PlaceOrder(PlaceOrderRequest request)
        {

            var response = new ApiResponse<string>();
            var placeOrder = new ProductOrder();

            placeOrder.OrderDate = request.OrderDate;
            placeOrder.PaymentMethod = request.PaymentMethod.ToString();
            placeOrder.ShippingAddressSno = request.ShippingAddressSno;
            placeOrder.ShipToDifferentAddress = request.ShipToDifferentAddress;
            placeOrder.OrderNotes = request.OrderNotes;
            placeOrder.ShippingMethod = request.ShippingMethod.ToString();

            using (IDbContextTransaction transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.ProductOrders.Add(placeOrder);
                    _context.SaveChanges();

                    var shoppingCart = _context.ShoppingCarts.Include(sc => sc.CartItems).ThenInclude(sc => sc.AProductsSnoNavigation).FirstOrDefault(sc => sc.AUsersSno == User.GetUserSno());

                    if (shoppingCart != null)
                    {
                        var orderItems = shoppingCart.CartItems.Select(ci => new OrderItem
                        {
                            Sno = ci.Sno,
                            Quantity = ci.Quantity,
                            AProductsSno = ci.AProductsSno,
                            ProductOrdersSno = placeOrder.Sno,
                        }).ToList();


                        if (request.ShippingMethod == ShippingMethod.Express)
                        {
                            var totalPlusExpress = shoppingCart.CartItems.Sum(ci => ci.Quantity * ci.AProductsSnoNavigation!.Price);
                            var orderSummary = new CalculateOrderSummary(totalPlusExpress ?? 0);
                            placeOrder.TotalAmount = orderSummary.Total + 50;
                        }

                        _context.CartItems.RemoveRange(shoppingCart.CartItems);

                        _context.SaveChanges();

                        _context.AddRange(orderItems);

                        _context.SaveChanges();
                    }

                    transaction.Commit();

                    response.Message = "Order Success Fully";
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    response.ErrorNo = 1;
                    response.Success = false;
                    response.Message = ex.Message;
                }
            }

            return Ok(response);
        }

    }
}
