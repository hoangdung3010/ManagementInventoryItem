using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MT.Data.BO
{
    public class ConfigExcel
    {
        public string Title { get; set; }

        public string SubTitle { get; set; }

        /// <summary>
        /// Vị trí vẽ cột header
        /// </summary>
        public int HeaderPositionIndex { get; set; }

        /// <summary>
        /// Vị trí bắt đầu ghi dữ liệu vào excel(Phần body)
        /// </summary>
        public int StartRowIndex { get; set; }

        /// <summary>
        /// Vị trí hiện tại của row
        /// </summary>
        public int CurrenRowIndex { get; set; }

        /// <summary>
        /// Danh sách các tham số truyền vào excel
        /// </summary>
        public Dictionary<string, MTParameter> ParametersExcel { get; set; }

        /// <summary>
        /// Danh sách các tham số truyền thêm vào hàm phục vụ việc lấy cần để xử lý thêm về nghiệp vụ
        /// </summary>
        public Dictionary<string, object> ExtraParams { get; set; }

        /// <summary>
        /// Hiển thị column theo thứ tự config khi xuất ra Excel
        /// </summary>
        public HashSet<string> ShowColumnsOrder { get; set; }

        /// <summary>
        /// Định nghĩa danh sách column là enum tương ứng nếu có
        /// </summary>
        public Dictionary<string, string> DefineColumnWithEnum { get; set; }

        /// <summary>
        /// Độ cao của dòng
        /// </summary>
        public int RowHeight { get; set; } = 1;

        /// <summary>
        /// Margin của mẫu in
        /// </summary>
        public float MarginRight { get; set; } = 0.5f;
        public float MarginLeft { get; set; } = 1;
        public float MarginTop { get; set; } = 1;
        public float MarginBottom { get; set; } = 1;

        /// <summary>
        /// Kích thước của chữ
        /// </summary>
        public float FontSize { get; set; } = 8;

        /// <summary>
        /// Cố định chiều cao của dòng
        /// </summary>
        public bool IsFixedHeight { get; set; } = false;

        public Dictionary<string,object> ParamsStore { get; set; }

        /// <summary>
        /// Danh sách cột của báo cáo. Dùng để render cột động
        /// </summary>
        public List<HeaderTable> HeaderTables { get; set; }
    }

}
