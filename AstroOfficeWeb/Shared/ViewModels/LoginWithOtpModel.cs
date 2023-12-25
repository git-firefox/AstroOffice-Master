using System.ComponentModel.DataAnnotations;

namespace AstroOfficeWeb.Shared.ViewModels
{
    public class LoginWithOtpModel
    {
        [Display(Name = "Mobile Number")]
        [Required(ErrorMessage = "{0} is required")]
        public string? MobileNumber { get; set; }
    }
}
