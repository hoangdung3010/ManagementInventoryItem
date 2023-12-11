using System;
using MT.Library;
using System.ComponentModel.DataAnnotations;

namespace MT.Data.BO
{
    public class EmployeeAccessLevel : BaseEntity
    {
        #region Instance Properties

        public Guid Id { get; set; }

        public Guid? EmployeeId { get; set; }

        public Guid? OrganizationUnitId { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        #endregion Instance Properties
    }

}
