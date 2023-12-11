using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using static MT.Library.Enummation;

namespace MT.Library.UW
{
    public interface IUnitOfWork: IDisposable
    {
         SqlDatabase DB { get; }
        /// <summary>
        /// Tạo transaction
        /// </summary>
        /// <returns>Trả về 1 transaction</returns>
        /// Create by: dvthang:19.04.2017
        void BeginTransaction();

        /// <summary>/// Tạo đối tượng command
        /// </summary>
        /// <returns>Trả về đối tượng command</returns>
        /// Create by: dvthang:18.04.2017
        DbCommand CreateCommand();
        
        /// <summary>
        /// Trả về danh sách tập dữ liệu
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu trả về</typeparam>
        /// <param name="query">Câu query</param>
        /// <param name="param">Danh sách tham số</param>
        /// <param name="commandType">Kiểu dữ liệu</param>
        /// <param name="timeout">Thời giam out</param>
        /// Create by: dvthang:23.03.2019
        List<T> Query<T>(string query, object param = null,
            CommandType? commandType=CommandType.Text,int? timeout=300);

        /// <summary>
        /// Trả về danh sách tập dữ liệu
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu trả về</typeparam>
        /// <param name="query">Câu query</param>
        /// <param name="param">Danh sách tham số</param>
        /// <param name="commandType">Kiểu dữ liệu</param>
        /// <param name="timeout">Thời giam out</param>
        /// <param name="type">Kiểu Đối tượng trả về</param>
        /// Create by: dvthang:23.03.2019
        IList Query(string query,Type type, object param = null,
            CommandType? commandType = CommandType.Text, int? timeout = 300);


        /// <summary>
        /// Trả về danh sách tập dữ liệu
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu trả về</typeparam>
        /// <param name="query">Câu query</param>
        /// <param name="param">Danh sách tham số</param>
        /// <param name="commandType">Kiểu dữ liệu</param>
        /// <param name="timeout">Thời giam out</param>
        /// <param name="type">Kiểu Đối tượng trả về</param>
        /// Create by: dvthang:23.03.2019
        IList Query(string query, Type type, Dictionary<string, object> param,
            CommandType? commandType = CommandType.Text, int? timeout = 300);

        /// <summary>
        /// Trả về danh sách tập dữ liệu
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu trả về</typeparam>
        /// <param name="query">Câu query</param>
        /// <param name="param">Danh sách tham số</param>
        /// <param name="commandType">Kiểu dữ liệu</param>
        /// <param name="timeout">Thời giam out</param>
        /// Create by: dvthang:23.03.2019
        List<T> Query<T>(string query, Dictionary<string,object> param,
            CommandType? commandType = CommandType.Text, int? timeout = 300);

        /// <summary>
        /// Trả về danh sách tập dữ liệu
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu trả về</typeparam>
        /// <param name="query">Câu query</param>
        /// <param name="param">Danh sách tham số</param>
        /// <param name="commandType">Kiểu dữ liệu</param>
        /// <param name="timeout">Thời giam out</param>
        /// Create by: dvthang:23.03.2019
        T QueryFirstOrDefault<T>(string query, object param = null, 
            CommandType? commandType = CommandType.Text, int? timeout = 300);

        /// <summary>
        /// Trả về danh sách tập dữ liệu
        /// </summary>
        /// <typeparam name="type">Kiểu dữ liệu trả về</typeparam>
        /// <param name="query">Câu query</param>
        /// <param name="param">Danh sách tham số</param>
        /// <param name="commandType">Kiểu dữ liệu</param>
        /// <param name="timeout">Thời giam out</param>
        /// Create by: dvthang:23.03.2019
        object QueryFirstOrDefault(string query,Type type, object param = null,
            CommandType? commandType = CommandType.Text, int? timeout = 300);

        /// <summary>
        /// Trả về danh sách tập dữ liệu
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu trả về</typeparam>
        /// <param name="query">Câu query</param>
        /// <param name="param">Danh sách tham số</param>
        /// <param name="commandType">Kiểu dữ liệu</param>
        /// <param name="timeout">Thời giam out</param>
        /// Create by: dvthang:23.03.2019
        T QueryFirstOrDefault<T>(string query, Dictionary<string,object> param,
            CommandType? commandType = CommandType.Text, int? timeout = 300);

        /// <summary>
        /// Trả về danh sách tập dữ liệu
        /// </summary>
        /// <typeparam name="type">Kiểu dữ liệu trả về</typeparam>
        /// <param name="query">Câu query</param>
        /// <param name="param">Danh sách tham số</param>
        /// <param name="commandType">Kiểu dữ liệu</param>
        /// <param name="timeout">Thời giam out</param>
        /// Create by: dvthang:23.03.2019
        object QueryFirstOrDefault(string query,Type type, Dictionary<string, object> param,
            CommandType? commandType = CommandType.Text, int? timeout = 300);

