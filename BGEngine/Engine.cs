using BGEngine.Entities.Managers;
using BGEngine.Forms;
using LibVLCSharp.Shared;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace BGEngine
{
    public class Engine
    {
        private NotifyIcon _icon;

        public ConfigManager ConfigManager;
        public WallpaperManager WallpaperManager;
        public TaskbarManager TaskbarManager;

        private WindowManager _windowManager;
        private bool _settingsvisible = false;

        public Engine()
        {
            CheckForUpdates();
            Core.Initialize();

            this.ConfigManager = new ConfigManager();
            this.WallpaperManager = new WallpaperManager();
            this._windowManager = new WindowManager();
            this.TaskbarManager = new TaskbarManager();

            this._icon = new NotifyIcon();
            this._icon.Icon = Icon.ExtractAssociatedIcon(Assembly.GetExecutingAssembly().Location);

            this._icon.Click += openSettings;
            this._icon.DoubleClick += openSettings;
            this._icon.BalloonTipClicked += openSettings;
        }

        private void openSettings(object sender, EventArgs e)
        {
            if (!_settingsvisible)
            {
                _settingsvisible = true;

                var settings = new Settings(this);
                settings.InitializeComponent();

                settings.ShowDialog();
                settings.Close();
                settings = null;
                GC.Collect();

                _settingsvisible = false;
            }
        }

        public void UpdateState()
        {
            _windowManager.Stop();

            if (ConfigManager.GetUseWallpaper())
                _windowManager.Start(WallpaperManager.GetCurrentWallpaper());

            TaskbarManager.SetTaskbarStyle(ConfigManager.GetTaskbarMode());
        }

        public void Run()
        {
            this.ConfigManager.Load();
            this.WallpaperManager.LoadWallpapers();

            // Initialize shit here
            WallpaperManager.SetCurrentWallpaper(ConfigManager.GetSelectedWallpaper());
            UpdateState();

            this._icon.Visible = true;
            this._icon.ShowBalloonTip(0, "BGEngine", "Started running!", ToolTipIcon.None);
            // Required for notifyicon
            System.Windows.Forms.Application.Run();
        }

        public void Stop()
        {
            _windowManager.Stop();
            System.Windows.Forms.Application.Exit();
        }

        const string EXPECTED_GH_VERSION_TAG = "0.4BETA";
        private void CheckForUpdates()
        {
            try
            {
                var releases = new Octokit.ReleasesClient(new Octokit.ApiConnection(new Octokit.Connection(new Octokit.ProductHeaderValue("bgengine"))));
                var allreleases = releases.GetAll("Naamloos", "BGEngine").GetAwaiter().GetResult();
                var latest = allreleases.OrderByDescending(x => x.PublishedAt).First();
                if (latest.TagName != EXPECTED_GH_VERSION_TAG)
                {
                    System.Windows.MessageBox.Show($"You're on version {EXPECTED_GH_VERSION_TAG}. The latest available is {latest.TagName}.\n" +
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
