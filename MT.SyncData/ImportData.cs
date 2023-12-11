using MT.Data.BO;
using MT.Data.Rep;
using MT.Library;
using MT.Library.UW;
using MT.SyncData.BO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MT.SyncData
{
    public class ImportData: CoreData
    {
        private string _connectionString;
        private static ImportData _instance;
        public static ImportData Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ImportData();
                }

                return _instance;
            }
        }

        /// <summary>
        /// Thực hiện import dữ liệu đơn vị gửi
        /// </summary>
        /// <param name="msgError">Nội dung lỗi trong quá trình import</param>
        public bool Execute(string connectionString, Guid organizationUnitId, ref string msgError)
        {
            try
            {
                _connectionString = connectionString;
                using (IUnitOfWork unitOfWork = new UnitOfWork(_connectionString))
                {
                    string query = $@"SELECT OptionValue FROM DBOption WHERE OptionID='{MT.Library.CommonKey.PathImport}'";
                    string pathImport = unitOfWork.QueryFirstOrDefault<string>(query);

                    if (string.IsNullOrWhiteSpace(pathImport))
                    {
                        msgError = "PathExportData Is empty";

                        return false;
                    }

                    MT.Library.Log.LogHelper.Debug($"Start Check exist folder: {pathImport}");
                    if (!Directory.Exists(pathImport))
                    {
                        msgError = $"Path: {pathImport} not exists";

                        return false;
                    }

                    //GetAllFolder

                    string pathFolderTemp = System.IO.Path.Combine(pathImport,"~Temp");

                    MT.Library.Log.LogHelper.Debug($"Start Create folder temp: {pathFolderTemp}");

                    if (!System.IO.Directory.Exists(pathFolderTemp))
                    {
                        System.IO.Directory.CreateDirectory(pathFolderTemp);
                    }

                    string[] subdirectoryEntries = Directory.GetDirectories(pathImport);

                    MT.Library.Log.LogHelper.Debug($"Read folder import: Files: {subdirectoryEntries.Length}");

                    foreach (string subdirectory in subdirectoryEntries)
                    {
                        int lastIndexFolder = subdirectory.LastIndexOf(@"\");
                        string folderExcute= subdirectory.Substring(lastIndexFolder+1);

                        if (folderExcute.Equals("~Temp", StringComparison.OrdinalIgnoreCase))
                        {
                            continue;
                        }

                        //Kiểm tra folder đã đọc chưa
                        query = "IF EXISTS(SELECT 1 FROM HistoryImport WHERE FolderName=@FolderName) SELECT 1 ELSE SELECT 0";

                        bool exists=  unitOfWork.QueryFirstOrDefault<bool>(query,new { FolderName = folderExcute });

                        MT.Library.Log.LogHelper.Debug($"Import {folderExcute}:{exists}");

                        //Folder chưa đọc thành công bao giờ
                        if (!exists)
                        {
                            if(_isDonViLaBanCoYeu== null)
                            {
                                _isDonViLaBanCoYeu = KiemTraDonViLaBanCoYeu(unitOfWork, organizationUnitId);
                            }

                            //1. Đọc file DeleteObject.json trước
                            string fileDeleteOject = System.IO.Path.Combine(pathImport, folderExcute, "DeleteObject.json");

                            if (System.IO.File.Exists(fileDeleteOject))
                            {
                                MT.Library.Log.LogHelper.Debug($"DeleteObject.json");

                                using (StreamReader r = new StreamReader(fileDeleteOject))
                                {
                                    string json = r.ReadToEnd();
                                    Dictionary<string,MetaDataExport> deleteObjects = MT.Library.Utility.DeserializeObject<Dictionary<string, MetaDataExport>>(json);
                                    if (deleteObjects?.Count > 0)
                                    {
                                        MT.Library.Log.LogHelper.Debug($"Total DeleteObject: {deleteObjects.Count}");
                                        foreach (var item in deleteObjects)
                                        {
                                            
                                            var guids = MT.Library.Utility.DeserializeObject<List<Guid>>(MT.Library.Utility.SerializeObject(item.Value.Data));

                                            //Nếu đơn vị import là ban cơ yếu
                                            if (_isDonViLaBanCoYeu.HasValue && _isDonViLaBanCoYeu.Value)
                                            {
                                                //Kiểm tra nếu là phiếu xuất
                                                if (_dicRelatedTable.ContainsKey(item.Key))
                                                {
                                                    //Đơn vị nhận là các hệ thì không cho xóa
                                                    query = $@"SELECT DISTINCT T.Id FROM {item.Key} AS T 
                                                                JOIN ConfigExportData  C ON T.sDM_DonVi_Id_Nhap=C.sDM_DonVi_Id_DonViNhap AND iType=0
                                                                WHERE T.Id IN({string.Join(",", guids.Select(m => $"'{m}'"))})";
                                                    var ids = unitOfWork.Query<Guid>(query);
                                                    if (ids?.Count > 0)
                                                    {
                                                        //Các phiếu xuất này không được xóa
                                                        guids.RemoveAll(g => ids.IndexOf(g) > -1);
                                                    }
                                                }
                                            }

                                            if (guids?.Count > 0)
                                            {
                                                query = $"DELETE FROM {item.Key} WHERE Id IN({string.Join(",", guids.Select(m => $"'{m}'"))})";
                                                unitOfWork.Execute(query);
                                                SaveHistoryImportWhenDeleteObject(item.Value.sDM_DonVi_Id_Xuat, folderExcute, item.Key, guids);
                                            }
                                        }
                                    }
                                }
                            }

                            //2.0 Tiền xử lý danh mục,Kiểm tra xem db có thiếu danh mục vào không, nếu thiếu thì insert mới vào

                            MT.Library.Log.LogHelper.Debug($"PrepareDictionary");
                            PrepareDictionary(unitOfWork,organizationUnitId, pathImport, folderExcute);

                            //2.1 Cập nhật ChangedData
                            string fileChangedData = System.IO.Path.Combine(pathImport, folderExcute, "ChangedData.json");
                            if (System.IO.File.Exists(fileChangedData))
                            {
                                using (StreamReader r = new StreamReader(fileChangedData))
                                {
                                    string json = r.ReadToEnd();
                                    Dictionary<string, List<TransferData>> dicChangedDatas = MT.Library.Utility.DeserializeObject<Dictionary<string, List<TransferData>>>(json);

                                    if (dicChangedDatas?.Count > 0)
                                    {
                                        MT.Library.Log.LogHelper.Debug($"foreach dicChangedDatas. Total table={dicChangedDatas.Count}");

                                        foreach (var item in dicChangedDatas)
                                        {
                                            foreach (var changedData in item.Value)
                                            {
                                                Save(unitOfWork, changedData, item.Key,folderExcute);

                                                if (changedData.RelatedTableDatas != null)
                                                {
                                                    foreach (var pair in changedData.RelatedTableDatas)
                                                    {
                                                        foreach (var it in pair.Value)
                                                        {
                                                            Save(unitOfWork, it, pair.Key, folderExcute);
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                       
                        MT.Library.Log.LogHelper.Debug($"Import finish folder: {folderExcute}");


                        string desDirName = System.IO.Path.Combine(pathFolderTemp, folderExcute);
                        MoveFolder(subdirectory, desDirName);
                    }

                }
            }
            catch (Exception ex)
            {
                msgError = ex.Message + "|" + ex.StackTrace;

                return false;
            }

            return true;
        }

        /// <summary>
        /// Thực hiện import data
        /// </summary>
        private void Save(IUnitOfWork unitOfWork, TransferData changedData, string tableName,string folderExcute)
        {
            Type type = Type.GetType($"MT.Data.BO.{tableName},MT.Data");
            if (type == null)
            {
                return;
            }
            BaseEntity baseEntityMaster = (BaseEntity)MT.Library.Utility.DeserializeObject(MT.Library.Utility.SerializeObject(changedData.Master), type);

            InsertOrUpdateChangedData(unitOfWork, changedData.sDM_DonVi_Id_Xuat, folderExcute, baseEntityMaster);

            if (changedData.Details?.Count > 0)
            {
                foreach (var d in changedData.Details)
                {
                    Type typeDetail = Type.GetType($"MT.Data.BO.{tableName}_CT,MT.Data");
                    if (typeDetail == null)
                    {
                        break;
                    }
                    BaseEntity baseEntityDetail = (BaseEntity)MT.Library.Utility.DeserializeObject(MT.Library.Utility.SerializeObject(d), typeDetail);

                    InsertOrUpdateChangedData(unitOfWork, changedData.sDM_DonVi_Id_Xuat, folderExcute, baseEntityDetail);
                }
            }

            if (changedData.DicPK_Details?.Count > 0)
            {
                foreach (var pair in changedData.DicPK_Details)
                {
                    if (pair.Value?.Count > 0)
                    {
                        foreach (var pk in pair.Value)
                        {
                            Type typeDetailPK = Type.GetType($"MT.Data.BO.{pair.Key},MT.Data");
                            if (typeDetailPK == null)
                            {
                                break;
                            }
                            BaseEntity baseEntity = (BaseEntity)MT.Library.Utility.DeserializeObject(MT.Library.Utility.SerializeObject(pk), typeDetailPK);
                            InsertOrUpdateChangedData(unitOfWork, changedData.sDM_DonVi_Id_Xuat, folderExcute, baseEntity);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Di chuyển folder đến chỗ khác
        /// </summary>
        /// <param name="sourceDirName">Folder nguồn</param>
        /// <param name="desDirName">Folder đích</param>
        private void MoveFolder(string sourceDirName,string desDirName)
        {
            try
            {
                MT.Library.Log.LogHelper.Debug($"Move folder {sourceDirName} to {desDirName} success");
                if (!System.IO.Directory.Exists(desDirName))
                {
                    System.IO.Directory.Move(sourceDirName, desDirName);
                }
               
            }
            catch (Exception ex)
            {
                MT.Library.Log.LogHelper.Error(ex, ex.Message);
            }
        }

        /// <summary>
        /// Compare danh mục của 2 hệ thống để nó luôn giống nhau
        /// </summary>
        private void PrepareDictionary(IUnitOfWork unitOfWork,Guid organizationUnitId, string pathImport, string folderExcute)
        {
            try
            {
                string query = @"select TableName,IsDictionary,SortOrder from SortOrderExportData as s order by S.SortOrder;";
                List<SortOrderExportData> sortOrderExportDatas = unitOfWork.Query<SortOrderExportData>(query);

                if (sortOrderExportDatas?.Count > 0)
                {
                    foreach (var item in sortOrderExportDatas.Where(m => m.IsDictionary == true).OrderBy(m => m.SortOrder))
                    {
                        string folderDictionary = System.IO.Path.Combine(pathImport, folderExcute, "Dictionary", $"{item.TableName}.json");

                        if (!System.IO.File.Exists(folderDictionary))
                        {
                            continue;
                        }

                        using (StreamReader r = new StreamReader(folderDictionary))
                        {
                            string json = r.ReadToEnd();
                            Dictionary<string, MetaDataExport> dicData = MT.Library.Utility.DeserializeObject<Dictionary<string, MetaDataExport>>(json);

                            if (dicData?.Count > 0)
                            {
                                foreach (var pair in dicData)
                                {
                                    query = $@"IF EXISTS(SELECT 1 FROM {item.TableName} WHERE Id=@Id) SELECT 1 ELSE SELECT 0";
                                    bool exists = unitOfWork.QueryFirstOrDefault<bool>(query, new { Id = Guid.Parse(pair.Key) });
                                    //Danh mục không tồn tại, thêm mới danh mục luôn
                                    if (!exists)
                                    {
                                        Type typeDetailPK = Type.GetType($"MT.Data.BO.{item.TableName},MT.Data");
                                        if (typeDetailPK == null)
                                        {
                                            break;
                                        }
                                        BaseEntity baseEntity = (BaseEntity)MT.Library.Utility.DeserializeObject(MT.Library.Utility.SerializeObject(pair.Value.Data), typeDetailPK);

                                        unitOfWork.SaveEntity(baseEntity, item.TableName, Enummation.MTEntityState.Add);
                                        SaveHistoryImportWhenChangedData(pair.Value.sDM_DonVi_Id_Xuat, folderExcute, item.TableName, Guid.Parse(pair.Key), 1);
                                    }
                                }
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MT.Library.Log.LogHelper.Error(ex, ex.Message);
            }
        }

        /// <summary>
        /// Thực hiện cập nhật bản ghi
        /// </summary>
        /// <param name="organizationUnitId">Đơn vị export</param>
        /// <param name="tableName">Tên bảng</param>
        /// <param name="entity">Đối tượng cập nhật</param>
        private void InsertOrUpdateChangedData(IUnitOfWork unitOfWork,Guid organizationUnitId,string folderExcute, BaseEntity entity)
        {
            int retry = 5;
            while (retry > 0)
            {
                try
                {

                    string query = $@"IF EXISTS(SELECT 1 FROM {entity.TableName} WHERE Id=@Id) SELECT 1 ELSE SELECT 0";
                    Guid id = Guid.Parse(entity.GetIdentity().ToString());
                    bool exists = unitOfWork.QueryFirstOrDefault<bool>(query, new { Id = id });
                    bool success = unitOfWork.SaveEntity(entity, entity.TableName, exists ? Enummation.MTEntityState.Edit : Enummation.MTEntityState.Add);

                    if (success)
                    {
                        SaveHistoryImportWhenChangedData(organizationUnitId, folderExcute, entity.TableName, id, exists ? 2 : 1);
                    }
                    retry = 0;
                }
                catch (Exception ex)
                {
                    MT.Library.Log.LogHelper.Error(ex, ex.Message);
                    retry--;
                    System.Threading.Thread.Sleep(10000);
                }
            }
           
        }

        /// <summary>
        /// Lưu lại lịch sử quá trình import data, dùng khi xóa
        /// </summary>
        private void SaveHistoryImportWhenDeleteObject(Guid organizationUnitId, string folderName, string tableName,List<Guid> guids)
        {
            Task.Run(() =>
            {
                try
                {
                    using (IUnitOfWork unitOfWork = new UnitOfWork(_connectionString))
                    {
                        foreach (var item in guids)
                        {
                            unitOfWork.SaveEntity(new Dictionary<string, object>
                            {
                                {"Id",Guid.NewGuid() },
                                {"FolderName",folderName },
                                {"ObjectId",item },
                                {"TableName",tableName},
                                {"Action",3 },
                                {"OrganizationUnitId",organizationUnitId },
                                {"Description",$"Xóa bản ghi"},
                                {"CreatedDate",DateTime.Now }
                            }, "HistoryImport", Library.Enummation.MTEntityState.Add); 
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
        /// Lưu lại lịch sử quá trình import data
        /// </summary>
        private void SaveHistoryImportWhenChangedData(Guid organizationUnitId, string folderName, string tableName, Guid objectId,int action)
        {
            Task.Run(() =>
            {
                try
                {
                    using (IUnitOfWork unitOfWork = new UnitOfWork(_connectionString))
                    {
                        string description=string.Empty;
                        switch (action)
                        {
                            case 1:
                                description = "Thêm mới";
                                break;
                            case 2:
                                description = "Cập nhật";
                                break;
                            case 3:
                                description = "Xóa";
                                break;
                        }
                        unitOfWork.SaveEntity(new Dictionary<string, object>
                            {
                                {"Id",Guid.NewGuid() },
                                {"FolderName",folderName },
                                {"ObjectId",objectId },
                                {"TableName",tableName},
                                {"Action",action },
                                {"OrganizationUnitId",organizationUnitId },
                                {"Description",description},
                                {"CreatedDate",DateTime.Now }
                            }, "HistoryImport", Library.Enummation.MTEntityState.Add);
                    }
                }
                catch (Exception ex)
                {
                    MT.Library.Log.LogHelper.Error(ex, ex.Message);
                }
            });
            
        }

        /// <summary>
        /// Thực hiện valid data
        /// </summary>
        /// <returns></returns>
        private bool Valid(ref string msgError)
        {
            return true;
        }

    }
}
