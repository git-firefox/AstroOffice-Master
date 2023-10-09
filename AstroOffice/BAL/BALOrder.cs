using System;
using System.Collections.Generic;
using AstroOffice.DAl;
//using AstroOffice.VO;
using AstroOffice.Models;

namespace AstroOffice.BAL
{
    internal class BALOrder
    {
        private readonly DALOrder _dalorobj;

        public BALOrder()
        {
            _dalorobj = new DALOrder();
        }

        public a_callorder AddOrder(a_callorder aordrcall, DateTime orderdate)
        {
            return this._dalorobj.AddOrder(aordrcall, orderdate);
        }

        public IEnumerable<a_callorder> GetOrderDetail()
        {
            return this._dalorobj.GetOrderDetail();
        }

        public a_callorder GetOrderRefernceNumber(string refnumber)
        {
            return this._dalorobj.GetOrderRefernceNumber(refnumber);
        }

        public a_callorder GetSelectedOrder(long sno)
        {
            return this._dalorobj.GetSelectedOrder(sno);
        }

        public int UpdateOrder(a_callorder aodr)
        {
            return this._dalorobj.UpdateOrder(aodr);
        }
    }
}