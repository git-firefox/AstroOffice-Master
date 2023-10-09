using System.Net.Http.Headers;
using System.Text;
using AstroOfficeWeb.Client.Services.IService;
using Blazored.LocalStorage;
using Newtonsoft.Json;

namespace AstroOfficeWeb.Client.Services
{
    public class SwaggerApiService : ISwaggerApiService
    {
        private readonly HttpClient _client;
        private readonly ILocalStorageService _localStorage;

        public SwaggerApiService(HttpClient client, ILocalStorageService localStorage)
        {
            _client = client;
            _localStorage = localStorage;
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

        public async Task<TResponse?> AuthPostAsync<TRequest, TResponse>(string url, TRequest request)
        {
            var content = JsonConvert.SerializeObject(request);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");

            // Add JWT token to the authorization header
            //var token = await _localStorage.GetItemAsync<string>("jwtToken");
            //if (!string.IsNullOrEmpty(token))
            //{
            //    _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            //}

            var response = await _client.PostAsync(_client.BaseAddress + url, bodyContent);
            if (response.IsSuccessStatusCode)
            {
                var contentTemp = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<TResponse>(contentTemp);
                return result;
            }
            return default;
        }

        public async Task<TResponse?> AuthGetAsync<TResponse>(string url)
        {
            // Add JWT token to the authorization header
            var token = await _localStorage.GetItemAsync<string>("jwtToken");
            if (!string.IsNullOrEmpty(token))
            {
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

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
