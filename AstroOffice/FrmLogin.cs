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
            Panel_SendOtp.Visible = ChkLoginOption.Checked;
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

        private void ChkLoginOption_CheckedChanged(object sender, EventArgs e)
        {
            Panel_SendOtp.Visible = ChkLoginOption.Checked;
            Panel_Credentials.Visible = !Panel_SendOtp.Visible;
            MTxtMobileNumber.Text = string.Empty;
        }

        private async void BtnSendOtp_Click(object sender, EventArgs e)
        {
            string mobileNumber = string.Concat(MTxtMobileNumber.Text.Where(c => char.IsDigit(c)));
            if (string.IsNullOrEmpty(mobileNumber) || mobileNumber.Length < 10)
            {
                MessageBox.Show("Enter valid mobile number.");
            }
            else
            {
                var response = await _httpClient.GetAsync<ApiResponse<string>>($"SMS/SendOtp?mobileNumber={mobileNumber}");
                if (response.Success)
                {
                    MessageBox.Show(response.Message);
                    Panel_SendOtp.Visible = false;
                    ChkLoginOption.Visible = false;
                    Panel_VerifyOtp.Visible = true;
                }
                else
                {
                    if (!string.IsNullOrEmpty(response.Message))
                    {
                        MessageBox.Show(response.Message);
                    }
                }
            }
        }

        private async void VerifyOtp_Click(object sender, EventArgs e)
        {
            string mobileNumber = string.Concat(MTxtMobileNumber.Text.Where(c => char.IsDigit(c))); ;
            string otp = string.Concat(MTxtOtp.Text.Where(c => char.IsDigit(c)));
            var bALUser = Program.ServiceProvider.GetRequiredService<BALUser>();

            try
            {
                this.Hide();
                Loader.Show();
                AUser aUser = bALUser.GetUserByMobileNumber(mobileNumber);


                if (aUser.Sno <= 0)
                {
                    MessageBox.Show("Invalid User name or Password");
                    this.Show();
                    return;
                }
                var response = await _httpClient.GetAsync<ApiResponse<string>>($"SMS/VerifyOtp?mobileNumber={mobileNumber}&otp={otp}");

                if (otp == aUser.MobileOtp && response.Success)
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
                    this.Hide(); Loader.Close();
                }
                else
                {
                    MessageBox.Show("Invalid Otp.");
                    Loader.Close();
                    this.Show();
                    return;
                }
            }
            catch
            {
                this.Show();
                Loader.Close();
            }
        }

        private void BtnCancelVefication_Click(object sender, EventArgs e)
        {
            ChkLoginOption.Checked = false;
            Panel_VerifyOtp.Visible = false;
            ChkLoginOption.Visible = true;
        }

        private async void BtnResendOtp_Click(object sender, EventArgs e)
        {
            string mobileNumber = string.Concat(MTxtMobileNumber.Text.Where(c => char.IsDigit(c))); ;
            if (string.IsNullOrEmpty(mobileNumber) || mobileNumber.Length < 10)
            {
                MessageBox.Show("Enter valid mobile number.");
            }
            else
            {
                var response = await _httpClient.GetAsync<ApiResponse<string>>($"SMS/SendOtp?mobileNumber={mobileNumber}");
                if (response.Success)
                {
                    MessageBox.Show(response.Message);
                }
                else
                {
                    if (!string.IsNullOrEmpty(response.Message))
                    {
                        MessageBox.Show(response.Message);
                    }
                }
            }
        }

    }
}
