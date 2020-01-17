using BGEngine.Entities.Windows;
using BGEngine.Sdk;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BGEngine.Entities.Managers
{
    public class WindowManager
    {
        private List<WallpaperWindow> _windows = null;
        public bool Running { get; private set; } = false;

        public WindowManager()
        {
            _windows = new List<WallpaperWindow>();
        }

        public void Start(Wallpaper w)
        {
            // give the process some time to start
            if(w == null)
            {
                return;
            }

            Running = true;

            foreach (var s in Screen.AllScreens)
            {
                var bounds = s.Bounds;
                WallpaperWindow win;
                switch (w.Type)
                {
                    default:
                    case WallpaperType.Video:
                        win = new VideoWallpaperWindow(w.WallpaperPath, bounds.Width, bounds.Height, bounds.X, bounds.Y);
                        break;

                    case WallpaperType.Plugin:
                        win = new PluginWallpaperWindow(w.WallpaperPath, bounds.Width, bounds.Height, bounds.X, bounds.Y);
                        break;

                    case WallpaperType.Web:
                    case WallpaperType.Website:
                        win = new WebWallpaperWindow(w.WallpaperPath, w.Type, bounds.Width, bounds.Height, bounds.X, bounds.Y);
                        break;

                    case WallpaperType.Unity:
                        win = new UnityWallpaperWindow(w.WallpaperPath, bounds.Width, bounds.Height, bounds.X, bounds.Y);
                        break;
                }

                win.Start();
                win.HideBorders();
                win.MoveToBack();
                _windows.Add(win);
                this.Running = true;
            }
        }

        public void Stop()
        {
            var workerw = IntPtr.Zero;
            foreach (var w in _windows)
            {
                w.MoveToFront();
                w.RevealBorders();
                w.Kill();
                workerw = w._workerw;
            }

            // Releasing the workerw, might want to bring this INTO the class..
            IntPtr dc = Win32.GetDCEx(workerw, IntPtr.Zero, (Win32.DeviceContextValues)0x403);
            Win32.ReleaseDC(workerw, dc);

            this._windows.Clear();
            RestoreWallpaper();
            this.Running = false;
        }


        /// <summary>
        /// Restores the original wallpaper.
        /// </summary>
        private void RestoreWallpaper()
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true);

            Win32.SystemParametersInfo(Win32.SPI_SETDESKWALLPAPER,
                0,
                (string)key.GetValue("Wallpaper"),
                Win32.SPIF_UPDATEINIFILE | Win32.SPIF_SENDWININICHANGE);
        }
    }
}
