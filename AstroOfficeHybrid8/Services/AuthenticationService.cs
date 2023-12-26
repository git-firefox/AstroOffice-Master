using System.Net.Http.Json;
using System.Security.Claims;
using AstroOfficeHybrid8.Services.IServices;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Newtonsoft.Json;
using System.Text;
using System.Net.Http.Headers;
using AstroOfficeWeb.Shared.Models;
using AstroOfficeWeb.Services.IServices;
using AstroOfficeWeb.Shared.Helper;

namespace AstroOfficeHybrid8.Services
{

    public class AuthenticationService : IAuthenticationService
    {
        private readonly AuthenticationStateProvider _authStateProvider;
        private readonly ISwaggerApiService _apiService;
        private readonly HttpClient _client;

        public AuthenticationService(AuthenticationStateProvider authStateProvider, ISwaggerApiService apiService, HttpClient client)
        {
            _authStateProvider = authStateProvider;
            _apiService = apiService;
            _client = client;
        }

        public async Task<SignInResponse> LoginAsync(SignInRequest signInRequest)
        {
            try
            {
                var response = await _apiService.PostAsync<SignInRequest, SignInResponse>(AccountApiConst.POST_SignIn, signInRequest);

                if (response!.IsAuthSuccessful)
                {
                    await SecureStorage.SetAsync(ApplicationConst.Local_Token, response!.Token!);
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
                await SecureStorage.SetAsync(ApplicationConst.Local_Token, response!.Token!);
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

        public void LogoutAsync()
        {
            SecureStorage.Remove(ApplicationConst.Local_Token);
            ((AuthenticationStateService)_authStateProvider).NotifyUserLogout();
            _client.DefaultRequestHeaders.Authorization = null;
        }

    }
}
