using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Net;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Enums;
using KeyAuth;

namespace CF_Game_Center
{
	public partial class Form1 : Form
	{
		private DynamicLoader loader = new DynamicLoader();
	
		private GameDownloader downloader = new GameDownloader();
	
		public static int currentjsonint;
	
		public static api KeyAuthApp = new api("CF Early", "0t0Sr0pLaB", "c52ed8ebcefc829ffed9a73e9c85b73fd5a8e244abec5531ef1cf87628d181e0", "1.0");
		
	
		public Form1()
		{
			InitializeComponent();
			loader.LoadRecentGames(this);
			loader.LoadGames(this);
			KeyAuthApp.init();
			if (!KeyAuthApp.response.success)
			{
				MessageBox.Show(KeyAuthApp.response.message);
			}
		}
	
		private void Nav_Buttons(object sender, EventArgs e)
		{
			Guna2CirclePictureBox val = (Guna2CirclePictureBox)((sender is Guna2CirclePictureBox) ? sender : null);
			if (val != null)
			{
				if (((Control)(object)val).Name == "Nav_Home")
				{
					((TabControl)(object)Panel_Switcher).SelectTab(0);
				}
				return;
			}
			switch (((Control)((sender is Guna2Button) ? sender : null)).Name)
			{
			case "Nav_Games":
				Panel_Switcher.SelectTab(1);
				break;
			case "Nav_Steam_Games":
				((TabControl)(object)Panel_Switcher).SelectTab(2);
				break;
			case "Nav_Library":
				loader.LoadLibrary(this);
				((TabControl)(object)Panel_Switcher).SelectTab(3);
				break;
			}
		}
	
		private void guna2TextBox1_TextChanged(object sender, EventArgs e)
		{
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Expected O, but got Unknown
			foreach (Guna2Panel control in Games_Flow_Layout.Controls)
			{
				Guna2Panel val = control;
				if (!((Control)(object)val).Name.ToLower().Replace("_", " ").Contains(((Control)(object)Game_Search_Bar).Text.ToLower()))
				{
					((Control)(object)val).Hide();
				}
				else if (((Control)(object)val).Name.ToLower().Replace("_", " ").Contains(((Control)(object)Game_Search_Bar).Text.ToLower()))
				{
					((Control)(object)val).Show();
				}
			}
		}
	
		private void guna2Button1_Click(object sender, EventArgs e)
		{
			MessageBox.Show("This feature is not available yet");
		}
	
		private void guna2Button2_Click(object sender, EventArgs e)
		{
			MessageBox.Show("This feature is not available yet");
		}
	
		private void guna2Button3_Click(object sender, EventArgs e)
		{
			downloader.startgame();
		}
	
		private void cloudsaveTimer_Tick(object sender, EventArgs e)
		{
		}
	
		private void guna2Button5_Click(object sender, EventArgs e)
		{
			((TabControl)(object)Panel_Switcher).SelectTab(7);
		}
	
		private void guna2Button4_Click(object sender, EventArgs e)
		{
			KeyAuthApp.login(((Control)(object)Username).Text, ((Control)(object)Password).Text);
			if (KeyAuthApp.response.success)
			{
				if (Login_Remember.Checked)
				{
					File.WriteAllText(Path.GetTempPath() + "j2o19j19u2.txt", ((Control)(object)Username).Text + "," + ((Control)(object)Password).Text);
				}
				((TabControl)(object)Panel_Switcher).SelectTab(0);
				((Control)(object)WelcomeMSG).Text = "Welcome Home " + KeyAuthApp.user_data.username;
			}
			else
			{
				MessageBox.Show("Invalid username or password");
			}
		}
	
		private void guna2Button6_Click(object sender, EventArgs e)
		{
			((TabControl)(object)Panel_Switcher).SelectTab(6);
		}
	
		private void guna2HtmlLabel2_Click(object sender, EventArgs e)
		{
		}
	
		private void Form1_Shown(object sender, EventArgs e)
		{
			if (File.Exists(Path.GetTempPath() + "j2o19j19u2.txt"))
			{
				string[] array = File.ReadAllText(Path.GetTempPath() + "j2o19j19u2.txt").Split(',');
				KeyAuthApp.login(array[0], array[1]);
				if (!KeyAuthApp.response.success)
				{
					MessageBox.Show(KeyAuthApp.response.message);
				}
				else
				{
					((Control)(object)WelcomeMSG).Text = "Welcome Home " + KeyAuthApp.user_data.username;
				}
			}
		}
	
		private void guna2Button8_Click(object sender, EventArgs e)
		{
			((TabControl)(object)Panel_Switcher).SelectTab(6);
		}
	
		private void guna2Button7_Click(object sender, EventArgs e)
		{
			string address = KeyAuthApp.var("reg").Replace("usernamehere", ((Control)(object)Reg_username).Text).Replace("passwordhere", ((Control)(object)Reg_password).Text);
			string text = new WebClient().DownloadString(address);
			if (text.Contains("\"success\":true"))
			{
				MessageBox.Show("Account Created successfully");
				((TabControl)(object)Panel_Switcher).SelectTab(6);
			}
			else
			{
				MessageBox.Show("Error!\n" + text);
			}
		}
	
		
	}
}
