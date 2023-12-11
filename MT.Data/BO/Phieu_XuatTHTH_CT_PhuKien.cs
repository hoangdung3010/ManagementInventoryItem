﻿using System;
using MT.Library;
using System.ComponentModel.DataAnnotations;

namespace MT.Data.BO
{
    [ForeignKey("Phieu_XuatTHTH_CT", "sPhieu_XuatTHTH_CT_Id")]
    public class Phieu_XuatTHTH_CT_PhuKien : BaseEntity
    {
        #region Instance Properties
        [Key]
        public Guid Id { get; set; }

        public Guid? sPhieu_XuatTHTH_CT_Id { get; set; }
        public string sPhieu_XuatTHTH_Id_Ten { get; set; }
        public Guid? sDM_SanPham_Id { get; set; }
        public string sDM_SanPham_Id_Ten { get; set; }
        public Guid? sDM_PhuKien_Id { get; set; }
        public string sDM_PhuKien_Id_Ten { get; set; }
        public Guid? sDM_DonViTinh_Id { get; set; }
        public string sDM_DonViTinh_Id_Ten { get; set; }
        public decimal? rSoLuong { get; set; }

        public decimal? rDonGia { get; set; }

        public decimal? rThanhTien { get; set; }

        public string sXuatXu { get; set; }

        public string sGhiChu { get; set; }

        public bool? bDeleted { get; set; }
        public decimal rSoLuongPhuKienTren1SP { get; set; }

        public int SortOrder { get; set; }
        #endregion Instance Properties
    }

}
