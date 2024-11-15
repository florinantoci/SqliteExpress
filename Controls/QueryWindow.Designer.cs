namespace SQlite.WF.Controls
{
    partial class QueryWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QueryWindow));
            this.queryToolbar = new System.Windows.Forms.ToolStrip();
            this.runBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabelCurrentDatabase = new System.Windows.Forms.ToolStripLabel();
            this.queryWinSplitter = new System.Windows.Forms.SplitContainer();
            this.queryText = new System.Windows.Forms.RichTextBox();
            this.queryWinTabs = new System.Windows.Forms.TabControl();
            this.DataTab = new System.Windows.Forms.TabPage();
            this.resultDataView = new System.Windows.Forms.DataGridView();
            this.MessagesTab = new System.Windows.Forms.TabPage();
            this.StatusText = new System.Windows.Forms.Label();
            this.queryToolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.queryWinSplitter)).BeginInit();
            this.queryWinSplitter.Panel1.SuspendLayout();
            this.queryWinSplitter.Panel2.SuspendLayout();
            this.queryWinSplitter.SuspendLayout();
            this.queryWinTabs.SuspendLayout();
            this.DataTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resultDataView)).BeginInit();
            this.MessagesTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // queryToolbar
            // 
            this.queryToolbar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.queryToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.runBtn,
            this.toolStripSeparator1,
            this.toolStripButton1,
            this.toolStripButtonSave,
            this.toolStripSeparator2,
            this.toolStripLabelCurrentDatabase});
            this.queryToolbar.Location = new System.Drawing.Point(0, 0);
            this.queryToolbar.Name = "queryToolbar";
            this.queryToolbar.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.queryToolbar.Size = new System.Drawing.Size(964, 59);
            this.queryToolbar.TabIndex = 0;
            this.queryToolbar.Text = "toolStrip1";
            // 
            // runBtn
            // 
            this.runBtn.Image = ((System.Drawing.Image)(resources.GetObject("runBtn.Image")));
            this.runBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.runBtn.Name = "runBtn";
            this.runBtn.Size = new System.Drawing.Size(61, 56);
            this.runBtn.Text = "Run";
            this.runBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.runBtn.Click += new System.EventHandler(this.runBtn_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 59);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = global::SQlite.WF.Properties.Resources.save;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(69, 56);
            this.toolStripButton1.Text = "Save";
            this.toolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButtonSave
            // 
            this.toolStripButtonSave.Image = global::SQlite.WF.Properties.Resources.save;
            this.toolStripButtonSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSave.Name = "toolStripButtonSave";
            this.toolStripButtonSave.Size = new System.Drawing.Size(98, 56);
            this.toolStripButtonSave.Text = "Save as";
            this.toolStripButtonSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonSave.Click += new System.EventHandler(this.toolStripButtonSave_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 59);
            // 
            // toolStripLabelCurrentDatabase
            // 
            this.toolStripLabelCurrentDatabase.Name = "toolStripLabelCurrentDatabase";
            this.toolStripLabelCurrentDatabase.Size = new System.Drawing.Size(113, 56);
            this.toolStripLabelCurrentDatabase.Text = "Database";
            // 
            // queryWinSplitter
            // 
            this.queryWinSplitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.queryWinSplitter.Location = new System.Drawing.Point(0, 59);
            this.queryWinSplitter.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.queryWinSplitter.Name = "queryWinSplitter";
            this.queryWinSplitter.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // queryWinSplitter.Panel1
            // 
            this.queryWinSplitter.Panel1.Controls.Add(this.queryText);
            // 
            // queryWinSplitter.Panel2
            // 
            this.queryWinSplitter.Panel2.Controls.Add(this.queryWinTabs);
            this.queryWinSplitter.Size = new System.Drawing.Size(964, 711);
            this.queryWinSplitter.SplitterDistance = 266;
            this.queryWinSplitter.SplitterWidth = 6;
            this.queryWinSplitter.TabIndex = 1;
            // 
            // queryText
            // 
            this.queryText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.queryText.Font = new System.Drawing.Font("Consolas", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.queryText.Location = new System.Drawing.Point(0, 0);
            this.queryText.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.queryText.Name = "queryText";
            this.queryText.Size = new System.Drawing.Size(964, 266);
            this.queryText.TabIndex = 0;
            this.queryText.Text = "";
            this.queryText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.query_KeyDown);
            // 
            // queryWinTabs
            // 
            this.queryWinTabs.Controls.Add(this.DataTab);
            this.queryWinTabs.Controls.Add(this.MessagesTab);
            this.queryWinTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.queryWinTabs.Location = new System.Drawing.Point(0, 0);
            this.queryWinTabs.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.queryWinTabs.Name = "queryWinTabs";
            this.queryWinTabs.SelectedIndex = 0;
            this.queryWinTabs.Size = new System.Drawing.Size(964, 439);
            this.queryWinTabs.TabIndex = 0;
            // 
            // DataTab
            // 
            this.DataTab.Controls.Add(this.resultDataView);
            this.DataTab.Location = new System.Drawing.Point(8, 39);
            this.DataTab.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DataTab.Name = "DataTab";
            this.DataTab.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DataTab.Size = new System.Drawing.Size(948, 392);
            this.DataTab.TabIndex = 0;
            this.DataTab.Text = "Data";
            this.DataTab.UseVisualStyleBackColor = true;
            // 
            // resultDataView
            // 
            this.resultDataView.AllowUserToAddRows = false;
            this.resultDataView.AllowUserToDeleteRows = false;
            this.resultDataView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.resultDataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resultDataView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultDataView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.resultDataView.GridColor = System.Drawing.SystemColors.ControlLight;
            this.resultDataView.Location = new System.Drawing.Point(4, 5);
            this.resultDataView.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.resultDataView.Name = "resultDataView";
            this.resultDataView.ReadOnly = true;
            this.resultDataView.RowTemplate.Height = 24;
            this.resultDataView.Size = new System.Drawing.Size(940, 382);
            this.resultDataView.TabIndex = 0;
            this.resultDataView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.resultDataView_CellContentClick);
            this.resultDataView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.resultDataView_CellFormatting);
            // 
            // MessagesTab
            // 
            this.MessagesTab.Controls.Add(this.StatusText);
            this.MessagesTab.Location = new System.Drawing.Point(8, 39);
            this.MessagesTab.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MessagesTab.Name = "MessagesTab";
            this.MessagesTab.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MessagesTab.Size = new System.Drawing.Size(948, 392);
            this.MessagesTab.TabIndex = 1;
            this.MessagesTab.Text = "Messages";
            this.MessagesTab.UseVisualStyleBackColor = true;
            // 
            // StatusText
            // 
            this.StatusText.AutoSize = true;
            this.StatusText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StatusText.Location = new System.Drawing.Point(4, 5);
            this.StatusText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.StatusText.Name = "StatusText";
            this.StatusText.Size = new System.Drawing.Size(0, 25);
            this.StatusText.TabIndex = 0;
            // 
            // QueryWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.queryWinSplitter);
            this.Controls.Add(this.queryToolbar);
            this.Name = "QueryWindow";
            this.Size = new System.Drawing.Size(964, 770);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.query_KeyDown);
            this.queryToolbar.ResumeLayout(false);
            this.queryToolbar.PerformLayout();
            this.queryWinSplitter.Panel1.ResumeLayout(false);
            this.queryWinSplitter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.queryWinSplitter)).EndInit();
            this.queryWinSplitter.ResumeLayout(false);
            this.queryWinTabs.ResumeLayout(false);
            this.DataTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.resultDataView)).EndInit();
            this.MessagesTab.ResumeLayout(false);
            this.MessagesTab.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip queryToolbar;
        private System.Windows.Forms.SplitContainer queryWinSplitter;
        private System.Windows.Forms.RichTextBox queryText;
        private System.Windows.Forms.TabControl queryWinTabs;
        private System.Windows.Forms.TabPage DataTab;
        private System.Windows.Forms.TabPage MessagesTab;
        private System.Windows.Forms.ToolStripButton runBtn;
        private System.Windows.Forms.Label StatusText;
        private System.Windows.Forms.DataGridView resultDataView;
        private System.Windows.Forms.ToolStripLabel toolStripLabelCurrentDatabase;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButtonSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}
