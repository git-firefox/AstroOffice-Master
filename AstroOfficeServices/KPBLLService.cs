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
    public class KPBLLService
    {
        private readonly ISwaggerApiService Swagger;

        public KPBLLService(ISwaggerApiService swagger)
        {
            Swagger = swagger;
        }
        public async Task<string> Get_Fal_Double_Mahadasha(short planet, KundliVO persKV, string online_Result, ProductSettingsVO prod)
        {
            var request = new GetFalDoubleMahadashaRequest()
            {
                PlanetNo = planet,
                PersonalKundli = persKV,
                OnlineResult = online_Result,
                TemporaryProduct = prod
            };

            var response = await Swagger!.PostAsync<GetFalDoubleMahadashaRequest, ApiResponse<string>>(KPBLLApiConst.POST_GetFalDoubleMahadasha, request);

            return response?.Data ?? string.Empty;
        }

        public async Task<string> Get_New_Products(ProductSettingsVO prod)
        {
            var response = await Swagger!.PostAsync<ProductSettingsVO, ApiResponse<string>>(KPBLLApiConst.POST_GetNewProducts, prod);

            return response?.Data ?? "";

        }

        public async Task<string> Get_KP_Lang(short sno, string language, bool v1, bool v2, bool mini)
        {
            var queryParams = new Dictionary<string, string>
            {
                { "mixsno", sno.ToStringX() },
                { "language", language.ToStringX() },
                { "dashafal", v1.ToStringX() },
                { "upay", v2.ToStringX() },
                { "mini", mini.ToStringX() }
            };
            var response = await Swagger!.GetAsync<ApiResponse<string>>(KPBLLApiConst.GET_GetKPLang, queryParams);
            if (response != null)
                return response.Data ?? string.Empty;
            return string.Empty;
        }

        public async Task<string> Tenth_Kamkaj_Pred(List<KPHouseMappingVO> cusp_house, List<KPPlanetMappingVO> kp_chart, KundliVO persKV)
        {
            var request = new TenthKamkajPredRequestModel() { CuspHouse = cusp_house, KPChart = kp_chart, PersonalKundli = persKV };
            var response = await Swagger!.PostAsync<TenthKamkajPredRequestModel, ApiResponse<string>>(KPBLLApiConst.POST_TenthKamkajPred, request);
            return response?.Data ?? "";
        }

        public async Task<ProcessPlanetLaganResponse?> Process_Planet_Lagan(string Online_Result, List<KPPlanetMappingVO> kp_chart, List<KPHouseMappingVO> cusp_house, short rotate, bool bhav_chalit)
        {
            var processPlanetLaganRequest = new ProcessPlanetLaganRequest()
            {
                OnlineResult = Online_Result,
                KpChart = kp_chart,
                CuspHouse = cusp_house,
                Rotate = rotate,
                BhavChalit = bhav_chalit
            };

            var processPlanetLaganResponse = await Swagger!.PostAsync<ProcessPlanetLaganRequest, ProcessPlanetLaganResponse>(KPBLLApiConst.POST_ProcessPlanetLagan, processPlanetLaganRequest);

            return processPlanetLaganResponse;
        }

        public async Task<List<KPPlanetMappingVO>> Process_KPChart_GoodBad(List<KPPlanetMappingVO> kp_chart, KundliVO persKV, ProductSettingsVO prod)
        {
            var processKPChartGoodBadRequest = new ProcessKPChartGoodBadRequest()
            {
                KpChart = kp_chart,
                PersKV = persKV,
                Prod = prod
            };

            var kpPlanetMappingVOs = await Swagger!.PostAsync<ProcessKPChartGoodBadRequest, List<KPPlanetMappingVO>>(KPBLLApiConst.POST_ProcessKPChartGoodBad, processKPChartGoodBadRequest);

            if (kpPlanetMappingVOs != null)
            {
                return kpPlanetMappingVOs;
            }
            return new List<KPPlanetMappingVO>();
        }

    }
}
