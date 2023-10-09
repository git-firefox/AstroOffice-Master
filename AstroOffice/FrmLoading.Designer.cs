namespace AstroOffice
{
    partial class FrmLoading
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLoading));
            PicBLoading = new PictureBox();
            LblLoading = new Label();
            ((System.ComponentModel.ISupportInitialize)PicBLoading).BeginInit();
            SuspendLayout();
            // 
            // PicBLoading
            // 
            PicBLoading.Anchor = AnchorStyles.Left;
            PicBLoading.Image = (Image)resources.GetObject("PicBLoading.Image");
            PicBLoading.Location = new Point(8, 8);
            PicBLoading.Name = "PicBLoading";
            PicBLoading.Size = new Size(65, 65);
            PicBLoading.SizeMode = PictureBoxSizeMode.StretchImage;
            PicBLoading.TabIndex = 0;
            PicBLoading.TabStop = false;
            // 
            // LblLoading
            // 
            LblLoading.Anchor = AnchorStyles.Left;
            LblLoading.AutoSize = true;
            LblLoading.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            LblLoading.Location = new Point(88, 32);
            LblLoading.Name = "LblLoading";
            LblLoading.Size = new Size(178, 21);
            LblLoading.TabIndex = 1;
            LblLoading.Text = "Loading... Please wait.";
            // 
            // FrmLoading
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(145, 13, 13);
            ClientSize = new Size(281, 80);
            ControlBox = false;
            Controls.Add(PicBLoading);
            Controls.Add(LblLoading);
            Cursor = Cursors.WaitCursor;
            ForeColor = Color.FromArgb(233, 175, 0);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmLoading";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmLoading";
            ((System.ComponentModel.ISupportInitialize)PicBLoading).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox PicBLoading;
        private Label LblLoading;
    }
}