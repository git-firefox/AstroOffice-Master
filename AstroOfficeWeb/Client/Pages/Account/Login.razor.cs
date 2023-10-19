//using AstroOfficeWeb.Client.Components;
using AstroOfficeWeb.Client.Models;
using AstroOfficeWeb.Client.Services.IService;
using AstroOfficeWeb.Client.Shared;
using AstroOfficeWeb.Shared;
using AstroOfficeWeb.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
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
        private LoginModel LoginModel { get; set; } = new();

        private string? LoginErrorMessage { get; set; }

        private void OnInvalidSubmit()
        {

        }

        private async Task OnValidSubmitAsync()
        {

            try
            {
                var response = await AuthService!.LoginAsync(new SignInRequest
                {
                    UserName = LoginModel!.UserName,
                    Password = LoginModel!.Password
                });
                if (response != null)
                {
                    if (response.IsAuthSuccessful)
                    {
                        NavigationManager!.NavigateTo("/");
                    }
                    else
                    {
                        LoginErrorMessage = response?.ErrorMessage ?? "Envalid login credentials";
                    }
                }
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
