namespace CF_Game_Center
{
    partial class Download
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
            this.components = new System.ComponentModel.Container();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.DownloadLBL = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.MinimizeBTN = new Guna.UI2.WinForms.Guna2ControlBox();
            this.CloseBTN = new Guna.UI2.WinForms.Guna2ControlBox();
            this.SearchBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.DownloadGameSizeLBL = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.DownloadDiskSpaceLBL = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.Download_BTN = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.guna2Panel1.Controls.Add(this.MinimizeBTN);
            this.guna2Panel1.Controls.Add(this.DownloadLBL);
            this.guna2Panel1.Controls.Add(this.CloseBTN);
            this.guna2Panel1.Location = new System.Drawing.Point(-1, 1);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(800, 49);
            this.guna2Panel1.TabIndex = 0;
            // 
            // DownloadLBL
            // 
            this.DownloadLBL.BackColor = System.Drawing.Color.Transparent;
            this.DownloadLBL.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DownloadLBL.ForeColor = System.Drawing.Color.White;
            this.DownloadLBL.Location = new System.Drawing.Point(13, 13);
            this.DownloadLBL.Name = "DownloadLBL";
            this.DownloadLBL.Size = new System.Drawing.Size(129, 22);
            this.DownloadLBL.TabIndex = 0;
            this.DownloadLBL.Text = "Download {name}";
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
            // SearchBox
            // 
            this.SearchBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.SearchBox.BorderRadius = 4;
            this.SearchBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.SearchBox.DefaultText = "C:\\cf_game_center\\";
            this.SearchBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.SearchBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.SearchBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.SearchBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.SearchBox.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.SearchBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.SearchBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.SearchBox.ForeColor = System.Drawing.Color.White;
            this.SearchBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.SearchBox.Location = new System.Drawing.Point(187, 202);
            this.SearchBox.Name = "SearchBox";
            this.SearchBox.PasswordChar = '\0';
            this.SearchBox.PlaceholderText = "";
            this.SearchBox.SelectedText = "";
            this.SearchBox.Size = new System.Drawing.Size(426, 30);
            this.SearchBox.TabIndex = 3;
            this.SearchBox.TextChanged += new System.EventHandler(this.SearchBox_TextChanged);
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.ForeColor = System.Drawing.Color.White;
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(340, 174);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(102, 19);
            this.guna2HtmlLabel1.TabIndex = 5;
            this.guna2HtmlLabel1.Text = "Download Path:";
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 4;
            this.guna2Elipse1.TargetControl = this;
            // 
            // DownloadGameSizeLBL
            // 
            this.DownloadGameSizeLBL.BackColor = System.Drawing.Color.Transparent;
            this.DownloadGameSizeLBL.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DownloadGameSizeLBL.ForeColor = System.Drawing.Color.White;
            this.DownloadGameSizeLBL.Location = new System.Drawing.Point(187, 238);
            this.DownloadGameSizeLBL.Name = "DownloadGameSizeLBL";
            this.DownloadGameSizeLBL.Size = new System.Drawing.Size(74, 19);
            this.DownloadGameSizeLBL.TabIndex = 6;
            this.DownloadGameSizeLBL.Text = "Game Size :";
            // 
            // DownloadDiskSpaceLBL
            // 
            this.DownloadDiskSpaceLBL.BackColor = System.Drawing.Color.Transparent;
            this.DownloadDiskSpaceLBL.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DownloadDiskSpaceLBL.ForeColor = System.Drawing.Color.White;
            this.DownloadDiskSpaceLBL.Location = new System.Drawing.Point(437, 238);
            this.DownloadDiskSpaceLBL.Name = "DownloadDiskSpaceLBL";
            this.DownloadDiskSpaceLBL.Size = new System.Drawing.Size(77, 19);
            this.DownloadDiskSpaceLBL.TabIndex = 7;
            this.DownloadDiskSpaceLBL.Text = "Disk Space :";
            // 
            // Download_BTN
            // 
            this.Download_BTN.BorderRadius = 4;
            this.Download_BTN.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Download_BTN.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Download_BTN.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Download_BTN.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Download_BTN.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.Download_BTN.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Download_BTN.ForeColor = System.Drawing.Color.White;
            this.Download_BTN.Image = global::CF_Game_Center.Properties.Resources.Loginicon;
            this.Download_BTN.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.Download_BTN.ImageSize = new System.Drawing.Size(30, 30);
            this.Download_BTN.Location = new System.Drawing.Point(656, 400);
            this.Download_BTN.Name = "Download_BTN";
            this.Download_BTN.Size = new System.Drawing.Size(132, 38);
            this.Download_BTN.TabIndex = 8;
            this.Download_BTN.Text = "Download";
            this.Download_BTN.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.Download_BTN.Click += new System.EventHandler(this.Download_BTN_Click);
            // 
            // Download
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Download_BTN);
            this.Controls.Add(this.DownloadDiskSpaceLBL);
            this.Controls.Add(this.DownloadGameSizeLBL);
            this.Controls.Add(this.guna2HtmlLabel1);
            this.Controls.Add(this.SearchBox);
            this.Controls.Add(this.guna2Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Download";
            this.Text = "Download";
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2ControlBox MinimizeBTN;
        private Guna.UI2.WinForms.Guna2ControlBox CloseBTN;
        private Guna.UI2.WinForms.Guna2TextBox SearchBox;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2Button Download_BTN;
        public Guna.UI2.WinForms.Guna2HtmlLabel DownloadLBL;
        public Guna.UI2.WinForms.Guna2HtmlLabel DownloadDiskSpaceLBL;
        public Guna.UI2.WinForms.Guna2HtmlLabel DownloadGameSizeLBL;
    }
}