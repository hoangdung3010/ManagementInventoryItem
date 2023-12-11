using MT.Data.Rep;
using MTControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormUI
{
    public class ConfigFormDetail
    {
        /// <summary>
        /// Tên form chi tiết
        /// </summary>
        public string FormName { get; set; }

        /// <summary>
        /// Control grid danh sách
        /// </summary>
        public MGridPaging Grid { get; set; }

        /// <summary>
        /// Control tree
        /// </summary>
        public MTreePaging  Tree { get; set; }
        /// <summary>
        /// Tên repository xử lý nghiệp vụ
        /// </summary>
        public IBaseRepository Rep { get; set; }

        /// <summary>
        /// Chỉ định toolbar cho danh sách
        /// </summary>
        public MToolbarList MToolbarList { get; set; }

        /// <summary>
        /// Tên đối tượng trong DB
        /// </summary>
        public string EntityName { get; set; }

        /// <summary>
        /// Tiêu đề form
        /// </summary>
        public string Title { get; set; }
    }
}
