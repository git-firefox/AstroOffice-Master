using AstroOfficeWeb.Client.Helper;
using AstroOfficeWeb.Client.Services.IService;
using AstroOfficeWeb.Shared.Models;
using Microsoft.JSInterop;

namespace AstroOfficeWeb.Client.Services
{
    public class KundaliHistroyService
    {
        private readonly ISwaggerApiService _swagger;
        private readonly IJSRuntime _jsRuntime;

        public KundaliHistroyService(ISwaggerApiService swagger, IJSRuntime jsRuntime)
        {
            _swagger = swagger;
            _jsRuntime = jsRuntime;
        }

        public async Task SaveKundali(BirthDetails birthDetails)
        {
            var request = new SaveKundaliRequest() { };

            var response = await _swagger!.PostAsync<SaveKundaliRequest, ApiResponse<string>>(KPBLLApiConst.POST_GetFalDoubleMahadasha, request);

            throw new NotImplementedException();
        }
    }
}
