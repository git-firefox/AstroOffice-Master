using System.Net.Http.Json;
using System.Security.Claims;
using AstroOfficeWeb.Client.Services.IService;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Blazored.LocalStorage;
using Newtonsoft.Json;
using System.Text;
using System.Net.Http.Headers;
using AstroOfficeWeb.Shared.Models;
using AstroOfficeWeb.Shared.Helper;
using AstroOfficeWeb.Services.IServices;

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
            try
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
            catch (Exception ex)
            {
                _ = ex;
                return new SignInResponse() { IsAuthSuccessful = false, Message = "Oops! Something went wrong on our end. Please try again later or contact support." };
            }
        }

        public async Task<SignInResponse> LoginWithOtpAsync(SignInWithOtpRequest signInRequest)
        {
            var response = await _apiService.PostAsync<SignInWithOtpRequest, SignInResponse>(AccountApiConst.POST_SignInWithOtp, signInRequest);

            if (response!.IsAuthSuccessful)
            {
                await _localStorage.SetItemAsync(ApplicationConst.Local_Token, response.Token);
                await _localStorage.SetItemAsync(ApplicationConst.Local_UserDetails, response.UserDTO);
                ((AuthenticationStateService)_authStateProvider).NotifyUserLoggedIn(response.Token);
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", response.Token);
            }

            return response;
        }

        public async Task<ApiResponse<string>> RegisterUserAsync(SignUpRequest signUpRequest)
        {
            var response = await _apiService.PostAsync<SignUpRequest, ApiResponse<string>>(AccountApiConst.POST_SignUp, signUpRequest);
            return response ?? new ApiResponse<string>() { Success = false };
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
