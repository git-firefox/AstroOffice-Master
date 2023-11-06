using AstroOfficeWeb.Shared.Models;

namespace AstroOfficeMobile.Services.IService
{
    public interface IAuthenticationService
    {
        Task<SignUpResponse> RegisterUserAsync(SignUpRequest signUpRequest);
        Task<SignInResponse> LoginAsync(SignInRequest signInRequest);
        Task<SignInResponse> LoginWithOtpAsync(SignInWithOtpRequest signInRequest);
        void Logout();
    }
}
