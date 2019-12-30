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

        public SamplePlugin()
        {
        }

        public void KillWindow()
        {
            // Killing the current window
            _form.Hide();
            _form.Dispose();
        }

        public IntPtr RequestWindowHandle()
        {
            // Sending handles to created windows back to the app.
            return this._form.Handle;
        }

        public void SpawnWindow(int width, int height)
        {
            // Spawning windows.
            _form = new SamplePluginForm();
            _form.Width = width;
            _form.Height = height;
            _form.Show();
        }
    }
}
