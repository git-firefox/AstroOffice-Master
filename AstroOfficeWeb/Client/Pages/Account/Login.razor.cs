//using AstroOfficeWeb.Client.Components;
using AstroOfficeWeb.Client.Models;
using AstroOfficeWeb.Client.Services.IService;
using AstroOfficeWeb.Shared;
using AstroOfficeWeb.Shared.Models;
using Microsoft.AspNetCore.Components;
using System.Net;
using System.Net.Http.Json;
using System.Security.Claims;
using static System.Net.WebRequestMethods;

namespace AstroOfficeWeb.Client.Pages.Account
{
    public partial class Login
    {

        private LoginModel? LoginModel { get; set; }

        [Inject]
        private IAuthenticationService? AuthenticationService { get; set; }

        [Inject]
        private HttpClient? HttpClient { get; set; }

        protected override void OnInitialized()
        {

            LoginModel = new LoginModel();
        }

        private void OnInvalidSubmit()
        {

        }

        private async Task OnValidSubmitAsync()
        {
            try
            {
                var response = await AuthenticationService!.LoginAsync(new SignInRequest
                {
                    UserName = LoginModel!.UserName,
                    Password = LoginModel!.Password
                });
                if (response != null) { }
            }
            catch
            {

            }
        }
    }
}
