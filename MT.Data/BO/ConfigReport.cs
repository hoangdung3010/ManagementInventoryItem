using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MT.Data.BO
{
    public class ConfigReport
    {
        /// <summary>
        /// Đối tượng repository xử lý báo cáo
        /// </summary>
        public string RepName { get; set; }

        /// <summary>
        /// Danh sách các cột xuất excel
        /// </summary>
        public HashSet<string> ShowColumnsOrder { get; set; }

        /// <summary>
        /// Định danh của báo cáo trong bảng reportData
        /// </summary>
        public MT.Data.ReportDictionaryKey DictionaryKey { get; set; }
    }
}
