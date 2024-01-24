using AstroOfficeWeb.Shared.Models;

namespace AstroOfficeWeb.Client.Services.IService
{
    public interface IAuthenticationService
    {
        Task<ApiResponse<string>> RegisterUserAsync(SignUpRequest signUpRequest);
        Task<SignInResponse> LoginAsync(SignInRequest signInRequest);
        Task<SignInResponse> LoginWithOtpAsync(SignInWithOtpRequest signInRequest);
        Task LogoutAsync();
    }
}
