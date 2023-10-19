using System.ComponentModel.DataAnnotations;

namespace AstroOfficeWeb.Client.Models
{
    public class LoginWithOtpModel
    {
        [Required(ErrorMessage = "Mobile number is required")]
        public string? MobileNumber { get; set; }
    }
}
