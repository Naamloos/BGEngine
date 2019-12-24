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
            this.tabs = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.autostart = new System.Windows.Forms.CheckBox();
            this.bgmodes = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.selectvideobtn = new System.Windows.Forms.Button();
            this.videopath = new System.Windows.Forms.TextBox();
            this.vptext = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.autostartdisablebtn = new System.Windows.Forms.Button();
            this.autostartenablebtn = new System.Windows.Forms.Button();
            this.RegistryLabel = new System.Windows.Forms.Label();
            this.applybtn = new System.Windows.Forms.Button();
            this.cancelbtn = new System.Windows.Forms.Button();
            this.vlcopendialog = new System.Windows.Forms.OpenFileDialog();
            this.videoopendialog = new System.Windows.Forms.OpenFileDialog();
            this.tabs.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabs
            // 
            this.tabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabs.Controls.Add(this.tabPage1);
            this.tabs.Controls.Add(this.tabPage2);
            this.tabs.Controls.Add(this.tabPage3);
            this.tabs.Controls.Add(this.tabPage4);
            this.tabs.Location = new System.Drawing.Point(12, 12);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(776, 411);
            this.tabs.TabIndex = 0;
            this.tabs.TabIndexChanged += new System.EventHandler(this.tabs_TabIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.autostart);
            this.tabPage1.Controls.Add(this.bgmodes);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(768, 385);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "General Settings";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // autostart
            // 
            this.autostart.AutoSize = true;
            this.autostart.Location = new System.Drawing.Point(6, 46);
            this.autostart.Name = "autostart";
            this.autostart.Size = new System.Drawing.Size(107, 17);
            this.autostart.TabIndex = 2;
            this.autostart.Text = "Autostart Service";
            this.autostart.UseVisualStyleBackColor = true;
            // 
            // bgmodes
            // 
            this.bgmodes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.bgmodes.FormattingEnabled = true;
            this.bgmodes.Location = new System.Drawing.Point(6, 19);
            this.bgmodes.Name = "bgmodes";
            this.bgmodes.Size = new System.Drawing.Size(756, 21);
            this.bgmodes.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Background mode";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.selectvideobtn);
            this.tabPage2.Controls.Add(this.videopath);
            this.tabPage2.Controls.Add(this.vptext);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(768, 385);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Video-background Settings";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // selectvideobtn
            // 
            this.selectvideobtn.Location = new System.Drawing.Point(678, 19);
            this.selectvideobtn.Name = "selectvideobtn";
            this.selectvideobtn.Size = new System.Drawing.Size(84, 20);
            this.selectvideobtn.TabIndex = 7;
            this.selectvideobtn.Text = "Select...";
            this.selectvideobtn.UseVisualStyleBackColor = true;
            this.selectvideobtn.Click += new System.EventHandler(this.selectvideobtn_Click);
            // 
            // videopath
            // 
            this.videopath.Enabled = false;
            this.videopath.Location = new System.Drawing.Point(6, 19);
            this.videopath.Name = "videopath";
            this.videopath.Size = new System.Drawing.Size(666, 20);
            this.videopath.TabIndex = 6;
            // 
            // vptext
            // 
            this.vptext.AutoSize = true;
            this.vptext.Location = new System.Drawing.Point(6, 3);
            this.vptext.Name = "vptext";
            this.vptext.Size = new System.Drawing.Size(59, 13);
            this.vptext.TabIndex = 5;
            this.vptext.Text = "Video Path";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(768, 385);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Plugin-background Settings";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(141, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "soon, i promise. kek";
            // 
            // tabPage4
            // 
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
            this.tabPage4.Click += new System.EventHandler(this.tabPage4_Click);
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
            // vlcopendialog
            // 
            this.vlcopendialog.FileName = "openfile";
            this.vlcopendialog.Filter = "VLC Media Player|vlc.exe";
            this.vlcopendialog.Title = "Find path to vlc.exe...";
            // 
            // videoopendialog
            // 
            this.videoopendialog.FileName = "video.mp4";
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
            this.Name = "ConfigForm";
            this.Text = "Config";
            this.tabs.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button applybtn;
        private System.Windows.Forms.Button cancelbtn;
        private System.Windows.Forms.ComboBox bgmodes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button autostartdisablebtn;
        private System.Windows.Forms.Button autostartenablebtn;
        private System.Windows.Forms.Label RegistryLabel;
        private System.Windows.Forms.CheckBox autostart;
        private System.Windows.Forms.OpenFileDialog vlcopendialog;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox videopath;
        private System.Windows.Forms.Label vptext;
        private System.Windows.Forms.Button selectvideobtn;
        private System.Windows.Forms.OpenFileDialog videoopendialog;
    }
}