using System.Net;
using AstroOfficeWeb.Server.Helper;
using AstroOfficeWeb.Shared.Models;
using AstroShared.Helper;
using AstroShared.Services.SSExpertSystem;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace AstroOfficeWeb.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CreditController : ControllerBase
    {
        public readonly SSExpertSystemSettings _setting;
        public readonly CreditSevice _creditSevice;

        public CreditController(IOptions<SSExpertSystemSettings> ssExpertSystemSetting)
        {
            _setting = ssExpertSystemSetting.Value;
            _creditSevice = new(_setting);
        }

        [HttpGet]
        public async Task<IActionResult> Balance()
        {
            var response = await _creditSevice.GetBalance();
            return Ok(response);
        }
    }
}
