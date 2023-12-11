using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using MT.Library.BO;
using MT.Library.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using static MT.Library.Enummation;

namespace MT.Library.UW
{
    public class UnitOfWork : IUnitOfWork
    {
        #region"Declare"
        /// <summary>
        /// Đối tượng thao tác với database
        /// </summary>
        /// Create by: dvthang:19.04.2017
        private SqlDatabase m_DB;

        DbTransaction transaction = null;

        DbConnection connection = null;

        private string _connectionString;

        #endregion
        #region"Property"
        public virtual SqlDatabase DB
        {
            get
            {
                if (m_DB == null)
                {
                    if (string.IsNullOrEmpty(_connectionString))
                    {
                        m_DB = new SqlDatabase(MT.Library.Utility.GetConnectionString());
                    }
                    else
                    {
                        m_DB = new SqlDatabase(_connectionString);
                    }
                }
                return m_DB;
            }
            private set
            {
                m_DB = value;
            }
        }
        #endregion
        #region"Contructor"
        public UnitOfWork()
        {
        }
        public UnitOfWork(string connectionString)
        {
            _connectionString = connectionString;
        }
        #endregion

        #region"Sub/Func"
        /// <summary>
        /// Thực thi 1 command
        /// </summary>
        /// <returns>True thực hiện thành công</returns>
        /// Create by: dvthang:18.04.2017
        private int ExecuteNoneQueryCmd(DbCommand cmd)
        {
            if (this.transaction != null)
            {
                return this.DB.ExecuteNonQuery(cmd,this.transaction);
            }
            return this.DB.ExecuteNonQuery(cmd);
        }

        /// <summary>
        /// Thực thi 1 command
        /// </summary>
        /// <returns>TRả về 1 tập dữ liệu</returns>
        /// Create by: dvthang:18.04.2017
        private IDataReader ExecuteReaderCmd(DbCommand cmd)
        {
            if (this.transaction != null)
            {
                return this.DB.ExecuteReader(cmd, this.transaction);
            }
            return this.DB.ExecuteReader(cmd);
        }

        /// <summary> 
        /// Thực thi 1 command 
        /// </summary>
        /// <returns>TRả về 1 giá trị đơn</returns>
        /// Create by: dvthang:18.04.2017
        private object ExecuteScalarCmd(DbCommand cmd)
        {
            if (this.transaction != null)
            {
                return this.DB.ExecuteScalar(cmd, this.transaction);
            }
            return this.DB.ExecuteScalar(cmd);
        }

        /// <summary>
        /// Thực thi 1 command 
        /// </summary>
        /// <returns>TRả về 1 giá trị đơn</returns>
        /// Create by: dvthang:18.04.2017
        public DataSet ExecuteDataSetCmd(DbCommand cmd)
        {
            if (this.transaction != null)
            {
                return this.DB.ExecuteDataSet(cmd, this.transaction);
            }
            return this.DB.ExecuteDataSet(cmd);
        }


        /// <summary>
        /// Tạo đối tượng command thao tác với DB
        /// </summary>
        /// <returns>Trả về IDbCommand</returns>
        /// Create by: dvthang:19.04.2017
        public DbCommand CreateCommand()
        {
            DbCommand command = null;
            if (this.connection == null)
            {
                this.connection = this.DB.CreateConnection();
            }
            this.OpenConn();
            command = this.connection.CreateCommand();

            return command;
        }

        /// <summary>
        /// Hàm cất tất cả các thông tin trong cùng 1 giao dịch
        /// </summary>
        /// Create by: dvthang:19.04.2017
        public void Commit()
        {
            if (this.transaction != null)
            {
                this.transaction.Commit();
                this.transaction = null;
            }
        }

        /// <summary>
        /// Giải phóng Connection và giao dịch
        /// </summary>
        /// Create by: dvthang:19.04.2017
        public void Dispose()
        {
            try
            {
                if (this.transaction != null)
                {
                    this.transaction.Rollback();
                    this.transaction = null;
                }

                if (this.connection != null)
                {
                    if (this.connection.State != ConnectionState.Closed)
                    {
                        this.connection.Close();
                    }
                    this.connection.Dispose();
                    this.connection = null;
                }
            }
            catch (Exception)
            {
            }

            GC.SuppressFinalize(this);
        }
        #endregion

        /// <summary>
        /// Tạo giao dịch
        /// </summary>
        /// Create by: dvthang:19.04.2017
        public void BeginTransaction()
        {
            if (this.transaction == null)
            {
                if (this.connection == null)
                {
                    this.connection = this.DB.CreateConnection();
                }
                this.OpenConn();
                this.transaction = this.connection.BeginTransaction();
            }
        }

        /// <summary>
        /// Hủy 1 giao dịch
        /// </summary>
        /// Create by:dvthang:19.04.2017
        public void RollBack()
        {
            if (this.transaction != null)
            {
                this.transaction.Rollback();
                this.transaction = null;
            }
        }

        /// <summary>
        /// Mở connection
        /// </summary>
        /// Create by: dvthang:20.04.2017
        public void OpenConn()
        {
            if (this.connection != null && this.connection.State == ConnectionState.Closed)
            {
                this.connection.Open();
            }
        }

        /// <summary>
        /// Kiểm tra kết nối đến DB
        /// </summary>
        /// <returns>true: Kết nối thanh công, ngược lại thất bại</returns>
        public bool IsConnect()
        {
            bool flag;
            try
            {
                if (this.connection == null)
                {
                    this.connection = this.DB.CreateConnection();
                }
                if (this.connection.State != ConnectionState.Open)
                {
                    this.connection.Open();
                    flag = true;
                }
                else
                {
                    flag = false;
                }
            }
            catch (DbException)
            {
                flag = false;
            }
            return flag;
        }

