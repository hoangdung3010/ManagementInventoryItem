using System;
using MT.Library;
using System.ComponentModel.DataAnnotations;
using System.Collections;

namespace MT.Data.BO
{
    [ForeignKey("KH_NhapSanPhamMoi", "sKH_NhapSanPhamMoi_Id")]
    public class KH_NhapSanPhamMoi_CT : BaseEntity
    {
        #region Instance Properties
        [Key]
        public Guid Id { get; set; }

        public Guid sKH_NhapSanPhamMoi_Id { get; set; }

        public Guid? sDM_SanPham_Id { get; set; }

        [Code]
        public string sDM_SanPham_Id_Ten { get; set; }


        public Guid? sDM_DonViTinh_Id { get; set; }

        public string sDM_DonViTinh_Id_Ten { get; set; }
        public decimal rSoLuong { get; set; }

        public decimal rDonGia { get; set; }

        public decimal rThanhTien { get; set; }

        public string sXuatXu { get; set; }

        public string sCauHinhKyThuat { get; set; }  

        public int? iNamSX { get; set; }

        public string sGhiChu { get; set; }
        public IList kH_NhapSanPhamMoi_CT_PhuKiens { get; set; }

        public bool IsShowSoSerial { get; set; }
        public int iKichThuocDongGoi { get; set; }

        public int SortOrder { get; set; }

        #endregion Instance Properties
        #region"Contructors"
        public KH_NhapSanPhamMoi_CT()
        {
            this.DetailConfig = new string[1] { "kH_NhapSanPhamMoi_CT_PhuKiens" };
        }
        #endregion
       
}

}
