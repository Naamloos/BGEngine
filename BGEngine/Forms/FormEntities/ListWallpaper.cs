using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace BGEngine.Forms.FormEntities
{
    class ListWallpaper
    {
        private string _Title;
        public string Title
        {
            get { return this._Title; }
            set { this._Title = value; }
        }

        private Uri _ImageData;
        public Uri ImageData
        {
            get { return this._ImageData; }
            set { this._ImageData = value; }
        }
    }
}
