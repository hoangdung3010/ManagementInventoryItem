using MT.Library;
using System;
using System.ComponentModel.DataAnnotations;

namespace MT.Data.BO
{
    public class DM_HangMucBaoDam : MT.Library.BaseEntity
    {
        [Key]
        public Guid Id { get; set; }

        [Code]
        public string sTenHangMuc { get; set; }

        public string sGhiChu { get; set; }
    }
}