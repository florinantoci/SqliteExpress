using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQlite.WF.Models
{
    public class SqlTrigger
    {
        public string TriggerName { get; set; }
        public string SqlCommand { get; set; }

        public SqlTrigger() { }

        public string GetScript()
        {
            string script = "DROP TRIGGER IF EXISTS " + this.TriggerName + "\n\n";
            return script + SqlCommand;
        }
    }
}
