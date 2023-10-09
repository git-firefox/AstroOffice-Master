using ASDLL.DataAccess.Core;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
namespace AstroOfficeWeb.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PlanetBLLController : ControllerBase
    {
        private readonly PlanetBLL _planetBLL;
        private readonly IMapper _mapper;
        public PlanetBLLController(PlanetBLL planetBLL, IMapper mapper)
        {
            _planetBLL = planetBLL;
            _mapper = mapper;
        }

        /// <summary>
        /// this.pvl = (new PlanetBLL()).GetAllPlanets();
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetKPPlanetsVOs()
        {
            var planetVOs = _planetBLL.GetAllPlanets();
            //var planet = _mapper.Map<List<DTOs.PlanetVO>>(planetVOs);
            return Ok(planetVOs);
        }
    }
}
