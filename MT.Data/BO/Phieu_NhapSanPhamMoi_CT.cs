using System;
using MT.Library;
using System.ComponentModel.DataAnnotations;
using System.Collections;

namespace MT.Data.BO
{
    [ForeignKey("Phieu_NhapSanPhamMoi", "sPhieu_NhapSanPhamMoi_Id")]
    public class Phieu_NhapSanPhamMoi_CT : BaseEntity
    {
        #region Instance Properties
        [Key]
        public Guid Id { get; set; }

        public Guid? sPhieu_NhapSanPhamMoi_Id { get; set; }

        public Guid? sKH_NhapSanPhamMoi_CT_Id { get; set; }

        public Guid? sKH_NhapSanPhamMoi_Id { get; set; }
        public Guid? sDM_SanPham_Id { get; set; }

        public string sDM_SanPham_Id_Ma { get; set; }
        public string sDM_SanPham_Id_Ten { get; set; }

        public string sMaVach { get; set; }

        public Guid? sDM_DonViTinh_Id { get; set; }

        public string  sDM_DonViTinh_Id_Ten { get; set; }

        public decimal rSoLuong { get; set; }

        public string sSerial { get; set; }

        public decimal rDonGia { get; set; }

        public decimal rThanhTien { get; set; }

        public string sCauHinhKyThuat { get; set; }

        public string sXuatXu { get; set; }

        public int? iNamSX { get; set; }

        public int iThoiGianBaoHanh { get; set; }

        public int iDonViThoiGianBaoHanh { get; set; }
        public DateTime? dHanBaoHanhDen { get; set; }

        public string sGhiChu { get; set; }

        public int SortOrder { get; set; }
        public IList phieu_NhapSanPhamMoi_CT_PhuKiens { get; set; }

        public string sSTTSP { get; set; }
        #endregion Instance Properties

        #region"Contructors"
        public Phieu_NhapSanPhamMoi_CT()
        {
            this.DetailConfig = new string[1] { "phieu_NhapSanPhamMoi_CT_PhuKiens" };
        }
        #endregion
    }

}
