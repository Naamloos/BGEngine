using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BGEngine.Entities.Managers
{
    public class WallpaperManager
    {
        private List<Wallpaper> _wallpapers;
        private Wallpaper _current;

        public WallpaperManager()
        {
            _wallpapers = new List<Wallpaper>();
            _current = null;
        }

        public void SetCurrentWallpaper(string id)
        {
            if(_wallpapers.Any(x => x.ToString() == id))
            {
                this._current = _wallpapers.First(x => x.ToString() == id);
            }
        }

        public Wallpaper GetCurrentWallpaper()
        {
            return this._current;
        }

        public Wallpaper GetWallpaper(string id)
        {
            return _wallpapers.First(x => x.ToString() == id);
        }

        public List<Wallpaper> GetWallpapers()
        {
            return this._wallpapers;
        }

        public void LoadWallpapers()
        {
            if (!Directory.Exists("wallpapers"))
            {
                Directory.CreateDirectory(Path.Combine(Application.StartupPath, "wallpapers"));
            }

            foreach (var dir in Directory.GetDirectories(Path.Combine(Application.StartupPath, "wallpapers")))
            {
                var metapath = Path.Combine(dir, "meta.json");
                if (File.Exists(metapath))
                {
                    var wp = File.ReadAllText(metapath);
                    var wpaper = JsonConvert.DeserializeObject<Wallpaper>(wp);
                    wpaper.Path = dir;
                    _wallpapers.Add(wpaper);
                }
                else
                {
                    File.Create(metapath).Close();
                    File.WriteAllText(metapath, JsonConvert.SerializeObject(new Wallpaper()));
                }
            }
        }
    }
}
