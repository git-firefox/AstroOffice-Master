using AstroOfficeWeb.Shared.Models;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MudBlazor;
using MudExtensions;
using static MudBlazor.Defaults.Classes;
using AstroOfficeWeb.Shared.ViewModels;

namespace AstroOfficeHybrid8.Components.Pages.Account
{
    public partial class Login
    {

        private bool PasswordIsClicked { get; set; } = false;
        private LoginModel LoginModel { get; set; } = new();

        MudCodeInput<string> _textFieldGroup;
        string _value;
        int _count = 4;
        int _spacing = 2;
        Variant _variant = Variant.Outlined;
        Margin _margin;
        bool _disabled;
        bool _readonly;

        bool success;
        string[] errors = { };
        MudTextField<string> pwField1;
        MudForm form;

        private IEnumerable<string> PasswordStrength(string pw)
        {
            if (string.IsNullOrWhiteSpace(pw))
            {
                yield return "Password is required!";
                yield break;
            }
            // if (pw.Length < 8)
            //     yield return "Password must be at least of length 8";
            // if (!Regex.IsMatch(pw, @"[A-Z]"))
            //     yield return "Password must contain at least one capital letter";
            // if (!Regex.IsMatch(pw, @"[a-z]"))
            //     yield return "Password must contain at least one lowercase letter";
            // if (!Regex.IsMatch(pw, @"[0-9]"))
            //     yield return "Password must contain at least one digit";
        }

        private string PasswordMatch(string arg)
        {
            if (pwField1.Value != arg)
                return "Passwords don't match";
            return null;
        }

        protected override async Task OnInitializedAsync()
        {

            

            await CheckAuthenticationState();
        }

        private void OnInvalidSubmit()
        {

        }

        private async Task OnValidSubmitAsync()
        {
            var response = await AuthService!.LoginAsync(new SignInRequest
            {
                UserName = LoginModel!.UserName,
                Password = LoginModel!.Password
            });
            Snackbar.Configuration.PositionClass = Defaults.Classes.Position.BottomCenter;


            if (response!.IsAuthSuccessful)
            {
                Snackbar.Add(response.Message, Severity.Success);

                //NavigationManager!.NavigateTo("/");
                NavigationManager.NavigateTo("/", false, true);
            }
            else
            {
                Snackbar.Add(response.Message, Severity.Error);
            }
        }

        private async Task CheckAuthenticationState()
        {
            var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;

            if (user!.Identity!.IsAuthenticated)
            {
                // User is already authenticated, redirect to another page
                NavigationManager.NavigateTo("/", false, true);
                //await JSRuntime.ShowToastAsync("You don't have access to open this page", SwalIcon.Success);
            }
        }

    }
}
