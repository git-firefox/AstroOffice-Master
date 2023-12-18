using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroOfficeHybrid8.Services.IServices
{
    public interface ISwaggerApiService
    {
        Task<TResponse?> PostAsync<TRequest, TResponse>(string url, TRequest request);
        Task<TResponse?> PutAsync<TRequest, TResponse>(string url, TRequest request);
        Task<TResponse?> GetAsync<TResponse>(string url, Dictionary<string, string>? queryParams = null);
        Task<TResponse?> DeleteAsync<TResponse>(string url, Dictionary<string, string>? queryParams = null);
    }
}
