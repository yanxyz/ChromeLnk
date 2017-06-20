using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using System.ComponentModel;
using System.IO;

namespace ChromeLnk
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string[] _installerArgs;

        public MainWindow()
        {
            InitializeComponent();
            this.txtZip.Text = Utils.GetZip();
            this.txtChrome.Text = Utils.GetChrome();
            this.txtLnk.Text = Utils.DesktopLnk();
            this.FontSize = 14;
        }

        #region create shortcut
        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            tbStatus.Visibility = Visibility.Hidden;

            try
            {
                if (tabControl.SelectedIndex == 0)
                    HandleInstaller();
                else
                    HandleChrome();
            }
            catch (ValidationException ex)
            {
                SetStatus(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                btnOk.IsEnabled = true;
            }
        }

        private void HandleInstaller()
        {
            var installer = GetText(txtInstaller);
            if (!File.Exists(installer))
            {
                txtInstaller.Focus();
                txtInstaller.SelectAll();
                throw new ValidationException("Could not find installer");
            }

            var zip = GetText(txtZip);
            if (!File.Exists(zip))
            {
                txtZip.Focus();
                txtZip.SelectAll();
                throw new ValidationException("Could not find zip");
            }

            var dest = GetText(txtXDest);
            if (Directory.Exists(dest))
            {
                txtXDest.Focus();
                txtXDest.SelectAll();
                throw new ValidationException("Extracted dest already exists");
            }

            var lnk = GetText(txtXLnk);
            if (System.IO.Path.GetExtension(lnk) != ".lnk")
            {
                txtXDest.Focus();
                txtXLnk.SelectAll();
                throw new ValidationException("Extension is not .lnk");
            }

            var chromeExe = System.IO.Path.Combine(dest, @"Chrome-bin\chrome.exe");
            var args = GetText(txtXArgs, false);

            _installerArgs = new string[] { zip, installer, dest, lnk, chromeExe, args };
            btnOk.IsEnabled = false;
            var worker = new BackgroundWorker();
            worker.DoWork += Worker_DoWork;
            worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
            worker.RunWorkerAsync();
        }

        private string GetText(TextBox tb, bool required = true)
        {
            var input = tb.Text;
            var text = input.Trim();
            if (input != text) tb.Text = text;

            if (!required) return text;

            if (text == String.Empty)
            {
                tb.Focus();
                throw new ValidationException("required value");
            }
                
            return text;
        }

        private class ValidationException : Exception
        {
            public ValidationException(string message) : base(message)
            {
                //
            }
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            Utils.Extract(_installerArgs[0], _installerArgs[1], _installerArgs[2]);
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
                SetStatus("Extracting installer.exe failed");
            }
            else
            {
                var lnk = _installerArgs[3];
                Environment.SetEnvironmentVariable("ExtratedDest", _installerArgs[2]);
                Environment.SetEnvironmentVariable("LnkName", System.IO.Path.GetFileNameWithoutExtension(lnk));
                Shortcut.Write(lnk, _installerArgs[4], _installerArgs[5]);
            }

            btnOk.IsEnabled = true;
        }

        private void HandleChrome()
        {
            var chromeExe = GetText(this.txtChrome);
            if (!File.Exists(chromeExe))
            {
                this.txtChrome.Focus();
                this.txtChrome.SelectAll();
                throw new ValidationException("Could not find Chrome");
            }

            var lnk = GetText(this.txtLnk);
            if (System.IO.Path.GetExtension(lnk) != ".lnk")
            {
                txtXDest.Focus();
                txtXLnk.SelectAll();
                throw new ValidationException("Extension is not .lnk");
            }

            var args = GetText(txtArgs, false);

            Shortcut.Write(lnk, chromeExe, args);
        }

        private void SetStatus(string message)
        {
            tbStatus.Visibility = Visibility.Visible;
            tbStatus.Text = message;
        }

        #endregion

        #region drag and drop
        private void Wnd_Drop(object sender, DragEventArgs e)
        {
            e.Handled = true;
            var fileName = GetDraggedFile(e);
            Debug.WriteLine(fileName);

            if (String.IsNullOrEmpty(fileName)) return;

            if (fileName.EndsWith(".lnk"))
            {
                var parameters = Shortcut.Read(fileName);
                this.txtChrome.Text = parameters.TargetPath;
                this.txtLnk.Text = parameters.LnkPath;
                this.txtArgs.Text = parameters.Arguments;
                this.tabControl.SelectedIndex = 1;
                return;
            }

            var name = System.IO.Path.GetFileName(fileName);
            if (name == "chrome.exe")
            {
                this.tabControl.SelectedIndex = 1;
                this.txtChrome.Text = fileName;
                this.txtLnk.Text = Utils.DesktopLnk();
                return;
            }

            var index = name.IndexOf("_chrome_installer");
            Debug.WriteLine($"{name} {index}");
            if (index == -1) return;

            this.tabControl.SelectedIndex = 0;
            this.txtInstaller.Text = fileName;

            var dir = System.IO.Path.GetDirectoryName(fileName);
            var name2 = name.Substring(0, index + 7);
            var dest = System.IO.Path.Combine(dir, name2);
            this.txtXDest.Text = dest;
            this.txtXLnk.Text = dest + ".lnk";

            var sb = new StringBuilder();
            sb.AppendLine($@"--user-data-dir=""%ExtratedDest%\User Data""");
            sb.AppendLine($@"--disk-cache-dir=""%TEMP%\%LnkName%""");
            sb.AppendLine("--no-first-run");
            sb.AppendLine("--lang=\"en-US\"");
            this.txtXArgs.Text = sb.ToString();
        }

        private string GetDraggedFile(DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, true))
            {
                var fileNames = e.Data.GetData(DataFormats.FileDrop, true) as string[];
                var item = fileNames[0];
                if (item.EndsWith(".lnk") ||
                    item.EndsWith(".exe"))
                {
                    return item;
                }
            }
            return null;
        }
        #endregion

        private void Download7zip_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("http://www.7-zip.org/download.html");
        }

        private void Help_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("http://peter.sh/experiments/chromium-command-line-switches/");
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("https://github.com/yanxyz/ChromeLnk/");
        }
    }
}
