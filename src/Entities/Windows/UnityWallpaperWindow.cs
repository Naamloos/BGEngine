using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BGEngine.Entities.Windows
{
    class UnityWallpaperWindow : WallpaperWindow
    {
        private Process _process;
        private string _exePath;
        private IntPtr _unityHwnd;

        public UnityWallpaperWindow(string exePath, int width, int height, int x, int y) :
            base(width, height, x, y)
        {
            this._exePath = exePath;
        }

        public override IntPtr GetHandle()
        {
            return this._unityHwnd;
        }

        public override void Start()
        {
            var wait = new SpinWait();
            var psi = new ProcessStartInfo(this._exePath, $"-parentHWND {this._workerw.ToInt32()} -screen-width {this.Width} -screen-height {this.Height}");

            this._process = Process.Start(psi);
            this._process.WaitForInputIdle();
            this._process.Refresh();

            Win32.EnumChildWindows(this._workerw, this.EnumWindowProc, IntPtr.Zero);

            // according to unity docs, wait until the least significant bit of GWL_USERDATA = 1
            while ((Win32.GetWindowLong(this._unityHwnd, Win32.GWL_USERDATA) & 0x7FFFFFFFF) != 1)
            {
                wait.SpinOnce();
            }

            Win32.MoveWindow(this._unityHwnd, this.X, this.Y, this.Width, this.Height, true);

            this._isHiddenBorder = true;
            this._isOnBackground = true;
        }

        // hacky way to get the window handle because for some reason
        // `_process.MainWindowHandle` doesn't work
        private bool EnumWindowProc(IntPtr hWnd, IntPtr lParam)
        {
            Win32.GetWindowThreadProcessId(hWnd, out var procId);

            if (procId == _process.Id)
            {
                this._unityHwnd = hWnd;
            }

            return true;
        }

        public override void Kill()
        {
            try
            {
                this._process?.Kill();
            }
            catch
            {
                // this is probably fine
            }
        }
    }
}
