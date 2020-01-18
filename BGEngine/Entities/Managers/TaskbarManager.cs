using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BGEngine.Entities.Managers
{
    public class TaskbarManager
    {
        public TaskbarManager()
        {

        }

        public void SetTaskbarStyle(TaskbarMode mode)
        {

            string tskBarClassName = "Shell_TrayWnd";
            IntPtr tskBarHwnd = Win32.FindWindow(tskBarClassName, null/* TODO Change to default(_) if this is not a reference type */);
            var accent = new Win32.AccentPolicy();
            var accentStructSize = Marshal.SizeOf(accent);

            switch(mode)
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
        Transparent
    }
}
