using ASDLL.DataAccess.Core;
using AstroOfficeWeb.Shared.Models;
using AstroShared.Models;
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

        [HttpPost]
        public IActionResult GetMixDasha([FromBody] GetMixDashaRequest request)
        {
            var vMixDasha=  _kpdao.Get_Mix_Dasha(request.Planet, request.House, request.FieldNumber, request.Category, request.PType);
            return Ok(vMixDasha);
        }

        [HttpGet]
        public IActionResult GetKPCuspPred(bool showref, short house)
        {
             var vGetKpCuspPred= _kpdao.Get_KP_Cusp_Pred(showref,house);    
            return Ok(vGetKpCuspPred);
        }
       
    }
}
