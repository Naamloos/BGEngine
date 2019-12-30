using BGEngine.Sdk;
using LibVLCSharp.Shared;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BGEngine.Entities.Windows
{
    class PluginWallpaperWindow : WallpaperWindow
    {
        IPlugin _plugin;
        Media _media;
        IntPtr _hwnd;
        public PluginWallpaperWindow(string dllpath, int width, int height, int x, int y) : base(width, height, x, y)
        {
            // Loading assembly
            var asm = Assembly.LoadFrom(dllpath);
            // Finding the first plugin class
            var pluginclass = asm.GetTypes().Where(p => typeof(IPlugin).IsAssignableFrom(p) && p != typeof(IPlugin)).FirstOrDefault();
            // Creating plugin instance
            _plugin = (IPlugin)Activator.CreateInstance(pluginclass);
        }

        public override IntPtr GetHandle()
        {
            return this._plugin.RequestWindowHandle();
        }

        public override void Kill()
        {
            this._plugin.KillWindow();
        }

        public override void Start()
        {
            this._plugin.SpawnWindow(this.Width, this.Height);
        }
    }
}
