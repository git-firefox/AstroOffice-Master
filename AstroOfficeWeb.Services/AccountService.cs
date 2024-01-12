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

        public async Task<List<UserListItemModel>?> GetUsers()
        {
            var response = await _swagger!.GetAsync<ApiResponse<List<UserListItemModel>>>(AccountApiConst.GET_Users);
            if (!response!.Success)
            {
                return null;
            }
            return response.Data;
        }

        public async Task<bool> IsUsedSavedAsync(SaveUserDTO user, string? password = null)
        {
            if (!string.IsNullOrEmpty(password))
            {
                //user.HashedPassword = ENCEK.ENCEK.CellGell_ENC(password, "cellgell.com");
            }
            var request = new SignUpMasterRequest()
            {
                UserDTO = user,
            };

            var response = await _swagger!.PostAsync<SignUpMasterRequest, ApiResponse<long>>(AccountApiConst.POST_SignUpMaster, request);

            if (response == null)
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
