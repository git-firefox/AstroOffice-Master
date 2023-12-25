using ASDLL.DataAccess.Core;
using AstroOfficeWeb.Shared.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using AstroOfficeWeb.Shared.VOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AstroOfficeWeb.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class KPBLLController : ControllerBase
    {
        private readonly KPBLL _kpbl;
        private readonly IMapper _mapper;

        public KPBLLController(KPBLL kpbl, IMapper mapper)
        {
            _kpbl = kpbl;
            _mapper = mapper;
        }

        /// <summary>
        /// this.planet_list = this.kpbl.Fill_Planets();
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetKPPlanetsVOs()
        {
            var kPPlanetsVOs = _kpbl.Fill_Planets();
            //var planets = _mapper.Map<List<DTOs.KPPlanetsVO>>(kPPlanetsVOs);
            return Ok(kPPlanetsVOs);
        }

        /// <summary>
        /// this.house_list = this.kpbl.Fill_Houses();
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetKPHousesVOs()
        {
            var kPHousesVOs = _kpbl.Fill_Houses();
            //var housesVOs = _mapper.Map<List<DTOs.KPHousesVO>>(kPHousesVOs);
            return Ok(kPHousesVOs);
        }

        /// <summary>
        /// this.nak_list = this.kpbl.Fill_Nak();
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetKPNAKVOs()
        {
            var kPNAKVOs = _kpbl.Fill_Nak();
            //var naks = _mapper.Map<List<DTOs.KPNAKVO>>(kPNAKVOs);
            return Ok(kPNAKVOs);
        }

        /// <summary>
        /// this.rashi_list = this.kpbl.Fill_Rashi();
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetKPRashiVOs()
        {
            var kPRashiVOs = _kpbl.Fill_Rashi();
            //var rashis = _mapper.Map<List<DTOs.KPRashiVO>>(kPRashiVOs);
            return Ok(kPRashiVOs);
        }

        /// <summary>
        /// this.kp249 = this.kpbl.Fill_249();
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetKP249VOs()
        {

            var kP249VOs = _kpbl.Fill_249();
            //var kp249 = _mapper.Map<List<AShared.KP249VO>>(kP249VOs);
            return Ok(kP249VOs);
        }

        [HttpPost]

        public IActionResult ProcessPlanetLagan([FromBody] ProcessPlanetLaganRequest request)
        {
            //_kpbl.Process_Planet_Lagan(request.OnlineResult, ref request.KpChart, ref request.CuspHouse, request.Rotate, request.BhavChalit);

            if (request.KpChart == null || request.CuspHouse == null)
                return BadRequest();

            List<KPPlanetMappingVO> kPPlanets = request.KpChart;
            List<KPHouseMappingVO> kPHouseMappings = request.CuspHouse;

            _kpbl.Process_Planet_Lagan(request.OnlineResult, ref kPPlanets, ref kPHouseMappings, request.Rotate, request.BhavChalit);

            var processPlanetLaganResponse = new ProcessPlanetLaganResponse();
            processPlanetLaganResponse.KpChart = kPPlanets;
            processPlanetLaganResponse.CuspHouse = kPHouseMappings;

            return Ok(processPlanetLaganResponse);
        }

        [HttpPost]

        public IActionResult ProcessKPChartGoodBad([FromBody] ProcessKPChartGoodBadRequest request)
        {
            var pPlanetMappingVOs = _kpbl.Process_KPChart_GoodBad(request.KpChart, request.PersKV, request.Prod);
            return Ok(pPlanetMappingVOs);
        }

        [HttpPost]
        public IActionResult GetFalDoubleMahadasha([FromBody] GetFalDoubleMahadashaRequest request)
        {
            if (request.PersonalKundli == null || request.OnlineResult == null || request.TemporaryProduct == null)
            {
                return BadRequest();
            }

            var html = _kpbl.Get_Fal_Double_Mahadasha(request.PlanetNo, request.PersonalKundli, request.OnlineResult, request.TemporaryProduct);

            if (!string.IsNullOrEmpty(html))
                html = html
                    .Replace("\n", "<br />")
                    .Replace("\r", "")
                    .Replace("\t", "&nbsp;&nbsp;&nbsp;&nbsp;");

            return Ok(new ApiResponse<string> { Data = html, Success = true });
        }


        [HttpPost]

        public IActionResult GetNewProducts(ProductSettingsVO prod)
        {

            var html = _kpbl.Get_New_Products(prod);
            if (!string.IsNullOrEmpty(html))
                html = html
                    .Replace("\n", "<br />")
                    .Replace("\r", "")
                    .Replace("\t", "&nbsp;&nbsp;&nbsp;&nbsp;");
            return Ok(new ApiResponse<string> { Data = html, Success = true });
        }

        [HttpPost]
        public IActionResult TenthKamkajPred([FromBody] TenthKamkajPredRequestModel request)
        {
            if (request.CuspHouse == null || request.KPChart == null || request.PersonalKundli == null)
                return BadRequest();

            var html = _kpbl.Tenth_Kamkaj_Pred(request.CuspHouse, request.KPChart, request.PersonalKundli);

            if (!string.IsNullOrEmpty(html))
                html = html
                   .Replace("\n", "<br />")
                   .Replace("\r", "")
                   .Replace("\t", "&nbsp;&nbsp;&nbsp;&nbsp;");
            return Ok(new ApiResponse<string> { Data = html, Success = true });
        }
        [HttpPost]
        public IActionResult GetKPLang([FromBody] GetKpLangRequest request)
        {
            var vGetKpLan = _kpbl.Get_KP_Lang(request.MixSno, request.Language, request.Dashafal, request.Upay, request.Mini);
            return Ok(new ApiResponse<string> { Data = vGetKpLan, Success = true });
        }

        [HttpGet]
        public IActionResult GetKPLang(short mixsno, string language, bool dashafal, bool upay, bool mini)
        {
            var vGetKpLan = _kpbl.Get_KP_Lang(mixsno, language, dashafal, upay, mini);
            return Ok(new ApiResponse<string> { Data = vGetKpLan, Success = true });
        }

        [HttpPost]
        public IActionResult GetPlanetNakPlanetSublordFal(GetPlanetNakPlanetSublordFalRequest request)
        {
            if (request.PersKV == null || request.Houses == null)
                return BadRequest();

            var dataString = _kpbl.Get_Planet_Nak_Planet_Sublord_Fal(request.PersKV, request.House, request.Houses);

            dataString = dataString.Replace("\n", "<br />").Replace("\r", " ").Replace("\t", "&nbsp;&nbsp;&nbsp;&nbsp;");
            
            return Ok(new ApiResponse<string> { Data = dataString, Success = true });
        }

        [HttpPost]
        public IActionResult GetPlanetChainPred(GetPlanetChainPredRequest request)
        {
            if (request.PersKV == null || request.Houses == null || request.PType == null || request.Prod == null)
                return BadRequest();

            var dataString = _kpbl.Get_Planet_Chain_Pred(request.Houses, request.StartDate, request.EndDate, request.PersKV, request.PType, request.NakSwami, request.Prod, request.Age);

            dataString = dataString.Replace("\n", "<br />").Replace("\r", " ").Replace("\t", "&nbsp;&nbsp;&nbsp;&nbsp;");

            return Ok(new ApiResponse<string> { Data = dataString, Success = true });
        }

        [HttpPost]
        public IActionResult GetDashaPred(GetDashaPredRequest request)
        {
            if (request.PersKV == null || request.Houses == null || request.PType == null || request.Prod == null || request.KPChart == null)
                return BadRequest();

            var dataString = _kpbl.Get_Dasha_Pred(request.Planet, request.Houses, request.StartDate, request.EndDate, request.PersKV, request.PType, request.Prod, request.KPChart);
            
            dataString = dataString.Replace("\n", "<br />").Replace("\r", " ").Replace("\t", "&nbsp;&nbsp;&nbsp;&nbsp;");

            return Ok(new ApiResponse<string> { Data = dataString, Success = true });
        }

        [HttpPost]
        public IActionResult GetDashaPredIntelli(GetDashaPredIntelliRequest request)
        {
            if (request.PersKV == null || request.Houses == null || request.PType == null || request.Prod == null || request.KPChart == null)
                return BadRequest();

            var dataString = _kpbl.Get_Dasha_Pred_Intelli(request.Planet, request.Houses, request.StartDate, request.EndDate, request.PersKV, request.PType, request.Prod, request.KPChart, request.ActualPlanet, request.ActualPlanetHouse, request.NakSwamiHouse);

            dataString = dataString.Replace("\n", "<br />").Replace("\r", " ").Replace("\t", "&nbsp;&nbsp;&nbsp;&nbsp;");

            return Ok(new ApiResponse<string> { Data = dataString, Success = true });
        }

    }
}
