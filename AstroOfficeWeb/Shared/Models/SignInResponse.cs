using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AstroOfficeWeb.Shared.DTOs;

namespace AstroOfficeWeb.Shared.Models
{
    public class SignInResponse
    {
        public bool IsAuthSuccessful { get; set; }
        public string? ErrorMessage { get; set; }
        public string? Token { get; set; }
        public AUserDTO? UserDTO { get; set; }

    }
}
