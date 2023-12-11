using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MT.Data.ViewModels
{
   public class ArgumentSearchLogAccess
    {
        public Guid UserId { get; set; }

        public string UserName { get; set; }

        public string Program { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }


        public int Page { get; set; }

        public int PageSize { get; set; }
    }
}
