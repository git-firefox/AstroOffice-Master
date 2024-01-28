using System.Linq;
using System.Linq.Expressions;
using ASModels;
using ASModels.Astrooff;
using AstroOfficeWeb.Server.Helper;
using AstroOfficeWeb.Server.Services.IServices;
using AstroOfficeWeb.Shared.DTOs;
using AstroOfficeWeb.Shared.Models;
using AstroOfficeWeb.Shared.Utilities;
using AutoMapper;
using AutoMapper.Configuration.Annotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Stripe.Checkout;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AstroOfficeWeb.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly AstrooffContext _context;
        private readonly IMapper _mapper;
        private readonly IStripePaymentService _stripePayment;

        public ProductController(AstrooffContext context, IMapper mapper, IStripePaymentService stripePayment)
        {
            _context = context;
            _mapper = mapper;
            _stripePayment = stripePayment;
        }

        // GET: api/<ProductController>
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetProducts(long? categorySno = null)
        {
            var shoppingCart = await _context.ShoppingCarts.Include(i => i.CartItems).FirstOrDefaultAsync(a => a.AUsersSno == User.GetUserSno());
            var cartItems = shoppingCart?.CartItems.ToList();


            List<AProduct>? aProducts = null;
            if (categorySno != null)
            {
                aProducts = _context.AProducts.Include(a => a.ProductCategoriesSnoNavigation).Where(p => p.ProductCategoriesSno == categorySno && p.IsActive == true).OrderByDescending(p => p.Sno).ToList();

            }
            else
            {
                aProducts = _context.AProducts.Include(a => a.ProductCategoriesSnoNavigation).Where(p => p.IsActive == true).OrderByDescending(p => p.Sno).ToList();
            }

            var productDTOs = _mapper.Map<List<ViewProductDTO>>(aProducts);

            productDTOs.ForEach(pd =>
            {
                pd.ProductQuantity = cartItems?.FirstOrDefault(ci => ci.AProductsSno == pd.Sno)?.Quantity ?? 0;
            });

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
        public async Task<IActionResult> GetProductBySno(long sno)
        {
            var apiResponse = new GetProductResponse();

            var aProduct = await _context.AProducts.Include(a => a.AProductMediaFiles).Include(a => a.ProductMetaData).Include(a => a.ProductCategoriesSnoNavigation).FirstOrDefaultAsync(p => p.Sno == sno && p.IsActive == true);

            var shoppingCart = await _context.ShoppingCarts.Include(i => i.CartItems).FirstOrDefaultAsync(a => a.AUsersSno == User.GetUserSno());
            var cartItems = shoppingCart?.CartItems.ToList();

            if (aProduct == null)
            {
                apiResponse.ErrorNo = 1;
                apiResponse.Success = false;
                apiResponse.Message = ProductMessageConst.NotFoundProduct;
                return Ok(apiResponse);
            }

            apiResponse.Success = true;

            var productDTO = _mapper.Map<BaseProductDTO>(aProduct);
            var imagesDTOs = _mapper.Map<List<MediaFileDTO>>(aProduct.AProductMediaFiles);
            var metaDataDTOs = _mapper.Map<List<MetaDataDTO>>(aProduct.ProductMetaData);


            apiResponse.GeneralInformation = productDTO;
            apiResponse.ProductMediaFiles = imagesDTOs;
            apiResponse.ProductMetaDatas = metaDataDTOs;


            productDTO.ProductCategory = aProduct.ProductCategoriesSnoNavigation?.Title ?? string.Empty;
            productDTO.ProductQuantity = cartItems?.FirstOrDefault(ci => ci.AProductsSno == aProduct.Sno)?.Quantity ?? 0;

            return Ok(apiResponse);
        }

        [HttpGet]
        public IActionResult GetCategories()
        {
            //var apiResponse = new ApiResponse<string> { Data = null };

            var apiResponse = new ApiResponse<List<CategoryDTO>> { Data = null };
            var categories = _context.ProductCategories.Include(i => i.AProducts).ToList();
            var categoryDTO = _mapper.Map<List<CategoryDTO>>(categories);

            foreach (var category in categoryDTO)
            {
                category.TotalProducts = categories.First(c => c.Sno == category.Sno).AProducts.Count;
            }

            apiResponse.Data = categoryDTO;
            return Ok(apiResponse);
        }

        [HttpGet]
        public IActionResult GetShopCategories()
        {

            List<PCategoryDTO> tmp = new List<PCategoryDTO>();
            //var apiResponse = new ApiResponse<string> { Data = null };

            var apiResponse = new ApiResponse<List<PCategoryDTO>> { Data = null };
            var categories = _context.ProductCategories.Include(i => i.AProducts).Where(i => i.AProducts.Count != 0).ToList();

            var pCategories = categories.Where(p => p.ParentCategorySno == null).Select(p => new PCategoryDTO()
            {
                Sno = p.Sno,
                Descriptions = p.Descriptions,
                ImageUrl = p.ImageUrl,
                Title = p.Title,
            });

            tmp.AddRange(pCategories);


            var parentCategorySnos = categories.Select(a => a.ParentCategorySno);
            var parentCategories = _context.ProductCategories.Where(a => parentCategorySnos.Contains(a.Sno)).Select(p => new PCategoryDTO()
            {
                Sno = p.Sno,
                Descriptions = p.Descriptions,
                ImageUrl = p.ImageUrl,
                Title = p.Title,
            }).ToList();

            var t2 = pCategories.Intersect(parentCategories);
            tmp.AddRange(t2);

            foreach (var subInit in tmp)
            {
                subInit.SubCategories = categories.Where(a => subInit.Sno == a.ParentCategorySno).Select(a => new SCategoryDTO()
                {
                    Descriptions = a.Descriptions,
                    Sno = a.Sno,
                    Title = a.Title
                }).ToList();
            }


            apiResponse.Data = tmp;
            return Ok(apiResponse);
        }

        [HttpGet]

        public IActionResult GetImagesByProductId(long productId)
        {
            var response = new ApiResponse<List<ImagesDTO>> { Data = null };
            try
            {
                var aProduct = _context.AProductMediaFiles.Where(p => p.AProductsSno == productId).ToList();
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

        private void UploadFileToServer(IFormFileCollection files, AProduct existedProduct)
        {

            if (files != null)
            {


                if (files.Any())
                {
                    var mediaFiles = new List<AProductMediaFile>();
                    //var test = Request.Form.Files;
                    var countOrder = existedProduct.AProductMediaFiles.Count;
                    var mediaPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "media");

                    foreach (var file in files)
                    {

                        var guid = Guid.NewGuid();
                        var extension = Path.GetExtension(file.FileName.ToLower());
                        var temp = extension.Split('|');
                        extension = temp[0];

                        var filePath = Path.Combine(mediaPath, guid + extension);
                        using var stream = new FileStream(filePath, FileMode.Create);
                        file.CopyTo(stream);

                        var aProductMediaFile = new AProductMediaFile
                        {
                            MediaName = Path.GetFileNameWithoutExtension(file.FileName),
                            MediaUrl = guid.ToString(),
                            AProductsSno = existedProduct.Sno,
                            MediaType = extension[1..].ToUpper(),
                        };

                        if (temp.Length == 2)
                        {

                            if (temp[1].Equals("is-primary"))
                            {
                                aProductMediaFile.IsPrimary = true;
                                aProductMediaFile.IsSecondary = false;

                            }
                            else if (temp[1].Equals("is-secondary"))
                            {
                                aProductMediaFile.IsPrimary = false;
                                aProductMediaFile.IsSecondary = true;
                            }
                        }
                        else if (temp.Length == 3)
                        {
                            aProductMediaFile.IsPrimary = true;
                            aProductMediaFile.IsSecondary = true;
                        }
                        else
                        {
                            aProductMediaFile.IsPrimary = false;
                            aProductMediaFile.IsSecondary = false;
                        }
                        mediaFiles.Add(aProductMediaFile);
                    }

                    _context.AProductMediaFiles.AddRange(mediaFiles);
                    _context.SaveChanges();
                }


            }
            //}

        }

        // POST api/<ProductController>
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddProduct([FromForm] MultipartFormRequest<SaveProductRequest> request)
        {
            var apiResponse = new ApiResponse<string> { Data = null };
            try
            {
                AProduct aProduct = _mapper.Map<AProduct>(request.DataObject!.GeneralInformation);
                aProduct.AddedByAUsersSno = User.GetUserSno();
                aProduct.AddedDate = DateTime.Now;
                await _context.AProducts.AddAsync(aProduct, CancellationToken.None);
                await _context.SaveChangesAsync(CancellationToken.None);

                UploadFileToServer(request.Files, aProduct);

                if (request.DataObject.ProductMetaDatas.Any())
                {
                    var metaDataNeedToAdd = request.DataObject.ProductMetaDatas.Select(pi => new ProductMetaData
                    {
                        MetaKeyword = pi.MetaKeyword,
                        MetaValue = pi.MetaValue,
                        AProductsSno = aProduct.Sno
                    });
                    await _context.ProductMetaDatas.AddRangeAsync(metaDataNeedToAdd);
                }
                await _context.SaveChangesAsync(CancellationToken.None);

                apiResponse.Message = ProductMessageConst.AddProduct;
                apiResponse.Success = true;
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
        public IActionResult UpdateProduct([FromQuery] long sno, [FromForm] MultipartFormRequest<SaveProductRequest> request)
        {
            var apiResponse = new ApiResponse<string> { Data = null };
            try
            {
                var productInfo = request.DataObject!;
                if (_context.AProducts.Include(a => a.AProductMediaFiles).FirstOrDefault(ap => ap.Sno == sno && ap.IsActive == true) is AProduct existedProduct)
                {
                    _context.Entry(existedProduct).State = EntityState.Detached;

                    AProduct aProduct = _mapper.Map<AProduct>(productInfo.GeneralInformation);
                    aProduct.Sno = sno;
                    aProduct.AddedByAUsersSno = existedProduct.AddedByAUsersSno;
                    aProduct.AddedDate = existedProduct.AddedDate;
                    aProduct.ModifiedByAUsersSno = User.GetUserSno();

                    aProduct.LastModifiedDate = DateTime.Now;


                    //aProduct.IsActive = true;c
                    if (productInfo.ProductMediaFiles.Any())
                    {

                        var existsImages = existedProduct.AProductMediaFiles.Where(p => p.AProductsSno == aProduct.Sno).ToList();

                        var doNotingImageSnos = productInfo.ProductMediaFiles.Where(pi => pi.Sno != 0).Select(pi => pi.Sno).ToList();

                        var needToUpdateImage = productInfo.ProductMediaFiles.Where(pi => pi.Sno != 0).ToList();


                        var imagesNeedToDelete = existsImages.Where(ei => !doNotingImageSnos.Contains(ei.Sno));

                        if (imagesNeedToDelete.Any())
                        {
                            var mediaPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "media");
                            string? filePath = null;
                            foreach (var image in imagesNeedToDelete)
                            {
                                filePath = Path.Combine(mediaPath, image.MediaUrl + "." + image.MediaType);
                                if (System.IO.File.Exists(filePath))
                                {
                                    System.IO.File.Delete(filePath);
                                }
                                _context.AProductMediaFiles.Remove(image);
                                filePath = null;
                            }
                        }

                        foreach (var updateImage in needToUpdateImage)
                        {
                            existsImages.First(pi => pi.Sno == updateImage.Sno).IsPrimary = updateImage.IsPrimary;
                            existsImages.First(pi => pi.Sno == updateImage.Sno).IsSecondary = updateImage.IsSecondary;
                        }

                        UploadFileToServer(request.Files, existedProduct);
                    }


                    var existMetaData = _context.ProductMetaDatas.Where(p => p.AProductsSno == aProduct.Sno).ToList();

                    var doNothingMetaDataSnos = productInfo.ProductMetaDatas.Where(p => p.Sno != 0).Select(pi => pi.Sno).ToList();

                    var metaDataNeedToDelete = existMetaData.Where(p => !doNothingMetaDataSnos.Contains(p.Sno));

                    var metaDataNeedToUpdate = existMetaData.Where(p => doNothingMetaDataSnos.Contains(p.Sno));

                    var metaDataNeedToAdd = productInfo.ProductMetaDatas.Where(pi => !doNothingMetaDataSnos.Contains(pi.Sno)).Select(pi => new ProductMetaData
                    {
                        MetaKeyword = pi.MetaKeyword,
                        MetaValue = pi.MetaValue,
                        AProductsSno = aProduct.Sno
                    });

                    if (metaDataNeedToUpdate.Any())
                    {
                        var newMetaDatas = productInfo.ProductMetaDatas.Where(pi => doNothingMetaDataSnos.Contains(pi.Sno));

                        var joinData = metaDataNeedToUpdate.Join(newMetaDatas,
                            metaData => metaData.Sno,
                            metaDataDto => metaDataDto.Sno,
                            (metaData, metaDataDto) => new { OldMetaData = metaData, NewMetaDataDTO = metaDataDto });


                        foreach (var tempData in joinData)
                        {
                            tempData.OldMetaData.MetaKeyword = tempData.NewMetaDataDTO.MetaKeyword;
                            tempData.OldMetaData.MetaValue = tempData.NewMetaDataDTO.MetaValue;
                            _context.ProductMetaDatas.Update(tempData.OldMetaData);
                            _context.SaveChanges();
                        }
                    }

                    if (metaDataNeedToAdd.Any())
                        _context.AddRange(metaDataNeedToAdd);

                    if (metaDataNeedToDelete.Any())
                        _context.ProductMetaDatas.RemoveRange(metaDataNeedToDelete);

                    _context.AProducts.Update(aProduct);
                    _context.SaveChanges();

                    apiResponse.Message = ProductMessageConst.UpdateProduct;
                    apiResponse.Success = true;
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
                _mapper.Map(addressDTO, existingAddress);
                existingAddress.AUsersSno = User.GetUserSno();

                _context.SaveChanges();

                response.Data = addressDTO;
                response.Message = "Address updated in user account";
            }

            return Ok(response);
        }


        [HttpPost]
        public IActionResult SaveAndUpdateCategory(CategoryDTO categoryDTO)
        {
            var response = new ApiResponse<CategoryDTO>();
            var existingCategory = _context.ProductCategories.FirstOrDefault(a => a.Sno == categoryDTO.Sno);
            if (existingCategory == null)
            {
                categoryDTO.AddedDate = DateTime.Now;
                categoryDTO.AddedByAUsersSno = User.GetUserSno();
                var category = _mapper.Map<ProductCategory>(categoryDTO);
                _context.ProductCategories.Add(category);
                _context.SaveChanges();
                categoryDTO.Sno = category.Sno;
                response.Data = categoryDTO;
                response.Message = "Category has been saved.";
            }
            else
            {
                categoryDTO.LastModifiedDate = DateTime.Now;
                categoryDTO.ModifiedByAUsersSno = User.GetUserSno();
                _mapper.Map(categoryDTO, existingCategory);
                _context.SaveChanges();
                response.Data = categoryDTO;
                response.Message = "Category has been Updated";
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
            placeOrder.OrderNotes = request.OrderNotes;
            placeOrder.ShipToDifferentAddress = request.ShipToDifferentAddress;
            placeOrder.BillingAddressSno = request.BillingAddressSno;
            placeOrder.ShippingAddressSno = request.ShipToDifferentAddress ? request.ShippingAddressSno : request.BillingAddressSno;
            placeOrder.PaymentMethod = request.PaymentMethod.ToString();
            placeOrder.ShippingMethod = request.ShippingMethod.ToString();

            placeOrder.AUsersSno = User.GetUserSno();
            placeOrder.Status = OrderStatus.Processing.ToString();

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
                        _context.ProductOrders.Update(placeOrder);
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

        [Authorize(Roles = "Admin,ManageProduct")]
        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            var response = new ApiResponse<List<OrderDTO>>();
            var orderDTOs = await _context.ProductOrders
                .Include(poi => poi.BillingAddressSnoNavigation)
                .Select(po => new OrderDTO
                {
                    OrderId = po.Sno,
                    BillingName = po!.BillingAddressSnoNavigation!.FirstName + " " + po.BillingAddressSnoNavigation.LastName,
                    Date = po.OrderDate,
                    OrderStatus = Enum.Parse<OrderStatus>(po.Status ?? ""),
                    PaymentMethod = Enum.Parse<PaymentMethod>(po.PaymentMethod ?? ""),
                    PaymentStatus = Enum.Parse<PaymentStatus>(po.Status ?? ""),
                    Total = po.TotalAmount
                }).ToListAsync();
            response.Data = orderDTOs;
            return Ok(response);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetUserOrder(long orderSno)
        {
            var response = new GetOrderResponse();

            var order = await _context.ProductOrders
                .Include(poi => poi.BillingAddressSnoNavigation)
                .Include(poi => poi.ShippingAddressSnoNavigation)
                .Include(poi => poi.OrderItems)
                    .ThenInclude(poi => poi.AProductsSnoNavigation)
                .FirstOrDefaultAsync(po => po.Sno == orderSno);

            if (order == null)
            {
                return Unauthorized();
            }

            response.ShippingInformation = _mapper.Map<AddressDTO>(order!.ShippingAddressSnoNavigation);
            response.BillingInformation = _mapper.Map<AddressDTO>(order!.BillingAddressSnoNavigation);

            var orderItems = order.OrderItems.Select(ci => new OrderItemDTO
            {
                ProductQuantity = ci.Quantity ?? default,
                ProductSno = ci.AProductsSno ?? default,
                ProductName = ci.AProductsSnoNavigation!.Name,
                ProductPrice = ci.AProductsSnoNavigation.Price,
                ProductImageSrc = ci.AProductsSnoNavigation.ImageUrl,
            }).ToList();

            response.OrderItems = orderItems;

            response.Order = new OrderDTO()
            {
                OrderId = order.Sno,
                BillingName = order!.BillingAddressSnoNavigation!.FirstName + " " + order.BillingAddressSnoNavigation.LastName,
                Date = order.OrderDate,
                OrderStatus = Enum.Parse<OrderStatus>(order.Status!),
                PaymentMethod = Enum.Parse<PaymentMethod>(order.PaymentMethod!),
                PaymentStatus = Enum.Parse<PaymentStatus>(order.Status!),
                Total = order.TotalAmount
            };

            return Ok(response);
        }

        [Authorize(Roles = "User")]
        [HttpGet]
        public async Task<IActionResult> GetUserOrders()
        {
            var response = new ApiResponse<List<OrderDTO>>();
            var orderDTOs = await _context.ProductOrders
                .Include(poi => poi.BillingAddressSnoNavigation)
                .Include(poi => poi.OrderItems)
                    .ThenInclude(poi => poi.ProductOrdersSnoNavigation)
                .Where(po => po.AUsersSno == User.GetUserSno())
                .Select(po => new OrderDTO
                {
                    OrderId = po.Sno,
                    BillingName = po!.BillingAddressSnoNavigation!.FirstName + " " + po.BillingAddressSnoNavigation.LastName,
                    ShippingAddress = po!.ShippingAddressSnoNavigation!.AddressLine1!,
                    Date = po.OrderDate,
                    OrderStatus = Enum.Parse<OrderStatus>(po.Status!),
                    PaymentMethod = Enum.Parse<PaymentMethod>(po.PaymentMethod!),
                    PaymentStatus = Enum.Parse<PaymentStatus>(po.Status!),
                    Total = po.TotalAmount,
                    OrderItems = po.OrderItems.Select(ci => new OrderItemDTO
                    {
                        ProductQuantity = ci.Quantity ?? default,
                        ProductSno = ci.AProductsSno ?? default,
                        ProductName = ci.AProductsSnoNavigation!.Name,
                        ProductPrice = ci.AProductsSnoNavigation.Price,
                        ProductImageSrc = ci.AProductsSnoNavigation.ImageUrl,
                    }).ToList()
                }).ToListAsync();

            response.Data = orderDTOs;
            return Ok(response);
        }

        [Authorize(Roles = "User")]
        [HttpPut]
        public async Task<IActionResult> AddToWishList(AddToWishlistRequest request)
        {
            ProductWishlist? productWishlist = null;
            var response = new ApiResponse<string>();

            productWishlist = await _context.ProductWishlists.FirstOrDefaultAsync(pw => pw.AProductsSno == request.ProductSno && pw.AUsersSno == User.GetUserSno());


            if (productWishlist == null)
            {
                productWishlist = new ProductWishlist();
                productWishlist.AProductsSno = request.ProductSno;
                productWishlist.AUsersSno = User.GetUserSno();
                await _context.ProductWishlists.AddAsync(productWishlist);
                await _context.SaveChangesAsync();
                response.Message = "Product added to your wishlist.";
            }
            else
            {
                response.Message = "Product already exists in your wishlist.";
            }

            return Ok(response);
        }

        [Authorize(Roles = "User")]
        [HttpDelete]
        public async Task<IActionResult> DeleteFromWishList(long productSno)
        {
            ProductWishlist? productWishlist = null;
            var response = new ApiResponse<string>();


            productWishlist = await _context.ProductWishlists.FirstOrDefaultAsync(pw => pw.AProductsSno == productSno && pw.AUsersSno == User.GetUserSno());

            if (productWishlist == null)
            {
                response.Success = false;
                response.ErrorNo = 1;
                response.Message = "Product not exists in your wishlist.";
                return Ok(response);
            }

            _context.ProductWishlists.Remove(productWishlist);
            await _context.SaveChangesAsync();

            response.Message = "Product removed from your wishlist.";
            return Ok(response);
        }

        [HttpDelete]

        public async Task<IActionResult> DeleteCategory(long sno)
        {
            var response = new ApiResponse<string>();
            try
            {
                var category = await _context.ProductCategories.FirstAsync(a => a.Sno == sno);
                _context.ProductCategories.Remove(category);
                await _context.SaveChangesAsync();
                response.Message = "Category has been deleted";
            }
            catch
            {
                response.Message = "Category not found";
            }
            return Ok(response);
        }

        [Authorize(Roles = "User")]
        [HttpGet]
        public async Task<IActionResult> GetUserWishList()
        {
            var response = new ApiResponse<List<ViewProductDTO>>();
            var shoppingCart = await _context.ShoppingCarts.Include(i => i.CartItems).FirstOrDefaultAsync(a => a.AUsersSno == User.GetUserSno());
            var cartItems = shoppingCart?.CartItems.ToList();

            var productWishlists = await _context.ProductWishlists.Include(pw => pw.AProductsSnoNavigation).Where(pw => pw.AUsersSno == User.GetUserSno()).ToListAsync();
            var aProducts = productWishlists.Select(wi => wi.AProductsSnoNavigation).Where(p => p!.IsActive == true).OrderByDescending(p => p!.Sno).ToList();
            var productDTOs = _mapper.Map<List<ViewProductDTO>>(aProducts);
            productDTOs.ForEach(pd =>
            {
                pd.ProductQuantity = cartItems?.FirstOrDefault(ci => ci.AProductsSno == pd.Sno)?.Quantity ?? 0;
            });
            response.Data = productDTOs;
            return Ok(response);
        }

        [Authorize(Roles = "User")]
        [HttpPut]
        public async Task<IActionResult> UpdateShoppingCart(List<CartItemDTO> cartItemDTOs)
        {
            var response = new ApiResponse<string>();

            var shoppingCart = await _context.ShoppingCarts.FirstOrDefaultAsync(a => a.AUsersSno == User.GetUserSno());

            if (shoppingCart == null)
            {
                shoppingCart = new ShoppingCart() { AUsersSno = User.GetUserSno() };
                await _context.ShoppingCarts.AddAsync(shoppingCart);
                await _context.SaveChangesAsync();
            }

            var needToBeDelete = new List<CartItem>();
            var needToBeUpdate = new List<CartItem>();

            var cartItems = await _context.CartItems.Where(ci => ci.ShoppingCartsSno == shoppingCart.Sno).ToListAsync();

            cartItems.ForEach(ci =>
            {
                var cartItem = cartItemDTOs.FirstOrDefault(cid => cid.ProductSno == ci.AProductsSno);

                if (cartItem == null)
                {
                    needToBeDelete.Add(ci);
                }
                else
                {
                    ci.Quantity = cartItem.ProductQuantity;
                    needToBeUpdate.Add(ci);
                }
            });

            if (needToBeUpdate.Any())
            {
                _context.CartItems.UpdateRange(needToBeUpdate);
            }

            if (needToBeDelete.Any())
            {
                _context.CartItems.RemoveRange(needToBeDelete);
            }

            await _context.SaveChangesAsync();

            response.Data = "Cart Updated";
            return Ok(response);
        }

        [Authorize(Roles = "User")]
        [HttpDelete]
        public async Task<IActionResult> DeleteUserAddress(long addressSno)
        {
            var response = new ApiResponse<string>() { };
            try
            {
                var address = await _context.Addresses.FirstOrDefaultAsync(a => a.AUsersSno == User.GetUserSno() && a.Sno == addressSno);
                if (address == null)
                {
                    response.ErrorNo = 1;
                    response.Success = false;
                    response.Message = "Address not exists";
                }
                else
                {
                    address.IsActive = false;
                    _context.Addresses.Update(address);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                response.ErrorNo = 2;
                response.Success = false;
                response.Message = ex.Message;
            }
            return Ok(response);
        }

        [Authorize(Roles = "User")]
        [HttpPost]
        public async Task<IActionResult> CreateCheckoutSession()
        {
            var response = new ApiResponse<string>();
            var shoppingCart = await _context.ShoppingCarts.Include(sc => sc.CartItems).ThenInclude(sc => sc.AProductsSnoNavigation).FirstOrDefaultAsync(a => a.AUsersSno == User.GetUserSno());

            var cartItems = shoppingCart?.CartItems.Select(ci => new CartItemDTO
            {
                ProductSno = ci.AProductsSno ?? 0,
                ProductName = ci.AProductsSnoNavigation?.Name ?? "",
                ProductQuantity = ci.Quantity ?? 0,
                ProductImageSrc = ci.AProductsSnoNavigation?.ImageUrl,
                ProductPrice = ci.AProductsSnoNavigation?.Price ?? 0
            }).ToList();

            try
            {
                var session = _stripePayment.CreateCheckoutSession(cartItems!);
                response.Data = session.Url;
            }
            catch (Exception ex)
            {
                response.ErrorNo = 1;
                response.Message = ex.Message;
                response.Success = false;
            }

            return Ok(response);
        }
    }
}
