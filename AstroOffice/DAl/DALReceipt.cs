using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
//using AstroOffice.VO;
using AstroOffice.Models;

namespace AstroOffice.DAl
{
    internal class DALReceipt
    {
        private readonly astroDataContainer _astroDataContainer;

        public DALReceipt()
        {
            _astroDataContainer = new astroDataContainer();
        }

        public a_appointment GetAppointmentReferenceNumber(string refnumber)
        {
            a_appointment aAppointment;
            try
            {
                aAppointment = (
                    from tt in this._astroDataContainer.a_appointment
                    where (tt.referenceno == refnumber) && tt.booked == (bool?)true && tt.cancelled == (bool?)false
                    select tt).FirstOrDefault<a_appointment>();
            }
            catch
            {
                aAppointment = null;
            }
            return aAppointment;
        }

        public a_callorder GetOrderRefernceNumber(string refnumber)
        {
            a_callorder aCallorder;
            try
            {
                aCallorder = (
                    from tt in this._astroDataContainer.a_callorder
                    where tt.refnumber == refnumber
                    select tt).FirstOrDefault<a_callorder>();
            }
            catch
            {
                aCallorder = null;
            }
            return aCallorder;
        }

        public a_receipt GetReceiptSno(long rcptno)
        {
            a_receipt aReceipt;
            try
            {
                aReceipt = (
                    from tt in this._astroDataContainer.a_receipt
                    where tt.receiptSno == (long?)rcptno
                    select tt).FirstOrDefault<a_receipt>();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
                aReceipt = null;
            }
            return aReceipt;
        }

        public void SubmitDDDetail(a_DDdetail rcpt, long rcptid)
        {
            try
            {
                //KeyValuePair<string, object>[] keyValuePair = new KeyValuePair<string, object>[] { new KeyValuePair<string, object>("sno", (object)rcptid) };
                //IEnumerable<KeyValuePair<string, object>> keyValuePairs = keyValuePair;
                ////astroDataContainer _astroDataContainer = new astroDataContainer();
                //EntityKey entityKey = new EntityKey("astroDataContainer.a_receipt", keyValuePairs);
                //rcpt.a_receiptReference.EntityKey = entityKey;
                rcpt.sno = rcptid;
                this._astroDataContainer.a_DDdetail.Add(rcpt);
                this._astroDataContainer.SaveChanges();
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                MessageBox.Show(string.Concat("Error in insertion..!!", exception.ToString()));
            }
        }

        public bool SubmitReciept(a_receipt arcpt)
        {
            bool flag;
            try
            {
                this._astroDataContainer.a_receipt.Add(arcpt);
                this._astroDataContainer.SaveChanges();
                flag = true;
            }
            catch (Exception exception)
            {
                _ = exception;
                MessageBox.Show("Error in insertion..!!");
                flag = false;
            }
            return flag;
        }
    }
}