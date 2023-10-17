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
using AstroOfficeWeb.Shared.Models;
//using System.Windows;

namespace AstroOffice
{
    public partial class FrmLogin : Form
    {
        //private readonly Loader _loader;
        private readonly HttpClientHelper _httpClient;

        public FrmLogin()
        {
            _httpClient = new HttpClientHelper("https://localhost:7085/api/");
            InitializeComponent();
            panel1.Visible = checkBox1.Checked;
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            panel1.Visible = checkBox1.Checked;
        }

        private void TxtMobileNumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnSendOtp_Click(object sender, EventArgs e)
        {
            var mobileNumber = TxtMobileNumber.Text;
            if (string.IsNullOrEmpty(mobileNumber))
            {
                MessageBox.Show("Enter Mobile Number ");
            }
            else
            {
                var response = _httpClient.GetAsync<ApiResponse<string>>($"SMS/SendOtp?mobileNumber={mobileNumber}").Result;
            }
        }

        private void VerifyOtp_Click(object sender, EventArgs e)
        {
            var bALUser = Program.ServiceProvider.GetRequiredService<BALUser>();

            this.Hide();
            Loader.Show();
            AUser aUser = bALUser.UserNameSearch(this.TxtUserName.Text);

            Loader.Close();

            if (aUser.Sno <= 0)
            {
                MessageBox.Show("Invalid User name or Password");
                this.Show();
                return;
            }

            string otp = TxtNum1.Text + TxtNum2.Text + TxtNum3.Text + TxtNum4.Text + TxtNum5.Text + TxtNum6.Text;

            if (otp == aUser.MobileOtp)
            {
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
            else
            {
                MessageBox.Show("Invalid Otp.");
                this.Show();
                return;
            }
        }
    }
}
