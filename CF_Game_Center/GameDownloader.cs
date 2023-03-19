using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Newtonsoft.Json;

namespace CF_Game_Center
{
    internal class GameDownloader
    {
        private bool Done = true;

        private CloudsaveModule cloudsavemodule = new CloudsaveModule();

        private Form1 a;

        private Guna2ProgressBar progressbar = new Guna2ProgressBar();

        private Guna2HtmlLabel FileViewer = new Guna2HtmlLabel();

        private Guna2HtmlLabel FileSPEED = new Guna2HtmlLabel();

        private Guna2HtmlLabel FileETA = new Guna2HtmlLabel();

        private Guna2PictureBox FileBanner = new Guna2PictureBox();

        private Guna2HtmlLabel Filetitle = new Guna2HtmlLabel();

        private Guna2Button FilePlaybtn = new Guna2Button();

        public async void DownloadGame(int JsonNumber, Guna2ProgressBar progressBar, Guna2HtmlLabel FILE, Guna2HtmlLabel SPEED, Guna2HtmlLabel ETA, Guna2HtmlLabel Title, Guna2PictureBox Banner, Guna2Button play, Form1 formies)
        {
            if (!Done)
            {
                MessageBox.Show("Cant Download while something is downloading");
                return;
            }
            ((Control)(object)play).Invoke((Delegate)(Action)delegate
            {
                ((Control)(object)play).Visible = false;
            });
            string userName = Environment.UserName;
            WebClient webClient = new WebClient();
            DownloadPopup downloadPopup = new DownloadPopup();
            ((Control)(object)downloadPopup.guna2HtmlLabel3).Text = "Game Size : " + crackjson.game.crack[JsonNumber].GameSize;
            ((Control)(object)downloadPopup.guna2HtmlLabel1).Text = "Game Name : " + crackjson.game.crack[JsonNumber].Gamename;
            downloadPopup.ShowDialog();
            if (DownloadPopup.mainpath == "" || DownloadPopup.mainpath == null)
            {
                MessageBox.Show("Please Select a Download Path");
                return;
            }
            ((TabControl)(object)formies.Panel_Switcher).SelectTab(5);
            if (!File.Exists(DownloadPopup.mainpath + "downloader.exe"))
            {
                Directory.CreateDirectory("C:\\Users\\" + userName + "\\.config\\");
                Directory.CreateDirectory("C:\\Users\\" + userName + "\\.config\\rclone\\");
                webClient.DownloadFile("https://files.zortos.me/Files/CF%20GC%20Resources/rclone.conf", "C:\\Users\\" + userName + "\\.config\\rclone\\rclone.conf");
                webClient.DownloadFile("https://picteon.dev/files/rclone.exe", DownloadPopup.mainpath + "downloader.exe");
            }
            progressbar = progressBar;
            FileViewer = FILE;
            FileSPEED = SPEED;
            FileETA = ETA;
            FileBanner = Banner;
            Filetitle = Title;
            Form1.currentjsonint = JsonNumber;
            FilePlaybtn = play;
            a = formies;
            byte[] buffer = new WebClient().DownloadData(crackjson.game.crack[JsonNumber].GameBanner);
            MemoryStream ms = new MemoryStream(buffer);
            ((Control)(object)FileBanner).Invoke((Delegate)(Action)delegate
            {
                ((PictureBox)(object)FileBanner).Image = Image.FromStream(ms);
            });
            ((Control)(object)Filetitle).Invoke((Delegate)(Action)delegate
            {
                ((Control)(object)Filetitle).Text = "Downloading : " + crackjson.game.crack[JsonNumber].Gamename;
            });
            Process process = new Process();
            process.OutputDataReceived += process_OutputDataReceived;
            process.StartInfo.FileName = DownloadPopup.mainpath + "downloader.exe";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = false;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.StartInfo.Arguments = "copy -P --transfers=4 --checkers=16 " + crackjson.game.crack[JsonNumber].GameDownload + " " + DownloadPopup.mainpath;
            Done = false;
            process.Exited += p_Exited;
            process.EnableRaisingEvents = true;
            process.Start();
            process.BeginOutputReadLine();
            while (!Done)
            {
                Application.DoEvents();
            }
            Gameinstalled(Form1.currentjsonint);
            await Task.Delay(5000);
            if (!string.IsNullOrEmpty(Form1.KeyAuthApp.user_data.username))
            {
                try
                {
                    if (cloudsavemodule.SaveExists(crackjson.cloudsave.data.Count() - 1))
                    {
                        ((Control)(object)a.Download_Checksaves).Invoke((Delegate)(Action)delegate
                        {
                            ((Control)(object)a.Download_Checksaves).Visible = true;
                        });
                        cloudsavemodule.RetrieveSavegame(crackjson.cloudsave.data.Count() - 1, Userpressed: false);
                        ((Control)(object)a.Download_Checksaves).Invoke((Delegate)(Action)delegate
                        {
                            ((Control)(object)a.Download_Checksaves).Text = "Save Found And Downloaded ;)";
                        });
                        await Task.Delay(2000);
                        ((Control)(object)a.Download_Checksaves).Invoke((Delegate)(Action)delegate
                        {
                            ((Control)(object)a.Download_Checksaves).Visible = false;
                        });
                        ((Control)(object)a.Download_Checksaves).Invoke((Delegate)(Action)delegate
                        {
                            ((Control)(object)a.Download_Checksaves).Text = "Checking For Saves";
                        });
                    }
                }
                catch (Exception)
                {
                }
            }
            ((Control)(object)FilePlaybtn).Invoke((Delegate)(Action)delegate
            {
                ((Control)(object)FilePlaybtn).Visible = true;
            });
        }

