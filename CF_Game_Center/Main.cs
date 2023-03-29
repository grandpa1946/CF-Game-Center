using Guna.UI2.WinForms;
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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }
        DynamicLoader loader = new DynamicLoader();
        public static DownloadManager downloadManager = new DownloadManager();
        private void Top_Buttons(object sender, EventArgs e)
        {
            Guna2Button btn = (sender as Guna2Button);
            switch (btn.Name)
            {
                case "Cracked_BTN":
                    SearchBox.Visible = true;
                    GameFlowlayout.Visible = true;
                    loader.ClearFlowPanel(this);
                    loader.LoadCrackGames(this);
                    break;
                case "GFN_BTN":
                    SearchBox.Visible = true;
                    GameFlowlayout.Visible = true;
                    break;
                case "Official_BTN":
                    GameFlowlayout.Visible = true;
                    SearchBox.Visible = true;
                    break;
                case "Home_BTN":
                    SearchBox.Visible = false;
                    GameFlowlayout.Visible = false;
                    break;
                case "Downloads_BTN":
                    GameFlowlayout.Visible = true;
                    SearchBox.Visible = true;
                    downloadManager.Show();
                    break;
            }
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            foreach (Guna2Panel control in GameFlowlayout.Controls)
            {
                Guna2Panel val = control;
                if (!val.Name.ToLower().Replace("_", " ").Contains(SearchBox.Text.ToLower()))
                {
                    val.Hide();
                }
                else if (val.Name.ToLower().Replace("_", " ").Contains(SearchBox.Text.ToLower()))
                {
                    val.Show();
                }
            }
        }
    }
}
