using System.ComponentModel.DataAnnotations;

namespace AstroOfficeWeb.Client.Models
{
    public class ChangePasswordModel
    {
        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required")]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string? ConfirmPassword { get; set; }
    }
}
