using BGEngine.Entities;
using LibVLCSharp.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BGEngine.Forms
{
    public partial class MainWindow : Form
    {
        private ConfigForm _config;
        private BackgroundManager _manager;

        public MainWindow()
        {
            Application.EnableVisualStyles();

            InitializeComponent();
            _config = new ConfigForm();
            _manager = new BackgroundManager();
            this.Hide();
            trayicon.Visible = true;
            trayicon.ShowBalloonTip(2000);

            if (Program.Config.AutoStartService)
            {
                // service must auto start.
                startbtn_Click(null, null);
            }
        }

        private void configbtn_Click(object sender, EventArgs e)
        {
            // This button will configure the BGEngine service.
            if (!_manager.Running)
            {
                _config.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please disable the background service before configuring BGEngine");
            }
        }

        private void startbtn_Click(object sender, EventArgs e)
        {
            if (!ValidateSettings())
            {
                MessageBox.Show("Your current configuration for BGEngine is invalid. Check your config.");
                return;
            }

            if (this._manager.Running)
            {
                _manager.Stop();
                statustext.ForeColor = Color.Red;
                statustext.Text = "Status: Stopped";
                startbtn.Text = "Start";
            }
            else
            {
                if (!_config.Visible)
                {
                    // config screen is disabled, starting service is allowed.
                    // TODO pick wallpaper from config
                    var wallpaper = Program.Wallpapers.First(x => x.ToString() == Program.Config.SelectedWallpaper);
                    _manager.Start(wallpaper);

                    statustext.ForeColor = Color.Green;
                    statustext.Text = "Status: Running";
                }
                startbtn.Text = "Stop";
            }
        }

        /// <summary>
        /// Validates settings.
        /// </summary>
        /// <returns>Returns true if settings are valid, else false.</returns>
        private bool ValidateSettings()
        {

            return true;
        }

        private void trayicon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!this.Visible)
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.Hide();
            }
        }

        private void MainWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_manager.Running)
                _manager.Stop();
            Application.Exit();
        }

        private void MainWindow_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                this.Hide();
            }
        }

        bool firsthide = false;
        private void MainWindow_Shown(object sender, EventArgs e)
        {
            if (!firsthide)
            {
                this.Hide();
                firsthide = true;
            }
        }

        private void githublink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.github.com/Naamloos/BGEngine");
        }

        private void kofilink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.ko-fi.com/Naamloos");
        }
    }
}
