using ASDLL.DataAccess.Core;
using AstroOfficeWeb.Shared.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AstroOfficeWeb.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BestBLLController : ControllerBase
    {

        private readonly BestBLL _bestbll;

        public BestBLLController(BestBLL bestbll)
        {
            _bestbll = bestbll;
        }

        [HttpGet]
        public IActionResult IsBestKundali(string best_Online_Result, short rating, short engine)
        {
            bool flag = _bestbll.isBestKundali(best_Online_Result, rating, engine);
            return Ok(new ApiResponse<bool> { Data = flag, Message = "Ok", Success = true });
        }

    }
}
