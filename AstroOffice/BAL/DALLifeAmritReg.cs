using AstroOffice.VO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Objects;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace AstroOffice.BAL
{
    internal class DALLifeAmritReg
    {
        private astroDataContainer adcObj = new astroDataContainer();

        public DALLifeAmritReg()
        {
        }

        public la_userreg AddRenewalDetails(la_userreg obj)
        {
            la_userreg laUserreg;
            try
            {
                EntityKey entityKey = null;
                object obj1 = null;
                entityKey = this.adcObj.CreateEntityKey("la_userreg", obj);
                if (!this.adcObj.TryGetObjectByKey(entityKey, out obj1))
                {
                    this.adcObj.Attach(obj);
                    this.adcObj.SaveChanges();
                    laUserreg = obj;
                }
                else
                {
                    this.adcObj.ApplyPropertyChanges(entityKey.EntitySetName, obj);
                    this.adcObj.SaveChanges();
                    laUserreg = obj;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                laUserreg = null;
            }
            return laUserreg;
        }

        public la_userreg AddUser(la_userreg objusr)
        {
            la_userreg laUserreg;
            try
            {
                string lower = objusr.name.Trim().ToLower();
                int hashCode = Guid.NewGuid().ToString().GetHashCode();
                objusr.pinno = string.Concat(lower, hashCode.ToString("x").Trim(), 1);
                this.adcObj.AddTola_userreg(objusr);
                this.adcObj.SaveChanges();
                EntityKey entityKey = null;
                object obj = null;
                DateTime value = objusr.dob.Value;
                hashCode = value.Year;
                string str = hashCode.ToString();
                value = objusr.dob.Value;
                hashCode = value.Month;
                string str1 = hashCode.ToString();
                value = objusr.dob.Value;
                hashCode = value.Day;
                string str2 = hashCode.ToString();
                long num = objusr.sno;
                objusr.refno = new long?(Convert.ToInt64(string.Concat(str, str1, str2, num.ToString())));
                entityKey = this.adcObj.CreateEntityKey("la_userreg", objusr);
                if (!this.adcObj.TryGetObjectByKey(entityKey, out obj))
                {
                    this.adcObj.Attach(objusr);
                }
                else
                {
                    this.adcObj.ApplyPropertyChanges(entityKey.EntitySetName, objusr);
                }
                this.adcObj.SaveChanges();
                laUserreg = objusr;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message.ToString());
                laUserreg = null;
            }
            return laUserreg;
        }

        public IEnumerable<la_userreg> GetAllListUser()
        {
            return this.adcObj.la_userreg.ToList<la_userreg>();
        }

        public la_userreg GetSelectedUser(long refno, string pin, string email, bool activationstatus)
        {
            la_userreg laUserreg = (
                from tt in this.adcObj.la_userreg
                where tt.refno == (long?)refno && (tt.pinno == pin) && (tt.emailId == email) && tt.activationstatus == (bool?)activationstatus
                select tt).First<la_userreg>();
            return laUserreg;
        }

        public IEnumerable<a_state_master> GetState(string ctrycode)
        {
            IEnumerable<a_state_master> aStateMaster =
                from tt in this.adcObj.a_state_master
                where tt.country_code == ctrycode.Trim()
                select tt;
            return aStateMaster;
        }

        public IEnumerable<la_userreg> GetUserAll()
        {
            IEnumerable<la_userreg> list = (
                from tt in this.adcObj.la_userreg
                where tt.sno > (long)0
                select tt).ToList<la_userreg>();
            return list;
        }

        public IEnumerable<la_userreg> GetUserAll(long refno)
        {
            IEnumerable<la_userreg> list = (
                from tt in this.adcObj.la_userreg
                where tt.sno > (long)0 && tt.refno == (long?)refno
                select tt).ToList<la_userreg>();
            return list;
        }
    }
}