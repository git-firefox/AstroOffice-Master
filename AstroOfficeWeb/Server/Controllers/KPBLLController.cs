using ASDLL.DataAccess.Core;
using AstroOfficeWeb.Shared.Models;
using AShared = AstroShared.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using AstroShared.Models;
//using DTOs = AstroOfficeWeb.Shared.DTOs;

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
    }
}
