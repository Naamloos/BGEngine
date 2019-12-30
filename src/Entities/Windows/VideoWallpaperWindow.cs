using LibVLCSharp.Shared;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGEngine.Entities.Windows
{
    class VideoWallpaperWindow : WallpaperWindow
    {
        MediaPlayer _mediaplayer;
        Media _media;
        IntPtr _hwnd;
        public VideoWallpaperWindow(string mediapath, int width, int height, int x, int y) : base(width, height, x, y)
        {
            this._mediaplayer = new MediaPlayer(Program.LibVLC);
            this._media = new Media(Program.LibVLC, mediapath);
            this._mediaplayer.Volume = 0;
            this._mediaplayer.Play(this._media);
        }

        public override IntPtr GetHandle()
        {
            return this._hwnd;
        }

        public override void Kill()
        {
            _mediaplayer.Stop();
        }

        public override void Start()
        {
            this._mediaplayer.Play(_media);
        }

        public override void MoveToBack()
        {
            this._mediaplayer.Hwnd = this._workerw;
        }

        public override void MoveToFront()
        {
            this._mediaplayer.Hwnd = IntPtr.Zero;
        }
    }
}
