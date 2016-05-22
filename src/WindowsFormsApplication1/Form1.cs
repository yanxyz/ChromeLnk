using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            this.Text = Application.ProductName;
            InitializeComponent();
            bindEvents();
            setStatus();
            zipTextBox.Text = Chrome.GetZipPath();

            chromeTextBox.Text = Chrome.GetChromePath();
            lnkDirTextBox.Text = Env.Desktop;
        }

        private void bindEvents()
        {
            string installer = "";
            string lnkName = "";

            #region create shortcut

            createButton.Click += async (s, e) =>
            {
                string lnkPath, exePath, args;
                var requiredMessage = "Input is required";
                var errorMessage = "Input value is error";
                var isInstallerPage = tabControl1.SelectedIndex == 0;

                #region validate installer

                if (isInstallerPage)
                {
                    installer = installerTextBox.Text.Trim();
                    if (installer == "")
                    {
                        setStatus(requiredMessage);
                        installerTextBox.Focus();
                        return;
                    }
                    if (!File.Exists(installer))
                    {
                        showError($"Could not find:\n{installer}");
                        setStatus(errorMessage);
                        installerTextBox.Select();
                        return;
                    }

                    var zip = zipTextBox.Text.Trim();
                    if (zip == "")
                    {
                        setStatus(requiredMessage);
                        zipTextBox.Focus();
                        return;
                    }
                    if (!File.Exists(zip))
                    {
                        showError($"Could not find:\n{zip}");
                        setStatus(errorMessage);
                        zipTextBox.Select();
                        return;
                    }

                    var zipOutput = zipOutputTextBox.Text.Trim();
                    if (zipOutput == "")
                    {
                        suggestInstaller(installer);
                        setStatus(requiredMessage);
                        zipOutputTextBox.Focus();
                        return;
                    }
                    if (Directory.Exists(zipOutput))
                    {
                        showError("Zip output directory already exist.");
                        setStatus(errorMessage);
                        zipOutputTextBox.Select();
                        return;
                    }

                    lnkPath = lnkTextBox.Text.Trim();
                    if (lnkPath == "")
                    {
                        suggestInstaller(installer);
                        setStatus(requiredMessage);
                        lnkTextBox.Focus();
                        return;
                    }
                    if (!isLnk(lnkPath))
                    {
                        showError($"File extension is not \".lnk\"\n{lnkPath}");
                        setStatus(errorMessage);
                        lnkTextBox.Select();
                        return;
                    }

                    args = argsRichTextBox.Text.Trim();
                    if (args == "")
                    {
                        suggestInstaller(installer);
                        setStatus(requiredMessage);
                        argsRichTextBox.Focus();
                        return;
                    }

                    createButton.Enabled = false;
                    setStatus("Extracing installer...");
                    try
                    {
                        await Chrome.Extract(installer, zip, zipOutput);
                    }
                    catch (Exception ex)
                    {
                        showError(ex.Message);
                        setStatus("Failed to extract installer");
                        return;
                    }

                    createButton.Enabled = true;
                    exePath = Path.Combine(zipOutput, @"Chrome-bin\chrome.exe");
                }

                #endregion validate installer

                #region validate chrome

                else
                {
                    exePath = chromeTextBox.Text;
                    if (exePath == "")
                    {
                        setStatus(requiredMessage);
                        chromeTextBox.Focus();
                        return;
                    }

                    if (!File.Exists(exePath))
                    {
                        showError($"Could not find:\n{exePath}");
                        setStatus(errorMessage);
                        lnkNameTextBox.Select();
                        return;
                    }

                    lnkName = lnkNameTextBox.Text.Trim();
                    if (lnkName == "")
                    {
                        setStatus(requiredMessage);
                        lnkNameTextBox.Focus();
                        return;
                    }

                    var lnkDir = lnkDirTextBox.Text.Trim();
                    if (lnkDir == "")
                    {
                        setStatus(requiredMessage);
                        lnkDirTextBox.Focus();
                        return;
                    }

                    // check extension otherwise lnkName "41.0.2272.118_chrome" will be "41.0.2272"
                    if (Path.GetExtension(lnkName).ToLower() == ".lnk")
                    {
                        lnkName = Path.GetFileNameWithoutExtension(lnkName);
                    }
                    lnkPath = Path.Combine(lnkDir, $"{lnkName}.lnk");

                    args = argsRichTextBox2.Text.Trim();
                    if (args == "")
                    {
                        if (argsCheckBox.Checked)
                        {
                            suggestChrome(lnkName, lnkDir);
                        }
                        setStatus(requiredMessage);

                        argsRichTextBox2.Focus();
                        return;
                    }
                }

                #endregion validate chrome

                setStatus("Creating shortcut...");
                Shortcut.Write(new Shortcut.ShortCutParams
                {
                    lnkPath = lnkPath,
                    targetPath = exePath,
                    arguments = args
                });

                setStatus();
            };

            #endregion create shortcut

            #region suggest

            installerTextBox.GotFocus += (s, e) =>
            {
                installer = installerTextBox.Text.Trim();
            };

            installerTextBox.LostFocus += (s, e) =>
            {
                string value = installerTextBox.Text.Trim();
                if (value == installer) return;

                installer = value;
                suggestInstaller(installer);
            };

            lnkNameTextBox.GotFocus += (s, e) =>
            {
                lnkName = lnkNameTextBox.Text.Trim();
            };

            lnkNameTextBox.LostFocus += (s, e) =>
            {
                if (!argsCheckBox.Checked) return;

                string value = lnkNameTextBox.Text.Trim();
                if (value == lnkName) return;

                lnkName = value;

                var lnkDir = lnkDirTextBox.Text.Trim();
                if (lnkDir == "")
                {
                    lnkDir = Env.LocalAppData;
                    lnkDirTextBox.Text = lnkDir;
                }

                suggestChrome(lnkName, lnkDir);
            };

            #endregion suggest

            #region drag-and-drop

            this.AllowDrop = true;

            this.DragEnter += (s, e) =>
            {
                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    var files = (string[])e.Data.GetData(DataFormats.FileDrop);
                    var file = files[0];
                    var name = Path.GetFileName(file);
                    var ext = Path.GetExtension(name).ToLower();

                    if (ext == ".lnk" || name == "chrome.exe" ||
                        name == "7z.exe" || name == "7za.exe" ||
                        name.Contains("_installer") &&
                        !String.IsNullOrEmpty(Chrome.GetInstallerVersion(name)))
                    {
                        e.Effect = DragDropEffects.Copy;
                    }
                    else
                    {
                        e.Effect = DragDropEffects.None;
                    }
                }
            };

            this.DragDrop += (s, e) =>
            {
                var files = (string[])e.Data.GetData(DataFormats.FileDrop);
                var file = files[0];
                var name = Path.GetFileName(file);
                var ext = Path.GetExtension(name).ToLower();

                if (name.Contains("_installer"))
                {
                    tabControl1.SelectedIndex = 0;
                    installerTextBox.Text = file;
                    suggestInstaller(file);
                    return;
                }

                if (ext == ".lnk")
                {
                    tabControl1.SelectedIndex = 1;
                    argsCheckBox.Checked = false;
                    lnkNameTextBox.Text = Path.GetFileNameWithoutExtension(file);
                    lnkDirTextBox.Text = Path.GetDirectoryName(file);

                    var p = Shortcut.Read(file);
                    chromeTextBox.Text = p.targetPath;
                    argsRichTextBox2.Text = p.arguments;

                    lnkNameTextBox.Select();
                    return;
                }

                if (name == "chrome.exe")
                {
                    tabControl1.SelectedIndex = 1;
                    chromeTextBox.Text = file;
                    return;
                }

                if (name == "7z.exe" || name == "7za.exe")
                {
                    tabControl1.SelectedIndex = 0;
                    zipTextBox.Text = file;
                    return;
                }
            };

            #endregion drag-and-drop

            #region Menu

            switchesMenuItem.Click += (s, e) =>
            {
                Process.Start(Env.SwitchesLink);
            };

            zipMenuItem.Click += (s, e) =>
            {
                Process.Start(Env.ZipLink);
            };

            aboutMenuItem.Click += (s, e) =>
            {
                Process.Start(Env.AboutLink);
            };

            #endregion Menu

            tabControl1.SelectedIndexChanged += (s, e) =>
            {
                setStatus();
            };
        }

        private void suggestInstaller(string installer)
        {
            if (String.IsNullOrEmpty(installer))
            {
                argsRichTextBox.Text = "";
                return;
            }

            if (!File.Exists(installer))
            {
                showError($"Could not find\n{installer}");
                installerTextBox.Select();
                return;
            }

            string name = Path.GetFileName(installer);
            string version = Chrome.GetInstallerVersion(name);
            if (String.IsNullOrEmpty(version))
            {
                showError($"Failed to get version from installer name:\n{name}");
                installerTextBox.Select();

                return;
            }

            string parent = Path.GetDirectoryName(installer);
            string zipOutput = Path.Combine(parent, $"{version}_chrome");
            zipOutputTextBox.Text = zipOutput;

            lnkTextBox.Text = Path.Combine(parent, $"{version}_chrome.lnk");

            string[] args = {
                $"--user-data-dir=\"{Path.Combine(zipOutput, @"User Data")}\"",
                $"--disk-cache-dir=\"{Path.Combine(Env.Temp, "Chrome", version)}\"",
                @"--no-first-run"
                };
            argsRichTextBox.Text = String.Join(Environment.NewLine, args);
        }

        private void suggestChrome(string lnkName, string lnkDir)
        {
            if (String.IsNullOrEmpty(lnkName))
            {
                argsRichTextBox2.Text = "";
                return;
            }

            // user data dir is located with shorcut first.
            var userDatadir = lnkDir == Env.Desktop
                ? Path.Combine(lnkDir, $@"Google\Chrome\{lnkName}\User Data")
                : Path.Combine(lnkDir, "User Data");
            string[] args = {
                $"--user-data-dir=\"{userDatadir}\"",
                $"--disk-cache-dir=\"{Path.Combine(Env.Temp, "Chrome", lnkName)}\"",
                @"--no-first-run"
                    };
            argsRichTextBox2.Text = String.Join(Environment.NewLine, args);
        }

        private void setStatus(string text = "Ready", bool isError = false)
        {
            toolStripStatusLabel1.Text = text;
            toolStripStatusLabel1.ForeColor = isError
                ? Color.Red : SystemColors.ControlText;
        }

        private DialogResult showError(string text)
        {
            return MessageBox.Show(text, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private bool isLnk(string path)
        {
            return Path.GetExtension(path).ToLower() == ".lnk";
        }
    }
}