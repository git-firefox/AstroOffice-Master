using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroOfficeWeb.Shared.Models
{
    public class SignInWithOtpRequest
    {
        [Required(ErrorMessage = "UserName is required")]
        public string? Otp { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string? MobileNumber { get; set; }
    }
}
