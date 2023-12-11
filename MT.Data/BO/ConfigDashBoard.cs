using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MT.Data.BO
{
    public class ConfigDashBoard
    {
        public int Id { get; set; }

        public string DashboardName { get; set; }

        public string Store { get; set; }

        public string ResultTypeName { get; set; }

        public int DictionaryKey { get; set; }

        public string UcParamName { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
