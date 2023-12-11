using MT.Data.BO;
using MT.Data.ExchangeData;
using MT.Data.Resources;
using MT.Library;
using MT.Library.BO;
using MT.Library.Extensions;
using MT.Library.Log;
using MT.Library.UW;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static MT.Library.Enummation;

namespace MT.Data.Rep
{
    /// <summary>
    /// Đối tượng xử lý thao tác liên quan đến database
    /// </summary>
    public class BaseRepository<TEntity>: IBaseRepository
        where TEntity : BaseEntity
    {
        protected readonly IUnitOfWork _unitOfWork;

        private static string[] _canCuPhieu = new string[]
        {
           "Phieu_NhapSanPhamMoi",
           "Phieu_NhapSanPham", "Phieu_XuatSanPham",
           "Phieu_NhapSuaChuaSanPham", "Phieu_XuatSuaChuaSanPham",
           "Phieu_NhapMuonTra", "Phieu_XuatMuonTra",
           "Phieu_NhapCaiDatSanPham","Phieu_XuatCaiDatSanPham",
           "Phieu_NhapBaoHanhSanPham", "Phieu_XuatBaoHanhSanPham",
           "Phieu_NhapBaoHanhSanPham","Phieu_XuatBaoHanhSanPham",
           "Phieu_XuatTHTH","Phieu_NhapTHTH","KH_XuatSanPham"
        };

        public BaseRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Hàm xóa danh sách đối tượng
        /// </summary>
        /// <param name="entities">Danh sách thực thể</param>
        /// <returns>=true: Tất cả xóa thành công hoặc có bản ghi xóa thành công, ngược lại tất cả đều lỗi</returns>
        public ResultData DeleteData(IList entities)
        {
            ResultData resultData = new ResultData { Success = true };
            try
            {
                List<BaseEntity> dataLogs = new List<BaseEntity>();
                List<object> idsSuccess = new List<object>();
                List<DeleteError> delErrors = new List<DeleteError>();
                foreach (var item in entities)
                {
                    TEntity entity = item as TEntity;
                    string msgError = string.Empty;
                    bool hasIncurrentData = this.CheckIncurrentDataBeforeDelete(entity,ref msgError);

                    if (!hasIncurrentData)
                    {
                        DeleteError deleteError = new DeleteError();
                        this.ValidateBeforeDelete(entity, deleteError);

                        if (string.IsNullOrEmpty(deleteError.Msg))
                        {
                            try
                            {
                                Dictionary<string, object> param = new Dictionary<string, object>()
                                {
                                     {entity.GetPrimaryKeyName(),entity.GetIdentity() }
                                };
                                var  dicCodeAttrs = entity.GetCodeAttributes();
                                string query = string.Empty;
                                TEntity oldData = null;
                                if (dicCodeAttrs!=null && dicCodeAttrs.Count > 0)
                                {
                                    query = $@"SELECT {string.Join(",", dicCodeAttrs.Select(m => m.Key))} FROM {entity.TableName} 
                                                WHERE {entity.GetPrimaryKeyName()}=@{entity.GetPrimaryKeyName()}";
                                    oldData = _unitOfWork.QueryFirstOrDefault<TEntity>(query, param);
                                    oldData.MTEntityState = MTEntityState.Delete;
                                }

                                _unitOfWork.BeginTransaction();

                                this.BeforeDeleteRecord(entity);

                                query = $"DELETE FROM {entity.TableName} WHERE {entity.GetPrimaryKeyName()}=@{entity.GetPrimaryKeyName()}";
                                bool success = _unitOfWork.Execute(query, param);

                                this.AfterDeleteBeforeCommit(entity);

                                _unitOfWork.Commit();

                                idsSuccess.Add(entity.GetIdentity());

                                this.AfterDeleteCommit(entity);

                                entity.MTEntityState = MTEntityState.Delete;
                                dataLogs.Add(oldData!=null? oldData: entity);
                            }
                            catch (Exception ex)
                            {
                                _unitOfWork.RollBack();
                                delErrors.Add(new DeleteError
                                {
                                    Id = entity.GetIdentity(),
                                    ErrorType = MT.Library.Enummation.ErrorType.Exception,
                                    Msg = ex.Message
                                });
                            }
                            finally
                            {
                                _unitOfWork.Dispose();
                            }
                        }
                        else
                        {
                            deleteError.Id = entity.GetIdentity();
                            if (deleteError.ErrorType == ErrorType.None)
                            {
                                deleteError.ErrorType = ErrorType.Business;
                            }
                            delErrors.Add(deleteError);
                        }
                    }
                    else
                    {
                        //Dữ liệu có phát sinh
                        delErrors.Add(new DeleteError
                        {
                            Id = entity.GetIdentity(),
                            ErrorType = MT.Library.Enummation.ErrorType.IncurrentData,
                            Msg = msgError
                        });
                    }
                }

                resultData.Data = delErrors;

                if (delErrors != null && delErrors.Count>0)
                {
                    resultData.UserMsg = string.Join("; ", delErrors.Select(m=>m.Msg));
                }
                if (idsSuccess.Count == 0)
                {
                    resultData.Success = false;
                }
                else
                {
                    WriteLog(dataLogs);
                }
            }
            catch (Exception ex)
            {
                resultData.SetError(ex);
            }
            finally
            {
                this._unitOfWork.Dispose();
            }
            return resultData;
        }


        /// <summary>
        /// Hàm lưu đối tượng
        /// </summary>
        /// <param name="entity">Đối tượng cần lưu</param>
        public ResultData SaveData(BaseEntity entity)
        {
            ResultData resultData = new ResultData { Success = true };
            try
            {
                this.ValidateBeforeSave(entity, resultData);

                if (resultData.Success)
                {
                    this.PreSaveData(entity);

                    List<BaseEntity> dataLogs = new List<BaseEntity>();

                    this._unitOfWork.BeginTransaction();

                    resultData.Success = this.DoSave(entity, entity.DetailConfig, ref dataLogs);

                    if (resultData.Success)
                    {
                        //Xử lý lưu thông tin tệp đính kèm
                        if (entity.TepDinhKems?.Count > 0)
                        {
                            foreach (TepDinhKem item in entity.TepDinhKems)
                            {
                                //Bản qua các bản ghi có mode là sửa vì không dùng
                                if (item.MTEntityState == MTEntityState.Edit)
                                {
                                    continue;
                                }
                                item.sRefId =(Guid)entity.GetIdentity();
                                DoSave(item, item.DetailConfig, ref dataLogs);
                            }
                        }
                        this.AfterSave(entity);

                        this._unitOfWork.Commit();

                        this.AfterCommitSave(entity);

                        this.WriteLog(dataLogs);
                    }
                    else
                    {
                        resultData.Success = false;
                        this._unitOfWork.RollBack();
                    }
                }
                
            }
            catch (Exception ex)
            {
                resultData.SetError(ex);
            }
            finally
            {
                this._unitOfWork.Dispose();
            }
            return resultData;
        }

        /// <summary>
        /// Lấy về chi tiết bản ghi theo ID
        /// </summary>
        /// <param name="id">ID bản ghi</param>
       public BaseEntity GetDataById(object id)
        {
            BaseEntity baseEntity = Activator.CreateInstance<TEntity>();
            string primaryKeyName = baseEntity.GetPrimaryKeyName();
            string viewName = $"View_{baseEntity.TableName}";
            string query = $@"IF OBJECT_ID('{viewName}', 'V') IS NOT NULL
                                SELECT * FROM {viewName} WHERE {primaryKeyName}=@{primaryKeyName}
                              ELSE
                                SELECT * FROM { baseEntity.TableName} WHERE {primaryKeyName}=@{primaryKeyName}";
            baseEntity = _unitOfWork.QueryFirstOrDefault<TEntity>(query, new Dictionary<string, object> { { primaryKeyName, id } });
            return baseEntity;
        }

        /// <summary>
        /// Xử lý luồng ghi log
        /// </summary>
        /// <param name="dataLogs">Danh sách đối tượng ghi log</param>
        private void WriteLog(List<BaseEntity> dataLogs)
        {
            if (dataLogs != null && dataLogs.Count > 0)
            {
                try
                {
                    Parallel.ForEach(dataLogs, oItem =>
                    {
                        this.InsertAuditLog(oItem);
                    });
                }
                catch (Exception ex)
                {
                    LogHelper.Error(ex,ex.Message);
                }
            }
        }

        /// <summary>
        /// Hàm thực hiện ghi log cho ứng dụng
        /// </summary>
        /// <param name="oEntity">Đối tượng log</param>
        /// Create by: dvthang:31.03.2021
        private void InsertAuditLog(BaseEntity oEntity)
        {
            try
            {
                string desEntity = string.Empty;
                SessionData.Resources.TryGetValue(oEntity.TableName.ToLower(), out desEntity);
                if (string.IsNullOrEmpty(desEntity))
                {
                    return;
                }
                string description = string.Empty;
                string entityInfo = string.Empty;

                if (oEntity.MTEntityState != Enummation.MTEntityState.Delete)
                {
                    description = oEntity.GetDescriptionLog();
                }
                entityInfo = oEntity.GetDescriptionSummary();

                string actionName = "";
                switch (oEntity.MTEntityState)
                {
                    case MTEntityState.Add:
                        actionName = "Thêm mới";
                        break;
                    case MTEntityState.Edit:
                        actionName = "Sửa";
                        break;
                    case MTEntityState.Delete:
                        actionName = "Xóa";
                        break;
                }
                var oAuditLog = new Dictionary<string,object>
                {
                    {"Id" , Guid.NewGuid() },
                    {"FunctionName" , desEntity },
                    {"LogTime" , SysDateTime.Instance.Now() },
                    {"UserId",MT.Library.SessionData.UserId },
                    {"UserName" ,MT.Library.SessionData.UserName },
                    {"EntityId" , oEntity.GetIdentity().ToString() },
                    {"ActionName" , actionName },
                    {"Description" , description },
                    {"EntityInfo" , entityInfo },
                    {"CreatedBy" , MT.Library.SessionData.UserName }
                };
                using (IUnitOfWork unitOfWork =new UnitOfWork(MT.Library.SessionData.ConnectString))
                {
                    unitOfWork.SaveEntity(oAuditLog, "AuditingLog", MTEntityState.Add);
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex,ex.Message);
            }
        }

        /// <summary>
        /// Thực hiện ghi log của hành động
        /// </summary>
        /// Created by: dvthang: 19.12.2020
        public void InsertAuditingLog(string tableName, string functionName, string actionName, string description)
        {
            Task.Run(() =>
            {
                try
                {
                    using (IUnitOfWork unitOfWork = new UnitOfWork(MT.Library.SessionData.ConnectString))
                    {
                        unitOfWork.Execute("Proc_InsertAuditingLog", new
                        {
                            FunctionName = functionName,
                            UserId = MT.Library.SessionData.UserId,
                            ActionName = actionName,
                            Description = description,
                            CreatedBy = MT.Library.SessionData.UserName
                        }, CommandType.StoredProcedure);
                    }
                }
                catch (Exception ex)
                {
                   LogHelper.Error(ex, ex.Message);
                }
            });

        }

        /// <summary>
        /// Thực hiện xử lý gì đó trước khi mở transaction
        /// </summary>
        /// <param name="id">
        /// Thông tin master</param>
        /// <param name="deleteError">Đối tượng chuối thông tin lỗi nếu có</param>
        /// Create by: dvthang:07.01.2018
        protected virtual void ValidateBeforeDelete(TEntity entity, DeleteError deleteError)
        {
            object id = entity.GetIdentity();
            //Kiểm tra nếu là dữ liệu mang đi IsSysTem=1 thì không cho xóa
            string query = $@"IF COL_LENGTH('dbo.{entity.TableName}','IsSystem') IS NOT NULL
                            BEGIN
                              EXEC('IF EXISTS(SELECT 1 FROM dbo.{entity.TableName} WHERE Id=''{id}'' AND IsSystem=1) SELECT 1 ELSE SELECT 0');
                            END
                            ELSE SELECT 0;";
            bool exists = _unitOfWork.ExecuteScalar<bool>(query);

            if (exists)
            {
                Dictionary<string, CodeAttribute> codes = entity.GetCodeAttributes();
                if(codes==null || codes.Count == 0)
                {
                    deleteError.Msg = "Bản ghi là dữ liệu hệ thống mang đi bạn không được xóa";
                    deleteError.Id = id;
                    return;
                }
                else
                {
                    query = $@"SELECT {string.Join(",", codes.Select(m=>m.Key))} FROM dbo.{entity.TableName}  WHERE Id='{id}'";

                    var data = _unitOfWork.QueryFirstOrDefault<TEntity>(query);
                    string[] arrMsg = new string[codes.Count];
                    int i = 0;
                    foreach (var item in codes)
                    {
                        arrMsg[i] = data.GetValue<string>(item.Key);
                    }

                    deleteError.Msg = $@"Bản ghi <{string.Join(" - ", arrMsg)}> là dữ liệu hệ thống mang đi bạn không được xóa";
                    deleteError.Id = id;
                }
               
            }
        }

        /// <summary>
        /// Hàm kiểm tra đã có phát sinh dữ liệu
        /// </summary>
        /// <param name="tableName">Tên bảng</param>
        /// <param name="id">ID của bảng</param>
        /// Trả về true là đã phát sinh dữ liệu, false nghĩa là chưa phát sinh
        protected virtual bool CheckIncurrentDataBeforeDelete(TEntity entity,ref string msg)
        {
            string query = $"SELECT * FROM  dbo.IncurrentData WHERE TableName=@TableName";

            var incurrentDatas = _unitOfWork.Query<IncurrentData>(query, new { TableName= entity.TableName });

            if(incurrentDatas!=null && incurrentDatas.Count > 0)
            {
                List<string> listMsg = new List<string>();
                foreach (var item in incurrentDatas)
                {
                    if (item.ReferenceTableName.Contains("@"))
                    {
                        query = $"SELECT TOP 10 {item.ReferenceCode} FROM {item.ReferenceTableName} AS T ";
                    }
                    else
                    {
                        query = $"SELECT TOP 10 {item.ReferenceCode} FROM {item.ReferenceTableName} AS T WHERE {item.ReferenceColumnName}=@{item.ReferenceColumnName}";
                    }

                    List<string> listMa= _unitOfWork.Query<string>(query, new Dictionary<string, object>
                    {
                        {item.ReferenceColumnName,entity.GetIdentity() }
                    });

                    if (listMa?.Count>0)
                    {
                        query = $"SELECT {item.Code} FROM {entity.TableName} WHERE Id=@Id";
                        string sCode= _unitOfWork.QueryFirstOrDefault<string>(query, new Dictionary<string, object>
                        {
                            {"Id",entity.GetIdentity() }
                        });
                        listMsg.Add(string.Format(item.Msg, sCode, string.Join("; ", listMa)));
                        
                    }
                }

                if (listMsg?.Count > 0)
                {
                    msg = string.Join("\n\r", listMsg)+ "\n\rBạn không được phép xóa.";
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Truowcj khi xóa dữ liệu
        /// </summary>
        /// <param name="oEntity"></param>
        protected virtual void BeforeDeleteRecord(TEntity oEntity)
        {
            GhiSoKho.LuuSo(_unitOfWork, oEntity);
        }


        /// <summary>
        /// Thực hiện xử lý gì đó sau khi mở transaction
        /// </summary>
        /// <param name="master">Thông tin master</param>
        /// <param name="details">Danh sách detail</param>
        /// Create by: dvthang:07.01.2018
        protected virtual void AfterDeleteCommit(TEntity oEntity)
        {
            ManagementData.Instance.SaveDeleteObject(oEntity);

        }

        /// <summary>
        /// Thực hiện xử lý gì đó trước khi commit transaction
        /// </summary>
        /// <param name="master">Thông tin master</param>
        /// <param name="details">Danh sách detail</param>
        /// Create by: dvthang:07.01.2018
        protected virtual void AfterDeleteBeforeCommit(TEntity oEntity)
        {
            DeleteCanCuPhieu(oEntity);
        }

        /// <summary>
        /// Thực hiện xử lý gì đó trước khi mở transaction
        /// </summary>
        /// <param name="master">Thông tin master</param>
        /// <param name="details">Danh sách detail</param>
        /// Create by: dvthang:07.01.2018
        protected virtual void ValidateBeforeSave(BaseEntity entity, ResultData resultData)
        {
            if (ValidateDuplicate(entity))
            {
                Dictionary<string, CodeAttribute> codes = entity.GetCodeAttributes();
                if(codes==null || codes.Count == 0)
                {
                    return;
                }
                string[] msgError = new string[codes.Count];
                int i = 0;
                foreach (var item in codes)
                {
                    string msgResource = SystemLogResource.ResourceManager.GetString($"{entity.TableName}_{item.Key}");
                    if (string.IsNullOrEmpty(msgResource))
                    {
                        msgResource = $"Trường mã";
                    }
                    msgResource += $" <{entity.GetValue(item.Key)}> đã tồn tại trong hệ thống.";
                    msgError[i++] = msgResource;
                }
                resultData.DevMsg = string.Join(", ", msgError);
                resultData.UserMsg = string.Join(", ", msgError);
                resultData.Success = false;
            }
        }

        /// <summary>
        /// Thực hiện xử lý gì đó sau khi mở transaction
        /// </summary>
        /// <param name="master">Thông tin master</param>
        /// Create by: dvthang:31.03.2021
        protected virtual void PreSaveData(BaseEntity entity)
        {
            if ((entity.MTEntityState == MTEntityState.Add || entity.MTEntityState == MTEntityState.Duplicate) && !entity.HasIdentity())
            {
                var id = entity.GetIdentity();
                if(id==null || Guid.Empty.ToString().Equals(id.ToString()))
                {
                    entity.SetIdentity(Guid.NewGuid());
                }
            }
        }

        /// <summary>
        /// Ham thuc hien sau khi luu xong
        /// </summary>
        /// <param name="master">Thông tin master</param>
        /// Create by: dvthang:31.03.2021
        protected virtual void AfterSave(BaseEntity entity)
        {
           
        }


        /// <summary>
        /// Thực hiện xử lý gì đó sau khi mở transaction
        /// </summary>
        /// <param name="master">Thông tin master</param>
        /// <param name="details">Danh sách detail</param>
        /// Create by: dvthang:31.03.2021
        protected virtual void AfterCommitSave(BaseEntity entity)
        {
            if (entity.SequenceVoucherId > 0)
            {
                string query = $"UPDATE dbo.SequenceVoucher SET bUsed=1,sSuffix=@sSuffix WHERE Id={entity.SequenceVoucherId}";
                _unitOfWork.Execute(query, new { sSuffix=entity.GetValue<string>("sChu") });
            }

            GhiSoKho.LuuSo(_unitOfWork, entity);

            AddNewCanCuPhieu(entity);

            ManagementData.Instance.SaveChangedData(entity);
        }
        #region"Overrides"
        /// <summary>
        /// Hàm thực hiện lưu data
        /// </summary>
        /// <param name="master">Thông tin master</param>
        /// <returns>true:Lưu thành công, ngược lại thất bại</returns>
        /// Create by: dvthang:07.01.2018
        protected virtual bool DoSave(BaseEntity entity, string[] detailConfig, ref List<BaseEntity> dataLogs)
        {
            bool success = true;

            try
            {
                if (entity.IsAuditLog)
                {
                    if (entity.MTEntityState == Enummation.MTEntityState.Edit)
                    {
                        entity.OldData = this.GetDataByID(entity);
                    }
                    dataLogs.Add(entity);
                }
                string query = string.Empty;
                DateTime now = SysDateTime.Instance.Now();
                string userName = MT.Library.SessionData.FullName + $" ({MT.Library.SessionData.UserName})";


                switch (entity.MTEntityState)
                {
                    case Enummation.MTEntityState.Add:
                        entity.SetValue(CommonKey.CreatedDate, now);
                        entity.SetValue(CommonKey.CreatedBy, userName);
                        entity.SetValue(CommonKey.ModifiedBy, userName);
                        entity.SetValue(CommonKey.ModifiedDate, now);
                        entity.SetValue(CommonKey.sDM_CanBo_Id_SoHuu, MT.Library.SessionData.UserId);
                        entity.SetValue(CommonKey.sDM_DonVi_Id_SoHuu, MT.Library.SessionData.OrganizationUnitId);
                        break;
                    case Enummation.MTEntityState.Edit:
                        entity.SetValue(CommonKey.ModifiedDate, now);
                        entity.SetValue(CommonKey.ModifiedBy, userName);
                        break;
                    case Enummation.MTEntityState.Delete:
                        break;
                }
                if (entity.UsedProc)
                {
                    if (entity.HasIdentity() && entity.MTEntityState == MTEntityState.Add)
                    {
                        if (string.IsNullOrEmpty(entity.ProcInsertName))
                        {
                            throw new Exception("ProcInsertName is Empty");
                        }
                        int identity = _unitOfWork.ExecuteScalar<int>(query, entity, commandType: CommandType.StoredProcedure);
                        if (identity > 0)
                        {
                            success = true;
                            entity.SetIdentity(identity);
                        }
                    }
                    else
                    {
                        string cmdText = string.Empty;
                        string cmdTextDefault = string.Empty;
                        switch (entity.MTEntityState)
                        {
                            case MTEntityState.Add:
                                cmdText = entity.ProcInsertName;
                                cmdTextDefault = $"Proc_{entity.TableName}_Insert";
                                break;
                            case MTEntityState.Edit:
                                cmdText = entity.ProcUpdateName;
                                cmdTextDefault = $"Proc_{entity.TableName}_Update";
                                break;
                            case MTEntityState.Delete:
                                cmdText = entity.ProcDeleteName;
                                cmdTextDefault = $"Proc_{entity.TableName}_Delete";
                                break;
                        }
                        if (string.IsNullOrEmpty(query) && string.IsNullOrEmpty(cmdTextDefault))
                        {
                            throw new Exception("Proc [Insert Or Update Or Delete] is Empty");
                        }
                        success = _unitOfWork.Execute(query, entity, commandType: CommandType.StoredProcedure);
                    }

                }
                else
                {
                    success = _unitOfWork.SaveEntity(entity, entity.TableName, entity.MTEntityState, entity.GetPrimaryKeyName());
                }
                if (success && entity.DetailConfig != null)
                {
                    foreach (string table in entity.DetailConfig)
                    {
                        IList data = MT.Library.Extensions.ExtensionMethod.GetValue<IList>(entity, table);
                        if (data != null)
                        {
                            foreach (BaseEntity oDetail in data)
                            {
                                string tableNameDetail = MT.Library.Extensions.ExtensionMethod.GetValue<string>(oDetail, CommonKey.TableName);
                                ForeignKeyAttribute fr = oDetail.GetForeignKey(entity.TableName);
                                if (fr != null)
                                {
                                    oDetail.SetValue(fr.ForeignKeyName, entity.GetIdentity());
                                    success = this.DoSave(oDetail, oDetail.DetailConfig, ref dataLogs);
                                    if (!success)
                                    {
                                        break;
                                    }
                                }
                                else
                                {
                                    oDetail.SetValue($"{tableNameDetail}Id", entity.GetIdentity());
                                    success = this.DoSave(oDetail, oDetail.DetailConfig, ref dataLogs);
                                    if (!success)
                                    {
                                        break;
                                    }
                                }

                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return success;
        }

        /// <summary>
        /// Trả về dữ liệu theo ID
        /// </summary>
        /// <param name="id">ID của bản ghi</param>
        /// Create by: dvthang:23.03.2019
        public virtual BaseEntity GetDataByID(BaseEntity entity,string columns="*")
        {
            if (string.IsNullOrEmpty(columns))
            {
                columns = "*";
            }
            if (Utility.CheckForSQLInjection(columns))
            {
                throw new Exception($"[columns] detect sql injection");
            }

            string query = string.Empty;
            string pkName = entity.GetPrimaryKeyName();
            string viewName = $"View_{entity.TableName}";
            query = $@"IF OBJECT_ID('{viewName}', 'V') IS NOT NULL
                                SELECT {columns} FROM {viewName} WHERE {pkName}=@{pkName}
                              ELSE
                                SELECT {columns} FROM {entity.TableName} WHERE {pkName}=@{pkName}";
            var result = _unitOfWork.QueryFirstOrDefault(query, entity.GetType(), new Dictionary<string, object> {
                {pkName,entity.GetIdentity() } });
            return result != null ? (BaseEntity)result : null;
        }

        /// <summary>
        /// Trả về dữ liệu theo ID
        /// </summary>
        /// <param name="id">ID của bản ghi</param>
        /// Create by: dvthang:23.03.2019
        public virtual T GetDataByID<T>(string tableName,object id,string columns="*") where T:class
        {
            if (string.IsNullOrEmpty(columns))
            {
                columns = "*";
            }
            else
            {
                var strCols = columns.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var item in strCols)
                {
                    if (MT.Library.Utility.CheckForSQLInjection(item))
                    {
                        throw new Exception($"Detect SQL Injection: {item}");
                    }
                }
                columns = string.Join(",", strCols);
            }
            if (Utility.CheckForSQLInjection(columns))
            {
                throw new Exception($"[columns] detect sql injection");
            }
            string viewName = $"View_{tableName}";
            string query = $@"IF OBJECT_ID('{viewName}', 'V') IS NOT NULL
                                SELECT {columns} FROM {viewName} WHERE Id=@Id
                              ELSE
                                SELECT {columns} FROM {tableName} WHERE Id=@Id";

            return _unitOfWork.QueryFirstOrDefault<T>(query, new Dictionary<string, object> {
                {"Id",id }
            }) ;
        }

        /// <summary>
        /// Kiểm tra xem đối tượng có bị trùng không 
        /// </summary>
        /// <param name="entity">Đối tượng cần check trùng</param>
        /// <returns>true: là trùng, ngược lại thì không</returns>
        protected virtual bool ValidateDuplicate(BaseEntity entity)
        {
            if (entity.MTEntityState == MTEntityState.Delete)
            {
                return false;
            }
            Dictionary<string, CodeAttribute> codes = entity.GetCodeAttributes();
            if (codes == null || codes.Count == 0 )
            {
                return false;
            }
            string primaryKeyName = entity.GetPrimaryKeyName();
            string _queryDuplicate = string.Empty;
            List<string> sWhere = new List<string>();
            Dictionary<string, object> param = new Dictionary<string, object>();
            foreach (var pair in codes)
            {
                sWhere.Add($"{pair.Key}=@{pair.Key}");
                param.Add(pair.Key, entity.GetValue(pair.Key));
            }
            switch (entity.MTEntityState)
            {
                case Enummation.MTEntityState.Add:
                    _queryDuplicate = $"IF EXISTS(SELECT TOP 1 1 FROM {entity.TableName} WHERE {string.Join(" AND ", sWhere)}) SELECT 1 ELSE SELECT 0;";
                    break;
                case Enummation.MTEntityState.Edit:
                    param.Add(primaryKeyName, entity.GetIdentity());
                    _queryDuplicate = $"IF EXISTS(SELECT TOP 1 1 FROM {entity.TableName} WHERE {primaryKeyName}<>@{primaryKeyName} AND {string.Join(" AND ", sWhere)}) SELECT 1 ELSE SELECT 0;";
                    break;
            }
            if (string.IsNullOrEmpty(_queryDuplicate))
            {
                return false;
            }
            return this._unitOfWork.ExecuteScalar<bool>(_queryDuplicate, param);
        }

        /// <summary>
        /// Load về danh sách data
        /// </summary>
        /// <param name="sort">Danh sách Cột sắp xếp</param>
        /// <param name="start">Lấy từ vị trí nào</param>
        /// <param name="limit">Lấy đến vị trí nào</param>
        /// <param name="where">Lọc  data theo điều kiện</param>
        /// <param name="columns">Danh sách các column lấy lên</param>
        /// <param name="totalOutput">Tổng số bản ghi trả về</param>
        /// <param name="dicSummary">Danh sách các cột cần sumary: { {"ColumnName","Value"}}</param>
        /// dvthang-08.04.2021
        public IList GetDataPaging(string viewNameOrTableName, string sort, int start, int limit, string where, 
           string columns, ref int totalCount, ref Dictionary<string, object> dicSummary)
        {
            string query = BuildQuery(viewNameOrTableName, sort, start, limit, where, columns, ref dicSummary);
            IList datas = null;
            Dictionary<string, object> resultSumary = new Dictionary<string, object>();
            _unitOfWork.ProcessIDataReader(query, (rd) =>
             {
                 datas = rd.ToListObject<TEntity>();
                 if (rd.NextResult())
                 {
                     resultSumary = rd.ToListDic().FirstOrDefault();
                 }
             });
            if (resultSumary != null)
            {
                foreach (var item in resultSumary)
                {
                    if (dicSummary.ContainsKey(item.Key))
                    {
                        dicSummary[item.Key] = item.Value;
                    }
                }
            }
            if(datas!=null && datas.Count > 0)
            {
                totalCount = (datas[0] as BaseEntity).TotalRecords;
            }
            return datas;
        }

        /// <summary>
        /// Tạo query lấy danh sách dữ liệu
        /// </summary>
        /// <param name="viewNameOrTableName">Tên view</param>
        /// <param name="sort">Danh sách cột sort</param>
        /// <param name="start">Vị trí bắt đầu</param>
        /// <param name="limit">Số lượng max</param>
        /// <param name="where">Điều kiện where</param>
        /// <param name="columns">Danh sách cột</param>
        private string BuildQuery(string viewNameOrTableName, string sort, int start, int limit, string where,
           string columns, ref Dictionary<string, object> dicSummary)
        {
            if (string.IsNullOrWhiteSpace(sort))
            {
                sort = $"{CommonKey.ModifiedDate} DESC";
            }
            if (string.IsNullOrWhiteSpace(columns))
            {
                columns = "*";
            }
            else
            {
                var strCols = columns.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var item in strCols)
                {
                    if (MT.Library.Utility.CheckForSQLInjection(item))
                    {
                        throw new Exception($"Detect SQL Injection: {item}");
                    }
                }
                columns = string.Join(",", strCols);
            }

            if (MT.Library.Utility.CheckForSQLInjection(columns))
            {
                throw new Exception($"Detect SQL Injection: {columns}");
            }

            if (MT.Library.Utility.CheckForSQLInjection(sort))
            {
                throw new Exception($"Detect SQL Injection: {sort}");
            }

            if (!string.IsNullOrWhiteSpace(where) && MT.Library.Utility.CheckForSQLInjection(where))
            {
                throw new Exception($"Detect SQL Injection: {where}");
            }

            if (start <= 0)
            {
                start = 1;
            }
            int skip = start;
            int take = skip + limit;
            string[] splitSorts = sort.Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            List<string> reserveSort = new List<string>();
            foreach (var item in splitSorts)
            {
                if (item.LastIndexOf("ASC", StringComparison.OrdinalIgnoreCase) > -1)
                {
                    reserveSort.Add(item.Substring(0, item.LastIndexOf("ASC", StringComparison.OrdinalIgnoreCase)) + " DESC");
                }
                else if (item.LastIndexOf("DESC", StringComparison.OrdinalIgnoreCase) > -1)
                {
                    reserveSort.Add(item.Substring(0, item.LastIndexOf("DESC", StringComparison.OrdinalIgnoreCase)) + " ASC");
                }
                else
                {
                    reserveSort.Add(item + " DESC");
                }
            }

            if (!string.IsNullOrWhiteSpace(where))
            {
                if (!where.Trim().StartsWith("WHERE", StringComparison.OrdinalIgnoreCase))
                {
                    where = $" WHERE 1=1 AND {where}";
                }
                else
                {
                    where = $" {where}";
                }
            }
            else
            {
                where = $" WHERE 1=1 ";
            }
            string query = string.Empty;

            string joinAccessLevel = string.Empty;

            var pInfoDonViSoHuu = typeof(TEntity).GetProperty(CommonKey.sDM_DonVi_Id_SoHuu, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
            if (pInfoDonViSoHuu != null)
            {
                joinAccessLevel = $@" LEFT JOIN dbo.EmployeeAccessLevel EL 
                                    ON T.{CommonKey.sDM_DonVi_Id_SoHuu}=EL.OrganizationUnitId 
                                        AND EL.EmployeeID='{MT.Library.SessionData.UserId}'";

            }

            var pInfoCanBoSoHuu = typeof(TEntity).GetProperty(CommonKey.sDM_CanBo_Id_SoHuu, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
            if (pInfoCanBoSoHuu != null)
            {

                where = $@"{where} AND (T.{CommonKey.sDM_CanBo_Id_SoHuu}='{MT.Library.SessionData.UserId}'
                           OR EL.OrganizationUnitId IS NOT NULL 
                           OR sDM_CanBo_Id_NguoiDuyet='{MT.Library.SessionData.UserId}')";

            }

            if (limit <= 0)
            {
                query = $@"WITH ctePageRecord  
                            AS  
                            (  
                                SELECT T.*,  
                                ROW_NUMBER() OVER(ORDER BY {sort}) AS RowNumber ,  
                                ROW_NUMBER() OVER(ORDER BY {string.Join(",", reserveSort)}) AS TotalRows  
                                FROM {viewNameOrTableName} as T {joinAccessLevel} {where}
                            )  
                            SELECT {columns}, totalRows + RowNumber -1 AS TotalRecords  
                            FROM ctePageRecord  
                            ORDER BY RowNumber";
            }
            else
            {
                query = $@"WITH ctePageRecord  
                            AS  
                            (  
                                SELECT T.*,  
                                ROW_NUMBER() OVER(ORDER BY {sort}) AS RowNumber ,  
                                ROW_NUMBER() OVER(ORDER BY {string.Join(",", reserveSort)}) AS TotalRows  
                                FROM {viewNameOrTableName} as T {joinAccessLevel} {where}
                            )  
                            SELECT {columns}, totalRows + RowNumber -1 AS TotalRecords  
                            FROM ctePageRecord  
                            WHERE RowNumber BETWEEN {skip} AND {take}  
                            ORDER BY RowNumber ";
            }

            List<string> columnsSumary = new List<string>();

            string summary = string.Empty;

            if (dicSummary != null)
            {
                foreach (var s in dicSummary)
                {
                    columnsSumary.Add($" SUM(ISNULL({s.Key},0)) AS {s.Key} ");
                }

                if (columnsSumary.Count > 0)
                {
                    summary = $" SELECT {string.Join(",", columnsSumary)} FROM {viewNameOrTableName} AS T {joinAccessLevel} {where}";
                }
            }

            if (!string.IsNullOrEmpty(summary))
            {
                query = $"{query};{summary}";
            }

            return query;
        }

        /// <summary>
        /// Trả về danh sách hàng Table
        /// </summary>
        /// <param name="viewNameOrTableName">Tên view</param>
        /// <param name="sort">Danh sách cột sort</param>
        /// <param name="start">Vị trí bắt đầu</param>
        /// <param name="limit">Số lượng max</param>
        /// <param name="where">Điều kiện where</param>
        /// <param name="columns">Danh sách cột</param>
        public DataSet GetAllData(string viewNameOrTableName, string sort, string where,
          string columns)
        {
            Dictionary<string, object> dicSummary = new Dictionary<string, object>();
            string query = BuildQuery(viewNameOrTableName, sort, 0, -1, where, columns,ref dicSummary);
            return _unitOfWork.QueryDataSet(query);
        }


        /// <summary>
        /// Lấy về danh sách chi tiết theo id master
        /// </summary>
        /// <typeparam name="viewNameOrTableName">Tên view hoặc tên table</typeparam>
        /// <typeparam name="foreignKeyName">Tên của cột khóa ngoại cần lấy</typeparam>
        /// <typeparam name="masterID">Id của master</typeparam>
        /// dvthang-08.04.2021
        public virtual IList GetDetailsByMasterID<T>(string viewNameOrTableName,string foreignKeyName,object masterID)
        {
            if (MT.Library.Utility.CheckForSQLInjection(viewNameOrTableName))
            {
                throw new Exception($"Detect SQL Injection: {viewNameOrTableName}");
            }

            if (MT.Library.Utility.CheckForSQLInjection(foreignKeyName))
            {
                throw new Exception($"Detect SQL Injection: {foreignKeyName}");
            }
            string query = $"SELECT * FROM {viewNameOrTableName} WHERE {foreignKeyName}=@{foreignKeyName}";

            BaseEntity baseEntity = Activator.CreateInstance<TEntity>();

            if (baseEntity.ExistsProperty("SortOrder"))
            {
                query += " ORDER BY SortOrder";
            }

            return _unitOfWork.Query<TEntity>(query);
        }

        /// <summary>
        /// Lấy về danh sách chi tiết theo id master
        /// </summary>
        /// <typeparam name="viewNameOrTableName">Tên view hoặc tên table</typeparam>
        /// <typeparam name="entityName">Tên đối tượng cần lấy về</typeparam>
        /// <typeparam name="masterID">Id của master</typeparam>
        /// dvthang-08.04.2021
       public virtual IList GetDetailsByMasterID2(string viewNameOrTableName, string entityName, object masterID)
        {
            if (MT.Library.Utility.CheckForSQLInjection(viewNameOrTableName))
            {
                throw new Exception($"Detect SQL Injection: {viewNameOrTableName}");
            }

            if (string.IsNullOrWhiteSpace(entityName))
            {
                throw new Exception($"entityName is empty");
            }

            Type t = Type.GetType(string.Format("MT.Data.BO.{0},MT.Data", entityName));

            BaseEntity baseEntity =(BaseEntity)Activator.CreateInstance(t);
            if (string.IsNullOrWhiteSpace(viewNameOrTableName))
            {
                viewNameOrTableName = baseEntity.TableName;
            }
            BaseEntity baseMasterEntity = Activator.CreateInstance<TEntity>();
            ForeignKeyAttribute foreignKeyAttribute= baseEntity.GetForeignKey(baseMasterEntity.TableName);
            if (foreignKeyAttribute == null)
            {
                return null;
            }
            string foreignKeyName=$"{foreignKeyAttribute.ForeignKeyName}" ;
            string query = $"SELECT * FROM {viewNameOrTableName} WHERE {foreignKeyName}=@{foreignKeyName}";

            if (baseEntity.ExistsProperty("SortOrder"))
            {
                query += " ORDER BY SortOrder";
            }
            return _unitOfWork.Query(query, t, new Dictionary<string,object>{ { foreignKeyName, masterID } });
        }

        /// <summary>
        /// Lấy về danh sách chi tiết theo id master
        /// </summary>
        /// <typeparam name="viewNameOrTableName">Tên view hoặc tên table</typeparam>
        /// <typeparam name="foreignKeyName">Tên của cột khóa ngoại cần lấy</typeparam>
        /// <typeparam name="masterID">Id của master</typeparam>
        /// dvthang-08.04.2021
        public DataTable GetDataTableDetailByMasterId(string viewNameOrTableName, string foreignKeyName, object masterID)
        {
            if (MT.Library.Utility.CheckForSQLInjection(viewNameOrTableName))
            {
                throw new Exception($"Detect SQL Injection: {viewNameOrTableName}");
            }

            if (MT.Library.Utility.CheckForSQLInjection(foreignKeyName))
            {
                throw new Exception($"Detect SQL Injection: {foreignKeyName}");
            }
            string query = $"SELECT * FROM {viewNameOrTableName} WHERE {foreignKeyName}=@{foreignKeyName}";
            return _unitOfWork.QueryDataTable(query);
        }

        /// <summary>
        /// Lấy về danh sách dữ liệu
        /// </summary>
        /// <param name="typeEntity">Kiểu dữ liệu</param>
        /// <param name="columns">Danh sách cột</param>
        /// <param name="where">Điều kiện where</param>
        /// <param name="orderBy">Orderby</param>
        public IList GetData(Type typeEntity, string columns = "*", string where = "", string orderBy = "",string viewName="")
        {
            if (string.IsNullOrWhiteSpace(columns))
            {
                columns = "*";
            }
            else
            {
                var strCols = columns.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                
                foreach (var item in strCols)
                {
                    if (MT.Library.Utility.CheckForSQLInjection(item))
                    {
                        throw new Exception($"Detect SQL Injection: {item}");
                    }
                }
                columns = string.Join(",", strCols);
            }
            
            BaseEntity baseEntity = (BaseEntity)Activator.CreateInstance(typeEntity);
            string query = $"SELECT {columns} FROM {baseEntity.TableName}";
            if (!string.IsNullOrWhiteSpace(viewName))
            {
                query = $"SELECT {columns} FROM {viewName} AS T";
            }
            
            if (!string.IsNullOrWhiteSpace(where))
            {
                if (MT.Library.Utility.CheckForSQLInjection(where))
                {
                    throw new Exception($"Detect SQL Injection: {where}");
                }
                if (where.Trim().StartsWith("WHERE"))
                {
                    where = $" {where}";
                }else if (where.Trim().StartsWith("AND"))
                {
                    where = $" WHERE 1=1 {where}";
                }
                else
                {
                    where = $" WHERE {where}";
                }
            }
            query +=" "+ where;

            if (!string.IsNullOrWhiteSpace(orderBy))
            {
                if (MT.Library.Utility.CheckForSQLInjection(orderBy))
                {
                    throw new Exception($"Detect SQL Injection: {orderBy}");
                }

                query += " ORDER BY " + orderBy;
            }
            return _unitOfWork.Query(query, typeEntity);
        }

        /// <summary>
        /// Hàm thực hiện sinh mã tự động theo thiết lập
        /// </summary>
        /// <param name="entity">Đối tượng cần sinh mã</param>
        /// <returns>Trả về mã tự tăng không trùng</returns>
        public void SetCodeNew(BaseEntity entity)
        {
            int retry = 5;
            while (retry > 0)
            {
                string code = string.Empty;
                string query = $"SELECT * FROM dbo.Sequence WHERE TableName=@TableName";
                try
                {
                    var sequence = _unitOfWork.QueryFirstOrDefault<Sequence>(query, new { TableName = entity.TableName });
                    if (sequence == null)
                    {
                        retry = 0;
                        return;
                    }
                    int newCurrentValue = sequence.CurrentValue + 1;
                    if (sequence.HasOrganizationCode)
                    {
                        if (!string.IsNullOrWhiteSpace(sequence.Prefix))
                        {
                        code = $"{sequence.Prefix}.{MT.Library.SessionData.OrganizationUnitCode}.{newCurrentValue.ToString().PadLeft(sequence.MaxLength, '0')}";
                        }
                        else{
                            code = $"{MT.Library.SessionData.OrganizationUnitCode}.{newCurrentValue.ToString().PadLeft(sequence.MaxLength, '0')}";
                        }
                    }
                    else
                    {
                        if (!string.IsNullOrWhiteSpace(sequence.Prefix))
                        {
                            code = $"{sequence.Prefix}.{newCurrentValue.ToString().PadLeft(sequence.MaxLength, '0')}";
                        }
                        else
                        {
                            code = $"{newCurrentValue.ToString().PadLeft(sequence.MaxLength, '0')}";
                        }
                    }
                   
                    entity.SetValue(sequence.ColumnName, code);

                    query = $"UPDATE dbo.Sequence SET CurrentValue={newCurrentValue} WHERE TableName=@TableName AND ColumnName=@ColumnName";
                    _unitOfWork.Execute(query, new { TableName = entity.TableName, ColumnName = sequence.ColumnName });

                    query = $"IF EXISTS (SELECT TOP 1 Id FROM {entity.TableName} WHERE {sequence.ColumnName}=@{sequence.ColumnName}) SELECT 1 ELSE SELECT 0;";

                    bool exists = _unitOfWork.ExecuteScalar<bool>(query, new Dictionary<string, object>
                        {
                            {sequence.ColumnName,code}
                        });

                    if (!exists)
                    {
                        retry = 0;
                        return;
                    }
                    else
                    {
                        System.Threading.Thread.Sleep(100);
                        retry--;
                    }
                }
                catch
                {
                    retry--;
                    System.Threading.Thread.Sleep(100);
                }
            }
            
        }

        /// <summary>
        /// Hàm thực hiện sinh mã tự động theo thiết lập
        /// </summary>
        /// <param name="entity">Đối tượng cần sinh mã</param>
        /// <returns>Trả về mã tự tăng không trùng</returns>
        public void SetSoChungTu(BaseEntity entity)
        {
            int retry = 5;
            while (retry > 0)
            {
                string query = $"SELECT TOP 1 * FROM dbo.SequenceVoucher WHERE sDM_DonVi_Id=@sDM_DonVi_Id AND sTenBang=@sTenBang AND bUsed=1 ORDER BY Id DESC ";
                try
                {
                    var sequence = _unitOfWork.QueryFirstOrDefault<SequenceVoucher>(query, new { sDM_DonVi_Id = MT.Library.SessionData.OrganizationUnitId, 
                        sTenBang=entity.TableName
                    });
                    if (sequence == null)
                    {
                        retry = 0;

                        query = $"SELECT TOP 1 * FROM dbo.SequenceVoucher WHERE sDM_DonVi_Id=@sDM_DonVi_Id AND sTenBang=@sTenBang AND bUsed=1 ORDER BY Id DESC ";
                        
                        sequence = new SequenceVoucher
                        {
                            sSo = "01"
                        };

                        var lastSequenceVoucherOfTable = _unitOfWork.QueryFirstOrDefault<SequenceVoucher>(query, new
                        {
                            sDM_DonVi_Id = MT.Library.SessionData.OrganizationUnitId,
                            sTenBang = entity.TableName
                        });

                        if (lastSequenceVoucherOfTable != null)
                        {
                            sequence.sSuffix = lastSequenceVoucherOfTable.sSuffix;
                        }

                    }
                    else
                    {
                        long newCurrentValue = long.Parse(sequence.sSo) + 1;
                        if (newCurrentValue < 10)
                        {
                            sequence.sSo = newCurrentValue.ToString().PadLeft(2, '0');
                        }
                        else
                        {
                            sequence.sSo = newCurrentValue.ToString();
                        }
                    }
                    
                    entity.SetValue("sSo", sequence.sSo);
                    entity.SetValue("sChu", sequence.sSuffix);
                    entity.SetValue("sMa", sequence.sSo+"/"+ sequence.sSuffix);

                    var now = SysDateTime.Instance.Now();
                    sequence.sTenBang = entity.TableName;
                    sequence.bUsed = false;
                    sequence.dCreatedDate = now;
                    sequence.sNguoiDung_Id = MT.Library.SessionData.UserId;
                    sequence.sDM_DonVi_Id = MT.Library.SessionData.OrganizationUnitId;
                    sequence.iNam = now.Year;

                    query = $@"IF EXISTS (SELECT TOP 1 Id FROM dbo.SequenceVoucher WHERE sSo=@sSo 
                                AND sDM_DonVi_Id=@sDM_DonVi_Id AND sTenBang=@sTenBang AND bUsed=1) SELECT 1 ELSE SELECT 0;";
                    bool exists = _unitOfWork.ExecuteScalar<bool>(query, new Dictionary<string, object>
                        {
                            {"sSo",sequence.sSo},
                            {"sDM_DonVi_Id",MT.Library.SessionData.OrganizationUnitId},
                            {"sTenBang",entity.TableName},
                            {"iNam",now.Year}
                        });

                    if (!exists)
                    {
                        _unitOfWork.SaveEntity(sequence, "SequenceVoucher", MTEntityState.Add);
                        entity.SequenceVoucherId = sequence.Id;
                         retry = 0;
                        return;
                    }
                    else
                    {
                        System.Threading.Thread.Sleep(300);
                        retry--;
                    }
                }
                catch
                {
                    retry--;
                    System.Threading.Thread.Sleep(300);
                }
            }

        }

        /// <summary>
        /// Thêm các căn cứ của phiếu
        /// </summary>
        public void AddNewCanCuPhieu(BaseEntity entity)
        {

            try
            {
                string sTenBangPhieu = entity.TableName;
                if (!_canCuPhieu.Contains(sTenBangPhieu))
                {
                    return;
                }
                int iLoaiPhieu = 0;
                string sTenBangCanCu = string.Empty;
                Guid? sCanCuId=null;
                switch (sTenBangPhieu)
                {
                    case "Phieu_NhapSanPhamMoi":
                        iLoaiPhieu = (int)MT.Data.iLoaiPhieu.NhapMoi;
                        sTenBangCanCu = "KH_NhapSanPhamMoi";
                        sCanCuId = entity.GetValue<Guid>("sKH_NhapSanPhamMoi_Id_CanCu");
                        break;
                    case "Phieu_NhapSanPham":
                        iLoaiPhieu = (int)MT.Data.iLoaiPhieu.NhapSP;
                        sTenBangCanCu = "KH_XuatSanPham";
                        sCanCuId = entity.GetValue<Guid>("sKH_XuatSanPham_Id_CanCu");
                        break;
                    case "Phieu_XuatSanPham":
                        iLoaiPhieu = (int)MT.Data.iLoaiPhieu.XuatSP;
                        sTenBangCanCu = "KH_XuatSanPham";
                        sCanCuId = entity.GetValue<Guid>("sKH_XuatSanPham_Id_CanCu");
                        break;
                    case "Phieu_NhapMuonTra":
                        iLoaiPhieu = entity.GetValue<int>("iTCNhap");
                        sTenBangCanCu = "KH_XuatMuonTra";
                        sCanCuId = entity.GetValue<Guid>("sPhieu_XuatMuonTra_Id_CanCu");
                        break;
                    case "Phieu_XuatMuonTra":
                        iLoaiPhieu = entity.GetValue<int>("iTCXuat");
                        sTenBangCanCu = "KH_XuatMuonTra";
                        if(iLoaiPhieu== (int)MT.Data.iLoaiPhieu.XuatTra)
                        {
                            sTenBangCanCu = "Phieu_NhapMuonTra";
                        }
                        sCanCuId = entity.GetValue<Guid>("sKH_XuatMuonTra_Id_CanCu");
                        break;
                    case "Phieu_XuatSuaChuaSanPham":
                        iLoaiPhieu = entity.GetValue<int>("iLoai");
                        sTenBangCanCu = "KH_SuaChuaSanPham";
                        if (iLoaiPhieu == (int)MT.Data.iLoaiPhieu.XuatSCTraVeSauSC)
                        {
                            sTenBangCanCu = "Phieu_NhapSuaChuaSanPham";
                        }
                        sCanCuId = entity.GetValue<Guid>("sKH_SuaChuaSanPham_Id_CanCu");
                        break;
                    case "Phieu_NhapSuaChuaSanPham":
                        iLoaiPhieu = (int)MT.Data.iLoaiPhieu.NhapVaoSC;
                        sTenBangCanCu = "Phieu_XuatSuaChuaSanPham";
                        sCanCuId = entity.GetValue<Guid>("sPhieu_XuatSuaChuaSanPham_Id_CanCu");
                        break;

                    case "Phieu_NhapCaiDatSanPham":
                        iLoaiPhieu = (int)MT.Data.iLoaiPhieu.NhapVaoCĐ;
                        sTenBangCanCu = "Phieu_XuatCaiDatSanPham";
                        sCanCuId = entity.GetValue<Guid>("sPhieu_XuatSanPham_Id_CanCu");

                        break;

                    case "Phieu_XuatCaiDatSanPham":
                        iLoaiPhieu = entity.GetValue<int>("iLoai");
                        sTenBangCanCu = "KH_CaiDatSanPham";
                        if (iLoaiPhieu == (int)MT.Data.iLoaiPhieu.XuatTraSauCĐ)
                        {
                            sTenBangCanCu = "Phieu_NhapCaiDatSanPham";
                        }
                        sCanCuId = entity.GetValue<Guid>("sKH_CaiDatSanPham_Id_CanCu");
                        break;
                    case "Phieu_XuatBaoHanhSanPham":
                        iLoaiPhieu = entity.GetValue<int>("iLoai");
                        sTenBangCanCu = "KH_BaoHanhSanPham";
                        if (iLoaiPhieu == (int)MT.Data.iLoaiPhieu.XuatTraSauBH)
                        {
                            sTenBangCanCu = "Phieu_NhapBaoHanhSanPham";
                        }
                        sCanCuId = entity.GetValue<Guid>("sKH_BaoHanhSanPham_Id_CanCu");
                        break;
                    case "Phieu_NhapBaoHanhSanPham":
                        iLoaiPhieu = (int)MT.Data.iLoaiPhieu.NhapBH;
                        sTenBangCanCu = "Phieu_XuatBaoHanhSanPham";
                        sCanCuId = entity.GetValue<Guid>("sPhieu_XuatBaoHanhSanPham_Id_CanCu");

                        break;
                    case "Phieu_NhapTHTH":
                        iLoaiPhieu = (int)MT.Data.iLoaiPhieu.NhapThuHoi;
                        sTenBangCanCu = "Phieu_XuatTHTH";
                        sCanCuId = entity.GetValue<Guid>("sPhieu_XuatTHTH_Id_CanCu");
                        break;
                    case "Phieu_XuatTHTH":
                        iLoaiPhieu = entity.GetValue<int>("iTCXuat");
                        sTenBangCanCu = "KH_XuatTHTH";
                        if (iLoaiPhieu == (int)MT.Data.iTCXuatTH.XuatHuy)
                        {
                            sTenBangCanCu = "Phieu_NhapTHTH";
                        }
                        sCanCuId = entity.GetValue<Guid>("sKH_XuatTHTH_Id_CanCu");
                        break;
                    case "KH_XuatSanPham":
                        sTenBangCanCu = "KH_XuatBaoDam";
                        sCanCuId = entity.GetValue<Guid>("sKH_BaoDam_Id");
                        break;
                }
                if (!sCanCuId.HasValue)
                {
                    return;
                }
                Guid sPhieu_Id = Guid.Parse(entity.GetIdentity().ToString());
               
                string query = $"DELETE FROM dbo.CanCuPhieu WHERE sPhieu_Id='{sPhieu_Id}'";

                _unitOfWork.Execute(query);

                var cancuPhieu = new CanCuPhieu
                {
                    Id = Guid.NewGuid(),
                    sPhieu_Id = sPhieu_Id,
                    sMaPhieu= entity.GetValue<string>("sMa"),
                    sTenBangPhieu = sTenBangPhieu,
                    sTenBangCanCu = sTenBangCanCu,
                    iLoaiPhieu=iLoaiPhieu,
                    sCanCuId = sCanCuId.Value,
                    dCreatedDate = SysDateTime.Instance.Now()
                };
                _unitOfWork.SaveEntity(cancuPhieu, "CanCuPhieu", MTEntityState.Add);
            }
            catch (Exception ex)
            {
                MT.Library.Log.LogHelper.AddError(ex);
            }
        }

        /// <summary>
        /// Xóa các căn cứ của phiếu
        /// </summary>
        public void DeleteCanCuPhieu(BaseEntity entity)
        {
            try
            {
                string sTenBangPhieu = entity.TableName;
                if (!_canCuPhieu.Contains(sTenBangPhieu))
                {
                    return;
                }
                Guid sPhieu_Id = Guid.Parse(entity.GetIdentity().ToString());

                string query = $"DELETE FROM dbo.CanCuPhieu WHERE sPhieu_Id='{sPhieu_Id}'";

                _unitOfWork.Execute(query);
            }
            catch (Exception ex)
            {
                MT.Library.Log.LogHelper.AddError(ex);
            }
        }

        /// <summary>
        /// Kiểm tra trạng thái của phiếu/kế hoạch
        /// </summary>
        /// <returns>true: Đã duyệt, ngược lại chưa</returns>
        public bool CheckHasApproved(object id, string tableName)
        {
            string[] tenbangCanKiemTra = { "KH_BaoHanhSanPham", "KH_CaiDatSanPham", "KH_NhapSanPhamMoi",
            "KH_SuaChuaSanPham","KH_XuatBaoDam","KH_XuatMuonTra","KH_XuatSanPham","KH_XuatTHTH","Phieu_NhapBaoHanhSanPham",
            "Phieu_NhapCaiDatSanPham","Phieu_NhapMuonTra","Phieu_NhapSanPham","Phieu_NhapSanPhamMoi",
            "Phieu_NhapSuaChuaSanPham","Phieu_NhapTHTH","Phieu_XuatBaoHanhSanPham","Phieu_XuatCaiDatSanPham",
            "Phieu_XuatMuonTra","Phieu_XuatSanPham","Phieu_XuatSuaChuaSanPham","Phieu_XuatTHTH"};

            if (!tenbangCanKiemTra.Contains(tableName))
            {
                return false;
            }

            string query = $"IF(EXISTS(SELECT Id FROM {tableName} WHERE Id='{id}' AND iTrangThaiDuyet=1)) SELECT 1 ELSE SELECT 0";
            return this._unitOfWork.ExecuteScalar<int>(query)>0;
        }
        #endregion
    }
}
