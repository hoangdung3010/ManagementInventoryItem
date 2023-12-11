using MT.Data.Rep;
using MT.Library;
using MT.Library.UW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MT.Data.ExchangeData
{
    public class ManagementData
    {
        private static ManagementData _instance;
        public static ManagementData Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ManagementData();
                }

                return _instance;
            }
        }

        /// <summary>
        /// Lưu data thay đổi(Thêm+ Sửa)
        /// </summary>
        public void SaveChangedData(object objectId, string tableName)
        {
            Task.Run(() =>
            {
                try
                {
                   

                    using (IUnitOfWork unitOfWork = new UnitOfWork(MT.Library.SessionData.ConnectString))
                    {
                        string query = "IF EXISTS(SELECT 1 FROM SortOrderExportData WHERE TableName=@TableName AND IsDictionary=0) SELECT 1 ELSE SELECT 0";

                        bool exists = unitOfWork.QueryFirstOrDefault<bool>(query, new { TableName = tableName });
                        if (exists)
                        {
                            query = $"DELETE FROM ChangedData where ObjectId='{objectId}'";
                            unitOfWork.Execute(query);
                            unitOfWork.SaveEntity(new Dictionary<string, object>
                            {
                                {"Id", Guid.NewGuid()},
                                {"ObjectId", objectId},
                                {"TableName", tableName},
                                {"CreatedDate",SysDateTime.Instance.Now()},
                            }, "ChangedData", Enummation.MTEntityState.Add);
                        }    
                            
                    }
                }
                catch (Exception ex)
                {
                    MT.Library.Log.LogHelper.Error(ex, ex.Message);
                }
            });
            
        }

        /// <summary>
        /// Lưu data thay đổi(Thêm+ Sửa)
        /// </summary>
        public void SaveChangedData(BaseEntity baseEntity)
        {
            SaveChangedData(baseEntity.GetIdentity(), baseEntity.TableName);
        }

        /// <summary>
        /// Lưu data bị xóa
        /// </summary>
        public void SaveDeleteObject(object objectId,string tableName)
        {
            Task.Run(() =>
            {
                try
                {
                    using (IUnitOfWork unitOfWork = new UnitOfWork(MT.Library.SessionData.ConnectString))
                    {
                        string query = "IF EXISTS(SELECT 1 FROM SortOrderExportData WHERE TableName=@TableName) SELECT 1 ELSE SELECT 0";

                        bool exists = unitOfWork.QueryFirstOrDefault<bool>(query,new { TableName =tableName});
                        if (exists)
                        {
                            unitOfWork.SaveEntity(new Dictionary<string, object>
                            {
                                {"Id", Guid.NewGuid()},
                                {"ObjectId", objectId},
                                {"TableName", tableName},
                                {"CreatedDate", SysDateTime.Instance.Now()},
                            }, "DeleteObject", Enummation.MTEntityState.Add);
                        }
                       
                    }
                }
                catch (Exception ex)
                {

                    MT.Library.Log.LogHelper.Error(ex, ex.Message);
                }
            });
            
        }

        /// <summary>
        /// Lưu data bị xóa
        /// </summary>
        public void SaveDeleteObject(BaseEntity baseEntity)
        {
            SaveDeleteObject(baseEntity.GetIdentity(), baseEntity.TableName);
        }
    }
}
