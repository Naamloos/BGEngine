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
        [JsonProperty("autostart-service", NullValueHandling = NullValueHandling.Ignore)]
        public bool AutoStartService = false;

        [JsonProperty("selectedwallpaper", NullValueHandling = NullValueHandling.Ignore)]
        public string SelectedWallpaper = "";
    }

    public enum BackgroundMode
    {
        Plugin,
        Video
    }
}
