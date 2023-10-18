using AstroOfficeWeb.Client.Helper;
using AstroOfficeWeb.Client.Models;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace AstroOfficeWeb.Client.Pages.Account
{
    public partial class Register
    {
        [Inject]
        private NavigationManager? NavigationManager { get; set; }    
        private InputText? InputMobileNumber { get; set; }

        private RegistrationModel registrationModel = new RegistrationModel();

        private void RegisterUser()
        {
            NavigationManager!.NavigateTo("/login");
        }
        private async Task OnFocusOut_MobileNumber(FocusEventArgs e)
        {

            var mobileNumberObj = await JSRuntime.GetInputMaskValueAsync(InputMobileNumber?.Element);
            registrationModel.MobileNumber = mobileNumberObj.ToMobileNumber(" ");
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await JSRuntime.ApplyInputMaskAsync(InputMobileNumber?.Element, "999 999 9999");
            }
        }
    }
}
