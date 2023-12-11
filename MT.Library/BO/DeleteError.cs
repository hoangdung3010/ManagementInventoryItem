using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MT.Library.Enummation;

namespace MT.Library.BO
{
   public class DeleteError
    {
        public object Id { get; set; }

        public string Msg { get; set; }

        public ErrorType ErrorType { get; set; }
    }
}
