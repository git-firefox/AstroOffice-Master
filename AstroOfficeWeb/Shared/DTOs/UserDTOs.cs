using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AstroOfficeWeb.Shared.Utilities;
using AstroOfficeWeb.Shared.ViewModels;

namespace AstroOfficeWeb.Shared.DTOs
{

    public class BaseUserDTO 
    {
        public long Sno { get; set; }
        public string Username { get; set; } = null!;
        public bool AdminUser { get; set; }
        public bool CanAdd { get; set; }
        public bool CanEdit { get; set; }
        public bool CanReport { get; set; }
        public bool Active { get; set; }
        public string? MobileNumber { get; set; }
        public UserRole Role { get; set; }
        public UserStatus Status { get; set; }
    }

    public class SaveUserDTO : BaseUserDTO
    {
        public string? HashedPassword { get; set; }
    }


    public class UserPermission
    {
        public bool AdminUser { get; set; } = false;
        public bool CanEdit { get; set; } = false;
        public bool CanReport { get; set; } = false;
        public bool CanAdd { get; set; } = false;
    }

    public class UserDTO : UserPermission
    {
        [Display(Name = "Username")]
        public string? UserName { get; set; }
        public long ActiveUserId { get; set; }

        public long Sno { get; set; }

        [Display(Name = "Mobile Number")]
        public string MobileNumber { get; set; } = null!;

        public string PasswordHash { get; set; } = null!;

        [Display(Name = "Role")]
        public UserRole Role { get; set; }

        [Display(Name = "Status")]
        public UserStatus Status { get; set; }
    }
}
