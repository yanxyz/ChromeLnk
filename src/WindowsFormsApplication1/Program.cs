using System;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }

    internal static class Env
    {
        // If app running on x64 system is compiled for x86,
        // %ProgramFiles% is the same as %ProgramFiles(x86)%.

        public static string ProgramFiles = Environment.GetEnvironmentVariable("ProgramFiles");
        public static string ProgramFiles64 = Environment.GetEnvironmentVariable("ProgramW6432");

        public static string LocalAppData = Environment.GetEnvironmentVariable("LOCALAPPDATA");
        public static string Temp = Environment.GetEnvironmentVariable("TEMP");
        public static string Desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        public static string ApplicationPath = Application.StartupPath;
        public static string SwitchesLink = @"http://peter.sh/experiments/chromium-command-line-switches/";
        public static string AboutLink = @"https://github.com/yanxyz/ChromeLnk";
        public static string ZipLink = @"http://www.7-zip.org/download.html";
    }
}