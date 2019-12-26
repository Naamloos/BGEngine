using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGEngine.Sdk
{
    public interface IPlugin
    {
        void SendMonitorSizes(IEnumerable<MonitorSize> sizes);
        /// <summary>
        /// Requests the plugin to spawn new windows.
        /// </summary>
        void SpawnWindows();

        /// <summary>
        /// Requests the plugin to kill its windows.
        /// </summary>
        void KillWindow();

        /// <summary>
        /// Requests the plugin to return window handles for your spawned windows. Indices must match monitor indices.
        /// </summary>
        /// <returns></returns>
        IntPtr[] RequestWindowHandles();

        /// <summary>
        /// Requests the plugin to return Plugin info.
        /// </summary>
        /// <returns></returns>
        PluginInfo RequestPluginInfo();

        /// <summary>
        /// Asks the plugin to show it's config screen. This should block until config is closed again.
        /// </summary>
        void ShowPluginConfig();
    }
}
