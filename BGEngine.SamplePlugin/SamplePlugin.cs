using BGEngine.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGEngine.SamplePlugin
{
    public class SamplePlugin : IPlugin
    {
        private SamplePluginForm _form;
        private PluginInfo _info;

        public SamplePlugin()
        {
            // For this sample we're using windows forms, but things like WPF and Monogame should work too! c:
            // Gonna spawn only one window for now, multi-screen support will come some other day hopefully.
            _info = new PluginInfo()
            {
                Author = "Naamloos",
                AuthorUrl = "https://www.naamloos.dev",
                PluginName = "samplePlugin",
                ProjectUrl = "https://www.github.com/Naamloos/BGEngine",
                PluginId = "bgengine-sampleplugin",
                HasConfig = true
            };
        }

        public void KillWindow()
        {
            // Killing the current window
            _form.Hide();
            _form.Dispose();
        }

        public PluginInfo RequestPluginInfo()
        {
            return _info;
        }

        public IntPtr[] RequestWindowHandles()
        {
            // Sending handles to created windows back to the app.
            return new IntPtr[] { _form.Handle };
        }

        public void SendMonitorSizes(IEnumerable<MonitorSize> sizes)
        {
            // Storing sizes for windows I need to spawn.
        }

        public void ShowPluginConfig()
        {
            // let's pretend the same form is our config
            var config = new SamplePluginForm();
            // This should block until config is hidden again
            config.ShowDialog();
        }

        public void SpawnWindows()
        {
            // Spawning windows.
            _form = new SamplePluginForm();
            _form.Show();
        }
    }
}
