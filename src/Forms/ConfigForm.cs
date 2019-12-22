using BGEngine.Entities;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BGEngine.Forms
{
    public partial class ConfigForm : Form
    {
        public ConfigForm()
        {
            InitializeComponent();
            bgmodes.Items.Add(Entities.BackgroundMode.Video);
            bgmodes.Items.Add(Entities.BackgroundMode.Window);

            var path = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";
            RegistryKey key = Registry.CurrentUser.OpenSubKey(path, true);

            RegistryLabel.Text = $"Autostart enabled: {key.GetValueNames().Contains("BGEngine")}";

            // preset values in config
            bgmodes.SelectedItem = Entry.Config.BackgroundMode;
            autostart.Checked = Entry.Config.AutoStartService;
            vlcpath.Text = Entry.Config.VlcPath;
            vlcargs.Text = Entry.Config.VlcArgs;
            videopath.Text = Entry.Config.VideoPath;
        }

        private void applybtn_Click(object sender, EventArgs e)
        {
            // apply
            Entry.Config.BackgroundMode = (BackgroundMode)bgmodes.SelectedItem;
            Entry.Config.AutoStartService = autostart.Checked;
            Entry.Config.VlcPath = vlcpath.Text;
            Entry.Config.VlcArgs = vlcargs.Text;
            Entry.Config.VideoPath = videopath.Text;

            File.WriteAllText(Path.Combine(Application.StartupPath, "config.json"), JsonConvert.SerializeObject(Entry.Config));
            this.Close();
        }

        private void cancelbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void tabs_TabIndexChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var path = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";
            RegistryKey key = Registry.CurrentUser.OpenSubKey(path, true);
            key.SetValue("BGEngine", Application.ExecutablePath.ToString());
            RegistryLabel.Text = $"Autostart enabled: {key.GetValueNames().Contains("BGEngine")}";
        }

        private void autostartdisablebtn_Click(object sender, EventArgs e)
        {
            var path = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";
            RegistryKey key = Registry.CurrentUser.OpenSubKey(path, true);
            key.DeleteValue("BGEngine", false);
            RegistryLabel.Text = $"Autostart enabled: {key.GetValueNames().Contains("BGEngine")}";
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            vlcopendialog.ShowHelp = true;
            vlcopendialog.FileName = "vlc.exe";
            var res = vlcopendialog.ShowDialog();

            if(res == DialogResult.OK)
            {
                this.vlcpath.Text = vlcopendialog.FileName;
            }
        }

        private void selectvideobtn_Click(object sender, EventArgs e)
        {
            videoopendialog.ShowHelp = true;
            videoopendialog.FileName = "vlc.exe";
            var res = videoopendialog.ShowDialog();

            if (res == DialogResult.OK)
            {
                this.videopath.Text = videoopendialog.FileName;
            }
        }
    }
}
