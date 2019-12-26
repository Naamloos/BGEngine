using BGEngine.Sdk;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BGEngine.Entities
{
    public class PluginManager
    {
        List<IPlugin> _plugins;

        public PluginManager()
        {
            _plugins = new List<IPlugin>();
        }

        public void PreloadPlugins()
        {
            if (!Directory.Exists("plugins"))
            {
                Directory.CreateDirectory("plugins");
            }

            foreach(var dll in Directory.GetFiles("plugins", "*.dll"))
            {
                var asm = Assembly.LoadFrom(dll);

                var pluginclasses = asm.GetTypes().Where(x => typeof(IPlugin).IsAssignableFrom(x) && x != typeof(IPlugin));

                foreach(var pclass in pluginclasses)
                {
                    var plugin = (IPlugin)Activator.CreateInstance(pclass);
                    _plugins.Add(plugin);
                }
            }
            MessageBox.Show($"Loaded plugins: {string.Join(", ", _plugins.Select(x => x.RequestPluginInfo().PluginName))}");
        }

        public IPlugin GetPlugin(string pluginid)
        {
            if(_plugins.Any(x => x.RequestPluginInfo().PluginId == pluginid))
            {
                return _plugins.First(x => x.RequestPluginInfo().PluginId == pluginid);
            }

            return null;
        }

        public IReadOnlyList<IPlugin> GetAllPlugins()
        {
            return _plugins;
        }
    }
}
