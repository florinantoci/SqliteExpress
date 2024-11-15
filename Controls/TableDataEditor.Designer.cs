namespace SQlite.WF.Controls
{
    partial class TableDataEditor
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TableDataEditor));
            this.toolStripTableActions = new System.Windows.Forms.ToolStrip();
            this.dataGridViewTableData = new System.Windows.Forms.DataGridView();
            this.toolStripLabelName = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButtonEditRecord = new System.Windows.Forms.ToolStripButton();
            this.bindingSourceData = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigatorData = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.toolStripTableActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTableData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigatorData)).BeginInit();
            this.bindingNavigatorData.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripTableActions
            // 
            this.toolStripTableActions.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStripTableActions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabelName,
            this.toolStripButtonEditRecord});
            this.toolStripTableActions.Location = new System.Drawing.Point(0, 0);
            this.toolStripTableActions.Name = "toolStripTableActions";
            this.toolStripTableActions.Size = new System.Drawing.Size(2056, 71);
            this.toolStripTableActions.TabIndex = 0;
            this.toolStripTableActions.Text = "toolStrip1";
            this.toolStripTableActions.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // dataGridViewTableData
            // 
            this.dataGridViewTableData.AllowUserToAddRows = false;
            this.dataGridViewTableData.AllowUserToDeleteRows = false;
            this.dataGridViewTableData.AllowUserToResizeRows = false;
            this.dataGridViewTableData.AutoGenerateColumns = false;
            this.dataGridViewTableData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTableData.DataSource = this.bindingSourceData;
            this.dataGridViewTableData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewTableData.Location = new System.Drawing.Point(0, 71);
            this.dataGridViewTableData.Name = "dataGridViewTableData";
            this.dataGridViewTableData.RowTemplate.Height = 33;
            this.dataGridViewTableData.Size = new System.Drawing.Size(2056, 1093);
            this.dataGridViewTableData.TabIndex = 1;
            // 
            // toolStripLabelName
            // 
            this.toolStripLabelName.Name = "toolStripLabelName";
            this.toolStripLabelName.Size = new System.Drawing.Size(217, 68);
            this.toolStripLabelName.Text = "Edit table data for: ";
            // 
            // toolStripButtonEditRecord
            // 
            this.toolStripButtonEditRecord.Image = global::SQlite.WF.Properties.Resources.list_12;
            this.toolStripButtonEditRecord.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonEditRecord.Name = "toolStripButtonEditRecord";
            this.toolStripButtonEditRecord.Size = new System.Drawing.Size(134, 68);
            this.toolStripButtonEditRecord.Text = "Edit record";
            this.toolStripButtonEditRecord.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonEditRecord.Click += new System.EventHandler(this.toolStripButtonEditRecord_Click);
            // 
            // bindingNavigatorData
            // 
            this.bindingNavigatorData.AddNewItem = this.bindingNavigatorAddNewItem;
            this.bindingNavigatorData.BindingSource = this.bindingSourceData;
            this.bindingNavigatorData.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigatorData.DeleteItem = this.bindingNavigatorDeleteItem;
            this.bindingNavigatorData.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.bindingNavigatorData.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem});
            this.bindingNavigatorData.Location = new System.Drawing.Point(0, 71);
            this.bindingNavigatorData.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigatorData.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigatorData.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigatorData.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigatorData.Name = "bindingNavigatorData";
            this.bindingNavigatorData.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigatorData.Size = new System.Drawing.Size(2056, 39);
            this.bindingNavigatorData.TabIndex = 2;
            this.bindingNavigatorData.Text = "bindingNavigator1";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(36, 36);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(36, 36);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 39);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 39);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(71, 36);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(36, 36);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(36, 36);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 39);
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(36, 36);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(36, 36);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            // 
            // TableDataEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.bindingNavigatorData);
            this.Controls.Add(this.dataGridViewTableData);
            this.Controls.Add(this.toolStripTableActions);
            this.Name = "TableDataEditor";
            this.Size = new System.Drawing.Size(2056, 1164);
            this.toolStripTableActions.ResumeLayout(false);
            this.toolStripTableActions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTableData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigatorData)).EndInit();
            this.bindingNavigatorData.ResumeLayout(false);
            this.bindingNavigatorData.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStripTableActions;
        private System.Windows.Forms.DataGridView dataGridViewTableData;
        private System.Windows.Forms.ToolStripLabel toolStripLabelName;
        private System.Windows.Forms.ToolStripButton toolStripButtonEditRecord;
        private System.Windows.Forms.BindingSource bindingSourceData;
        private System.Windows.Forms.BindingNavigator bindingNavigatorData;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
    }
}
