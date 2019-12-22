using BGEngine.Entities;
using BGEngine.Forms;
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
    class Entry
    {
        static MainWindow main;
        internal static Config Config;
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

            Application.EnableVisualStyles();
            Application.Run(new MainWindow());
        }
    }
}
