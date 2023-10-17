using AstroOfficeWeb.Client.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace AstroOfficeWeb.Client.Pages.Account
{
    public partial class ForgotPassword
    {
        [Inject]
        private NavigationManager? NavigationManager { get; set; }

        private MobileOtpModal MobileOtpModal = new();

        private void OnClick_BtnMobileVerifyOTP(MouseEventArgs e)
        {
            MobileOtpModal?.ShowAsync();
        }
        private void OnConfirmationChanged(bool  isConfirm)
        {
            if(isConfirm)
            {
                MobileOtpModal?.CloseAsync();
                NavigationManager!.NavigateTo("/changePassword");
            }
        }
    }
 
}
