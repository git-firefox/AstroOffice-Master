using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroShared.ViewModels
{

    public abstract class BaseUserViewModel
    {
        public long Sno { get; set; }

        [Display(Name = "Username")]
        public string UserName { get; set; } = null!;

        [Display(Name = "Mobile Number")]
        public string MobileNumber { get; set; } = null!;

        [Display(Name = "Role")]
        public UserRole Role { get; set; }

        [Display(Name = "Status")]
        public UserStatus Status { get; set; }
        public bool CanReport { get; set; }
        public bool CanEdit { get; set; }
        public bool CanAdd { get; set; }
    }

    public class UserViewModel : BaseUserViewModel
    {
        public string Password { get; set; } = null!;
        public string RetypePassword { get; set; } = null!;

        public UserViewModel() { }
        public UserViewModel(UserViewModel original)
        {
            if (original == null)
            {
                throw new ArgumentNullException(nameof(UserViewModel));
            }
            Sno = original.Sno;
            UserName = original.UserName;
            MobileNumber = original.MobileNumber;
            Role = original.Role;
            Status = original.Status;
        }

    }
}
