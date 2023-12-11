using MT.Library;
using System;
using System.ComponentModel.DataAnnotations;

namespace MT.Data.BO
{
    public class DM_ThamSoMatMa : MT.Library.BaseEntity
    {
        [Key]
        public Guid Id { get; set; }

        [Code]
        public string sMaThamSoMatMa { get; set; }

        public string sTenThamSoMatMa { get; set; }

        public int iThoiHanSuDung { get; set; }

        [EnumLog("iDonViThoiGianHieuLuc")]
        public int iDonViThoiGianHieuLuc { get; set; }
        public DateTime? dNgayHieuLuc { get; set; }

        public DateTime? dNgayHetHan { get; set; }
        public string sGhiChu { get; set; }
    }

}
