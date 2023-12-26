using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AstroOfficeWeb.Services.IServices;
using AstroOfficeWeb.Shared.Helper;
using AstroOfficeWeb.Shared.Models;
using AstroOfficeWeb.Shared.ViewModels;

namespace AstroOfficeWeb.Services
{
    public class AccountService
    {
        private readonly ISwaggerApiService _swagger;

        public AccountService(ISwaggerApiService swagger)
        {
            _swagger = swagger;
        }

        public async Task<List<UserViewModel>?> GetUsers()
        {
            var response = await _swagger!.GetAsync<List<UserViewModel>>(AccountApiConst.GET_Users);
            return response;
        }

        public async Task SaveUsers(SignUpRequest request)
        {
            var response = await _swagger!.PostAsync<SignUpRequest, ApiResponse<int>>(AccountApiConst.POST_SignUp, request);
        }
    }
}
