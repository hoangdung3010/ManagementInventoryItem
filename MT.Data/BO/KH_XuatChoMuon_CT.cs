﻿using System;
using MT.Library;
using System.ComponentModel.DataAnnotations;
using System.Collections;

namespace MT.Data.BO
{
    [ForeignKey("KH_XuatChoMuon_CT", "sKH_XuatChoMuon_Id")]
    public class KH_XuatChoMuon_CT : BaseEntity
    {
        #region Instance Properties

        [Key]
        public Guid Id { get; set; }

        public Guid? sKH_XuatChoMuon_Id { get; set; }
        public string sKH_XuatChoMuon_Id_Ten { get; set; }
        public Guid sDM_DonVi_Id_DonViNhap { get; set; }
        public string sDM_DonVi_Id_DonViNhap_Ten { get; set; }
        public Guid? sDM_SanPham_Id { get; set; }
        [Code]
        public string sDM_SanPham_Id_Ten { get; set; }
        public Guid? sDM_MangLienLac_Id { get; set; }
        public string sDM_MangLienLac_Id_Ten { get; set; }
        public Guid? sDM_DonViTinh_Id { get; set; }
        public string sDM_DonViTinh_Id_Ten { get; set; } //sDM_HangMucBaoDam_Id
        public string sSerial { get; set; } // note
        public decimal rSoLuong { get; set; }
        public decimal rDonGia { get; set; }
        public decimal rThanhTien { get; set; }
        public string sXuatXu { get; set; }
        public string sGhiChu { get; set; }
        public bool? bDeleted { get; set; }
        public string sCauHinhKyThuat { get; set; }// Notee
        public int? iNamSX { get; set; }
        public int iThoiGianBaoHanh { get; set; }
        [EnumLog("iDonViThoiGianBaoHanh")]
        public int iDonViThoiGianBaoHanh { get; set; }
        public DateTime? dHanBaoHanhDen { get; set; }
        public bool IsShowSoSerial { get; set; }
        public int iKichThuocDongGoi { get; set; }
        [IgnoreLog]
        public IList kH_XuatChoMuon_CT_PhuKiens { get; set; }
        //public IList kH_NhapSanPhamMoi_CT_PhuKiens { get; set; }
        public KH_XuatChoMuon_CT()
        {
            this.DetailConfig = new string[1] { "kH_XuatChoMuon_CT_PhuKiens" };
        }

        #endregion Instance Properties
    }
}