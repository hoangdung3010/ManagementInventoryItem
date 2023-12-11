using MT.Library;
using System;
using System.ComponentModel.DataAnnotations;

namespace MT.Data.BO
{
    public class DM_MangLienLac : MT.Library.BaseEntity
    {
        [Key]
        public Guid Id { get; set; }

        [Code]
        public string sMaMangLienLac { get; set; }

        public string sTenMangLienLac { get; set; }

        public Guid? sDM_ThamSoMatMa_Id { get; set; }
        public string sDM_ThamSoMatMa_Id_Ten { get; set; }
        public string sGhiChu { get; set; }
    }

}
