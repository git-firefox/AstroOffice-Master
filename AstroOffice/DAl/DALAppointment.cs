using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using AstroOffice.Models;
//using AstroOffice.VO;

namespace AstroOffice.DAl
{
    internal class DALAppointment
    {
        private readonly AstrooffContext _context ;

        public DALAppointment()
        {
            _context = new AstrooffContext();
        }

        public a_appointment AddAppointment(a_appointment a, long hcelvalue)
        {
            //this.adc.AddToa_appointment(a);
            //this.adc.SaveChanges();
            //EntityKey entityKey = null;
            //object obj = null;
            //try
            //{
            //    DateTime value = a.appDate.Value;
            //    int year = value.Year;
            //    string str = year.ToString();
            //    value = a.appDate.Value;
            //    year = value.Month;
            //    string str1 = year.ToString();
            //    value = a.appDate.Value;
            //    year = value.Day;
            //    a.referenceno = string.Concat(str, str1, year.ToString(), hcelvalue.ToString());
            //}
            //catch (Exception exception)
            //{
            //    MessageBox.Show("Check the date formate dd/mm/yyyy");
            //}
            //entityKey = this.adc.CreateEntityKey("a_appointment", a);
            //if (!this.adc.TryGetObjectByKey(entityKey, out obj))
            //{
            //    this.adc.Attach(a);
            //}
            //else
            //{
            //    this.adc.ApplyPropertyChanges(entityKey.EntitySetName, a);
            //}
            //this.adc.SaveChanges();
            //return a;

            try
            {
                DateTime value = a.appDate.Value;
                int year = value.Year;
                string str = year.ToString();
                value = a.appDate.Value;
                year = value.Month;
                string str1 = year.ToString();
                value = a.appDate.Value;
                year = value.Day;
                a.referenceno = string.Concat(str, str1, year.ToString(), hcelvalue.ToString());
                this._context.a_appointment.Add(a);
                this._context.SaveChanges();
            }
            catch (Exception exception)
            {
                _ = exception;
                MessageBox.Show("Check the date formate dd/mm/yyyy");
            }
            return a;
        }

        public int AppointmentUpdate(a_appointment acl)
        {
            //EntityKey entityKey = null;
            //object obj = null;
            //int num = 0;
            //entityKey = this.adc.CreateEntityKey("a_appointment", acl);
            //if (!this.adc.TryGetObjectByKey(entityKey, out obj))
            //{
            //    this.adc.Attach(acl);
            //}
            //else
            //{
            //    this.adc.ApplyPropertyChanges(entityKey.EntitySetName, acl);
            //    num = 1;
            //}
            //this.adc.SaveChanges();
            //return num;

            int num;

            var entry = _context.Entry(acl);

            if (entry.State == System.Data.Entity.EntityState.Detached)
            {
                _context.Set<a_appointment>().Attach(acl);
                entry.State = System.Data.Entity.EntityState.Modified;
            }

            try
            {
                num = _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _ = ex;
                num = 0;
            }

            return num;
        }

        public bool DeleteAppointment(a_appointment apmnt)
        {
            //bool flag;
            //try
            //{
            //    a_appointment aAppointment = (
            //        from tt in this.adc.a_appointment
            //        where tt.sno == apmnt.sno && tt.booked == (bool?)true && tt.cancelled == (bool?)false
            //        select tt).FirstOrDefault<a_appointment>();
            //    this.adc.DeleteObject(aAppointment);
            //    this.adc.SaveChanges();
            //    flag = true;
            //}
            //catch (Exception exception)
            //{
            //    MessageBox.Show(exception.Message);
            //    flag = false;
            //}
            //return flag;

            bool flag;
            try
            {
                a_appointment aAppointment = this._context.a_appointment.First(tt => tt.sno == apmnt.sno && tt.booked == true && tt.cancelled == false);
                this._context.a_appointment.Remove(aAppointment);
                this._context.SaveChanges();
                flag = true;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                flag = false;
            }
            return flag;
        }

        public IEnumerable<a_appointment> GetAppointDate(DateTime apdate)
        {
            IEnumerable<a_appointment> list;
            try
            {
                list = this._context.a_appointment.Where(aa => aa.appDate == apdate).ToList<a_appointment>();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                list = null;
            }
            return list;
        }

        public a_appointment GetAppointmentDate(DateTime appdate)
        {
            a_appointment aAppointment = (
                from tt in this._context.a_appointment
                where tt.appDate == (DateTime?)appdate
                select tt).FirstOrDefault<a_appointment>();
            return aAppointment;
        }

        public a_appointment GetAppointmentReferenceNumber(string refnumber)
        {
            a_appointment aAppointment = (
                from tt in this._context.a_appointment
                where tt.referenceno == refnumber
                select tt).FirstOrDefault<a_appointment>();
            return aAppointment;
        }

        public a_appointment GetAppointmentSNumber(long sno)
        {
            a_appointment aAppointment = (
                from tt in this._context.a_appointment
                where tt.sno == sno && tt.cancelled == (bool?)false
                select tt).FirstOrDefault<a_appointment>();
            return aAppointment;
        }

        public IEnumerable<time_master> GetAppointmentTime()
        {
            IEnumerable<time_master> list = (
                from tt in this._context.time_master
                where tt.slotstatus == (bool?)true
                select tt).ToList<time_master>();
            return list;
        }

        public IEnumerable<a_appointment> GetCancellationStatus(DateTime appdate)
        {
            IEnumerable<a_appointment> list = (
                from tt in this._context.a_appointment
                where (tt.appDate == (DateTime?)appdate) && tt.cancelled == (bool?)true && tt.confirmed == (bool?)false
                select tt).ToList<a_appointment>();
            return list;
        }

        public IEnumerable<a_appointment> GetCancelledList()
        {
            IEnumerable<a_appointment> list = (
                from tt in this._context.a_appointment
                where tt.cancelled == (bool?)true && (tt.appDate > (DateTime?)DateTime.Now)
                select tt).ToList<a_appointment>();
            return list;
        }

        public object GetNextAvailable()
        {
            object obj;
            try
            {
                DateTime? nullable = (
                    from t in this._context.a_appointment
                    where t.booked == (bool?)true
                    select t).Max<a_appointment, DateTime?>((a_appointment t) => t.appDate);
                obj = (!nullable.HasValue ? nullable : nullable);
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                MessageBox.Show(string.Concat("No Previous Record Found..!!\n", exception.Message));
                obj = null;
            }
            return obj;
        }

        public a_appointment SearchAppointmentSNumber(long sno)
        {
            a_appointment aAppointment = (
                from tt in this._context.a_appointment
                where tt.sno == sno && tt.cancelled == (bool?)true && tt.booked == (bool?)false && tt.confirmed == (bool?)false
                select tt).FirstOrDefault<a_appointment>();
            return aAppointment;
        }
    }
}