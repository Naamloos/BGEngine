using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGEngine.Sdk
{
    public struct PluginInfo
    {
        /// <summary>
        /// Author of this plugin
        /// </summary>
        public string Author;

        /// <summary>
        /// Project Url for this plugin
        /// </summary>
        public string ProjectUrl;

        /// <summary>
        /// Name of this plugin
        /// </summary>
        public string PluginName;

        /// <summary>
        /// Author Url for this plugin
        /// </summary>
        public string AuthorUrl;

        /// <summary>
        /// Unique identifier for this plugin. Might cause compatibility issues if ID is in use.
        /// </summary>
        public string PluginId;

        /// <summary>
        /// Whether this plugin has its own config.
        /// </summary>
        public bool HasConfig;
    }
}
