using BGEngine.Entities;
using BGEngine.Forms;
using LibVLCSharp.Shared;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BGEngine
{
    class Program
    {
        internal static LibVLC LibVLC;

        [STAThread]
        static void Main(string[] args)
        {
            // Initialize VLC
            Core.Initialize();
            LibVLC = new LibVLC("--input-repeat=65535", "--autoscale", "--repeat", "--no-embedded-video");

            CheckForUpdates();
        }

        const string EXPECTED_GH_VERSION_TAG = "0.4BETA";
        static void CheckForUpdates()
        {
            try
            {
                var releases = new Octokit.ReleasesClient(new Octokit.ApiConnection(new Octokit.Connection(new Octokit.ProductHeaderValue("bgengine"))));
                var allreleases = releases.GetAll("Naamloos", "BGEngine").GetAwaiter().GetResult();
                var latest = allreleases.OrderByDescending(x => x.PublishedAt).First();
                if (latest.TagName != EXPECTED_GH_VERSION_TAG)
                {
                    MessageBox.Show($"You're on version {EXPECTED_GH_VERSION_TAG}. The latest available is {latest.TagName}.\n" +
                        $"The new version is available on GitHub.", "Update available!");
                }
            }
            catch (Exception)
            {
                // User probably doesn't have an internet connection. We'll just ignore it.
            }
        }
    }
}
