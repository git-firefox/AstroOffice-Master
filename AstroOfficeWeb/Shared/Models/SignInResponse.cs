using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AstroOfficeWeb.Shared.DTOs;

using Newtonsoft.Json;

namespace AstroOfficeWeb.Shared.Models
{

    public class SignInResponse : ApiResponse<BaseUserDTO>
    {
        public string? Token { get; set; }
    }
}
