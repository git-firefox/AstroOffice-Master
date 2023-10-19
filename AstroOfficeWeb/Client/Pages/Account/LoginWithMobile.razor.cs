using AstroOfficeWeb.Client.Helper;
using AstroOfficeWeb.Client.Models;
using AstroOfficeWeb.Client.Services.IService;
using AstroOfficeWeb.Client.Shared;
using AstroOfficeWeb.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;
using System.ComponentModel.DataAnnotations;

namespace AstroOfficeWeb.Client.Pages.Account
{
    public partial class LoginWithMobile
    {
        private MobileOtpModal MobileOtpModal = new();
        private LoginWithOtpModel LoginModel = new();
        private InputText? InputMobileNumber { get; set; }

        [Inject]
        private NavigationManager? NavigationManager { get; set; }

        [Inject]
        ISwaggerApiService? Swagger { get; set; }

        private string? OtpErrorMessage { get; set; }

        private async void OnConfirmationChanged(bool isConfirm)
        {
            if (isConfirm)
            {
                var otpObj = await MobileOtpModal.GetOtpValue();

                var response = await AuthService.LoginWithOtpAsync(new SignInWithOtpRequest { MobileNumber = LoginModel.MobileNumber, Otp = otpObj.ToStringX() });

                if (response == null) { return; }

                if (response.IsAuthSuccessful)
                {
                    MobileOtpModal?.CloseAsync();
                    NavigationManager!.NavigateTo("/");
                }
                else
                {
                    OtpErrorMessage = response.ErrorMessage;
                }
            }
        }


        private async Task OnFocusOut_MobileNumber(FocusEventArgs e)
        {

            var mobileNumberObj = await JSRuntime.GetInputMaskValueAsync(InputMobileNumber?.Element);
            LoginModel.MobileNumber = mobileNumberObj.ToMobileNumber(" ");
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await JSRuntime.ApplyInputMaskAsync(InputMobileNumber?.Element, "999 999 9999");
            }
        }

        private async Task OnValidSubmit_LoginWithMobile()
        {
            OtpErrorMessage = string.Empty;
            var response = await Swagger!.GetAsync<ApiResponse<string>>(string.Format(SMSApiConst.GET_SendOtp, LoginModel.MobileNumber));
            if (response == null)
            {
                return;
            }

            if (response.Success)
            {
                await MobileOtpModal!.ShowAsync();
            }
        }

    }
}
