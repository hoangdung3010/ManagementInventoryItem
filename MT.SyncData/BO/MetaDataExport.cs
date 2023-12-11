using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MT.SyncData.BO
{
    internal class MetaDataExport
    {
        /// <summary>
        /// Đơn vị xuất
        /// </summary>
        public Guid sDM_DonVi_Id_Xuat { get; set; }

        /// <summary>
        /// Dữ liệu export
        /// </summary>
        public object Data { get; set; }
    }
}
