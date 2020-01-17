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
            var b = new ChromiumWebBrowser(address);
            b.Parent = this;
            b.Show();
        }
    }
}
