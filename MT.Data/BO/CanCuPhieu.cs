using System;
using MT.Library;
using System.ComponentModel.DataAnnotations;

namespace MT.Data.BO
{
    public class CanCuPhieu:BaseEntity
    {
        #region Instance Properties
        [Key]
        public Guid Id { get; set; }

        public string sMaPhieu { get; set; }

        public string sTenBangPhieu { get; set; }

        public Guid? sPhieu_Id { get; set; }

        public int? iLoaiPhieu { get; set; }

        public string sTenBangCanCu { get; set; }

        public Guid? sCanCuId { get; set; }

        #endregion Instance Properties
    }

}
