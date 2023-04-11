using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CF_Game_Center
{
    public partial class DownloadManager : Form
    {
        public DownloadManager()
        {
            InitializeComponent();
        }

        public static bool DownloadFinished = true;
        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {

        }

        private void guna2ProgressBar1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void CloseBTN_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}
