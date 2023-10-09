using System;
using System.Collections.Generic;
using AstroOffice.DAl;
//using AstroOffice.VO;
using AstroOffice.Models;

namespace AstroOffice.BAL
{
    internal class BALTimeDistribution
    {
        private readonly DALTimeDistribution _dt;

        public BALTimeDistribution()
        {
            _dt = new DALTimeDistribution();
        }

        public void AddTimeDistribution(time_master at)
        {
            this._dt.AddTimeDistribution(at);
        }

        public IEnumerable<time_master> Display()
        {
            return this._dt.Display();
        }

        public IEnumerable<time_master> GetPreSlotTime(int preslot)
        {
            return this._dt.GetPreSlotTime(preslot);
        }

        public time_master GetSelectedSlot(int slot)
        {
            return this._dt.GetSelectedSlot(slot);
        }

        public time_master GetSelectedSno(long sno, int slot)
        {
            return this._dt.GetSelectedSno(sno, slot);
        }

        public IEnumerable<time_master> GetSlots()
        {
            return this._dt.GetSlots();
        }

        public int UpdateAppointmentTime(time_master tm)
        {
            return this._dt.UpdateAppointmentTime(tm);
        }
    }
}