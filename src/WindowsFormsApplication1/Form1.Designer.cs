namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.createButton = new System.Windows.Forms.Button();
            this.installerTextBox = new System.Windows.Forms.TextBox();
            this.argsRichTextBox = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.zipTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lnkTextBox = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.zipOutputTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.argsCheckBox = new System.Windows.Forms.CheckBox();
            this.argsRichTextBox2 = new System.Windows.Forms.RichTextBox();
            this.lnkDirTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lnkNameTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.chromeTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.switchesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zipMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "chrome_installer.exe";
            // 
            // createButton
            // 
            this.createButton.Location = new System.Drawing.Point(226, 580);
            this.createButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(99, 33);
            this.createButton.TabIndex = 1;
            this.createButton.Text = "Create";
            this.createButton.UseVisualStyleBackColor = true;
            // 
            // installerTextBox
            // 
            this.installerTextBox.Location = new System.Drawing.Point(22, 46);
            this.installerTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.installerTextBox.Name = "installerTextBox";
            this.installerTextBox.Size = new System.Drawing.Size(522, 24);
            this.installerTextBox.TabIndex = 2;
            // 
            // argsRichTextBox
            // 
            this.argsRichTextBox.Location = new System.Drawing.Point(19, 290);
            this.argsRichTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.argsRichTextBox.Name = "argsRichTextBox";
            this.argsRichTextBox.Size = new System.Drawing.Size(523, 203);
            this.argsRichTextBox.TabIndex = 3;
            this.argsRichTextBox.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 270);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(264, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "chrome.exe command line switches";
            // 
            // zipTextBox
            // 
            this.zipTextBox.Location = new System.Drawing.Point(22, 104);
            this.zipTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.zipTextBox.Name = "zipTextBox";
            this.zipTextBox.Size = new System.Drawing.Size(522, 24);
            this.zipTextBox.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "7z.exe or 7za.exe";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 208);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(168, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "shortcut file(*.lnk)";
            // 
            // lnkTextBox
            // 
            this.lnkTextBox.Location = new System.Drawing.Point(22, 228);
            this.lnkTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lnkTextBox.Name = "lnkTextBox";
            this.lnkTextBox.Size = new System.Drawing.Size(523, 24);
            this.lnkTextBox.TabIndex = 2;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 28);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(578, 535);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.installerTextBox);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.argsRichTextBox);
            this.tabPage1.Controls.Add(this.zipTextBox);
            this.tabPage1.Controls.Add(this.zipOutputTextBox);
            this.tabPage1.Controls.Add(this.lnkTextBox);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage1.Size = new System.Drawing.Size(570, 505);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "installer.exe";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // zipOutputTextBox
            // 
            this.zipOutputTextBox.Location = new System.Drawing.Point(23, 165);
            this.zipOutputTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.zipOutputTextBox.Name = "zipOutputTextBox";
            this.zipOutputTextBox.Size = new System.Drawing.Size(523, 24);
            this.zipOutputTextBox.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(21, 145);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(280, 17);
            this.label8.TabIndex = 0;
            this.label8.Text = "extract installer.exe to directory";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.argsCheckBox);
            this.tabPage2.Controls.Add(this.argsRichTextBox2);
            this.tabPage2.Controls.Add(this.lnkDirTextBox);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.lnkNameTextBox);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.chromeTextBox);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage2.Size = new System.Drawing.Size(570, 505);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "chrome.exe";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // argsCheckBox
            // 
            this.argsCheckBox.AutoSize = true;
            this.argsCheckBox.Checked = true;
            this.argsCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.argsCheckBox.Location = new System.Drawing.Point(314, 112);
            this.argsCheckBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.argsCheckBox.Name = "argsCheckBox";
            this.argsCheckBox.Size = new System.Drawing.Size(219, 21);
            this.argsCheckBox.TabIndex = 9;
            this.argsCheckBox.Text = "Suggest switches by name";
            this.argsCheckBox.UseVisualStyleBackColor = true;
            // 
            // argsRichTextBox2
            // 
            this.argsRichTextBox2.Location = new System.Drawing.Point(19, 227);
            this.argsRichTextBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.argsRichTextBox2.Name = "argsRichTextBox2";
            this.argsRichTextBox2.Size = new System.Drawing.Size(522, 241);
            this.argsRichTextBox2.TabIndex = 8;
            this.argsRichTextBox2.Text = "";
            // 
            // lnkDirTextBox
            // 
            this.lnkDirTextBox.Location = new System.Drawing.Point(19, 165);
            this.lnkDirTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lnkDirTextBox.Name = "lnkDirTextBox";
            this.lnkDirTextBox.Size = new System.Drawing.Size(522, 24);
            this.lnkDirTextBox.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(17, 145);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(272, 17);
            this.label9.TabIndex = 5;
            this.label9.Text = "locate shortcut file in directory";
            // 
            // lnkNameTextBox
            // 
            this.lnkNameTextBox.Location = new System.Drawing.Point(19, 109);
            this.lnkNameTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lnkNameTextBox.Name = "lnkNameTextBox";
            this.lnkNameTextBox.Size = new System.Drawing.Size(267, 24);
            this.lnkNameTextBox.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 89);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(344, 17);
            this.label6.TabIndex = 5;
            this.label6.Text = "shortcut file name(without extension .lnk)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 206);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(264, 17);
            this.label7.TabIndex = 6;
            this.label7.Text = "chrome.exe command line switches";
            // 
            // chromeTextBox
            // 
            this.chromeTextBox.Location = new System.Drawing.Point(19, 55);
            this.chromeTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chromeTextBox.Name = "chromeTextBox";
            this.chromeTextBox.Size = new System.Drawing.Size(522, 24);
            this.chromeTextBox.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 17);
            this.label5.TabIndex = 3;
            this.label5.Text = "chrome.exe";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 629);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 18, 0);
            this.statusStrip1.Size = new System.Drawing.Size(578, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(578, 25);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.switchesMenuItem,
            this.zipMenuItem,
            this.aboutMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(47, 21);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // switchesMenuItem
            // 
            this.switchesMenuItem.Name = "switchesMenuItem";
            this.switchesMenuItem.Size = new System.Drawing.Size(319, 22);
            this.switchesMenuItem.Text = "List of Chromium Command Line Switches";
            // 
            // zipMenuItem
            // 
            this.zipMenuItem.Name = "zipMenuItem";
            this.zipMenuItem.Size = new System.Drawing.Size(319, 22);
            this.zipMenuItem.Text = "Download 7-Zip";
            // 
            // aboutMenuItem
            // 
            this.aboutMenuItem.Name = "aboutMenuItem";
            this.aboutMenuItem.Size = new System.Drawing.Size(319, 22);
            this.aboutMenuItem.Text = "About";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 651);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.createButton);
            this.Font = new System.Drawing.Font("Consolas", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.TextBox installerTextBox;
        private System.Windows.Forms.RichTextBox argsRichTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox zipTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox lnkTextBox;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox chromeTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox argsRichTextBox2;
        private System.Windows.Forms.TextBox lnkNameTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox zipOutputTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem switchesMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zipMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutMenuItem;
        private System.Windows.Forms.TextBox lnkDirTextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox argsCheckBox;
    }
}

