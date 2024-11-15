using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQlite.WF.Models
{
    public class SqlIndex
    {
        public string  IndexName { get; set; }
        public List<SqlColumn> Columns { get; set; }

        public SqlIndex()
        {
            Columns = new List<SqlColumn>();
        }

        public string GetScript(string table)
        {
            string script = "DROP INDEX IF EXISTS " + this.IndexName + "\n\nCREATE UNIQUE INDEX " + this.IndexName + " ON " + table + "(";
            foreach (SqlColumn col in this.Columns)
            {
                script += col.ColumnName + ",";
            }
            script = script.Substring(0, script.Length - 2);
            script += ");";
            return script;
        }
    }
}
