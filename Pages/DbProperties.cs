using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQlite.WF.Pages
{
    public partial class DbProperties : Form
    {
        public DbProperties(string dbName, string creationDate, string modifDate, double length, string path)
        {
            InitializeComponent();
            tbSize.Text = length + " kB";
            tbName.Text = dbName;
            tbCreatDate.Text = creationDate;
            tbLastDate.Text = modifDate;
            tbFullPath.Text = path;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
