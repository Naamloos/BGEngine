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
        public static LibVLC LibVLC;

        [STAThread]
        static void Main(string[] args)
        {
            Core.Initialize();
            LibVLC = new LibVLC("--input-repeat=65535", "--autoscale", "--repeat", "--no-embedded-video", "--aspect-ratio=4:3");

            var engine = new Engine();

            engine.Run();
        }
    }
}
