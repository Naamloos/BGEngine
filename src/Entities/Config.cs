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
        [JsonProperty("backgroundmode")]
        public BackgroundMode BackgroundMode = BackgroundMode.Video;

        [JsonProperty("videopath")]
        public string VideoPath = "";

        [JsonProperty("autostart-service")]
        public bool AutoStartService = false;
    }

    public enum BackgroundMode
    {
        Plugin,
        Video
    }
}
