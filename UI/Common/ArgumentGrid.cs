using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormUI.Common
{
    public class ArgumentGrid
    {
        public string Sumary { get; set; }
        public string KeyName { get; set; }
        public string Columns { get; set; }

        public string Where { get; set; }

        public string ViewName { get; set; }

        public string Sort { get; set; }

        /// <summary>
        /// Đánh dấu export dữ liệu
        /// </summary>
        public bool IsExport { get; set; }
    }
}
