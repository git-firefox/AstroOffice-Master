using System.Net.Http.Headers;
using System.Security.Claims;
using AstroOfficeMobile.Services.IService;
using AstroShared.Helper;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;

namespace AstroOfficeMobile.Services
{
    public class AuthenticationStateService : AuthenticationStateProvider, IAuthenticationStateService
    {

        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorage;

        public AuthenticationStateService(HttpClient httpClient, ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            _localStorage = localStorage;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            //var token = await _localStorage.GetItemAsync<string>(ApplicationConst.Local_Token);
            var token = await SecureStorage.GetAsync(ApplicationConst.Local_Token);
            if (token == null)
            {
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            }
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(JwtParser.ParseClaimsFromJwt(token), "JWTAuthType")));
        }
        public void NotifyUserLoggedIn(string token)
        {
            if (string.IsNullOrEmpty(token)) throw new ArgumentNullException(nameof(token));
            var authenticatedUser = new ClaimsPrincipal(new ClaimsIdentity(JwtParser.ParseClaimsFromJwt(token), "JWTAuthType"));
            var authState = Task.FromResult(new AuthenticationState(authenticatedUser));
            NotifyAuthenticationStateChanged(authState);
        }

        public void NotifyUserLogout()
        {
            var authState = Task.FromResult(new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity())));
            NotifyAuthenticationStateChanged(authState);
        }
    }
}
