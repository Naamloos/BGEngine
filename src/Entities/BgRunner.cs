using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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

        public void Start(string file, string args)
        {
            _killwhendone = true;
            var process = Process.Start(file, args);
            // give the process some time to start
            Thread.Sleep(TimeSpan.FromSeconds(3));
            this.Start(process);
        }

        public void Start(Process process)
        {
            _running = true;
            _window = new BgWindow(process);

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
