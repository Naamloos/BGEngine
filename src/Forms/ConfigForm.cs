using BGEngine.Entities;
using BGEngine.Sdk;
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

            foreach(var p in Program.Plugins.GetAllPlugins())
            {
                this.pluginlistbox.Items.Add(new ListPlugin(p));
            }

            if (Program.Plugins.GetAllPlugins().Any(x => x.RequestPluginInfo().PluginId == Program.Config.SelectedPluginId))
            {
                this.pluginlistbox.SelectedItem 
                    = new ListPlugin(Program.Plugins.GetAllPlugins().First(x => x.RequestPluginInfo().PluginId == Program.Config.SelectedPluginId));
            }
            else
            {
                this.pluginlistbox.SelectedItem = null;
            }

            ShowConfigButtonIfNeeded();
        }

        private void applybtn_Click(object sender, EventArgs e)
        {
            // apply
            Program.Config.BackgroundMode = (BackgroundMode)bgmodes.SelectedItem;
            Program.Config.AutoStartService = autostart.Checked;
            Program.Config.VideoPath = videopath.Text;
            if (pluginlistbox.SelectedItem != null)
                Program.Config.SelectedPluginId = ((ListPlugin)pluginlistbox.SelectedItem).Plugin.RequestPluginInfo().PluginId;

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
            videoopendialog.Filter = "Video Files|*.mp4;*.wmv;*.mov;*.mkv;*.avi;*.flv;";
            var res = videoopendialog.ShowDialog();

            if (res == DialogResult.OK)
            {
                this.videopath.Text = videoopendialog.FileName;
            }
        }

        private void pluginlistbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowConfigButtonIfNeeded();
        }

        private void ShowConfigButtonIfNeeded()
        {
            var selected = (ListPlugin)pluginlistbox.SelectedItem;

            if (selected == null)
                return;

            if (selected.Plugin.RequestPluginInfo().HasConfig)
            {
                pluginconfigbtn.Enabled = true;
            }
            else
            {
                pluginconfigbtn.Enabled = false;
            }
        }

        private void pluginconfigbtn_Click(object sender, EventArgs e)
        {
            var selected = (ListPlugin)pluginlistbox.SelectedItem;

            if (selected == null)
                return;

            if (selected.Plugin.RequestPluginInfo().HasConfig)
            {
                selected.Plugin.ShowPluginConfig();
            }
        }
    }
}
