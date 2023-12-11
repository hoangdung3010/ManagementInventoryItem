using System;
using MT.Library;
using System.ComponentModel.DataAnnotations;

namespace MT.Data.BO
{
    public class TepDinhKem : BaseEntity
    {
        #region Instance Properties
        [Key]
        public Guid Id { get; set; }

        public Guid sRefId { get; set; }

        public string sTableName { get; set; }

        public string sTen { get; set; }

        public string sTenGoc { get; set; }

        public string sExtention { get; set; }

        public Single? fSize { get; set; }

        public byte[] byBinaryData { get; set; }

        public string sGhiChu { get; set; }

        public int SortOrder { get; set; }

        public int iSTT { get; set; }


        #endregion Instance Properties
    }

}
