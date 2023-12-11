using System;
using MT.Library;
using System.ComponentModel.DataAnnotations;
using System.Collections;

namespace MT.Data.BO
{
    [ForeignKey("KH_XuatSanPham", "sKH_XuatSanPham_Id")]
    public class KH_XuatSanPham_CT : BaseEntity
    {
        #region Instance Properties

        [Key]
        public Guid Id { get; set; }

        public Guid? sKH_XuatSanPham_Id { get; set; }
        public string sKH_XuatSanPham_Id_Ten { get; set; }
        public Guid? sKH_XuatBaoDam_CT_Id { get; set; }
        public string sKH_XuatBaoDam_CT_Id_Ten { get; set; } //sKH_XuatBaoDam_Id
        public Guid? sKH_XuatBaoDam_Id { get; set; }
        public string sKH_XuatBaoDam_Id_Ten { get; set; } //sKH_XuatBaoDam_Id
        public Guid? sDM_SanPham_Id { get; set; }
        
        private string _sDM_SanPham_Id_Ten;
        [Code]
        public string sDM_SanPham_Id_Ten
        {
            get
            {
                return _sDM_SanPham_Id_Ten;
            }
            set
            {
                _sDM_SanPham_Id_Ten = value;
            }
        }

        public Guid? sDM_MangLienLac_Id { get; set; }
        public string sDM_MangLienLac_Id_Ten { get; set; }
        public Guid? sDM_DonViTinh_Id { get; set; }
        public string sDM_DonViTinh_Id_Ten { get; set; }
        public Guid? sDM_HangMucBaoDam_Id { get; set; }
        public string sDM_HangMucBaoDam_Id_Ten { get; set; }
        public string sSerial { get; set; } // note
        public string sSTTSP { get; set; } // note
        public decimal rSoLuong { get; set; }

        public decimal rDonGia { get; set; }

        public decimal rThanhTien { get; set; }

        public string sXuatXu { get; set; }

        public string sGhiChu { get; set; }

        public bool? bDeleted { get; set; }
        public string sCauHinhKyThuat { get; set; }// Notee
        public int? iNamSX { get; set; }
        public bool IsShowSoSerial { get; set; }
        public int iKichThuocDongGoi { get; set; }
        [IgnoreLog]
        public IList kH_XuatSanPham_CT_PhuKiens { get; set; }

        //---------Noteeeeeeeeee---------
        // Nhung truong du thua nay sau se duoc load tu dong
        public int SortOrder { get; set; }

        public int iThoiGianBaoHanh { get; set; }
        [EnumLog("iDonViThoiGianBaoHanh")]
        public int iDonViThoiGianBaoHanh { get; set; }
        public DateTime? dHanBaoHanhDen { get; set; }

        public KH_XuatSanPham_CT()
        {
            this.DetailConfig = new string[1] { "kH_XuatSanPham_CT_PhuKiens" };
        }

        #endregion Instance Properties
    }
}