using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BGEngine.Entities.Managers
{
    public class ConfigManager
    {
        private Config _config;
        public ConfigManager()
        {

        }

        public void Load()
        {
            if (File.Exists(Path.Combine(Application.StartupPath, "config.json")))
            {
                _config = JsonConvert.DeserializeObject<Config>(File.ReadAllText(Path.Combine(Application.StartupPath, "config.json")));
            }
            else
            {
                _config = new Config();
                File.Create(Path.Combine(Application.StartupPath, "config.json")).Close();
            }
            this.save();
        }

        public bool Validate()
        {
            // Validate settings
            return true;
        }

        public TaskbarMode GetTaskbarMode()
        {
            return this._config.TaskbarMode;
        }

        public void SetTaskbarMode(TaskbarMode mode)
        {
            this._config.TaskbarMode = mode;
            this.save();
        }

        public void SetSelectedWallpaper(string wallpaper)
        {
            this._config.SelectedWallpaper = wallpaper;
            this.save();
        }

        public string GetSelectedWallpaper()
        {
            return this._config.SelectedWallpaper;
        }

        public void SetUseWallpaper(bool enabled)
        {
            this._config.UseWallpaper = enabled;
            this.save();
        }

        public bool GetUseWallpaper()
        {
            return this._config.UseWallpaper;
        }

        public void SetLaunchAtBoot(bool enabled)
        {
            var path = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";
            RegistryKey key = Registry.CurrentUser.OpenSubKey(path, true);
            if (enabled)
            {
                key.SetValue("BGEngine", Assembly.GetEntryAssembly().Location);
            }
            else
            {
                key.DeleteValue("BGEngine", false);
            }
        }

        public bool GetLaunchAtBoot()
        {
            var path = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";
            RegistryKey key = Registry.CurrentUser.OpenSubKey(path, true);

            return key.GetValueNames().Contains("BGEngine");
        }

        private void save()
        {
            File.WriteAllText(Path.Combine(Application.StartupPath, "config.json"), JsonConvert.SerializeObject(_config));
        }
    }
}
