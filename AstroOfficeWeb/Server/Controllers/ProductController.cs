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
            var aProducts = _context.AProducts.Where(p => p.IsActive == true).ToList();
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
            try
            {

                var aProduct = _context.AProducts.FirstOrDefault(p => p.Sno == sno && p.IsActive == true);

                if (aProduct == null)
                {
                    apiResponse.ErrorNo = 1;
                    apiResponse.Success = false;
                    apiResponse.Message = ProductMessageConst.NotFoundProduct;
                    return Ok(apiResponse);
                }

                apiResponse.Success = true;
                var productDTO = _mapper.Map<ViewProductDTO>(aProduct);
                apiResponse.Data = productDTO;
            }
            catch (Exception ex) { }

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
                _context.AProducts.Add(aProduct);

                _context.SaveChanges();

                apiResponse.Message = ProductMessageConst.AddProduct;
                apiResponse.Success = true;
                var viewProduct = _mapper.Map<ViewProductDTO>(aProduct);
                apiResponse.Data = viewProduct;
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
                    aProduct.ModifiedByAUsersSno = User.GetUserSno();
                    //aProduct.IsActive = true;

                    _context.AProducts.Update(aProduct);
                    _context.SaveChanges();

                    apiResponse.Message = ProductMessageConst.UpdateProduct;
                    apiResponse.Success = true;

                    var viewProduct = _mapper.Map<ViewProductDTO>(aProduct);

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

                //existedProduct.IsActive = false;
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
    }
}
