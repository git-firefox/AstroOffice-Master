using AstroOfficeServices.IServices;
using AstroOfficeWeb.Shared.Models;
using AstroShared.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroOfficeServices
{
    public class BestBLLService
    {
        private readonly ISwaggerApiService Swagger;

        public BestBLLService(ISwaggerApiService swagger)
        {
            Swagger = swagger;
        }

        public async Task<bool> IsBestKundali(string best_Online_Result, short rating, short engine)
        {
            var request = new BestKundaliRequest() { Best_Online_Result = best_Online_Result, Rating = rating, Engine = engine };

            var response = await Swagger!.PostAsync<BestKundaliRequest, ApiResponse<bool>>(BestBLLApiConst.POST_IsBestKundali, request);

            return response?.Data ?? false;
        }
    }
}
