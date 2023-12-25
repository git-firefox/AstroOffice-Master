using System;
using System.Data;
using AstroOfficeWeb.Shared.VOs;
//using AstroShared.Models;
namespace ASDLL.DataAccess.Core
{
    public class UserManagement
    {
        public UserManagement()
        {
        }

        public UsersVO AstroLogin(string username, string password)
        {
            UsersVO usersVO = new UsersVO();
            DataTable dataTable = (new UserDAO()).AstroLogin(username, password);
            if (dataTable.Rows.Count <= 0)
            {
                usersVO = null;
            }
            else
            {
                usersVO.Username = dataTable.Rows[0]["username"].ToString();
                usersVO.Sno = Convert.ToInt64(dataTable.Rows[0]["sno"].ToString());
                usersVO.Password = dataTable.Rows[0]["password"].ToString();
                usersVO.Active = Convert.ToBoolean(dataTable.Rows[0]["active"]);
            }
            return usersVO;
        }
    }
}