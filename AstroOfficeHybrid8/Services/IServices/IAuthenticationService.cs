using AstroOfficeWeb.Shared.Models;

namespace AstroOfficeHybrid8.Services.IServices
{
    public interface IAuthenticationService
    {
        Task<SignUpResponse> RegisterUserAsync(SignUpRequest signUpRequest);
        Task<SignInResponse> LoginAsync(SignInRequest signInRequest);
        Task<SignInResponse> LoginWithOtpAsync(SignInWithOtpRequest signInRequest);
        void LogoutAsync();
    }
}
