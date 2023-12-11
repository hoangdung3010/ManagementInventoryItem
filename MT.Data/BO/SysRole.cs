using MT.Library;
using System;
using System.ComponentModel.DataAnnotations;

namespace MT.Data.BO
{
    
    [TableName("SysRoles")]
    public class SysRole:MT.Library.BaseEntity
    {

        // Properties
        [Key]
        public Guid Id { get; set; }

        public string RoleName { get; set; }
        public bool Active { get; set; }
        public bool IsSystem { get; set; }

        public int DictionaryKey { get; set; }
    }

}
