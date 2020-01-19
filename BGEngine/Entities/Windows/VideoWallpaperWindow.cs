using BGEngine.Forms;
using LibVLCSharp.Shared;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BGEngine.Entities.Windows
{
    class VideoWallpaperWindow : WallpaperWindow
    {
        MediaPlayer _mediaplayer;
        Media _media;
        EmptyForm _form;

        public VideoWallpaperWindow(string mediapath, int width, int height, int x, int y) : base(width, height, x, y)
        {
            this._form = new EmptyForm();
            this._mediaplayer = new MediaPlayer(Program.LibVLC);
            this._mediaplayer.Hwnd = this._form.Handle;
            this._media = new Media(Program.LibVLC, mediapath);
            this._mediaplayer.Volume = 0;
            this._mediaplayer.Play(this._media);
        }

        public override IntPtr GetHandle()
        {
            return this._form.Handle;
        }

        public override void Kill()
        {
            _mediaplayer.Stop();
            _form.Dispose();
        }

        public override void Start()
        {
            this._mediaplayer.Play(_media);
        }
    }
}
