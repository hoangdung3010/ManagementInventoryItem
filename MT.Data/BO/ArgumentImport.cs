using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MT.Data.BO
{
    public class ArgumentImport
    {
        public string TableName { get; set; }

        public int ActiveSheet { get; set; }

        public int RowPosition { get; set; }

        /// <summary>
        /// =true là nhập khẩu thêm mới, ngược lại nhập khẩu cập nhật
        /// </summary>
        public bool AddNew { get; set; }
    }
}
