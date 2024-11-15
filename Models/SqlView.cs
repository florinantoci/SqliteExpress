using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQlite.WF.Models
{
    public class SqlView
    {
        public string ViewName { get; set; }
        public List<SqlColumn> ViewColumns { get; set; }
        public string Script { get; set; }

        public SqlView()
        {
            ViewColumns = new List<SqlColumn>();
        }
    }
}
