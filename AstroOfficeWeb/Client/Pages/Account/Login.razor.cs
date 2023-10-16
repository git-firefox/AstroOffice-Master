//using AstroOfficeWeb.Client.Components;
using AstroOfficeWeb.Client.Models;
using AstroOfficeWeb.Client.Services.IService;
using AstroOfficeWeb.Client.Shared;
using AstroOfficeWeb.Shared;
using AstroOfficeWeb.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System.Net;
using System.Net.Http.Json;
using System.Security.Claims;
using static System.Net.WebRequestMethods;

namespace AstroOfficeWeb.Client.Pages.Account
{
    public partial class Login
    {

        private MobileOtpModal MobileOtpModal = new();
        private MobileOtpModal ForgotPasswordModal = new();
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

        private void OnClick_BtnMobileOTP(MouseEventArgs e)
        {
            MobileOtpModal?.ShowAsync();
        }
        private void OnClick_BtnForgotPassword(MouseEventArgs e)
        {
            ForgotPasswordModal?.ShowForgotPasswordAsync();
        }

        private void OnConfirmationChanged_MobileOtpModal(bool isConfirm)
        {

        }
        private void OnConfirmationChanged_ForgotPasswordModal(bool isConfirm)
        {
            
        }

    }
}