        /// <summary>
        /// Trả về danh sách tập dữ liệu
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu trả về</typeparam>
        /// <param name="query">Câu query</param>
        /// <param name="param">Danh sách tham số</param>
        /// <param name="commandType">Kiểu dữ liệu</param>
        /// <param name="timeout">Thời giam out</param>
        /// Create by: dvthang:23.03.2019
        List<Dictionary<string,object>> QueryListDictionary(string query, object param = null, 
            CommandType? commandType = CommandType.Text, int? timeout = 300);

        /// <summary>
        /// Trả về danh sách tập dữ liệu
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu trả về</typeparam>
        /// <param name="query">Câu query</param>
        /// <param name="param">Danh sách tham số</param>
        /// <param name="commandType">Kiểu dữ liệu</param>
        /// <param name="timeout">Thời giam out</param>
        /// Create by: dvthang:23.03.2019
        List<Dictionary<string, object>> QueryListDictionary(string query, Dictionary<string,object> param,
            CommandType? commandType = CommandType.Text, int? timeout = 300);

        /// <summary>
        /// Trả về danh sách tập dữ liệu
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu trả về</typeparam>
        /// <param name="query">Câu query</param>
        /// <param name="param">Danh sách tham số</param>
        /// <param name="commandType">Kiểu dữ liệu</param>
        /// <param name="timeout">Thời giam out</param>
        /// Create by: dvthang:23.03.2019
        Dictionary<string, object> QueryDictionary(string query, object param = null,
            CommandType? commandType = CommandType.Text, int? timeout = 300);

        /// <summary>
        /// Trả về danh sách tập dữ liệu
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu trả về</typeparam>
        /// <param name="query">Câu query</param>
        /// <param name="param">Danh sách tham số</param>
        /// <param name="commandType">Kiểu dữ liệu</param>
        /// <param name="timeout">Thời giam out</param>
        /// Create by: dvthang:23.03.2019
        Dictionary<string, object> QueryDictionary(string query, Dictionary<string,object> param,
            CommandType? commandType = CommandType.Text, int? timeout = 300);

        /// <summary>
        /// Trả về danh sách tập dữ liệu
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu trả về</typeparam>
        /// <param name="query">Câu query</param>
        /// <param name="param">Danh sách tham số</param>
        /// <param name="commandType">Kiểu dữ liệu</param>
        /// <param name="timeout">Thời giam out</param>
        /// Create by: dvthang:23.03.2019
        bool Execute(string query, object param = null, 
            CommandType? commandType = CommandType.Text, int? timeout = 300);

        /// <summary>
        /// Trả về danh sách tập dữ liệu
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu trả về</typeparam>
        /// <param name="query">Câu query</param>
        /// <param name="param">Danh sách tham số</param>
        /// <param name="commandType">Kiểu dữ liệu</param>
        /// <param name="timeout">Thời giam out</param>
        /// Create by: dvthang:23.03.2019
        T ExecuteScalar<T>(string query, object param = null, 
            CommandType? commandType = CommandType.Text, int? timeout = 300);

        /// <summary>
        /// Trả về danh sách tập dữ liệu
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu trả về</typeparam>
        /// <param name="query">Câu query</param>
        /// <param name="param">Danh sách tham số</param>
        /// <param name="commandType">Kiểu dữ liệu</param>
        /// <param name="timeout">Thời giam out</param>
        /// Create by: dvthang:23.03.2019
        bool Execute(string query, Dictionary<string,object> param ,
            CommandType? commandType = CommandType.Text, int? timeout = 300);

        /// <summary>
        /// Trả về danh sách tập dữ liệu
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu trả về</typeparam>
        /// <param name="query">Câu query</param>
        /// <param name="param">Danh sách tham số</param>
        /// <param name="commandType">Kiểu dữ liệu</param>
        /// <param name="timeout">Thời giam out</param>
        /// Create by: dvthang:23.03.2019
        T ExecuteScalar<T>(string query, Dictionary<string,object> param ,
            CommandType? commandType = CommandType.Text, int? timeout = 300);

        /// <summary>
        /// Thực thi 1 command 
        /// </summary>
        /// <returns>TRả về 1 giá trị đơn</returns>
        /// Create by: dvthang:18.04.2017
        DataSet ExecuteDataSetCmd(DbCommand cmd);
        /// <summary>
        /// Trả về danh sách tập dữ liệu
        /// </summary>
        /// <param name="store"></param>
        /// <returns></returns>
        /// CreateBy:ThanhCong:10.09.2019
        DataSet QueryDataSet(string query,
            Dictionary<string, object> param=null, CommandType? commandType = CommandType.Text, int? timeout = 300);

