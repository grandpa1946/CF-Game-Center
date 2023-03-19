using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace CF_Game_Center
{
    public partial class DownloadPopup : Form
    {
        public static string mainpath;

        public bool playpressed;


        public DownloadPopup()
        {
            InitializeComponent();
            playpressed = false;
            char[] separator = "\\".ToCharArray();
            ((Control)(object)guna2HtmlLabel2).Text = "Disk Space Left : " + GetTotalFreeSpace(((Control)(object)guna2TextBox2).Text.Split(separator)[0] + "\\") + "GB";
        }

        private long GetTotalFreeSpace(string driveName)
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo driveInfo in drives)
            {
                if (driveInfo.IsReady && driveInfo.Name == driveName)
                {
                    return driveInfo.TotalFreeSpace / 1024 / 1024 / 1024;
                }
            }
            return -1L;
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {
            char[] separator = "\\".ToCharArray();
            ((Control)(object)guna2HtmlLabel2).Text = "Disk Space Left : " + GetTotalFreeSpace(((Control)(object)guna2TextBox2).Text.Split(separator)[0] + "\\") + "GB";
        }

        private void Download_Play_Click(object sender, EventArgs e)
        {
            playpressed = true;
            try
            {
                Directory.CreateDirectory(((Control)(object)guna2TextBox2).Text);
                char[] separator = "\\".ToCharArray();
                if (GetTotalFreeSpace(((Control)(object)guna2TextBox2).Text.Split(separator)[0] + "\\") > 1)
                {
                    if (!((Control)(object)guna2TextBox2).Text.EndsWith("\\"))
                    {
                        ((Control)(object)guna2TextBox2).Text += "\\";
                    }
                    mainpath = ((Control)(object)guna2TextBox2).Text;
                    Close();
                }
                else
                {
                    MessageBox.Show("Not enough disk space");
                    mainpath = "";
                    playpressed = false;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid Drive Letter");
                mainpath = "";
                playpressed = false;
                return;
            }
            Hide();
        }

        private void DownloadPopup_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!playpressed)
            {
                ((Control)(object)guna2TextBox2).Text = "";
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            ((Control)(object)guna2TextBox2).Text = "C:\\CF_Game_Center\\";
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            ((Control)(object)guna2TextBox2).Text = "D:\\CF_Game_Center\\";
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            ((Control)(object)guna2TextBox2).Text = "E:\\CF_Game_Center\\";
        }

        private void DownloadPopup_FormClosed(object sender, FormClosedEventArgs e)
        {
        }




    }

}

