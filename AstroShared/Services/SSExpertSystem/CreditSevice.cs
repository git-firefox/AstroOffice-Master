using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AstroShared.Helper;
using AstroShared.Services.SSExpertSystem.Models;

namespace AstroShared.Services.SSExpertSystem
{
    public static class BalanceApiConst
    {
        public static string GET_Balance = "api/v2/Balance";
    }
    public class CreditSevice
    {
        public readonly SSExpertSystemSettings _setting;
        public readonly HttpClientBase _httpClient;
        public CreditSevice(SSExpertSystemSettings settings)
        {
            _setting = settings;
            _httpClient = new(_setting.BaseUrl);
        }
        //public async Task<ApiSSExpertSystemResponse<IList<BalanceResponse>>?> GetBalance()
        public async Task<ApiSSExpertSystemResponse?> GetBalance()
        {
            var queryParams = new Dictionary<string, string>()
            {
                { "ApiKey", _setting.APIKey }
                , { "ClientId", _setting.ClientId }
            };
            //var response = await _httpClient.GetAsync<ApiSSExpertSystemResponse<IList<BalanceResponse>>>(BalanceApiConst.GET_Balance, queryParams);
            var response = await _httpClient.GetAsync<ApiSSExpertSystemResponse>(BalanceApiConst.GET_Balance, queryParams);
            return response;
        }
    }
}
