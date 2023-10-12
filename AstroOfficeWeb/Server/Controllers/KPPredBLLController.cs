using ASDLL.DataAccess.Core;
using AstroOfficeWeb.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AstroOfficeWeb.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class KPPredBLLController : ControllerBase
    {

        private readonly KPPredBLL _kpPredBLL;

        public KPPredBLLController(KPPredBLL kpPredBLL)
        {
            _kpPredBLL = kpPredBLL;
        }
        public IActionResult GetRedSigniPlanetWise(GetRedSigniPlanetWiseRequest request)
        {
            if (request.PersonalKundli == null || request.ProductSettings == null || request.CuspHouse == null || request.KPChart == null)
                return BadRequest();

            var dataString = _kpPredBLL.Get_Red_Signi_PlanetWise(request.KPChart, request.CuspHouse, request.ProductSettings, request.PersonalKundli, request.Planet);

            dataString = dataString.Replace("\n", "<br />").Replace("\r", "").Replace("\t", "&nbsp;&nbsp;&nbsp;&nbsp;");

            return Ok(new ApiResponse<string> { Data = dataString, Success = true });
        }
    }
}
