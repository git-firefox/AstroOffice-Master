using AstroOfficeWeb.Client.Helper;
using AstroOfficeWeb.Client.Models;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace AstroOfficeWeb.Client.Pages.Account
{
    public partial class Register
    {
        private InputText? InputMobileNumber { get; set; }

        private RegistrationModel RegistrationModel = new RegistrationModel();

        public IList<string>? Errors { get; set; }

        private async Task OnValidSubmit_RegisterUser()
        {
            var response = await AuthService.RegisterUserAsync(new AstroOfficeWeb.Shared.Models.SignUpRequest()
            {
                Password = RegistrationModel.Password,
                PhoneNumber = RegistrationModel.MobileNumber,
                UserName = RegistrationModel.UserName
            });

            if (response.IsRegisterationSuccessful)
            {
                NavigationManager!.NavigateTo("/login");
            }
            else
            {
                Errors = response.Errors.ToList();
            }
        }
        private async Task OnFocusOut_MobileNumber(FocusEventArgs e)
        {

            var mobileNumberObj = await JSRuntime.GetInputMaskValueAsync(InputMobileNumber?.Element);
            RegistrationModel.MobileNumber = mobileNumberObj.ToMobileNumber(" ");
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
