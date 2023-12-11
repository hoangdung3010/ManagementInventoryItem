using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MT.Library.BO
{
   public class MTTree<T>:BaseEntity
        where T:struct
    {
        public bool? Expanded { get; set; }
        public IList Data { get; set; }
        public bool Leaf { get; set; }
        public string IconCls { get; set; }

        public virtual int Level { get; set; }

        public virtual T Id { get; set; }

        public virtual T? ParentId { get; set; }
    }
}
