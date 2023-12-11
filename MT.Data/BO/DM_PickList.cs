using System;
using MT.Library;
using System.ComponentModel.DataAnnotations;

namespace MT.Data.BO
{
    public class DM_PickList : BaseEntity
    {
        #region Instance Properties

        public Guid Id { get; set; }

        public string sTen { get; set; }

        public int? SortOrder { get; set; }

        public int PickListType { get; set; }

        public bool? bDeleted { get; set; }

        #endregion Instance Properties
    }

}
