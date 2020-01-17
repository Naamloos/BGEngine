using BGEngine.Entities;
using BGEngine.Sdk;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
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

            var path = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";
            RegistryKey key = Registry.CurrentUser.OpenSubKey(path, true);

            RegistryLabel.Text = $"Autostart enabled: {key.GetValueNames().Contains("BGEngine")}";

            // preset values in config
            autostart.Checked = Program.Config.AutoStartService;

            WallpaperList.LargeImageList = new ImageList();
            WallpaperList.LargeImageList.ImageSize = new Size(100, 100);
            WallpaperList.LargeImageList.ColorDepth = ColorDepth.Depth32Bit;
            foreach(var w in Program.Wallpapers)
            {
                var impath = Path.Combine(w.Path, w.ThumbnailPath);
                WallpaperList.LargeImageList.Images.Add(w.ToString(), Image.FromFile(impath));
                WallpaperList.Items.Add(w.ToString(), w.ToString());
            }
        }

        private void applybtn_Click(object sender, EventArgs e)
        {
            // apply
            Program.Config.AutoStartService = autostart.Checked;

            if(WallpaperList.SelectedItems.Count > 0)
            {
                var selected = WallpaperList.SelectedItems[0];

                Program.Config.SelectedWallpaper = selected.Text;
            }

            File.WriteAllText(Path.Combine(Application.StartupPath, "config.json"), JsonConvert.SerializeObject(Program.Config));
            this.Close();
        }

        private void cancelbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var path = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";
            RegistryKey key = Registry.CurrentUser.OpenSubKey(path, true);
            key.SetValue("BGEngine", Assembly.GetEntryAssembly().Location);
            RegistryLabel.Text = $"Autostart enabled: {key.GetValueNames().Contains("BGEngine")}";
        }

        private void autostartdisablebtn_Click(object sender, EventArgs e)
        {
            var path = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";
            RegistryKey key = Registry.CurrentUser.OpenSubKey(path, true);
            key.DeleteValue("BGEngine", false);
            RegistryLabel.Text = $"Autostart enabled: {key.GetValueNames().Contains("BGEngine")}";
        }
    }
}
