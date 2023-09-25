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
        private bool mouseDown;
        private Point lastLocation;

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation=e.Location;
        }

        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
               (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void MainForm_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Visible = false;

            // have to prefix Properties with the Namepace if we want to examine them at design-time (!?)
            if ((Shortcutter.Properties.Settings.Default.LocationX < 0) || (Shortcutter.Properties.Settings.Default.LocationY < 0))
            { this.Location = new Point(0, 0); }
            else
            { this.Location = new Point(Shortcutter.Properties.Settings.Default.LocationX, Shortcutter.Properties.Settings.Default.LocationY); }

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            chkOnTop.Checked = Shortcutter.Properties.Settings.Default.FloatOnTop;
            this.TopMost = chkOnTop.Checked;

            Debug.WriteLine(this.Opacity.ToString());
            this.Opacity = Shortcutter.Properties.Settings.Default.OpacityPercent;
            if (this.Opacity < 0.10) { this.Opacity = 0.10; }

            GetFiles();
            this.Visible = true;
        }
        private void lstFiles_KeyPress(object sender, KeyPressEventArgs e) { if (e.KeyChar == Convert.ToChar(Keys.Enter)) { RunItem(lstFiles); } }
        private void lstFiles_Click(object sender, EventArgs e) { RunItem(lstFiles); }
        private void chkOnTop_CheckedChanged(object sender, EventArgs e) { this.TopMost = chkOnTop.Checked; }
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

                string folder = GetShortcutFolder();
                if (String.IsNullOrEmpty(folder)) 
                { 
                    folder = "."; 
  
                }

                Shortcutter.Properties.Settings.Default.ShortcutFolder = folder;
            }

            string[] files = Directory.GetFiles(Shortcutter.Properties.Settings.Default.ShortcutFolder, "*." + Shortcutter.Properties.Settings.Default.FileExt);

            lstFiles.Items.Clear();

            foreach (string file in files)
            {
                string fileName = Path.GetFileNameWithoutExtension(file);
                lstFiles.Items.Add(fileName);
            }
            int maxHeight = Screen.FromControl(this).WorkingArea.Height - 100;
            lstFiles.Size = new Size(lstFiles.PreferredSize.Width-20, lstFiles.PreferredSize.Height);
            if (lstFiles.PreferredSize.Width < 160) { lstFiles.Width = 160; }
            if (lstFiles.PreferredHeight > maxHeight) { lstFiles.Height = maxHeight; }

            chkOnTop.Top = lstFiles.Height + 5;
            btnChangeFolder.Top = lstFiles.Height + 1;
            btnRefresh.Top = lstFiles.Height + 1;

            this.Size = new Size(this.PreferredSize.Width, this.PreferredSize.Height);
        }
          private string GetShortcutFolder()
        {
            OpenFileDialog folderBrowser = new OpenFileDialog
            {
                ValidateNames = false,
                CheckFileExists = false,
                CheckPathExists = true,
                FileName = "Folder selected"
            };

            if (folderBrowser.ShowDialog() == DialogResult.OK) { return System.IO.Path.GetDirectoryName(folderBrowser.FileName); }
            else { return ""; }
        }
        private void RunItem(ListBox lst)
        {
            try { Process.Start(Shortcutter.Properties.Settings.Default.ShortcutFolder + Path.DirectorySeparatorChar + lst.SelectedItem); }
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
            this.Activate();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            GetFiles();
        }
    }
}