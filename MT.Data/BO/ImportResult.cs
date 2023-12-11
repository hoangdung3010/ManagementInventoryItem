using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MT.Data.BO
{
    public class ImportResult
    {
        /// <summary>
        /// Tổng số bản ghi nhập khẩu
        /// </summary>
        public int Total { get; set; }

        /// <summary>
        /// Tổng số bản ghi được thêm mới thành công
        /// </summary>
        public int TotalAddNewSuccess { get; set; }

        /// <summary>
        /// Tổng số bản ghi được update thành công
        /// </summary>
        public int TotalUpdateSuccess { get; set; }

        /// <summary>
        /// Lỗi
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Đường dẫn chứa file kết quả nhập khẩu
        /// </summary>
        public string PathResultImport { get; set; }
    }
}
