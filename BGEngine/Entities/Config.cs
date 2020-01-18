using BGEngine.Entities.Managers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGEngine.Entities
{
    public class Config
    {
        [JsonProperty("use-wallpaper", NullValueHandling = NullValueHandling.Ignore)]
        public bool UseWallpaper { 
            get; 
            set; 
        }

        [JsonProperty("selectedwallpaper", NullValueHandling = NullValueHandling.Ignore)]
        public string SelectedWallpaper = "";

        [JsonProperty("taskbarmode")]
        public TaskbarMode TaskbarMode = TaskbarMode.Acrylic;
    }

    public enum BackgroundMode
    {
        Plugin,
        Video
    }
}
