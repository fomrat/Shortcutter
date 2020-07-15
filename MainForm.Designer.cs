namespace Shortcutter
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.lstFiles = new System.Windows.Forms.ListBox();
            this.chkOnTop = new System.Windows.Forms.CheckBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnChangeFolder = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LstFiles
            // 
            this.lstFiles.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstFiles.FormattingEnabled = true;
            this.lstFiles.ItemHeight = 14;
            this.lstFiles.Location = new System.Drawing.Point(0, 0);
            this.lstFiles.Name = "LstFiles";
            this.lstFiles.Size = new System.Drawing.Size(176, 186);
            this.lstFiles.TabIndex = 0;
            this.lstFiles.Click += new System.EventHandler(this.lstFiles_Click);
            this.lstFiles.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lstFiles_KeyPress);
            // 
            // ChkOnTop
            // 
            this.chkOnTop.AutoSize = true;
            this.chkOnTop.Location = new System.Drawing.Point(2, 196);
            this.chkOnTop.Name = "ChkOnTop";
            this.chkOnTop.Size = new System.Drawing.Size(49, 17);
            this.chkOnTop.TabIndex = 1;
            this.chkOnTop.Text = "&Float";
            this.chkOnTop.UseVisualStyleBackColor = true;
            this.chkOnTop.CheckedChanged += new System.EventHandler(this.ChkOnTop_CheckedChanged);
            // 
            // BtnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(48, 192);
            this.btnRefresh.Name = "BtnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "&Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);
            // 
            // btnChangeFolder
            // 
            this.btnChangeFolder.Location = new System.Drawing.Point(129, 192);
            this.btnChangeFolder.Name = "btnChangeFolder";
            this.btnChangeFolder.Size = new System.Drawing.Size(75, 23);
            this.btnChangeFolder.TabIndex = 3;
            this.btnChangeFolder.Text = "&Change";
            this.btnChangeFolder.UseVisualStyleBackColor = true;
            this.btnChangeFolder.Click += new System.EventHandler(this.btnChangeFolder_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 450);
            this.Controls.Add(this.btnChangeFolder);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.chkOnTop);
            this.Controls.Add(this.lstFiles);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Shortcutter";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstFiles;
        private System.Windows.Forms.CheckBox chkOnTop;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnChangeFolder;
    }
}

