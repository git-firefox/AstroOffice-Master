using System.Runtime.Versioning;
using ASDLL.DataAccess.Core;
using AstroOfficeWeb.Server.Helper;
using AstroOfficeWeb.Shared.Models;
using AstroShared.Models;
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
            var lkmv = request.Lkmv;
            var bitmap = _kpbl.Gen_Image(request.Lagna, lkmv, request.Online_Result, request.Bhav_Chalit, request.Kund_Size, request.Lang);
            return Ok(new ApiResponse<string> { Success = true, Data = bitmap.ToBase64String() });
        }


        [HttpPost]
        public IActionResult NEWGetVarshaphalKundliMapping([FromBody] GetVarshaphalKundliMappingRequest request)
        {
            var getVarsh = _kpbl.NEW_GetVarshaphalKundliMapping(request.age, request.persKV, request.kp_chart);



            return Ok(getVarsh);
        }


    }
}
