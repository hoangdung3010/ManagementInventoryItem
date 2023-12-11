using System;
using MT.Library;
using System.ComponentModel.DataAnnotations;

namespace MT.Data.BO
{
    public class DM_CanBo : BaseEntity
    {
        #region Instance Properties
        [Key]
        public Guid Id { get; set; }
        [Code]
        public string sMaCanBo { get; set; }

        public string sHoVaDem { get; set; }

        public string sTen { get; set; }

        public string sTenCanBo { get; set; }

        public string sEmail { get; set; }

        public string sDienThoai { get; set; }

        public int SortOrder { get; set; }

        public Guid? sDM_ChucVu_Id { get; set; }
        public string sDM_ChucVu_Id_Ten { get; set; }

        public Guid? sDM_DonVi_Id { get; set; }
        public string sDM_DonVi_Id_Ten { get; set; }
        public string sGhiChu { get; set; }

        #endregion Instance Properties
    }

}
