using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AstroOfficeWeb.Shared.DTOs;
using AstroOfficeWeb.Shared.Utilities;


namespace AstroOfficeWeb.Shared.ViewModels
{

    public class UserViewModel : UserDTO
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
