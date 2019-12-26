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
        [JsonProperty("backgroundmode", NullValueHandling = NullValueHandling.Ignore)]
        public BackgroundMode BackgroundMode = BackgroundMode.Video;

        [JsonProperty("videopath", NullValueHandling = NullValueHandling.Ignore)]
        public string VideoPath = "";

        [JsonProperty("autostart-service", NullValueHandling = NullValueHandling.Ignore)]
        public bool AutoStartService = false;

        [JsonProperty("selectedpluginid", NullValueHandling = NullValueHandling.Ignore)]
        public string SelectedPluginId = "";
    }

    public enum BackgroundMode
    {
        Plugin,
        Video
    }
}
