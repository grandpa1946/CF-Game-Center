using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Newtonsoft.Json;
using static CF_Game_Center.crackjson;


namespace CF_Game_Center {
    internal class DynamicLoader
    {
        //private GameDownloader downloader = new GameDownloader();

        //private CloudsaveModule Cloudsavemodule = new CloudsaveModule();
        private Downloader downloader = new Downloader();
        public void ClearFlowPanel(Main main)
        {
            main.GameFlowlayout.Controls.Clear();
        }
        public void LoadCrackGames(Main main)
        {
            for (int i = 0; i < cracked.crack.Count(); i++)
            {
                Guna2Panel panel = new Guna2Panel();
                Guna2PictureBox picturebox = new Guna2PictureBox();
                panel.BorderColor = System.Drawing.Color.LightGray;
                panel.BorderRadius = 4;
                panel.BorderThickness = 2;
                panel.Controls.Add(picturebox);
                panel.Location = new System.Drawing.Point(3, 3);
                panel.Name = cracked.crack[i].Gamename + "Panel";
                panel.Size = new System.Drawing.Size(104, 152);
                panel.TabIndex = 1;
                // Picturebox (AKA Button)
                picturebox.FillColor = Color.DimGray;
                picturebox.ImageRotate = 0F;
                picturebox.Location = new Point(6, 4);
                picturebox.Tag = i; 
                picturebox.Name = cracked.crack[i].Gamename + "BTN"; // Gamename + BTN
                picturebox.Load(cracked.crack[i].GamePoster); 
                picturebox.SizeMode = PictureBoxSizeMode.Zoom;
                picturebox.Size = new Size(94, 145);
                picturebox.TabIndex = 0;
                picturebox.TabStop = false;
                picturebox.Click += (sender, args) =>
                {
                    MessageBox.Show(picturebox.Tag.ToString());
                    downloader.ShowDownloadPrompt(Convert.ToInt32(picturebox.Tag.ToString()), "cracked");
                };
                main.GameFlowlayout.Controls.Add(panel);
            }
           
        }

        public void LoadOfficialGames()
        {

        }
        public void LoadGFNGames()
        {

        }

    }

}


