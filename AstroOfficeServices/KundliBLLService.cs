using AstroOfficeServices.IServices;
using AstroOfficeWeb.Shared.Models;
using AstroShared.Helper;
using AstroShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroOfficeServices
{
    public class KundliBLLService
    {
        private readonly ISwaggerApiService Swagger;

        public KundliBLLService(ISwaggerApiService swagger)
        {
            Swagger = swagger;
        }

        public async Task<string> Gen_Kunda(string? detail, float lagan, short rotate)
        {
            var kundaRequest = new GenKundaRequest()
            {
                Detail = detail,
                Lagan = lagan,
                Rotate = rotate,
            };

            var kundaResponse = await Swagger!.PostAsync<GenKundaRequest, ApiResponse<string>>(KundliBLLApiConst.POST_GenKunda, kundaRequest);
            if (kundaResponse == null)
            {
                return string.Empty;
            }
            return kundaResponse.Data ?? string.Empty;
        }

        public async Task<string> Gen_Image(string lagna, List<KPPlanetMappingVO> lkmv, string Online_Result, bool bhav_chalit, short Kund_Size, string lang)
        {
            var genImageRequest = new GenImageRequest()
            {
                Lagna = lagna,
                Lkmv = lkmv,
                Online_Result = Online_Result,
                Bhav_Chalit = bhav_chalit,
                Kund_Size = Kund_Size,
                Lang = lang
            };

            var imgResponse = await Swagger!.PostAsync<GenImageRequest, ApiResponse<string>>(KundliBLLApiConst.POST_GenImage, genImageRequest);

            return imgResponse?.Data ?? "";
        }

        public async Task<List<KPPlanetMappingVO>> NEW_GetVarshaphalKundliMapping(int age, KundliVO persKV, List<KPPlanetMappingVO> kp_chart)
        {
            var request = new GetVarshaphalKundliMappingRequest()
            {
                Age = age,
                KP_Chart = kp_chart,
                PersKV = persKV
            };

            var reponse = await Swagger!.PostAsync<GetVarshaphalKundliMappingRequest, List<KPPlanetMappingVO>>(KundliBLLApiConst.POST_NEWGetVarshaphalKundliMapping, request);

            if (reponse != null)
            {
                return reponse;
            }
            return new List<KPPlanetMappingVO>();
        }
    }
}

