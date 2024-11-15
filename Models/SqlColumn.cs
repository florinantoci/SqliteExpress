using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQlite.WF.Models
{
    public class SqlColumn
    {
        public string ColumnName { get; set; }
        public string OriginalColumnName { get; set; }
        public SqlTypeEnum Type { get; set; }
        public bool AllowNull { get; set; }
        public bool IsPrimaryKey { get; set; }
        public int Size { get; set; }
        public int Precision { get; set; }

        public SqlColumn() { }
    }
}
