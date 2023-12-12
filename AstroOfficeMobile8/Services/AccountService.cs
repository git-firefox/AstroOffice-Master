using AstroOfficeMobile8.Services.IServices;
using AstroOfficeWeb.Shared.Models;
using AstroShared.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AstroOfficeMobile8.Services
{
    class AccountService : IAccountService
    {

        private readonly ISwaggerApiService _apiService;
        private readonly HttpClient _client;

        public AccountService(ISwaggerApiService swaggerApiService, HttpClient client)
        {
            _apiService = swaggerApiService;
            _client = client;
        }

        public AccountService()
        {
            _client = new HttpClient { BaseAddress = new Uri("http://ec2-15-207-51-190.ap-south-1.compute.amazonaws.com") };
            _apiService = new SwaggerApiService(_client);
        }

        public async Task<SignInResponse> LoginAsync(SignInRequest signInRequest)
        {
            try
            {
                var response = await _apiService.PostAsync<SignInRequest, SignInResponse>(AccountApiConst.POST_SignIn, signInRequest);

                if (response!.IsAuthSuccessful)
                {
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

        public Task<SignInResponse> LoginWithOtpAsync(SignInWithOtpRequest signInRequest)
        {
            throw new NotImplementedException();
        }

        public Task LogoutAsync()
        {
            throw new NotImplementedException();
        }

        public Task<SignUpResponse> RegisterUserAsync(SignUpRequest signUpRequest)
        {
            throw new NotImplementedException();
        }
    }
}
