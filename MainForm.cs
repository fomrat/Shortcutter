using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Shortcutter
{
    public partial class MainForm : Form
    {
        bool isMouseDown = false;
        Point mouseOffset;
        public MainForm()
        {
            InitializeComponent();
        }

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


        private void GetFiles()
        {
            if (!Directory.Exists(Properties.Settings.Default.ShortcutFolder))
            {
                MessageBox.Show("Set a folder And extension in the config file.", "Settings must make sense...", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {

        }
    }
}
