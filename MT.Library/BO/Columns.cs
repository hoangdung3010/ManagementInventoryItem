using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MT.Library.BO
{
   public class Columns
    {
        public string ColumnName { get; set; }

        public string DataType { get; set; }

        public int? MaxLength { get; set; }

        public bool IsNullAble { get; set; }

        public bool IsIdentity { get; set; }
    }
}
