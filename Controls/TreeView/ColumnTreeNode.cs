using SQlite.WF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQlite.WF.Controls
{
   internal class ColumnTreeNode : TreeNode
    {
        public ColumnTreeNode(SqlColumn c)
        {
            this.Text = c.ColumnName + " (" + c.Type;
            if (c.Size > 0)
                this.Text += "(" + c.Size + ")";


            if (c.AllowNull)
                this.Text += ", null";
            else
                this.Text += ", not null";

            if (c.IsPrimaryKey)
                this.Text += ", PK";
            
            this.Text += ")";
            
            //this.ImageIndex = 2;
        }
    }
}
