//using AstroOffice.VO;
using AstroOffice.Models;
using System;
using System.Data;
using System.Data.Objects;

namespace AstroOffice.DAl
{
    internal class DALVfalUpay
    {
        private readonly astroDataContainer _asdc;

        public DALVfalUpay()
        {
            _asdc = new astroDataContainer();
        }

        public int Update_upay(A_upay updateupay)
        {
            int num = 0;

            //EntityKey entityKey = null;
            //object obj = null;
            //entityKey = this.asdc.CreateEntityKey("A_upay", updateupay);
            //if (!this.asdc.TryGetObjectByKey(entityKey, out obj))
            //{
            //    this.asdc.Attach(updateupay);
            //}
            //else
            //{
            //    this.asdc.ApplyPropertyChanges(entityKey.EntitySetName, updateupay);
            //    num = 1;
            //}

            var entity = this._asdc.Set<A_upay>().Find(updateupay);
            if (entity == null)
            {
                this._asdc.A_upay.Attach(updateupay);
            }
            else
            {
                this._asdc.Entry(entity).CurrentValues.SetValues(updateupay);
                num = 1;
            }

            this._asdc.SaveChanges();

            return num;
        }

        public int UpdateVfalUpay(A_vfal_upay updatevfal)
        {
            int num = 0;
            //EntityKey entityKey = null;
            //object obj = null;
            //entityKey = this.asdc.CreateEntityKey("A_vfal_upay", updatevfal);
            //if (!this.asdc.TryGetObjectByKey(entityKey, out obj))
            //{
            //    this.asdc.Attach(updatevfal);
            //}
            //else
            //{
            //    this.asdc.ApplyPropertyChanges(entityKey.EntitySetName, updatevfal);
            //    num = 1;
            //}

            var entity = this._asdc.Set<A_vfal_upay>().Find(updatevfal);
            if (entity == null)
            {
                this._asdc.A_vfal_upay.Attach(updatevfal);
            }
            else
            {
                this._asdc.Entry(entity).CurrentValues.SetValues(updatevfal);
                num = 1;
            }

            this._asdc.SaveChanges();

            return num;
        }
    }
}