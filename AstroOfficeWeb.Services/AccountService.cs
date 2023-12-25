using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AstroOfficeServices.IServices;
using AstroOfficeWeb.Shared.Helper;
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

        public async Task<List<UserViewModel>?> SaveUsers()
        {
            var response = await _swagger!.GetAsync<List<UserViewModel>>(AccountApiConst.GET_Users);
            return response;
        }
    }
}
