using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor;

namespace AstroOfficeWeb.Client.Pages.User
{
    public class ManageUserViewModel
    {

    }

    public partial class ManageUsers
    {
        private bool IsDrawerOpen { get; set; }
        private bool IsSaveUserFormValid { get; set; }
        void OnClick_ToggleDrawer(MouseEventArgs e)
        {
            IsDrawerOpen = !IsDrawerOpen;
        }

        string[] errors = { };
        MudTextField<string> pwField1 = null!;
        MudForm form = null!;

        private IEnumerable<string> PasswordStrength(string pw)
        {
            if (string.IsNullOrWhiteSpace(pw))
            {
                yield return "Password is required!";
                yield break;
            }
            if (pw.Length < 8)
                yield return "Password must be at least of length 8";
            if (!Regex.IsMatch(pw, @"[A-Z]"))
                yield return "Password must contain at least one capital letter";
            if (!Regex.IsMatch(pw, @"[a-z]"))
                yield return "Password must contain at least one lowercase letter";
            if (!Regex.IsMatch(pw, @"[0-9]"))
                yield return "Password must contain at least one digit";
        }

        private string? PasswordMatch(string arg)
        {
            if (pwField1.Value != arg)
                return "Passwords don't match";
            return null;
        }
    }
}
