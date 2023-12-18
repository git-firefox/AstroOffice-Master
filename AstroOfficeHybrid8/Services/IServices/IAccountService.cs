using AstroOfficeWeb.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroOfficeHybrid8.Services.IServices
{
    public interface IAccountService
    {
        Task<SignUpResponse> RegisterUserAsync(SignUpRequest signUpRequest);
        Task<SignInResponse> LoginAsync(SignInRequest signInRequest);
        Task<SignInResponse> LoginWithOtpAsync(SignInWithOtpRequest signInRequest);
        Task LogoutAsync();
    }
}
