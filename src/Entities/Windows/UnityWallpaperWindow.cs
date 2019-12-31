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
            return _unityHwnd;
        }

        public override void Start()
        {
            var wait = new SpinWait();
            var psi = new ProcessStartInfo(_exePath, $"-parentHWND {_workerw.ToInt32()} -screen-width {Width} -screen-height {Height}");

            _process = Process.Start(psi);
            _process.WaitForInputIdle();
            _process.Refresh();

            Win32.EnumChildWindows(_workerw, EnumWindowProc, IntPtr.Zero);

            // according to unity docs, wait until the least significant bit of GWL_USERDATA = 1
            while ((Win32.GetWindowLong(_unityHwnd, Win32.GWL_USERDATA) & 0x7FFFFFFFF) != 1)
            {
                wait.SpinOnce();
            }

            Win32.MoveWindow(_unityHwnd, X, Y, Width, Height, true);

            _isHiddenBorder = true;
            _isOnBackground = true;
        }

        // hacky way to get the window handle because for some reason
        // `_process.MainWindowHandle` doesn't work
        private bool EnumWindowProc(IntPtr hWnd, IntPtr lParam)
        {
            Win32.GetWindowThreadProcessId(hWnd, out var procId);

            if (procId == _process.Id)
            {
                _unityHwnd = hWnd;
            }

            return true;
        }

        public override void Kill()
        {
            try
            {
                _process?.Kill();
            }
            catch
            {
                // this is probably fine
            }
        }
    }
}
