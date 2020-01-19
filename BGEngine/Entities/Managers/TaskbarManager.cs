using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation;

namespace BGEngine.Entities.Managers
{
    // Some of the code featured in this class is based on some code from the following repository:
    // https://github.com/mdhiggins/CenterTaskbar
    // Licensed under the MIT license.

    public class TaskbarManager
    {
        private Thread _taskbarThread;
        private CancellationTokenSource _cancel;
        private ConfigManager _config;

        ConcurrentHashSet<AutomationElement> _taskbars = new ConcurrentHashSet<AutomationElement>();
        ConcurrentDictionary<AutomationElement, AutomationElement> _taskbarChildren = new ConcurrentDictionary<AutomationElement, AutomationElement>();
        AutomationElement _desktop = AutomationElement.RootElement;
        ConcurrentDictionary<AutomationElement, double> _lastvalues = new ConcurrentDictionary<AutomationElement, double>();

        public TaskbarManager(ConfigManager config)
        {
            _config = config;
        }

        public void Start()
        {
            _lastvalues.Clear();
            _taskbars.Clear();
            _taskbarChildren.Clear();

            // Setting up the condition to find AutomationElements
            OrCondition condition = new OrCondition(new PropertyCondition(AutomationElement.ClassNameProperty, "Shell_TrayWnd"), new PropertyCondition(AutomationElement.ClassNameProperty, "Shell_SecondaryTrayWnd"));

            // Setting up cache request
            CacheRequest cacheRequest = new CacheRequest();
            cacheRequest.Add(AutomationElement.NameProperty);
            cacheRequest.Add(AutomationElement.BoundingRectangleProperty);

            // Activating cache request
            using (cacheRequest.Activate())
            {
                // Finding tray windows
                AutomationElementCollection lists = _desktop.FindAll(TreeScope.Children, condition);
                if (lists == null)
                {
                    return;
                }

                _lastvalues.Clear();

                // Looping through all found trays
                foreach (AutomationElement trayWnd in lists)
                {
                    // Finding MSTaskListWClass
                    AutomationElement tasklist = trayWnd.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.ClassNameProperty, "MSTaskListWClass"));
                    if (tasklist == null)
                    {
                        continue;
                    }

                    // Adding an event handler on changed properties
                    Automation.AddAutomationPropertyChangedEventHandler(tasklist, TreeScope.Element, TellTrayToUpdate, AutomationElement.BoundingRectangleProperty);

                    // Saving this taskbar
                    _taskbars.Add(trayWnd);
                    // saving this taskbar AND its tasks
                    while(!_taskbarChildren.TryAdd(trayWnd, tasklist)) { } // Ensuring it's getting added.
                }
            }

            // Adding event handlers to the desktop opening / closing.
            Automation.AddAutomationEventHandler(WindowPattern.WindowOpenedEvent, _desktop, TreeScope.Subtree, TellTrayToUpdate);
            Automation.AddAutomationEventHandler(WindowPattern.WindowClosedEvent, _desktop, TreeScope.Subtree, TellTrayToUpdate);

