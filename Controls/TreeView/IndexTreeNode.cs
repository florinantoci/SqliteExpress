using SQlite.WF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQlite.WF.Controls
{
    internal class IndexTreeNode : TreeNode
    {
        public SqlIndex Index { get; set; }

        public IndexTreeNode(SqlIndex index)
        {
            this.Text = index.IndexName;
            this.Index = index;
        }
    }
}
