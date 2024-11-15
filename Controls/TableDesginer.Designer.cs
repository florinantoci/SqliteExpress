namespace SQlite.WF.Controls
{
    partial class TableDesginer
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.editorGroup = new System.Windows.Forms.GroupBox();
            this.tableColumnsDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTypeColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataGridViewAllowNull = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewPrecision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableColumnsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panelTop = new System.Windows.Forms.Panel();
            this.tbTableName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenuColumnEvents = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.setPrimaryKeyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removePrimaryKeyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteColumnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.queryToolbar = new System.Windows.Forms.ToolStrip();
            this.toolStripLabelCurrentDatabase = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonSave = new System.Windows.Forms.ToolStripButton();
            this.editorGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableColumnsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableColumnsBindingSource)).BeginInit();
            this.panelTop.SuspendLayout();
            this.contextMenuColumnEvents.SuspendLayout();
            this.queryToolbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // editorGroup
            // 
            this.editorGroup.Controls.Add(this.tableColumnsDataGridView);
            this.editorGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editorGroup.Location = new System.Drawing.Point(0, 133);
            this.editorGroup.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.editorGroup.Name = "editorGroup";
            this.editorGroup.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.editorGroup.Size = new System.Drawing.Size(1456, 1108);
            this.editorGroup.TabIndex = 3;
            this.editorGroup.TabStop = false;
            this.editorGroup.Text = "Fields";
            // 
            // tableColumnsDataGridView
            // 
            this.tableColumnsDataGridView.AutoGenerateColumns = false;
            this.tableColumnsDataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tableColumnsDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.tableColumnsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableColumnsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewColumnName,
            this.dataGridViewTypeColumn,
            this.dataGridViewAllowNull,
            this.dataGridViewSize,
            this.dataGridViewPrecision});
            this.tableColumnsDataGridView.DataSource = this.tableColumnsBindingSource;
            this.tableColumnsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableColumnsDataGridView.Location = new System.Drawing.Point(4, 29);
            this.tableColumnsDataGridView.Name = "tableColumnsDataGridView";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tableColumnsDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.tableColumnsDataGridView.RowTemplate.Height = 33;
            this.tableColumnsDataGridView.Size = new System.Drawing.Size(1448, 1074);
            this.tableColumnsDataGridView.TabIndex = 0;
            this.tableColumnsDataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.tableColumnsDataGridView_CellEndEdit);
            this.tableColumnsDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.tableColumnsDataGridView_DataError);
            this.tableColumnsDataGridView.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.tableColumnsDataGridView_RowPostPaint);
            this.tableColumnsDataGridView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tableColumnsDataGridView_MouseDown);
            // 
            // dataGridViewColumnName
            // 
            this.dataGridViewColumnName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewColumnName.DataPropertyName = "ColumnName";
            this.dataGridViewColumnName.HeaderText = "ColumnName";
            this.dataGridViewColumnName.MinimumWidth = 250;
            this.dataGridViewColumnName.Name = "dataGridViewColumnName";
            this.dataGridViewColumnName.Width = 250;
            // 
            // dataGridViewTypeColumn
            // 
            this.dataGridViewTypeColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTypeColumn.DataPropertyName = "Type";
            this.dataGridViewTypeColumn.HeaderText = "Type";
            this.dataGridViewTypeColumn.MinimumWidth = 180;
            this.dataGridViewTypeColumn.Name = "dataGridViewTypeColumn";
            this.dataGridViewTypeColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTypeColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTypeColumn.Width = 180;
            // 
            // dataGridViewAllowNull
            // 
            this.dataGridViewAllowNull.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewAllowNull.DataPropertyName = "AllowNull";
            this.dataGridViewAllowNull.HeaderText = "AllowNull";
            this.dataGridViewAllowNull.Name = "dataGridViewAllowNull";
            this.dataGridViewAllowNull.Width = 139;
            // 
            // dataGridViewSize
            // 
            this.dataGridViewSize.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewSize.DataPropertyName = "Size";
            this.dataGridViewSize.HeaderText = "Size";
            this.dataGridViewSize.Name = "dataGridViewSize";
            this.dataGridViewSize.Width = 109;
            // 
            // dataGridViewPrecision
            // 
            this.dataGridViewPrecision.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewPrecision.DataPropertyName = "Precision";
            this.dataGridViewPrecision.HeaderText = "Precision";
            this.dataGridViewPrecision.Name = "dataGridViewPrecision";
            this.dataGridViewPrecision.Width = 168;
            // 
            // tableColumnsBindingSource
            // 
            this.tableColumnsBindingSource.DataSource = typeof(SQlite.WF.Models.SqlColumn);
            // 
            // panelTop
            // 
            this.panelTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTop.Controls.Add(this.tbTableName);
            this.panelTop.Controls.Add(this.label1);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelTop.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.panelTop.Location = new System.Drawing.Point(0, 59);
            this.panelTop.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1456, 74);
            this.panelTop.TabIndex = 2;
            // 
            // tbTableName
            // 
            this.tbTableName.Location = new System.Drawing.Point(176, 19);
            this.tbTableName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbTableName.Name = "tbTableName";
            this.tbTableName.Size = new System.Drawing.Size(509, 39);
            this.tbTableName.TabIndex = 1;
            this.tbTableName.TextChanged += new System.EventHandler(this.tbTableName_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 19);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Table Name";
            // 
            // contextMenuColumnEvents
            // 
            this.contextMenuColumnEvents.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuColumnEvents.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setPrimaryKeyToolStripMenuItem,
            this.removePrimaryKeyToolStripMenuItem,
            this.deleteColumnToolStripMenuItem});
            this.contextMenuColumnEvents.Name = "contextMenuColumnEvents";
            this.contextMenuColumnEvents.Size = new System.Drawing.Size(310, 112);
            this.contextMenuColumnEvents.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuColumnEvents_Opening);
            // 
            // setPrimaryKeyToolStripMenuItem
            // 
            this.setPrimaryKeyToolStripMenuItem.Name = "setPrimaryKeyToolStripMenuItem";
            this.setPrimaryKeyToolStripMenuItem.Size = new System.Drawing.Size(309, 36);
            this.setPrimaryKeyToolStripMenuItem.Text = "Set Primary Key";
            this.setPrimaryKeyToolStripMenuItem.Click += new System.EventHandler(this.setPrimaryKeyToolStripMenuItem_Click);
            // 
            // removePrimaryKeyToolStripMenuItem
            // 
            this.removePrimaryKeyToolStripMenuItem.Name = "removePrimaryKeyToolStripMenuItem";
            this.removePrimaryKeyToolStripMenuItem.Size = new System.Drawing.Size(309, 36);
            this.removePrimaryKeyToolStripMenuItem.Text = "Remove Primary Key";
            this.removePrimaryKeyToolStripMenuItem.Click += new System.EventHandler(this.removePrimaryKeyToolStripMenuItem_Click);
            // 
            // deleteColumnToolStripMenuItem
            // 
            this.deleteColumnToolStripMenuItem.Name = "deleteColumnToolStripMenuItem";
            this.deleteColumnToolStripMenuItem.Size = new System.Drawing.Size(309, 36);
            this.deleteColumnToolStripMenuItem.Text = "Delete Column";
            this.deleteColumnToolStripMenuItem.Click += new System.EventHandler(this.deleteColumnToolStripMenuItem_Click);
            // 
            // queryToolbar
            // 
            this.queryToolbar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.queryToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabelCurrentDatabase,
            this.toolStripSeparator1,
            this.toolStripButtonSave});
            this.queryToolbar.Location = new System.Drawing.Point(0, 0);
            this.queryToolbar.Name = "queryToolbar";
            this.queryToolbar.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.queryToolbar.Size = new System.Drawing.Size(1456, 59);
            this.queryToolbar.TabIndex = 1;
            this.queryToolbar.Text = "toolStrip1";
            // 
            // toolStripLabelCurrentDatabase
            // 
            this.toolStripLabelCurrentDatabase.Name = "toolStripLabelCurrentDatabase";
            this.toolStripLabelCurrentDatabase.Size = new System.Drawing.Size(113, 56);
            this.toolStripLabelCurrentDatabase.Text = "Database";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 59);
            // 
            // toolStripButtonSave
            // 
            this.toolStripButtonSave.Image = global::SQlite.WF.Properties.Resources.save;
            this.toolStripButtonSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSave.Name = "toolStripButtonSave";
            this.toolStripButtonSave.Size = new System.Drawing.Size(69, 56);
            this.toolStripButtonSave.Text = "Save";
            this.toolStripButtonSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonSave.Click += new System.EventHandler(this.toolStripButtonSave_Click);
            // 
            // TableDesginer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.editorGroup);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.queryToolbar);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "TableDesginer";
            this.Size = new System.Drawing.Size(1456, 1241);
            this.editorGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tableColumnsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableColumnsBindingSource)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.contextMenuColumnEvents.ResumeLayout(false);
            this.queryToolbar.ResumeLayout(false);
            this.queryToolbar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.TextBox tbTableName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox editorGroup;
        private System.Windows.Forms.DataGridView tableColumnsDataGridView;
        private System.Windows.Forms.BindingSource tableColumnsBindingSource;
        private System.Windows.Forms.ContextMenuStrip contextMenuColumnEvents;
        private System.Windows.Forms.ToolStripMenuItem setPrimaryKeyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteColumnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removePrimaryKeyToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewColumnName;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewTypeColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewAllowNull;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewPrecision;
        private System.Windows.Forms.ToolStrip queryToolbar;
        private System.Windows.Forms.ToolStripLabel toolStripLabelCurrentDatabase;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButtonSave;
    }
}
