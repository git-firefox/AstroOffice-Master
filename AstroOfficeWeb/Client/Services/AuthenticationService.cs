using System.Net.Http.Json;
using System.Security.Claims;
using AstroOfficeWeb.Client.Services.IService;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Blazored.LocalStorage;
using Newtonsoft.Json;
using System.Text;
using System.Net.Http.Headers;
using AstroOfficeWeb.Client.Helper;
using AstroOfficeWeb.Shared.Models;

namespace AstroOfficeWeb.Client.Services
{

    public class AuthenticationService : IAuthenticationService
    {
        private readonly ILocalStorageService _localStorage;
        private readonly AuthenticationStateProvider _authStateProvider;
        private readonly ISwaggerApiService _apiService;
        private readonly HttpClient _client;

        public AuthenticationService(ILocalStorageService localStorage, AuthenticationStateProvider authStateProvider, ISwaggerApiService apiService, HttpClient client)
        {
            _authStateProvider = authStateProvider;
            _localStorage = localStorage;
            _apiService = apiService;
            _client = client;
        }

        /// <summary>
        /// var formData = new MultipartFormDataContent();
        /// Add the UserName and Password as form data fields
        /// formData.Add(new StringContent(signInRequest.UserName), "UserName");
        /// formData.Add(new StringContent(signInRequest.Password), "Password"); 
        /// var response = await _client.PostAsync(_client.BaseAddress + "api/Account/SignIn", formData);
        /// </summary>
        /// <param name="signInRequest"></param>
        /// <returns>Task<SignInResponse></returns>
        public async Task<SignInResponse> LoginAsync(SignInRequest signInRequest)
        {
            var response = await _apiService.PostAsync<SignInRequest, SignInResponse>(AccountApiConst.POST_SignIn, signInRequest);

            if (response!.IsAuthSuccessful)
            {
                await _localStorage.SetItemAsync(ApplicationConst.Local_Token, response.Token);
                await _localStorage.SetItemAsync(ApplicationConst.Local_UserDetails, response.UserDTO);
                ((AuthenticationStateService)_authStateProvider).NotifyUserLoggedIn(response.Token);
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", response.Token);
            }

            return response;
        }

        public async Task<SignUpResponse> RegisterUserAsync(SignUpRequest signUpRequest)
        {
            var response = await _apiService.PostAsync<SignUpRequest, SignUpResponse>(AccountApiConst.POST_SignUp, signUpRequest);
            return response ?? new SignUpResponse { IsRegisterationSuccessful = false };
        }

        public async Task LogoutAsync()
        {
            await _localStorage.RemoveItemAsync(ApplicationConst.Local_Token);
            await _localStorage.RemoveItemAsync(ApplicationConst.Local_UserDetails);
            ((AuthenticationStateService)_authStateProvider).NotifyUserLogout();
            _client.DefaultRequestHeaders.Authorization = null;
        }

    }
}
