using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MT.Data.ViewModels
{
   public class ArgumentSearchLogAction
    {
        public Guid UserId { get; set; }
        public string SearchValue { get; set; }

        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

        public int Page { get; set; }

        public int PageSize { get; set; }
    }
}
