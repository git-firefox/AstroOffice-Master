//using AstroOffice.VO;
using AstroOffice.DAl;
using AstroOffice.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AstroOffice.BAL
{
    internal class BALLifeAmritReg
    {
        private DALLifeAmritReg uregobj = new DALLifeAmritReg();

        public BALLifeAmritReg()
        {
        }

        public la_userreg AddRenewalDetails(la_userreg obj)
        {
            return this.uregobj.AddRenewalDetails(obj);
        }

        public la_userreg AddUser(la_userreg objreg)
        {
            return this.uregobj.AddUser(objreg);
        }

        public IEnumerable<la_userreg> GetAllListUser()
        {
            return this.uregobj.GetAllListUser();
        }

        public la_userreg GetSelectedUser(long refno, string pin, string email, bool activationstatus)
        {
            la_userreg selectedUser;
            try
            {
                selectedUser = this.uregobj.GetSelectedUser(refno, pin, email, activationstatus);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                selectedUser = null;
            }
            return selectedUser;
        }

        public IEnumerable<a_state_master> GetState(string ctrycode)
        {
            return this.uregobj.GetState(ctrycode);
        }

        public IEnumerable<la_userreg> GetUserAllUser()
        {
            return this.uregobj.GetUserAll();
        }

        public IEnumerable<la_userreg> GetUserAllUser(long refno)
        {
            return this.uregobj.GetUserAll(refno);
        }
    }
}