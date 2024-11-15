using SQlite.WF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQlite.WF.Controls
{
    internal class TableTreeNode : TreeNode
    {
        public SqlTable Table { get; set; }
        public TableTreeNode(SqlTable table)
        {
            this.Text = table.TableName;
            this.Table = table;

            TreeNode columnsNode = new TreeNode("Columns");
            columnsNode.ImageIndex = 3;
            columnsNode.SelectedImageIndex = 3;
            foreach (SqlColumn c in table.TableColumns)
            {
                columnsNode.Nodes.Add(new ColumnTreeNode(c) { ImageIndex = 9, SelectedImageIndex = 9 });
            }

            TreeNode indexesNode = new TreeNode("Indexes");
            indexesNode.ImageIndex = 4;
            indexesNode.SelectedImageIndex = 4;
            foreach (SqlIndex index in table.Indexes)
            {
                indexesNode.Nodes.Add(new IndexTreeNode(index) { ImageIndex = 13, SelectedImageIndex = 13 });
            }

            TreeNode triggersNode = new TreeNode("Triggers");
            triggersNode.ImageIndex = 5;
            triggersNode.SelectedImageIndex = 5;
            foreach (SqlTrigger t in table.Triggers)
            {
                triggersNode.Nodes.Add(new TriggerTreeNode(t) { ImageIndex = 10, SelectedImageIndex = 10 });
            }

            TreeNode fkNode = new TreeNode("Relations");
            fkNode.ImageIndex = 6;
            fkNode.SelectedImageIndex = 6;
            foreach (SqlRelation rel in table.Relations)
            {
                fkNode.Nodes.Add(new RelationTreeNode(rel) { ImageIndex = 11, SelectedImageIndex = 11 });
            }

            //TreeNode constraintsNode = new TreeNode("Constraints");
            //constraintsNode.ImageIndex = 6;
            //constraintsNode.SelectedImageIndex = 6;
            //foreach (string constraint in table.Constraints)
            //{
            //    constraintsNode.Nodes.Add(new ConstraintTreeNode(constraint) { ImageIndex = 12, SelectedImageIndex = 12 });
            //}

            this.Nodes.Add(columnsNode);
            this.Nodes.Add(fkNode);
            //this.Nodes.Add(constraintsNode);
            this.Nodes.Add(indexesNode);
            this.Nodes.Add(triggersNode);
        }
    }
}
