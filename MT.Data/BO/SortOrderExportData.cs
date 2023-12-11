using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MT.Data.BO
{
    public class SortOrderExportData
    {
        public string TableName { get; set; }

        public bool IsDictionary { get; set; }

        public int SortOrder { get; set; }

        /// <summary>
        /// Quyền export
        /// </summary>
        public int Permission { get; set; }
    }
}
