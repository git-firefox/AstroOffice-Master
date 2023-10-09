using System;
using System.Collections.Generic;
using AstroOffice.DAl;
using AstroOffice.Models;
//using AstroOffice.VO;

namespace AstroOffice.BAL
{
    internal class BALAppointment
    {
        private readonly DALAppointment _dla;

        public BALAppointment()
        {
            _dla = new DALAppointment();
        }

        public a_appointment AddAppointment(a_appointment a, long hcelvalue)
        {
            return this._dla.AddAppointment(a, hcelvalue);
        }

        public int AppointmentUpdate(a_appointment acl)
        {
            return this._dla.AppointmentUpdate(acl);
        }

        public bool DeleteAppointment(a_appointment apmnt)
        {
            return this._dla.DeleteAppointment(apmnt);
        }

        public IEnumerable<a_appointment> GetAppointDate(DateTime apdate)
        {
            return this._dla.GetAppointDate(apdate);
        }

        public a_appointment GetAppointmentDate(DateTime appdate)
        {
            return this._dla.GetAppointmentDate(appdate);
        }

        public a_appointment GetAppointmentReferenceNumber(string refnumber)
        {
            return this._dla.GetAppointmentReferenceNumber(refnumber);
        }

        public a_appointment GetAppointmentSNumber(long sno)
        {
            return this._dla.GetAppointmentSNumber(sno);
        }

        public IEnumerable<time_master> GetAppointmentTime()
        {
            return this._dla.GetAppointmentTime();
        }

        public IEnumerable<a_appointment> GetCancellationStatus(DateTime appdate)
        {
            return this._dla.GetCancellationStatus(appdate);
        }

        public IEnumerable<a_appointment> GetCancelledList()
        {
            return this._dla.GetCancelledList();
        }

        public object GetNextAvailable()
        {
            return this._dla.GetNextAvailable();
        }

        public a_appointment SearchAppointmentSNumber(long sno)
        {
            return this._dla.SearchAppointmentSNumber(sno);
        }
    }
}