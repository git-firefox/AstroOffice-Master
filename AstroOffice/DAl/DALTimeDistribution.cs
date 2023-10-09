using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Objects;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
//using AstroOffice.VO;
using AstroOffice.Models;

namespace AstroOffice.DAl
{
    internal class DALTimeDistribution
    {
        private astroDataContainer adc = new astroDataContainer();

        public DALTimeDistribution()
        {
        }

        public void AddTimeDistribution(time_master at)
        {
            this.adc.time_master.Add(at);
            this.adc.SaveChanges();
            MessageBox.Show("Time Allocation have been done successfully..!!");
        }

        public IEnumerable<time_master> Display()
        {
            return this.adc.time_master.ToList<time_master>();
        }

        public IEnumerable<time_master> GetPreSlotTime(int preslot)
        {
            IEnumerable<time_master> list = (
                from tt in this.adc.time_master
                where tt.slot == (int?)preslot
                select tt).ToList<time_master>();
            return list;
        }

        public time_master GetSelectedSlot(int slot)
        {
            time_master timeMaster = (
                from uu in this.adc.time_master
                where uu.slot == (int?)slot
                select uu).FirstOrDefault<time_master>();
            return timeMaster;
        }

        public time_master GetSelectedSno(long sno, int slot)
        {
            time_master timeMaster = (
                from uu in this.adc.time_master
                where uu.sno == sno && uu.slot == (int?)slot
                select uu).FirstOrDefault<time_master>();
            return timeMaster;
        }

        public IEnumerable<time_master> GetSlots()
        {
            IEnumerable<time_master> list = (
                from ap in this.adc.time_master
                orderby ap.slot
                select ap).ToList<time_master>();
            return list;
        }

        public int UpdateAppointmentTime(time_master tm)
        {

            int num = 0;
            //EntityKey entityKey = null;
            //object obj = null;
            //entityKey = this.adc.CreateEntityKey("time_master", tm);
            //if (!this.adc.TryGetObjectByKey(entityKey, out obj))
            //{
            //    this.adc.Attach(tm);
            //}
            //else
            //{
            //    this.adc.ApplyPropertyChanges(entityKey.EntitySetName, tm);
            //    num = 1;
            //}
            var existingEntity = this.adc.Set<time_master>().Find(tm);
            if (existingEntity == null)
            {
                this.adc.time_master.Attach(tm);
            }
            else
            {
                this.adc.Entry(existingEntity).CurrentValues.SetValues(tm);
                num = 1;
            }

            this.adc.SaveChanges();
            return num;
        }
    }
}