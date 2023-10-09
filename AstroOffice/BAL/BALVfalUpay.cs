using AstroOffice.DAl;
//using AstroOffice.VO;
using AstroOffice.Models;
using System;

namespace AstroOffice.BAL
{
    internal class BALVfalUpay
    {
        private readonly DALVfalUpay dalvfal;

        public BALVfalUpay()
        {
            dalvfal = new DALVfalUpay();
        }

        public int Update_Upay(A_upay updateupay)
        {
            return this.dalvfal.Update_upay(updateupay);
        }

        public int UpdateVfalUpay(A_vfal_upay updatevfal)
        {
            return this.dalvfal.UpdateVfalUpay(updatevfal);
        }
    }
}