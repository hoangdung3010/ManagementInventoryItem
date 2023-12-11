using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MT.Data.BO
{
    /// <summary>
    /// Đối tượng lưu số tồn kho
    /// </summary>
    public class TonKhoViewModel
    {
        public Guid sDM_SanPham_Id { get; set; }

        public string sDM_SanPham_Ma { get; set; }

        public string sDM_SanPham_Id_Ten { get; set; }

        public string sMaVach { get; set; }

        public Guid sDM_DonViTinh_Id { get; set; }

        public string sDM_DonViTinh_Id_Ten { get; set; }

        public decimal rSoLuongTon { get; set; }

        public decimal rSoLuongTongTon { get; set; }

        public string sDM_DonVi_Id_Ten { get; set; }
    }
}
