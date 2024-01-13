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

    public class UserListItemModel : BaseUserDTO
    {
        public UserListItemModel() { }
        public UserListItemModel(SaveUserModel userModel)
        {
            Sno = userModel.Sno;
            Username = userModel.Username;
            MobileNumber = userModel.MobileNumber;
            Role = userModel.Role;
            Status = userModel.Status;
            CanAdd = userModel.CanAdd;
            CanEdit = userModel.CanEdit;
            CanReport = userModel.CanReport;
            AdminUser = userModel.AdminUser;
            Role = userModel.Role;
        }
    }

    public class SaveUserModel : SaveUserDTO
    {
        public string? Password { get; set; }
        public string? RetypePassword { get; set; }

        public SaveUserModel() { }
        public SaveUserModel(UserListItemModel userList)
        {
            Sno = userList.Sno;
            Username = userList.Username;
            MobileNumber = userList.MobileNumber;
            Role = userList.Role;
            Status = userList.Status;
            CanAdd = userList.CanAdd;
            CanEdit = userList.CanEdit;
            CanReport = userList.CanReport;
            AdminUser = userList.AdminUser;
        }
    }
}