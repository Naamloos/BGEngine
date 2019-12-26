using BGEngine.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGEngine.Entities
{
    internal class ListPlugin
    {
        public ListPlugin(IPlugin plugin)
        {
            this.Plugin = plugin;
        }

        public IPlugin Plugin;

        public override string ToString()
        {
            var pinfo = Plugin.RequestPluginInfo();
            return $"{pinfo.PluginName} by {pinfo.Author} ({pinfo.PluginId})";
        }
    }
}
