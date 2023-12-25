//using AstroOfficeWeb.Client.Components;
using AstroOfficeWeb.Client.Services.IService;
using AstroOfficeWeb.Client.Shared;
using AstroOfficeWeb.Components;
using AstroOfficeWeb.Shared;
using AstroOfficeWeb.Shared.Helper;
using AstroOfficeWeb.Shared.Models;
using AstroOfficeWeb.Shared.ViewModels;


using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Net;
using System.Net.Http.Json;
using System.Security.Claims;
using static System.Net.WebRequestMethods;

namespace AstroOfficeWeb.Client.Pages.Account
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

            if (user.Identity.IsAuthenticated)
            {
                // User is already authenticated, redirect to another page
                NavigationManager.NavigateTo("/");
                //await JSRuntime.ShowToastAsync("You don't have access to open this page", SwalIcon.Success);
            }
        }

    }
}
