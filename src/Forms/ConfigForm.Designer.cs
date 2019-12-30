namespace BGEngine.Forms
{
    partial class ConfigForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigForm));
            this.applybtn = new System.Windows.Forms.Button();
            this.cancelbtn = new System.Windows.Forms.Button();
            this.videoopendialog = new System.Windows.Forms.OpenFileDialog();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.autostartdisablebtn = new System.Windows.Forms.Button();
            this.autostartenablebtn = new System.Windows.Forms.Button();
            this.RegistryLabel = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.WallpaperList = new System.Windows.Forms.ListView();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.autostart = new System.Windows.Forms.CheckBox();
            this.tabs = new System.Windows.Forms.TabControl();
            this.tabPage4.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabs.SuspendLayout();
            this.SuspendLayout();
            // 
            // applybtn
            // 
            this.applybtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.applybtn.Location = new System.Drawing.Point(12, 429);
            this.applybtn.Name = "applybtn";
            this.applybtn.Size = new System.Drawing.Size(94, 23);
            this.applybtn.TabIndex = 1;
            this.applybtn.Text = "Apply Changes";
            this.applybtn.UseVisualStyleBackColor = true;
            this.applybtn.Click += new System.EventHandler(this.applybtn_Click);
            // 
            // cancelbtn
            // 
            this.cancelbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cancelbtn.Location = new System.Drawing.Point(112, 429);
            this.cancelbtn.Name = "cancelbtn";
            this.cancelbtn.Size = new System.Drawing.Size(75, 23);
            this.cancelbtn.TabIndex = 2;
            this.cancelbtn.Text = "Cancel";
            this.cancelbtn.UseVisualStyleBackColor = true;
            this.cancelbtn.Click += new System.EventHandler(this.cancelbtn_Click);
            // 
            // videoopendialog
            // 
            this.videoopendialog.FileName = "video.mp4";
            this.videoopendialog.Filter = "*.mp4|Video files";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.label2);
            this.tabPage4.Controls.Add(this.autostartdisablebtn);
            this.tabPage4.Controls.Add(this.autostartenablebtn);
            this.tabPage4.Controls.Add(this.RegistryLabel);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(768, 385);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Registry Settings";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(301, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "This will cause BGEngine to start when you log in to Windows.";
            // 
            // autostartdisablebtn
            // 
            this.autostartdisablebtn.Location = new System.Drawing.Point(6, 52);
            this.autostartdisablebtn.Name = "autostartdisablebtn";
            this.autostartdisablebtn.Size = new System.Drawing.Size(756, 23);
            this.autostartdisablebtn.TabIndex = 2;
            this.autostartdisablebtn.Text = "Disable Autostart";
            this.autostartdisablebtn.UseVisualStyleBackColor = true;
            this.autostartdisablebtn.Click += new System.EventHandler(this.autostartdisablebtn_Click);
            // 
            // autostartenablebtn
            // 
            this.autostartenablebtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.autostartenablebtn.Location = new System.Drawing.Point(6, 23);
            this.autostartenablebtn.Name = "autostartenablebtn";
            this.autostartenablebtn.Size = new System.Drawing.Size(756, 23);
            this.autostartenablebtn.TabIndex = 1;
            this.autostartenablebtn.Text = "Enable Autostart";
            this.autostartenablebtn.UseVisualStyleBackColor = true;
            this.autostartenablebtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // RegistryLabel
            // 
            this.RegistryLabel.AutoSize = true;
            this.RegistryLabel.Location = new System.Drawing.Point(7, 7);
            this.RegistryLabel.Name = "RegistryLabel";
            this.RegistryLabel.Size = new System.Drawing.Size(74, 13);
            this.RegistryLabel.TabIndex = 0;
            this.RegistryLabel.Text = "Registry state:";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.WallpaperList);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(768, 385);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Wallpaper Settings";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // WallpaperList
            // 
            this.WallpaperList.HideSelection = false;
            this.WallpaperList.Location = new System.Drawing.Point(7, 7);
            this.WallpaperList.MultiSelect = false;
            this.WallpaperList.Name = "WallpaperList";
            this.WallpaperList.Size = new System.Drawing.Size(755, 372);
            this.WallpaperList.TabIndex = 0;
            this.WallpaperList.TileSize = new System.Drawing.Size(50, 50);
            this.WallpaperList.UseCompatibleStateImageBehavior = false;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.autostart);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(768, 385);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "General Settings";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(300, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "This will autostart the wallpaper when the program has started.";
            // 
            // autostart
            // 
            this.autostart.AutoSize = true;
            this.autostart.Location = new System.Drawing.Point(9, 6);
            this.autostart.Name = "autostart";
            this.autostart.Size = new System.Drawing.Size(107, 17);
            this.autostart.TabIndex = 2;
            this.autostart.Text = "Autostart Service";
            this.autostart.UseVisualStyleBackColor = true;
            // 
            // tabs
            // 
            this.tabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabs.Controls.Add(this.tabPage1);
            this.tabs.Controls.Add(this.tabPage3);
            this.tabs.Controls.Add(this.tabPage4);
            this.tabs.Location = new System.Drawing.Point(12, 12);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(776, 411);
            this.tabs.TabIndex = 0;
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 457);
            this.Controls.Add(this.cancelbtn);
            this.Controls.Add(this.applybtn);
            this.Controls.Add(this.tabs);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(816, 496);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(816, 496);
            this.Name = "ConfigForm";
            this.Text = "Config";
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabs.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button applybtn;
        private System.Windows.Forms.Button cancelbtn;
        private System.Windows.Forms.OpenFileDialog videoopendialog;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button autostartdisablebtn;
        private System.Windows.Forms.Button autostartenablebtn;
        private System.Windows.Forms.Label RegistryLabel;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ListView WallpaperList;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox autostart;
        private System.Windows.Forms.TabControl tabs;
    }
}