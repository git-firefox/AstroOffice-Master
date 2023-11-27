using ASBAL;
using ASModels;
using AstroShared.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AstroOfficeWeb.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly AstrooffContext _context;
        private readonly BALCountry _dalCountry;
        private readonly IMapper _mapper;

        public CountryController(BALCountry balCountry, IMapper mapper, AstrooffContext context)
        {
            _dalCountry = balCountry;
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public IActionResult GetCountry()
        {
            var aCountry = _dalCountry.GetCountry();
            var countryDTOs = _mapper.Map<IEnumerable<CountryDTO>>(aCountry);
            return Ok(countryDTOs);
        }

        [HttpGet]
        public IActionResult GetCountries()
        {
            var countries = _context.ACountries.Select(c => new CountryDTO()
            {
                Sno = c.Sno,
                Country = c.Country ?? ""
            }).ToList(); 

            return Ok(countries);
        }
    }
}
