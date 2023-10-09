using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroOffice.Helper
{
    internal static class Loader
    {
        private static FrmLoading _frmLoading;
        private static Thread _thread;

        public static void Show()
        {
            Cursor.Current = Cursors.WaitCursor;
            _thread = new Thread(InItFrmLoading);
            _thread.Start();
        }

        public static void Close()
        {
            Thread.Sleep(9000);
            if (IsLoaderVisible())
            {
                if (_frmLoading.InvokeRequired)
                    _frmLoading.Invoke(new Action(() => _frmLoading.Close()));
                _thread.Interrupt();
                _frmLoading = null;
                _thread = null;
            }
            Cursor.Current = Cursors.Default;
        }

        public static bool IsLoaderVisible()
        {
            if (_frmLoading != null && !_frmLoading.IsDisposed)
                return _frmLoading.Visible;
            return false;
        }

        private static void InItFrmLoading()
        {
            _frmLoading = new FrmLoading();
            _frmLoading.ShowDialog();
        }
    }
}
