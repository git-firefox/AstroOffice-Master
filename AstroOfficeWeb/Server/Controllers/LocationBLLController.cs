using ASDLL.ASDLL.ValueObjects;
using ASDLL.AstroScienceWeb.BLL;
using AstroOfficeWeb.Shared.DTOs;
using AstroShared.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;


namespace AstroOfficeWeb.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LocationBLLController : ControllerBase
    {
        private readonly LocationBLL _locationBLL;
        private readonly IMapper _mapper;

        public LocationBLLController(LocationBLL locationBLL, IMapper mapper)
        {
            _locationBLL = locationBLL;
            _mapper = mapper;
        }

        [HttpGet]

        public IActionResult GetPlaceListLike(string place, string countryCode)
        {
            string? stateName;
            var lstBCity = new List<APlaceMaster>();
            var placeListLike = _locationBLL.GetPlaceListLike(place, countryCode);
            foreach (var places in placeListLike)
            {
                var country = new APlaceMaster();
                if ((places.StateOrCountryCode == null ? false : places.StateOrCountryCode.Length > 0))
                {
                    var state = new AStateMaster();
                    stateName = _locationBLL.GetStateByCode(places.StateOrCountryCode)?.StateName;
                }
                else
                {
                    stateName = _locationBLL.GetCountryByCode(places.CountryCode ?? string.Empty).Country;
                }
                country.Sno = places.Sno;
                country.Place = string.Concat(places.Place, " [", stateName, "]");
                country.CountryCode = places.CountryCode;
                country.Latitude = places.Latitude;
                country.StateOrCountryCode = places.StateOrCountryCode;
                country.Longitude = places.Longitude;
                country.TimeCorrectionCode = places.TimeCorrectionCode;
                lstBCity.Add(country);
            }
            var aPlaceMasters = _mapper.Map<List<PlaceDTO>>(lstBCity);
            return Ok(aPlaceMasters);
        }

        [HttpGet]
        public IActionResult GetPlaceByID(long sno)
        {
            var aPlaceMaster = _locationBLL.GetPlaceByID(sno);
            var aPlace = _mapper.Map<PlaceDTO>(aPlaceMaster);
            return Ok(aPlace);
        }

        [HttpGet]
        public IActionResult GetCountryByCode(string countryCode)
        {
            var aCountryMaster = _locationBLL.GetCountryByCode(countryCode);
            var countryMaster = _mapper.Map<ACountryMaster>(aCountryMaster);
            return Ok(countryMaster);
        }

        [HttpGet]

        public IActionResult GetStateByCode(string stateCode)
        {
            var aStateMaster = _locationBLL.GetStateByCode(stateCode);
            var aState = _mapper.Map<AStateMaster>(aStateMaster);
            return Ok(aState);
        }
    }
}
