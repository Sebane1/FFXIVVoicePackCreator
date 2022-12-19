using AutoUpdaterDotNET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FFXIVVoicePackCreator {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            bool launchForm = true;
            AutoUpdater.DownloadPath = Application.StartupPath;
            AutoUpdater.Synchronous = true;
            AutoUpdater.Mandatory = true;
            AutoUpdater.UpdateMode = Mode.ForcedDownload;
            AutoUpdater.Start("https://raw.githubusercontent.com/Sebane1/FFXIVVoicePackCreator/main/update.xml");
            AutoUpdater.ApplicationExitEvent += delegate () {
                launchForm = false;
            };
            if (launchForm) {
                Application.EnableVisualStyles();
                Application.SetHighDpiMode(HighDpiMode.SystemAware);
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainWindow());
            }
        }
    }
}
