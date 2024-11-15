using SQlite.WF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQlite.WF.Controls
{
    internal class ConstraintTreeNode : TreeNode
    {
        public ConstraintTreeNode(string c)
        {
            this.Text = c;
        }
    }

    internal class RelationTreeNode : TreeNode
    {
        public SqlRelation Relation { get; set; }

        public RelationTreeNode(SqlRelation sqlRelation)
        {
            this.Text = sqlRelation.RefTableName + "(" + sqlRelation.ColumnName + ", Ref:" + sqlRelation.RefColumnName + ")";
            this.Relation = sqlRelation;
        }
    }
}
