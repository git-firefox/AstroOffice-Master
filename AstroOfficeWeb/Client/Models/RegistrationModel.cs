using System.ComponentModel.DataAnnotations;

namespace AstroOfficeWeb.Client.Models
{
    public class RegistrationModel
    {
        [Required(ErrorMessage = "User Name is required")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Mobile number is required")]
        public string? MobileNumber { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Retype password is required")]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string? RetypePassword { get; set; }

        public bool AgreeTerms { get; set; } = false;
    }
}
