using System;
using MT.Library;
using System.ComponentModel.DataAnnotations;

namespace MT.Data.BO
{
    public class DuLieuGanNhatTrenForm : BaseEntity
    {
        #region Instance Properties
        [Key]
        public Guid Id { get; set; }

        public Guid? sUserId { get; set; }

        public string sTableName { get; set; }

        public string sFormData { get; set; }

        #endregion Instance Properties
    }

}
