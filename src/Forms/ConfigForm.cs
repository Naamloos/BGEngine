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
            bgmodes.Items.Add(Entities.BackgroundMode.Plugin);

            var path = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";
            RegistryKey key = Registry.CurrentUser.OpenSubKey(path, true);

            RegistryLabel.Text = $"Autostart enabled: {key.GetValueNames().Contains("BGEngine")}";

            // preset values in config
            bgmodes.SelectedItem = Program.Config.BackgroundMode;
            autostart.Checked = Program.Config.AutoStartService;
            videopath.Text = Program.Config.VideoPath;
        }

        private void applybtn_Click(object sender, EventArgs e)
        {
            // apply
            Program.Config.BackgroundMode = (BackgroundMode)bgmodes.SelectedItem;
            Program.Config.AutoStartService = autostart.Checked;
            Program.Config.VideoPath = videopath.Text;

            File.WriteAllText(Path.Combine(Application.StartupPath, "config.json"), JsonConvert.SerializeObject(Program.Config));
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
