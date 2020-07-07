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
            this.LstFiles = new System.Windows.Forms.ListBox();
            this.ChkOnTop = new System.Windows.Forms.CheckBox();
            this.BtnRefresh = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LstFiles
            // 
            this.LstFiles.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LstFiles.FormattingEnabled = true;
            this.LstFiles.ItemHeight = 14;
            this.LstFiles.Location = new System.Drawing.Point(0, 0);
            this.LstFiles.Name = "LstFiles";
            this.LstFiles.Size = new System.Drawing.Size(176, 186);
            this.LstFiles.TabIndex = 0;
            this.LstFiles.Click += new System.EventHandler(this.LstFiles_Click);
            this.LstFiles.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.LstFiles_KeyPress);
            // 
            // ChkOnTop
            // 
            this.ChkOnTop.AutoSize = true;
            this.ChkOnTop.Location = new System.Drawing.Point(2, 196);
            this.ChkOnTop.Name = "ChkOnTop";
            this.ChkOnTop.Size = new System.Drawing.Size(49, 17);
            this.ChkOnTop.TabIndex = 1;
            this.ChkOnTop.Text = "&Float";
            this.ChkOnTop.UseVisualStyleBackColor = true;
            this.ChkOnTop.CheckedChanged += new System.EventHandler(this.ChkOnTop_CheckedChanged);
            // 
            // BtnRefresh
            // 
            this.BtnRefresh.Location = new System.Drawing.Point(68, 192);
            this.BtnRefresh.Name = "BtnRefresh";
            this.BtnRefresh.Size = new System.Drawing.Size(75, 23);
            this.BtnRefresh.TabIndex = 2;
            this.BtnRefresh.Text = "&Refresh";
            this.BtnRefresh.UseVisualStyleBackColor = true;
            this.BtnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 450);
            this.Controls.Add(this.BtnRefresh);
            this.Controls.Add(this.ChkOnTop);
            this.Controls.Add(this.LstFiles);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Shortcutter";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox LstFiles;
        private System.Windows.Forms.CheckBox ChkOnTop;
        private System.Windows.Forms.Button BtnRefresh;
    }
}

