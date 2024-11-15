using SQlite.WF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQlite.WF.Controls.TreeView
{
    internal class SqlTreeView: System.Windows.Forms.TreeView
    {
        public SqlEngine CurrentEngine { get; set; }
        public event EventHandler CurrentEngineChanged;
        public void RefreshData(List<SqlEngine> engines)
        {
            this.RefreshData(engines, null);
        }
        public void RefreshData(List<SqlEngine> engines, SqlEngine selectedEngine)
        {
            this.Nodes.Clear();
            foreach (var e in engines)
            {
                e.LoadTables();

                var node = new EngineTreeNode(e);
                this.Nodes.Add(node);
                if (e == selectedEngine)
                    this.SelectedNode = node;
            }
          
        }
        protected override void OnAfterSelect(TreeViewEventArgs e)
        {
            base.OnAfterSelect(e);
            var node = e.Node;
            while (node.Parent != null)
            {
                node = node.Parent;
            }
            if (node.GetType() == typeof(EngineTreeNode))
            {
                CurrentEngine = ((EngineTreeNode)node).Engine;
                this.CurrentEngineChanged?.Invoke(this, new EventArgs());
            }
        }
    }
}
