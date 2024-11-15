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
using System.Text.RegularExpressions;
using System.IO;

namespace SQlite.WF.Controls
{
    internal partial class QueryWindow : Base.BaseControl
    {
        private SqlEngine currentEngine;
        private static string keywords = @"\b(CREATE|UPDATE|DELETE|DROP|INSERT|ALTER|SELECT|FROM|WHERE|GROUP|BY|IS|ORDER)\b";
        private static string types = @"\b(INTEGER|TEXT|REAL)\b";
        private static string comments = @"(--.*)|(((/\*)+?[\w\W]+?(\*/)+))";
        private static string objects = @"\b(TABLE|VIEW|INDEX)\b";
        private static string strings = "\'.+?\'";
        private static string conditions = @"\b(ON|JOIN|LEFT|RIGHT|CROSS)\b";

        private List<int> _binaryColumns = new List<int>();
        public string FilePath { get; set; } = "";

        public QueryWindow(SqlEngine engine)
        {
            InitializeComponent();
            currentEngine = engine;
            if (currentEngine != null)
            {
                toolStripLabelCurrentDatabase.Text = engine.DbName;

            }
            else
            {
                toolStripLabelCurrentDatabase.Text = "No database";

            }
            resultDataView.AutoGenerateColumns = false;
            this.queryText.TextChanged += new System.EventHandler(this.queryText_TextChanged);
        }
        private void queryText_TextChanged(object sender, EventArgs e)
        {

            this.ThrowContentChanged();
            MatchCollection keywordMatches = Regex.Matches(queryText.Text.ToLower(), keywords.ToLower());
            MatchCollection typeMatches = Regex.Matches(queryText.Text.ToLower(), types.ToLower());
            MatchCollection commentMatches = Regex.Matches(queryText.Text.ToLower(), comments.ToLower());
            MatchCollection objectMatches = Regex.Matches(queryText.Text.ToLower(), objects.ToLower());
            MatchCollection stringMatches = Regex.Matches(queryText.Text.ToLower(), strings.ToLower());
            MatchCollection conditionMatches = Regex.Matches(queryText.Text.ToLower(), conditions.ToLower());

            int originalIndex = queryText.SelectionStart;
            int originalLength = queryText.SelectionLength;
            Color originalColor = Color.Black;

            queryText.SelectionStart = 0;
            queryText.SelectionLength = queryText.Text.Length;
            queryText.SelectionColor = originalColor;

            foreach (Match m in keywordMatches)
            {
                queryText.SelectionStart = m.Index;
                queryText.SelectionLength = m.Length;
                queryText.SelectionColor = Color.Blue;
            }

            foreach (Match m in typeMatches)
            {
                queryText.SelectionStart = m.Index;
                queryText.SelectionLength = m.Length;
                queryText.SelectionColor = Color.DarkCyan;
            }

            foreach (Match m in commentMatches)
            {
                queryText.SelectionStart = m.Index;
                queryText.SelectionLength = m.Length;
                queryText.SelectionColor = Color.Green;
            }

            foreach (Match m in objectMatches)
            {
                queryText.SelectionStart = m.Index;
                queryText.SelectionLength = m.Length;
                queryText.SelectionColor = Color.DarkBlue;
            }

            foreach (Match m in stringMatches)
            {
                queryText.SelectionStart = m.Index;
                queryText.SelectionLength = m.Length;
                queryText.SelectionColor = Color.DarkOrange;
            }

            foreach (Match m in conditionMatches)
            {
                queryText.SelectionStart = m.Index;
                queryText.SelectionLength = m.Length;
                queryText.SelectionColor = Color.DarkOliveGreen;
            }

            queryText.SelectionStart = originalIndex;
            queryText.SelectionLength = originalLength;
            queryText.SelectionColor = originalColor;
            queryText.Focus();
        }

        private void runBtn_Click(object sender, EventArgs e)
        {
            if(currentEngine != null)
            {
                ExecuteCommand();

            }
            else
            {
                MessageBox.Show("Please connect to a database before any operations!", "Error", MessageBoxButtons.OK);
            }
        }

