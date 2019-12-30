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
        SimpleHTTPServer _server;
        int _port;
        string _uri;
        public WebWallpaperWindow(string uri, WallpaperType Type, int Width, int Height, int X, int Y) : base(Width, Height, X, Y)
        {
            var url = "";
            if(Type == WallpaperType.Website)
            {
                url = uri;
            }
            else
            {
                _port = new Random().Next(10000, 60000);
                // create webserver
                _uri = uri;
                url = $"http://localhost:{_port}/";
            }
            _browser = new BrowserForm(url);
        }

        public override IntPtr GetHandle()
        {
            return _browser.Handle;
        }

        public override void Kill()
        {
            _server.Stop();
            _browser.Dispose();
        }

        public override void Start()
        {
            _server = new SimpleHTTPServer(_uri, _port);
            _browser.Show();
        }
    }
}
