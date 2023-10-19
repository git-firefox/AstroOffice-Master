using System.Text;
using Newtonsoft.Json;

namespace AstroOfficeWeb.Server.Helper
{
    public class HttpClientHelper
    {
        private readonly HttpClient _client;

        public HttpClientHelper(string baseAddress)
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

        public async Task<TResponse?> GetAsync<TResponse>(string url)
        {
            var response = await _client.GetAsync(_client.BaseAddress + url);
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
