using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQlite.WF.Models
{
    public class SqlTable
    {
        public string TableName { get; set; }
        public string OriginalTableName { get; set; }
        public List<string> Constraints { get; set; }
        public List<SqlRelation> Relations { get; set; }
        public List<SqlColumn> TableColumns { get; set; }
        public SqlIndex PrimaryKey { get; set; }
        public List<SqlIndex> Indexes { get; set; }
        public List<SqlTrigger> Triggers { get; set; }

        private SqlEngine _engine;

        public SqlTable(SqlEngine engine)
        {
            TableColumns = new List<SqlColumn>();
            Constraints = new List<string>();
            Indexes = new List<SqlIndex>();
            Relations = new List<SqlRelation>();
            Triggers = new List<SqlTrigger>();
            _engine = engine;
        }
        public void Save()
        {
            _engine.SaveTableChanges(this);
        }
    }

    public class SqlRelation
    {
        public string RefTableName { get; set; }
        public string ColumnName { get; set; }
        public string RefColumnName { get; set; }

        public SqlRelation() { }

        public override string ToString()
        {
            return this.RefTableName + "(" + this.ColumnName + ", Ref:" + this.RefColumnName + ")";
        }
    }
}
