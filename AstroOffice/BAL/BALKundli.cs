using System;
using System.Collections.Generic;
using System.Linq;
using AstroOffice.DAl;
using AstroOffice.Models;
//using AstroOffice.VO;

namespace AstroOffice.BAL
{
    internal class BALKundli
    {
        private DALKundli dalcount = new DALKundli();

        public BALKundli()
        {
        }

        public IEnumerable<A_kundlis> GetAllKundliByDate(DateTime fromdate, DateTime todate)
        {
            IEnumerable<A_kundlis> list = this.dalcount.GetAllKundliByDate(fromdate, todate).ToList<A_kundlis>();
            return list;
        }

        public int UpdateKundli(A_kundlis ak)
        {
            return this.dalcount.UpdateKundli(ak);
        }

        //public int UpdateKundliSM(A_kundlisSM ak)
        //{
        //    return this.dalcount.UpdateKundliSM(ak);
        //}
    }
}