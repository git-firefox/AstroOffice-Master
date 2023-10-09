using System;
using AstroOffice.DAl;
//using AstroOffice.VO;
using AstroOffice.Models;

namespace AstroOffice.BAL
{
    internal class BALGeneral
    {
        private readonly DALGeneral _dgl;

        public BALGeneral()
        {
            _dgl = new DALGeneral();
        }

        public void AddChangeLog(a_changelog acl)
        {
            this._dgl.AddChangeLog(acl);
        }

        public a_changelog GetSno(long sno)
        {
            return this._dgl.GetSno(sno);
        }
    }
}