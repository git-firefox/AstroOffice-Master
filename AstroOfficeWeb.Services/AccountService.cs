using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AstroOfficeWeb.Services.IServices;
using AstroOfficeWeb.Shared.DTOs;
using AstroOfficeWeb.Shared.Helper;
using AstroOfficeWeb.Shared.Models;
using AstroOfficeWeb.Shared.ViewModels;

namespace AstroOfficeWeb.Services
{
    public class AccountService
    {
        private readonly ISwaggerApiService _swagger;
        private readonly ISnackbarService _snackbar;

        public AccountService(ISwaggerApiService swagger, ISnackbarService snackbar)
        {
            _swagger = swagger;
            _snackbar = snackbar;
        }

        public async Task<List<UserViewModel>?> GetUsers()
        {
            var response = await _swagger!.GetAsync<List<UserViewModel>>(AccountApiConst.GET_Users);
            return response;
        }

        public async Task<bool> IsUsedSavedAsync(UserViewModel user)
        {
            var request = new SignUpMasterRequest()
            {
                Password = user.Password,
                PasswordHash = user.PasswordHash,
                PhoneNumber = user.MobileNumber,
                UserName = user!.UserName!,
                UserPermission = (UserPermission)(user)
            };
            var response = await _swagger!.PostAsync<SignUpMasterRequest, ApiResponse<long>>(AccountApiConst.POST_SignUp, request);

            if(response == null)
            {
                _snackbar.ShowErrorSnackbar("Some this wrong.. try again");
                return false;
            }
            var isSuccessResponse = response?.Success == true;
            if (isSuccessResponse)
            {
                user.Sno = response!.Data;
                _snackbar.ShowSuccessSnackbar(response?.Message);
            }
            else
            {
                _snackbar.ShowErrorSnackbar(response?.Message);
            }
            return isSuccessResponse;
        }
    }
}
