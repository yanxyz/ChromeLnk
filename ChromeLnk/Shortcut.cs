using IWshRuntimeLibrary;
using System;
using System.Text.RegularExpressions;

namespace ChromeLnk
{
    internal class Shortcut
    {
        public struct ShortCutParams
        {
            public string LnkPath { get; set; }
            public string TargetPath { get; set; }
            public string Arguments { get; set; }
        }

        public static ShortCutParams Read(string lnkPath)
        {
            var shell = new WshShell();
            IWshShortcut lnk = shell.CreateShortcut(lnkPath);
            var shortCutparams = new ShortCutParams
            {
                LnkPath = lnkPath,
                TargetPath = lnk.TargetPath
            };

            string args = lnk.Arguments;
            if (!String.IsNullOrEmpty(args))
            {
                var rgx = new Regex(@"\s+--");
                shortCutparams.Arguments = rgx.Replace(args, Environment.NewLine + "--");
            }

            return shortCutparams;
        }

        public static void Write(string lnkPath, string targetPath, string arguments)
        {
            if (!String.IsNullOrEmpty(arguments))
            {
                arguments = Environment.ExpandEnvironmentVariables(arguments);
                var rgx = new Regex("[\r\n]");
                arguments = rgx.Replace(arguments, " ");
            }

            var shell = new WshShell();
            IWshShortcut lnk = shell.CreateShortcut(lnkPath);
            lnk.TargetPath = targetPath;
            lnk.Arguments = arguments;
            lnk.Save();
        }
    }
}