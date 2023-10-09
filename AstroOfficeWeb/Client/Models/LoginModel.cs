using System.ComponentModel.DataAnnotations;

namespace AstroOfficeWeb.Client.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "UserName is required.")]
        //[EmailAddress(ErrorMessage = "Invalid email address.")]
        public string UserName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        public bool RememberMe { get; set; }
    }
}
