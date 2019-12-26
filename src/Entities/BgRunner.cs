using BGEngine.Sdk;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static BGEngine.BgWindow;

namespace BGEngine.Entities
{
    public class BgRunner
    {
        private BgWindow _window = null;
        private bool _killwhendone = false;
        public bool Running { get { return _running; } }
        private bool _running = false;

        public BgRunner()
        {

        }

        public void Start(string file)
        {
            _killwhendone = true;
            // give the process some time to start
            _running = true;
            _window = new BgWindow(file);

            _window.RemoveBorders();
            _window.MoveToBack();
        }

        public void Start(IPlugin plugin)
        {
            _killwhendone = true;
            // give the process some time to start
            _running = true;
            _window = new BgWindow(plugin);

            _window.RemoveBorders();
            _window.MoveToBack();
        }

        public void Start(Process process)
        {
            _running = true;
            _window = new BgWindow(process);

            _window.RemoveBorders();
            _window.MoveToBack();
        }

        public void Start(IntPtr handle, Action killmethod)
        {
            _killwhendone = true;
            _running = true;
            _window = new BgWindow(handle, killmethod);

            _window.RemoveBorders();
            _window.MoveToBack();
        }

        public void Stop()
        {
            _window.ReleaseFromBack();
            _window.RevealBorders();
            if (_killwhendone)
            {
                _window.Kill();
            }
            _killwhendone = false;
            _running = false;
        }
    }
}
