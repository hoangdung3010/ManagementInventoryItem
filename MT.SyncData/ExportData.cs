using MT.Data.BO;
using MT.Library;
using MT.Library.Extensions;
using MT.Library.UW;
using MT.SyncData.BO;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MT.SyncData
{
    public class ExportData:CoreData
    {
        private string _connectionString;

        private static ExportData _instance;
        public static ExportData Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ExportData();
                }

                return _instance;
            }
        }


        private static List<ConfigExportData> configExportDatas = null;

        private const string MSC_Permission = "Permission";

        /// <summary>
        /// Thực hiện export dữ liệu của đơn vị
        /// </summary>
        /// <param name="organizationUnitId">Đơn vị xuất(Chính nó và con cháu, chắt chút chít của nó)</param>
        /// <param name="msgError">Thông báo lỗi</param>
        /// <returns>true là thành công, ngược lại thất bại</returns>
        public bool Execute(string connnectionString, Guid organizationUnitId,ref  string msgError)
        {
            try
            {
                _connectionString = connnectionString;
                //1. Export các danh mục phát sinh trên các phiếu
                //2. KH
                //3. Phiếu xuất. Lưu ý lấy đơn vị xuất
                //4. Phiếu nhập. Lưu ý lấy theo đơn vị nhập
                //5. Các dữ liệu bị xóa tương ứng ở các bảng

                int permission = MT.Library.Utility.GetAppSettings<int>(MSC_Permission,0);

                string query = @"select TableName,IsDictionary,SortOrder,Permission from SortOrderExportData as s order by S.SortOrder;";
                using (IUnitOfWork unitOfWork = new UnitOfWork(_connectionString))
                {
                    List<SortOrderExportData> sortOrderExportDatas = unitOfWork.Query<SortOrderExportData>(query);

                    if (sortOrderExportDatas == null || sortOrderExportDatas.Count == 0)
                    {
                        msgError = "SortOrderExportData IS NULL";

                        return false;
                    }

                    query = $@"SELECT OptionValue FROM DBOption WHERE OptionID='{MT.Library.CommonKey.PathExportData}'";
                    string pathExportData = unitOfWork.QueryFirstOrDefault<string>(query);

                    if (string.IsNullOrWhiteSpace(pathExportData))
                    {
                        msgError = "PathExportData Is empty";

                        return false;
                    }

                    if (!System.IO.Directory.Exists(pathExportData))
                    {
                        msgError = $"Path: {pathExportData} not exists";

                        return false;
                    }

                    MT.Library.Log.LogHelper.Debug($"Start IsDonViLaBanCoYeu {_isDonViLaBanCoYeu},Permission: {permission}");

                    if (_isDonViLaBanCoYeu == null)
                    {
                        _isDonViLaBanCoYeu = KiemTraDonViLaBanCoYeu(unitOfWork, organizationUnitId);
                    }
                    //Tạo thư mục export ứng với từng hệ
                    CreateFolderExport(unitOfWork,pathExportData, organizationUnitId);

                    MT.Library.Log.LogHelper.Debug($"CreateFolderExport Success");

                    //1.Đọc các bản ghi bị xóa
                    string folderExportByTime = DateTime.Now.ToString("ddMMyyyyhhmmss") + organizationUnitId.ToString("N");

                    var dictionaryDeleteObject = new Dictionary<string, MetaDataExport>();
                    foreach (var item in sortOrderExportDatas)
                    {
                        query = $"SELECT ObjectID FROM DeleteObject WHERE TableName='{item.TableName}' AND IsExportData=0 ORDER BY CreatedDate";

                        var guids = unitOfWork.Query<Guid>(query);

                        if (guids?.Count > 0)
                        {
                            query = $"UPDATE DeleteObject SET IsExportData=1 WHERE ObjectID IN({string.Join(",", guids.Select(m=>$"'{m}'"))})";
                            unitOfWork.Execute(query);

                            if (!dictionaryDeleteObject.ContainsKey(item.TableName))
                            {
                                dictionaryDeleteObject.Add(item.TableName, new MetaDataExport { Data = guids, sDM_DonVi_Id_Xuat = organizationUnitId } );
                            }
                        }
                    }

                    MT.Library.Log.LogHelper.Debug($"DictionaryDeleteObject: {dictionaryDeleteObject.Count}");

                    if (dictionaryDeleteObject.Count > 0)
                    {
                        foreach (var cf in configExportDatas.FindAll(m => m.sDM_DonVi_Id_DonViXuat == organizationUnitId))
                        {
                            string pathFolderByOrg = System.IO.Path.Combine(pathExportData, cf.sFolderName, folderExportByTime);

                            if (!System.IO.Directory.Exists(pathFolderByOrg))
                            {
                                System.IO.Directory.CreateDirectory(pathFolderByOrg);
                            }
                            string pathFileDeleteObject = System.IO.Path.Combine(pathFolderByOrg, "DeleteObject.json");

                            //lưu danh sách các bản ghi bị xóa
                            using (System.IO.StreamWriter file = new System.IO.StreamWriter(pathFileDeleteObject, true))
                            {
                                file.WriteLine(MT.Library.Utility.SerializeObject(dictionaryDeleteObject));
                            }
                        }
                    }
                    //2. Đọc các dữ liệu thay đổi từ bảng ChangedData
                    var dicChangedDataByOrg = new Dictionary<string, Dictionary<string, List<TransferData>>>();

                    foreach (var item in sortOrderExportDatas)
                    {
                        //Kiểm tra nếu không có quyền export thì bỏ qua
                        if ((item.Permission & permission)!=permission)
                        {
                            continue;
                        }
                        
                        query = $"SELECT ObjectID FROM ChangedData WHERE TableName='{item.TableName}' ORDER BY CreatedDate";

                        var guids = unitOfWork.Query<Guid>(query);

                        if (guids==null || guids.Count==0)
                        {
                            continue;
                        }

                        MT.Library.Log.LogHelper.Debug($"Read ChangedData: {item.TableName},guids:{guids.Count}");

                        List<TransferData> transferDatas = new List<TransferData>();
                        foreach (var g in guids)
                        {
                            var transferData = CreateTransferData(unitOfWork, item.TableName, g, item.IsDictionary,organizationUnitId);
                            if (transferData != null)
                            {
                                transferData.RelatedTableDatas = new Dictionary<string, List<TransferData>>();
                                //Lấy ra căn cứ của phiếu
                                if (_dicRelatedTable.ContainsKey(item.TableName))
                                {
                                    GetRelatedData(unitOfWork, transferData,transferData.Id, organizationUnitId);
                                }
                                transferDatas.Add(transferData);
                            }
                            else
                            {
                                MT.Library.Log.LogHelper.Debug($"Get TransferData:{item.TableName} IS NULL");
                            }
                        }
                        if (transferDatas.Count > 0)
                        {
                            MT.Library.Log.LogHelper.Debug($"TransferDatas:{transferDatas.Count},configExportDatas:{configExportDatas.Count}");
                            if (_isDonViLaBanCoYeu.HasValue && _isDonViLaBanCoYeu.Value)
                            {
                                //Nếu là ban cơ yếu thì chỉ quan tâm đến các phiếu xuất cho các hệ
                                foreach (var cfExportData in configExportDatas.FindAll(m => m.sDM_DonVi_Id_DonViXuat == organizationUnitId))
                                {
                                    var transferDatasByOrg = transferDatas.FindAll(m => m.sDM_DonVi_Id_Nhap == cfExportData.sDM_DonVi_Id_DonViNhap);
                                    if (transferDatasByOrg?.Count > 0)
                                    {
                                        var dicChangedData = new Dictionary<string, List<TransferData>>();
                                        if (!dicChangedDataByOrg.TryGetValue(cfExportData.sFolderName, out dicChangedData))
                                        {
                                            dicChangedData = new Dictionary<string, List<TransferData>>();
                                            dicChangedDataByOrg.Add(cfExportData.sFolderName, dicChangedData);
                                        }
                                        dicChangedData.Add(item.TableName, transferDatasByOrg);
                                    }
                                }
                            }
                            else
                            {
                                var config = configExportDatas.FirstOrDefault(m => m.iType == 1);

                                MT.Library.Log.LogHelper.Debug($"Hệ cơ yếu thì export hết: {config.sFolderName}");

                                //Hệ cơ yếu thì export hết
                                var dicChangedData = new Dictionary<string, List<TransferData>>();
                                if (!dicChangedDataByOrg.TryGetValue(config.sFolderName, out dicChangedData))
                                {
                                    dicChangedData = new Dictionary<string, List<TransferData>>();
                                    dicChangedDataByOrg.Add(config.sFolderName, dicChangedData);
                                }
                                dicChangedData.Add(item.TableName, transferDatas);
                            }
                            
                        }
                        //Xóa bản ghi thay đổi ggi
                        query = $"DELETE FROM ChangedData WHERE ObjectID IN({string.Join(",", guids.Select(m => $"'{m}'"))})";
                        unitOfWork.Execute(query);

                    }

                    MT.Library.Log.LogHelper.Debug($"DicChangedDataByOrg: {dicChangedDataByOrg.Count}");

                    if (dicChangedDataByOrg.Count > 0)
                    {
                        foreach (var item in dicChangedDataByOrg)
                        {
                            string pathFolderByOrg = System.IO.Path.Combine(pathExportData, item.Key, folderExportByTime);

                            if(item.Value==null || item.Value.Count == 0)
                            {
                                continue;
                            }
                            if (!System.IO.Directory.Exists(pathFolderByOrg))
                            {
                                System.IO.Directory.CreateDirectory(pathFolderByOrg);
                            }
                            string pathFileSaveChangeData= System.IO.Path.Combine(pathFolderByOrg, "ChangedData.json");
                            //Lưu danh sách các bản ghi thay đổi
                            using (System.IO.StreamWriter file = new System.IO.StreamWriter(pathFileSaveChangeData, true))
                            {
                                file.WriteLine(MT.Library.Utility.SerializeObject(item.Value));
                            }
                        }
                        MT.Library.Log.LogHelper.Debug($"Start Export Dictionary");
                        //3. Lấy xuất toàn bộ danh mục của DB ra
                        foreach (var item in sortOrderExportDatas.Where(m => m.IsDictionary == true).OrderBy(m => m.SortOrder))
                        {
                            query = $"SELECT * FROM {item.TableName}";

                            Type type = Type.GetType($"MT.Data.BO.{item.TableName},MT.Data");

                            if (type == null)
                            {
                                msgError = $@"Type.GetType(MT.Data.BO.{item.TableName} NULL";
                                return false;
                            }

                            var datas = unitOfWork.Query(query, type);

                            var dicData = new Dictionary<string, MetaDataExport>();
                            if (datas?.Count > 0)
                            {
                                foreach (var item2 in datas)
                                {
                                    var id = ((BaseEntity)item2).GetIdentity();
                                    if (!dicData.ContainsKey(id.ToString()))
                                    {
                                        dicData.Add(id.ToString(), new MetaDataExport { Data = item2, sDM_DonVi_Id_Xuat = organizationUnitId });
                                    }
                                }
                                foreach (var cf in configExportDatas.FindAll(m => m.sDM_DonVi_Id_DonViXuat == organizationUnitId))
                                {
                                    string pathFolderByOrg = System.IO.Path.Combine(pathExportData, cf.sFolderName, folderExportByTime);

                                    if (!System.IO.Directory.Exists(pathFolderByOrg))
                                    {
                                        System.IO.Directory.CreateDirectory(pathFolderByOrg);
                                    }

                                    string folderDictionary = System.IO.Path.Combine(pathFolderByOrg, "Dictionary");

                                    if (!System.IO.Directory.Exists(folderDictionary))
                                    {
                                        System.IO.Directory.CreateDirectory(folderDictionary);
                                    }
                                    string pathTable = System.IO.Path.Combine(folderDictionary, item.TableName + ".json");

                                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(pathTable, true))
                                    {
                                        file.WriteLine(MT.Library.Utility.SerializeObject(dicData));
                                    }
                                }
                            }

                        }
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
        /// Tạo danh sách transfer data liên quan đến phiếu xuất
        /// </summary>
        /// <param name="tableName">Tên bảng Phiếu xuất</param>
        /// <param name="isDictionary">=true Bảng export là danh mục</param>
        /// <param name="organizationUnitId">Id đơn vị xuất</param>
        private TransferData CreateTransferData(IUnitOfWork unitOfWork,string tableName,Guid id,bool isDictionary,Guid organizationUnitId)
        {
            TransferData transferData = null;
            string query = $"SELECT * FROM {tableName} WHERE Id='{id}'";

            Type type = Type.GetType($"MT.Data.BO.{tableName},MT.Data");

            //Danh sách bản ghi thêm/sửa của bảng item.TableName
            var data = unitOfWork.QueryFirstOrDefault(query, type);

            if (data != null)
            {
                transferData = new TransferData() { sDM_DonVi_Id_Xuat=organizationUnitId};
                transferData.Id = Guid.Parse(id.ToString());
                transferData.Master = data;
               
                //Nếu bảng danh mục thì ko có chi tiết
                if (isDictionary)
                {
                    return transferData;
                }
                if (tableName.Equals("SoKho", StringComparison.OrdinalIgnoreCase))
                {
                    transferData.sDM_DonVi_Id_Nhap = data.GetValue<Guid>("sDM_DonVi_Id_Nguon");
                }
                else
                {
                    transferData.sDM_DonVi_Id_Nhap = data.GetValue<Guid>("sDM_DonVi_Id_Nhap");
                }

                MT.Library.Log.LogHelper.Debug($"CreateTransferData:[TableName={tableName},sDM_DonVi_Id_Nhap={transferData.sDM_DonVi_Id_Nhap}]");

                string tableDetail = $"{tableName}_CT";

                query = $@"IF OBJECT_ID (N'{tableDetail}', N'U') IS NOT NULL 
                                                    SELECT 1 AS res ELSE SELECT 0 AS res;";

                //Kiểm tra tồn tại bảng chi tiết
                var exists = unitOfWork.QueryFirstOrDefault<bool>(query);

                Type typeDetail = Type.GetType($"MT.Data.BO.{tableDetail},MT.Data");

                if (!exists || typeDetail == null)
                {
                    return transferData;
                }
                query = $@"SELECT * FROM {tableDetail} WHERE s{tableName}_Id='{id}'";

                //Lấy danh sách bản ghi chi tiết theo masterid
                var details = unitOfWork.Query(query, typeDetail);

                transferData.Details = details;

                string tableDetailPK = $"{tableName}_CT_PhuKien";

                query = $@"IF OBJECT_ID (N'{tableDetailPK}', N'U') IS NOT NULL 
                                                    SELECT 1 AS res ELSE SELECT 0 AS res;";

                ///Có tồn tại bản phụ kiện chi tiết
                var existsPK = unitOfWork.QueryFirstOrDefault<bool>(query);
                if (!existsPK)
                {
                    return transferData;
                }

                //Lưu danh sách phụ kiện ứng với bản ghi chi tiết
                transferData.DicPK_Details = new Dictionary<string, System.Collections.IList>();
                foreach (var d in details)
                {
                    Type typeDetailPK = Type.GetType($"MT.Data.BO.{tableDetailPK},MT.Data");

                    if (typeDetailPK == null)
                    {
                        break;
                    }

                    var idPK = ((BaseEntity)d).GetIdentity();

                    query = $@"SELECT * FROM {tableDetailPK} WHERE s{tableDetail}_Id='{id}'";
                    var detailsPK = unitOfWork.Query(query, typeDetailPK);

                    if (!transferData.DicPK_Details.ContainsKey(idPK.ToString()))
                    {
                        transferData.DicPK_Details.Add(idPK.ToString(), detailsPK);
                    }
                }
            }
            else
            {
                MT.Library.Log.LogHelper.Debug($"CreateTransferData:[TableName={tableName},Id={id}] IS NULL");
            }
            return transferData;
        }

        /// <summary>
        /// Lấy về các bảng related liên quan đến phiếu
        /// </summary>
        private void GetRelatedData(IUnitOfWork unitOfWork, TransferData masterData, Guid id,Guid organizationUnitId)
        {
           string query = $@"select sTenBangCanCu,sCanCuId from CanCuPhieu WHERE sPhieu_Id='{id}'
                                                AND sCanCuId IS NOT NULL AND sCanCuId <> '00000000-0000-0000-0000-000000000000'
                                                order by dCreatedDate ";

            var canCus = unitOfWork.Query<CanCuPhieu>(query);

            if (canCus?.Count > 0)
            {
                foreach (var c in canCus)
                {
                    var transferDataCanCu = CreateTransferData(unitOfWork, c.sTenBangCanCu, c.sCanCuId.Value, false,organizationUnitId);

                    if (transferDataCanCu == null)
                    {
                        continue;
                    }
                    var transferDataCanCus = new List<TransferData>();
                    if (!masterData.RelatedTableDatas.TryGetValue(c.sTenBangCanCu, out transferDataCanCus))
                    {
                        transferDataCanCus = new List<TransferData>();
                        masterData.RelatedTableDatas.Add(c.sTenBangCanCu, transferDataCanCus);
                    }
                    transferDataCanCus.Add(transferDataCanCu);

                    GetRelatedData(unitOfWork, masterData, transferDataCanCu.Id, organizationUnitId);
                }
            }
        }

        /// <summary>
        /// Tạo thư mục export dữ liệu theo từng hệ
        /// </summary>
        private void CreateFolderExport(IUnitOfWork unitOfWork,string pathExportData,Guid organizationUnitId)
        {
            if (configExportDatas == null)
            {
                string query = "SELECT * FROM ConfigExportData ORDER BY sDM_DonVi_Id_DonViXuat";
                configExportDatas = unitOfWork.Query<ConfigExportData>(query);
            }

            if(configExportDatas==null || configExportDatas.Count == 0)
            {
                throw new Exception("Bạn chưa thiết lập config trong bảng ConfigExportData");
            }

            foreach (var item in configExportDatas.FindAll(m=>m.sDM_DonVi_Id_DonViXuat==organizationUnitId))
            {
                string pathFolderByOrg = System.IO.Path.Combine(pathExportData, item.sFolderName);
                if (!System.IO.Directory.Exists(pathFolderByOrg))
                {
                    System.IO.Directory.CreateDirectory(pathFolderByOrg);
                }
            }
        }

    }
}
