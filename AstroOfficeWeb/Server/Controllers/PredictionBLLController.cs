using ASDLL.DataAccess.Core;
using AstroOfficeWeb.Shared.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AstroOfficeWeb.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PredictionBLLController : ControllerBase
    {
        private readonly PredictionBLL _predictionBLL;
        private readonly IMapper _mapper;

        public PredictionBLLController(PredictionBLL predictionBLL, IMapper mapper)
        {
            _predictionBLL = predictionBLL;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult MapPersKV([FromBody] MapPersKVRequest request)
        {
            var persKV = _predictionBLL.map_persKV(request.Online_Result, request.Name, request.City, request.DD, request.MM, request.YY, request.HH, request.Min, request.SS, request.Username, request.Lon, request.Lat, request.TZ, request.Paid, request.Lang.ToString(), request.ShowRef, request.Male, request.Domain, request.FilePrefix, request.VcnPrefix, request.Source, request.HeaderTitle, request.Product, request.WDD, request.WMM, request.WYY, request.Rotate);
            //var kundli = _mapper.Map<DTOs.KundliVO>(persKV);
            return Ok(persKV);
        }

        [HttpGet]
        public IActionResult GetCodeLang(string rulecode, string lang, bool paid, bool unicode)
        {
            string code = _predictionBLL.GetCodeLang(rulecode, lang, paid, unicode);
            return Ok(new ApiResponse<string> { Data = code, Success = true });
        }

        [HttpPost]
        public IActionResult GetList35Sala(GetList35SalaRequest request)
        {
            if (request.Online_Result == null || request.PersKV == null)
            {
                return BadRequest();
            }
            var dashaVOs = _predictionBLL.Get_List_35_Sala(request.Online_Result, request.PersKV, request.Dasha_Starts, request.Dasha_Ends);
            return Ok(dashaVOs);
        }
    }
}
