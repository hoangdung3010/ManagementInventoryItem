using System;
using MT.Library;
using System.ComponentModel.DataAnnotations;
using System.Collections;

namespace MT.Data.BO
{
    public class Phieu_NhapSanPhamMoi : BaseEntity
    {
        #region Instance Properties
        [Key]
        public Guid Id { get; set; }

        public string sSo { get; set; }

        public string sChu { get; set; }
        public string sMa { get; set; }

        public string sSo_KH { get; set; }

        public string sChu_KH { get; set; }
        public string sMa_KH { get; set; }

        public DateTime? dNgayPhieu_NhapSanPhamMoi { get; set; }

        public Guid? sKH_NhapSanPhamMoi_Id_CanCu { get; set; }
        public string sKH_NhapSanPhamMoi_Id_CanCu_Ten { get; set; }
        public Guid? sDM_NhaCC_Id { get; set; }

        public string sDM_NhaCC_Id_Ten { get; set; }

        public string sNguoiGiao { get; set; }

        public Guid? sDM_DonVi_Id_Nhap { get; set; }

        public string sDM_DonVi_Id_Nhap_Ten { get; set; }

        public Guid? sDM_CanBo_Id_NguoiNhap { get; set; }

        public string sDM_CanBo_Id_NguoiNhap_Ten { get; set; }

        public Guid? sDM_CanBo_Id_NguoiLapPhieu { get; set; }

        public string sDM_CanBo_Id_NguoiLapPhieu_Ten { get; set; }
        public Guid? sDM_CanBo_Id_NguoiDuyet { get; set; }

        public string sDM_CanBo_Id_NguoiDuyet_Ten { get; set; }

        public decimal rThanhTien { get; set; }

        public string sGhiChu { get; set; }

        public IList phieu_NhapSanPhamMoi_CT { get; set; }

        public bool iNhapVeKho { get; set; }

        public int iTrangThaiDuyet { get; set; }

        public DateTime? dNgayDuyet { get; set; }
        public string sLyDoXetDuyet { get; set; }

        /// <summary>
        /// Người sở hữu bản ghi
        /// </summary>
        public Guid sDM_CanBo_Id_SoHuu { get; set; }

        /// <summary>
        /// Đơn vị sở hữu bản ghi
        /// </summary>
        public Guid sDM_DonVi_Id_SoHuu { get; set; }

        #endregion Instance Properties

        #region"Contructors"
        public Phieu_NhapSanPhamMoi()
        {
            this.DetailConfig = new string[1] { "phieu_NhapSanPhamMoi_CT" };
        }
        #endregion
    }

}
