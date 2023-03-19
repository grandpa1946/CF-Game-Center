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
        private GameDownloader downloader = new GameDownloader();

        private CloudsaveModule Cloudsavemodule = new CloudsaveModule();

        public async void LoadRecentGames(Form1 a)
        {
            await Task.Delay(1000);
            a.Main_Flowlayout_Recent.Controls.Clear();
            int num = 0;
            int num2 = 0;
            if (crackjson.game.crack.Count() - 10 < 0)
            {
                num = crackjson.game.crack.Count();
                num2 = crackjson.game.crack.Count() - 1;
            }
            else
            {
                num = crackjson.game.crack.Count() - 9;
                num2 = crackjson.game.crack.Count() - 1;
            }
            int num3 = num2;
            while (num3 >= num)
            {
                if (num3 >= 0)
                {
                    Guna2Panel panel = new Guna2Panel();
                    ((Control)(object)panel).BackColor = Color.Transparent;
                    MemoryStream stream = new MemoryStream(new WebClient().DownloadData(crackjson.game.crack[num3].GamePoster));
                    ((Control)(object)panel).Tag = num3;
                    ((Control)(object)panel).BackgroundImage = Image.FromStream(stream);
                    ((Control)(object)panel).BackgroundImageLayout = ImageLayout.Zoom;
                    panel.BorderColor = Color.Gray;
                    panel.BorderRadius = 8;
                    panel.BorderThickness = 3;
                    ((Control)(object)panel).Location = new Point(3, 3);
                    ((Control)(object)panel).Name = crackjson.game.crack[num3].Gamename;
                    ((Control)(object)panel).Size = new Size(121, 184);
                    ((Control)(object)panel).TabIndex = 10;
                    panel.UseTransparentBackground = true;
                    ((Control)(object)panel).Click += delegate
                    {
                        downloader.DownloadGame(int.Parse(((Control)(object)panel).Tag.ToString()), a.Download_Progressbar, a.Download_File, a.Download_SPEED, a.Download_ETA, a.Download_Title, a.Download_Banner, a.Download_Play, a);
                    };
                    a.Main_Flowlayout_Recent.Controls.Add((Control)(object)panel);
                    num3--;
                    continue;
                }
                break;
            }
        }

        public void LoadGames(Form1 a)
        {
            //IL_0049: Unknown result type (might be due to invalid IL or missing references)
            //IL_0053: Expected O, but got Unknown
            a.Games_Flow_Layout.Controls.Clear();
            crackjson.Root root = JsonConvert.DeserializeObject<crackjson.Root>(crackjson.getAPPjson());
            for (int i = 0; i < root.crack.Count(); i++)
            {
                Guna2Panel panel = new Guna2Panel();
                ((Control)(object)panel).BackColor = Color.Transparent;
                MemoryStream stream = new MemoryStream(new WebClient().DownloadData(root.crack[i].GamePoster));
                ((Control)(object)panel).BackgroundImage = Image.FromStream(stream);
                ((Control)(object)panel).BackgroundImageLayout = ImageLayout.Zoom;
                panel.BorderColor = Color.Gray;
                panel.BorderRadius = 4;
                panel.BorderThickness = 3;
                ((Control)(object)panel).Location = new Point(3, 3);
                ((Control)(object)panel).Name = root.crack[i].Gamename;
                ((Control)(object)panel).Size = new Size(121, 184);
                ((Control)(object)panel).TabIndex = 10;
                ((Control)(object)panel).Tag = i;
                panel.UseTransparentBackground = true;
                ((Control)(object)panel).Click += delegate
                {
                    downloader.DownloadGame(int.Parse(((Control)(object)panel).Tag.ToString()), a.Download_Progressbar, a.Download_File, a.Download_SPEED, a.Download_ETA, a.Download_Title, a.Download_Banner, a.Download_Play, a);
                };
                a.Games_Flow_Layout.Controls.Add((Control)(object)panel);
            }
        }

        public void LoadLibrary(Form1 a)
        {
            crackjson.cloudsave = JsonConvert.DeserializeObject<Rootsave>(File.ReadAllText(Application.UserAppDataPath + "\\installed.json"));
            if (!File.Exists(Application.UserAppDataPath + "\\installed.json"))
            {
                return;
            }
            a.Library_Flow_Layout.Controls.Clear();
            if (crackjson.cloudsave == null)
            {
                return;
            }
            for (int i = 0; i < crackjson.cloudsave.data.Count(); i++)
            {
                if (File.Exists(crackjson.cloudsave.data[i].GameInstallDir + crackjson.cloudsave.data[i].Gamelaunch))
                {
                    Guna2PictureBox val = new Guna2PictureBox();
                    val.BorderRadius = 5;
                    MemoryStream stream = new MemoryStream(new WebClient().DownloadData(crackjson.cloudsave.data[i].GameBanner));
                    ((PictureBox)(object)val).Image = Image.FromStream(stream);
                    val.ImageRotate = 0f;
                    ((Control)(object)val).Location = new Point(18, 14);
                    ((Control)(object)val).Name = crackjson.cloudsave.data[i].GameName + "_Banner";
                    ((Control)(object)val).Size = new Size(89, 133);
                    ((PictureBox)(object)val).SizeMode = PictureBoxSizeMode.Zoom;
                    ((PictureBox)(object)val).TabIndex = 0;
                    ((PictureBox)(object)val).TabStop = false;
                    Guna2HtmlLabel val2 = new Guna2HtmlLabel();
                    ((Control)(object)val2).BackColor = Color.Transparent;
                    ((Control)(object)val2).Font = new Font("Microsoft YaHei", 12.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
                    ((Control)(object)val2).ForeColor = Color.White;
                    ((Control)(object)val2).Location = new Point(118, 16);
                    ((Control)(object)val2).Name = crackjson.cloudsave.data[i].GameName + "_Title";
                    ((Control)(object)val2).Size = new Size(63, 26);
                    ((Control)(object)val2).TabIndex = 7;
                    ((Control)(object)val2).Text = crackjson.cloudsave.data[i].GameName;
                    Guna2HtmlLabel val3 = new Guna2HtmlLabel();
                    ((Control)(object)val3).BackColor = Color.Transparent;
                    ((Control)(object)val3).Font = new Font("Microsoft YaHei", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
                    ((Control)(object)val3).ForeColor = Color.White;
                    ((Control)(object)val3).Location = new Point(118, 48);
                    ((Control)(object)val3).Name = crackjson.cloudsave.data[i].GameName + "_Size";
                    ((Control)(object)val3).Size = new Size(41, 19);
                    ((Control)(object)val3).TabIndex = 15;
                    ((Control)(object)val3).Text = "Size: " + crackjson.cloudsave.data[i].GameSize;
                    Guna2Button button1 = new Guna2Button();
                    button1.BorderRadius = 6;
                    button1.DisabledState.BorderColor = Color.DarkGray;
                    button1.DisabledState.CustomBorderColor = Color.DarkGray;
                    button1.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
                    button1.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
                    button1.FillColor = Color.ForestGreen;
                    ((Control)(object)button1).Tag = crackjson.cloudsave.data[i].Id + "," + i;
                    ((Control)(object)button1).Font = new Font("Segoe UI", 9f);
                    ((Control)(object)button1).ForeColor = Color.White;
                    button1.ImageAlign = HorizontalAlignment.Left;
                    button1.ImageSize = new Size(35, 35);
                    ((Control)(object)button1).Location = new Point(458, 114);
                    ((Control)(object)button1).Name = crackjson.cloudsave.data[i].GameName + "_Play";
                    ((Control)(object)button1).Size = new Size(105, 33);
                    ((Control)(object)button1).TabIndex = 18;
                    ((Control)(object)button1).Text = "Play";
                    ((Control)(object)button1).Click += delegate
                    {
                        Form1.currentjsonint = int.Parse(((Control)(object)button1).Tag.ToString().Split(",".ToCharArray()[0])[0]);
                        DownloadPopup.mainpath = crackjson.cloudsave.data[int.Parse(((Control)(object)button1).Tag.ToString().Split(",".ToCharArray()[0])[1])].GameInstallDir;
                        downloader.startgame();
                    };
                    Guna2Button button2 = new Guna2Button();
                    button2.BorderRadius = 6;
                    button2.DisabledState.BorderColor = Color.DarkGray;
                    button2.DisabledState.CustomBorderColor = Color.DarkGray;
                    button2.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
                    button2.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
                    button2.FillColor = Color.LightSeaGreen;
                    ((Control)(object)button2).Font = new Font("Segoe UI", 9f);
                    ((Control)(object)button2).ForeColor = Color.White;
                    button2.ImageAlign = HorizontalAlignment.Left;
                    button2.ImageSize = new Size(35, 35);
                    ((Control)(object)button2).Location = new Point(347, 114);
                    ((Control)(object)button2).Name = crackjson.cloudsave.data[i].GameName + "_cloud_save";
                    ((Control)(object)button2).Size = new Size(105, 33);
                    ((Control)(object)button2).Tag = i;
                    ((Control)(object)button2).TabIndex = 17;
                    ((Control)(object)button2).Text = "Save";
                    ((Control)(object)button2).Click += delegate
                    {
                        Cloudsavemodule.SaveGame(int.Parse(((Control)(object)button2).Tag.ToString()), Userpressed: true);
                    };
                    Guna2Panel val4 = new Guna2Panel();
                    val4.BorderColor = Color.Gray;
                    val4.BorderRadius = 6;
                    val4.BorderThickness = 2;
                    ((Control)(object)val4).Controls.Add((Control)(object)button1);
                    ((Control)(object)val4).Controls.Add((Control)(object)button2);
                    ((Control)(object)val4).Controls.Add((Control)(object)val2);
                    ((Control)(object)val4).Controls.Add((Control)(object)val3);
                    ((Control)(object)val4).Controls.Add((Control)(object)val);
                    ((Control)(object)val4).Location = new Point(3, 3);
                    ((Control)(object)val4).Margin = new Padding(3, 3, 6, 6);
                    ((Control)(object)val4).Name = crackjson.cloudsave.data[i].GameName + "_Panel";
                    ((Control)(object)val4).Size = new Size(576, 163);
                    ((Control)(object)val4).TabIndex = 0;
                    a.Library_Flow_Layout.Controls.Add((Control)(object)val4);
                }
            }
        }

        public void LoadOfficial(Form1 a)
        {
        }
    }

}


