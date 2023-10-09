using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroOffice.Helper
{
    internal class ExceptionHandler
    {
        public static void HandleException(Exception ex)
        {
            Loader.Close();
            LogException(ex);
            ShowErrorMessage(ex.Message);

            // Optionally, exit the application gracefully
            // Environment.Exit(1);
        }

        private static void LogException(Exception ex)
        {
            // Implement your logging logic here (e.g., write to a log file)
        }

        private static void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
