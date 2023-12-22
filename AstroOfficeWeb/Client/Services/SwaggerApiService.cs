using System.Net;
using System.Net.Http.Headers;
using System.Text;
using AstroOfficeWeb.Client.Services.IService;
using AstroOfficeWeb.Shared.Models;
using AstroShared.Helper;
using AstroShared.Utilities;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Forms;
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
            else if (response.StatusCode == HttpStatusCode.Unauthorized) { };

            return default;
        }

        public async Task<TResponse?> PostWithMultipartFormDataContentAsync<TResponse>(string url, List<FileData> files)
        {
            var multipartContent = new MultipartFormDataContent();

            //if (request != null)
            //{
            //    var content = JsonConvert.SerializeObject(request);
            //    var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            //    multipartContent.Add(bodyContent, "json");
            //}

            foreach (var file in files)
            {

                var fileStreamContent = new StreamContent(file.File);
                fileStreamContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                {
                    Name = "Files",
                    FileName = file.FileName,
                };
                fileStreamContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(file.ContentType);
                multipartContent.Add(fileStreamContent, file.Name, file.FileName);
            }

            var response = await _client.PostAsync(_client.BaseAddress + url, multipartContent);

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
