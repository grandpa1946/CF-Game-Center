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
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2ControlBox2 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.Official_BTN = new Guna.UI2.WinForms.Guna2Button();
            this.GFN_BTN = new Guna.UI2.WinForms.Guna2Button();
            this.Cracked_BTN = new Guna.UI2.WinForms.Guna2Button();
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.Top_bar.SuspendLayout();
            this.SuspendLayout();
            // 
            // Top_bar
            // 
            this.Top_bar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.Top_bar.Controls.Add(this.guna2ControlBox2);
            this.Top_bar.Controls.Add(this.Official_BTN);
            this.Top_bar.Controls.Add(this.GFN_BTN);
            this.Top_bar.Controls.Add(this.guna2ControlBox1);
            this.Top_bar.Controls.Add(this.Cracked_BTN);
            this.Top_bar.Location = new System.Drawing.Point(-2, 1);
            this.Top_bar.Name = "Top_bar";
            this.Top_bar.Size = new System.Drawing.Size(1058, 65);
            this.Top_bar.TabIndex = 0;
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox1.BorderRadius = 4;
            this.guna2ControlBox1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.guna2ControlBox1.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox1.Location = new System.Drawing.Point(1003, 11);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.Size = new System.Drawing.Size(45, 29);
            this.guna2ControlBox1.TabIndex = 1;
            // 
            // guna2ControlBox2
            // 
            this.guna2ControlBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox2.BorderRadius = 4;
            this.guna2ControlBox2.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.guna2ControlBox2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.guna2ControlBox2.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox2.Location = new System.Drawing.Point(952, 11);
            this.guna2ControlBox2.Name = "guna2ControlBox2";
            this.guna2ControlBox2.Size = new System.Drawing.Size(45, 29);
            this.guna2ControlBox2.TabIndex = 2;
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
            this.Official_BTN.Location = new System.Drawing.Point(591, 11);
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
            this.GFN_BTN.Location = new System.Drawing.Point(435, 11);
            this.GFN_BTN.Name = "GFN_BTN";
            this.GFN_BTN.Size = new System.Drawing.Size(150, 45);
            this.GFN_BTN.TabIndex = 2;
            this.GFN_BTN.Text = "GFN Patched";
            this.GFN_BTN.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.GFN_BTN.Click += new System.EventHandler(this.Top_Buttons);
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
            this.Cracked_BTN.Location = new System.Drawing.Point(279, 11);
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
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(1058, 592);
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
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox2;
        private Guna.UI2.WinForms.Guna2Button GFN_BTN;
        private Guna.UI2.WinForms.Guna2Button Official_BTN;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
    }
}