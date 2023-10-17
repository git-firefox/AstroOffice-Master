namespace AstroOffice
{
    partial class FrmLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            BtnAccess = new Button();
            BtnExit = new Button();
            TxtUserName = new TextBox();
            TxtPassword = new TextBox();
            TxtNum2 = new TextBox();
            TxtNum3 = new TextBox();
            TxtNum6 = new TextBox();
            TxtNum4 = new TextBox();
            TxtNum5 = new TextBox();
            TxtNum1 = new TextBox();
            checkBox1 = new CheckBox();
            panel1 = new Panel();
            VerifyOtp = new Button();
            BtnResendOtp = new Button();
            TxtMobileNumber = new TextBox();
            BtnSendOtp = new Button();
            panel2 = new Panel();
            Panel_Cred = new Panel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            Panel_Cred.SuspendLayout();
            SuspendLayout();
            // 
            // BtnAccess
            // 
            BtnAccess.AutoSize = true;
            BtnAccess.BackColor = Color.Khaki;
            BtnAccess.Cursor = Cursors.Hand;
            BtnAccess.FlatAppearance.BorderSize = 0;
            BtnAccess.FlatStyle = FlatStyle.Flat;
            BtnAccess.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            BtnAccess.Location = new Point(248, 8);
            BtnAccess.Margin = new Padding(4, 3, 4, 3);
            BtnAccess.Name = "BtnAccess";
            BtnAccess.Size = new Size(72, 31);
            BtnAccess.TabIndex = 2;
            BtnAccess.Text = "Access";
            BtnAccess.UseVisualStyleBackColor = false;
            BtnAccess.Click += BtnAccess_Click;
            // 
            // BtnExit
            // 
            BtnExit.AutoSize = true;
            BtnExit.BackColor = Color.Khaki;
            BtnExit.Cursor = Cursors.Hand;
            BtnExit.FlatAppearance.BorderSize = 0;
            BtnExit.FlatStyle = FlatStyle.Flat;
            BtnExit.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            BtnExit.Location = new Point(344, 8);
            BtnExit.Margin = new Padding(4, 3, 4, 3);
            BtnExit.Name = "BtnExit";
            BtnExit.Size = new Size(72, 31);
            BtnExit.TabIndex = 3;
            BtnExit.Text = "Exit";
            BtnExit.UseVisualStyleBackColor = false;
            BtnExit.Click += BtnExit_Click;
            // 
            // TxtUserName
            // 
            TxtUserName.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            TxtUserName.Location = new Point(8, 16);
            TxtUserName.Margin = new Padding(4, 6, 4, 3);
            TxtUserName.Name = "TxtUserName";
            TxtUserName.Size = new Size(95, 25);
            TxtUserName.TabIndex = 0;
            // 
            // TxtPassword
            // 
            TxtPassword.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            TxtPassword.Location = new Point(119, 16);
            TxtPassword.Margin = new Padding(4, 6, 4, 3);
            TxtPassword.Name = "TxtPassword";
            TxtPassword.PasswordChar = '*';
            TxtPassword.Size = new Size(95, 25);
            TxtPassword.TabIndex = 1;
            TxtPassword.TextChanged += TxtPassword_TextChanged;
            // 
            // TxtNum2
            // 
            TxtNum2.Location = new Point(40, 16);
            TxtNum2.Name = "TxtNum2";
            TxtNum2.Size = new Size(24, 23);
            TxtNum2.TabIndex = 4;
            // 
            // TxtNum3
            // 
            TxtNum3.Location = new Point(72, 16);
            TxtNum3.Name = "TxtNum3";
            TxtNum3.Size = new Size(24, 23);
            TxtNum3.TabIndex = 5;
            // 
            // TxtNum6
            // 
            TxtNum6.Location = new Point(168, 16);
            TxtNum6.Name = "TxtNum6";
            TxtNum6.Size = new Size(24, 23);
            TxtNum6.TabIndex = 6;
            // 
            // TxtNum4
            // 
            TxtNum4.Location = new Point(104, 16);
            TxtNum4.Name = "TxtNum4";
            TxtNum4.Size = new Size(24, 23);
            TxtNum4.TabIndex = 7;
            // 
            // TxtNum5
            // 
            TxtNum5.Location = new Point(136, 16);
            TxtNum5.Name = "TxtNum5";
            TxtNum5.Size = new Size(24, 23);
            TxtNum5.TabIndex = 7;
            // 
            // TxtNum1
            // 
            TxtNum1.Location = new Point(8, 16);
            TxtNum1.Name = "TxtNum1";
            TxtNum1.Size = new Size(24, 23);
            TxtNum1.TabIndex = 8;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(160, 216);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(103, 19);
            checkBox1.TabIndex = 9;
            checkBox1.Text = "Login with otp";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // panel1
            // 
            panel1.Controls.Add(VerifyOtp);
            panel1.Controls.Add(BtnResendOtp);
            panel1.Controls.Add(TxtNum1);
            panel1.Controls.Add(TxtNum2);
            panel1.Controls.Add(TxtNum3);
            panel1.Controls.Add(TxtNum5);
            panel1.Controls.Add(TxtNum6);
            panel1.Controls.Add(TxtNum4);
            panel1.Location = new Point(8, 152);
            panel1.Name = "panel1";
            panel1.Size = new Size(424, 48);
            panel1.TabIndex = 10;
            // 
            // VerifyOtp
            // 
            VerifyOtp.BackColor = Color.Khaki;
            VerifyOtp.FlatStyle = FlatStyle.Flat;
            VerifyOtp.Location = new Point(232, 8);
            VerifyOtp.Name = "VerifyOtp";
            VerifyOtp.Size = new Size(88, 31);
            VerifyOtp.TabIndex = 10;
            VerifyOtp.Text = "Verify Otp";
            VerifyOtp.UseVisualStyleBackColor = false;
            VerifyOtp.Click += VerifyOtp_Click;
            // 
            // BtnResendOtp
            // 
            BtnResendOtp.BackColor = Color.Khaki;
            BtnResendOtp.FlatStyle = FlatStyle.Flat;
            BtnResendOtp.Location = new Point(328, 8);
            BtnResendOtp.Name = "BtnResendOtp";
            BtnResendOtp.Size = new Size(88, 31);
            BtnResendOtp.TabIndex = 9;
            BtnResendOtp.Text = "Resend Otp";
            BtnResendOtp.UseVisualStyleBackColor = false;
            // 
            // TxtMobileNumber
            // 
            TxtMobileNumber.Location = new Point(8, 16);
            TxtMobileNumber.Name = "TxtMobileNumber";
            TxtMobileNumber.Size = new Size(100, 23);
            TxtMobileNumber.TabIndex = 11;
            TxtMobileNumber.TextChanged += TxtMobileNumber_TextChanged;
            // 
            // BtnSendOtp
            // 
            BtnSendOtp.BackColor = Color.Khaki;
            BtnSendOtp.FlatStyle = FlatStyle.Flat;
            BtnSendOtp.Location = new Point(344, 8);
            BtnSendOtp.Name = "BtnSendOtp";
            BtnSendOtp.Size = new Size(72, 31);
            BtnSendOtp.TabIndex = 12;
            BtnSendOtp.Text = "Send Otp";
            BtnSendOtp.UseVisualStyleBackColor = false;
            BtnSendOtp.Click += BtnSendOtp_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(BtnSendOtp);
            panel2.Controls.Add(TxtMobileNumber);
            panel2.Location = new Point(8, 88);
            panel2.Name = "panel2";
            panel2.Size = new Size(424, 48);
            panel2.TabIndex = 13;
            // 
            // Panel_Cred
            // 
            Panel_Cred.Controls.Add(TxtUserName);
            Panel_Cred.Controls.Add(TxtPassword);
            Panel_Cred.Controls.Add(BtnAccess);
            Panel_Cred.Controls.Add(BtnExit);
            Panel_Cred.Location = new Point(8, 16);
            Panel_Cred.Name = "Panel_Cred";
            Panel_Cred.Size = new Size(424, 48);
            Panel_Cred.TabIndex = 14;
            // 
            // FrmLogin
            // 
            AcceptButton = BtnAccess;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 128, 0);
            ClientSize = new Size(442, 250);
            ControlBox = false;
            Controls.Add(Panel_Cred);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(checkBox1);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(2);
            Name = "FrmLogin";
            Padding = new Padding(12);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AstroScience Login";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            Panel_Cred.ResumeLayout(false);
            Panel_Cred.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BtnAccess;
        private Button BtnExit;
        private TextBox TxtUserName;
        private TextBox TxtPassword;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private TextBox textBox6;
        private CheckBox checkBox1;
        private Panel panel1;
        private TextBox TxtMobileNumber;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button BtnSendOtp;
        private Panel panel2;
        private Panel Panel_Cred;
        private Button BtnResendOtp;
        private Button VerifyOtp;
        private TextBox TxtNum2;
        private TextBox TxtNum3;
        private TextBox TxtNum6;
        private TextBox TxtNum4;
        private TextBox TxtNum5;
        private TextBox TxtNum1;
    }
}