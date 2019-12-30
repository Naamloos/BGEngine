using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGEngine.Sdk
{
    public interface IPlugin
    {
        /// <summary>
        /// Requests the plugin to spawn new windows.
        /// </summary>
        void SpawnWindow(int width, int height);

        /// <summary>
        /// Requests the plugin to kill its windows.
        /// </summary>
        void KillWindow();

        /// <summary>
        /// Requests the plugin to return window handles for your spawned windows. Indices must match monitor indices.
        /// </summary>
        /// <returns></returns>
        IntPtr RequestWindowHandle();
    }
}
