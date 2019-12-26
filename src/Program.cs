using BGEngine.Entities;
using BGEngine.Forms;
using LibVLCSharp.Shared;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BGEngine
{
    class Program
    {
        internal static LibVLC LibVLC;
        internal static Config Config;
        internal static PluginManager Plugins;

        [STAThread]
        static void Main(string[] args)
        {
            if (File.Exists(Path.Combine(Application.StartupPath, "config.json")))
            {
                Config = JsonConvert.DeserializeObject<Config>(File.ReadAllText(Path.Combine(Application.StartupPath, "config.json")));
            }
            else
            {
                Config = new Config();
                File.Create(Path.Combine(Application.StartupPath, "config.json")).Close();
            }
            File.WriteAllText(Path.Combine(Application.StartupPath, "config.json"), JsonConvert.SerializeObject(Config));
            Core.Initialize();
            // repeat on -1 or 0 doesn't seem to work, so we'll just use the biggest 16-bit int possible, ooooooof
            LibVLC = new LibVLC("--input-repeat=65535", "--autoscale", "--repeat");

            Plugins = new PluginManager();
            Plugins.PreloadPlugins();

            Application.EnableVisualStyles();
            Application.Run(new MainWindow());
        }
    }
}
