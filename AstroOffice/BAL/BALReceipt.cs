using AstroOffice.DAl;
using System;
//using AstroOffice.VO;
using AstroOffice.Models;

namespace AstroOffice.BAL
{
    internal class BALReceipt
    {
        private DALReceipt drpt = new DALReceipt();

        public BALReceipt()
        {
        }

        public a_appointment GetAppointmentReferenceNumber(string refnumber)
        {
            return this.drpt.GetAppointmentReferenceNumber(refnumber);
        }

        public a_callorder GetOrderRefernceNumber(string refnumber)
        {
            return this.drpt.GetOrderRefernceNumber(refnumber);
        }

        public a_receipt GetReceiptSno(long rcptno)
        {
            return this.drpt.GetReceiptSno(rcptno);
        }

        public bool SubmitDDDetail(a_DDdetail arcpt, long rcptid)
        {
            bool flag;
            try
            {
                this.drpt.SubmitDDDetail(arcpt, rcptid);
                flag = true;
            }
            catch (Exception exception)
            {
                _ = exception;

                flag = false;
            }
            return flag;
        }

        public bool SubmitReciept(a_receipt arcpt)
        {
            bool flag;
            try
            {
                this.drpt.SubmitReciept(arcpt);
                flag = true;
            }
            catch (Exception exception)
            {
                _ = exception;
                flag = false;
            }
            return flag;
        }
    }
}