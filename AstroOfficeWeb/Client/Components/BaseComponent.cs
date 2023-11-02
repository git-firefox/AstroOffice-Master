using System.Security.Claims;
using AstroOfficeWeb.Client.Services.IService;
using AstroShared.Helper;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace AstroOfficeWeb.Client.Components
{
    public class BaseComponent : ComponentBase
    {
        [CascadingParameter]
        protected Task<AuthenticationState>? AuthenticationState { get; set; }

        [Inject]
        protected AuthenticationStateProvider? AuthenticationStateProvider { get; set; }

        protected ClaimsPrincipal? User { get; private set; }
        protected bool IsAuthenticated => User != null && User!.Identity!.IsAuthenticated;
        protected string? UserName => User?.Identity?.Name;
        protected bool IsAdmin => User != null && User.IsInRole(ApplicationConst.Role_Admin);
        protected bool UserCanEdit => User != null && Convert.ToBoolean(User.Claims.FirstOrDefault(i => i.Type == ApplicationConst.CanEdit_Rights)?.Value);
        protected bool UserCanAdd => User != null && Convert.ToBoolean(User.Claims.FirstOrDefault(i => i.Type == ApplicationConst.CanAdd_Rights)?.Value);
        protected bool UserCanReport => User != null && Convert.ToBoolean(User.Claims.FirstOrDefault(i => i.Type == ApplicationConst.CanReport_Rights)?.Value);

        protected override async Task OnInitializedAsync()
        {
            //var authenticationState = await AuthenticationStateProvider!.GetAuthenticationStateAsync();
            User = (await AuthenticationState!).User;
        }
    }
}
