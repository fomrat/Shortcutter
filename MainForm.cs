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
        private bool isMouseDown = false;
        private Point mouseOffset;

        public MainForm()
        {
            InitializeComponent();
        }

        #region "Events"

        private void MainForm_Load(object sender, EventArgs e)
        {
            ChkOnTop.Checked = Properties.Settings.Default.FloatOnTop;
            this.TopMost = ChkOnTop.Checked;

            this.Location = new Point(Properties.Settings.Default.LocationX, Properties.Settings.Default.LocationY);

            this.Opacity = Properties.Settings.Default.OpacityPercent;

            if (this.Opacity < 10)
            {
                this.Opacity = 10;
            }

            GetFiles();
        }

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // Get the new position
                mouseOffset = new Point(-e.X, -e.Y);
                // Set that left button is pressed
                isMouseDown = true;
            }
        }

        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                Point mousePos = Control.MousePosition;
                // Get the new form position
                mousePos.Offset(mouseOffset.X, mouseOffset.Y);
                this.Location = mousePos;
            }
        }

        private void MainForm_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = false;
            }
        }

        private void LstFiles_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                RunItem(LstFiles);
            }
        }

        private void LstFiles_Click(object sender, EventArgs e)
        {
            RunItem(LstFiles);
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            GetFiles();
        }

        private void ChkOnTop_CheckedChanged(object sender, EventArgs e)
        {
            this.TopMost = ChkOnTop.Checked;
        }

        #endregion "Events"

        private void GetFiles()
        {
            string folder = Properties.Settings.Default.ShortcutFolder;
            if (!Directory.Exists(folder))
            {
                MessageBox.Show($"ShortcutFolder set to { (object)folder} .Set a folder and extension to display in the config file.","Settings must make sense...",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string[] files = Directory.GetFiles(Properties.Settings.Default.ShortcutFolder, "*." + Properties.Settings.Default.FileExt);

            LstFiles.Items.Clear();

            foreach (string file in files)
            {
                string fileName = Path.GetFileName(file);
                LstFiles.Items.Add(fileName);
            }

            LstFiles.Size = LstFiles.PreferredSize;
            if (LstFiles.PreferredSize.Width < 200)
            {
                LstFiles.Height = LstFiles.PreferredSize.Height;
                LstFiles.Width = 200;
            }

            ChkOnTop.Left = 2;
            ChkOnTop.Top = LstFiles.Height + 5;
            BtnRefresh.Top = LstFiles.Height + 1;

            this.Size = this.PreferredSize;
        }

        private void RunItem(ListBox lst)
        {
            try
            {
                Process.Start(Properties.Settings.Default.ShortcutFolder + Path.DirectorySeparatorChar + lst.SelectedItem);
            }
            catch (Win32Exception e)
            {
                string msg = e.Message + Environment.NewLine + Environment.NewLine + Properties.Settings.Default.ShortcutFolder + Path.DirectorySeparatorChar + LstFiles.SelectedItem + Environment.NewLine + Environment.NewLine + "Is there a period in the shortcut's name?";
                MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.LocationX = this.Location.X;
            Properties.Settings.Default.LocationY = this.Location.Y;
            Properties.Settings.Default.Save();
        }
    }
}