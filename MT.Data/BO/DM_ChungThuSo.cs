using System;
using MT.Library;
using System.ComponentModel.DataAnnotations;

namespace MT.Data.BO
{
    public class DM_ChungThuSo : BaseEntity
    {
        #region Instance Properties
        [Key]
        public Guid Id { get; set; }

        [Code]
        public string sMaCTS { get; set; }
        public string sHoSo { get; set; }
        public string sMaVach { get; set; }

        public string sSerialNumber { get; set; }

        public string sPassword { get; set; }

        public string sMasterCode { get; set; }

        public string sChuNhan { get; set; }

        public string sEmail { get; set; }
        public string sTenToChucCap1 { get; set; }

        public string sTenToChucCap2 { get; set; }

        public string sTenToChucCap3 { get; set; }

        public string sTenToChucCap4 { get; set; }

        public string sDiaChi { get; set; }

        public string sTenNguoi { get; set; }

        public DateTime dNgayBatDau { get; set; }

        public DateTime dNgayKetThuc { get; set; }

        public string sGhiChu { get; set; }
        #endregion Instance Properties
    }

}
