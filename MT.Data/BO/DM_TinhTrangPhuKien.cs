using System;
using MT.Library;
using System.ComponentModel.DataAnnotations;

namespace MT.Data.BO
{
    public class DM_TinhTrangPhuKien : BaseEntity
    {
        #region Instance Properties

        public Guid Id { get; set; }

        public string sTenTinhTrangPhuKien { get; set; }

        public string sGhiChu { get; set; }

        public bool bDeleted { get; set; }

        public int SortOrder { get; set; }

        #endregion Instance Properties
    }

}
