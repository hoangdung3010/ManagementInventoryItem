using MT.Library;
using System;
using System.ComponentModel.DataAnnotations;

namespace MT.Data.BO
{
    public class DM_SanPham : MT.Library.BaseEntity
    {
        [Key]
        public Guid Id { get; set; }

        [Code]
        public string sMaSanPham { get; set; }

        public string sTenSanPham { get; set; }

        public Guid? sDM_NhaCC_Id { get; set; }

        public string sDM_NhaCC_Id_Ten { get; set; }

        public Guid? sDM_NhomSanPham_Id { get; set; }

        public string sDM_NhomSanPham_Id_Ten { get; set; }

        public Guid? sDM_DonViTinh_Id_Cap1 { get; set; }

        public string sDM_DonViTinh_Id_Cap1_Ten { get; set; }
        public decimal rDonGia_Cap1 { get; set; }
        public int iKichThuocDongGoi { get; set; }
        public Guid? sDM_DonViTinh_Id_Cap2 { get; set; }
        public string sDM_DonViTinh_Id_Cap2_Ten { get; set; }

        public decimal rDonGia_Cap2 { get; set; }

        public string sCauHinhKyThuat { get; set; }

        public string sXuatXu { get; set; }

        public string sGhiChu { get; set; }
        public bool bKepChi { get; set; }


        public int iNamSX { get; set; }

        public decimal rSoNamSuDung { get; set; }
    }

}
