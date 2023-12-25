using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AstroOfficeWeb.Shared.Helper
{

    public class HttpClientBase
    {
        private readonly HttpClient _client;

        public HttpClientBase(string baseAddress)
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri(baseAddress)
            };
        }

        public async Task<TResponse?> PostAsync<TRequest, TResponse>(string url, TRequest request)
        {

            var content = JsonConvert.SerializeObject(request);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync(_client.BaseAddress + url, bodyContent);
            if (response.IsSuccessStatusCode)
            {
                var contentTemp = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<TResponse>(contentTemp);
                return result;
            }
            return default;
        }

        public async Task<TResponse?> GetAsync<TResponse>(string url, Dictionary<string, string>? queryParams = null)
        {
            var uriBuilder = new UriBuilder(_client.BaseAddress + url);

            if (queryParams != null && queryParams.Count > 0)
            {
                string query = string.Join("&", queryParams.Select(kvp => $"{Uri.EscapeDataString(kvp.Key)}={Uri.EscapeDataString(kvp.Value)}"));
                uriBuilder.Query = query;
            }

            HttpResponseMessage response = await _client.GetAsync(uriBuilder.Uri);
            if (response.IsSuccessStatusCode)
            {
                var contentTemp = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<TResponse>(contentTemp);
                return result;
            }
            return default;
        }
    }
}
