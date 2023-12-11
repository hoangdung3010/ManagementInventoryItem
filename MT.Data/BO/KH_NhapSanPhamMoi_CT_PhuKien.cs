using System;
using MT.Library;
using System.ComponentModel.DataAnnotations;
using System.Collections;

namespace MT.Data.BO
{
    [ForeignKey("KH_NhapSanPhamMoi_CT", "sKH_NhapSanPhamMoi_CT_Id")]
    public class KH_NhapSanPhamMoi_CT_PhuKien : BaseEntity
    {
        #region Instance Properties
        [Key]
        public Guid Id { get; set; }

        public Guid? sKH_NhapSanPhamMoi_CT_Id { get; set; }
        public string sKH_NhapSanPhamMoi_CT_Id_Ten { get; set; }

        public Guid? sDM_SanPham_Id { get; set; }
        public string sDM_SanPham_Id_Ten { get; set; }

        public Guid? sDM_PhuKien_Id { get; set; }
        public string sDM_PhuKien_Id_Ten { get; set; }

        public Guid? sDM_DonViTinh_Id { get; set; }
        public string sDM_DonViTinh_Id_Ten { get; set; }

        public decimal rSoLuongPhuKienTren1SP { get; set; }

        public decimal rSoLuong { get; set; }

        public decimal rDonGia { get; set; }

        public decimal rThanhTien { get; set; }

        public string sXuatXu { get; set; }

        public string sGhiChu { get; set; }

        public int SortOrder { get; set; }

        #endregion Instance Properties


    }

}
