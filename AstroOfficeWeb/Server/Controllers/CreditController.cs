using AstroOfficeWeb.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace AstroOfficeWeb.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CreditController : ControllerBase
    {
        public readonly SSExpertSystemSetting _setting;

        public CreditController(IOptions<SSExpertSystemSetting> ssExpertSystemSetting)
        {
            _setting = ssExpertSystemSetting.Value;
        }

        [HttpGet]
        public IActionResult Balance([FromQuery] string ApiKey, [FromQuery] string ClientId)
        {       

            return Ok();
        }
    }
}
