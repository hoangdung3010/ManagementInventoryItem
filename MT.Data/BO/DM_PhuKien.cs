using MT.Library;
using System;
using System.ComponentModel.DataAnnotations;

namespace MT.Data.BO
{
    public class DM_PhuKien : MT.Library.BaseEntity
    {
        [Key]
        public Guid Id { get; set; }

        [Code]
        public string sMaPhuKien { get; set; }

        public string sTenPhuKien { get; set; }

        public Guid? sDM_SanPham_Id { get; set; }
        public string sDM_SanPham_Id_Ten { get; set; }

        public Guid? sDM_DonViTinh_Id { get; set; }
        public string sDM_DonViTinh_Id_Ten { get; set; }

        public decimal rSoLuong { get; set; }
        public decimal rDonGia { get; set; }

        public string sXuatXu { get; set; }

        public string sGhiChu { get; set; }
        [IgnoreLog]
        public int SortOrder { get; set; }
    }

}
