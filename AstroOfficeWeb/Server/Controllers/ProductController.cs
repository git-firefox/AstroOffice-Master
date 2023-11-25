using System.Linq.Expressions;
using ASModels;
using ASModels.Astrooff;
using AstroOfficeWeb.Server.Helper;
using AstroOfficeWeb.Shared.Models;
using AstroShared.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            var apiResponse = new ApiResponse<ViewProductDTO> { Data = null };

            var aProduct = _context.AProducts.FirstOrDefault(p => p.Sno == sno && p.IsActive == true);

            if (aProduct == null)
            {
                apiResponse.ErrorNo = 1;
                apiResponse.Success = false;
                apiResponse.ErrorMessage = ProductMessageConst.NotFoundProduct;
                return Ok(apiResponse);
            }

            apiResponse.Success = true;
            var productDTO = _mapper.Map<ViewProductDTO>(aProduct);
            apiResponse.Data = productDTO;

            return Ok(apiResponse);
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

                apiResponse.ErrorMessage = ProductMessageConst.AddProduct;
                apiResponse.Success = true;
                var viewProduct = _mapper.Map<ViewProductDTO>(aProduct);
                apiResponse.Data = viewProduct;
            }
            catch (Exception ex)
            {
                apiResponse.Success = false;
                apiResponse.ErrorMessage = ex.Message;
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

                    apiResponse.ErrorMessage = ProductMessageConst.UpdateProduct;
                    apiResponse.Success = true;

                    var viewProduct = _mapper.Map<ViewProductDTO>(aProduct);

                    apiResponse.Data = viewProduct;
                }
                else
                {
                    apiResponse.ErrorNo = 1;
                    apiResponse.Success = false;
                    apiResponse.ErrorMessage = ProductMessageConst.NotFoundProduct;
                    return Ok(apiResponse);
                }
            }
            catch (Exception ex)
            {
                apiResponse.ErrorNo = 2;
                apiResponse.Success = false;
                apiResponse.ErrorMessage = ex.Message;
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
                    apiResponse.ErrorMessage = ProductMessageConst.NotFoundProduct;
                    return Ok(apiResponse);
                }

                existedProduct.IsActive = false;
                existedProduct.ModifiedByAUsersSno = User.GetUserSno();

                _context.AProducts.Update(existedProduct);
                _context.SaveChanges();

                apiResponse.ErrorMessage = ProductMessageConst.DeleteProduct;
                apiResponse.Success = true;
                var viewProduct = _mapper.Map<ViewProductDTO>(existedProduct);
                apiResponse.Data = viewProduct;
            }
            catch (Exception ex)
            {
                apiResponse.Success = false;
                apiResponse.ErrorMessage = ex.Message;
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
            var cartItems = shoppingCart?.CartItems.Select(ci => new CartItemDTO { ProductSno = ci.AProductsSno ?? 0, ProductName = ci.AProductsSnoNavigation?.Name ?? "", ProductQuantity = ci.Quantity ?? 0 }).ToList();
            response.Data = cartItems;
            return Ok(response);
        }
    }
}
