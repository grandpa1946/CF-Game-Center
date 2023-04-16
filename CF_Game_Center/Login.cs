using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KeyAuth;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CF_Game_Center
{
    public partial class Login : Form
    {
        public static api KeyAuthApp = new api(
            name: "ZortosPWET",
            ownerid: "0t0Sr0pLaB",
            secret: "d78a376b9d87c293b1e55f9f145779f82d3afbebf4519cb73317a269720ee259",
            version: "1.0"
        );

        public Login()
        {
            InitializeComponent();
        }
        public static bool LoggedIN()
        {
            if (!string.IsNullOrEmpty(KeyAuthApp.user_data.username))
            {
                return true;
            }
            else { return false; }
        }
        private void Cracked_BTN_Click(object sender, EventArgs e)
        {
            KeyAuthApp.login(usernameTXT.Text, passwordTXT.Text);
            if (KeyAuthApp.response.success)
            {
                this.Hide();
            }
            else
                MessageBox.Show(KeyAuthApp.response.message);
        }
    }
}
