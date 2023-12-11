using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MT.Data.BO
{
    public class IncurrentData
    {
        public int Id { get; set; }

        public string Code { get; set; }
        public string TableName { get; set; }

        public string ReferenceTableName { get; set; }

        public string ReferenceColumnName { get; set; }

        public string Msg { get; set; }

        public string Description { get; set; }

        public DateTime ModifieldDate { get; set; }

        public string ReferenceCode { get; set; }
    }
}
