using System;
using MT.Library;
using System.ComponentModel.DataAnnotations;
using System.Collections;

namespace MT.Data.BO
{
    [ForeignKey("Phieu_NhapSuaChuaSanPham", "sPhieu_NhapSuaChuaSanPham_Id")]
    public class Phieu_NhapSuaChuaSanPham_CT : BaseEntity
    {
        #region Instance Properties
        [Key]
        public Guid Id { get; set; }
        /// <summary>
        /// FK_Chứng thư số
        /// </summary>
        public Guid? sDM_ChungThuSo_Id { get; set; }

        public string sDM_ChungThuSo_Id_Ten { get; set; }
        public Guid? sPhieu_NhapSuaChuaSanPham_Id { get; set; }
        public Guid? sPhieu_XuatSuaChuaSanPham_CT_Id { get; set; }
        public Guid? sPhieu_XuatSuaChuaSanPham_Id { get; set; }
        [Code]
        public Guid? sDM_SanPham_Id { get; set; }
        public string sDM_SanPham_Id_Ten { get; set; }
        public string sDM_SanPham_Id_Ma { get; set; }

        public Guid? sDM_MangLienLac_Id { get; set; }
        public string sDM_MangLienLac_Id_Ten { get; set; }

        public Guid? sDM_NoiDungSuaChua_Id { get; set; }
        public string sDM_NoiDungSuaChua_Id_Ten { get; set; }

        public Guid? sDM_TinhTrangHongHoc_Id { get; set; }
        public string sDM_TinhTrangHongHoc_Id_Ten { get; set; }

        public string sMaVach { get; set; }

        public Guid? sDM_DonViTinh_Id { get; set; }
        public string sDM_DonViTinh_Id_Ten { get; set; }

        public decimal rSoLuong { get; set; }

        public string sSerial { get; set; }
        public string sSTTSP { get; set; }

        public decimal rDonGia { get; set; }

        public decimal rThanhTien { get; set; }

        public bool iNhapVeKho { get; set; }

        public string sGhiChu { get; set; }



        public int SortOrder { get; set; }

        public string sCauHinhKyThuat { get; set; }

        public int? iNamSX { get; set; }

        public string sXuatXu { get; set; }

        public Guid? sDM_NguonVon_Id { get; set; }
        public string sDM_NguonVon_Id_Ten { get; set; }

        public int iThoiGianBaoHanh { get; set; }
        [EnumLog("iDonViThoiGianHieuLuc")]
        public int? iDonViThoiGianBaoHanh { get; set; }

        public DateTime? dHanBaoHanhDen { get; set; }
        // Extend
        [IgnoreLog]
        public IList phieu_NhapSuaChuaSanPham_CT_PhuKiens { get; set; }
        #endregion Instance Properties
        public Phieu_NhapSuaChuaSanPham_CT()
        {
            this.DetailConfig = new string[1] { "phieu_NhapSuaChuaSanPham_CT_PhuKiens" };
        }
    }

}
