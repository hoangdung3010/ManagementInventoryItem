using System;
using MT.Library;
using System.ComponentModel.DataAnnotations;

namespace MT.Data.BO
{
    public class DBOption : BaseEntity
    {
        #region Instance Properties
        [Key]
        public int Id { get; set; }

        public string OptionId { get; set; }

        public string OptionValue { get; set; }

        public int? DataType { get; set; }

        public string Description { get; set; }

        public Guid? UserId { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        #endregion Instance Properties
    }

}
