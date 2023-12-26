using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AstroOfficeWeb.Shared.Utilities;

namespace AstroOfficeWeb.Services.IServices
{
    public interface ISnackbarService
    {
        void ShowSnackbar(Snackbar snackbar);
        Task ShowSnackbarAsync(Snackbar snackbar);
        void ShowDarkSnackbar(string? message);
        void ShowInfoSnackbar(string? message);
        void ShowSuccessSnackbar(string? message);
        void ShowWarningSnackbar(string? message);
        void ShowErrorSnackbar(string? message);
    }
}
