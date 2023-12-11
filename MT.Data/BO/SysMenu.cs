using MT.Library;
using MT.Library.BO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MT.Data.BO
{
    public class SysMenu: MTTree<int>
    {
        [Key]
        public override int Id { get; set; }

        public string MenuName { get; set; }

        public string FormName { get; set; }

        public int MaxPermission { get; set; }

        public int SortOrder { get; set; }

        public bool Active { get; set; }

        public bool IsShowDialog { get; set; }
    }
}
