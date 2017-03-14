using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace FM.Models
{
    public class Row
    {
        public Row()
        {
            this.ColumnList = new List<string>();
        }

        public IList<string> ColumnList { get; set; }
    }
}
