using System;
using System.ComponentModel.DataAnnotations;

namespace MT.Data.BO
{
    public class SysUser : MT.Library.BaseEntity
    {
        [Key]
        public Guid Id { get; set; }

        public string UserName { get; set; }

        public string FullName { get; set; }

        public Guid? RoleId { get; set; }

        /// <summary>
        /// Định danh của vai trò
        /// </summary>
        public int Role_DictionaryKey { get; set; }

        public string RoleName { get; set; }

        public string Password { get; set; }
        public string Email { get; set; }

        public byte[] Picture { get; set; }

        public bool Active { get; set; }

        public Guid? OrganizationUnitId { get; set; }

        public string OrganizationUnitName { get; set; }

        public string OrganizationUnitCode { get; set; }
    }

}
