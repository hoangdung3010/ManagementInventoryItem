﻿using System;
using MT.Library;
using System.ComponentModel.DataAnnotations;
using System.Collections;

namespace MT.Data.BO
{
    [ForeignKey("Phieu_NhapMuonTra", "sPhieu_NhapMuonTra_Id")]
    public class Phieu_NhapMuonTra_CT : BaseEntity
    {
        #region Instance Properties

        [Key]
        public Guid Id { get; set; }
        /// <summary>
        /// FK_Chứng thư số
        /// </summary>
        public Guid? sDM_ChungThuSo_Id { get; set; }

        public string sDM_ChungThuSo_Id_Ten { get; set; }
        public Guid? sPhieu_NhapMuonTra_Id { get; set; }
        public string sPhieu_NhapMuonTra_Id_Ten { get; set; }
        public Guid? sPhieu_XuatMuonTra_CT_Id { get; set; }
        public string sPhieu_XuatMuonTra_CT_Id_Ten { get; set; }
        public Guid? sPhieu_XuatMuonTra_Id { get; set; }
        public string sPhieu_XuatMuonTra_Id_Ten { get; set; }
        public Guid? sDM_SanPham_Id { get; set; }
        [Code]
        public string sDM_SanPham_Id_Ten { get; set; }
        public string sDM_SanPham_Id_Ma { get; set; }
        public Guid? sDM_MangLienLac_Id { get; set; }
        public string sDM_MangLienLac_Id_Ten { get; set; }
        public string sMaVach { get; set; }
        public Guid? sDM_DonViTinh_Id { get; set; }
        public string sDM_DonViTinh_Id_Ten { get; set; }

        public decimal rSoLuong { get; set; }
        public string sSerial { get; set; } // note
        public string sSTTSP { get; set; } // note
        public decimal rDonGia { get; set; }

        public decimal rThanhTien { get; set; }
        public bool? iNhapVeKho { get; set; } // note
        public string sGhiChu { get; set; }

        public bool? bDeleted { get; set; }

        //---------Noteeeeeeeeee---------
        // Nhung truong du thua nay sau se duoc load tu dong
        public int SortOrder { get; set; }

        public string sCauHinhKyThuat { get; set; }
        public string sXuatXu { get; set; }
        public int? iNamSX { get; set; }
        public Guid? sDM_NguonVon_Id { get; set; }
        public string sDM_NguonVon_Id_Ten { get; set; }
        public int iThoiGianBaoHanh { get; set; }
        [EnumLog("iDonViThoiGianBaoHanh")]
        public int iDonViThoiGianBaoHanh { get; set; }
        public DateTime? dHanBaoHanhDen { get; set; }

        //-------end note---------
        [IgnoreLog]
        public IList phieu_NhapMuonTra_CT_PhuKiens { get; set; }

        public Phieu_NhapMuonTra_CT()
        {
            this.DetailConfig = new string[1] { "phieu_NhapMuonTra_CT_PhuKiens" };
        }

        #endregion Instance Properties
    }
}