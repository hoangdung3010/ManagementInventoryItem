using System;
using MT.Library;
using System.ComponentModel.DataAnnotations;

namespace MT.Data.BO
{
    public class DM_NoiDungBaoHanh : BaseEntity
    {
        #region Instance Properties
        [Key]
        public Guid Id { get; set; }
        [Code]
        public string sTenNoiDungBaoHanh { get; set; }

        public string sGhiChu { get; set; }
        public bool? bDeleted { get; set; }

        #endregion Instance Properties
    }

}
