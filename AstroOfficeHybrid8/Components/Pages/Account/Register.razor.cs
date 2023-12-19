using AstroShared.Helper;
using AstroShared.ViewModels;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroOfficeHybrid8.Components.Pages.Account
{
    public partial class Register
    {
        private InputText? InputMobileNumber { get; set; }

        private RegistrationModel RegistrationModel = new RegistrationModel();
        MudTextField<string>? passwordMatch;
        private string? Password { get; set; }
        private bool PasswordIsClicked { get; set; } = false;
        private string? ConfirmPassword { get; set; }
        private bool ConfirmPasswordIsClicked { get; set; } = false;

        bool isShowPassword;
        bool isShowRetyPassword;

        InputType PasswordInput = InputType.Password;
        InputType RetypePasswordInput = InputType.Password;
        string RetypePasswordInputIcon = Icons.Material.Filled.VisibilityOff;
        string PasswordInputIcon = Icons.Material.Filled.VisibilityOff;
        void ButtonPasswordclick()
        {
            if(isShowPassword)
            {
                isShowPassword = false;
                PasswordInputIcon = Icons.Material.Filled.VisibilityOff;
                PasswordInput = InputType.Password;
            }
        else
            {
                isShowPassword = true;
                PasswordInputIcon = Icons.Material.Filled.Visibility;
                PasswordInput = InputType.Text;
            }
        }
        
        void ButtonReTypePasswordclick()
        {
            if(isShowRetyPassword)
            {
                isShowRetyPassword = false;
                RetypePasswordInputIcon = Icons.Material.Filled.VisibilityOff;
                RetypePasswordInput = InputType.Password;
            }
        else
            {
                isShowRetyPassword = true;
                RetypePasswordInputIcon = Icons.Material.Filled.Visibility;
                RetypePasswordInput = InputType.Text;
            }
        }

        private string PasswordMatch(string arg)
        {
            if (passwordMatch.Value != arg)
                return "Passwords don't match";
            return null;
        }

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
              //  await JSRuntime.ShowToastAsync(response?.Message, SwalIcon.Success);
                NavigationManager!.NavigateTo("/login");
            }
            else
            {
                //await JSRuntime.ShowToastAsync(response?.Message, SwalIcon.Error);
            }


        }
        //private async Task OnFocusOut_MobileNumber(FocusEventArgs e)
        //{

        //    var mobileNumberObj = await JSRuntime.GetInputMaskValueAsync(InputMobileNumber?.Element);
        //    RegistrationModel.MobileNumber = mobileNumberObj.ToMobileNumber();
        //}


        //protected override async Task OnAfterRenderAsync(bool firstRender)
        //{
        //    if (firstRender)
        //    {
        //        await JSRuntime.ApplyInputMaskAsync(InputMobileNumber?.Element, "999 999 9999");
        //    }
        //}
    }
}
