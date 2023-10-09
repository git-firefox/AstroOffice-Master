using ASDLL.DataAccess.Core;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace AstroOfficeWeb.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class KPDAOController : ControllerBase
    {

        public readonly KPDAO _kpdao;
        public readonly IMapper _mapper;

        public KPDAOController(KPDAO kpdao, IMapper mapper)
        {
            _kpdao = kpdao;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetUpayLogic()
        {
            var kpdaos = _kpdao.Get_Upay_Logic();
            return Ok(kpdaos);
        }

    }
}
