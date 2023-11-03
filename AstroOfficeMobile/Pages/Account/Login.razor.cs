
using AstroOfficeWeb.Shared.Models;
using AstroShared.Helper;
using AstroShared.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroOfficeMobile.Pages.Account
{
    public partial class Login
    {
        private LoginModel LoginModel { get; set; } = new();

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
                NavigationManager!.NavigateTo("/");
            }
            else
            {
                await JSRuntime.ShowToastAsync(response?.Message ?? "Error!", SwalIcon.Error);
            }
        }
    }
}
