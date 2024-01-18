using ASDLL.DataAccess.Core;
using AstroOfficeWeb.Shared.Models;
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

        [HttpPost]
        public IActionResult IsBestKundali(BestKundaliRequest request)
        {
            bool flag = _bestbll.isBestKundali(request.Best_Online_Result, request.Rating, request.Engine);
            return Ok(new ApiResponse<bool> { Data = flag, Message = "Ok", Success = true });
        }

        [HttpPost]
        public IActionResult IsBestKundaliKPAuto(IsBestKundaliKPRequest request)
        {
            if (request.BestOnlineResult == null)
                return BadRequest();

            var vIsBestKundaliKPAuto = _bestbll.isBestKundali_KP_Auto(request.BestOnlineResult, request.Rating);

            return Ok(new ApiResponse<bool> { Data = vIsBestKundaliKPAuto, Success = true });
        }

    }
}
