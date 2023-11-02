using System.ComponentModel.DataAnnotations;

namespace AstroShared.ViewModels
{
    public class LoginWithOtpModel
    {
        [Display(Name = "Mobile Number")]
        [Required(ErrorMessage = "{0} is required")]
        public string? MobileNumber { get; set; }
    }
}
