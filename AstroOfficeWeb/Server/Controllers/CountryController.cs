using ASBAL;
using AstroOfficeWeb.Shared.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AstroOfficeWeb.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly BALCountry _dalCountry;
        private readonly IMapper _mapper;

        public CountryController(BALCountry balCountry, IMapper mapper)
        {
            _dalCountry = balCountry;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetCountry()
        {
            var aCountry = _dalCountry.GetCountry();
            var countryDTOs = _mapper.Map<IEnumerable<ACountryMaster>>(aCountry);
            return Ok(countryDTOs);
        }
    }
}
