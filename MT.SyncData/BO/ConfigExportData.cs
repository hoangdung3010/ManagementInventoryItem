using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MT.SyncData.BO
{
    internal class ConfigExportData
    {
        public Guid sDM_DonVi_Id_DonViXuat { get; set; }
        public string sDM_DonVi_Id_DonViXuat_Ten { get; set; }
        public Guid sDM_DonVi_Id_DonViNhap { get; set; }
        public string sDM_DonVi_Id_DonViNhap_Ten { get; set; }
        public string sFolderName { get; set; }

        public int iType { get; set; }
    }
}
