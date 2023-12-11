using FlexCel.Core;
using MT.Data.BO;
using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace MT.Data
{
    public interface IBaseImportRepository
    {
        /// <summary>
        /// Thiết lập thông tin khi import
        /// </summary>
        /// <param name="argumentImport"></param>
        void SetConfig(ArgumentImport argumentImport);
        /// <summary>
        /// Thực hiện mở file
        /// </summary>
        void OpenXlsFile(string fileName);

        /// <summary>
        /// Lấy về giá trị của cell
        /// </summary>
        /// <param name="rowIndex">Hàng</param>
        /// <param name="colIndex">Cột</param>
        /// <param name="formatted">=true lấy giá trị đúng như format trên excel, ngược lại chỉ lấy rawvalue</param>
        string GetCellValue(int rowIndex, int colIndex, bool formatted = false);

        /// <summary>
        /// Đọc số sheet của file
        /// </summary>
        List<string> GetSheetsName();
        
        /// <summary>
        /// Validate xem excel có hợp lệ không
        /// </summary>
        /// <returns>Trả về true là hợp lệ</returns>
        bool ValidFile();

        /// <summary>
        /// Lấy về thiết lập mapping của chức năng nhập khẩu
        /// </summary>
        List<ConfigImportMapping> GetConfigImportMapping(string tableName);

        /// <summary>
        /// Ghép cột tự động
        /// </summary>
        List<ColumnMatchWhenImportExcel> ColumnMatch();

        /// <summary>
        /// Thực hiện đọc dữ liệu từ tệp excel
        /// </summary>
        IList ReadData();
        /// <summary>
        /// Cập nhật thêm dữ liệu trước hiển thị
        /// </summary>
        /// <param name="rowData">Dòng dữ liệu hiện tại</param>
        void UpdateMoreData(object rowData);

        /// <summary>
        /// Thực hiện chuyển dữ liệu vào bảng thật
        /// </summary>
        ImportResult ExecuteDB(IList datas);

    }
}
