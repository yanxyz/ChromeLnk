using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ChromeLnk
{
    internal class Utils
    {
        public static string GetZip()
        {
            string path;

            // use 7za.exe in the application directory first
            path = Path.Combine(App.StartupPath, "7za.exe");
            if (File.Exists(path)) return path;

            return GetFromProgramFiles(@"7-Zip\7z.exe");
        }

        private static string GetFromProgramFiles(string part)
        {
            var programFiles = Environment.GetEnvironmentVariable("ProgramFiles");
            var x86 = programFiles.EndsWith("(x86)");
            var path = x86 ?
                Path.Combine(programFiles.Replace(" (x86)", ""), part) :
                Path.Combine(programFiles, part);

            if (File.Exists(path)) return path;

            if (Environment.Is64BitOperatingSystem)
            {
                path = x86 ?
                    Path.Combine(programFiles, part) :
                    Path.Combine(programFiles + " (x86)", part);
                if (File.Exists(path)) return path;
            }

            return null;
        }

        public static string GetChrome()
        {
            string path;
            string p = @"Google\Chrome\Application\chrome.exe";

            path = Path.Combine(Environment.GetEnvironmentVariable("LOCALAPPDATA"), p);
            if (File.Exists(path)) return path;

            return GetFromProgramFiles(p);
        }

        public static string DesktopLnk()
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Chrome.lnk");
        }

        public static string GetInstallerVersion(string name)
        {
            // 44.0.2403.89_chrome_installer.exe
            // 45.0.2454.12_chrome64_installer.exe
            // 49.0.2623.108_chrome_installer_win64.exe
            var rgx = new Regex(@"(?<version>(\d+\.)+\d+)_chrome");
            Match match = rgx.Match(name.Trim());
            if (match.Success)
            {
                return match.Groups["version"].Value;
            }

            return null;
        }

        public static void Extract(string zip, string installer, string dest)
        {
            var startInfo = new ProcessStartInfo
            {
                FileName = zip,
                // Notice: -o{dir}
                // 1. no space after -o
                // 2. dir should be quoted in case of including space
                Arguments = $@"x ""{installer}"" -o""{dest}""",
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardError = true
            };

            var proc = new Process
            {
                StartInfo = startInfo
            };

            proc.Start();
            var error = proc.StandardError.ReadToEnd();
            proc.WaitForExit(60000);
            if (proc.ExitCode > 0)
            {
                throw new Exception($"7-Zip{error}");
            }

            var archive = Path.Combine(dest, "chrome.7z");
            startInfo.Arguments = $@"x ""{archive}"" -o""{dest}""";
            proc.Start();
            error = proc.StandardError.ReadToEnd();
            proc.WaitForExit(60000);
            if (proc.ExitCode > 0)
            {
                throw new Exception($"7-Zip{error}");
            }

            File.Delete(archive);
        }
    }
}