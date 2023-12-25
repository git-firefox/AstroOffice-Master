using System.Runtime.Versioning;
using ASDLL.DataAccess.Core;
using AstroOfficeWeb.Server.Helper;
using AstroOfficeWeb.Shared.Models;

using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AstroOfficeWeb.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class KundliBLLController : ControllerBase
    {

        private readonly KundliBLL _kpbl;
        private readonly IMapper _mapper;

        public KundliBLLController(KundliBLL kpbl, IMapper mapper)
        {
            _kpbl = kpbl;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult GenKunda([FromBody] GenKundaRequest request)
        {
            var Online_Result = _kpbl.Gen_Kunda(request.Detail, request.Lagan, Convert.ToInt16(request.Rotate));
            return Ok(new ApiResponse<string> { Success = true, Data = Online_Result });
        }

        [SupportedOSPlatform("windows")]
        [HttpPost]
        public IActionResult GenImage([FromBody] GenImageRequest request)
        {
            if (request.Lkmv == null)
                return BadRequest();

            var bitmap = _kpbl.Gen_Image(request.Lagna, request.Lkmv, request.Online_Result, request.Bhav_Chalit, request.Kund_Size, request.Lang);
            return Ok(new ApiResponse<string> { Success = true, Data = bitmap.ToBase64String() });
        }


        [HttpPost]
        public IActionResult NEWGetVarshaphalKundliMapping([FromBody] GetVarshaphalKundliMappingRequest request)
        {
            if (request.PersKV == null || request.KP_Chart == null)
                return BadRequest();

            var getVarsh = _kpbl.NEW_GetVarshaphalKundliMapping(request.Age, request.PersKV, request.KP_Chart);

            return Ok(getVarsh);
        }


    }
}
