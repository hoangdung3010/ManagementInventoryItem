using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MT.ObjectDataSource
{
   public class KH_NhapSanPhamMoi_CTDataSource : ReportDataSource
    {
        #region Instance Properties
        public Guid Id { get; set; }

        public Guid sKH_NhapSanPhamMoi_CT_Id { get; set; }

        public string sDM_SanPham_Id_Ma { get; set; }
        public string sDM_SanPham_Id_Ten { get; set; }

        public string sDM_DonViTinh_Id_Ten { get; set; }
        public decimal rSoLuong { get; set; }

        public decimal rDonGia { get; set; }

        public decimal rThanhTien { get; set; }

        public string sXuatXu { get; set; }

        public string sCauHinhKyThuat { get; set; }

        public int? iNamSX { get; set; }

        public string sGhiChu { get; set; }

        public int SortOrder { get; set; }

        public List<KH_NhapSanPhamMoi_CT_PhuKienDataSource> PhuKiens { get; set; }

        #endregion Instance Properties

    }
}