        /// <summary>
        /// Trả về danh sách tập dữ liệu
        /// </summary>
        /// <param name="store">tên store</param>
        /// <param name="parameters">danh sách tham số</param>
        /// <returns></returns>
        /// CreateBy:ThanhCong:10.09.2019
        DataTable QueryDataTable(string query,
            Dictionary<string, object> param = null, CommandType? commandType = CommandType.Text, int? timeout = 300);
        /// <summary>
        /// Trả về tập datareader
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu trả về</typeparam>
        /// <param name="query">Câu query</param>
        /// <param name="param">Danh sách tham số</param>
        /// <param name="commandType">Kiểu dữ liệu</param>
        /// <param name="timeout">Thời giam out</param>
        /// Create by: dvthang:24.08.2019
        void ProcessIDataReader(string query, Action<IDataReader> method, object param = null, 
            CommandType? commandType = CommandType.Text, int? timeout = 300);
        
        /// <summary>
        /// Trả về tập datareader
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu trả về</typeparam>
        /// <param name="query">Câu query</param>
        /// <param name="param">Danh sách tham số</param>
        /// <param name="commandType">Kiểu dữ liệu</param>
        /// <param name="timeout">Thời giam out</param>
        /// Create by: dvthang:24.08.2019
        void ProcessIDataReader(string query, Action<IDataReader> method,
           Dictionary<string, object> param, CommandType? commandType = CommandType.Text,
           int? timeout = 300);

        /// <summary>
        /// Hàm thực hiện cất tất cả các repository trong cùng 1 giao dịch
        /// </summary>
        /// Create by: dvthang:18.04.2017
        void Commit();

        /// <summary>
        /// Hủy giao dịch
        /// </summary>
        /// Create by: dvthang:19.04.2017
        void RollBack();

        /// <summary>
        /// Mở connection
        /// </summary>
        /// Create by: dvthang:20.04.2017
        void OpenConn();
        /// <summary>
        /// Đóng connection
        /// </summary>
        /// Create by: dvthang:20.04.2017
        void CloseConn();

        /// <summary>
        /// Hàm lưu dạng dictionary
        /// </summary>
        /// <param name="entity">Đối tượng cần lưu</param>
        /// <param name="tableName">Tên bảng</param>
        /// <param name="state">0:None,1:Add,2:Edit,3:Delete</param>
        /// <param name="includeCols">Danh sách cột thực hiện thao tác insert or update</param>
        /// <param name="exculeCols">Danh sách cột không thực hiện insert or update</param>
        /// <returns>true thành công, ngược lại thất bại</returns>
        bool SaveEntity(BaseEntity entity,string tableName, MTEntityState state,string primaryKeyName="Id", string[] includeCols = null, string[] exculeCols = null);

        /// <summary>
        /// Hàm lưu entity
        /// </summary>
        /// <param name="entity">Đối tượng cần lưu</param>
        /// <param name="tableName">Tên bảng</param>
        /// <param name="state">0:None,1:Add,2:Edit,3:Delete</param>
        /// <param name="includeCols">Danh sách cột thực hiện thao tác insert or update</param>
        /// <param name="exculeCols">Danh sách cột không thực hiện insert or update</param>
        /// <returns>true thành công, ngược lại thất bại</returns>
        bool SaveEntity(Dictionary<string,object> dicData, string tableName, MTEntityState state ,string primaryKeyName = "Id", string[] includeCols=null, string[] exculeCols=null);
        /// <summary>
        /// Kiểm tra kết nối đến DB
        /// </summary>
        /// <returns>true: Kết nối thanh công, ngược lại thất bại</returns>
        bool IsConnect();

        /// <summary>
        /// Hàm thực hiện insert sử dụng bulkinsert
        /// </summary>
        /// <param name="datas">Dữ liệu cần insert</param>
        /// <param name="tableName">Tên bảng cần insert</param>
        /// <returns>true: Insert thành công, ngược lại thất bại</returns>
        bool BulkInsert<T>(List<T> datas, string tableName, string columns = "*");

        /// <summary>
        /// Hàm thực hiện insert sử dụng bulkinsert
        /// </summary>
        /// <param name="datas">Dữ liệu cần insert</param>
        /// <param name="tableName">Tên bảng cần insert</param>
        /// <returns>true: Insert thành công, ngược lại thất bại</returns>
        bool BulkInsert(DataTable datas, string tableName, string columns = "*");
    }
}
