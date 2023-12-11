using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MT.ObjectDataSource
{
   public class Phieu_NhapSanPhamMoi_CT_PhuKienDataSource : ReportDataSource
    {
        #region Instance Properties
        public Guid Id { get; set; }

        public Guid? sPhieu_NhapSanPhamMoi_CT_Id { get; set; }

        public string sDM_SanPham_Id_Ten { get; set; }

        public string sDM_PhuKien_Id_Ten { get; set; }
        public string sDM_DonViTinh_Id_Ten { get; set; }
        public decimal rSoLuong { get; set; }

        public decimal rDonGia { get; set; }

        public decimal rThanhTien { get; set; }

        public string sXuatXu { get; set; }

        public string sGhiChu { get; set; }

        public int SortOrder { get; set; }

        #endregion Instance Properties
    }
}
