using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using CustomAlertBoxDemo;
using Guna.UI2;
using static System.Net.Mime.MediaTypeNames;
using static CF_Game_Center.Downloader;
using static CF_Game_Center.Download;

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

            // Args
            Process process = new Process();
            process.StartInfo.FileName = mainpath + "downloader.exe";
            process.StartInfo.Arguments = $"{command}";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = true;
            process.EnableRaisingEvents = true;


            // Start the download process
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
            string username = Login.KeyAuthApp.user_data.username;
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
        public void Save(int cloudsaveID)
        {
            
            string path = (crackjson.cloudsave.data[cloudsaveID].GameSavePath.StartsWith("%USERPROFILE%") ? crackjson.cloudsave.data[cloudsaveID].GameSavePath.Replace("%USERPROFILE%", Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)) : (crackjson.cloudsave.data[cloudsaveID].GameSavePath.Contains("{user}") ? crackjson.cloudsave.data[cloudsaveID].GameSavePath.Replace("{user}", Environment.UserName) : ((!crackjson.cloudsave.data[cloudsaveID].GameSavePath.StartsWith("C:\\")) ? (crackjson.cloudsave.data[cloudsaveID].GameInstallDir + crackjson.cloudsave.data[cloudsaveID].GameSavePath) : crackjson.cloudsave.data[cloudsaveID].GameSavePath)));
            string username = Login.KeyAuthApp.user_data.username;
            string rclonesave = rclone($"copy --transfers=2 --checkers=5 " + path + " Zortoscloud1:Cloudsave\\" + Login.KeyAuthApp.user_data.username + "\\" + crackjson.cloudsave.data[cloudsaveID].GameName.Replace(" ", "_") + "\\");
            if (string.IsNullOrEmpty(rclonesave))
            {
                Alert($"{crackjson.cloudsave.data[cloudsaveID].GameName} Saved!", Form_Alert.enmType.Success);
            }
            else
            {
                Alert($"Something went wrong while Saving", Form_Alert.enmType.Error);
            }
        }


        public void CreateDir()
        {
            rclone("mkdir Zortoscloud1:Cloudsave\\" + Login.KeyAuthApp.user_data.username + "\\");
        }

        /// <summary>
        /// Loads the save files to the game
        /// </summary>
        public void Load(int cloudsaveID)
        {
            string path = (crackjson.cloudsave.data[cloudsaveID].GameSavePath.StartsWith("%USERPROFILE%") ? crackjson.cloudsave.data[cloudsaveID].GameSavePath.Replace("%USERPROFILE%", Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)) : (crackjson.cloudsave.data[cloudsaveID].GameSavePath.Contains("{user}") ? crackjson.cloudsave.data[cloudsaveID].GameSavePath.Replace("{user}", Environment.UserName) : ((!crackjson.cloudsave.data[cloudsaveID].GameSavePath.StartsWith("C:\\")) ? (crackjson.cloudsave.data[cloudsaveID].GameInstallDir + crackjson.cloudsave.data[cloudsaveID].GameSavePath) : crackjson.cloudsave.data[cloudsaveID].GameSavePath)));
            string username = Login.KeyAuthApp.user_data.username;
            string rclonesave = rclone($"copy --transfers=2 --checkers=5 Zortoscloud1:Cloudsave\\" + Login.KeyAuthApp.user_data.username + "\\" + crackjson.cloudsave.data[cloudsaveID].GameName.Replace(" ", "_") + "\\ " + path);
        }
    }
}
