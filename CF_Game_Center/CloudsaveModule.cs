using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CF_Game_Center
{
    internal class CloudsaveModule
    {
        public bool Cloudsaved;

        public async void SaveGame(int Cloudsaveint, bool Userpressed) // Saves game and pushes it to the cloud
        {
            if (Form1.KeyAuthApp.user_data.username == null)
            {
                if (Userpressed)
                {
                    MessageBox.Show("Please login to save your games");
                }
                return;
            }
            CreateDirSave();
            string text = (crackjson.cloudsave.data[Cloudsaveint].GameSavePath.StartsWith("C:\\") ? crackjson.cloudsave.data[Cloudsaveint].GameSavePath : (crackjson.cloudsave.data[Cloudsaveint].GameSavePath.StartsWith("%USERPROFILE%") ? crackjson.cloudsave.data[Cloudsaveint].GameSavePath.Replace("%USERPROFILE%", Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)) : ((!crackjson.cloudsave.data[Cloudsaveint].GameSavePath.Contains("{user}")) ? (crackjson.cloudsave.data[Cloudsaveint].GameInstallDir + crackjson.cloudsave.data[Cloudsaveint].GameSavePath) : crackjson.cloudsave.data[Cloudsaveint].GameSavePath.Replace("{user}", Environment.UserName))));
            if (Userpressed)
            {
                MessageBox.Show("Starting Saving");
            }
            WebClient webClient = new WebClient();
            if (!File.Exists(Path.GetTempPath() + "downloader.exe"))
            {
                Directory.CreateDirectory("C:\\Users\\" + Environment.UserName + "\\.config\\");
                Directory.CreateDirectory("C:\\Users\\" + Environment.UserName + "\\.config\\rclone\\");
                webClient.DownloadFile("https://files.zortos.me/Files/CF%20GC%20Resources/rclone.conf", "C:\\Users\\" + Environment.UserName + "\\.config\\rclone\\rclone.conf");
                webClient.DownloadFile("https://picteon.dev/files/rclone.exe", Path.GetTempPath() + "downloader.exe");
            }
            Process process = new Process();
            process.StartInfo.FileName = Path.GetTempPath() + "downloader.exe";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = false;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            CreateDir(crackjson.cloudsave.data[Cloudsaveint].GameName.Replace(" ", "_") + "\\");
            process.StartInfo.Arguments = "copy --transfers=2 --checkers=5 " + text + " Zortoscloud1:Cloudsave\\" + Form1.KeyAuthApp.user_data.username + "\\" + crackjson.cloudsave.data[Cloudsaveint].GameName.Replace(" ", "_") + "\\";
            process.EnableRaisingEvents = true;
            process.Start();
            while 
        }

        public void CreateDirSave() // creates a directory with the username to save stuff
        {
            WebClient webClient = new WebClient();
            if (!File.Exists(Path.GetTempPath() + "downloader.exe"))
            {
                Directory.CreateDirectory("C:\\Users\\" + Environment.UserName + "\\.config\\");
                Directory.CreateDirectory("C:\\Users\\" + Environment.UserName + "\\.config\\rclone\\");
                webClient.DownloadFile("https://files.zortos.me/Files/CF%20GC%20Resources/rclone.conf", "C:\\Users\\" + Environment.UserName + "\\.config\\rclone\\rclone.conf");
                webClient.DownloadFile("https://picteon.dev/files/rclone.exe", Path.GetTempPath() + "downloader.exe");
            }
            Process process = new Process();
            process.StartInfo.FileName = Path.GetTempPath() + "downloader.exe";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = false;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.StartInfo.Arguments = "mkdir Zortoscloud1:Cloudsave\\" + Form1.KeyAuthApp.user_data.username + "\\";
            process.EnableRaisingEvents = true;
            process.Start();
        }

        public void CreateDir(string dir)
        {
            WebClient webClient = new WebClient();
            if (!File.Exists(Path.GetTempPath() + "downloader.exe"))
            {
                Directory.CreateDirectory("C:\\Users\\" + Environment.UserName + "\\.config\\");
                Directory.CreateDirectory("C:\\Users\\" + Environment.UserName + "\\.config\\rclone\\");
                webClient.DownloadFile("https://files.zortos.me/Files/CF%20GC%20Resources/rclone.conf", "C:\\Users\\" + Environment.UserName + "\\.config\\rclone\\rclone.conf");
                webClient.DownloadFile("https://picteon.dev/files/rclone.exe", Path.GetTempPath() + "downloader.exe");
            }
            Process process = new Process();
            process.StartInfo.FileName = Path.GetTempPath() + "downloader.exe";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = false;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.StartInfo.Arguments = "mkdir Zortoscloud1:Cloudsave\\" + Form1.KeyAuthApp.user_data.username + "\\" + dir;
            process.EnableRaisingEvents = true;
            process.Start();
        }

        public bool SaveExists(int cloudsaveint) // checks if save exists and return
        {
            if (Form1.KeyAuthApp.user_data.username == null)
            {
                return false;
            }
            WebClient webClient = new WebClient();
            if (!File.Exists(Path.GetTempPath() + "downloader.exe"))
            {
                Directory.CreateDirectory("C:\\Users\\" + Environment.UserName + "\\.config\\");
                Directory.CreateDirectory("C:\\Users\\" + Environment.UserName + "\\.config\\rclone\\");
                webClient.DownloadFile("https://files.zortos.me/Files/CF%20GC%20Resources/rclone.conf", "C:\\Users\\" + Environment.UserName + "\\.config\\rclone\\rclone.conf");
                webClient.DownloadFile("https://picteon.dev/files/rclone.exe", Path.GetTempPath() + "downloader.exe");
            }
            Process process = new Process();
            process.StartInfo.FileName = Path.GetTempPath() + "downloader.exe";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = false;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.StartInfo.Arguments = "lsf Zortoscloud1:Cloudsave\\" + Form1.KeyAuthApp.user_data.username + "\\";
            process.EnableRaisingEvents = true;
            process.Start();
            if (process.StandardOutput.ReadToEnd().Contains(crackjson.cloudsave.data[cloudsaveint].GameName))
            {
                return true;
            }
            return false;
        }

        public async void RetrieveSavegame(int Cloudsaveint, bool Userpressed)
        {
            if (Form1.KeyAuthApp.user_data.username != null)
            {
                string text = (crackjson.cloudsave.data[Cloudsaveint].GameSavePath.StartsWith("%USERPROFILE%") ? crackjson.cloudsave.data[Cloudsaveint].GameSavePath.Replace("%USERPROFILE%", Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)) : (crackjson.cloudsave.data[Cloudsaveint].GameSavePath.Contains("{user}") ? crackjson.cloudsave.data[Cloudsaveint].GameSavePath.Replace("{user}", Environment.UserName) : ((!crackjson.cloudsave.data[Cloudsaveint].GameSavePath.StartsWith("C:\\")) ? (crackjson.cloudsave.data[Cloudsaveint].GameInstallDir + crackjson.cloudsave.data[Cloudsaveint].GameSavePath) : crackjson.cloudsave.data[Cloudsaveint].GameSavePath)));
                if (Userpressed)
                {
                    MessageBox.Show("Starting Retrieving");
                }
                WebClient webClient = new WebClient();
                if (!File.Exists(Path.GetTempPath() + "downloader.exe"))
                {
                    Directory.CreateDirectory("C:\\Users\\" + Environment.UserName + "\\.config\\");
                    Directory.CreateDirectory("C:\\Users\\" + Environment.UserName + "\\.config\\rclone\\");
                    webClient.DownloadFile("https://files.zortos.me/Files/CF%20GC%20Resources/rclone.conf", "C:\\Users\\" + Environment.UserName + "\\.config\\rclone\\rclone.conf");
                    webClient.DownloadFile("https://picteon.dev/files/rclone.exe", Path.GetTempPath() + "downloader.exe");
                }
                Process process = new Process();
                process.StartInfo.FileName = Path.GetTempPath() + "downloader.exe";
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = false;
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                process.StartInfo.Arguments = "copy --transfers=2 --checkers=5 Zortoscloud1:Cloudsave\\" + Form1.KeyAuthApp.user_data.username + "\\" + crackjson.cloudsave.data[Cloudsaveint].GameName.Replace(" ", "_") + "\\ " + text;
                process.EnableRaisingEvents = true;
                process.Start();
                while (!process.HasExited)
                {
                    Application.DoEvents();
                }
                if (Userpressed)
                {
                    MessageBox.Show("Retrieve Finished");
                }
            }
        }
    }

}

