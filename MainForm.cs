using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Shortcutter
{
    public partial class MainForm : Form
    {
        public MainForm() { InitializeComponent(); }

        #region "Events"
        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Visible = false;
            // have to prefix Properties with the Namepace if we want to examine it at design-time (!?)           
            this.Location = new Point(Shortcutter.Properties.Settings.Default.LocationX, Shortcutter.Properties.Settings.Default.LocationY);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            chkOnTop.Checked = Shortcutter.Properties.Settings.Default.FloatOnTop;
            this.TopMost = chkOnTop.Checked;
            Debug.WriteLine(this.Opacity.ToString());
            this.Opacity = Shortcutter.Properties.Settings.Default.OpacityPercent;

            if (this.Opacity < 0.10) {this.Opacity = 0.10;}

            GetFiles();
            this.Visible = true;
        }
        private void lstFiles_KeyPress(object sender, KeyPressEventArgs e) { if (e.KeyChar == Convert.ToChar(Keys.Enter)) { RunItem(lstFiles); } }
        private void lstFiles_Click(object sender, EventArgs e) { RunItem(lstFiles); }
        private void BtnRefresh_Click(object sender, EventArgs e) { GetFiles(); }
        private void ChkOnTop_CheckedChanged(object sender, EventArgs e) { this.TopMost = chkOnTop.Checked; }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Shortcutter.Properties.Settings.Default.LocationX = this.Location.X;
            Shortcutter.Properties.Settings.Default.LocationY = this.Location.Y;
            Shortcutter.Properties.Settings.Default.FloatOnTop = chkOnTop.Checked;
            Shortcutter.Properties.Settings.Default.Save();
        }
        #endregion "Events"
        private void GetFiles()
        {
            if (!Directory.Exists(Shortcutter.Properties.Settings.Default.ShortcutFolder))
            {
                MessageBox.Show($"ShortcutFolder set to \"{ (object)Shortcutter.Properties.Settings.Default.ShortcutFolder}\". Select the  folder that contains your shortcuts.", "Settings must be set", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Shortcutter.Properties.Settings.Default.ShortcutFolder = GetShortcutFolder();
            }

            string[] files = Directory.GetFiles(Shortcutter.Properties.Settings.Default.ShortcutFolder, "*." + Shortcutter.Properties.Settings.Default.FileExt);

            lstFiles.Items.Clear();

            foreach (string file in files)
            {
                string fileName = Path.GetFileName(file);
                lstFiles.Items.Add(fileName);
            }

            lstFiles.Size = lstFiles.PreferredSize;
            if (lstFiles.PreferredSize.Width < 200)
            {
                lstFiles.Height = lstFiles.PreferredSize.Height;
                lstFiles.Width = 200;
            }

            chkOnTop.Top = lstFiles.Height + 5;
            btnRefresh.Top = lstFiles.Height + 1;
            btnChangeFolder.Top = lstFiles.Height + 1;

            this.Size = new Size(this.PreferredSize.Width - 3, this.PreferredSize.Height);
        }
        private string GetShortcutFolder()
        {
            OpenFileDialog folderBrowser = new OpenFileDialog();
            folderBrowser.ValidateNames = false;
            folderBrowser.CheckFileExists = false;
            folderBrowser.CheckPathExists = true;
            folderBrowser.FileName = "Folder selected";

            if (folderBrowser.ShowDialog() == DialogResult.OK) { return System.IO.Path.GetDirectoryName(folderBrowser.FileName); }
            else { return ""; }
        }
        private void RunItem(ListBox lst)
        {
            try
            {
                Process.Start(Shortcutter.Properties.Settings.Default.ShortcutFolder + Path.DirectorySeparatorChar + lst.SelectedItem);
            }
            catch (Win32Exception e)
            {
                string msg = e.Message + Environment.NewLine + Environment.NewLine + Shortcutter.Properties.Settings.Default.ShortcutFolder + Path.DirectorySeparatorChar + lstFiles.SelectedItem + Environment.NewLine + Environment.NewLine + "Is there a period in the shortcut's name?";
                MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnChangeFolder_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Shortcutter.Properties.Settings.Default.ShortcutFolder = "";
            Shortcutter.Properties.Settings.Default.Save();
            GetFiles();
            this.Visible = true;
        }
    }
}