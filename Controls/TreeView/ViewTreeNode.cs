using SQlite.WF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQlite.WF.Controls
{
    internal class ViewTreeNode : TreeNode
    {
        public SqlView View { get; set; }
        public ViewTreeNode(SqlView v)
        {
            this.Text = v.ViewName;
            this.View = v;
        }
    }
}
