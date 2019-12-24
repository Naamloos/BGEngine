namespace BGEngine.Forms
{
    partial class MainWindow
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.title = new System.Windows.Forms.Label();
            this.configbtn = new System.Windows.Forms.Button();
            this.startbtn = new System.Windows.Forms.Button();
            this.statustext = new System.Windows.Forms.Label();
            this.trayicon = new System.Windows.Forms.NotifyIcon(this.components);
            this.githublink = new System.Windows.Forms.LinkLabel();
            this.kofilink = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(13, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(359, 103);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // title
            // 
            this.title.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.title.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.Location = new System.Drawing.Point(12, 119);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(360, 55);
            this.title.TabIndex = 1;
            this.title.Text = "BGEngine";
            this.title.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // configbtn
            // 
            this.configbtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.configbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.configbtn.Location = new System.Drawing.Point(13, 178);
            this.configbtn.Name = "configbtn";
            this.configbtn.Size = new System.Drawing.Size(359, 65);
            this.configbtn.TabIndex = 2;
            this.configbtn.Text = "Config";
            this.configbtn.UseVisualStyleBackColor = true;
            this.configbtn.Click += new System.EventHandler(this.configbtn_Click);
            // 
            // startbtn
            // 
            this.startbtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.startbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startbtn.Location = new System.Drawing.Point(13, 249);
            this.startbtn.Name = "startbtn";
            this.startbtn.Size = new System.Drawing.Size(359, 65);
            this.startbtn.TabIndex = 3;
            this.startbtn.Text = "Start";
            this.startbtn.UseVisualStyleBackColor = true;
            this.startbtn.Click += new System.EventHandler(this.startbtn_Click);
            // 
            // statustext
            // 
            this.statustext.AutoSize = true;
            this.statustext.ForeColor = System.Drawing.Color.Red;
            this.statustext.Location = new System.Drawing.Point(13, 321);
            this.statustext.Name = "statustext";
            this.statustext.Size = new System.Drawing.Size(83, 13);
            this.statustext.TabIndex = 4;
            this.statustext.Text = "Status: Stopped";
            // 
            // trayicon
            // 
            this.trayicon.BalloonTipText = "BGEngine has started.";
            this.trayicon.BalloonTipTitle = "BGEngine";
            this.trayicon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayicon.Icon")));
            this.trayicon.Text = "BGEngine";
            this.trayicon.Visible = true;
            this.trayicon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.trayicon_MouseDoubleClick);
            this.trayicon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.trayicon_MouseDoubleClick);
            // 
            // githublink
            // 
            this.githublink.AutoSize = true;
            this.githublink.Location = new System.Drawing.Point(284, 321);
            this.githublink.Name = "githublink";
            this.githublink.Size = new System.Drawing.Size(40, 13);
            this.githublink.TabIndex = 5;
            this.githublink.TabStop = true;
            this.githublink.Text = "GitHub";
            this.githublink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.githublink_LinkClicked);
            // 
            // kofilink
            // 
            this.kofilink.AutoSize = true;
            this.kofilink.Location = new System.Drawing.Point(330, 321);
            this.kofilink.Name = "kofilink";
            this.kofilink.Size = new System.Drawing.Size(42, 13);
            this.kofilink.TabIndex = 6;
            this.kofilink.TabStop = true;
            this.kofilink.Text = "Donate";
            this.kofilink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.kofilink_LinkClicked);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 341);
            this.Controls.Add(this.kofilink);
            this.Controls.Add(this.githublink);
            this.Controls.Add(this.statustext);
            this.Controls.Add(this.startbtn);
            this.Controls.Add(this.configbtn);
            this.Controls.Add(this.title);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(400, 380);
            this.MinimumSize = new System.Drawing.Size(400, 380);
            this.Name = "MainWindow";
            this.Text = "BGEngine";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainWindow_FormClosed);
            this.Shown += new System.EventHandler(this.MainWindow_Shown);
            this.Resize += new System.EventHandler(this.MainWindow_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Button configbtn;
        private System.Windows.Forms.Button startbtn;
        private System.Windows.Forms.Label statustext;
        private System.Windows.Forms.NotifyIcon trayicon;
        private System.Windows.Forms.LinkLabel githublink;
        private System.Windows.Forms.LinkLabel kofilink;
    }
}