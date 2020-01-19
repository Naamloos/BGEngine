using BGEngine.Entities.Managers;
using BGEngine.Forms.FormEntities;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BGEngine.Forms
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        private Engine engine;
        public Settings(Engine engine)
        {
            this.engine = engine;
            InitializeComponent();

            Autostart.IsChecked = engine.ConfigManager.GetLaunchAtBoot();
            UseLwp.IsChecked = engine.ConfigManager.GetUseWallpaper();
            Centertaskbar.IsChecked = engine.ConfigManager.GetCenterTaskbar();

            Autostart.Checked += checkboxChanged;
            Autostart.Unchecked += checkboxChanged;
            UseLwp.Checked += checkboxChanged;
            UseLwp.Unchecked += checkboxChanged;
            Centertaskbar.Checked += checkboxChanged;
            Centertaskbar.Unchecked += checkboxChanged;

            wallpaperlist.SelectionMode = SelectionMode.Single;
            List<ListWallpaper> wps = new List<ListWallpaper>();
            var selected = engine.WallpaperManager.GetCurrentWallpaper();
            foreach(var wall in engine.WallpaperManager.GetWallpapers())
            {
                var lwp = new ListWallpaper { Title = wall.ToString(), ImageData = new Uri($"{wall.ThumbnailPath}") };
                wps.Add(lwp);
                if(wall == selected)
                {
                    wallpaperlist.SelectedItem = lwp;
                }
            }
            wallpaperlist.ItemsSource = wps;

            wallpaperlist.SelectionChanged += newSelection;

            Taskbarmode.Items.Add(TaskbarMode.None);
            Taskbarmode.Items.Add(TaskbarMode.Acrylic);
            Taskbarmode.Items.Add(TaskbarMode.Blur);
            Taskbarmode.Items.Add(TaskbarMode.Transparent);
            Taskbarmode.SelectedItem = engine.ConfigManager.GetTaskbarMode();
        }

        private void newSelection(object sender, SelectionChangedEventArgs e)
        {
            updateSettings();
        }

        private void checkboxChanged(object sender, RoutedEventArgs e)
        {
            updateSettings();
        }

        private void updateSettings()
        {
            if(wallpaperlist.SelectedItem != null)
                engine.WallpaperManager.SetCurrentWallpaper(((ListWallpaper)wallpaperlist.SelectedItem).Title);

            var wp = engine.WallpaperManager.GetCurrentWallpaper();

            if (wp != null)
            {
                wallpapername.Content = wp.ToString();
                wallpaperdesc.Content = wp.Description;
                authorurl.Content = wp.AuthorUrl;
                projecturl.Content = wp.ProjectUrl;
            }

            engine.ConfigManager.SetTaskbarMode((TaskbarMode)Taskbarmode.SelectedItem);
            engine.ConfigManager.SetLaunchAtBoot(Autostart.IsChecked ?? engine.ConfigManager.GetLaunchAtBoot());
            engine.ConfigManager.SetUseWallpaper(UseLwp.IsChecked ?? engine.ConfigManager.GetUseWallpaper());
            engine.ConfigManager.SetCenterTaskbar(Centertaskbar.IsChecked ?? engine.ConfigManager.GetCenterTaskbar());

            if (wallpaperlist.SelectedItem != null)
                engine.ConfigManager.SetSelectedWallpaper(((ListWallpaper)wallpaperlist.SelectedItem).Title);

            engine.UpdateState();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            engine.Stop();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            engine.Stop();
        }
    }
}
