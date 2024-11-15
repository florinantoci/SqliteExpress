using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQlite.WF.Pages
{
    public partial class AboutApp : Form
    {
        public AboutApp()
        {
            InitializeComponent();
        }

        private void AboutApp_Load(object sender, EventArgs e)
        {
            this.labelVersion.Text = String.Format("Version {0}", Assembly.GetExecutingAssembly().GetName().Version.ToString());
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/florinantoci/SqliteExpress");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/florinantoci/SqliteExpress");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.flaticon.com");
        }
    }
}
