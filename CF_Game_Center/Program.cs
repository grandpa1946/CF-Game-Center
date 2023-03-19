using System;
using System.IO;
using System.Windows.Forms;
using Sentry;
using Sentry.Protocol;

namespace CF_Game_Center
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            using (SentrySdk.Init((Action<SentryOptions>)delegate (SentryOptions o)
            {
                o.Dsn = "https://eef7d361326a4570a3abd42c0da42a41@o1302473.ingest.sentry.io/4504561864671232";
                o.Debug = true;
                o.TracesSampleRate = 1.0;
                o.IsGlobalModeEnabled = true;
            }))

                Directory.CreateDirectory(Application.UserAppDataPath);

            if (!File.Exists(Application.UserAppDataPath + "\\\\installed.json"))
            {
                File.Create(Application.UserAppDataPath + "\\\\installed.json");
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(defaultValue: false);
            Application.Run(new Form1());
        }
    }
}


