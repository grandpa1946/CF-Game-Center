using Guna.UI2;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static CF_Game_Center.Download;
using static System.Net.Mime.MediaTypeNames;

namespace CF_Game_Center
{
    internal class SaveModule
    {
        #region Strings/Bools
        public bool Done = true;

        #endregion
        /// <summary>
        /// runs rclone commands 
        /// </summary>
        /// <param name="command"></param>
        /// <returns>Rclone Output</returns>
        public string rclone(string command)
        {
            string userName = Environment.UserName;
            WebClient webClient = new WebClient();

            // Check if the downloader.exe file exists in the download path
            if (!File.Exists(mainpath + "downloader.exe"))
            {
                // If not, download rclone.conf and downloader.exe
                Directory.CreateDirectory($"C:\\Users\\{userName}\\.config\\rclone");
                webClient.DownloadFile("https://files.zortos.me/Files/CF%20GC%20Resources/rclone.conf", $"C:\\Users\\{userName}\\.config\\rclone\\rclone.conf");
                webClient.DownloadFile("https://picteon.dev/files/rclone.exe", mainpath + "downloader.exe");
            }



            Process process = new Process();
            process.StartInfo.FileName = mainpath + "downloader.exe";
            process.StartInfo.Arguments = $"{command}";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = true;

            // Set up events to monitor the progress of the download process
            process.EnableRaisingEvents = true;


            // Start the download process and show the progress bar
            Done = false;
            process.Start();
            process.BeginOutputReadLine();
            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            return output;
        }

        /// <summary>
        /// Checks if save exists
        /// </summary>
        /// <returns>True or False</returns>
        public bool Checksave()
        {
            // add keyauth username
            string username = "a";
            // need to change cloud drive
            string rclonesave = rclone($"lsf Zortoscloud1:Cloudsave\\{username}\\");
            if (rclonesave.Contains(crackjson.cloudsave.data[crackjson.cloudsave.data.Count() - 1].GameName))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// saves the save files to the cloud
        /// </summary>
        public void Save()
        {
            string rclonesave = rclone("");
        }

        /// <summary>
        /// Loads the save files to the game
        /// </summary>
        public void Load()
        {
            //string text = (crackjson.cloudsave.data[Cloudsaveint].GameSavePath.StartsWith("%USERPROFILE%") ? crackjson.cloudsave.data[Cloudsaveint].GameSavePath.Replace("%USERPROFILE%", Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)) : (crackjson.cloudsave.data[Cloudsaveint].GameSavePath.Contains("{user}") ? crackjson.cloudsave.data[Cloudsaveint].GameSavePath.Replace("{user}", Environment.UserName) : ((!crackjson.cloudsave.data[Cloudsaveint].GameSavePath.StartsWith("C:\\")) ? (crackjson.cloudsave.data[Cloudsaveint].GameInstallDir + crackjson.cloudsave.data[Cloudsaveint].GameSavePath) : crackjson.cloudsave.data[Cloudsaveint].GameSavePath)));
            //string rcloneload = rclone("copy --transfers=2 --checkers=5 Zortoscloud1:Cloudsave\\" + Form1.KeyAuthApp.user_data.username + "\\" + crackjson.cloudsave.data[Cloudsaveint].GameName.Replace(" ", "_") + "\\ " + text);
        }
    }
}
