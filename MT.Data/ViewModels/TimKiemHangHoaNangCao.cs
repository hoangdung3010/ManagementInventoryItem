using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MT.Data.ViewModels
{
   public class TimKiemHangHoaNangCao
    {
        public string sMaVach { get; set; }

        public string sMaSanPham { get; set; }
        public string sTenSanPham { get; set; }

        public string sDM_MangLienLac_Id_Ten { get; set; }

        public string sDM_DonViTinh_Id_Ten { get; set; }

        public int iNamSX { get; set; }

        public string sXuatXu { get; set; }

        public string sGhiChu { get; set; }

        public int iTrangThai { get; set; }

        public string sDM_DonVi_Id_Nhap_Ten_CuoiCung { get; set; }

        public string sDM_DonVi_Id_Nhap_Ten_PX { get; set; }
    }
}
