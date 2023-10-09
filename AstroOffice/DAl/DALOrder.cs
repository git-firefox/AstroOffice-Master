using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Objects;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
//using AstroOffice.VO;
using AstroOffice.Models;

namespace AstroOffice.DAl
{
    internal class DALOrder
    {
        private astroDataContainer asdc = new astroDataContainer();

        //private a_callorder aco = new a_callorder();

        public DALOrder()
        {
        }

        public a_callorder AddOrder(a_callorder aco, DateTime orderdate)
        {
            //this.asdc.AddToa_callorder(aco);
            //this.asdc.SaveChanges();
            //EntityKey entityKey = null;
            //object obj = null;
            //int year = orderdate.Year;
            //string str = year.ToString();
            //year = orderdate.Month;
            //string str1 = year.ToString();
            //year = orderdate.Day;
            //string str2 = year.ToString();
            //long num = aco.sno;
            //aco.refnumber = string.Concat(str, str1, str2, num.ToString());
            //entityKey = this.asdc.CreateEntityKey("a_callorder", aco);
            //if (!this.asdc.TryGetObjectByKey(entityKey, out obj))
            //{
            //    this.asdc.Attach(aco);
            //}
            //else
            //{
            //    this.asdc.ApplyPropertyChanges(entityKey.EntitySetName, aco);
            //}
            //this.asdc.SaveChanges();
            //return aco;

            aco.refnumber = string.Concat(orderdate.Year, orderdate.Month, orderdate.Day, aco.sno);
            this.asdc.a_callorder.Add(aco);
            this.asdc.SaveChanges();

            var existingEntity = asdc.Set<a_callorder>().Find(aco);
            if (existingEntity == null)
            {
                this.asdc.a_callorder.Attach(aco);
            }
            else
            {
                this.asdc.Entry(aco).CurrentValues.SetValues(aco);
            }

            this.asdc.SaveChanges();

            return aco;
        }

        public IEnumerable<a_callorder> GetOrderDetail()
        {
            IEnumerable<a_callorder> list =
                from u in this.asdc.a_callorder.ToList<a_callorder>()
                orderby u.sno
                select u;
            return list;
        }

        public a_callorder GetOrderRefernceNumber(string refnumber)
        {
            a_callorder aCallorder = (
                from tt in this.asdc.a_callorder
                where tt.refnumber == refnumber
                select tt).FirstOrDefault<a_callorder>();
            return aCallorder;
        }

        public a_callorder GetSelectedOrder(long sno)
        {
            a_callorder aCallorder = (
                from uu in this.asdc.a_callorder
                where uu.sno == sno
                select uu).FirstOrDefault<a_callorder>();
            return aCallorder;
        }

        public int UpdateOrder(a_callorder acl)
        {
            int num;

            //EntityKey entityKey = null;
            //object obj = null;
            //entityKey = this.asdc.CreateEntityKey("a_callorder", acl);
            //if (!this.asdc.TryGetObjectByKey(entityKey, out obj))
            //{
            //    this.asdc.Attach(acl);
            //}
            //else
            //{
            //    this.asdc.ApplyPropertyChanges(entityKey.EntitySetName, acl);
            //    num = 1;
            //}

            var existingEntity = asdc.Set<a_callorder>().Find(acl);
            if (existingEntity == null)
            {
                this.asdc.a_callorder.Attach(acl);
            }
            else
            {
                this.asdc.Entry(acl).CurrentValues.SetValues(acl);
            }

            num = this.asdc.SaveChanges();

            return num;
        }
    }
}