using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SQlite.WF.Models;

namespace SQlite.WF.Controls
{
    internal partial class TableDataEditor : Base.BaseControl
    {
        private SqlTable _table;
        public TableDataEditor(SqlTable table)
        {
            InitializeComponent();
            _table = table;


        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripButtonEditRecord_Click(object sender, EventArgs e)
        {

        }
    }
}