        /// <summary>
        /// Đóng connection
        /// </summary>
        /// Create by: dvthang:20.04.2017
        public void CloseConn()
        {
            if (this.connection != null && this.connection.State != ConnectionState.Closed)
            {
                this.connection.Close();
            }
        }

        /// <summary>
        /// Trả về danh sách tập dữ liệu
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu trả về</typeparam>
        /// <param name="query">Câu query</param>
        /// <param name="param">Danh sách tham số</param>
        /// <param name="commandType">Kiểu dữ liệu</param>
        /// <param name="timeout">Thời giam out</param>
        /// Create by: dvthang:23.03.2019
        public List<T> Query<T>(string query, object param = null, CommandType? commandType = CommandType.Text, int? timeout = 300)
        {
            List<T> datas = null;
            this.ProcessIDataReader(query, (rd) =>
            {
                datas = rd.ToListObject<T>();
            }, param, commandType, timeout);
            return datas;
        }

        /// <summary>
        /// Trả về danh sách tập dữ liệu
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu trả về</typeparam>
        /// <param name="query">Câu query</param>
        /// <param name="param">Danh sách tham số</param>
        /// <param name="commandType">Kiểu dữ liệu</param>
        /// <param name="timeout">Thời giam out</param>
        /// Create by: dvthang:23.03.2019
        public List<T> Query<T>(string query, Dictionary<string, object> param, CommandType? commandType = CommandType.Text, int? timeout = 300)
        {
            List<T> datas = null;
            this.ProcessIDataReader(query, (rd) =>
            {
                datas = rd.ToListObject<T>();
            }, param, commandType, timeout);
            return datas;
        }


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
        public IList Query(string query, Type type, object param = null,
            CommandType? commandType = CommandType.Text, int? timeout = 300)
        {
            IList datas = null;
            this.ProcessIDataReader(query, (rd) =>
            {
                datas = rd.ToListObject(type);
            }, param, commandType, timeout);
            return datas;
        }


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
        public IList Query(string query, Type type, Dictionary<string, object> param,
            CommandType? commandType = CommandType.Text, int? timeout = 300)
        {
            IList datas = null;
            this.ProcessIDataReader(query, (rd) =>
            {
                datas = rd.ToListObject(type);
            }, param, commandType, timeout);
            return datas;
        }

        #region"Private/Func"
        /// <summary>
        /// Gán giá trị vào param
        /// </summary>
        /// <param name="pram">Tham số trong cammand</param>
        /// <param name="vVal">Giá trị</param>
        /// Create by: dvthang:24.08.2019
        void SetValue(DbParameter pram, object vVal)
        {
            if (vVal != null)
            {
                pram.Value = vVal;
            }
            else
            {
                pram.Value = DBNull.Value;
            }
        }

