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
    internal partial class RenameControl : Base.BaseControl
    {
        SqlTable _table;
        public RenameControl(SqlTable table)
        {
            InitializeComponent();
            _table = table;
            tbTableName.Text = _table.TableName;
        }

        public override void Save()
        {
            _table.TableName = tbTableName.Text;
            _table.Save();
            base.Save();
        }
    }
}
