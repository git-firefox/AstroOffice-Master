﻿using AstroOfficeWeb.Services.IServices;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroOfficeHybrid8.Services
{
    public class CustomSnackbar : ISnackbarService
    {
        private readonly ISnackbar _snackbar;
        public CustomSnackbar(ISnackbar snackbar)
        {
            _snackbar = snackbar;
            _snackbar.Configuration.PositionClass = Defaults.Classes.Position.BottomEnd;

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