using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AstroOffice.Helper;
//using AstroOffice.BAL;
//using AstroOffice.Models.Astrooff;
using ASBAL;
using ASModels.Astrooff;
using Microsoft.Extensions.DependencyInjection;
namespace AstroOffice
{
    public partial class FrmLogin : Form
    {
        //private readonly Loader _loader;
        public FrmLogin()
        {
            InitializeComponent();
            //_loader = new Loader();
        }

        private void BtnAccess_Click(object sender, EventArgs e)
        {
            if (this.TxtUserName.Text.ToString().Trim().Length <= 0 || this.TxtPassword.Text.ToString().Trim().Length <= 0)
            {
                MessageBox.Show("Enter User name or Password");
                return;
            }
            var bALUser = Program.ServiceProvider.GetRequiredService<BALUser>();

            //BALUser bALUser = new();
            AUser aUser = new();
            this.Hide();
            Loader.Show();
            aUser = bALUser.UserLogin(this.TxtUserName.Text, this.TxtPassword.Text);
            Loader.Close();

            if (aUser.Sno <= 0)
            {
                MessageBox.Show("Invalid User name or Password");
                this.Show();
                return;
            }
            AUserLog aUserLog = new()
            {
                Username = aUser.Username,
                Loginsuccess = new bool?(true),
                Logintime = new DateTime?(DateTime.Now),
                Systemname = Environment.UserName.ToString()
            };
            AstroGlobal.Username = aUser.Username;
            AstroGlobal.CanAddNew = aUser.CanAdd.Value;
            AstroGlobal.CanModify = aUser.CanEdit.Value;
            AstroGlobal.CanReport = aUser.CanReport.Value;
            AstroGlobal.ActiveUserId = aUser.Sno;
            AstroGlobal.Username = aUser.Username;
            AstroGlobal.IsAdmin = aUser.Adminuser.Value;
            new FrmNewKP().Show();
            Hide();
        }
        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
            Application.ExitThread();
        }
    }
}
