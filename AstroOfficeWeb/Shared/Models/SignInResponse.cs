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
        public string? Message { get; set; }
        public string? Token { get; set; }
        public UserDTO? UserDTO { get; set; }

    }
}
