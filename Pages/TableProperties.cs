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
    public partial class TableProperties : Form
    {
        public TableProperties(string dbName, string tableName, int nrRows)
        {
            InitializeComponent();

            tbDatabase.Text = dbName;
            tbName.Text = tableName;
            tbRecords.Text = nrRows > 0 ? nrRows.ToString() : "No records";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
