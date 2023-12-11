using MT.Library;
using System;

namespace MT.Data.BO
{
    public class SoKhoViewModel
    {
        #region Instance Properties

        public Guid Id { get; set; }

        public Guid? sDM_DonVi_Id { get; set; }

        public string sDM_DonVi_Id_Ten { get; set; }

        public int? iLoaiPhieu { get; set; }

        public Guid? sPhieu_Id { get; set; }

        public DateTime? dNgayPhieu { get; set; }

        public string sSo { get; set; }

        public string sChu { get; set; }

        public string sMa { get; set; }

        public bool iNhapVeKho { get; set; }

        public Guid? sPhieu_Detail_Id { get; set; }

        public Guid? sDM_SanPham_Id { get; set; }
        public string sDM_SanPham_Ma { get; set; }
        public string sDM_SanPham_Id_Ten { get; set; }

        public string sMaVach { get; set; }

        public Guid? sDM_DonViTinh_Id { get; set; }

        public string sDM_DonViTinh_Id_Ten { get; set; }

        public decimal rSoLuong_Nhap { get; set; }

        public decimal rDonGia_Nhap { get; set; }

        public decimal rThanhTien_Nhap { get; set; }

        public decimal rSoLuong_Xuat { get; set; }

        public decimal rDonGia_Xuat { get; set; }

        public decimal rThanhTien_Xuat { get; set; }

        public string sCauHinhKyThuat { get; set; }

        public string sXuatXu { get; set; }

        public int? iNamSX { get; set; }

        public int iThoiGianBaoHanh { get; set; }

        public int iDonViThoiGianBaoHanh { get; set; }

        public DateTime? dHanBaoHanhDen { get; set; }

        /// <summary>
        /// sDM_DonVi_Id+sDM_SanPham_Id+sDM_DonViTinh_Id
        /// </summary>
        public Guid? sMd5Id { get; set; }

        public int SortOrder { get; set; }

        public DateTime? dCreatedDate { get; set; }

        public DateTime? dModifiedDate { get; set; }
        public string sModifiedBy { get; set; }
        public string sCreatedBy { get; set; }

        public Guid? sDM_MangLienLac_Id { get; set; }

        public string sDM_MangLienLac_Id_Ten { get; set; }

        /// <summary>
        /// =1 là phiếu xuất, ngược lại là phiếu nhập
        /// </summary>
        public bool bPhieuXuat { get; set; }

        /// <summary>
        /// bPhieuXuat=1 thì Lưu đơn vị xuất đến của px, ngược lại lưu đơn vị xuất của phiếu nhập
        /// </summary>
        public Guid? sDM_DonVi_Id_Nguon { get; set; }

        public string sDM_DonVi_Id_Nguon_Ten { get; set; }

        public string sGhiChu { get; set; }

        public Guid? sDM_ChungThuSo_Id { get; set; }

        public string sDM_ChungThuSo_Id_Ten { get; set; }
        public string sSerial { get; set; }

        public string sSTTSP { get; set; }

        #endregion Instance Properties
    }

}
