using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AstroOfficeWeb.Services.IServices;
using AstroOfficeWeb.Shared.Utilities;

namespace AstroOfficeWeb.Services
{
    public class SnackbarService : ISnackbarService
    {
        public void ShowDarkSnackbar(string? message)
        {
            Console.WriteLine(message);
        }

        public void ShowErrorSnackbar(string? message)
        {
            Console.WriteLine(message);
        }

        public void ShowInfoSnackbar(string? message)
        {
            Console.WriteLine(message);
        }

        public void ShowSnackbar(Snackbar snackbar)
        {
            Console.WriteLine("Obj");
        }

        public Task ShowSnackbarAsync(Snackbar snackbar)
        {
            throw new NotImplementedException();
        }

        public void ShowSuccessSnackbar(string? message)
        {
            Console.WriteLine(message);
        }

        public void ShowWarningSnackbar(string? message)
        {
            Console.WriteLine(message);
        }
    }
}
