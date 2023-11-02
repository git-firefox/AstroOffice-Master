//using AstroOfficeWeb.Client.Components;
using AstroOfficeWeb.Client.Services.IService;
using AstroOfficeWeb.Client.Shared;
using AstroOfficeWeb.Shared;
using AstroOfficeWeb.Shared.Models;
using AstroShared.Helper;
using AstroShared.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;
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
                NavigationManager!.NavigateTo("/");
            }
            else
            {
                await JSRuntime.ShowToastAsync(response?.Message ?? "Error!", SwalIcon.Error);
            }
        }  

    }
}
