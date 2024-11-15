using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SQlite.WF.Models
{
    public class SqlEngine
    {
        System.Data.SQLite.SQLiteConnection _conn;
        public SqlTable SelectedTable { get; set; }
        public SqlView SelectedView { get; set; }
        public SqlIndex SelectedIndex { get; set; }
        public SqlTrigger SelectedTrigger { get; set; }
        public SqlRelation SelectedRelation { get; set; }
        public bool IsPinned { get; set; }
        public bool IsConnected { get; set; }

        public event EventHandler<string> QueryExecuted;

        public SqlEngine(string dbfilePath)
        {
            //aici se intampla minunile
            FullDbName = dbfilePath;
            DbName = Path.GetFileNameWithoutExtension(dbfilePath);
            string connstring = "Data Source={0};";
            //   return
            _conn = new SQLiteConnection(string.Format(connstring, dbfilePath));
            _conn.Open();
            LoadTables();
        }
        public SqlTable GetSqlTableWithName(string tableName)
        {

            var tables = GetDataBaseData(string.Format("SELECT * FROM sqlite_master WHERE type = 'table' and name='{0}'", tableName));
            if (tables.Rows.Count == 1)
            {
                DataRow r = tables.Rows[0];

                SqlTable table = new SqlTable(this) { TableName = r["Name"].ToString() };
                table.OriginalTableName = table.TableName;
                var columns = GetDataBaseData(" pragma table_info(" + table.TableName + ")");
                table.TableColumns = new List<SqlColumn>();
                foreach (DataRow c in columns.Rows)
                {
                    SqlColumn column = new SqlColumn();
                    column.ColumnName = c["NAME"].ToString();
                    column.OriginalColumnName = column.ColumnName;
                    column.IsPrimaryKey = c["PK"].ToString() == "1" ? true : false;
                    column.AllowNull = c["NOTNULL"].ToString() == "0" ? true : false;
                    column.Type = GetEnumTypeFromString(c["TYPE"].ToString());

                    table.TableColumns.Add(column);

                    if (column.IsPrimaryKey)
                    {
                        if (table.PrimaryKey == null)
                        {
                            table.PrimaryKey = new SqlIndex();
                            table.PrimaryKey.IndexName = "Primary Key";
                        }
                        table.PrimaryKey.Columns.Add(column);
                    }
                }
                return table;
            }
            return null;

        }
        public void LoadTables()
        {
            try
            {
                Tables = new List<SqlTable>();
                Views = new List<SqlView>();
                var tables = GetDataBaseData("SELECT * FROM sqlite_master WHERE type = 'table' order by name");
                foreach (DataRow r in tables.Rows)
                {
                    SqlTable table = new SqlTable(this) { TableName = r["Name"].ToString() };
                    table.OriginalTableName = table.TableName;
                    var columns = GetDataBaseData(" pragma table_info(" + table.TableName + ")");
                    table.TableColumns = new List<SqlColumn>();
                    foreach (DataRow c in columns.Rows)
                    {
                        SqlColumn column = new SqlColumn();
                        column.ColumnName = c["NAME"].ToString();
                        column.OriginalColumnName = column.ColumnName;
                        column.IsPrimaryKey = c["PK"].ToString() == "1" ? true : false;
                        column.AllowNull = c["NOTNULL"].ToString() == "0" ? true : false;
                        column.Type = GetEnumTypeFromString(c["TYPE"].ToString());
                        if (column.Type == SqlTypeEnum.VARCHAR)
                        {
                            string rString = Regex.Match(c["TYPE"].ToString(), @"\d+").Value;
                            column.Size = !string.IsNullOrEmpty(rString) ? Int32.Parse(rString) : 0;
                        }

                        table.TableColumns.Add(column);

                        if (column.IsPrimaryKey)
                        {
                            if (table.PrimaryKey == null)
                            {
                                table.PrimaryKey = new SqlIndex();
                                table.PrimaryKey.IndexName = "Primary Key";
                            }
                            table.PrimaryKey.Columns.Add(column);
                        }

                    }

                    string getIndex = "SELECT il.name, ii.name AS 'indexed-columns' FROM sqlite_master AS m, pragma_index_list(m.name) AS il, pragma_index_info(il.name) AS ii WHERE m.type = 'table' and m.name = '" + table.TableName + "' ORDER BY 1";
                    var indexes = GetDataBaseData(getIndex);
                    table.Indexes = new List<SqlIndex>();
                    string prevIndex = "";
                    foreach (DataRow i in indexes.Rows)
                    {
                        string indexName = i["NAME"].ToString();
                        string indexCol = i["indexed-columns"].ToString();

                        if (indexName != prevIndex)
                        {
                            SqlIndex sqlIndex = new SqlIndex();
                            sqlIndex.IndexName = indexName;
                            table.Indexes.Add(sqlIndex);

                            prevIndex = indexName;
                        }
                        //add column
                        SqlColumn column = table.TableColumns.Where(a => a.ColumnName == indexCol).FirstOrDefault();
                        if (column != null)
                        {
                            table.Indexes.Where(a => a.IndexName == indexName).First().Columns.Add(column);
                        }
                    }

                    string getTrigger = "select * from sqlite_master where type = 'trigger' and  tbl_name = '" + table.TableName + "'";
                    var triggers = GetDataBaseData(getTrigger);
                    foreach (DataRow i in triggers.Rows)
                    {
                        SqlTrigger trigger = new SqlTrigger();
                        trigger.TriggerName = i["name"].ToString();
                        trigger.SqlCommand = i["sql"].ToString();
                        table.Triggers.Add(trigger);
                    }

                    string getFK = " pragma foreign_key_list(" + table.TableName + ")";
                    var foreignKeys = GetDataBaseData(getFK);
                    table.Relations = new List<SqlRelation>();
                    foreach (DataRow fk in foreignKeys.Rows)
                    {
                        string newFk = fk[2].ToString() + "(" + fk[3].ToString() + ")";
                        SqlRelation relation = new SqlRelation() { RefTableName = fk[2].ToString(), ColumnName = fk[3].ToString(), RefColumnName = fk[4].ToString() };
                        table.Relations.Add(relation);
                    }

                    Tables.Add(table);

                }

                var views = GetDataBaseData("SELECT * FROM sqlite_master WHERE type = 'view'");
                foreach (DataRow r in views.Rows)
                {
                    SqlView table = new SqlView() { ViewName = r["Name"].ToString() };
                    var columns = GetDataBaseData(" pragma table_info(" + table.ViewName + ")");
                    table.ViewColumns = new List<SqlColumn>();
                    foreach (DataRow c in columns.Rows)
                    {
                        SqlColumn column = new SqlColumn();
                        column.ColumnName = c["NAME"].ToString();
                        column.IsPrimaryKey = c["PK"].ToString() == "1" ? true : false;
                        column.AllowNull = c["NOTNULL"].ToString() == "0" ? true : false;
                        column.Type = GetEnumTypeFromString(c["TYPE"].ToString());

                        table.ViewColumns.Add(column);
                    }
                    Views.Add(table);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private SqlTypeEnum GetEnumTypeFromString(string type)
        {
            if (type == SqlTypeEnum.BLOB.ToString())
            {
                return SqlTypeEnum.BLOB;
            }
            else if (type == SqlTypeEnum.VARCHAR.ToString())
            {
                return SqlTypeEnum.VARCHAR;
            }
            else if (type == SqlTypeEnum.INTEGER.ToString())
            {
                return SqlTypeEnum.INTEGER;
            }
            else if (type == SqlTypeEnum.DOUBLE.ToString() || type == "FLOAT" || type == "NUMBER")
            {
                return SqlTypeEnum.DOUBLE;
            }
            else if (type == SqlTypeEnum.DATE.ToString())
            {
                return SqlTypeEnum.DATE;
            }
            else
            {
                return SqlTypeEnum.VARCHAR;
            }
        }

        public List<SqlTable> Tables { get; set; }
        public List<SqlView> Views { get; set; }
        public string FullDbName { get; set; }
        public string DbName { get; set; }

        public void SaveTableChanges(SqlTable table)
        {
            string tempTableName = "temp_t_" + DateTime.Now.ToString("ddMM_mmss");
            var dbTable = GetSqlTableWithName(table.OriginalTableName);
            if (dbTable != null)
            {
                if (table.OriginalTableName != table.TableName)
                {
                    //peform table rename

                    this.ExecuteNonQuery(string.Format("alter table {0} rename to {1}", table.OriginalTableName, table.TableName));
                }

                dbTable = GetSqlTableWithName(table.TableName);
                string query;
                if (AreAllOldColumnsUnchanged(table, dbTable))
                {
                    //we only have new columns
                    //we add them to the database
                    for (int i = dbTable.TableColumns.Count; i < table.TableColumns.Count; i++)
                    {
                        query = string.Format("alter table {0} add column {1} {2}", table.TableName, table.TableColumns[i].ColumnName, table.TableColumns[i].Type);
                        if (table.TableColumns[i].Size > 0)
                            query += "(" + table.TableColumns[i].Size + ")";
                        this.ExecuteNonQuery(query);
                    }

                    //completed - table changed

                }
                else
                {
                    //we have a complex change in the table

                    //at this stage, we are sure there is no more table renaming, or simple column renaming

                    //step 1 - get index/pk/fk/trigger/view definitions - and disable keys and constraints
                    //rename table to temp table
                    this.ExecuteNonQuery(string.Format("alter table {0} rename to {1}", table.TableName, tempTableName));

                    //TODO

                    //step 2 - create new table with the new structure
                    string template = "CREATE TABLE {0}({1})";
                    string collCreateTemplate = "{0} {1} {2},";
                    string colCreate = "";

                    foreach (var col in table.TableColumns)
                    {

                        colCreate += string.Format(collCreateTemplate, col.ColumnName, col.Type, col.Size > 0 ? "(" + col.Size + ")" : "");
                    }
                    colCreate = colCreate.Substring(0, colCreate.Length - 1);
                    this.ExecuteNonQuery(string.Format(template, table.TableName, colCreate));

                    //step 3 - move data that is maching cols from temp_Table

                    List<SqlColumn> moveCols = new List<SqlColumn>();
                    List<SqlColumn> convertCols = new List<SqlColumn>();
                    foreach (var sqlCol in dbTable.TableColumns)
                    {
                        //this col was renamed
                        //check for type
                        var newcol = table.TableColumns.Where(a => a.ColumnName == sqlCol.ColumnName).FirstOrDefault();
                        if (newcol == null)
                        {
                            continue;
                        }
                        if (newcol.Type == sqlCol.Type && newcol.Size == sqlCol.Size)
                            moveCols.Add(sqlCol);
                        else
                            convertCols.Add(newcol);
                    }
                    if (moveCols.Count > 0 || convertCols.Count > 0)
                    {
                        string insertCommand = "insert into {0} ({1}) select {2} from {3}";
                        string coldest = "";
                        string colsource = "";
                        foreach (var mc in moveCols)
                        {
                            coldest += mc.ColumnName + ",";
                            colsource += mc.OriginalColumnName + ",";
                        }
                        foreach (var cc in convertCols)
                        {
                            coldest += cc.ColumnName + ",";
                            colsource += string.Format("cast({0} as {1}{2}), ", cc.OriginalColumnName, cc.Type, cc.Size > 0 ? "(" + cc.Size + ")" : "");
                        }
                        colsource = colsource.Substring(0, colsource.Length - 2);
                        coldest = coldest.Substring(0, coldest.Length - 1);
                        this.ExecuteNonQuery(string.Format(insertCommand, table.TableName, coldest, colsource, tempTableName));

                    }

                    //drop temp table
                    this.ExecuteNonQuery("drop table " + tempTableName);

                    //recreate the PK/index/FK...ect
                    //TODO

                }

            }
            else
            {
                //create new table
                string template = "CREATE TABLE {0}({1})";
                string collCreateTemplate = "{0} {1}{2},";
                string colCreate = "";
                foreach (var col in table.TableColumns)
                {
                    colCreate += string.Format(collCreateTemplate, col.ColumnName, col.Type, col.Size > 0 ? "(" + col.Size + ")" : "");
                }
                colCreate = colCreate.Substring(0, colCreate.Length - 1);
                this.ExecuteNonQuery(string.Format(template, table.TableName, colCreate));
            }
        }

        private bool AreAllOldColumnsUnchanged(SqlTable newTable, SqlTable dbTable)
        {
            if (newTable.TableColumns.Count < dbTable.TableColumns.Count)
                return false;

            for (int i = 0; i < dbTable.TableColumns.Count; i++)
            {

                if (newTable.TableColumns[i].OriginalColumnName == null)
                {
                    //we have inserted a new column
                    return false;
                }
                if (newTable.TableColumns[i].ColumnName != dbTable.TableColumns[i].ColumnName)
                {
                    //columsn have been reorderd
                    return false;
                }
                if (newTable.TableColumns[i].Type != dbTable.TableColumns[i].Type)
                {
                    //columsn have different type
                    return false;
                }

                if (newTable.TableColumns[i].Size != dbTable.TableColumns[i].Size)
                {
                    return false;
                }
            }
            return true;
        }
        private object ExecuteNonQuery(string CommandText)
        {
            SQLiteCommand sqliteCommand = (SQLiteCommand)_conn.CreateCommand();

            sqliteCommand.CommandType = System.Data.CommandType.Text;
            sqliteCommand.CommandText = CommandText;
            return sqliteCommand.ExecuteNonQuery();
        }
        public object ExecuteScalar(string CommandText)
        {
            SQLiteCommand sqliteCommand = (SQLiteCommand)_conn.CreateCommand();

            sqliteCommand.CommandType = System.Data.CommandType.Text;
            sqliteCommand.CommandText = CommandText;
            return sqliteCommand.ExecuteScalar();
        }

        public System.Data.DataTable GetDataBaseData(string p_commandStringText)
        {

            System.Data.DataTable res = new DataTable();

            SQLiteCommand sqliteCommand = (SQLiteCommand)_conn.CreateCommand();
            sqliteCommand.CommandType = System.Data.CommandType.Text;
            sqliteCommand.CommandText = p_commandStringText;

            IDataReader reader = sqliteCommand.ExecuteReader();

            while (reader.Read())
            {
                try
                {
                    object[] values = new object[reader.FieldCount];
                    reader.GetValues(values);
                    if (res.Columns.Count == 0)
                    {

                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            if (values[i].GetType().Equals(typeof(byte[])))
                            {
                                res.Columns.Add(new DataColumn(reader.GetName(i), typeof (byte[])));
                            }
                            else
                            {
                                res.Columns.Add(new DataColumn(reader.GetName(i)));
                            }

                        }
                    }
                   
                    DataRow dr = res.NewRow();
                    for (int i = 0; i < res.Columns.Count; i++)
                    {
                        dr[i] = values[i];
                      
                    }
                    res.Rows.Add(dr);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return res;


        }

        internal void DropTable(SqlTable selectedTable)
        {

            this.ExecuteNonQuery(string.Format("drop table {0}", selectedTable.TableName));
            this.Tables.Remove(selectedTable);

        }

        internal void DropView(SqlView selectedView)
        {

            this.ExecuteNonQuery(string.Format("drop view {0}", selectedView.ViewName));
            this.Views.Remove(selectedView);
        }

        internal void DropIndex(SqlIndex selectedIndex)
        {
            this.ExecuteNonQuery(string.Format("drop index  if exists {0}", selectedIndex.IndexName));
            this.SelectedTable.Indexes.Remove(selectedIndex);
        }

        internal void DropTrigger(SqlTrigger selectedTrigger)
        {
            this.ExecuteNonQuery(string.Format("drop trigger if exists {0}", selectedTrigger.TriggerName));
            this.SelectedTable.Triggers.Remove(selectedTrigger);
        }

        internal void DropRelation(SqlRelation selectedRelation)
        {
            //TODO
        }

        public void ExecuteQuery(SqlQuery q)
        {
            q.QueryResult = new Result();

            if (q.QueryCommand.ToLower().Trim().StartsWith("select"))
            {
                try
                {
                    q.QueryResult.ResultData = GetDataBaseData(q.QueryCommand);
                    q.QueryResult.Status = string.Format("Returned {0} records", q.QueryResult.ResultData.Rows.Count);
                    ThrowQueryExecutedEvent(q.QueryCommand);
                }
                catch (Exception ex)
                {
                    q.QueryResult.Status = string.Format("Error executing script: {0}", ex.Message);
                    ThrowQueryExecutedEvent(q.QueryResult.Status);
                }
            }
            else
            {
                try
                {
                    var result = ExecuteNonQuery(q.QueryCommand);
                    q.QueryResult.Status = string.Format("Executed command. Affected data: {0} ", result.ToString());
                    ThrowQueryExecutedEvent(q.QueryCommand);
                }
                catch (Exception ex)
                {
                    q.QueryResult.Status = string.Format("Error executing script: {0}", ex.Message);
                    ThrowQueryExecutedEvent(q.QueryResult.Status);
                }
            }


        }
        public void ThrowQueryExecutedEvent(string queryOrResult)
        {
            if (this.QueryExecuted != null)
                this.QueryExecuted(this, queryOrResult);
        }
    }
}
