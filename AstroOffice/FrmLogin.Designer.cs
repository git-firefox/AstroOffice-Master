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
            ChkLoginOption = new CheckBox();
            Panel_VerifyOtp = new Panel();
            MTxtOtp = new MaskedTextBox();
            BtnCancelVefication = new Button();
            VerifyOtp = new Button();
            BtnResendOtp = new Button();
            BtnSendOtp = new Button();
            Panel_SendOtp = new Panel();
            MTxtMobileNumber = new MaskedTextBox();
            Panel_Credentials = new Panel();
            FlowLayoutPanel_LoginOptions = new FlowLayoutPanel();
            Panel_VerifyOtp.SuspendLayout();
            Panel_SendOtp.SuspendLayout();
            Panel_Credentials.SuspendLayout();
            FlowLayoutPanel_LoginOptions.SuspendLayout();
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
            TxtUserName.Location = new Point(8, 12);
            TxtUserName.Margin = new Padding(4, 6, 4, 3);
            TxtUserName.Name = "TxtUserName";
            TxtUserName.Size = new Size(95, 25);
            TxtUserName.TabIndex = 0;
            // 
            // TxtPassword
            // 
            TxtPassword.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            TxtPassword.Location = new Point(122, 12);
            TxtPassword.Margin = new Padding(4, 6, 4, 3);
            TxtPassword.Name = "TxtPassword";
            TxtPassword.PasswordChar = '*';
            TxtPassword.Size = new Size(95, 25);
            TxtPassword.TabIndex = 1;
            // 
            // ChkLoginOption
            // 
            ChkLoginOption.AutoSize = true;
            ChkLoginOption.Location = new Point(130, 99);
            ChkLoginOption.Name = "ChkLoginOption";
            ChkLoginOption.Size = new Size(169, 19);
            ChkLoginOption.TabIndex = 9;
            ChkLoginOption.Text = "Login with Mobile Number";
            ChkLoginOption.UseVisualStyleBackColor = true;
            ChkLoginOption.CheckedChanged += ChkLoginOption_CheckedChanged;
            // 
            // Panel_VerifyOtp
            // 
            Panel_VerifyOtp.Controls.Add(MTxtOtp);
            Panel_VerifyOtp.Controls.Add(BtnCancelVefication);
            Panel_VerifyOtp.Controls.Add(VerifyOtp);
            Panel_VerifyOtp.Controls.Add(BtnResendOtp);
            Panel_VerifyOtp.Location = new Point(12, 63);
            Panel_VerifyOtp.Name = "Panel_VerifyOtp";
            Panel_VerifyOtp.Size = new Size(424, 139);
            Panel_VerifyOtp.TabIndex = 10;
            Panel_VerifyOtp.Visible = false;
            // 
            // MTxtOtp
            // 
            MTxtOtp.BackColor = Color.FromArgb(255, 128, 0);
            MTxtOtp.BorderStyle = BorderStyle.FixedSingle;
            MTxtOtp.Font = new Font("Segoe UI Black", 24F, FontStyle.Regular, GraphicsUnit.Point);
            MTxtOtp.Location = new Point(8, 12);
            MTxtOtp.Mask = "0 - 0 - 0 - 0 - 0 - 0";
            MTxtOtp.Name = "MTxtOtp";
            MTxtOtp.Size = new Size(408, 51);
            MTxtOtp.TabIndex = 15;
            MTxtOtp.TextAlign = HorizontalAlignment.Center;
            // 
            // BtnCancelVefication
            // 
            BtnCancelVefication.BackColor = Color.Khaki;
            BtnCancelVefication.FlatStyle = FlatStyle.Flat;
            BtnCancelVefication.Location = new Point(328, 83);
            BtnCancelVefication.Name = "BtnCancelVefication";
            BtnCancelVefication.Size = new Size(88, 31);
            BtnCancelVefication.TabIndex = 9;
            BtnCancelVefication.Text = "Cancel";
            BtnCancelVefication.UseVisualStyleBackColor = false;
            BtnCancelVefication.Click += BtnCancelVefication_Click;
            // 
            // VerifyOtp
            // 
            VerifyOtp.BackColor = Color.Khaki;
            VerifyOtp.FlatStyle = FlatStyle.Flat;
            VerifyOtp.Location = new Point(8, 83);
            VerifyOtp.Name = "VerifyOtp";
            VerifyOtp.Size = new Size(88, 31);
            VerifyOtp.TabIndex = 7;
            VerifyOtp.Text = "Verify Otp";
            VerifyOtp.UseVisualStyleBackColor = false;
            VerifyOtp.Click += VerifyOtp_Click;
            // 
            // BtnResendOtp
            // 
            BtnResendOtp.BackColor = Color.Khaki;
            BtnResendOtp.FlatStyle = FlatStyle.Flat;
            BtnResendOtp.Location = new Point(102, 83);
            BtnResendOtp.Name = "BtnResendOtp";
            BtnResendOtp.Size = new Size(88, 31);
            BtnResendOtp.TabIndex = 8;
            BtnResendOtp.Text = "Resend Otp";
            BtnResendOtp.UseVisualStyleBackColor = false;
            BtnResendOtp.Click += BtnResendOtp_Click;
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
            // Panel_SendOtp
            // 
            Panel_SendOtp.Controls.Add(MTxtMobileNumber);
            Panel_SendOtp.Controls.Add(BtnSendOtp);
            Panel_SendOtp.Location = new Point(3, 3);
            Panel_SendOtp.Name = "Panel_SendOtp";
            Panel_SendOtp.Size = new Size(424, 48);
            Panel_SendOtp.TabIndex = 13;
            // 
            // MTxtMobileNumber
            // 
            MTxtMobileNumber.Location = new Point(8, 13);
            MTxtMobileNumber.Mask = "000-000-0000";
            MTxtMobileNumber.Name = "MTxtMobileNumber";
            MTxtMobileNumber.Size = new Size(100, 23);
            MTxtMobileNumber.TabIndex = 13;
            // 
            // Panel_Credentials
            // 
            Panel_Credentials.Controls.Add(TxtUserName);
            Panel_Credentials.Controls.Add(TxtPassword);
            Panel_Credentials.Controls.Add(BtnAccess);
            Panel_Credentials.Controls.Add(BtnExit);
            Panel_Credentials.Location = new Point(3, 57);
            Panel_Credentials.Name = "Panel_Credentials";
            Panel_Credentials.Size = new Size(424, 48);
            Panel_Credentials.TabIndex = 14;
            // 
            // FlowLayoutPanel_LoginOptions
            // 
            FlowLayoutPanel_LoginOptions.Controls.Add(Panel_SendOtp);
            FlowLayoutPanel_LoginOptions.Controls.Add(Panel_Credentials);
            FlowLayoutPanel_LoginOptions.Location = new Point(8, 15);
            FlowLayoutPanel_LoginOptions.Name = "FlowLayoutPanel_LoginOptions";
            FlowLayoutPanel_LoginOptions.Size = new Size(433, 54);
            FlowLayoutPanel_LoginOptions.TabIndex = 15;
            // 
            // FrmLogin
            // 
            AcceptButton = BtnAccess;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 128, 0);
            ClientSize = new Size(454, 210);
            ControlBox = false;
            Controls.Add(FlowLayoutPanel_LoginOptions);
            Controls.Add(Panel_VerifyOtp);
            Controls.Add(ChkLoginOption);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(2);
            Name = "FrmLogin";
            Padding = new Padding(12);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AstroScience Login";
            Panel_VerifyOtp.ResumeLayout(false);
            Panel_VerifyOtp.PerformLayout();
            Panel_SendOtp.ResumeLayout(false);
            Panel_SendOtp.PerformLayout();
            Panel_Credentials.ResumeLayout(false);
            Panel_Credentials.PerformLayout();
            FlowLayoutPanel_LoginOptions.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BtnAccess;
        private Button BtnExit;
        private TextBox TxtUserName;
        private TextBox TxtPassword;
        private CheckBox ChkLoginOption;
        private Panel Panel_VerifyOtp;
        private Button BtnSendOtp;
        private Panel Panel_SendOtp;
        private Panel Panel_Credentials;
        private Button BtnResendOtp;
        private Button VerifyOtp;
        private Button BtnCancelVefication;
        private MaskedTextBox MTxtOtp;
        private MaskedTextBox MTxtMobileNumber;
        private FlowLayoutPanel FlowLayoutPanel_LoginOptions;
    }
}