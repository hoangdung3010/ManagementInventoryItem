using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MT.Library.BO
{
    class FileInfoEncrypt
    {
        /// <summary>
        /// Độ dài file gốc
        /// </summary>
        public int OriginBytesLength { get; set; }

        /// <summary>
        /// Độ dài file encrypt
        /// </summary>
        public int NewBytesLength { get; set; }

        /// <summary>
        /// Tổng số byte đọc
        /// </summary>
        public long TotalReadBytes { get; set; }
    }
}
