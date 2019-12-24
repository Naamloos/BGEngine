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
        [JsonProperty("hideborders")]
        public bool HideBorders = true;

        [JsonProperty("backgroundmode")]
        public BackgroundMode BackgroundMode = BackgroundMode.Video;

        [JsonProperty("vlcargs")]
        public string VlcArgs = "--loop --fullscreen --no-osd --gain=0 --qt-minimal-view --quiet --qt-auto-raise=0 -Idummy --no-qt-system-tray";

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
