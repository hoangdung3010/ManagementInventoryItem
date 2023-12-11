using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MT.Library
{
    public class RolePermission
    {
        public int Id { get; set; }
        public string FormId { get; set; }
        public string FormName { get; set; }

        public int Permission { get; set; }

        public int MaxPermission { get; set; }

        public bool IsActive { get; set; }

        public int ParentId { get; set; }

        public int SortOrder { get; set; }
    }
}
