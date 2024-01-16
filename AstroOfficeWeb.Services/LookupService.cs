using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AstroOfficeWeb.Services.IServices;
using AstroOfficeWeb.Shared.Utilities;

namespace AstroOfficeWeb.Services
{
    public class LookupService
    {
        private readonly ISwaggerApiService _swagger;
        private readonly ProductService _service;

        public LookupService(ISwaggerApiService swagger, ProductService service)
        {
            _swagger = swagger;
            _service = service;
        }

        public async Task<IEnumerable<Option>> GetCategoryOptions()
        {
            var categories = await _service.GetCategories();
            return categories?.Select(a => new Option()) ?? Enumerable.Empty<Option>();
        }
    }
}
