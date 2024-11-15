using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQlite.WF.Models
{
    public class SqlLogItem
    {
        public DateTime LogTime { get; set; }
        public string    Query { get; set; }
        public SqlEngine ExecutedOnEngine { get; set; }
    }
}
