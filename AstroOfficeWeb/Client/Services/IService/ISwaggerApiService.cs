using AstroOfficeWeb.Shared.Models;
using AstroShared.Utilities;

namespace AstroOfficeWeb.Client.Services.IService
{
    public interface ISwaggerApiService
    {
        Task<TResponse?> PostAsync<TRequest, TResponse>(string url, TRequest request);
        //Task<TResponse?> PostWithMultipartFormDataContentAsync<TRequest, TResponse>(string url, List<IBrowserFile> files, TRequest? request);
        Task<TResponse?> PostWithMultipartFormDataContentAsync<TResponse>(string url, List<FileData> files);
        Task<TResponse?> PutAsync<TRequest, TResponse>(string url, TRequest request);
        Task<TResponse?> GetAsync<TResponse>(string url, Dictionary<string, string>? queryParams = null);
        Task<TResponse?> DeleteAsync<TResponse>(string url, Dictionary<string, string>? queryParams = null);
    }
}
