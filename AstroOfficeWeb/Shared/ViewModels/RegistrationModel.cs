using System.ComponentModel.DataAnnotations;

namespace AstroOfficeWeb.Shared.ViewModels
{
    public class RegistrationModel
    {
        [Required(ErrorMessage = "User Name is required")]

        public string? UserName { get; set; }

        [Required(ErrorMessage = "Mobile Number is required")]
        public string? MobileNumber { get; set; }

        [Required(ErrorMessage = "Password is required")]
        //[RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@#$%^&+=!])[A-Za-z\d@#$%^&+=!]{8,}$", ErrorMessage = "Invalid password. It must be at least 8 characters long and include at least one letter, one digit, and one special character.")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Retype password is required")]
        //[RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@#$%^&+=!])[A-Za-z\d@#$%^&+=!]{8,}$", ErrorMessage = "Invalid password. It must be at least 8 characters long and include at least one letter, one digit, and one special character.")]      
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string? RetypePassword { get; set; }

        public bool AgreeTerms { get; set; } = false;
    }
}
