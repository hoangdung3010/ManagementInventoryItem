using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MT.Data.BO
{
    public class HeaderTable
    {
        /// <summary>
        /// Tên cột dùng để binding
        /// </summary>
        public string DataIndex { get; set; }

        /// <summary>
        /// Tên cột hiển thị
        /// </summary>
        public string HeaderText { get; set; }

        /// <summary>
        /// Danh sách cột con
        /// </summary>
        public List<HeaderTable> HeaderTables { get; set; }

        /// <summary>
        /// Độ rộng của cột
        /// </summary>
        public int Width { get; set; } = 100;

        /// <summary>
        /// Cho phép render Html
        /// </summary>
        public bool IsHtmlDraw { get; set; }
    }
}
