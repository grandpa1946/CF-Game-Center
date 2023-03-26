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

        private void Top_Buttons(object sender, EventArgs e)
        {
            Guna2Button btn = (sender as Guna2Button);
            switch (btn.Name)
            {
                case "Cracked_BTN":
                    MessageBox.Show("Funny joke");
                    break;
            }
        }
    }
}