        /// <summary>
        /// Thực hiện mapping param với command dạng object
        /// </summary>
        /// <param name="param">Danh sách param</param>
        /// Create by: dvthang:23.03.2019
        private void MappingParamsWithObject(DbCommand cmd, object param)
        {
            if (param == null)
            {
                return;
            }
            if (cmd.CommandType == CommandType.Text)
            {

                PropertyInfo[] infos = param.GetType().GetProperties();
                foreach (PropertyInfo p in infos)
                {
                    object vVal = p.GetValue(param, null);
                    SqlParameter pr = new SqlParameter($"@{p.Name}", vVal ?? DBNull.Value);
                    cmd.Parameters.Add(pr);
                }
                return;
            }
            else
            {
                if (this.transaction != null)
                {
                    cmd.Transaction = this.transaction;
                }
                SqlCommandBuilder.DeriveParameters((SqlCommand)cmd);
                if (cmd.Parameters.Count > 0)
                {
                    string name = string.Empty;
                    int totalParams = cmd.Parameters.Count;
                    for (int i = 0; i < totalParams; i++)
                    {
                        var pr = cmd.Parameters[i];
                        name = cmd.Parameters[i].ParameterName.Replace("@", "");

                        if (name.Equals("RETURN_VALUE", StringComparison.OrdinalIgnoreCase))
                        {
                            continue;
                        }
                        var pInfo = param.GetType().GetProperty(name);
                        if (pInfo != null)
                        {
                            object vVal = pInfo.GetValue(param, null);
                            SetValue(pr, vVal);
                        }
                        else
                        {
                            SetValue(pr, null);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Thực hiện mapping param với command
        /// </summary>
        /// <param name="param">Danh sách param</param>
        /// Create by: dvthang:23.03.2019
        private void MappingParamsWithDictionary(DbCommand cmd, Dictionary<string, object> dicData)
        {
            if (cmd.CommandType == CommandType.Text)
            {
                if (dicData == null || dicData.Count == 0)
                {
                    return;
                }
                foreach (KeyValuePair<string, object> pair in dicData)
                {
                    SqlParameter pr = new SqlParameter($"@{pair.Key}", pair.Value ?? DBNull.Value);
                    cmd.Parameters.Add(pr);
                }
            }
            else
            {
                if (this.transaction != null)
                {
                    cmd.Transaction = this.transaction;
                }
                SqlCommandBuilder.DeriveParameters((SqlCommand)cmd);
                if (cmd.Parameters.Count > 0)
                {
                    string name = string.Empty;
                    int totalParams = cmd.Parameters.Count;
                    for (int i = 0; i < totalParams; i++)
                    {
                        var pr = cmd.Parameters[i];
                        name = cmd.Parameters[i].ParameterName.Replace("@", "");
                        if (name.Equals("RETURN_VALUE", StringComparison.OrdinalIgnoreCase))
                        {
                            continue;
                        }
                        if (dicData!=null && dicData.ContainsKey(name))
                        {
                            SetValue(pr, dicData[name]);
                        }
                        else
                        {
                            SetValue(pr, null);
                        }
                    }
                }
            }
        }
        #endregion

        /// <summary>
        /// Trả về danh sách tập dữ liệu
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu trả về</typeparam>
        /// <param name="query">Câu query</param>
        /// <param name="param">Danh sách tham số</param>
        /// <param name="commandType">Kiểu dữ liệu</param>
        /// <param name="timeout">Thời giam out</param>
        /// Create by: dvthang:23.03.2019
        public T QueryFirstOrDefault<T>(string query, object param = null, CommandType? commandType = CommandType.Text, int? timeout = 300)
        {
            T data = default(T);
            this.ProcessIDataReader(query, (rd) =>
            {
                data = rd.ToObject<T>();
            }, param, commandType, timeout);
            return data;
        }

        /// <summary>
        /// Trả về danh sách tập dữ liệu
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu trả về</typeparam>
        /// <param name="query">Câu query</param>
        /// <param name="param">Danh sách tham số</param>
        /// <param name="commandType">Kiểu dữ liệu</param>
        /// <param name="timeout">Thời giam out</param>
        /// Create by: dvthang:23.03.2019
        public T QueryFirstOrDefault<T>(string query, Dictionary<string, object> param, CommandType? commandType = CommandType.Text, int? timeout = 300)
        {
            T data = default(T);
            this.ProcessIDataReader(query, (rd) =>
            {
                data = rd.ToObject<T>();
            }, param, commandType, timeout);
            return data;
        }


        /// <summary>
        /// Trả về danh sách tập dữ liệu
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu trả về</typeparam>
        /// <param name="query">Câu query</param>
        /// <param name="param">Danh sách tham số</param>
        /// <param name="commandType">Kiểu dữ liệu</param>
        /// <param name="timeout">Thời giam out</param>
        /// Create by: dvthang:23.03.2019
        public object QueryFirstOrDefault(string query,Type type, object param = null, CommandType? commandType = CommandType.Text, int? timeout = 300)
        {
            IList datas = null;
            this.ProcessIDataReader(query, (rd) =>
            {
                datas = rd.ToListObject(type);
            }, param, commandType, timeout);
            return datas != null && datas.Count > 0 ? datas[0] : null;
        }

        /// <summary>
        /// Trả về danh sách tập dữ liệu
        /// </summary>
        /// <typeparam name="type">Kiểu dữ liệu trả về</typeparam>
        /// <param name="query">Câu query</param>
        /// <param name="param">Danh sách tham số</param>
        /// <param name="commandType">Kiểu dữ liệu</param>
        /// <param name="timeout">Thời giam out</param>
        /// Create by: dvthang:23.03.2019
        public object QueryFirstOrDefault(string query,Type type, Dictionary<string, object> param, CommandType? commandType = CommandType.Text, int? timeout = 300)
        {
            IList datas = null;
            this.ProcessIDataReader(query, (rd) =>
            {
                datas = rd.ToListObject(type);
            }, param, commandType, timeout);
            return datas!=null && datas.Count>0?datas[0]:null;
        }


        /// <summary>
        /// Trả về danh sách tập dữ liệu
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu trả về</typeparam>
        /// <param name="query">Câu query</param>
        /// <param name="param">Danh sách tham số</param>
        /// <param name="commandType">Kiểu dữ liệu</param>
        /// <param name="timeout">Thời giam out</param>
        /// Create by: dvthang:23.03.2019
        public List<Dictionary<string, object>> QueryListDictionary(string query, object param = null, CommandType? commandType = CommandType.Text, int? timeout = 300)
        {
            List<Dictionary<string, object>> listDicData = null;
            this.ProcessIDataReader(query, (rd) =>
            {
                listDicData = rd.ToListDic();
            }, param, commandType, timeout);
            return listDicData;
        }

        /// <summary>
        /// Trả về danh sách tập dữ liệu
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu trả về</typeparam>
        /// <param name="query">Câu query</param>
        /// <param name="param">Danh sách tham số</param>
        /// <param name="commandType">Kiểu dữ liệu</param>
        /// <param name="timeout">Thời giam out</param>
        /// Create by: dvthang:23.03.2019
        public List<Dictionary<string, object>> QueryListDictionary(string query, Dictionary<string, object> param, CommandType? commandType = CommandType.Text, int? timeout = 300)
        {
            List<Dictionary<string, object>> listDicData = null;
            this.ProcessIDataReader(query, (rd) =>
            {
                listDicData = rd.ToListDic();
            }, param, commandType, timeout);
            return listDicData;
        }

        /// <summary>
        /// Trả về danh sách tập dữ liệu
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu trả về</typeparam>
        /// <param name="query">Câu query</param>
        /// <param name="param">Danh sách tham số</param>
        /// <param name="commandType">Kiểu dữ liệu</param>
        /// <param name="timeout">Thời giam out</param>
        /// Create by: dvthang:23.03.2019
        public Dictionary<string, object> QueryDictionary(string query, object param = null, CommandType? commandType = CommandType.Text, int? timeout = 300)
        {
            Dictionary<string, object> dicData = null;
            this.ProcessIDataReader(query, (rd) =>
            {
                dicData = rd.ToListDic().FirstOrDefault();
            }, param, commandType, timeout);
            return dicData;
        }

        /// <summary>
        /// Trả về danh sách tập dữ liệu
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu trả về</typeparam>
        /// <param name="query">Câu query</param>
        /// <param name="param">Danh sách tham số</param>
        /// <param name="commandType">Kiểu dữ liệu</param>
        /// <param name="timeout">Thời giam out</param>
        /// Create by: dvthang:23.03.2019
        public Dictionary<string, object> QueryDictionary(string query, Dictionary<string, object> param, CommandType? commandType = CommandType.Text, int? timeout = 300)
        {
            Dictionary<string, object> dicData = null;
            this.ProcessIDataReader(query, (rd) =>
            {
                dicData = rd.ToListDic().FirstOrDefault();
            }, param, commandType, timeout);
            return dicData;
        }

        /// <summary>
        /// Trả về danh sách tập dữ liệu
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu trả về</typeparam>
        /// <param name="query">Câu query</param>
        /// <param name="param">Danh sách tham số</param>
        /// <param name="commandType">Kiểu dữ liệu</param>
        /// <param name="timeout">Thời giam out</param>
        /// Create by: dvthang:23.03.2019
        public bool Execute(string query, object param = null, 
            CommandType? commandType = CommandType.Text, int? timeout = 300)
        {
            int retry = 5;
            bool success = false;
            while (retry > 0)
            {
                try
                {
                    using (DbCommand cmd = this.CreateCommand())
                    {
                        cmd.CommandText = query;
                        cmd.CommandType = commandType ?? CommandType.Text;
                        cmd.CommandTimeout = timeout ?? 300;                   
                        MappingParamsWithObject(cmd, param);

                        int rowEffect = ExecuteNoneQueryCmd(cmd);
                        success = rowEffect > 0;
                        retry = 0;
                    }
                }
                catch (SqlException ex) when (ex.Number == 1205)
                {
                    retry--;
                    System.Threading.Thread.Sleep(10000);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (transaction == null)
                    {
                        CloseConn();
                    }
                }
            }
            return success;
        }

        /// <summary>
        /// Trả về danh sách tập dữ liệu
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu trả về</typeparam>
        /// <param name="query">Câu query</param>
        /// <param name="param">Danh sách tham số</param>
        /// <param name="commandType">Kiểu dữ liệu</param>
        /// <param name="timeout">Thời giam out</param>
        /// Create by: dvthang:23.03.2019
        public bool Execute(string query, Dictionary<string,object> param ,
            CommandType? commandType = CommandType.Text, int? timeout = 300)
        {
            int retry = 5;
            bool success = false;
            while (retry > 0)
            {
                try
                {
                    using (DbCommand cmd = this.CreateCommand())
                    {
                        cmd.CommandText = query;
                        cmd.CommandType = commandType ?? CommandType.Text;
                        cmd.CommandTimeout = timeout ?? 300;
                        MappingParamsWithDictionary(cmd, param);

                        int rowEffect = ExecuteNoneQueryCmd(cmd);
                        success = rowEffect > 0;
                    }

                    retry = 0;
                }
                catch (SqlException ex) when (ex.Number == 1205)
                {
                    retry--;
                    System.Threading.Thread.Sleep(10000);
                }
                catch (Exception ex)
                {
                    retry = 0;
                    throw ex;
                }
                finally
                {
                    if (transaction == null)
                    {
                        CloseConn();
                    }
                }

            }
            return success;
        }

        /// <summary>
        /// Trả về danh sách tập dữ liệu
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu trả về</typeparam>
        /// <param name="query">Câu query</param>
        /// <param name="param">Danh sách tham số</param>
        /// <param name="commandType">Kiểu dữ liệu</param>
        /// <param name="timeout">Thời giam out</param>
        /// Create by: dvthang:23.03.2019
        public T ExecuteScalar<T>(string query, object param = null, 
            CommandType? commandType = CommandType.Text, int? timeout = 300)
        {
            try
            {
                using (DbCommand cmd = this.CreateCommand())
                {
                    cmd.CommandText = query;
                    cmd.CommandType = commandType ?? CommandType.Text;
                    cmd.CommandTimeout = timeout ?? 300;
                    MappingParamsWithObject(cmd, param);

                    object rs = ExecuteScalarCmd(cmd);
                    if (rs == null)
                    {
                        return default(T);
                    }
                    return rs.ChangeType<T>();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (transaction == null)
                {
                    CloseConn();
                }
            }
            return default(T);
        }

        /// <summary>
        /// Trả về danh sách tập dữ liệu
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu trả về</typeparam>
        /// <param name="query">Câu query</param>
        /// <param name="param">Danh sách tham số</param>
        /// <param name="commandType">Kiểu dữ liệu</param>
        /// <param name="timeout">Thời giam out</param>
        /// Create by: dvthang:23.03.2019
        public T ExecuteScalar<T>(string query, Dictionary<string,object> param ,
            CommandType? commandType = CommandType.Text, int? timeout = 300)
        {
            try
            {
                using (DbCommand cmd = this.CreateCommand())
                {
                    cmd.CommandText = query;
                    cmd.CommandType = commandType ?? CommandType.Text;
                    cmd.CommandTimeout = timeout ?? 300;
                    MappingParamsWithDictionary(cmd, param);

                    object rs = ExecuteScalarCmd(cmd);
                    if (rs == null)
                    {
                        return default(T);
                    }
                    return rs.ChangeType<T>();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (transaction == null)
                {
                    CloseConn();
                }
            }
            return default(T);
        }
        /// <summary>
        /// Trả về tập datareader
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu trả về</typeparam>
        /// <param name="query">Câu query</param>
        /// <param name="param">Danh sách tham số</param>
        /// <param name="commandType">Kiểu dữ liệu</param>
        /// <param name="timeout">Thời giam out</param>
        /// Create by: dvthang:24.08.2019
        public void ProcessIDataReader(string query, Action<IDataReader> method, object param = null, CommandType? commandType = CommandType.Text, int? timeout = 300)
        {
            try
            {
                using (DbCommand cmd = this.CreateCommand())
                {
                    cmd.CommandText = query;
                    cmd.CommandType = commandType ?? CommandType.Text;
                    cmd.CommandTimeout = timeout ?? 300;
                    MappingParamsWithObject(cmd, param);

                    using (IDataReader rd = ExecuteReaderCmd(cmd))
                    {
                        method(rd);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (transaction == null)
                {
                    CloseConn();
                }
            }
        }

        /// <summary>
        /// Trả về tập datareader
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu trả về</typeparam>
        /// <param name="query">Câu query</param>
        /// <param name="param">Danh sách tham số</param>
        /// <param name="commandType">Kiểu dữ liệu</param>
        /// <param name="timeout">Thời giam out</param>
        /// Create by: dvthang:24.08.2019
        public void ProcessIDataReader(string query, Action<IDataReader> method,
            Dictionary<string, object> param, CommandType? commandType = CommandType.Text, int? timeout = 300)
        {
            try
            {
                using (DbCommand cmd = this.CreateCommand())
                {
                    cmd.CommandText = query;
                    cmd.CommandType = commandType ?? CommandType.Text;
                    cmd.CommandTimeout = timeout ?? 300;
                    MappingParamsWithDictionary(cmd, param);

                    using (IDataReader rd = ExecuteReaderCmd(cmd))
                    {
                        method(rd);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (transaction == null)
                {
                    CloseConn();
                }
            }
        }
        /// <summary>
        /// Trả về danh sách tập dữ liệu
        /// </summary>
        /// <param name="store">tên store</param>
        /// <param name="parameters">danh sách tham số</param>
        /// <returns></returns>
        /// CreateBy:ThanhCong:10.09.2019
        public DataSet QueryDataSet(string query,
            Dictionary<string, object> param=null, CommandType? commandType = CommandType.Text, int? timeout = 300)
        {
            try
            {
                using (DbCommand cmd = this.CreateCommand())
                {
                    cmd.CommandText = query;
                    cmd.CommandType = commandType ?? CommandType.Text;
                    cmd.CommandTimeout = timeout ?? 300;
                    if (this.transaction != null)
                    {
                        cmd.Transaction = this.transaction;
                    }
                    MappingParamsWithDictionary(cmd, param);
                    DataSet data = ExecuteDataSetCmd(cmd);
                    return data;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (transaction == null)
                {
                    CloseConn();
                }
            }
        }


        /// <summary>
        /// Trả về danh sách tập dữ liệu
        /// </summary>
        /// <param name="store">tên store</param>
        /// <param name="parameters">danh sách tham số</param>
        /// <returns></returns>
        /// CreateBy:ThanhCong:10.09.2019
        public DataTable QueryDataTable(string query,
            Dictionary<string, object> param=null, CommandType? commandType = CommandType.Text, int? timeout = 300)
        {
            try
            {
                using (DbCommand cmd = this.CreateCommand())
                {
                    cmd.CommandText = query;
                    cmd.CommandType = commandType ?? CommandType.Text;
                    cmd.CommandTimeout = timeout ?? 300;
                    if (this.transaction != null)
                    {
                        cmd.Transaction = this.transaction;
                    }
                    MappingParamsWithDictionary(cmd, param);
                    DataSet data = ExecuteDataSetCmd(cmd);
                    if (data.Tables.Count > 0)
                    {
                        return data.Tables[0];
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (transaction == null)
                {
                    CloseConn();
                }
            }
        }

        /// <summary>
        /// Hàm lưu entity
        /// </summary>
        /// <param name="entity">Đối tượng cần lưu</param>
        /// <param name="tableName">Tên bảng</param>
        /// <param name="state">0:None,1:Add,2:Edit,3:Delete</param>
        /// <param name="includeCols">Danh sách cột thực hiện thao tác insert or update</param>
        /// <param name="exculeCols">Danh sách cột không thực hiện insert or update</param>
        /// <returns>true thành công, ngược lại thất bại</returns>
        public bool SaveEntity(BaseEntity entity, string tableName, MTEntityState state, 
            string primaryKeyName = "Id",string[] includeCols = null, string[] exculeCols = null)
        {
            bool success = false;
            List<Columns> columnsInfo = GetColumnsByTableName(tableName);
            List<string> columnNames = new List<string>();
            string cmdText = string.Empty;
            var colIdentity = columnsInfo.Find(m => m.IsIdentity);
            if (string.IsNullOrEmpty(primaryKeyName) && colIdentity != null)
            {
                primaryKeyName = colIdentity.ColumnName;
            }
            if (string.IsNullOrWhiteSpace(primaryKeyName))
            {
                primaryKeyName = "Id";
            }
            Dictionary<string, object> values = new Dictionary<string, object>();
            switch (state)
            {
                case MTEntityState.Add:
                    foreach (var item in columnsInfo)
                    {
                        if (item.IsIdentity
                            || primaryKeyName.Equals(item.ColumnName, StringComparison.OrdinalIgnoreCase)
                            || !entity.ExistsProperty(item.ColumnName))
                        {
                            continue;
                        }
                        if (exculeCols != null && exculeCols.Length > 0
                            && exculeCols.Contains(item.ColumnName))
                        {
                            continue;
                        }

                        if (includeCols != null && includeCols.Length > 0)
                        {
                            if (includeCols.Contains(item.ColumnName, StringComparer.OrdinalIgnoreCase))
                            {
                                columnNames.Add(item.ColumnName);
                                values.Add(item.ColumnName, entity[item.ColumnName]);
                            }
                        }
                        else
                        {
                            columnNames.Add(item.ColumnName);
                            values.Add(item.ColumnName, entity[item.ColumnName]);
                        }
                    }

                    if (colIdentity != null)
                    {
                        cmdText = $@"INSERT INTO {tableName}({string.Join(",", columnNames)}) 
                                VALUES({string.Join(",", columnNames.Select(m => $"@{m}"))});SELECT SCOPE_IDENTITY();";
                        long id2 = this.ExecuteScalar<long>(cmdText, values);
                        success = id2 > 0;
                        if (entity.ExistsProperty(primaryKeyName))
                        {
                            entity[primaryKeyName] = id2;
                        }
                        else
                        {
                            entity.SetValue(primaryKeyName, id2);
                        }
                    }
                    else
                    {
                        columnNames.Add(primaryKeyName);
                        values.Add(primaryKeyName, entity[primaryKeyName]);

                        cmdText = $@"INSERT INTO {tableName}({string.Join(",", columnNames)}) 
                                VALUES({string.Join(",", columnNames.Select(m => $"@{m}"))})";
                        success = this.Execute(cmdText, values);
                    }
                    break;
                case MTEntityState.Edit:
                    if (!entity.ExistsProperty(primaryKeyName) || entity[primaryKeyName] == null)
                    {
                        throw new Exception($"Cột khóa chính [{primaryKeyName}] không tồn tại hoặc bằng null");
                    }
                    foreach (var item in columnsInfo)
                    {
                        if (item.IsIdentity
                            || primaryKeyName.Equals(item.ColumnName, StringComparison.OrdinalIgnoreCase)
                            || !entity.ExistsProperty(item.ColumnName))
                        {
                            continue;
                        }
                        if (exculeCols != null && exculeCols.Length > 0
                           && exculeCols.Contains(item.ColumnName))
                        {
                            continue;
                        }

                        if (includeCols != null && includeCols.Length > 0)
                        {
                            if (includeCols.Contains(item.ColumnName, StringComparer.OrdinalIgnoreCase))
                            {
                                columnNames.Add(item.ColumnName);
                                values.Add(item.ColumnName, entity[item.ColumnName]);
                            }
                        }
                        else
                        {
                            columnNames.Add(item.ColumnName);
                            values.Add(item.ColumnName, entity[item.ColumnName]);
                        }
                    }

                    values.Add(primaryKeyName, entity[primaryKeyName]);

                    cmdText = $@"UPDATE {tableName} SET {string.Join(",", columnNames.Select(m => $"{m}=@{m}"))} 
                               WHERE {primaryKeyName}=@{primaryKeyName}";

                    success = this.Execute(cmdText, values);
                    break;
                case MTEntityState.Delete:
                    if (!entity.ExistsProperty(primaryKeyName) || entity[primaryKeyName] == null)
                    {
                        throw new Exception($"Cột khóa chính [{primaryKeyName}] không tồn tại hoặc bằng null");
                    }
                    cmdText = $"DELETE FROM {tableName} WHERE {primaryKeyName}=@{primaryKeyName}";
                    values.Add(primaryKeyName, entity[primaryKeyName]);
                    success = this.Execute(cmdText, values);
                    break;
                case MTEntityState.InsertOrUpdate:
                    object primarykey = null;
                    if (!entity.ExistsProperty(primaryKeyName) || entity[primaryKeyName] == null)
                    {
                        throw new Exception($"Cột khóa chính [{primaryKeyName}] không tồn tại hoặc bằng null");
                    }
                    primarykey = entity[primaryKeyName];

                    foreach (var item in columnsInfo)
                    {
                        if (item.IsIdentity
                            || primaryKeyName.Equals(item.ColumnName, StringComparison.OrdinalIgnoreCase)
                            || !entity.ExistsProperty(item.ColumnName))
                        {
                            continue;
                        }
                        if (exculeCols != null && exculeCols.Length > 0
                           && exculeCols.Contains(item.ColumnName))
                        {
                            continue;
                        }

                        if (includeCols != null && includeCols.Length > 0)
                        {
                            if (includeCols.Contains(item.ColumnName, StringComparer.OrdinalIgnoreCase))
                            {
                                columnNames.Add(item.ColumnName);
                                values.Add(item.ColumnName, entity[item.ColumnName]);
                            }
                        }
                        else
                        {
                            columnNames.Add(item.ColumnName);
                            values.Add(item.ColumnName, entity[item.ColumnName]);
                        }
                    }

                    values.Add(primaryKeyName, primarykey);

                    string cmdTextIdentity = ";SELECT SCOPE_IDENTITY()";


                    cmdText = $@"IF EXISTS(SELECT TOP 1 FROM {tableName} WHERE {primaryKeyName}=@{primaryKeyName})
                                    BEGIN
                                        UPDATE {tableName} SET {string.Join(",", columnNames.Select(m => $"{m}=@{m}"))} 
                                        WHERE {primaryKeyName}=@{primaryKeyName} 
                                        ;SELECT -1;
                                    END";

                    if (colIdentity == null)
                    {
                        cmdTextIdentity = string.Empty;
                        columnNames.Add(primaryKeyName);
                    }

                    cmdText += $@"ELSE
                                    BEGIN
                                        INSERT INTO {tableName}({string.Join(",", columnNames)}) 
                                        VALUES({string.Join(",", columnNames.Select(m => $"@{m}"))})
                                        {cmdTextIdentity}
                                    END";

                    long id = this.ExecuteScalar<long>(cmdText, values);
                    success = id == -1 || id > 0;
                    if (entity.ExistsProperty(primaryKeyName))
                    {
                        if (id > 0)
                        {
                            entity[primaryKeyName] = id;
                        }

                    }
                    else
                    {
                        if (id > 0)
                        {
                            entity.SetValue(primaryKeyName, id);
                        }
                    }
                    break;
            }

            return success;
        }

        /// <summary>
        /// Hàm lưu dạng dictionary
        /// </summary>
        /// <param name="entity">Đối tượng cần lưu</param>
        /// <param name="tableName">Tên bảng</param>
        /// <param name="state">0:None,1:Add,2:Edit,3:Delete</param>
        /// <param name="includeCols">Danh sách cột thực hiện thao tác insert or update</param>
        /// <param name="exculeCols">Danh sách cột không thực hiện insert or update</param>
        /// <returns>true thành công, ngược lại thất bại</returns>
        public bool SaveEntity(Dictionary<string, object> dicData, string tableName, MTEntityState state,
            string primaryKeyName = "Id", string[] includeCols = null, string[] exculeCols = null)
        {
            bool success = false;
            List<Columns> columnsInfo = GetColumnsByTableName(tableName);
            List<string> columnNames = new List<string>();
            string cmdText = string.Empty;
            var colIdentity = columnsInfo.Find(m => m.IsIdentity);
            if (string.IsNullOrEmpty(primaryKeyName) && colIdentity != null)
            {
                primaryKeyName = colIdentity.ColumnName;
            }
            if (string.IsNullOrWhiteSpace(primaryKeyName))
            {
                primaryKeyName = "Id";
            }
            Dictionary<string, object> values = new Dictionary<string, object>();
            switch (state)
            {
                case MTEntityState.Add:
                    foreach (var item in columnsInfo)
                    {
                        if (item.IsIdentity 
                            || primaryKeyName.Equals(item.ColumnName, StringComparison.OrdinalIgnoreCase)
                            || !dicData.ContainsKey(item.ColumnName))
                        {
                            continue;
                        }
                        if (exculeCols!=null && exculeCols.Length>0
                            && exculeCols.Contains(item.ColumnName))
                        {
                            continue;
                        }

                        if (includeCols != null && includeCols.Length > 0)
                        {
                            if (includeCols.Contains(item.ColumnName, StringComparer.OrdinalIgnoreCase))
                            {
                                columnNames.Add(item.ColumnName);
                                values.Add(item.ColumnName, dicData[item.ColumnName]);
                            }
                        }
                        else
                        {
                            columnNames.Add(item.ColumnName);
                            values.Add(item.ColumnName, dicData[item.ColumnName]);
                        }
                    }
                   
                    if (colIdentity != null)
                    {
                        cmdText = $@"INSERT INTO {tableName}({string.Join(",", columnNames)}) 
                                VALUES({string.Join(",", columnNames.Select(m => $"@{m}"))});SELECT SCOPE_IDENTITY();";
                        long id2= this.ExecuteScalar<long>(cmdText, values);
                        success = id2 > 0;
                        if (dicData.ContainsKey(primaryKeyName))
                        {
                            dicData[primaryKeyName] = id2;
                        }
                        else
                        {
                            dicData.Add(primaryKeyName, id2);
                        }
                    }
                    else
                    {
                        columnNames.Add(primaryKeyName);
                        values.Add(primaryKeyName, dicData[primaryKeyName]);

                        cmdText = $@"INSERT INTO {tableName}({string.Join(",", columnNames)}) 
                                VALUES({string.Join(",", columnNames.Select(m => $"@{m}"))})";
                        success = this.Execute(cmdText, values);
                    }
                    break;
                case MTEntityState.Edit:
                    if (!dicData.ContainsKey(primaryKeyName) || dicData[primaryKeyName] == null)
                    {
                        throw new Exception($"Cột khóa chính [{primaryKeyName}] không tồn tại hoặc bằng null");
                    }
                    foreach (var item in columnsInfo)
                    {
                        if (item.IsIdentity 
                            || primaryKeyName.Equals(item.ColumnName,StringComparison.OrdinalIgnoreCase)
                            ||!dicData.ContainsKey(item.ColumnName))
                        {
                            continue;
                        }
                        if (exculeCols != null && exculeCols.Length > 0
                           && exculeCols.Contains(item.ColumnName))
                        {
                            continue;
                        }

                        if (includeCols != null && includeCols.Length > 0)
                        {
                            if (includeCols.Contains(item.ColumnName, StringComparer.OrdinalIgnoreCase))
                            {
                                columnNames.Add(item.ColumnName);
                                values.Add(item.ColumnName, dicData[item.ColumnName]);
                            }
                        }
                        else
                        {
                            columnNames.Add(item.ColumnName);
                            values.Add(item.ColumnName, dicData[item.ColumnName]);
                        }
                    }

                    values.Add(primaryKeyName, dicData[primaryKeyName]);

                    cmdText = $@"UPDATE {tableName} SET {string.Join(",",columnNames.Select(m=>$"{m}=${m}"))} 
                               WHERE {primaryKeyName}=@{primaryKeyName}";

                    success = this.Execute(cmdText, values);
                    break;
                case MTEntityState.Delete:
                    if (!dicData.ContainsKey(primaryKeyName) || dicData[primaryKeyName] == null)
                    {
                        throw new Exception($"Cột khóa chính [{primaryKeyName}] không tồn tại hoặc bằng null");
                    }
                    cmdText = $"DELETE FROM {tableName} WHERE {primaryKeyName}=@{primaryKeyName}";
                    values.Add(primaryKeyName, dicData[primaryKeyName]);
                    success = this.Execute(cmdText, values);
                    break;
                case MTEntityState.InsertOrUpdate:
                    object primarykey=null;
                    if (!dicData.ContainsKey(primaryKeyName) || dicData[primaryKeyName]==null)
                    {
                        throw new Exception($"Cột khóa chính [{primaryKeyName}] không tồn tại hoặc bằng null");
                    }
                    primarykey = dicData[primaryKeyName];

                    foreach (var item in columnsInfo)
                    {
                        if (item.IsIdentity
                            || primaryKeyName.Equals(item.ColumnName, StringComparison.OrdinalIgnoreCase)
                            || !dicData.ContainsKey(item.ColumnName))
                        {
                            continue;
                        }
                        if (exculeCols != null && exculeCols.Length > 0
                           && exculeCols.Contains(item.ColumnName))
                        {
                            continue;
                        }

                        if (includeCols != null && includeCols.Length > 0)
                        {
                            if (includeCols.Contains(item.ColumnName, StringComparer.OrdinalIgnoreCase))
                            {
                                columnNames.Add(item.ColumnName);
                                values.Add(item.ColumnName, dicData[item.ColumnName]);
                            }
                        }
                        else
                        {
                            columnNames.Add(item.ColumnName);
                            values.Add(item.ColumnName, dicData[item.ColumnName]);
                        }
                    }

                    values.Add(primaryKeyName, primarykey);

                    string cmdTextIdentity = ";SELECT SCOPE_IDENTITY()";
                    

                    cmdText = $@"IF EXISTS(SELECT TOP 1 FROM {tableName} WHERE {primaryKeyName}=@{primaryKeyName})
                                    BEGIN
                                        UPDATE {tableName} SET {string.Join(",", columnNames.Select(m => $"{m}=${m}"))} 
                                        WHERE {primaryKeyName}=@{primaryKeyName} 
                                        ;SELECT -1;
                                    END";

                    if (colIdentity == null)
                    {
                        cmdTextIdentity = string.Empty;
                        columnNames.Add(primaryKeyName);
                    }

                    cmdText +=$@"ELSE
                                    BEGIN
                                        INSERT INTO {tableName}({string.Join(",", columnNames)}) 
                                        VALUES({string.Join(",", columnNames.Select(m => $"@{m}"))})
                                        {cmdTextIdentity}
                                    END";

                    long id = this.ExecuteScalar<long>(cmdText, values);
                    success = id == -1 || id > 0;
                    if (dicData.ContainsKey(primaryKeyName))
                    {
                        if (id > 0)
                        {
                            dicData[primaryKeyName] = id;
                        }

                    }
                    else
                    {
                        if (id > 0)
                        {
                            dicData.Add(primaryKeyName, id);
                        }
                    }
                    break;
            }

            return success;
        }

        /// <summary>
        /// Lấy về danh sách cột của bảng
        /// </summary>
        /// <param name="tableName">Tên bảng</param>
        /// <returns>Danh sách cột</returns>
        private List<Columns> GetColumnsByTableName(string tableName)
        {
            List<Columns> cols = new List<Columns>();
            if (!MT.Library.SessionData.MappingTableWithCols.TryGetValue(tableName,out cols))
            {
                string query = $@"select COLUMN_NAME as ColumnName, sc.DATA_TYPE as DataType, sc.CHARACTER_MAXIMUM_LENGTH as MaxLength, 
	                        case when sc.IS_NULLABLE='YES' then 1 else 0 end as IsNullAble,c.is_identity as IsIdentity from sys.columns c
	                        join INFORMATION_SCHEMA.COLUMNS sc on c.Name=sc.COLUMN_NAME AND sc.TABLE_NAME='{tableName}'	AND sc.TABLE_SCHEMA='dbo'
	                        where c.object_id=object_id('{tableName}','U')";
                cols = this.Query<Columns>(query);
                if (cols != null && cols.Count > 0)
                {
                    MT.Library.SessionData.MappingTableWithCols.TryAdd(tableName, cols);
                }
            }
            return cols;
        }

        /// <summary>
        /// Hàm thực hiện insert sử dụng bulkinsert
        /// </summary>
        /// <param name="datas">Dữ liệu cần insert</param>
        /// <param name="tableName">Tên bảng cần insert</param>
        /// <returns>true: Insert thành công, ngược lại thất bại</returns>
        public bool BulkInsert<T>(List<T> datas,string tableName,string columns="*")
        {
            bool success = false;
            try
            {
                using (DbCommand cmd = this.CreateCommand())
                {
                    using (var copy = new SqlBulkCopy((SqlConnection)cmd.Connection))
                    {
                        copy.BatchSize = 1000;
                        copy.DestinationTableName = tableName;
                        
                        string[] arrCol = null;
                        if (!string.IsNullOrWhiteSpace(columns) && !"*".Equals(columns))
                        {
                            arrCol = columns.Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        }
                        DataTable dataTable = datas.ToDataTable<T>();
                        foreach (DataColumn column in dataTable.Columns)
                        {
                            if(arrCol!=null && !arrCol.Contains(column.ColumnName))
                            {
                                continue;
                            }
                            copy.ColumnMappings.Add(
                                 new SqlBulkCopyColumnMapping()
                                 {
                                     SourceColumn = column.ColumnName,
                                     DestinationColumn = column.ColumnName
                                 }
                               );

                        }
                        copy.WriteToServer(dataTable);
                    }
                }

                success = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (transaction == null)
                {
                    CloseConn();
                }
            }

            return success;
        }

        /// <summary>
        /// Hàm thực hiện insert sử dụng bulkinsert
        /// </summary>
        /// <param name="datas">Dữ liệu cần insert</param>
        /// <param name="tableName">Tên bảng cần insert</param>
        /// <returns>true: Insert thành công, ngược lại thất bại</returns>
        public bool BulkInsert(DataTable datas, string tableName, string columns = "*")
        {
            bool success = false;
            try
            {
                using (DbCommand cmd = this.CreateCommand())
                {
                    using (var copy = new SqlBulkCopy((SqlConnection)cmd.Connection))
                    {
                        copy.BatchSize = 1000;
                        copy.DestinationTableName = tableName;
                        if (!string.IsNullOrWhiteSpace(columns) && !"*".Equals(columns))
                        {
                            string[] arrCol = columns.Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                            foreach (var item in arrCol)
                            {
                                copy.ColumnMappings.Add(item, item);
                            }
                        }
                        copy.WriteToServer(datas);
                    }
                }

                success = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (transaction == null)
                {
                    CloseConn();
                }
            }

            return success;
        }
        ~UnitOfWork()
        {
            this.Dispose();
        }
    }
}

