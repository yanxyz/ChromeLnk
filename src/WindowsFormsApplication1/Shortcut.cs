using IWshRuntimeLibrary;
using System;
using System.Text.RegularExpressions;

namespace WindowsFormsApplication1
{
    internal class Shortcut
    {
        public struct ShortCutParams
        {
            public string lnkPath { get; set; }
            public string targetPath { get; set; }
            public string arguments { get; set; }
        }

        public static void Write(ShortCutParams p)
        {
            string args = p.arguments;
            if (!String.IsNullOrEmpty(args))
            {
                var rgx = new Regex("[\r\n]");
                args = rgx.Replace(args, " ");
            }

            var shell = new WshShell();
            IWshShortcut lnk = shell.CreateShortcut(p.lnkPath);
            lnk.TargetPath = p.targetPath;
            if (!String.IsNullOrEmpty(args)) lnk.Arguments = args;
            lnk.Save();
        }

        public static ShortCutParams Read(string lnkPath)
        {
            var shell = new WshShell();
            IWshShortcut lnk = shell.CreateShortcut(lnkPath);
            var p = new ShortCutParams
            {
                lnkPath = lnkPath,
                targetPath = lnk.TargetPath
            };

            string args = lnk.Arguments;
            if (!String.IsNullOrEmpty(args))
            {
                var rgx = new Regex(@"\s+--");
                p.arguments = rgx.Replace(args, Environment.NewLine + "--");
            }

            return p;
        }
    }
}