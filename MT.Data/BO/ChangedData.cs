using System;
using MT.Library;
using System.ComponentModel.DataAnnotations;

namespace MT.Data.BO
{
    public class ChangedData 
    {
        #region Instance Properties

        public Guid Id { get; set; }

        public Guid? ObjectId { get; set; }

        public string TableName { get; set; }

        public DateTime? CreatedDate { get; set; }

        #endregion Instance Properties
    }

}
