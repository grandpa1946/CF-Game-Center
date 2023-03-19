using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace CF_Game_Center
{
    internal class crackjson
    {
        public class Crack
        {
            public string Gamename { get; set; }

            public string GamePoster { get; set; }

            public string GameBanner { get; set; }

            public int GameSteamID { get; set; }

            public string GameDownload { get; set; }

            public string Gamelaunch { get; set; }

            public string GameSavePath { get; set; }

            public string GameExe { get; set; }

            public string GameSize { get; set; }
        }

        public class Root
        {
            public List<Crack> crack { get; set; }
        }

        public class Rootsave
        {
            public List<save> data { get; set; }
        }

        public class save
        {
            public int Id { get; set; }

            public string GameName { get; set; }

            public string GameBanner { get; set; }

            public string GameDownload { get; set; }

            public string GameSize { get; set; }

            public string Gamelaunch { get; set; }

            public string GameSavePath { get; set; }

            public string GameInstallDir { get; set; }
        }

        public static Rootsave cloudsave = JsonConvert.DeserializeObject<Rootsave>(File.ReadAllText(Application.UserAppDataPath + "\\installed.json"));

        public static Root game = JsonConvert.DeserializeObject<Root>(getAPPjson());

        public static string getAPPjson()
        {
            return new WebClient().DownloadString("https://files.zortos.me/Files/CF%20GC%20Resources/GameCenter.json");
        }
    }

}
