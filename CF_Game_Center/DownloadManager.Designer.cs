namespace CF_Game_Center
{
    partial class DownloadManager
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
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.MinimizeBTN = new Guna.UI2.WinForms.Guna2ControlBox();
            this.TopbarLBL = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.CloseBTN = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.DownloadETALBL = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.FilesRichTXT = new System.Windows.Forms.RichTextBox();
            this.DownloadSpeedLBL = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.DownloadGBLeftLBL = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.DownloadGameLBL = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.DownloadProgress = new Guna.UI2.WinForms.Guna2ProgressBar();
            this.DownloadGameIMG = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2Panel1.SuspendLayout();
            this.guna2Panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DownloadGameIMG)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.guna2Panel1.Controls.Add(this.MinimizeBTN);
            this.guna2Panel1.Controls.Add(this.TopbarLBL);
            this.guna2Panel1.Controls.Add(this.CloseBTN);
            this.guna2Panel1.Location = new System.Drawing.Point(0, 1);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(800, 49);
            this.guna2Panel1.TabIndex = 1;
            // 
            // MinimizeBTN
            // 
            this.MinimizeBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MinimizeBTN.BorderRadius = 4;
            this.MinimizeBTN.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.MinimizeBTN.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.MinimizeBTN.IconColor = System.Drawing.Color.White;
            this.MinimizeBTN.Location = new System.Drawing.Point(693, 11);
            this.MinimizeBTN.Name = "MinimizeBTN";
            this.MinimizeBTN.Size = new System.Drawing.Size(45, 29);
            this.MinimizeBTN.TabIndex = 4;
            // 
            // TopbarLBL
            // 
            this.TopbarLBL.BackColor = System.Drawing.Color.Transparent;
            this.TopbarLBL.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TopbarLBL.ForeColor = System.Drawing.Color.White;
            this.TopbarLBL.Location = new System.Drawing.Point(13, 13);
            this.TopbarLBL.Name = "TopbarLBL";
            this.TopbarLBL.Size = new System.Drawing.Size(140, 22);
            this.TopbarLBL.TabIndex = 0;
            this.TopbarLBL.Text = "Download Manager";
            // 
            // CloseBTN
            // 
            this.CloseBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseBTN.BorderRadius = 4;
            this.CloseBTN.CustomClick = true;
            this.CloseBTN.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.CloseBTN.IconColor = System.Drawing.Color.White;
            this.CloseBTN.Location = new System.Drawing.Point(744, 11);
            this.CloseBTN.Name = "CloseBTN";
            this.CloseBTN.Size = new System.Drawing.Size(45, 29);
            this.CloseBTN.TabIndex = 3;
            this.CloseBTN.Click += new System.EventHandler(this.CloseBTN_Click);
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.Controls.Add(this.DownloadETALBL);
            this.guna2Panel2.Controls.Add(this.FilesRichTXT);
            this.guna2Panel2.Controls.Add(this.DownloadSpeedLBL);
            this.guna2Panel2.Controls.Add(this.DownloadGBLeftLBL);
            this.guna2Panel2.Controls.Add(this.DownloadGameLBL);
            this.guna2Panel2.Controls.Add(this.DownloadProgress);
            this.guna2Panel2.Controls.Add(this.DownloadGameIMG);
            this.guna2Panel2.Location = new System.Drawing.Point(0, 57);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(789, 277);
            this.guna2Panel2.TabIndex = 2;
            // 
            // DownloadETALBL
            // 
            this.DownloadETALBL.BackColor = System.Drawing.Color.Transparent;
            this.DownloadETALBL.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DownloadETALBL.ForeColor = System.Drawing.Color.White;
            this.DownloadETALBL.Location = new System.Drawing.Point(92, 65);
            this.DownloadETALBL.Name = "DownloadETALBL";
            this.DownloadETALBL.Size = new System.Drawing.Size(27, 19);
            this.DownloadETALBL.TabIndex = 11;
            this.DownloadETALBL.Text = "ETA";
            // 
            // FilesRichTXT
            // 
            this.FilesRichTXT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.FilesRichTXT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FilesRichTXT.Cursor = System.Windows.Forms.Cursors.Default;
            this.FilesRichTXT.DetectUrls = false;
            this.FilesRichTXT.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FilesRichTXT.ForeColor = System.Drawing.Color.White;
            this.FilesRichTXT.Location = new System.Drawing.Point(92, 148);
            this.FilesRichTXT.Name = "FilesRichTXT";
            this.FilesRichTXT.ReadOnly = true;
            this.FilesRichTXT.Size = new System.Drawing.Size(665, 109);
            this.FilesRichTXT.TabIndex = 10;
            this.FilesRichTXT.Text = "";
            // 
            // DownloadSpeedLBL
            // 
            this.DownloadSpeedLBL.BackColor = System.Drawing.Color.Transparent;
            this.DownloadSpeedLBL.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DownloadSpeedLBL.ForeColor = System.Drawing.Color.White;
            this.DownloadSpeedLBL.Location = new System.Drawing.Point(92, 115);
            this.DownloadSpeedLBL.Name = "DownloadSpeedLBL";
            this.DownloadSpeedLBL.Size = new System.Drawing.Size(107, 19);
            this.DownloadSpeedLBL.TabIndex = 9;
            this.DownloadSpeedLBL.Text = "Download Speed";
            // 
            // DownloadGBLeftLBL
            // 
            this.DownloadGBLeftLBL.BackColor = System.Drawing.Color.Transparent;
            this.DownloadGBLeftLBL.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DownloadGBLeftLBL.ForeColor = System.Drawing.Color.White;
            this.DownloadGBLeftLBL.Location = new System.Drawing.Point(92, 90);
            this.DownloadGBLeftLBL.Name = "DownloadGBLeftLBL";
            this.DownloadGBLeftLBL.Size = new System.Drawing.Size(44, 19);
            this.DownloadGBLeftLBL.TabIndex = 8;
            this.DownloadGBLeftLBL.Text = "gb left";
            // 
            // DownloadGameLBL
            // 
            this.DownloadGameLBL.BackColor = System.Drawing.Color.Transparent;
            this.DownloadGameLBL.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DownloadGameLBL.ForeColor = System.Drawing.Color.White;
            this.DownloadGameLBL.Location = new System.Drawing.Point(92, 13);
            this.DownloadGameLBL.Name = "DownloadGameLBL";
            this.DownloadGameLBL.Size = new System.Drawing.Size(74, 19);
            this.DownloadGameLBL.TabIndex = 7;
            this.DownloadGameLBL.Text = "Game Size :";
            this.DownloadGameLBL.Click += new System.EventHandler(this.guna2HtmlLabel2_Click);
            // 
            // DownloadProgress
            // 
            this.DownloadProgress.BorderRadius = 4;
            this.DownloadProgress.Location = new System.Drawing.Point(92, 38);
            this.DownloadProgress.Name = "DownloadProgress";
            this.DownloadProgress.Size = new System.Drawing.Size(678, 21);
            this.DownloadProgress.TabIndex = 1;
            this.DownloadProgress.Text = "guna2ProgressBar1";
            this.DownloadProgress.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.DownloadProgress.ValueChanged += new System.EventHandler(this.guna2ProgressBar1_ValueChanged);
            // 
            // DownloadGameIMG
            // 
            this.DownloadGameIMG.ImageRotate = 0F;
            this.DownloadGameIMG.Location = new System.Drawing.Point(13, 14);
            this.DownloadGameIMG.Name = "DownloadGameIMG";
            this.DownloadGameIMG.Size = new System.Drawing.Size(73, 112);
            this.DownloadGameIMG.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.DownloadGameIMG.TabIndex = 0;
            this.DownloadGameIMG.TabStop = false;
            // 
            // DownloadManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(800, 346);
            this.Controls.Add(this.guna2Panel2);
            this.Controls.Add(this.guna2Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DownloadManager";
            this.Text = "DownloadManager";
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DownloadGameIMG)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2ControlBox MinimizeBTN;
        private Guna.UI2.WinForms.Guna2HtmlLabel TopbarLBL;
        private Guna.UI2.WinForms.Guna2ControlBox CloseBTN;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        public Guna.UI2.WinForms.Guna2PictureBox DownloadGameIMG;
        public Guna.UI2.WinForms.Guna2ProgressBar DownloadProgress;
        public Guna.UI2.WinForms.Guna2HtmlLabel DownloadGameLBL;
        public System.Windows.Forms.RichTextBox FilesRichTXT;
        public Guna.UI2.WinForms.Guna2HtmlLabel DownloadSpeedLBL;
        public Guna.UI2.WinForms.Guna2HtmlLabel DownloadGBLeftLBL;
        public Guna.UI2.WinForms.Guna2HtmlLabel DownloadETALBL;
    }
}