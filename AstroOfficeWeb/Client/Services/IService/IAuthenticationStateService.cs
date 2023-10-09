using Microsoft.AspNetCore.Components.Authorization;

namespace AstroOfficeWeb.Client.Services.IService
{
    public interface IAuthenticationStateService
    {
        //Task<AuthenticationState> GetAuthenticationStateAsync();
        void NotifyUserLoggedIn(string token);
        void NotifyUserLogout();

    }
}
