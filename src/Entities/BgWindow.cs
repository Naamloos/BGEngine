using LibVLCSharp.Shared;
using Microsoft.Win32;
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
        private MediaPlayer _mediaplayer;

        private bool _isOnBackground;
        private bool _isHiddenBorder;
        private int _oldBorder;
        private IntPtr _workerw;
        private IntPtr _handle;
        private Action _killwindow;

        public BgWindow(Process process)
        {
            this._process = process;
            this._handle = process.MainWindowHandle;
            this._isOnBackground = false;
            this._isHiddenBorder = false;

            // We're going to look for the workerw
            findWorkerW();
        }

        public BgWindow(IntPtr handle, Action killwindow)
        {
            this._handle = handle;
            this._process = null;
            this._isOnBackground = false;
            this._isHiddenBorder = false;
            this._killwindow = killwindow;

            // We're going to look for the workerw
            findWorkerW();
        }

        public BgWindow(string mediapath)
        {
            // We're going to look for the workerw
            findWorkerW();
            this._isOnBackground = false;
            this._isHiddenBorder = false;

            var mediaplayer = new MediaPlayer(Program.LibVLC);
            var media = new Media(Program.LibVLC, mediapath);
            mediaplayer.Volume = 0;
            mediaplayer.Play(media);

            this._mediaplayer = mediaplayer;
        }

        public void Kill()
        {
            if (_process != null)
            {
                if (!_process.HasExited)
                    _process.Kill();
            }
            if (this._killwindow != null)
            {
                this._killwindow();
            }
            if(this._mediaplayer != null)
            {
                this._mediaplayer.Stop();
            }

            IntPtr dc = Win32.GetDCEx(_workerw, IntPtr.Zero, (Win32.DeviceContextValues)0x403);
            Win32.ReleaseDC(_workerw, dc);

            // resetting wallpaper
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true);

            Win32.SystemParametersInfo(Win32.SPI_SETDESKWALLPAPER,
                0,
                (string)key.GetValue("Wallpaper"),
                Win32.SPIF_UPDATEINIFILE | Win32.SPIF_SENDWININICHANGE);
        }

        public void MoveToBack()
        {
            // We'll set the window's parent handle to the bg handle.
            if (!this._isOnBackground)
            {
                if (this._handle != null)
                {
                    Win32.SetParent(this._handle, this._workerw);
                    Win32.SetWindowPos(this._handle, Win32.HWND_TOP, 0, 0, 1920, 1080, Win32.SWP_SHOWWINDOW);
                }
                if(this._mediaplayer != null)
                {
                    this._mediaplayer.Hwnd = _workerw;
                }
                this._isOnBackground = true;
            }
        }

        public void ReleaseFromBack()
        {
            if (this._isOnBackground)
            {
                if (this._handle != null)
                {
                    Win32.SetParent(this._handle, IntPtr.Zero);
                    Win32.SetWindowPos(this._handle, Win32.HWND_TOP, 25, 25, 500, 250, Win32.SWP_SHOWWINDOW);
                }
                if(this._mediaplayer != null)
                {
                    this._mediaplayer.Hwnd = IntPtr.Zero;
                }
                this._isOnBackground = false;
            }
        }

        public void RemoveBorders()
        {
            if (!_isHiddenBorder)
            {
                if (this._handle != null)
                {
                    this._oldBorder = Win32.GetWindowLong(this._handle, Win32.GWL_STYLE);
                    Win32.SetWindowLong(this._handle, Win32.GWL_STYLE, Win32.WS_SYSMENU);
                }
                this._isHiddenBorder = true;
            }
        }

        public void RevealBorders()
        {
            if (this._isHiddenBorder)
            {
                if (this._handle != null)
                {
                    Win32.SetWindowLong(this._handle, Win32.GWL_STYLE, this._oldBorder);
                }
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
                    this._workerw = Win32.FindWindowEx(IntPtr.Zero,
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
