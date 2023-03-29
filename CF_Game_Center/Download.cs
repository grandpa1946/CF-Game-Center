using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CF_Game_Center
{
    public partial class Download : Form
    {
        public Download()
        {
            InitializeComponent();
        }
        public static string mainpath;
        public static bool Finished = false;
        private void Download_BTN_Click(object sender, EventArgs e)
        {
            try
            {
                Directory.CreateDirectory(SearchBox.Text);
                char[] separator = "\\".ToCharArray();
                if (GetTotalFreeSpace(SearchBox.Text.Split(separator)[0] + "\\") > 1)
                {
                    if (!SearchBox.Text.EndsWith("\\"))
                    {
                        SearchBox.Text += "\\";
                    }
                    mainpath = SearchBox.Text;
                    Finished =true;
                    
                    Hide();
                }
                else
                {
                    MessageBox.Show("Not enough disk space");
                    mainpath = "";
                    
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid Drive Letter");
                mainpath = "";
                return;
            }
            
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
            return -1;
        }

        private void SearchBox_TextChanged(object sender, EventArgs e)
        {
            char[] separator = "\\".ToCharArray();
            DownloadDiskSpaceLBL.Text = "Disk Space Left : " + GetTotalFreeSpace(SearchBox.Text.Split(separator)[0] + "\\") + "GB";
        }

        private void CloseBTN_Click(object sender, EventArgs e)
        {
            this.Hide();
            Finished = true;
        }
    }
}
