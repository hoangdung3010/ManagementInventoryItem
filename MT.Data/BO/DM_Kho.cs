using MT.Library;
using System;
using System.ComponentModel.DataAnnotations;

namespace MT.Data.BO
{
    public class DM_Kho : MT.Library.BaseEntity
    {
        [Key]
        public Guid Id { get; set; }

        [Code]
        public string sTenKho { get; set; }
        public Guid? sDM_Donvi_Id { get; set; }
        public string sDM_Donvi_Id_Ten { get; set; }
        public string sGhiChu { get; set; }
    }

}
