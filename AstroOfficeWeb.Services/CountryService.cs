using AstroOfficeServices.IServices;
using AstroOfficeWeb.Shared.DTOs;
using AstroOfficeWeb.Shared.Helper;
using AstroOfficeWeb.Shared.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AstroOfficeServices
{
    public class CountryService
    {
        private readonly ISwaggerApiService _swagger;

        public CountryService(ISwaggerApiService swagger)
        {
            _swagger = swagger;
        }

        public async Task<List<Option>> GetCountryOptionsAsync()
        {
            var countryDTOs = await _swagger.GetAsync<List<CountryDTO>>(CountryApiConst.GET_Countries) ?? new List<CountryDTO>();

            var options = countryDTOs.Select(a => new Option { Text = a.Country, Value = a.Sno }).ToList();
            return options;
        }
    }
}
