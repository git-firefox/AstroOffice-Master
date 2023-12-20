using System.Net;
using System.Net.Http.Headers;
using System.Text;
using AstroOfficeServices.IServices;
using AstroShared.Helper;

using Newtonsoft.Json;

namespace AstroOfficeServices
{
    public class SwaggerApiService : ISwaggerApiService
    {
        private readonly HttpClient _client;

        public SwaggerApiService(HttpClient client)
        {
            _client = client;
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
            else if (response.StatusCode == HttpStatusCode.Unauthorized) { };

            return default;
        }

        public async Task<TResponse?> PutAsync<TRequest, TResponse>(string url, TRequest request)
        {
            try
            {
                var content = JsonConvert.SerializeObject(request);
                var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
                var response = await _client.PutAsync(_client.BaseAddress + url, bodyContent);
                if (response.IsSuccessStatusCode)
                {
                    var contentTemp = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<TResponse>(contentTemp);
                    return result;
                }
                return default;
            }
            catch (Exception ex)
            {
                _ = ex;
                return default;
            }
        }

        public async Task<TResponse?> GetAsync<TResponse>(string url, Dictionary<string, string>? queryParams = null)
        {
            HttpResponseMessage response = await _client.GetAsync(GetUriBuilder(url, queryParams).Uri);
            if (response.IsSuccessStatusCode)
            {
                var contentTemp = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<TResponse>(contentTemp);
                return result;
            }
            return default;
        }

        public async Task<TResponse?> DeleteAsync<TResponse>(string url, Dictionary<string, string>? queryParams = null)
        {
            HttpResponseMessage response = await _client.DeleteAsync(GetUriBuilder(url, queryParams).Uri);
            if (response.IsSuccessStatusCode)
            {
                var contentTemp = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<TResponse>(contentTemp);
                return result;
            }
            return default;
        }

        private UriBuilder GetUriBuilder(string url, Dictionary<string, string>? queryParams = null)
        {
            var uriBuilder = new UriBuilder(_client.BaseAddress + url);

            if (queryParams != null && queryParams.Count > 0)
            {
                string query = string.Join("&", queryParams.Select(kvp => $"{Uri.EscapeDataString(kvp.Key)}={Uri.EscapeDataString(kvp.Value.ToStringX())}"));
                uriBuilder.Query = query;
            }
            return uriBuilder;
        }
    }
}
