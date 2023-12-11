using MT.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MT.Data.BO
{
   public class Sequence
    {
        public int Id { get; set; }

        public string TableName { get; set; }

        public string ColumnName { get; set; }

        public string Prefix { get; set; }

        public int CurrentValue { get; set; }

        public int MaxLength { get; set; }

        public bool HasOrganizationCode { get; set; }
    }
}
