using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AstroOfficeWeb.Shared.Helper;
using AstroOfficeWeb.Shared.SSExpertSystem.Models;


namespace AstroOfficeWeb.Shared.SSExpertSystem
{

    public static class TemplateApiConst
    {
        public static string GET_Template = "api/v2/Template";
    }
    public class TemplateSevice
    {
        public readonly SSExpertSystemSettings _setting;
        public readonly HttpClientBase _httpClient;
        public TemplateSevice(SSExpertSystemSettings settings)
        {
            _setting = settings;
            _httpClient = new(_setting.BaseUrl);
        }

        //public async Task<ApiSSExpertSystemResponse<IList<TemplateResponse>>?> GetTemplates()
        public async Task<ApiSSExpertSystemResponse?> GetTemplates()
        {
            var queryParams = new Dictionary<string, string>()
            {
                { "ApiKey", _setting.APIKey }
                , { "ClientId", _setting.ClientId }
            };
            //var response = await _httpClient.GetAsync<ApiSSExpertSystemResponse<List<TemplateResponse>>>(TemplateApiConst.GET_Template, queryParams);
            var response = await _httpClient.GetAsync<ApiSSExpertSystemResponse>(TemplateApiConst.GET_Template, queryParams);
            return response;
        }
    }
}
