using Microsoft.AspNetCore.Components.Authorization;

namespace AstroOfficeHybrid8.Services.IServices
{
    public interface IAuthenticationStateService
    {
        //Task<AuthenticationState> GetAuthenticationStateAsync();
        void NotifyUserLoggedIn(string token);
        void NotifyUserLogout();

    }
}
