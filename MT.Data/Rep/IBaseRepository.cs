using MT.Library;
using MT.Library.BO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MT.Data.Rep
{
    public interface IBaseRepository
    {
        /// <summary>
        /// Hàm xóa danh sách đối tượng
        /// </summary>
        /// <param name="entities">Danh sách thực thể</param>
        /// <returns>=true: Tất cả xóa thành công hoặc có bản ghi xóa thành công, ngược lại tất cả đều lỗi</returns>
        ResultData DeleteData(IList entities);

        /// <summary>
        /// Hàm lưu đối tượng
        /// </summary>
        /// <param name="entity">Đối tượng cần lưu</param>
        ResultData SaveData(BaseEntity entity);
        /// <summary>
        /// Lấy về chi tiết bản ghi theo ID
        /// </summary>
        /// <param name="id">ID bản ghi</param>
        BaseEntity GetDataById(object id);
        /// <summary>
        /// Load về danh sách data
        /// </summary>
        /// <param name="sort">Danh sách Cột sắp xếp</param>
        /// <param name="start">Lấy từ vị trí nào</param>
        /// <param name="limit">Lấy đến vị trí nào</param>
        /// <param name="where">Lọc  data theo điều kiện</param>
        /// <param name="columns">Danh sách các column lấy lên</param>
        /// <param name="totalOutput">Tổng số bản ghi trả về</param>
        /// dvthang-08.04.2021
        IList GetDataPaging(string viewNameOrTableName, string sort, int start, int limit, string where,
           string columns, ref int totalCount, ref Dictionary<string, object> dicSummary);

        /// <summary>
        /// Trả về danh sách hàng Table
        /// </summary>
        /// <param name="viewNameOrTableName">Tên view</param>
        /// <param name="sort">Danh sách cột sort</param>
        /// <param name="start">Vị trí bắt đầu</param>
        /// <param name="limit">Số lượng max</param>
        /// <param name="where">Điều kiện where</param>
        /// <param name="columns">Danh sách cột</param>
        DataSet GetAllData(string viewNameOrTableName, string sort, string where,
         string columns);

        /// <summary>
        /// Lấy về danh sách chi tiết theo id master
        /// </summary>
        /// <typeparam name="viewNameOrTableName">Tên view hoặc tên table</typeparam>
        /// <typeparam name="foreignKeyName">Tên của cột khóa ngoại cần lấy</typeparam>
        /// <typeparam name="masterID">Id của master</typeparam>
        /// dvthang-08.04.2021
        IList GetDetailsByMasterID<T>(string viewNameOrTableName, string foreignKeyName, object masterID);

        /// <summary>
        /// Lấy về danh sách chi tiết theo id master
        /// </summary>
        /// <typeparam name="viewNameOrTableName">Tên view hoặc tên table</typeparam>
        /// <typeparam name="entityName">Tên đối tượng cần lấy về</typeparam>
        /// <typeparam name="masterID">Id của master</typeparam>
        /// dvthang-08.04.2021
        IList GetDetailsByMasterID2(string viewNameOrTableName, string entityName, object masterID);

        /// <summary>
        /// Lấy về danh sách chi tiết theo id master
        /// </summary>
        /// <typeparam name="viewNameOrTableName">Tên view hoặc tên table</typeparam>
        /// <typeparam name="foreignKeyName">Tên của cột khóa ngoại cần lấy</typeparam>
        /// <typeparam name="masterID">Id của master</typeparam>
        /// Create by: dvthang:08.04.2021
        DataTable GetDataTableDetailByMasterId(string viewNameOrTableName, string foreignKeyName, object masterID);

        /// <summary>
        /// Lấy về danh sách dữ liệu
        /// </summary>
        /// <param name="typeEntity">Kiểu dữ liệu</param>
        /// <param name="columns">Danh sách cột</param>
        /// <param name="where">Điều kiện where</param>
        /// <param name="orderBy">Orderby</param>
        /// <param name="viewName">Tên view dữ liệu</param>
        IList GetData(Type typeEntity, string columns="*", string where="", string orderBy = "", string viewName = "");

        /// <summary>
        /// Hàm thực hiện sinh mã tự động theo thiết lập
        /// </summary>
        /// <param name="entity">Đối tượng cần sinh mã</param>
        /// <returns>Trả về mã tự tăng không trùng</returns>
        void SetCodeNew(BaseEntity entity);

        /// <summary>
        /// Hàm thực hiện sinh mã tự động theo thiết lập
        /// </summary>
        /// <param name="entity">Đối tượng cần sinh mã</param>
        /// <returns>Trả về mã tự tăng không trùng</returns>
        void SetSoChungTu(BaseEntity entity);

        /// <summary>
        /// Thêm các căn cứ của phiếu
        /// </summary>
        void AddNewCanCuPhieu(BaseEntity entity);

        /// <summary>
        /// Xóa các căn cứ của phiếu
        /// </summary>
        void DeleteCanCuPhieu(BaseEntity entity);

        /// <summary>
        /// Kiểm tra trạng thái của phiếu/kế hoạch
        /// </summary>
        /// <returns>true: Đã duyệt, ngược lại chưa</returns>
        bool CheckHasApproved(object id,string tableName);
    }
}
