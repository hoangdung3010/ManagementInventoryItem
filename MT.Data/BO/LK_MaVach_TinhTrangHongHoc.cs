using System;
using MT.Library;
using System.ComponentModel.DataAnnotations;

namespace MT.Data.BO
{
    public class LK_MaVach_TinhTrangHongHoc : BaseEntity
    {
        #region Instance Properties
        [Key]
        public Guid Id { get; set; }

        public string sMaVach { get; set; }

        // Phần Cài đặt sản phẩm
        public Guid? sDM_NoiDungCaiDat_Id { get; set; }
        public String sTinhTrangCaiDat { get; set; }

        // Phần Sửa chữa sản phẩm
        public Guid? sDM_NoiDungSuaChua_Id { get; set; }
        public Guid? sDM_TinhTrangHongHoc_Id { get; set; }

        // Phần Bảo hành sản phẩm
        public Guid? sDM_NoiDungBaoHanh_Id { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        #endregion Instance Properties
    }

}
