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
        internal static List<Wallpaper> Wallpapers;

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
            var b = Screen.PrimaryScreen.Bounds;
            LibVLC = new LibVLC("--input-repeat=65535", "--autoscale", "--repeat", "--no-embedded-video");

            Wallpapers = new List<Wallpaper>();

            if (!Directory.Exists("wallpapers"))
            {
                Directory.CreateDirectory("wallpapers");
            }

            foreach(var dir in Directory.GetDirectories("wallpapers"))
            {
                var metapath = Path.Combine(dir, "meta.json");
                if (File.Exists(metapath))
                {
                    var wp = File.ReadAllText(metapath);
                    var wpaper = JsonConvert.DeserializeObject<Wallpaper>(wp);
                    wpaper.Path = dir;
                    Wallpapers.Add(wpaper);
                }
                else
                {
                    File.Create(metapath).Close();
                    File.WriteAllText(metapath, JsonConvert.SerializeObject(new Wallpaper()));
                }
            }

            CheckForUpdates();

            Application.EnableVisualStyles();
            Application.Run(new MainWindow());
        }

        const string EXPECTED_GH_VERSION_TAG = "0.4BETA";
        static void CheckForUpdates()
        {
            try
            {
                var releases = new Octokit.ReleasesClient(new Octokit.ApiConnection(new Octokit.Connection(new Octokit.ProductHeaderValue("bgengine"))));
                var allreleases = releases.GetAll("Naamloos", "BGEngine").GetAwaiter().GetResult();
                var latest = allreleases.OrderByDescending(x => x.PublishedAt).First();
                if (latest.TagName != EXPECTED_GH_VERSION_TAG)
                {
                    MessageBox.Show($"You're on version {EXPECTED_GH_VERSION_TAG}. The latest available is {latest.TagName}.\n" +
                        $"The new version is available on GitHub.", "Update available!");
                }
            }
            catch (Exception)
            {
                // User probably doesn't have an internet connection. We'll just ignore it.
            }
        }
    }
}
