using BGEngine.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGEngine.Entities.Windows
{
    class WebWallpaperWindow : WallpaperWindow
    {
        BrowserForm _browser;

        public WebWallpaperWindow(string uri, WallpaperType Type, int Width, int Height, int X, int Y) : base(Width, Height, X, Y)
        {
            string url;
            if (Type == WallpaperType.Website)
            {
                url = uri;
            }
            else
            {
                url = $"file://{uri}/index.html";
            }

            _browser = new BrowserForm(url);
        }

        public override IntPtr GetHandle()
        {
            return _browser.Handle;
        }

        public override void Kill()
        {
            _browser.Dispose();
        }

        public override void Start()
        {
            _browser.Show();
        }
    }
}
