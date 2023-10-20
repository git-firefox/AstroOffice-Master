using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroOfficeWeb.Shared.Models
{
    public class SignUpRequest
    {
        [Required(ErrorMessage = "Name is required")]
        public string? UserName { get; set; }

        public string? PhoneNumber { get; set; }


        [Required(ErrorMessage = "Password is required.")]
        public string? Password { get; set; }
    }
}