        private void query_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                if (currentEngine != null)
                {
                    ExecuteCommand();

                }
                else
                {
                    MessageBox.Show("Please connect to a database before any operations!", "Error", MessageBoxButtons.OK);
                }
            }
        }
        public override void SaveAs()
        {
            base.SaveAs();


            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Select location for file";
            saveFileDialog.FileName = "sqlfile";
            saveFileDialog.DefaultExt = ".sql";
            saveFileDialog.AddExtension = true;
            saveFileDialog.Filter = "sql files (*.sql)|*.sql|txt files (*.txt)|*.txt";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName))
                {
                    sw.Write(this.queryText.Text);
                    sw.Flush();
                    sw.Close();
                }

                this.Title = Path.GetFileName(saveFileDialog.FileName);
                this.Parent.Text = Path.GetFileName(saveFileDialog.FileName);
            }

            this.HasChanges = false;

        }
        public override void Save()
        {
            base.Save();

            if (!string.IsNullOrEmpty(this.FilePath))
            {
                StreamWriter writer = new StreamWriter(this.FilePath);
                writer.Write(queryText.Text);
                writer.Flush();
                writer.Close();

                this.Title = Path.GetFileName(this.FilePath);
                this.Parent.Text = Path.GetFileName(this.FilePath);
            }
            else
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Title = "Select location for file";
                saveFileDialog.FileName = "sqlfile";
                saveFileDialog.DefaultExt = ".sql";
                saveFileDialog.AddExtension = true;
                saveFileDialog.Filter = "sql files (*.sql)|*.sql|txt files (*.txt)|*.txt";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName))
                    {
                        sw.Write(this.queryText.Text);
                        sw.Flush();
                        sw.Close();
                    }
                       

                    this.Title = Path.GetFileName(saveFileDialog.FileName);
                    this.Parent.Text = Path.GetFileName(saveFileDialog.FileName);
                }
            }
            this.HasChanges = false;
        }

        internal void SetCommandText(string v)
        {
            this.queryText.TextChanged -= new System.EventHandler(this.queryText_TextChanged);
            this.queryText.Text = v;
            this.queryText.SelectAll();
            this.queryText.TextChanged += new System.EventHandler(this.queryText_TextChanged);

            if(currentEngine== null)
            {
                MessageBox.Show("You cannot run queries if there is no database connected.", "Error", MessageBoxButtons.OK);
            }
        }

        internal void ExecuteCommand()
        {
            var s1 = DateTime.Now;
            string queryString;
            if (!string.IsNullOrEmpty(queryText.SelectedText))
            {
                queryString = queryText.SelectedText;
            }
            else
            {
                queryString = queryText.Text;
            }
            if (string.IsNullOrEmpty(queryString))
            {
                MessageBox.Show("There are no instruction to run.", "Run failed", MessageBoxButtons.OK);

            }
            else if (currentEngine != null && currentEngine.IsConnected)
            {
                try
                {
                    SqlQuery q = new SqlQuery();
                    q.QueryCommand = queryString;
                    currentEngine.ExecuteQuery(q);
                    _binaryColumns = new List<int>();

                    resultDataView.Columns.Clear();
                    if (q.QueryResult.ResultData != null && q.QueryResult.ResultData.Columns.Count > 0)
                    {
                        //copiere data
                        for (int i = 0; i < q.QueryResult.ResultData.Columns.Count; i++)
                        {
                            if (q.QueryResult.ResultData.Columns[i].DataType.Equals(typeof(byte[])))
                            {
                                //_binaryColumns.Add(i);
                                DataGridViewButtonColumn col = new DataGridViewButtonColumn();
                                col.HeaderText = q.QueryResult.ResultData.Columns[i].ColumnName;
                                col.DataPropertyName = q.QueryResult.ResultData.Columns[i].ColumnName;
                            
                                resultDataView.Columns.Add(col);
                                _binaryColumns.Add(i);
                            }
                            else
                            {

                                DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
                                col.HeaderText = q.QueryResult.ResultData.Columns[i].ColumnName;
                                col.DataPropertyName = q.QueryResult.ResultData.Columns[i].ColumnName;
                                resultDataView.Columns.Add(col);
                            }

                        }


                        resultDataView.DataSource = q.QueryResult.ResultData;


                        StatusText.Text = q.QueryResult.Status;
                        queryWinTabs.SelectTab(DataTab);
                    }
                    else
                    {
                        StatusText.Text = q.QueryResult.Status;
                        queryWinTabs.SelectTab(MessagesTab);
                    }
                }
                catch (Exception ex)
                {
                    StatusText.Text = ex.Message;
                    queryWinTabs.SelectTab(MessagesTab);
                }
            }
            else
            {
                MessageBox.Show("There are no connected databases.", "Run failed", MessageBoxButtons.OK);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //save
            this.Save();
        }

        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            //save as
            this.SaveAs();

        }

        private void resultDataView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (_binaryColumns.IndexOf(e.ColumnIndex) >= 0)
            {
                if (e.Value == DBNull.Value)
                {
                    e.Value = "byte[] dbnull";
                }
                else
                {
                    e.Value = "byte[] (view content)";
                }
            }
        }

        private void resultDataView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                Pages.FormBinaryView frm = new Pages.FormBinaryView();
                DataTable dt = (DataTable)senderGrid.DataSource;
                var obj = dt.Rows[e.RowIndex][e.ColumnIndex];
                if (obj != DBNull.Value)
                {
                    frm.LoadByte((byte[])dt.Rows[e.RowIndex][e.ColumnIndex]);
                }
                frm.ShowDialog();
            }
        }



        //private void resultDataView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        //{
        //    if (_binaryColumns.IndexOf(e.ColumnIndex)>0)
        //    {
        //        e.Value = "BLOB";
        //    }

        //   //  
        //}
    }
}
