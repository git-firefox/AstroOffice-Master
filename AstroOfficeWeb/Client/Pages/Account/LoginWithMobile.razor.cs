using AstroOfficeWeb.Client.Services.IService;
using AstroOfficeWeb.Client.Shared;
using AstroOfficeWeb.Shared.Models;
using AstroShared.Helper;
using AstroShared.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;
using System.ComponentModel.DataAnnotations;
using SwalIcon = AstroShared.Helper.SwalIcon;

namespace AstroOfficeWeb.Client.Pages.Account
{
    public partial class LoginWithMobile
    {
        private MobileOtpModal MobileOtpModal = new();
        private LoginWithOtpModel LoginModel = new();
        private InputText? InputMobileNumber { get; set; }

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
                    await MobileOtpModal.CloseAsync();
                    await JSRuntime.ShowToastAsync(response?.Message ?? "Error!", SwalIcon.Success);
                    NavigationManager!.NavigateTo("/");
                }
                else
                {
                    await JSRuntime.ShowToastAsync(response?.Message ?? "Error!", SwalIcon.Error);
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
                await JSRuntime.ShowToastAsync(response?.Message ?? "Success!", SwalIcon.Success);
                await MobileOtpModal!.ShowAsync();
            }
            else
            {
                await JSRuntime.ShowToastAsync(response.Message ?? "Something is wrong", SwalIcon.Error);
            }
        }

    }
}
