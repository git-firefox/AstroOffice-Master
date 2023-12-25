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
        void ShowDarkSnackbar(string message, SnackbarPosition position = SnackbarPosition.BottomLeft);
        void ShowInfoSnackbar(string message, SnackbarPosition position = SnackbarPosition.BottomLeft);
        void ShowSuccessSnackbar(string message, SnackbarPosition position = SnackbarPosition.BottomLeft);
        void ShowWarningSnackbar(string message, SnackbarPosition position = SnackbarPosition.BottomLeft);
        void ShowErrorSnackbar(string message, SnackbarPosition position = SnackbarPosition.BottomLeft);
    }
}