            // Starting taskbar thread
            _cancel = new CancellationTokenSource();
            _taskbarThread = new Thread(new ThreadStart(taskbarLoop));
            _taskbarThread.Start();
        }

        private void TellTrayToUpdate(object sender, AutomationEventArgs e)
        {
            trayuptodate = false;
        }

        bool running = false;
        public void Stop()
        {
            if (_cancel != null)
            {
                resetAll();
                _cancel.Cancel();
            }
        }

        bool previouslyenabled = false;
        bool trayuptodate = false;
        private void taskbarLoop()
        {
            while (!_cancel.IsCancellationRequested)
            {
                setTaskbarStyle(_config.GetTaskbarMode());

                if (_config.GetCenterTaskbar() && !trayuptodate)
                {
                    previouslyenabled = true;
                    foreach (AutomationElement trayWnd in _taskbars)
                    {
                        centerTrayItems(trayWnd);
                    }
                    trayuptodate = true;
                }

                if(!_config.GetCenterTaskbar() && previouslyenabled)
                {
                    resetAll();
                    _taskbars.Clear();
                    _taskbarChildren.Clear();
                    _lastvalues.Clear();
                    previouslyenabled = false;
                }

                Thread.Sleep(1000 / 60);
            }
        }

        private void resetAll()
        {
            foreach (AutomationElement trayWnd in _taskbars)
            {
                Reset(trayWnd);
            }
        }

        private void centerTrayItems(AutomationElement trayWnd)
        {
            AutomationElement tasklist = _taskbarChildren[trayWnd];
            AutomationElement last = TreeWalker.ControlViewWalker.GetLastChild(tasklist);
            if(last == null)
            {
                return;
            }

            Rect trayBounds = trayWnd.Cached.BoundingRectangle;
            bool horizontal = (trayBounds.Width > trayBounds.Height);

            double lastChildPos = (horizontal ? last.Current.BoundingRectangle.Left : last.Current.BoundingRectangle.Top); // Use the left/top bounds because there is an empty element as the last child with a nonzero width

            if ((_lastvalues.ContainsKey(trayWnd) && lastChildPos == _lastvalues[trayWnd]))
            {
                return;
            }
            else
            {
                _lastvalues[trayWnd] = lastChildPos;

                AutomationElement first = TreeWalker.ControlViewWalker.GetFirstChild(tasklist);
                if (first == null)
                {
                    return;
                }

                double scale = horizontal ? (last.Current.BoundingRectangle.Height / trayBounds.Height) : (last.Current.BoundingRectangle.Width / trayBounds.Width);
                double size = (lastChildPos - (horizontal ? first.Current.BoundingRectangle.Left : first.Current.BoundingRectangle.Top)) / scale;
                if (size < 0)
                {
                    return;
                }

                AutomationElement tasklistcontainer = TreeWalker.ControlViewWalker.GetParent(tasklist);
                if (tasklistcontainer == null)
                {
                    return;
                }

                Rect tasklistBounds = tasklist.Current.BoundingRectangle;

                double barSize = horizontal ? trayWnd.Cached.BoundingRectangle.Width : trayWnd.Cached.BoundingRectangle.Height;
                double targetPos = Math.Round((barSize - size) / 2) + (horizontal ? trayBounds.X : trayBounds.Y);

                double delta = Math.Abs(targetPos - (horizontal ? tasklistBounds.X : tasklistBounds.Y));
                // Previous bounds check
                if (delta <= 1)
                {
                    // Already positioned within margin of error, avoid the unneeded MoveWindow call
                    return;
                }

                // Right bounds check
                int rightBounds = sideBoundary(false, horizontal, tasklist);
                if ((targetPos + size) > (rightBounds))
                {
                    // Shift off center when the bar is too big
                    double extra = (targetPos + size) - rightBounds;
                    targetPos -= extra;
                }

                // Left bounds check
                int leftBounds = sideBoundary(true, horizontal, tasklist);
                if (targetPos <= (leftBounds))
                {
                    // Prevent X position ending up beyond the normal left aligned position
                    Reset(trayWnd);
                    return;
                }

                IntPtr tasklistPtr = (IntPtr)tasklist.Current.NativeWindowHandle;

                if (horizontal)
                {
                    Win32.SetWindowPos(tasklistPtr, IntPtr.Zero, (relativePos(targetPos, horizontal, tasklist)), 0, 0, 0, Win32.SWP_NOZORDER | Win32.SWP_NOSIZE | Win32.SWP_ASYNCWINDOWPOS);
                }
                else
                {
                    Win32.SetWindowPos(tasklistPtr, IntPtr.Zero, 0, (relativePos(targetPos, horizontal, tasklist)), 0, 0, Win32.SWP_NOZORDER | Win32.SWP_NOSIZE | Win32.SWP_ASYNCWINDOWPOS);
                }
                _lastvalues[trayWnd] = (horizontal ? last.Current.BoundingRectangle.Left : last.Current.BoundingRectangle.Top);

                return;
            }
        }

        private void Reset(AutomationElement trayWnd)
        {

            AutomationElement tasklist = trayWnd.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.ClassNameProperty, "MSTaskListWClass"));
            if (tasklist == null)
            {
                return;
            }
            AutomationElement tasklistcontainer = TreeWalker.ControlViewWalker.GetParent(tasklist);
            if (tasklistcontainer == null)
            {
                return;
            }

            Rect trayBounds = trayWnd.Cached.BoundingRectangle;
            bool horizontal = (trayBounds.Width > trayBounds.Height);

            IntPtr tasklistPtr = (IntPtr)tasklist.Current.NativeWindowHandle;

            double listBounds = horizontal ? tasklist.Current.BoundingRectangle.X : tasklist.Current.BoundingRectangle.Y;

            Rect bounds = tasklist.Current.BoundingRectangle;
            int newWidth = (int)bounds.Width;
            int newHeight = (int)bounds.Height;
            Win32.SetWindowPos(tasklistPtr, IntPtr.Zero, 0, 0, 0, 0, Win32.SWP_NOZORDER | Win32.SWP_NOSIZE | Win32.SWP_ASYNCWINDOWPOS);
        }

        private int relativePos(double x, bool horizontal, AutomationElement element)
        {
            int adjustment = sideBoundary(true, horizontal, element);

            double newPos = x - adjustment;

            if (newPos < 0)
            {
                newPos = 0;
            }

            return (int)newPos;
        }

        private int sideBoundary(bool left, bool horizontal, AutomationElement element)
        {
            double adjustment = 0;
            AutomationElement prevSibling = TreeWalker.ControlViewWalker.GetPreviousSibling(element);
            AutomationElement nextSibling = TreeWalker.ControlViewWalker.GetNextSibling(element);
            AutomationElement parent = TreeWalker.ControlViewWalker.GetParent(element);
            if ((left && prevSibling != null))
            {
                adjustment = (horizontal ? prevSibling.Current.BoundingRectangle.Right : prevSibling.Current.BoundingRectangle.Bottom);
            }
            else if (!left && nextSibling != null)
            {
                adjustment = (horizontal ? nextSibling.Current.BoundingRectangle.Left : nextSibling.Current.BoundingRectangle.Top);
            }
            else if (parent != null)
            {
                if (horizontal)
                {
                    adjustment = left ? parent.Current.BoundingRectangle.Left : parent.Current.BoundingRectangle.Right;
                }
                else
                {
                    adjustment = left ? parent.Current.BoundingRectangle.Top : parent.Current.BoundingRectangle.Bottom;
                }

            }

            return (int)adjustment;
        }

        private void setTaskbarStyle(TaskbarMode mode)
        {

            string tskBarClassName = "Shell_TrayWnd";
            IntPtr tskBarHwnd = Win32.FindWindow(tskBarClassName, null/* TODO Change to default(_) if this is not a reference type */);
            var accent = new Win32.AccentPolicy();
            var accentStructSize = Marshal.SizeOf(accent);

            switch (mode)
            {
                default:
                case TaskbarMode.Acrylic:
                    accent.AccentState = Win32.AccentState.ACCENT_ENABLE_ACRYLICBLURBEHIND;
                    accent.GradientColor = 10;
                    break;

                case TaskbarMode.Blur:
                    accent.AccentState = Win32.AccentState.ACCENT_ENABLE_BLURBEHIND;
                    break;

                case TaskbarMode.Transparent:
                    accent.AccentState = Win32.AccentState.ACCENT_ENABLE_TRANSPARANT;
                    break;

                case TaskbarMode.None:
                    accent.AccentState = Win32.AccentState.ACCENT_DISABLED;
                    break;
            }

            var accentPtr = Marshal.AllocHGlobal(accentStructSize);
            Marshal.StructureToPtr(accent, accentPtr, false);
            var data = new Win32.WindowCompositionAttributeData();
            data.Attribute = Win32.WindowCompositionAttribute.WCA_ACCENT_POLICY;
            data.SizeOfData = accentStructSize;
            data.Data = accentPtr;
            Win32.SetWindowCompositionAttribute(tskBarHwnd, ref data);
            Marshal.FreeHGlobal(accentPtr);

        }
    }

    public enum TaskbarMode
    {
        Acrylic,
        Blur,
        Transparent,
        None
    }
}
