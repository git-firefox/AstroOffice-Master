using AstroOfficeWeb.Client.Helper;
using AstroOfficeWeb.Client.Services.IService;
using AstroOfficeWeb.Client.Shared;
using AstroOfficeWeb.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace AstroOfficeWeb.Client.Pages.Account
{
    public partial class ForgotPassword
    {
        [Inject]
        private NavigationManager? NavigationManager { get; set; }
        private string? MobileNUmber { get; set; }

        [Inject]
        ISwaggerApiService? Swagger { get; set; }
        private MobileOtpModal MobileOtpModal = new();

        private async Task OnClick_BtnMobileVerifyOTP(MouseEventArgs e)
        {
            var response = await Swagger!.GetAsync<ApiResponse<string>>(string.Format(SMSApiConst.GET_SendOtp, MobileNUmber));
            
            if(response == null)
            {
                return;
            }

            if (response.Success)
            {
                MobileOtpModal?.ShowAsync();
            }

        }
        private void OnConfirmationChanged(bool isConfirm)
        {
            if (isConfirm)
            {
                MobileOtpModal?.CloseAsync();
                NavigationManager!.NavigateTo("/changePassword");
            }
        }
    }

}
