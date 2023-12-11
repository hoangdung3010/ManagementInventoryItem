using System;
using MT.Library;
using System.ComponentModel.DataAnnotations;
using System.Collections;

namespace MT.Data.BO
{
    public class Phieu_XuatMuonTra : BaseEntity
    {
        #region Instance Properties

        [Key]
        public Guid Id { get; set; }

        public Guid? sKH_XuatMuonTra_Id_CanCu { get; set; }
        public string sKH_XuatMuonTra_Id_CanCu_Ten { get; set; }
        public string soKHX { get; set; } // Note Phieu_XuatMuonTra_CTRepository
        public string sMa_KH { get; set; }
        public string sSo_KH { get; set; }
        public string sChu_KH { get; set; }
        [Code]
        public string sMa { get; set; }
        public string sSo { get; set; }
        public string sChu { get; set; }
        public DateTime? dNgayPhieu_Xuat { get; set; }
        public Guid sDM_DonVi_Id_Xuat { get; set; }
        public string sDM_DonVi_Id_Xuat_Ten { get; set; } //sDM_SanPham_Id_Ten

        //public string sDM_SanPham_Id_Ten { get; set; } //sDM_SanPham_Id_Ten
        public Guid? sDM_CanBo_Id_NguoiGiao { get; set; }

        public string sDM_CanBo_Id_NguoiGiao_Ten { get; set; }
        public Guid sDM_DonVi_Id_Nhap { get; set; }
        public string sDM_DonVi_Id_Nhap_Ten { get; set; }
        public Guid? sDM_CanBo_Id_NguoiNhap { get; set; }
        public string sDM_CanBo_Id_NguoiNhap_Ten { get; set; }
        public Guid? sDM_CanBo_Id_NguoiLapPhieu { get; set; }
        public string sDM_CanBo_Id_NguoiLapPhieu_Ten { get; set; }
        public Guid? sDM_CanBo_Id_NguoiDuyet { get; set; }
        public string sDM_CanBo_Id_NguoiDuyet_Ten { get; set; }
        public decimal? rThanhTien { get; set; }

        //public Guid sMaPhieu_XuatMuonTra { get; set; }
        public string sGhiChu { get; set; }

        public bool? bDeleted { get; set; }
        [IgnoreLog]
        public IList phieu_XuatMuonTra_CTs { get; set; }
        [EnumLog("iTrangThaiDuyet")]
        public int iTrangThaiDuyet { get; set; }
        public DateTime? dNgayDuyet { get; set; }
        public string sLyDoXetDuyet { get; set; }
        [EnumLog("iTrangThaiThucHienKHNM")]
        public int iTrangThaiThucHienKHNM { get; set; }
        [EnumLog("iTCXuat")]
        public int iTCXuat { get; set; }  // Chú ý: dùng để phân biệt giữa các loại phiếu xuất

        /// <summary>
        /// Người sở hữu bản ghi
        /// </summary>
        public Guid sDM_CanBo_Id_SoHuu { get; set; }

        /// <summary>
        /// Đơn vị sở hữu bản ghi
        /// </summary>
        public Guid sDM_DonVi_Id_SoHuu { get; set; }
        #endregion Instance Properties

        public Phieu_XuatMuonTra()
        {
            this.DetailConfig = new string[1] { "phieu_XuatMuonTra_CTs" };
        }
    }
}