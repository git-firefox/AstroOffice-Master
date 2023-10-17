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
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            textBox6 = new TextBox();
            checkBox1 = new CheckBox();
            panel1 = new Panel();
            panel1.SuspendLayout();
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
            // textBox1
            // 
            textBox1.Location = new Point(40, 16);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(24, 23);
            textBox1.TabIndex = 4;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(72, 16);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(24, 23);
            textBox2.TabIndex = 5;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(168, 16);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(24, 23);
            textBox3.TabIndex = 6;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(104, 16);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(24, 23);
            textBox4.TabIndex = 7;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(136, 16);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(24, 23);
            textBox5.TabIndex = 7;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(8, 16);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(24, 23);
            textBox6.TabIndex = 8;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(8, 80);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(103, 19);
            checkBox1.TabIndex = 9;
            checkBox1.Text = "Login with otp";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(textBox6);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(textBox5);
            panel1.Controls.Add(textBox3);
            panel1.Controls.Add(textBox4);
            panel1.Location = new Point(120, 64);
            panel1.Name = "panel1";
            panel1.Size = new Size(200, 56);
            panel1.TabIndex = 10;
            // 
            // FrmLogin
            // 
            AcceptButton = BtnAccess;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 128, 0);
            ClientSize = new Size(442, 143);
            ControlBox = false;
            Controls.Add(panel1);
            Controls.Add(checkBox1);
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
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
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
    }
}