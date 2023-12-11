using System;
using MT.Library;
using System.ComponentModel.DataAnnotations;

namespace MT.Data.BO
{
    public class LK_MaVach_CTS : BaseEntity
    {
        #region Instance Properties
        [Key]
        public Guid Id { get; set; }

        public string sMaVach { get; set; }

        public Guid sDM_ChungThuSo_Id { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        #endregion Instance Properties
    }

}
