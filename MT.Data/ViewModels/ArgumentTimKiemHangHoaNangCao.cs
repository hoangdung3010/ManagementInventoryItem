using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MT.Data.ViewModels
{
   public class ArgumentTimKiemHangHoaNangCao
    {
        public string sMaSanPham { get; set; } = string.Empty;

        public Guid? sDM_SanPham_Id { get; set; }

        public Guid? sDM_MangLienLac_Id { get; set; }

        public string sMaVach { get; set; } = string.Empty;

        public int? iNamSX { get; set; }

        public string sXuatXu { get; set; } = string.Empty;

        public int iTrangThai { get; set; }

        //Đơn vị được cấp sử dụng
        public Guid? sDM_DonVi_Id_Nhap { get; set; }

        //Ví trị sản phẩm
        public Guid? sDM_DonVi_Id_Xuat { get; set; }

        public string sGhiChu { get; set; }

    }
}
