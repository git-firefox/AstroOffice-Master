using System;
using System.Linq;
using System.Windows.Forms;
//using AstroOffice.VO;
using AstroOffice.Models;

namespace AstroOffice.DAl
{
    internal class DALGeneral
    {
        private readonly astroDataContainer _asd;

        public DALGeneral()
        {
            _asd = new astroDataContainer();
        }

        public void AddChangeLog(a_changelog acl)
        {
            try
            {
                this._asd.a_changelog.Add(acl);
                this._asd.SaveChanges();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        public a_changelog GetSno(long sno)
        {
            a_changelog aChangelog;
            try
            {
                aChangelog = (
                    from tt in this._asd.a_changelog
                    where tt.modifiedby == (long?)sno
                    select tt).FirstOrDefault<a_changelog>();
            }
            catch (Exception exception)
            {
                _ = exception;

                aChangelog = null;
            }
            return aChangelog;
        }
    }
}