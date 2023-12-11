using FlexCel.Core;
using MT.Data.BO;
using System.Collections.Generic;
using System.Data;

namespace MT.Data
{
    public interface IBaseReportRepository
    {
        /// <summary>
        /// Thực hiện tạo file excel
        /// </summary>
        /// <param name="pathFileName">Đường dẫn file</param>
        void CreateExcel(string pathFileName);
        /// <summary>
        /// Hàm tạo báo cáo, dùng khi đã có đầy đủ dữ liệu xuất ra
        /// </summary>
        /// <param name="configExcel">Thông tin cấu hình excel</param> 
        /// <param name="pathFileName">Đường dẫn đầy đủ của file</param>
        /// <param name="ds">Danh sách dữ liệu</param>
        /// <returns>Trả về nội dung file excel</returns>
        ExcelFile CreateReport(ConfigExcel configExcel, string pathFileName,DataSet ds);

        /// <summary>
        /// Hàm tạo báo cáo dùng khi cần lấy dữ liệu từ store trong bảng Report để xuất ra file
        /// </summary>
        /// <param name="configExcel">Thông tin cấu hình excel</param>  
        /// <param name="pathFileName">Đường dẫn đầy đủ của file</param>
        /// <param name="data">Danh sách dữ liệu</param>
        /// <param name="paramStore">Tham số truyền vào store</param>
        /// <returns>Trả về nội dung file excel</returns>
        ExcelFile CreateReport(ConfigExcel configExcel, ReportData reportData);
    }
}
