using SQlite.WF.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQlite.WF.Controls
{
    internal class EngineTreeNode : TreeNode
    {
        public SqlEngine Engine { get; set; }
        public EngineTreeNode(SqlEngine engine)
        {
            this.Text = Path.GetFileName(engine.FullDbName);
            this.Engine = engine;

            if (engine.IsPinned)
            {
                this.ImageIndex = 15;
                this.SelectedImageIndex = 15;
            }
            else
            {
                this.ImageIndex = 0;
                this.SelectedImageIndex = 0;
            }

            if(engine.IsConnected)
            {
                TreeNode tablesnode = new TreeNode("Tables");
                tablesnode.ImageIndex = 1;
                tablesnode.SelectedImageIndex = 1;
                foreach (SqlTable c in engine.Tables)
                {
                    tablesnode.Nodes.Add(new TableTreeNode(c) { ImageIndex = 7 , SelectedImageIndex = 7});
                }

                TreeNode viewNode = new TreeNode("Views");
                viewNode.ImageIndex = 2;
                viewNode.SelectedImageIndex = 2;
                foreach (SqlView v in engine.Views)
                {
                    viewNode.Nodes.Add(new ViewTreeNode(v) { ImageIndex = 8 , SelectedImageIndex = 8 });
                }

                this.Nodes.Add(tablesnode);
                this.Nodes.Add(viewNode);
            }
           
        }
    }
}
