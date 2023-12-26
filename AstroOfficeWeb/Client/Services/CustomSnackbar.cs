//using AstroOfficeWeb.Services.IServices;
using System.Diagnostics.CodeAnalysis;
using AstroOfficeWeb.Services.IServices;
using AstroOfficeWeb.Shared.Utilities;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace AstroOfficeWeb.Client.Services
{
    public class CustomSnackbar : ISnackbarService
    {
        private readonly ISnackbar _snackbar;

        public CustomSnackbar(ISnackbar snackbar)
        {
            _snackbar = snackbar;
        }

        public void ShowDarkSnackbar(string? message)
        {
            _snackbar.Add(message, Severity.Normal);
        }

        public void ShowErrorSnackbar(string? message)
        {
            _snackbar.Add(message, Severity.Error);
        }

        public void ShowInfoSnackbar(string? message)
        {
            _snackbar.Add(message, Severity.Info);
        }

        public void ShowSnackbar(AstroOfficeWeb.Shared.Utilities.Snackbar snackbar)
        {
            throw new NotImplementedException();
        }

        public Task ShowSnackbarAsync(AstroOfficeWeb.Shared.Utilities.Snackbar snackbar)
        {
            throw new NotImplementedException();
        }

        public void ShowSuccessSnackbar(string? message)
        {
            _snackbar.Add(message, Severity.Success);
        }

        public void ShowWarningSnackbar(string? message)
        {
            _snackbar.Add(message, Severity.Warning);
        }
    }
}
