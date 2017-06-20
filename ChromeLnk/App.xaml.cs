using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Reflection;
using System.IO;

namespace ChromeLnk
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static Assembly myAssembly = Assembly.GetEntryAssembly();
        public static string ExecutablePath = myAssembly.Location;
        public static string StartupPath = Path.GetDirectoryName(ExecutablePath);
    }
}
