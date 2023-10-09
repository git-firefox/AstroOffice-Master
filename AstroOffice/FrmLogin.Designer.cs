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
            BtnAccess.Location = new Point(254, 17);
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
            BtnExit.Location = new Point(350, 17);
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
            TxtUserName.Location = new Point(16, 20);
            TxtUserName.Margin = new Padding(4, 6, 4, 3);
            TxtUserName.Name = "TxtUserName";
            TxtUserName.Size = new Size(95, 25);
            TxtUserName.TabIndex = 0;
            // 
            // TxtPassword
            // 
            TxtPassword.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            TxtPassword.Location = new Point(135, 20);
            TxtPassword.Margin = new Padding(4, 6, 4, 3);
            TxtPassword.Name = "TxtPassword";
            TxtPassword.PasswordChar = '*';
            TxtPassword.Size = new Size(95, 25);
            TxtPassword.TabIndex = 1;
            // 
            // FrmLogin
            // 
            AcceptButton = BtnAccess;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 128, 0);
            ClientSize = new Size(442, 65);
            ControlBox = false;
            Controls.Add(BtnExit);
            Controls.Add(BtnAccess);
            Controls.Add(TxtPassword);
            Controls.Add(TxtUserName);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(2);
            Name = "FrmLogin";
            Padding = new Padding(12);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AstroScience Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BtnAccess;
        private Button BtnExit;
        private TextBox TxtUserName;
        private TextBox TxtPassword;
    }
}