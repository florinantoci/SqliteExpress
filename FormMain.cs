using SQlite.WF.Controls;
using SQlite.WF.Controls.Base;
using SQlite.WF.Models;
using SQlite.WF.Pages;
using SQlite.WF.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQlite.WF
{
    public partial class FormMain : Form
    {
        private List<SqlEngine> _engines;
        private SqlEngine _currentEngine;
        private static int nrOfQueries = 1;
        private static int nrOfTables = 1;
        private TreeNode nodeclicked;

        private BindingList<SqlLogItem> _logItems = new BindingList<SqlLogItem>();

        public FormMain()
        {

            InitializeComponent();
            _engines = new List<SqlEngine>();
            this.sqlTreeView.CurrentEngineChanged += SqlTreeView_CurrentEngineChanged;
            this.sqlTreeView.MouseDown += SqlTreeView_MouseDown;

            this.sqlTreeView.ImageList = imageListForTreeView;
            this.Text += " version: " + System.Windows.Forms.Application.ProductVersion;


            if (string.IsNullOrEmpty(Settings.Default.InstanceId))
            {
                Settings.Default.InstanceId = Guid.NewGuid().ToString();
                Settings.Default.Save();

            }
            if (Settings.Default.PinnedDb == null)
            {
                Settings.Default.PinnedDb = new List<string>();
            }
            else
            {
                // Show db 
                foreach (string dbPath in Settings.Default.PinnedDb)
                {
                    if (System.IO.File.Exists(dbPath))
                    {
                        var eng = new SqlEngine(dbPath) { IsPinned = true, IsConnected = false };
                        eng.QueryExecuted += _currentEngine_QueryExecuted;
                        _engines.Add(eng);
                    }
                    refreshData();
                }
            }
   

            sqlLogItemBindingSource.DataSource = this._logItems;
            foreach (DataGridViewColumn c in sqlLogItemDataGridView.Columns)
            {
                c.DefaultCellStyle.Font = new Font("Arial", 10F, GraphicsUnit.Pixel);
            }
          
        }

        private void SqlTreeView_MouseDown(object sender, MouseEventArgs e)
        {
            nodeclicked = this.sqlTreeView.GetNodeAt(e.X, e.Y);

            if (nodeclicked != null)
            {
                if (e.Button == MouseButtons.Right)
                {
                    this.sqlTreeView.SelectedNode = nodeclicked;

                    Type currentType = this.sqlTreeView.SelectedNode.GetType();

                    if (this.sqlTreeView.SelectedNode.Text == "Tables")
                    {
                        this.contextMenuStripAllTables.Show(this.sqlTreeView, new Point(e.X, e.Y));
                    }
                    else if (this.sqlTreeView.SelectedNode.Text == "Relations" || this.sqlTreeView.SelectedNode.Text == "Views" || this.sqlTreeView.SelectedNode.Text == "Indexes" || this.sqlTreeView.SelectedNode.Text == "Triggers")
                    {
                        this.contextMenuStripAddElement.Show(this.sqlTreeView, new Point(e.X, e.Y));
                    }
                    else if (currentType == typeof(IndexTreeNode))
                    {
                        this.contextMenuStripEditElement.Show(this.sqlTreeView, new Point(e.X, e.Y));
                    }
                    else if (currentType == typeof(TriggerTreeNode))
                    {
                        this.contextMenuStripEditElement.Show(this.sqlTreeView, new Point(e.X, e.Y));
                        _currentEngine.SelectedTrigger = ((TriggerTreeNode)nodeclicked).Trigger;

                        //
                        _currentEngine.SelectedIndex = null;
                        _currentEngine.SelectedRelation = null;
                    }
                    else if (currentType == typeof(RelationTreeNode))
                    {
                        this.contextMenuStripEditElement.Show(this.sqlTreeView, new Point(e.X, e.Y));
                        _currentEngine.SelectedRelation = ((RelationTreeNode)nodeclicked).Relation;
                        _currentEngine.SelectedTable = ((TableTreeNode)nodeclicked.Parent.Parent).Table;
                        //
                        _currentEngine.SelectedIndex = null;
                        _currentEngine.SelectedTrigger = null;
                    }
                    else if (currentType == typeof(TableTreeNode))
                    {
                        this.contextMenuStripTable.Show(this.sqlTreeView, new Point(e.X, e.Y));
                        _currentEngine.SelectedTable = ((TableTreeNode)nodeclicked).Table;
                    }
                    else if (currentType == typeof(EngineTreeNode))
                    {
                        this.contextMenuStripDB.Show(this.sqlTreeView, new Point(e.X, e.Y));
                    }
                    else if (currentType == typeof(ViewTreeNode))
                    {
                        this.contextMenuStripView.Show(this.sqlTreeView, new Point(e.X, e.Y));
                        _currentEngine.SelectedView = ((ViewTreeNode)nodeclicked).View;
                    }
                }
            }
        }

        private void SqlTreeView_CurrentEngineChanged(object sender, EventArgs e)
        {
            //aici facem ceva cu ala schimbat
            _currentEngine = this.sqlTreeView.CurrentEngine;
        }

        #region Database Functions

        private void refreshData()
        {
            var savedExpansionState = this.sqlTreeView.Nodes.GetExpansionState();

            this.sqlTreeView.BeginUpdate();
            this.sqlTreeView.RefreshData(this._engines, this._currentEngine);

            this.sqlTreeView.Nodes.SetExpansionState(savedExpansionState);


            this.sqlTreeView.EndUpdate();

            if (this.sqlTreeView.SelectedNode != null)
                this.sqlTreeView.SelectedNode.EnsureVisible();

        }

        private void openDatabase_Click(object sender, EventArgs e)
        {
            openDataBaseDialog.Filter = "db files (*.db)|*.db";
            openDataBaseDialog.Title = "Please select an db file.";
            openDataBaseDialog.FileName = "";
            openDataBaseDialog.ShowDialog();

            string filename = openDataBaseDialog.FileName;
            if (System.IO.File.Exists(filename))
            {
                if (_engines.Where(a => a.FullDbName == filename).Count() == 0)
                {
                    //new engine 
                    _engines.Add(new SqlEngine(filename));
                    _currentEngine = _engines[_engines.Count - 1];
                    _currentEngine.IsConnected = true;
                    _currentEngine.QueryExecuted += _currentEngine_QueryExecuted;
                }
                else
                {
                    _currentEngine = _engines.Where(a => a.FullDbName == filename).First();
                    _currentEngine.IsConnected = true;
                }
            }

            refreshData();
        }

        private void sampleDatabase_Click(object sender, EventArgs e)
        {
            PopupForm popup = new PopupForm();
            popup.ShowDialog();

            if (!string.IsNullOrEmpty(popup.samplePath))
            {
                string resourceName = "SQlite.WF.Resources.SQLiteExpress_SampleDB.db";
                string filename = popup.samplePath;

                using (Stream resource = GetType().Assembly.GetManifestResourceStream(resourceName))
                {
                    if (resource == null)
                    {
                        throw new ArgumentException("No such resource", "resourceName");
                    }
                    try
                    {
                        using (Stream output = File.OpenWrite(filename))
                        {
                            resource.CopyTo(output);
                        }

                        _engines.Add(new SqlEngine(filename));
                        _currentEngine = _engines[_engines.Count - 1];
                        _currentEngine.IsConnected = true;
                        _currentEngine.QueryExecuted += _currentEngine_QueryExecuted;
                        refreshData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("The file path is not valid. Please try again.");
                    }

                }
            }

        }

        private void _currentEngine_QueryExecuted(object sender, string e)
        {
            this._logItems.Add(new SqlLogItem()
            {
                ExecutedOnEngine = (SqlEngine)sender,
                LogTime = DateTime.Now,
                Query = e
            });
            sqlLogItemBindingSource.DataSource = this._logItems;
        }

        private void createDatabase_Click(object sender, EventArgs e)
        {
            saveNewDatabaseDialog.Title = "Select location for new database";
            saveNewDatabaseDialog.FileName = "New_database";
            saveNewDatabaseDialog.DefaultExt = ".db";
            saveNewDatabaseDialog.AddExtension = true;
            saveNewDatabaseDialog.Filter = "SQLite Database (*.db)|*.db";
            if (saveNewDatabaseDialog.ShowDialog() == DialogResult.OK)
            {
                string filename = saveNewDatabaseDialog.FileName;

                FileInfo f = new FileInfo(filename);
                var fs = f.Create();
                fs.Dispose();

                //new engine 
                var eng = new SqlEngine(f.FullName) { IsConnected = true };
                eng.QueryExecuted += _currentEngine_QueryExecuted;
                _engines.Add(eng);

                refreshData();
            }

        }

        private void AddTabControl(BaseControl t)
        {

            BaseTabPage newTab = new BaseTabPage();
            newTab.AddControl(t);
            tabControlPages.TabPages.Add(newTab);
            tabControlPages.SelectTab(newTab);
        }

        private void refreshToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            refreshData();
        }

        private void contextMenuStripDB_Opening(object sender, CancelEventArgs e)
        {
            if (_currentEngine.IsPinned)
            {
                contextMenuStripDB.Items["pinDatabaseToolStripMenuItem"].Enabled = false;
                contextMenuStripDB.Items["unpinDatabaseToolStripMenuItem"].Enabled = true;
            }
            else
            {
                contextMenuStripDB.Items["pinDatabaseToolStripMenuItem"].Enabled = true;
                contextMenuStripDB.Items["unpinDatabaseToolStripMenuItem"].Enabled = false;
            }

            if (_currentEngine.IsConnected)
            {
                contextMenuStripDB.Items["connectToolStripMenuItem"].Enabled = false;
                contextMenuStripDB.Items["disconnectToolStripMenuItem"].Enabled = true;
            }
            else
            {
                contextMenuStripDB.Items["connectToolStripMenuItem"].Enabled = true;
                contextMenuStripDB.Items["disconnectToolStripMenuItem"].Enabled = false;
            }
        }

        private void pinDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.Default.PinnedDb.Add(_currentEngine.FullDbName);
            Settings.Default.Save();
            _currentEngine.IsPinned = true;
        }

        private void unpinDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.Default.PinnedDb.Remove(_currentEngine.FullDbName);
            Settings.Default.Save();
            _currentEngine.IsPinned = false;
            if (!_currentEngine.IsConnected)
            {
                _engines.Remove(_currentEngine);
            }
            refreshData();
        }

        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _engines.Where(a => a.FullDbName == _currentEngine.FullDbName).First().IsConnected = true;
            refreshData();
        }

        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _engines.Where(a => a.FullDbName == _currentEngine.FullDbName).First().IsConnected = false;
            if (_engines.Where(a => a.FullDbName == _currentEngine.FullDbName).First().IsPinned == false)
            {
                _engines.Remove(_currentEngine);
            }
            refreshData();
        }

        private void copyDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveNewDatabaseDialog.Title = "Select location for database copy";
            saveNewDatabaseDialog.FileName = Path.GetFileNameWithoutExtension(_currentEngine.FullDbName) + "_Copy";
            saveNewDatabaseDialog.DefaultExt = ".db";
            saveNewDatabaseDialog.AddExtension = true;
            saveNewDatabaseDialog.Filter = "SQLite Database (*.db)|*.db";

            if (saveNewDatabaseDialog.ShowDialog() == DialogResult.OK)
            {
                string newFileName = saveNewDatabaseDialog.FileName;
                File.Copy(_currentEngine.FullDbName, newFileName);


                var eng = new SqlEngine(newFileName) { IsConnected = true };
                eng.QueryExecuted += _currentEngine_QueryExecuted;
                _engines.Add(eng);

                refreshData();
            }
        }

        private void createBackupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveNewDatabaseDialog.Title = "Select location for database backup";
            saveNewDatabaseDialog.FileName = Path.GetFileNameWithoutExtension(_currentEngine.FullDbName) + "_Backup";
            saveNewDatabaseDialog.DefaultExt = ".db";
            saveNewDatabaseDialog.AddExtension = true;
            saveNewDatabaseDialog.Filter = "SQLite Database (*.db)|*.db";

            if (saveNewDatabaseDialog.ShowDialog() == DialogResult.OK)
            {
                string newFileName = saveNewDatabaseDialog.FileName;
                File.Copy(_currentEngine.FullDbName, newFileName);

                _currentEngine.QueryExecuted += _currentEngine_QueryExecuted;

                refreshData();
            }
        }

        private void openFileLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var directoryPath = Path.GetDirectoryName(_currentEngine.FullDbName);
            // opens the folder in explorer
            Process.Start(directoryPath);
        }

        private void propertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Path.get
            string name = Path.GetFileNameWithoutExtension(_currentEngine.FullDbName);
            string creationDate = File.GetCreationTime(_currentEngine.FullDbName).ToString();
            double length = Math.Round((double)new FileInfo(_currentEngine.FullDbName).Length / 1000, 1);
            string fullPath = _currentEngine.FullDbName;
            string lastModifiedDate = File.GetLastWriteTime(_currentEngine.FullDbName).ToString();

            DbProperties prop = new DbProperties(name, creationDate, lastModifiedDate, length, fullPath);
            prop.ShowDialog();
        }
        #endregion

        #region Query Functions
        private void newQuery_Click(object sender, EventArgs e)
        {
            createNewQuery("");
        }

        private QueryWindow createNewQuery(string qName)
        {

            QueryWindow newQuery = new QueryWindow(_currentEngine);
            if (string.IsNullOrEmpty(qName))
            {
                newQuery.Title = "Query " + (nrOfQueries++);//+ Path.GetFileName(_currentEngine.DbName)
            }
            else
            {
                newQuery.Title = qName;
                // nrOfQueries++;
            }

            AddTabControl(newQuery);

            return newQuery;

        }
        #endregion

        #region Table Functions


        private void renameTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_currentEngine != null && _currentEngine.SelectedTable != null)
            {
                new RenameControl(_currentEngine.SelectedTable).ShowInDialog();
            }
            refreshData();
        }

        private TableDesginer addTable(SqlTable table)
        {
            TableDesginer newTable = new TableDesginer(table, _currentEngine);
            newTable.Title = "Edit Table" + table.TableName;
            newTable.HasChanges = false;
            AddTabControl(newTable);
            return newTable;
        }

        private void addNewTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_currentEngine != null)
            {
                SqlTable sqlTable = new SqlTable(_currentEngine);
                sqlTable.TableName = "Table" + (nrOfTables++);
                addTable(sqlTable);
            }
        }

        private TableDesginer editTableStructure(SqlTable table)
        {
            TableDesginer newTable = new TableDesginer(table, _currentEngine);
            newTable.Title = "Edit Table" + table.TableName;
            newTable.HasChanges = false;
            AddTabControl(newTable);
            return newTable;
        }

        private void editTableStructureMenuItem_Click(object sender, EventArgs e)
        {
            if (_currentEngine != null && _currentEngine.SelectedTable != null)
            {
                editTableStructure(_currentEngine.SelectedTable);
            }
        }

        private void selectTop100RecordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_currentEngine != null && _currentEngine.SelectedTable != null)
            {
                var q = createNewQuery("");
                q.SetCommandText(string.Format("select * from {0} limit 100", _currentEngine.SelectedTable.TableName));
                q.ExecuteCommand();
            }
        }

        private void dropTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_currentEngine != null && _currentEngine.SelectedTable != null)
            {
                if (MessageBox.Show("Are you sure you want to drop this table", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    _currentEngine.DropTable(_currentEngine.SelectedTable);
                    refreshData();
                }
            }
        }

        private void editTOP100RecordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_currentEngine != null && _currentEngine.SelectedTable != null)
            {
                //TODO
                //var q = createNewQuery();
                //q.SetCommandText(string.Format("select * from {0} limit 100", _currentEngine.SelectedTable.TableName));
                //q.ExecuteCommand();
            }
        }

        private void addNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (nodeclicked.Text == "Views")
            {
                var q = createNewQuery("");
                q.SetCommandText("CREATE VIEW view_name AS\nSELECT column1, column2, ...\nFROM table_name\nWHERE condition; ");
            }
            else if (nodeclicked.Text == "Indexes")
            {
                var q = createNewQuery("");
                q.SetCommandText("CREATE INDEX index_name \nON table_name(column1, column2, ...); ");
            }
            else if (nodeclicked.Text == "Relations")
            {
                var q = createNewQuery("");
                q.SetCommandText("FOREIGN KEY (colName) REFERENCES tablename(colName)");
            }
            else if (nodeclicked.Text == "Triggers")
            {
                var q = createNewQuery("");
                q.SetCommandText(" CREATE TRIGGER[IF NOT EXISTS] trigger_name \n [BEFORE | AFTER | INSTEAD OF][INSERT | UPDATE | DELETE] \n ON table_name\n [WHEN condition]\nBEGIN\nstatements;\n END; ");
            }
        }

        private void exportTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Text.StringBuilder sb = new StringBuilder();
            List<string> colList = new List<string>();
            foreach (var col in _currentEngine.SelectedTable.TableColumns)
            {
                colList.Add(col.ColumnName);
            }
            sb.AppendLine(String.Join(",", colList));

            // execute a select
            SqlQuery q = new SqlQuery();
            q.QueryCommand = "select * from " + _currentEngine.SelectedTable.TableName;
            _currentEngine.ExecuteQuery(q);
            if (q.QueryResult.ResultData != null && q.QueryResult.ResultData.Columns.Count > 0)
            {
                DataTable dt = q.QueryResult.ResultData;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    sb.AppendLine(String.Join(",", dt.Rows[i].ItemArray));
                }

                StreamWriter writer = null;
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.FileName = "ExportDb";
                saveFileDialog.Filter = "CSV|*.csv";
                saveFileDialog.Title = "Save CSV file";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    writer = new StreamWriter(saveFileDialog.FileName);
                    writer.Write(sb);
                    writer.Close();
                }
            }
        }

        private void refreshStripMenuItem_Click(object sender, EventArgs e)
        {
            refreshData();
        }


        // edit, delete for index, trigger and relation
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_currentEngine != null)
            {
                if (_currentEngine.SelectedIndex != null)
                {
                    var q = createNewQuery("");
                    q.SetCommandText(_currentEngine.SelectedIndex.GetScript(_currentEngine.SelectedTable.TableName));
                }
                else if (_currentEngine.SelectedTrigger != null)
                {
                    var q = createNewQuery("");
                    q.SetCommandText(_currentEngine.SelectedTrigger.GetScript());
                }
                else if (_currentEngine.SelectedRelation != null)
                {

                }
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_currentEngine != null)
            {
                if (_currentEngine.SelectedIndex != null)
                {
                    if (MessageBox.Show("Are you sure you want to drop this index", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        _currentEngine.DropIndex(_currentEngine.SelectedIndex);
                        refreshData();
                    }
                }
                else if (_currentEngine.SelectedTrigger != null)
                {
                    if (MessageBox.Show("Are you sure you want to drop this trigger", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        _currentEngine.DropTrigger(_currentEngine.SelectedTrigger);
                        refreshData();
                    }
                }
                else if (_currentEngine.SelectedRelation != null)
                {
                    if (MessageBox.Show("Are you sure you want to drop this relation", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        _currentEngine.DropRelation(_currentEngine.SelectedRelation);
                        refreshData();
                    }
                }
            }
        }

        private void propStripMenuItem_Click(object sender, EventArgs e)
        {

            if (_currentEngine != null && _currentEngine.SelectedTable != null)
            {
                string dbName = Path.GetFileNameWithoutExtension(_currentEngine.FullDbName);
                string tablename = _currentEngine.SelectedTable.TableName;
                int nrRows = 0;
                SqlQuery q = new SqlQuery();
                q.QueryCommand = "select count(*) from " + _currentEngine.SelectedTable.TableName;
                _currentEngine.ExecuteQuery(q);
                if (q.QueryResult.ResultData != null)
                {
                    DataTable dt = q.QueryResult.ResultData;
                    nrRows = Convert.ToInt32(dt.Rows[0].ItemArray[0].ToString());
                }
                TableProperties prop = new TableProperties(dbName, tablename, nrRows);
                prop.ShowDialog();
            }


            //DbProperties prop = new DbProperties(name, creationDate, lastModifiedDate, length, fullPath);
            //prop.ShowDialog();
        }


        #region Generate Script functions

        private void selectTOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_currentEngine != null && _currentEngine.SelectedTable != null)
            {
                var q = createNewQuery("");
                string cmd = "select ";
                foreach (SqlColumn column in _currentEngine.SelectedTable.TableColumns.OrderBy(a => a.ColumnName).ToList())
                {
                    cmd += "[" + column.ColumnName + "],\n";
                }
                cmd = cmd.Remove(cmd.Length - 2);
                cmd += " from {0}";
                q.SetCommandText(string.Format(cmd, _currentEngine.SelectedTable.TableName));
                //q.ExecuteCommand();
            }
        }

        private void insertINTOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_currentEngine != null && _currentEngine.SelectedTable != null)
            {
                var q = createNewQuery("");
                string cmd = "INSERT INTO {0} \n (";
                foreach (SqlColumn column in _currentEngine.SelectedTable.TableColumns.OrderBy(a => a.ColumnName).ToList())
                {
                    cmd += "[" + column.ColumnName + "], \n";
                }
                cmd = cmd.Remove(cmd.Length - 2);
                cmd += ")\n VALUES \n(";
                foreach (SqlColumn column in _currentEngine.SelectedTable.TableColumns.OrderBy(a => a.ColumnName).ToList())
                {
                    cmd += "<" + column.ColumnName + ", " + column.Type + ">,\n";
                }
                cmd = cmd.Remove(cmd.Length - 2);
                cmd += ")";
                q.SetCommandText(string.Format(cmd, _currentEngine.SelectedTable.TableName));
            }
        }

        private void uPDATEToToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_currentEngine != null && _currentEngine.SelectedTable != null)
            {
                var q = createNewQuery("");
                string cmd = "UPDATE {0} \n SET ";
                foreach (SqlColumn column in _currentEngine.SelectedTable.TableColumns.OrderBy(a => a.ColumnName).ToList())
                {
                    cmd += "[" + column.ColumnName + "] = <" + column.ColumnName + ", " + column.Type + ">,\n";
                }
                cmd = cmd.Remove(cmd.Length - 2);
                cmd += "\nWHERE <Search Conditions,,>";
                q.SetCommandText(string.Format(cmd, _currentEngine.SelectedTable.TableName));
            }
        }

        private void dELETEToToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_currentEngine != null && _currentEngine.SelectedTable != null)
            {
                var q = createNewQuery("");
                string cmd = "DELETE FROM {0} \n WHERE <Search Conditions,,>";
                q.SetCommandText(string.Format(cmd, _currentEngine.SelectedTable.TableName));
            }
        }

        private void dROPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_currentEngine != null && _currentEngine.SelectedTable != null)
            {
                var q = createNewQuery("");
                string cmd = "DROP TABLE {0}";
                q.SetCommandText(string.Format(cmd, _currentEngine.SelectedTable.TableName));
            }
        }

        private void cREATEToToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_currentEngine != null && _currentEngine.SelectedTable != null)
            {
                var q = createNewQuery("");

                var result = _currentEngine.GetDataBaseData(string.Format("SELECT sql FROM sqlite_master\nWHERE type = 'table' and name = '{0}';", _currentEngine.SelectedTable.TableName));
                q.SetCommandText(string.Format("{0}", result.Rows[0]["sql"].ToString()));
            }
        }

        private void aLTERTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_currentEngine != null && _currentEngine.SelectedTable != null)
            {
                var q = createNewQuery("");
                string cmd = "ALTER TABLE {0} \n ALTER COLUMN column_name datatyp";
                q.SetCommandText(string.Format(cmd, _currentEngine.SelectedTable.TableName));
            }
        }
        #endregion

        #endregion

        #region View Functions
        private void selectTOP100RecordsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (_currentEngine != null && _currentEngine.SelectedView != null)
            {
                var q = createNewQuery("");
                q.SetCommandText(string.Format("select * from {0} limit 100", _currentEngine.SelectedView.ViewName));
                q.ExecuteCommand();
            }
        }

        private void editScriptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_currentEngine != null && _currentEngine.SelectedView != null)
            {
                var q = createNewQuery("");

                var result = _currentEngine.GetDataBaseData(string.Format("SELECT sql FROM sqlite_master\nWHERE type = 'view' and name = '{0}';", _currentEngine.SelectedView.ViewName));
                q.SetCommandText(string.Format("DROP VIEW {0}\n {1}", _currentEngine.SelectedView.ViewName, result.Rows[0]["sql"].ToString()));
                //q.ExecuteCommand();
            }
        }

        private void deleteViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_currentEngine != null && _currentEngine.SelectedView != null)
            {
                if (MessageBox.Show("Are you sure you want to delete this view", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    _currentEngine.DropView(_currentEngine.SelectedView);
                    refreshData();
                }
            }
        }
        #endregion

        #region Main Menu Functions

        private void abouSQliteStudioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pages.AboutApp app = new Pages.AboutApp();
            app.ShowDialog();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void sQliteDatabaseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            openDatabase_Click(sender, e);
        }

        private void sQliteDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            createDatabase_Click(sender, e);
        }

        private void sQliteQueryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            createNewQuery("");
        }

        private void savedSQliteQueryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openDataBaseDialog.Filter = "sql files (*.sql)|*.sql|txt files (*.txt)|*.txt";
            openDataBaseDialog.Title = "Please select an sql file.";
            openDataBaseDialog.FileName = "";
            openDataBaseDialog.ShowDialog();

            string filename = openDataBaseDialog.FileName;
            if (System.IO.File.Exists(filename))
            {
                StreamReader reader = new StreamReader(filename);
                string text = reader.ReadToEnd();
                reader.Close();

                string qName = Path.GetFileName(filename);
                var q = createNewQuery(qName);
                q.FilePath = filename;

                q.SetCommandText(text);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabPage p = tabControlPages.SelectedTab;
            BaseControl c = (BaseControl)p.Controls[0];
            c.Save();
            p.Text = c.Title; // fara *
            refreshData();
        }

        private void saveAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (TabPage t in tabControlPages.TabPages)
            {
                BaseControl c = (BaseControl)t.Controls[0];

                if (c.HasChanges)
                {
                    c.Save();
                    refreshData();
                    t.Text = c.Title; // fara *
                }

            }
        }

        private void closeDatabaeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            disconnectToolStripMenuItem_Click(sender, e);
        }
        #endregion

        private void tabControlPages_DrawItem(object sender, DrawItemEventArgs e)
        {
            try
            {
                var tabPage = this.tabControlPages.TabPages[e.Index];
                var tabRect = this.tabControlPages.GetTabRect(e.Index);
                tabRect.Inflate(-2, -2);
                Image closeImage = SQlite.WF.Properties.Resources.close_black_16x16;

                if (e.State == DrawItemState.Selected)
                {
                    e.Graphics.FillRectangle(new SolidBrush(Color.LightGoldenrodYellow), e.Bounds);
                    TextRenderer.DrawText(e.Graphics, tabPage.Text, tabPage.Font,
                 tabRect, Color.Black, TextFormatFlags.Left);
                }
                else
                {
                    e.Graphics.FillRectangle(new SolidBrush(Color.SteelBlue), e.Bounds);
                    TextRenderer.DrawText(e.Graphics, tabPage.Text, tabPage.Font,
                 tabRect, Color.White, TextFormatFlags.Left);
                }

                var imageRect = new Rectangle(
               (tabRect.Right - closeImage.Width),
               tabRect.Top + (tabRect.Height - closeImage.Height) / 2,
               closeImage.Width,
               closeImage.Height);
                e.Graphics.DrawImage(closeImage,
                    imageRect);

                //TextRenderer.DrawText(e.Graphics, tabPage.Text, tabPage.Font,
                //    tabRect, tabPage.ForeColor, TextFormatFlags.Left);


            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private void tabControlPages_MouseDown(object sender, MouseEventArgs e)
        {
            for (var i = 0; i < this.tabControlPages.TabPages.Count; i++)
            {
                var tabRect = this.tabControlPages.GetTabRect(i);
                if (tabRect.Contains(e.Location))
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        tabRect.Inflate(-2, -2);
                        Image closeImage = SQlite.WF.Properties.Resources.close_black_16x16;
                        var imageRect = new Rectangle(
                            (tabRect.Right - closeImage.Width),
                            tabRect.Top + (tabRect.Height - closeImage.Height) / 2,
                            closeImage.Width,
                            closeImage.Height);
                        if (imageRect.Contains(e.Location))
                        {
                            var control = (BaseControl)this.tabControlPages.TabPages[i].Controls[0];
                            if (control.HasChanges)
                            {
                                var dr = MessageBox.Show(control.Title + " has changes. Do you want to save?", "Unsaved", MessageBoxButtons.YesNoCancel);
                                if (dr == DialogResult.Yes)
                                {
                                    control.Save();
                                    this.tabControlPages.TabPages.RemoveAt(i);
                                }
                                else if (dr == DialogResult.No)
                                {
                                    control.Cancel();
                                    this.tabControlPages.TabPages.RemoveAt(i);
                                }


                                break;
                            }
                            else
                            {
                                control.Cancel();
                                this.tabControlPages.TabPages.RemoveAt(i);
                            }
                        }
                    }
                    else
                    {
                        this.contextMenuStripCloseAll.Show(this.tabControlPages, new Point(e.X, e.Y));
                    }
                }
            }
        }



        private void sqlLogItemDataGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (sqlLogItemBindingSource.Current != null)
            {
                SqlLogItem item = ((SqlLogItem)sqlLogItemBindingSource.Current);
                string command = item.Query;
                if (!command.Substring(0, 6).ToUpper().Contains("ERROR"))
                {
                    if (item.ExecutedOnEngine != null)
                    {
                        //TODO
                        //change current query to that one, if availble
                    }
                    if (_currentEngine != null)
                    {
                        var q = createNewQuery("");
                        q.SetCommandText(command);

                    }
                }
            }
        }

        private void toolStripMenuItemCloseAll_Click(object sender, EventArgs e)
        {
            foreach (TabPage t in tabControlPages.TabPages)
            {
                BaseControl control = (BaseControl)t.Controls[0];

                if (control.HasChanges)
                {
                    var dr = MessageBox.Show(control.Title + " has changes. Do you want to save?", "Unsaved", MessageBoxButtons.YesNoCancel);
                    if (dr == DialogResult.Yes)
                    {
                        control.Save();
                        this.tabControlPages.TabPages.Remove(t);
                    }
                    else if (dr == DialogResult.No)
                    {
                        control.Cancel();
                        this.tabControlPages.TabPages.Remove(t);
                    }

                }
                else
                {
                    this.tabControlPages.TabPages.Remove(t);
                }

            }
        }

        private void btnClearLog_Click(object sender, EventArgs e)
        {
            this._logItems = new BindingList<SqlLogItem>();
            sqlLogItemBindingSource.DataSource = this._logItems;
        }

        private void reportAnIssueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.sqliteexpress.com/home/contact");
        }
    }
}
