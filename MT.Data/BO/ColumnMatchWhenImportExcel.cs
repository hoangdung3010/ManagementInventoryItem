using MT.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MT.Data.BO
{
    public class ColumnMatchWhenImportExcel:BaseEntity
    {
        public bool IsRequired { get; set; }
        /// <summary>
        /// Tên cột nguồn
        /// </summary>
        public string SourceDisplay { get; set; }

        /// <summary>
        /// Tên cột đích
        /// </summary>
        public string Destination { get; set; }

        /// <summary>
        /// Diễn giải
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Dữ liệu trên tệp mẫu
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Thứ tự cột trên excel
        /// </summary>
        public int ColIndex { get; set; }

        public int Width { get; set; }

        public bool IsLock { get; set; }

        public int DataType { get; set; }

        public bool AutoInsert { get; set; }
    }
}
