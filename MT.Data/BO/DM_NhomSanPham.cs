using MT.Library;
using System;
using System.ComponentModel.DataAnnotations;

namespace MT.Data.BO
{
    public class DM_NhomSanPham : MT.Library.BO.MTTree<Guid>
    {
        [Key]
        public override Guid Id { get; set; }
        public Guid? sParentId { get; set; }
        public string sParentId_Ten { get; set; }

        [Code]
        public string sTenNhomSanPham { get; set; }

        public string sMaNhomSanPham { get; set; }

        public string sGhiChu { get; set; }
    }

}
