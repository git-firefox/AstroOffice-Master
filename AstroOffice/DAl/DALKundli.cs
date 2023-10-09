using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
//using AstroOffice.VO;
using AstroOffice.Models;

namespace AstroOffice.DAl
{
    internal class DALKundli
    {
        private readonly astroDataContainer _adc;

        public DALKundli()
        {
            _adc = new astroDataContainer();
        }

        public IEnumerable<A_kundlis> GetAllKundliByDate(DateTime fromdate, DateTime todate)
        {
            IEnumerable<A_kundlis> list = (
                from tt in this._adc.A_kundlis
                where (tt.entrytime >= (DateTime?)fromdate) && (tt.entrytime <= (DateTime?)todate)
                select tt).ToList<A_kundlis>();
            return list;
        }

        public int UpdateKundli(A_kundlis ak)
        {
            //EntityKey entityKey = null;
            //object obj = null;
            //int num = 0;
            //entityKey = this.adc.CreateEntityKey("A_kundlis", ak);
            //if (!this.adc.TryGetObjectByKey(entityKey, out obj))
            //{
            //    this.adc.Attach(ak);
            //}
            //else
            //{
            //    this.adc.ApplyPropertyChanges(entityKey.EntitySetName, ak);
            //    num = 1;
            //}
            //this.adc.SaveChanges();
            //return num;

            //EntityKey entityKey = null;
            //object obj = null;


            int num = 0;

            var entityEntry = _adc.Entry(ak);

            if (entityEntry.State == System.Data.Entity.EntityState.Detached)
            {
                _adc.A_kundlis.Attach(ak);
                entityEntry.State = System.Data.Entity.EntityState.Modified;
            }
            else
            {
                var existingEntity = _adc.Set<A_kundlis>().Find(ak); 
                if (existingEntity != null)
                {
                    _adc.Entry(existingEntity).CurrentValues.SetValues(ak);
                    num = 1;
                }
            }

            try
            {
                num += _adc.SaveChanges();
            }
            catch (Exception) 
            {
                // Handle concurrency exception if needed
            }

            return num;
        }

        //public int UpdateKundliSM(A_kundlisSM ak)
        //{
        //    EntityKey entityKey = null;
        //    object obj = null;
        //    int num = 0;
        //    entityKey = this._adc.CreateEntityKey("A_kundlisSM", ak);
        //    if (!this._adc.TryGetObjectByKey(entityKey, out obj))
        //    {
        //        this._adc.Attach(ak);
        //    }
        //    else
        //    {
        //        this._adc.ApplyPropertyChanges(entityKey.EntitySetName, ak);
        //        num = 1;
        //    }
        //    this._adc.SaveChanges();
        //    return num;
        //}
    }
}