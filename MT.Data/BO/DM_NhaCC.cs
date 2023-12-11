using MT.Library;
using System;
using System.ComponentModel.DataAnnotations;

namespace MT.Data.BO
{
    public class DM_NhaCC : MT.Library.BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        [Code]
        public string sMaNCC { get; set; }
        public string sTenNCC { get; set; }
        public string sDiaChi { get; set; }
        public string sSoDienThoai { get; set; }
        public string sMaSoThue { get; set; }

        public string sGhiChu { get; set; }
    }

}