        private void process_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            _ = Environment.UserName;
            try
            {
                if (Process.GetProcessesByName("downloader").Length != 0 && e.Data.Contains("ETA"))
                {
                    string data = e.Data;
                    string text = data.Substring(data.IndexOf("Transferred:"));
                    int progress = 0;
                    int num = text.IndexOf('%');
                    string[] split = text.Split(',');
                    ((Control)(object)FileViewer).Invoke((Delegate)(Action)delegate
                    {
                        ((Control)(object)FileViewer).Text = split[0];
                    });
                    ((Control)(object)FileSPEED).Invoke((Delegate)(Action)delegate
                    {
                        ((Control)(object)FileSPEED).Text = split[2];
                    });
                    ((Control)(object)FileETA).Invoke((Delegate)(Action)delegate
                    {
                        ((Control)(object)FileETA).Text = split[3];
                    });
                    if (num >= 0)
                    {
                        string text2 = text.Substring(0, num);
                        int.TryParse(text2.Substring(text2.IndexOf(",") + 1), out progress);
                    }
                    ((Control)(object)progressbar).Invoke((Delegate)(Action)delegate
                    {
                        progressbar.Value = progress;
                    });
                }
            }
            catch (Exception ex)
            {
                _ = ex is NullReferenceException;
            }
        }

        private async void p_Exited(object sender, EventArgs e)
        {
            try
            {
                ((Control)(object)FileViewer).Invoke((Delegate)(Action)delegate
                {
                    ((Control)(object)FileViewer).Text = string.Empty;
                });
                ((Control)(object)progressbar).Invoke((Delegate)(Action)delegate
                {
                    progressbar.Value = 0;
                });
                Done = true;
            }
            catch (Exception)
            {
                return;
            }
            Done = true;
        }

        public void Gameinstalled(int Gameint)
        {
            if (!File.Exists(Application.UserAppDataPath + "\\installed.json"))
            {
                File.Create(Application.UserAppDataPath + "\\installed.json");
            }
            string text = File.ReadAllText(Application.UserAppDataPath + "\\installed.json");
            crackjson.Rootsave rootsave = JsonConvert.DeserializeObject<crackjson.Rootsave>(text);
            if (text == "")
            {
                rootsave = new crackjson.Rootsave();
                rootsave.data = new List<crackjson.save>();
            }
            if (rootsave.data == null || !rootsave.data.Any((crackjson.save x) => x.GameName == crackjson.game.crack[Gameint].Gamename))
            {
                rootsave.data.Add(new crackjson.save
                {
                    GameBanner = crackjson.game.crack[Gameint].GamePoster,
                    GameName = crackjson.game.crack[Gameint].Gamename,
                    GameDownload = crackjson.game.crack[Gameint].GameDownload,
                    Id = Gameint,
                    GameSize = crackjson.game.crack[Gameint].GameSize,
                    GameSavePath = crackjson.game.crack[Gameint].GameSavePath,
                    Gamelaunch = crackjson.game.crack[Gameint].Gamelaunch,
                    GameInstallDir = DownloadPopup.mainpath
                });
                string contents = JsonConvert.SerializeObject((object)rootsave, (Formatting)1);
                File.WriteAllText(Application.UserAppDataPath + "\\installed.json", contents);
            }
        }

        public bool startgame()
        {
            if (File.Exists(DownloadPopup.mainpath + crackjson.game.crack[Form1.currentjsonint].Gamelaunch))
            {
                Process.Start(DownloadPopup.mainpath + crackjson.game.crack[Form1.currentjsonint].Gamelaunch);
                return true;
            }
            return false;
        }
    }

}

