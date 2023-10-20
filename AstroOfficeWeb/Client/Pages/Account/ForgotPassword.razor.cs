using AstroOfficeWeb.Client.Helper;
using AstroOfficeWeb.Client.Models;
using AstroOfficeWeb.Client.Services.IService;
using AstroOfficeWeb.Client.Shared;
using AstroOfficeWeb.Shared;
using AstroOfficeWeb.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using SwalIcon = AstroOfficeWeb.Client.Helper.SwalIcon;

namespace AstroOfficeWeb.Client.Pages.Account
{
    public partial class ForgotPassword
    {

        private InputText? InputMobileNumber { get; set; }
        private LoginWithOtpModel LoginModel = new();

        [Inject]
        private NavigationManager? NavigationManager { get; set; }

        [Inject]
        ISwaggerApiService? Swagger { get; set; }
        private MobileOtpModal MobileOtpModal = new();

        private async void OnConfirmationChanged(bool isConfirm)
        {
            if (isConfirm)
            {
                var otpObj = await MobileOtpModal.GetOtpValue();
                var response = await Swagger!.GetAsync<ApiResponse<string>>(string.Format(SMSApiConst.GET_VerifyOtp, LoginModel.MobileNumber, otpObj.ToStringX()));

                if (response == null) { return; }

                if (response.Success)
                {
                    MobileOtpModal?.CloseAsync();
                    NavigationManager!.NavigateTo($"/changePassword/{LoginModel.MobileNumber}/{otpObj.ToStringX()}");
                }
                else
                {
                    await JSRuntime.ShowToastAsync(response.Message ?? "Something is wrong", SwalIcon.Error);
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
            var response = await Swagger!.GetAsync<ApiResponse<string>>(string.Format(SMSApiConst.GET_SendOtp, LoginModel.MobileNumber));
            if (response == null)
            {
                return;
            }

            if (response.Success)
            {
                await MobileOtpModal!.ShowAsync();
            }
            else
            {
                await JSRuntime.ShowToastAsync(response.Message ?? "Something is wrong please try again later.", SwalIcon.Error);
            }
        }
    }
}
