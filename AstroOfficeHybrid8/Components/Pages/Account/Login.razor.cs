using AstroOfficeWeb.Shared.Models;
using AstroShared.Helper;
using AstroShared.ViewModels;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroOfficeHybrid8.Components.Pages.Account
{
    public partial class Login
    {

        private bool PasswordIsClicked { get; set; } = false;
        private LoginModel LoginModel { get; set; } = new();

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
            if (response!.IsAuthSuccessful)
            {
                await JSRuntime.ShowToastAsync(response?.Message ?? "Success!");
                NavigationManager!.NavigateTo("/welcome");
            }
            else
            {
                await JSRuntime.ShowToastAsync(response?.Message ?? "Error!", SwalIcon.Error);
            }
        }

        private async Task CheckAuthenticationState()
        {
            var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;

            if (user!.Identity!.IsAuthenticated)
            {
                // User is already authenticated, redirect to another page
                NavigationManager.NavigateTo("/");
                //await JSRuntime.ShowToastAsync("You don't have access to open this page", SwalIcon.Success);
            }
        }

    }
}
