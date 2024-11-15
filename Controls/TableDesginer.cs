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
    internal partial class TableDesginer : Base.BaseControl
    {
        private SqlTable _table;
        public TableDesginer(SqlTable table, SqlEngine
             engine
            )
        {
            InitializeComponent();

            this.tbTableName.Text = table.TableName;
            this.dataGridViewTypeColumn.DataSource = Enum.GetValues(typeof(SqlTypeEnum));
            this.tableColumnsBindingSource.DataSource = table.TableColumns;
            this.ThrowContentChanged();
            _table = table;

            this.toolStripLabelCurrentDatabase.Text = engine.DbName;

        }

        public override void Save()
        {
            _table.TableName = this.tbTableName.Text;
            _table.TableColumns = (List<SqlColumn>)tableColumnsBindingSource.DataSource;
            _table.Save();
            base.Save();

            this.Title = "Edit Table" + _table.TableName; ;
            this.Parent.Text = "Edit Table" + _table.TableName;
            this.HasChanges = false;
        }

        private void tableColumnsDataGridView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.contextMenuColumnEvents.Show(this.tableColumnsDataGridView, new Point(e.X, e.Y));
            }
        }

        private void setPrimaryKeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in this.tableColumnsDataGridView.SelectedRows)
            {
                SqlColumn selectedColumn = (SqlColumn)row.DataBoundItem;
                if (!selectedColumn.IsPrimaryKey)
                {
                    _table.TableColumns.Where(a => a.ColumnName == selectedColumn.ColumnName).First().IsPrimaryKey = true;
                    tableColumnsDataGridView.Refresh();
                }
            }
            this.ThrowContentChanged();
        }

        private void removePrimaryKeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in this.tableColumnsDataGridView.SelectedRows)
            {
                SqlColumn selectedColumn = (SqlColumn)row.DataBoundItem;
                if (selectedColumn.IsPrimaryKey)
                {
                    _table.TableColumns.Where(a => a.ColumnName == selectedColumn.ColumnName).First().IsPrimaryKey = false;
                    tableColumnsDataGridView.Refresh();
                }
            }
            this.ThrowContentChanged();
        }

        private void deleteColumnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int rowToDelete = tableColumnsDataGridView.Rows.GetFirstRow(DataGridViewElementStates.Selected);
            tableColumnsDataGridView.Rows.RemoveAt(rowToDelete);
            tableColumnsDataGridView.Refresh();
            this.ThrowContentChanged();
        }

        private void tableColumnsDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            int x = 2;
        }

        private void contextMenuColumnEvents_Opening(object sender, CancelEventArgs e)
        {
            foreach (DataGridViewRow row in this.tableColumnsDataGridView.SelectedRows)
            {
                SqlColumn selectedColumn = (SqlColumn)row.DataBoundItem;
                if (selectedColumn.IsPrimaryKey)
                {
                    contextMenuColumnEvents.Items[0].Enabled = false;
                    contextMenuColumnEvents.Items[1].Enabled = true;
                }
                else
                {
                    contextMenuColumnEvents.Items[0].Enabled = true;
                    contextMenuColumnEvents.Items[1].Enabled = false;
                }
            }

        }

        private void tableColumnsDataGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {

            if (e.RowIndex < _table.TableColumns.Count && _table.TableColumns[e.RowIndex].IsPrimaryKey)
            {
                Graphics graphics = e.Graphics;

                //Set Image dimension - User's choice
                int iconHeight = 14;
                int iconWidth = 14;

                //Set x/y position - As the center of the RowHeaderCell
                int xPosition = e.RowBounds.X + (tableColumnsDataGridView.RowHeadersWidth / 2);
                int yPosition = e.RowBounds.Y +
                ((tableColumnsDataGridView.Rows[e.RowIndex].Height - iconHeight) / 2);


                Rectangle rectangle = new Rectangle(xPosition, yPosition, iconWidth, iconHeight);
                graphics.DrawImage(Properties.Resources.primary_key, rectangle);
            }
        }

        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.Save();
                MessageBox.Show(null, "Table was saved!", "Success", MessageBoxButtons.OK);
                //this.Title = "Edit Table" + _table.TableName; ;
                //this.Parent.Text = "Edit Table" + _table.TableName;
            }
            catch(Exception ex)
            {
                MessageBox.Show(null,"Error performing action : " + ex.Message, "Error",MessageBoxButtons.OK);
            }
        }

        private void tableColumnsDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            this.ThrowContentChanged();
        }

        private void tbTableName_TextChanged(object sender, EventArgs e)
        {
            this.ThrowContentChanged();
        }
    }
}
