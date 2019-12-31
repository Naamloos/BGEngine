using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BGEngine.Entities
{
    public class Wallpaper
    {
        [JsonProperty("name")]
        public string Name;

        [JsonProperty("description")]
        public string Description;

        [JsonProperty("author")]
        public string Author;

        [JsonProperty("thumbnailpath")]
        public string ThumbnailPath;

        [JsonProperty("projecturl")]
        public string ProjectUrl;

        [JsonProperty("authorurl")]
        public string AuthorUrl;

        [JsonProperty("type")]
        public WallpaperType Type;

        [JsonIgnore]
        public string WallpaperPath
        {
            get
            {
                if(Type == WallpaperType.Website)
                {
                    return _wallpaperpath;
                }
                return System.IO.Path.Combine(Path, _wallpaperpath);
            }
        }

        [JsonIgnore]
        public string Path { get; set; }

        [JsonProperty("path")]
        private string _wallpaperpath;

        public override string ToString()
        {
            return $"{this.Name} by {this.Author}";
        }
    }

    public enum WallpaperType
    {
        Video,
        Plugin,
        Web,
        Website,
        Unity
    }
}
