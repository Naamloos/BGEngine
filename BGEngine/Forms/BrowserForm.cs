using CefSharp;
using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BGEngine.Forms
{
    public partial class BrowserForm : Form
    {
        public BrowserForm(string address)
        {
            InitializeComponent();

            BrowserSettings browserSettings = new BrowserSettings();
            browserSettings.FileAccessFromFileUrls = CefState.Enabled;
            browserSettings.UniversalAccessFromFileUrls = CefState.Enabled;
            browserSettings.TextAreaResize = CefState.Enabled;

            var b = new ChromiumWebBrowser(address);
            b.BrowserSettings = browserSettings;
            b.Parent = this;
            b.Show();
        }
    }
}
