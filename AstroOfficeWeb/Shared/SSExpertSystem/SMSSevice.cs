using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AstroOfficeWeb.Shared.Helper;
using AstroOfficeWeb.Shared.SSExpertSystem.Models;


namespace AstroOfficeWeb.Shared.SSExpertSystem
{
    public static class SMSApiConst
    {
        public static string POST_SendSMS = "api/v2/SendSMS";
        public static string GET_MessageStatus = "api/v2/MessageStatus";
    }
    public class SMSSevice
    {
        public readonly SSExpertSystemSettings _setting;
        public readonly HttpClientBase _httpClient;
        public SMSSevice(SSExpertSystemSettings settings)
        {
            _setting = settings;
            _httpClient = new(_setting.BaseUrl);
        }

        //public async Task<ApiSSExpertSystemResponse<List<SendOtpResponse>>?> SendSMS(SendOtpRequest request)
        public async Task<ApiSSExpertSystemResponse?> SendSMS(SendOtpRequest request)
        {
            //var response = await _httpClient.PostAsync<SendOtpRequest, ApiSSExpertSystemResponse<List<SendOtpResponse>>>(SMSApiConst.POST_SendSMS, request);
            var response = await _httpClient.PostAsync<SendOtpRequest, ApiSSExpertSystemResponse>(SMSApiConst.POST_SendSMS, request);
            return response;
        }

        //public async Task<ApiSSExpertSystemResponse<MessageStatusResponse>?> GetMessageStatus(string? messageID)
        public async Task<ApiSSExpertSystemResponse?> GetMessageStatus(string? messageID)
        {
            var queryParams = new Dictionary<string, string>()
            {
                { "ApiKey", _setting.APIKey }
                , { "ClientId", _setting.ClientId }
                , { "MessageId", messageID ?? "" }
            };
            //var response = await _httpClient.GetAsync<ApiSSExpertSystemResponse<MessageStatusResponse>>(SMSApiConst.GET_MessageStatus, queryParams);
            var response = await _httpClient.GetAsync<ApiSSExpertSystemResponse>(SMSApiConst.GET_MessageStatus, queryParams);
            return response;
        }
    }
}
