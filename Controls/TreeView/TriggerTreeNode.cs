using SQlite.WF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQlite.WF.Controls
{
    internal class TriggerTreeNode : TreeNode 
    {
        public SqlTrigger Trigger { get; set; }
        public TriggerTreeNode(SqlTrigger t)
        {
            this.Text = t.TriggerName;
            this.Trigger = t;
        }
    }
}
