using System;
using MT.Library;
using System.ComponentModel.DataAnnotations;
using System.Collections;

namespace MT.Data.BO
{
    [ForeignKey("KH_SuaChuaSanPham", "sKH_SuaChuaSanPham_Id")]
    public class KH_SuaChuaSanPham_CT : BaseEntity
    {
        #region Instance Properties
        [Key]
        public Guid Id { get; set; }

        public Guid? sKH_SuaChuaSanPham_Id { get; set; }
        public string sKH_SuaChuaSanPham_Id_Ten { get; set; }
        [Code]
        public Guid? sDM_SanPham_Id { get; set; }
        public string sDM_SanPham_Id_Ten { get; set; }

        public Guid? sDM_NoiDungSuaChua_Id { get; set; }
        public string sDM_NoiDungSuaChua_Id_Ten { get; set; }

        public Guid? sDM_TinhTrangHongHoc_Id { get; set; }
        public string sDM_TinhTrangHongHoc_Id_Ten { get; set; }

        public Guid? sDM_MangLienLac_Id { get; set; }
        public string sDM_MangLienLac_Id_Ten { get; set; }

        public Guid? sDM_DonViTinh_Id { get; set; }
        public string sDM_DonViTinh_Id_Ten { get; set; }

        public decimal rSoLuong { get; set; }

        public decimal rDonGia { get; set; }

        public decimal rThanhTien { get; set; }

        public string sXuatXu { get; set; }

        public string sGhiChu { get; set; }

        public int SortOrder { get; set; }
        [IgnoreLog]
        public IList kH_SuaChuaSanPham_CT_PhuKiens { get; set; }
        #endregion Instance Properties
        #region"Contructors"
        public KH_SuaChuaSanPham_CT()
        {
            this.DetailConfig = new string[1] { "kH_SuaChuaSanPham_CT_PhuKiens" };
        }
        #endregion
    }

}
