using Microsoft.AspNetCore.Components.Authorization;

namespace AstroOfficeMobile.Services.IService
{
    public interface IAuthenticationStateService
    {
        //Task<AuthenticationState> GetAuthenticationStateAsync();
        void NotifyUserLoggedIn(string token);
        void NotifyUserLogout();

    }
}
