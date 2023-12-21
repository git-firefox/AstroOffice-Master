﻿using AstroOfficeWeb.Shared.Models;

namespace AstroOfficeServices.IServices
{
    public interface ISwaggerApiService
    {
        Task<TResponse?> PostAsync<TRequest, TResponse>(string url, TRequest request);
        Task<TResponse?> PutAsync<TRequest, TResponse>(string url, TRequest request);
        Task<TResponse?> GetAsync<TResponse>(string url, Dictionary<string, string>? queryParams = null);
        Task<TResponse?> DeleteAsync<TResponse>(string url, Dictionary<string, string>? queryParams = null);
    }
}