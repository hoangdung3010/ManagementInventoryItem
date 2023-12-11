using MT.Library;
using System;
using System.ComponentModel.DataAnnotations;

namespace MT.Data.BO
{
    public class DM_DonVi : MT.Library.BO.MTTree<Guid>
    {
        [Key]
        public override Guid Id { get; set; }

        [Code]
        public string sMaDonvi { get; set; }

        public string sTenDonvi { get; set; }
        public string sTenDonviRutGon { get; set; }

        public Guid? sDM_LoaiDonVi_Id { get; set; }

        public string sDM_LoaiDonVi_Id_Ten { get; set; }

        public string sGhiChu { get; set; }

        public Guid? sParentId { get; set; }
        public string sParentId_Ten { get; set; }
        [IgnoreLog]
        public string sLoai { get; set; } = "Đơn vị"; // Sử dụng khi chọn cả Đơn vị + Nhà cung cấp
        [IgnoreLog]
        public int iDictionary { get; set; }

        /// <summary>
        /// Chỉ áp dụng cho cơ cấu tổ chức con: 1 là con theo cơ cấu tổ chức,2: Con theo nghiệp vụ
        /// </summary>
        [EnumLog("DM_DonVi_iType")]
        public int iType { get; set; }
        [IgnoreLog]
        public string iType_Ten { get; set; }

        public string sTenCotBC { get; set; }
    }

}
