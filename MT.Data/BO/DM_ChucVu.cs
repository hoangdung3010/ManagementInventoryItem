using MT.Library;
using System;
using System.ComponentModel.DataAnnotations;

namespace MT.Data.BO
{
    public class DM_ChucVu : MT.Library.BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
      
        [Code]
        public string sTenChucVu { get; set; }

        public string sGhiChu { get; set; }
    }

}
