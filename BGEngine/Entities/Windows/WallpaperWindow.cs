using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BGEngine.Entities.Windows
{
    abstract class WallpaperWindow
    {
        /// <summary>
        /// Whether this window is on the background.
        /// </summary>
        internal bool _isOnBackground;
        /// <summary>
        /// Whether the Border is hidden.
        /// </summary>
        internal bool _isHiddenBorder;
        /// <summary>
        /// An integer value to store the old state of the border.
        /// </summary>
        internal int _oldBorder;

        /// <summary>
        /// Workerw handle.
        /// </summary>
        internal IntPtr _workerw;

        /// <summary>
        /// Window Width
        /// </summary>
        internal int Width;

        /// <summary>
        /// Window Height
        /// </summary>
        internal int Height;

        /// <summary>
        /// Window X
        /// </summary>
        internal int X;

        /// <summary>
        /// Window Y
        /// </summary>
        internal int Y;

        /// <summary>
        /// Kills this window.
        /// </summary>
        public abstract void Kill();

        /// <summary>
        /// Starts this window.
        /// </summary>
        public abstract void Start();

        /// <summary>
        /// Gets this window's handle.
        /// </summary>
        /// <returns></returns>
        public abstract IntPtr GetHandle();

        public WallpaperWindow(int width, int height, int x, int y)
        {
            this._workerw = FindWorkerW();
            this.Width = width;
            this.Height = height;
            this.X = x;
            this.Y = y;
        }

        /// <summary>
        /// Hides this window's borders.
        /// </summary>
        public void HideBorders()
        {
            // Check whether the borders are not already hidden.
            if (!_isHiddenBorder)
            {
                // Get handle.
                var handle = this.GetHandle();

                // Can't do anything without handle.
                if (handle != null)
                {
                    // Store the old border style so we can restore it later.
                    this._oldBorder = Win32.GetWindowLong(handle, Win32.GWL_STYLE);

                    // Hide this window's borders.
                    Win32.SetWindowLong(handle, Win32.GWL_STYLE, Win32.WS_SYSMENU);

                    // This window is now hidden.
                    this._isHiddenBorder = true;
                }
            }
        }

        /// <summary>
        /// Reveals this window's borders.
        /// </summary>
        public void RevealBorders()
        {
            // Don't reveal windows that are already revealed.
            if (this._isHiddenBorder)
            {
                var handle = this.GetHandle();

                // No border revealing when the window doesn't exist yo
                if (handle != null)
                {
                    // Restoring the old border.
                    Win32.SetWindowLong(handle, Win32.GWL_STYLE, this._oldBorder);

                    // aaaaand setting the boolean
                    this._isHiddenBorder = false;
                }
            }
        }

        /// <summary>
        /// Moves this window to the back (wallpaper).
        /// </summary>
        public virtual void MoveToBack()
        {
            // Check whether this window isn't already on the wallpaper.
            if (!this._isOnBackground)
            {
                // Get this window's handle.
                var handle = this.GetHandle();

                // Can't do anything without handle.
                if (handle != null)
                {
                    // Setting this window's parent to workerw.
                    Win32.SetParent(handle, this._workerw);

                    //MessageBox.Show($"x{b.X}, y{b.Y}, w{b.Width}, h{b.Height}");

                    // Set a new position for this window to fill the screen.
                    Win32.SetWindowPos(handle, Win32.HWND_TOP, this.X, this.Y, this.Width, this.Height, Win32.SWP_SHOWWINDOW);

                    // Woo! we're done. Set a new value for isOnBackground.
                    this._isOnBackground = true;
                }
            }
        }

        /// <summary>
        /// Moves this window to the front.
        /// </summary>
        public virtual void MoveToFront()
        {
            // Checking whether this window is on the background.
            if (this._isOnBackground)
            {
                var handle = this.GetHandle();

                // Can't do anything without handle.
                if (handle != null)
                {
                    // Set this window's parent handle to null so it goes back to being a window.
                    Win32.SetParent(handle, IntPtr.Zero);

                    // Setting window position to something onscreen that doesn't fill the screen.
                    Win32.SetWindowPos(handle, Win32.HWND_TOP, 25, 25, 500, 250, Win32.SWP_SHOWWINDOW);

                    // Yes. We're done. Set isOnBackground to false.
                    this._isOnBackground = false;
                }
            }
        }

        /// <summary>
        /// Finds the workerw handle.
        /// </summary>
        private IntPtr FindWorkerW()
        {
            // Many thanks to Gerald Degeneve's article
            // https://www.codeproject.com/Articles/856020/Draw-Behind-Desktop-Icons-in-Windows-plus

            var workerw = IntPtr.Zero;

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
                    workerw = Win32.FindWindowEx(IntPtr.Zero,
                                               tophandle,
                                               "WorkerW",
                                               "");
                }

                return true;
            }), IntPtr.Zero);

            return workerw;
        }
    }
}
