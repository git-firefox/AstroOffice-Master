using AstroOfficeWeb.Shared.Models;
using AstroOfficeWeb.Shared.Utilities;

namespace AstroOfficeWeb.Services.IServices
{
    public interface ISwaggerApiService
    {
        Task<TResponse?> PostAsync<TRequest, TResponse>(string url, TRequest request);
        Task<TResponse?> PostWithMultipartFormDataContentAsync<TResponse>(string url, IEnumerable<FileData?>? files);
        Task<TResponse?> PostWithMultipartFormDataContentAsync<TRequest, TResponse>(string url, TRequest request, IEnumerable<FileData?>? files);
        Task<TResponse?> PutWithMultipartFormDataContentAsync<TRequest, TResponse>(string url, TRequest request, IEnumerable<FileData?>? files);
        Task<TResponse?> PutAsync<TRequest, TResponse>(string url, TRequest request);
        Task<TResponse?> GetAsync<TResponse>(string url, Dictionary<string, string>? queryParams = null);
        Task<TResponse?> DeleteAsync<TResponse>(string url, Dictionary<string, string>? queryParams = null);
    }
}
