using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroOffice.Helper
{
    public delegate void ErrorOccurredEventHandler(object sender, EventArgs e);

    internal class LoaderService
    {
        private FrmLoading _frmLoading;
        private Thread _thread;

        // Declare an event for error handling
        public event ErrorOccurredEventHandler ErrorOccurred;

        public void Show()
        {
            if (_frmLoading != null && _frmLoading.Visible)
            {
                Close();
            }
            Cursor.Current = Cursors.WaitCursor;
            _thread = new Thread(LoadingProcess);
            _thread.Priority = ThreadPriority.AboveNormal; // Set the desired priority
            _thread.Start();
        }

        public void Close()
        {
            if (_frmLoading != null && !_frmLoading.IsDisposed)
            {
                if (_frmLoading.InvokeRequired)
                {
                    _frmLoading.Invoke(new Action(() =>
                    {
                        _frmLoading.DialogResult = DialogResult.OK;
                        _frmLoading.Close();
                    }));
                }
                _frmLoading = null;
                _thread = null;
            }
            Cursor.Current = Cursors.Default;
        }

        private void LoadingProcess()
        {
            _frmLoading = new FrmLoading();
            _frmLoading.ShowDialog();
        }
    }
}
