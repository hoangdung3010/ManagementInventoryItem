using System;
using MT.Library;
using System.ComponentModel.DataAnnotations;
using System.Collections;

namespace MT.Data.BO
{
    public class Phieu_NhapCaiDatSanPham : BaseEntity
    {
        #region Instance Properties
        [Key]
        public Guid Id { get; set; }
        [IgnoreLog]
        public int? iLoai { get; set; }

        public Guid? sPhieu_XuatSanPham_Id_CanCu { get; set; }

        public string sMa_PX { get; set; }

        public string sSo_PX { get; set; }

        public string sChu_PX { get; set; }

        public string sSo { get; set; }

        public string sChu { get; set; }
        [Code]
        public string sMa { get; set; }

        public DateTime? dNgayPhieu_Nhap { get; set; }

        public Guid sDM_DonVi_Id_Xuat { get; set; }

        public string sDM_DonVi_Id_Xuat_Ten { get; set; }

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

        public bool? iNhapVeKho { get; set; }

        public string sGhiChu { get; set; }
        [EnumLog("iTrangThaiDuyetKHNM")]
        public int iTrangThaiDuyet { get; set; }
        public DateTime? dNgayDuyet { get; set; }

        public string sLyDoXetDuyet { get; set; }
        [IgnoreLog]
        public IList phieuNhapCaiDatSanPham_CTs { get; set; }


        /// <summary>
        /// Người sở hữu bản ghi
        /// </summary>
        public Guid sDM_CanBo_Id_SoHuu { get; set; }

        /// <summary>
        /// Đơn vị sở hữu bản ghi
        /// </summary>
        public Guid sDM_DonVi_Id_SoHuu { get; set; }

        #endregion Instance Properties

        public Phieu_NhapCaiDatSanPham()
        {
            this.DetailConfig = new string[1] { "phieuNhapCaiDatSanPham_CTs" };
        }
    }

}
