namespace CF_Game_Center
{
    partial class Main
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
            this.Top_bar = new Guna.UI2.WinForms.Guna2Panel();
            this.Downloads_BTN = new Guna.UI2.WinForms.Guna2Button();
            this.Home_BTN = new Guna.UI2.WinForms.Guna2Button();
            this.MinimizeBTN = new Guna.UI2.WinForms.Guna2ControlBox();
            this.Official_BTN = new Guna.UI2.WinForms.Guna2Button();
            this.GFN_BTN = new Guna.UI2.WinForms.Guna2Button();
            this.CloseBTN = new Guna.UI2.WinForms.Guna2ControlBox();
            this.Cracked_BTN = new Guna.UI2.WinForms.Guna2Button();
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.GameFlowlayout = new System.Windows.Forms.FlowLayoutPanel();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.SearchBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.Top_bar.SuspendLayout();
            this.SuspendLayout();
            // 
            // Top_bar
            // 
            this.Top_bar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.Top_bar.Controls.Add(this.Downloads_BTN);
            this.Top_bar.Controls.Add(this.Home_BTN);
            this.Top_bar.Controls.Add(this.MinimizeBTN);
            this.Top_bar.Controls.Add(this.Official_BTN);
            this.Top_bar.Controls.Add(this.GFN_BTN);
            this.Top_bar.Controls.Add(this.CloseBTN);
            this.Top_bar.Controls.Add(this.Cracked_BTN);
            this.Top_bar.Location = new System.Drawing.Point(-2, 1);
            this.Top_bar.Name = "Top_bar";
            this.Top_bar.Size = new System.Drawing.Size(1058, 65);
            this.Top_bar.TabIndex = 0;
            // 
            // Downloads_BTN
            // 
            this.Downloads_BTN.BorderRadius = 4;
            this.Downloads_BTN.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Downloads_BTN.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Downloads_BTN.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Downloads_BTN.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Downloads_BTN.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.Downloads_BTN.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Downloads_BTN.ForeColor = System.Drawing.Color.White;
            this.Downloads_BTN.Image = global::CF_Game_Center.Properties.Resources.downloads_48px;
            this.Downloads_BTN.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.Downloads_BTN.ImageSize = new System.Drawing.Size(30, 30);
            this.Downloads_BTN.Location = new System.Drawing.Point(74, 11);
            this.Downloads_BTN.Name = "Downloads_BTN";
            this.Downloads_BTN.Size = new System.Drawing.Size(51, 45);
            this.Downloads_BTN.TabIndex = 8;
            this.Downloads_BTN.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.Downloads_BTN.Click += new System.EventHandler(this.Top_Buttons);
            // 
            // Home_BTN
            // 
            this.Home_BTN.BorderRadius = 4;
            this.Home_BTN.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Home_BTN.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Home_BTN.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Home_BTN.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Home_BTN.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.Home_BTN.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Home_BTN.ForeColor = System.Drawing.Color.White;
            this.Home_BTN.Image = global::CF_Game_Center.Properties.Resources.home_512px;
            this.Home_BTN.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.Home_BTN.ImageSize = new System.Drawing.Size(30, 30);
            this.Home_BTN.Location = new System.Drawing.Point(17, 11);
            this.Home_BTN.Name = "Home_BTN";
            this.Home_BTN.Size = new System.Drawing.Size(51, 45);
            this.Home_BTN.TabIndex = 4;
            this.Home_BTN.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.Home_BTN.Click += new System.EventHandler(this.Top_Buttons);
            // 
            // MinimizeBTN
            // 
            this.MinimizeBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MinimizeBTN.BorderRadius = 4;
            this.MinimizeBTN.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.MinimizeBTN.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.MinimizeBTN.IconColor = System.Drawing.Color.White;
            this.MinimizeBTN.Location = new System.Drawing.Point(952, 11);
            this.MinimizeBTN.Name = "MinimizeBTN";
            this.MinimizeBTN.Size = new System.Drawing.Size(45, 29);
            this.MinimizeBTN.TabIndex = 2;
            // 
            // Official_BTN
            // 
            this.Official_BTN.BorderRadius = 4;
            this.Official_BTN.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Official_BTN.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Official_BTN.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Official_BTN.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Official_BTN.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.Official_BTN.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Official_BTN.ForeColor = System.Drawing.Color.White;
            this.Official_BTN.Image = global::CF_Game_Center.Properties.Resources.minecraft_pickaxe_48px;
            this.Official_BTN.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.Official_BTN.ImageSize = new System.Drawing.Size(30, 30);
            this.Official_BTN.Location = new System.Drawing.Point(594, 11);
            this.Official_BTN.Name = "Official_BTN";
            this.Official_BTN.Size = new System.Drawing.Size(150, 45);
            this.Official_BTN.TabIndex = 3;
            this.Official_BTN.Text = "Official Games";
            this.Official_BTN.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.Official_BTN.Click += new System.EventHandler(this.Top_Buttons);
            // 
            // GFN_BTN
            // 
            this.GFN_BTN.BorderRadius = 4;
            this.GFN_BTN.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.GFN_BTN.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.GFN_BTN.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.GFN_BTN.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.GFN_BTN.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.GFN_BTN.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.GFN_BTN.ForeColor = System.Drawing.Color.White;
            this.GFN_BTN.Image = global::CF_Game_Center.Properties.Resources.nvidia_48px;
            this.GFN_BTN.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.GFN_BTN.ImageSize = new System.Drawing.Size(30, 30);
            this.GFN_BTN.Location = new System.Drawing.Point(438, 11);
            this.GFN_BTN.Name = "GFN_BTN";
            this.GFN_BTN.Size = new System.Drawing.Size(150, 45);
            this.GFN_BTN.TabIndex = 2;
            this.GFN_BTN.Text = "GFN Patched";
            this.GFN_BTN.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.GFN_BTN.Click += new System.EventHandler(this.Top_Buttons);
            // 
            // CloseBTN
            // 
            this.CloseBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseBTN.BorderRadius = 4;
            this.CloseBTN.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.CloseBTN.IconColor = System.Drawing.Color.White;
            this.CloseBTN.Location = new System.Drawing.Point(1003, 11);
            this.CloseBTN.Name = "CloseBTN";
            this.CloseBTN.Size = new System.Drawing.Size(45, 29);
            this.CloseBTN.TabIndex = 1;
            // 
            // Cracked_BTN
            // 
            this.Cracked_BTN.BorderRadius = 4;
            this.Cracked_BTN.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Cracked_BTN.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Cracked_BTN.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Cracked_BTN.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Cracked_BTN.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.Cracked_BTN.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Cracked_BTN.ForeColor = System.Drawing.Color.White;
            this.Cracked_BTN.Image = global::CF_Game_Center.Properties.Resources.Earth_Globe_96px;
            this.Cracked_BTN.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.Cracked_BTN.ImageSize = new System.Drawing.Size(30, 30);
            this.Cracked_BTN.Location = new System.Drawing.Point(282, 11);
            this.Cracked_BTN.Name = "Cracked_BTN";
            this.Cracked_BTN.Size = new System.Drawing.Size(150, 45);
            this.Cracked_BTN.TabIndex = 1;
            this.Cracked_BTN.Text = "Cracked Games";
            this.Cracked_BTN.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.Cracked_BTN.Click += new System.EventHandler(this.Top_Buttons);
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2DragControl1.TargetControl = this.Top_bar;
            this.guna2DragControl1.UseTransparentDrag = true;
            // 
            // GameFlowlayout
            // 
            this.GameFlowlayout.Location = new System.Drawing.Point(12, 109);
            this.GameFlowlayout.Name = "GameFlowlayout";
            this.GameFlowlayout.Size = new System.Drawing.Size(1034, 471);
            this.GameFlowlayout.TabIndex = 1;
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 4;
            this.guna2Elipse1.TargetControl = this;
            // 
            // SearchBox
            // 
            this.SearchBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.SearchBox.BorderRadius = 4;
            this.SearchBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.SearchBox.DefaultText = "";
            this.SearchBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.SearchBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.SearchBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.SearchBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.SearchBox.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.SearchBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.SearchBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.SearchBox.ForeColor = System.Drawing.Color.White;
            this.SearchBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.SearchBox.Location = new System.Drawing.Point(15, 73);
            this.SearchBox.Name = "SearchBox";
            this.SearchBox.PasswordChar = '\0';
            this.SearchBox.PlaceholderText = "Search Your Games Here!";
            this.SearchBox.SelectedText = "";
            this.SearchBox.Size = new System.Drawing.Size(1031, 30);
            this.SearchBox.TabIndex = 2;
            this.SearchBox.Visible = false;
            this.SearchBox.TextChanged += new System.EventHandler(this.guna2TextBox1_TextChanged);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(1058, 592);
            this.Controls.Add(this.SearchBox);
            this.Controls.Add(this.GameFlowlayout);
            this.Controls.Add(this.Top_bar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Main";
            this.Text = "Main";
            this.Top_bar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel Top_bar;
        private Guna.UI2.WinForms.Guna2Button Cracked_BTN;
        private Guna.UI2.WinForms.Guna2ControlBox CloseBTN;
        private Guna.UI2.WinForms.Guna2ControlBox MinimizeBTN;
        private Guna.UI2.WinForms.Guna2Button GFN_BTN;
        private Guna.UI2.WinForms.Guna2Button Official_BTN;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        private Guna.UI2.WinForms.Guna2Button Home_BTN;
        public System.Windows.Forms.FlowLayoutPanel GameFlowlayout;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2TextBox SearchBox;
        private Guna.UI2.WinForms.Guna2Button Downloads_BTN;
    }
}