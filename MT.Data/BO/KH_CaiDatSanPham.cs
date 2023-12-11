using System;
using MT.Library;
using System.ComponentModel.DataAnnotations;
using System.Collections;

namespace MT.Data.BO
{
    public class KH_CaiDatSanPham : BaseEntity
    {
        #region Instance Properties
        [Key]
        public Guid Id { get; set; }
        [Code]
        public string sMa { get; set; }
        public string sSo { get; set; }

        public string sChu { get; set; }


        public DateTime? dNgayKeHoach { get; set; }

        public int? iThoiGianHieuLuc { get; set; }

        [EnumLog("iDonViThoiGianHieuLuc")]

        public int? iDonViThoiGianHieuLuc { get; set; }

        public Guid sDM_DonVi_Id_DonViXayDungKH { get; set; }

        public string sDM_DonVi_Id_DonViXayDungKH_Ten { get; set; }

        public Guid sDM_DonVi_Id_DonViXuat { get; set; }

        public string sDM_DonVi_Id_DonViXuat_Ten { get; set; }

        public Guid sDM_DonVi_Id_DonViNhap { get; set; }

        public string sDM_DonVi_Id_DonViNhap_Ten { get; set; }

        public Guid? sDM_CanBo_Id_NguoiLapKH { get; set; }

        public string sDM_CanBo_Id_NguoiLapKH_Ten { get; set; }

        public Guid? sDM_CanBo_Id_NguoiDuyet { get; set; }

        public string sDM_CanBo_Id_NguoiDuyet_Ten { get; set; }

        public Guid? sDM_CanBo_Id_ThuTruongDonVi { get; set; }

        public string sDM_CanBo_Id_ThuTruongDonVi_Ten { get; set; }

        public string sGhiChu { get; set; }
        [EnumLog("iTrangThaiDuyetKHCĐSP")]
        public int iTrangThaiDuyet { get; set; }
        [EnumLog("iTrangThaiThucHienKHCDSP")]
        public int iTrangThaiThucHienKHCD { get; set; }
        public DateTime? dNgayDuyet { get; set; }

        public string sLyDoXetDuyet { get; set; }
        [IgnoreLog]
        public IList khCaiDatSanPham_CTs { get; set; }


        /// <summary>
        /// Người sở hữu bản ghi
        /// </summary>
        public Guid sDM_CanBo_Id_SoHuu { get; set; }

        /// <summary>
        /// Đơn vị sở hữu bản ghi
        /// </summary>
        public Guid sDM_DonVi_Id_SoHuu { get; set; }

        #endregion Instance Properties

        public KH_CaiDatSanPham()
        {
            this.DetailConfig = new string[1] { "khCaiDatSanPham_CTs" };
        }
    }

}
