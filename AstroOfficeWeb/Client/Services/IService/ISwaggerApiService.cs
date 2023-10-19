namespace AstroOfficeWeb.Client.Services.IService
{
    public interface ISwaggerApiService
    {
        Task<TResponse?> PostAsync<TRequest, TResponse>(string url, TRequest request);
        Task<TResponse?> PutAsync<TRequest, TResponse>(string url, TRequest request);
        Task<TResponse?> GetAsync<TResponse>(string url);
        Task<TResponse?> AuthPostAsync<TRequest, TResponse>(string url, TRequest request);
        Task<TResponse?> AuthGetAsync<TResponse>(string url);
    }
}
