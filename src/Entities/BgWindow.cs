using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGEngine
{
    public class BgWindow
    {
        private Process _process;
        private bool _isOnBackground;
        private bool _isHiddenBorder;
        private int _oldBorder;
        private IntPtr _workerw;
        private IntPtr _handle => _process.MainWindowHandle;

        public BgWindow(Process process)
        {
            this._process = process;
            this._isOnBackground = false;
            this._isHiddenBorder = false;

            // We're going to look for the workerw
            findWorkerW();
        }

        public void Kill()
        {
            if(!_process.HasExited)
                _process.Kill();
        }

        public void MoveToBack()
        {
            // We'll set the window's parent handle to the bg handle.
            if (!this._isOnBackground)
            {
                Win32.SetParent(this._handle, this._workerw);
                Win32.SetWindowPos(this._handle, Win32.HWND_TOP, 0, 0, 1920, 1080, Win32.SWP_SHOWWINDOW);
                this._isOnBackground = true;
            }
        }

        public void ReleaseFromBack()
        {
            if (this._isOnBackground)
            {
                Win32.SetParent(this._handle, IntPtr.Zero);
                Win32.SetWindowPos(this._handle, Win32.HWND_TOP, 25, 25, 500, 250, Win32.SWP_SHOWWINDOW);
                this._isOnBackground = false;
            }
        }

        public void RemoveBorders()
        {
            if (!_isHiddenBorder)
            {
                this._oldBorder = Win32.GetWindowLong(this._handle, Win32.GWL_STYLE);
                Win32.SetWindowLong(this._handle, Win32.GWL_STYLE, Win32.WS_SYSMENU);
                this._isHiddenBorder = true;
            }
        }

        public void RevealBorders()
        {
            if (this._isHiddenBorder)
            {
                Win32.SetWindowLong(this._handle, Win32.GWL_STYLE, this._oldBorder);
                this._isHiddenBorder = false;
            }
        }

        private void findWorkerW()
        {
            // get progman
            IntPtr progman = Win32.FindWindow("Progman", null);

            // initialize result
            IntPtr result = IntPtr.Zero;

            // Send 0x052C to Progman. This message directs Progman to spawn a 
            // WorkerW behind the desktop icons. If it is already there, nothing 
            // happens.
            Win32.SendMessageTimeout(progman,
                                   0x052C,
                                   new IntPtr(0),
                                   IntPtr.Zero,
                                   Win32.SendMessageTimeoutFlags.SMTO_NORMAL,
                                   1000,
                                   out result);

            // We enumerate all Windows, until we find one, that has the SHELLDLL_DefView 
            // as a child. 
            // If we found that window, we take its next sibling and assign it to workerw.
            Win32.EnumWindows(new Win32.EnumWindowsProc((tophandle, topparamhandle) =>
            {
                IntPtr p = Win32.FindWindowEx(tophandle,
                                            IntPtr.Zero,
                                            "SHELLDLL_DefView",
                                            "");

                if (p != IntPtr.Zero)
                {
                    // Gets the WorkerW Window after the current one.
                    _workerw = Win32.FindWindowEx(IntPtr.Zero,
                                               tophandle,
                                               "WorkerW",
                                               "");
                }

                return true;
            }), IntPtr.Zero);
        }

        public override string ToString()
        {
            return $"Window: {this._process.MainWindowTitle}, on bg: {this._isOnBackground}";
        }
    }
}
