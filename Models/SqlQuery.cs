using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQlite.WF.Models
{
    public class SqlQuery
    {
        public string QueryCommand { get; set; }
        public Result QueryResult { get; set; }
    }

    public class Result
    {
        public string ErrorMessage { get; set; }
        public string Status { get; set; }
        public DataTable ResultData { get; set; }

        public Result()
        {
            ResultData = new DataTable();
        }
    }

    public class Data
    {
        public List<string> DataColumns { get; set; }
        public List<List<string>> Records { get; set; }

        public Data()
        {
            DataColumns = new List<string>();
            Records = new List<List<string>>();
        }
    }
}
