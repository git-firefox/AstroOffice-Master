using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AstroOfficeServices.IServices;
using AstroOfficeWeb.Shared.Helper;
using AstroOfficeWeb.Shared.Models;

namespace AstroOfficeWeb.Services
{
    public class BestBLLService
    {
        private readonly ISwaggerApiService _swagger;

        public BestBLLService(ISwaggerApiService swagger)
        {
            _swagger = swagger;
        }

        public async Task<bool> IsBestKundali(string best_Online_Result, short rating, short engine)
        {
            var request = new BestKundaliRequest() { Best_Online_Result = best_Online_Result, Rating = rating, Engine = engine };

            var response = await _swagger!.PostAsync<BestKundaliRequest, ApiResponse<bool>>(BestBLLApiConst.POST_IsBestKundali, request);

            return response?.Data ?? false;
        }
    }
}
