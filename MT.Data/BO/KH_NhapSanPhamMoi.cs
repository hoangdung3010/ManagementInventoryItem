using System;
using MT.Library;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Collections;

namespace MT.Data.BO
{
    public class KH_NhapSanPhamMoi : BaseEntity
    {
        #region Instance Properties
        [Key]
        public Guid Id { get; set; }

        [Code]
        public string sMa{ get; set; }

        public string sSo { get; set; }

        public string sChu { get; set; }

        public DateTime dNgayLap { get; set; }
        public Guid sDM_DonVi_Id_DonViXayDungKH { get; set; }

        public string sDM_DonVi_Id_DonViXayDungKH_Ten { get; set; }
        public Guid sDM_NhaCC_Id { get; set; }

        public string sDM_NhaCC_Id_Ten { get; set; }

        public Guid? sDM_HinhThucLCNT_Id { get; set; }

        public string sDM_HinhThucLCNT_Id_Ten { get; set; }

        public Guid? sDM_NguonVon_Id { get; set; }

        public string sDM_NguonVon_Id_Ten { get; set; }

        public Guid? sDM_CanBo_Id_NguoiLapKH { get; set; }

        public string sDM_CanBo_Id_NguoiLapKH_Ten { get; set; }

        public Guid? sDM_CanBo_Id_NguoiDuyet { get; set; }

        public string sDM_CanBo_Id_NguoiDuyet_Ten { get; set; }

        public Guid? sDM_CanBo_Id_ThuTruongDonVi { get; set; }

        public string sDM_CanBo_Id_ThuTruongDonVi_Ten { get; set; }

        public Guid? sDM_DonVi_Id_DonViNhap { get; set; }

        public string sDM_DonVi_Id_DonViNhap_Ten { get; set; }

        public string sSoHopDong { get; set; }

        public DateTime? dNgayHopDong { get; set; }

        
        public int? iThoiGianHieuLuc { get; set; }

        [EnumLog("iDonViThoiGianHieuLuc")]
        public int iDonViThoiGianHieuLuc { get; set; }
        public string sGhiChu { get; set; }

        [IgnoreLog]
        public IList kH_NhapSanPhamMoi_CTs { get; set; }

        [EnumLog("iTrangThaiDuyetKHNM")]
        public int iTrangThaiDuyet { get; set; }

        public DateTime? dNgayDuyet { get; set; }
        public string sLyDoXetDuyet { get; set; }

        [EnumLog("iTrangThaiThucHienKHNM")]
        public int iTrangThaiThucHienKHNM { get; set; }

        public decimal rThanhTien { get; set; }

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
        public KH_NhapSanPhamMoi()
        {
            this.DetailConfig = new string[1] { "kH_NhapSanPhamMoi_CTs" };
        }
        #endregion
    }

}
