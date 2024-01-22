using System.Dynamic;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using AstroOfficeWeb.Services.IServices;
using AstroOfficeWeb.Shared.BaseModels;
using AstroOfficeWeb.Shared.DTOs;
using AstroOfficeWeb.Shared.Helper;
using AstroOfficeWeb.Shared.Models;
using AstroOfficeWeb.Shared.Utilities;
using Newtonsoft.Json;

namespace AstroOfficeWeb.Services
{
    public class SwaggerApiService : ISwaggerApiService
    {
        private readonly HttpClient _client;
        private readonly ISnackbarService _snackbar;

        public SwaggerApiService(HttpClient client, ISnackbarService snackbar)
        {
            _client = client;
            _snackbar = snackbar;
        }

        public async Task<TResponse?> PostAsync<TRequest, TResponse>(string url, TRequest request)
        {
            try
            {

                var content = JsonConvert.SerializeObject(request);
                var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
                var response = await _client.PostAsync(_client.BaseAddress + url, bodyContent);

                var contentTemp = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var result = JsonConvert.DeserializeObject<TResponse>(contentTemp);
                    return result;
                }
                else if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    var errorResponse = await response.Content.ReadFromJsonAsync<ApiErrorResponse>();
                    _snackbar.ShowErrorSnackbar(errorResponse?.Title);
                }
                else
                {
                    var errorResponse = await response.Content.ReadFromJsonAsync<ApiErrorResponse>();
                    _snackbar.ShowErrorSnackbar(errorResponse?.Title);
                };
            }
            catch (Exception ex)
            {
                _snackbar.ShowErrorSnackbar(ex.Message);
            }
            return default;
        }

        public async Task<TResponse?> PostWithMultipartFormDataContentAsync<TRequest, TResponse>(string url, TRequest request, IEnumerable<MediaFile>? files)
        {
            try
            {
                var multipartContent = new MultipartFormDataContent();

                if (request != null)
                {
                    var content = JsonConvert.SerializeObject(request);
                    var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
                    multipartContent.Add(bodyContent, "Data");
                }
                if (files != null)
                {
                    foreach (var file in files)
                    {
                        if (file?.Stream != null)
                        {
                            var fileStreamContent = new StreamContent(file.Stream);
                            fileStreamContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                            {
                                Name = "Files",
                                FileName = file.MediaName,
                            };
                            fileStreamContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(file.ContentType);
                            multipartContent.Add(fileStreamContent, file.Name, file.MediaName);
                        }

                        //multipartContent.Add(fileStreamContent, "1" , "2");

                    }
                }
                var response = await _client.PostAsync(_client.BaseAddress + url, multipartContent);

                if (response.IsSuccessStatusCode)
                {
                    var contentTemp = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<TResponse>(contentTemp);
                    return result;
                }
                else if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    var errorResponse = await response.Content.ReadFromJsonAsync<ApiErrorResponse>();
                    _snackbar.ShowErrorSnackbar(errorResponse?.Title);
                }
                else
                {
                    var errorResponse = await response.Content.ReadFromJsonAsync<ApiErrorResponse>();
                    _snackbar.ShowErrorSnackbar(errorResponse?.Title);
                };

            }
            catch (Exception ex)
            {
                _snackbar.ShowErrorSnackbar(ex.Message);
            }
            return default;
        }

        public async Task<TResponse?> PutWithMultipartFormDataContentAsync<TRequest, TResponse>(string url, TRequest request, IEnumerable<MediaFile?>? files)
        {
            try
            {
                var multipartContent = new MultipartFormDataContent();

                if (request != null)
                {
                    var content = JsonConvert.SerializeObject(request);
                    var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
                    multipartContent.Add(bodyContent, "Data");
                }

                if (files != null)
                {
                    foreach (var file in files)
                    {
                        if (file?.Stream != null)
                        {
                            var fileStreamContent = new StreamContent(file.Stream);
                            fileStreamContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                            {
                                Name = "Files",
                                FileName = file.MediaName,
                            };
                            fileStreamContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(file.ContentType);
                            multipartContent.Add(fileStreamContent, file.Name, file.MediaName);
                        }

                        //multipartContent.Add(fileStreamContent, "1" , "2");

                    }
                }

                //var response = await _client.PostAsync(_client.BaseAddress + url, multipartContent);
                var response = await _client.PutAsync(_client.BaseAddress + url, multipartContent);

                if (response.IsSuccessStatusCode)
                {
                    var contentTemp = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<TResponse>(contentTemp);
                    return result;
                }
                else if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    var errorResponse = await response.Content.ReadFromJsonAsync<ApiErrorResponse>();
                    _snackbar.ShowErrorSnackbar(errorResponse?.Title);
                }
                else
                {
                    var errorResponse = await response.Content.ReadFromJsonAsync<ApiErrorResponse>();
                    _snackbar.ShowErrorSnackbar(errorResponse?.Title);
                };

            }
            catch (Exception ex)
            {
                _snackbar.ShowErrorSnackbar(ex.Message);
            }
            return default;
        }



        public async Task<TResponse?> PostWithMultipartFormDataContentAsync<TResponse>(string url, IEnumerable<MediaFile>? files)
        {
            var multipartContent = new MultipartFormDataContent();

            try
            {
                if (files != null)
                    foreach (var file in files)
                    {
                        if (file != null)
                        {

                            var fileStreamContent = new StreamContent(file.Stream);
                            fileStreamContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                            {
                                Name = "Files",
                                FileName = file.MediaName,
                            };
                            fileStreamContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(file.ContentType);
                            multipartContent.Add(fileStreamContent, file.Name, file.MediaName);
                        }
                    }

                var response = await _client.PostAsync(_client.BaseAddress + url, multipartContent);

                if (response.IsSuccessStatusCode)
                {
                    var contentTemp = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<TResponse>(contentTemp);
                    return result;
                }
                else if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    var errorResponse = await response.Content.ReadFromJsonAsync<ApiErrorResponse>();
                    _snackbar.ShowErrorSnackbar(errorResponse?.Title);
                }
                else
                {
                    var errorResponse = await response.Content.ReadFromJsonAsync<ApiErrorResponse>();
                    _snackbar.ShowErrorSnackbar(errorResponse?.Title);
                };
            }
            catch (Exception ex)
            {
                _snackbar.ShowErrorSnackbar(ex.Message);
            }
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
                else if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    var errorResponse = await response.Content.ReadFromJsonAsync<ApiErrorResponse>();
                    _snackbar.ShowErrorSnackbar(errorResponse?.Title);
                }
                else
                {
                    var errorResponse = await response.Content.ReadFromJsonAsync<ApiErrorResponse>();
                    _snackbar.ShowErrorSnackbar(errorResponse?.Title);
                };
            }
            catch (Exception ex)
            {
                _snackbar.ShowErrorSnackbar(ex.Message);
            }
            return default;
        }

        public async Task<TResponse?> GetAsync<TResponse>(string url, Dictionary<string, string>? queryParams = null)
        {
            try
            {
                HttpResponseMessage response = await _client.GetAsync(GetUriBuilder(url, queryParams).Uri);
                if (response.IsSuccessStatusCode)
                {
                    var contentTemp = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<TResponse>(contentTemp);
                    return result;
                }
                else if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    var errorResponse = await response.Content.ReadFromJsonAsync<ApiErrorResponse>();
                    _snackbar.ShowErrorSnackbar(errorResponse?.Title);
                }
                else
                {
                    var errorResponse = await response.Content.ReadFromJsonAsync<ApiErrorResponse>();
                    _snackbar.ShowErrorSnackbar(errorResponse?.Title);
                };
            }
            catch (Exception ex)
            {
                _snackbar.ShowErrorSnackbar(ex.Message);
            }
            return default;
        }

        public async Task<TResponse?> DeleteAsync<TResponse>(string url, Dictionary<string, string>? queryParams = null)
        {
            try
            {
                HttpResponseMessage response = await _client.DeleteAsync(GetUriBuilder(url, queryParams).Uri);
                if (response.IsSuccessStatusCode)
                {
                    var contentTemp = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<TResponse>(contentTemp);
                    return result;
                }
                else if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    var errorResponse = await response.Content.ReadFromJsonAsync<ApiErrorResponse>();
                    _snackbar.ShowErrorSnackbar(errorResponse?.Title);
                }
                else
                {
                    var errorResponse = await response.Content.ReadFromJsonAsync<ApiErrorResponse>();
                    _snackbar.ShowErrorSnackbar(errorResponse?.Title);
                };
            }
            catch (Exception ex)
            {
                _snackbar.ShowErrorSnackbar(ex.Message);
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


        //public async Task<TResponse?> PostWithMultipartFormDataContentAsync1<TRequest, TResponse>(string url, TRequest request, List<MediaFileDTO> fileRequest) 
        //{
        //    try
        //    {

        //        var expandoObject = new ExpandoObject() as IDictionary<string, object>;
        //        var properties = request?.GetType().GetProperties();
        //        var multipartContent = new MultipartFormDataContent();

        //        foreach (var property in properties)
        //        {
        //            var value = property.GetValue(request);
        //            multipartContent.Add(new StringContent(JsonConvert.SerializeObject(value)), property.Name);
        //        }


        //        //if (request != null)
        //        //{
        //        //    var content = JsonConvert.SerializeObject(request);
        //        //    var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
        //        //    multipartContent.Add(bodyContent, "Data");
        //        //}


        //        if (fileRequest != null)
        //        {
        //            for (int i = 0; i < fileRequest.Count; i++)
        //            {
        //                var file = fileRequest[i];
        //                var propertiesfileRequest = fileRequest.GetType().GetProperties();

        //                if (file.File != null)
        //                {
        //                    var streamContent = new StreamContent(file.File.Stream);
        //                    multipartContent.Add(streamContent, $"Files[{i}].File", file.File.MediaName);
        //                }

        //                foreach (var property in propertiesfileRequest.Where(property => property.PropertyType == typeof(BaseFormFile)))
        //                {
        //                    var value = property.GetValue(file);
        //                    multipartContent.Add(new StringContent(JsonConvert.SerializeObject(value)), $"Files[{i}].{property.Name}");
        //                }

        //            }
        //        }
        //        var response = await _client.PostAsync(_client.BaseAddress + url, multipartContent);

        //        if (response.IsSuccessStatusCode)
        //        {
        //            var contentTemp = await response.Content.ReadAsStringAsync();
        //            var result = JsonConvert.DeserializeObject<TResponse>(contentTemp);
        //            return result;
        //        }
        //        else if (response.StatusCode == HttpStatusCode.Unauthorized)
        //        {
        //            var errorResponse = await response.Content.ReadFromJsonAsync<ApiErrorResponse>();
        //            _snackbar.ShowErrorSnackbar(errorResponse?.Title);
        //        }
        //        else
        //        {
        //            var errorResponse = await response.Content.ReadFromJsonAsync<ApiErrorResponse>();
        //            _snackbar.ShowErrorSnackbar(errorResponse?.Title);
        //        };

        //    }
        //    catch (Exception ex)
        //    {
        //        _snackbar.ShowErrorSnackbar(ex.Message);
        //    }
        //    return default;
        //}

    }
}
