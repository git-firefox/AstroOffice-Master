using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AstroOfficeWeb.Shared.Utilities;

namespace AstroOfficeWeb.Shared.DTOs
{
    public class UserPermission
    {
        public bool AdminUser { get; set; }
        public bool CanEdit { get; set; }
        public bool CanReport { get; set; }
        public bool CanAdd { get; set; }
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
