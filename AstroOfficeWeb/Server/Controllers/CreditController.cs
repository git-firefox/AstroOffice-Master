using System.Net;
using AstroOfficeWeb.Server.Helper;
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
        public readonly SSExpertSystemSettings _setting;
        public readonly HttpClientHelper _httpClient;

        public CreditController(IOptions<SSExpertSystemSettings> ssExpertSystemSetting)
        {
            _setting = ssExpertSystemSetting.Value;
            _httpClient = new(BaseApiConst.Base);
        }

        [HttpGet]
        public async Task<IActionResult> Balance()
        {

            string url = string.Format(BalanceApiConst.Balance, _setting.APIKey, _setting.ClientId);
            string d = WebUtility.UrlEncode(url);
            var response = await _httpClient.GetAsync<BalanceListResponse>(d);
            return Ok(response);
        }
    }
}
