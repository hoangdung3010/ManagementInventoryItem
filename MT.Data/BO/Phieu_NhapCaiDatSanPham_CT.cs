using System;
using MT.Library;
using System.ComponentModel.DataAnnotations;
using System.Collections;

namespace MT.Data.BO
{
    [ForeignKey("Phieu_NhapCaiDatSanPham", "sPhieu_NhapCaiDatSanPham_Id")]
    public class Phieu_NhapCaiDatSanPham_CT : BaseEntity
    {
        #region Instance Properties
        [Key]
        public Guid Id { get; set; }
        /// <summary>
        /// FK_Chứng thư số
        /// </summary>
        public Guid? sDM_ChungThuSo_Id { get; set; }

        public string sDM_ChungThuSo_Id_Ten { get; set; }
        public Guid? sPhieu_NhapCaiDatSanPham_Id { get; set; }

        public Guid? sPhieu_XuatCaiDatSanPham_Id { get; set; }

        public Guid? sPhieu_XuatCaiDatSanPham_CT_Id { get; set; }
        [Code]
        public Guid? sDM_SanPham_Id { get; set; }

        public string sDM_SanPham_Id_Ma { get; set; }
        public string sDM_SanPham_Id_Ten { get; set; }

        public Guid? sDM_MangLienLac_Id { get; set; }

        public string sDM_MangLienLac_Id_Ten { get; set; }

        public Guid? sDM_NoiDungCaiDat_Id { get; set; }

        public string sDM_NoiDungCaiDat_Id_Ten { get; set; }

        public string sTinhTrangCaiDat { get; set; }

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

        public int iNamSX { get; set; }

        public string sXuatXu { get; set; }

        public Guid? sDM_NguonVon_Id { get; set; }
        public string sDM_NguonVon_Id_Ten { get; set; }

        public int iThoiGianBaoHanh { get; set; }
        [EnumLog("iDonViThoiGianHieuLuc")]
        public int iDonViThoiGianBaoHanh { get; set; }

        public DateTime? dHanBaoHanhDen { get; set; }
        
        [IgnoreLog]
        public IList phieuNhapCaiDatSanPham_CT_PhuKiens { get; set; }
        #endregion Instance Properties

        public Phieu_NhapCaiDatSanPham_CT()
        {
            this.DetailConfig = new string[1] { "phieuNhapCaiDatSanPham_CT_PhuKiens" };
        }
    }

}
