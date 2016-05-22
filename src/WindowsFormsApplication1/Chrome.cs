using RunProcessAsTask;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Diagnostics;


namespace WindowsFormsApplication1
{

    internal class Chrome
    {
        
        public static string GetZipPath()
        {
            string path;

            // use 7za.exe in the application directory first
            path = Path.Combine(Env.ApplicationPath, "7za.exe");
            if (File.Exists(path)) return path;

            var p = @"7-Zip\7z.exe";

            if (Env.ProgramFiles64 != "")
            {
                path = Path.Combine(Env.ProgramFiles64, p);
                if (File.Exists(path)) return path;
            }

            path = Path.Combine(Env.ProgramFiles, p);
            if (File.Exists(path)) return path;

            return String.Empty;
        }

        public static string GetChromePath()
        {
            string path;
            string p = @"Google\Chrome\Application\chrome.exe";

            path = Path.Combine(Env.LocalAppData, p);
            if (File.Exists(path)) return path;

            if (Env.ProgramFiles64 != "")
            {
                path = Path.Combine(Env.ProgramFiles, p);
                if (File.Exists(path)) return path;
            }

            path = Path.Combine(Env.ProgramFiles, p);
            if (File.Exists(path)) return path;

            return String.Empty;
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

        public static async Task Extract(string installer,
            string zip, string output)
        {
            var processStartInfo = new ProcessStartInfo
            {
                FileName = zip,
                // Notice: -o{dir}
                // 1. no space after -o
                // 2. dir should be quoted in case of including space
                Arguments = $@"x ""{installer}"" -o""{output}""",
                CreateNoWindow = true
            };
            var results = await ProcessEx.RunAsync(processStartInfo);
            if (results.ExitCode > 0)
            {
                var error = String.Join(" ", results.StandardError);
                throw new Exception($"7-Zip\n{error}");
            }

            string archive = Path.Combine(output, "chrome.7z");
            processStartInfo.Arguments = $@"x ""{archive}"" -o""{output}""";
            results = await ProcessEx.RunAsync(processStartInfo);
            if (results.ExitCode > 0)
            {
                var error = String.Join(" ", results.StandardError);
                throw new Exception($"7-Zip\n{error}");
            }

            File.Delete(archive);
        }
    }
}