using FlexCel.Core;
using FlexCel.XlsAdapter;
using MT.Data.BO;
using MT.Data.ExchangeData;
using MT.Library;
using MT.Library.Extensions;
using MT.Library.UW;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MT.Data.Rep
{
    public class ImportBaseRepository: IBaseImportRepository
    {
        private XlsFile _xlsFile;
        protected readonly IUnitOfWork _unitOfWork;

        private const string MSC_ImportError = "ImportError";

        private const string MSC_ImportValid = "ImportValid";

        protected ArgumentImport _argumentImport;

        private List<ConfigImportMapping> _configImportMappings;

        private List<ColumnMatchWhenImportExcel> _columnMatchWhenImportExcels;

        private ConcurrentDictionary<string, Dictionary<string, Guid>> _dicLookupData = new ConcurrentDictionary<string, Dictionary<string, Guid>>();
        public ImportBaseRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Thiết lập thông tin khi import
        /// </summary>
        /// <param name="argumentImport"></param>
        public void SetConfig(ArgumentImport argumentImport)
        {
            _argumentImport = argumentImport;
        }

        /// <summary>
        /// Thực hiện mở file
        /// </summary>
        public void OpenXlsFile(string fileName)
        {
            XlsFile xls = new XlsFile(false);
            xls.Open(fileName);
            _xlsFile = xls;
        }

        /// <summary>
        /// Đọc số sheet của file
        /// </summary>
        /// <param name="xls">Tên file</param>
        public List<string> GetSheetsName()
        {
            if (_xlsFile == null)
            {
                throw new Exception("File not open.");
            }
            List<string> sheetNames = new List<string>();
            for (int sheet = 1; sheet <= _xlsFile.SheetCount; sheet++)
            {
                sheetNames.Add(_xlsFile.GetSheetName(sheet));
            }
            return sheetNames;
        }

        /// <summary>
        /// Validate xem excel có hợp lệ không
        /// </summary>
        /// <returns>Trả về true là hợp lệ</returns>
        public bool ValidFile()
        {
            if (_xlsFile == null)
            {
                throw new Exception("File not open.");
            }

            int colCount = _xlsFile.ColCount;

            if (colCount < 2)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Lấy về thiết lập mapping của chức năng nhập khẩu
        /// </summary>
        public List<ConfigImportMapping> GetConfigImportMapping(string tableName)
        {
            string query = $@"SELECT * FROM ConfigImportMapping WHERE TableName=@TableName ORDER BY SortOrder";
            _configImportMappings = _unitOfWork.Query<ConfigImportMapping>(query, new { TableName = tableName });
            return _configImportMappings;
        }

        /// <summary>
        /// Lấy về giá trị của cell
        /// </summary>
        /// <param name="rowIndex">Hàng</param>
        /// <param name="colIndex">Cột</param>
        /// <param name="formatted">=true lấy giá trị đúng như format trên excel, ngược lại chỉ lấy rawvalue</param>
        public string GetCellValue(int rowIndex,int colIndex,bool formatted=false)
        {
            try
            {
                if (formatted)
                {
                    TRichString rs = _xlsFile.GetStringFromCell(rowIndex, colIndex);
                    return rs.Value;
                }

                int XF = 0; //This is the cell format, we will not use it here.
                object val = _xlsFile.GetCellValueIndexed(rowIndex, colIndex, ref XF);

                TFormula fmla = val as TFormula;
                if (fmla != null)
                {
                    return Convert.ToString(fmla.Result);
                }
                else
                {
                    return Convert.ToString(val);
                }
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Ghép cột tự động
        /// </summary>
        public List<ColumnMatchWhenImportExcel> ColumnMatch()
        {
            if (_xlsFile == null || _argumentImport==null)
            {
                throw new Exception("File not open.");
            }

            _xlsFile.ActiveSheet = _argumentImport.ActiveSheet;
            int colCount = _xlsFile.ColCount;

            GetConfigImportMapping(_argumentImport.TableName);

            if(_configImportMappings==null || _configImportMappings.Count == 0)
            {
                return new List<ColumnMatchWhenImportExcel>();
            }
            _columnMatchWhenImportExcels = new List<ColumnMatchWhenImportExcel>();
            for (int cIndex = 1; cIndex <= _xlsFile.ColCountInRow(_argumentImport.RowPosition); cIndex++)
            {
                int colIndexReality = _xlsFile.ColFromIndex(_argumentImport.RowPosition, cIndex);
                string headerText = GetCellValue(_argumentImport.RowPosition, colIndexReality);
                if (string.IsNullOrWhiteSpace(headerText))
                {
                    continue;
                }
                var find = _configImportMappings.Find(m=> MappingContainsHeaderText(headerText,m.Mapping));

                if (find != null)
                {
                    _columnMatchWhenImportExcels.Add(new ColumnMatchWhenImportExcel
                    {
                        SourceDisplay = headerText,
                        Destination= find.FieldName,
                        Description=find.Description,
                        Value=string.Empty,
                        IsRequired= find.IsRequired,
                        ColIndex= colIndexReality,
                        Width= find.Width,
                        IsLock=find.IsLock,
                        DataType= find.DataType,
                        AutoInsert= find.AutoInsert
                    });
                }
            }
            return _columnMatchWhenImportExcels;
        }

        /// <summary>
        /// Kiểm tra mapping có chưa headertext không
        /// </summary>
        /// <param name="headerText">Header text trên excel</param>
        /// <param name="mapping">Thông tin map cột</param>
       bool MappingContainsHeaderText(string headerText,string mapping)
        {
            headerText = headerText.Replace("(*)", "").Replace("*","").Replace("(","").Replace(")","");
            var arrMapping = mapping.ToLower().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            if (arrMapping.Contains(headerText.ToLower()))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Thực hiện đọc dữ liệu từ tệp excel
        /// </summary>
        public IList ReadData()
        {
            IList lst = new List<object>();
            if (_xlsFile == null || _argumentImport == null)
            {
                throw new Exception("File not open.");
            }

            _xlsFile.ActiveSheet = _argumentImport.ActiveSheet;
            int rowCount = _xlsFile.RowCount;
            GetConfigImportMapping(_argumentImport.TableName);

            if (_configImportMappings == null || _configImportMappings.Count == 0)
            {
                return null;
            }
            Type type = Type.GetType($"MT.Data.BO.{_argumentImport.TableName},MT.Data");
            if (type == null)
            {
                return null;
            }
            for (int r = _argumentImport.RowPosition+1; r <= rowCount; r++)
            {
                object data = Activator.CreateInstance(type);

                List<string> errors = new List<string>();

                foreach (var item in _columnMatchWhenImportExcels)
                {
                    string value = GetCellValue(r, item.ColIndex,true);

                    string fieldName = item.Destination;
                    switch (item.DataType)
                    {
                        case (int)MT.Library.Enummation.DataType.Guid:
                            fieldName = $"{item.Destination}_Ten";
                            data.SetValue(fieldName, value);
                            break;
                        case (int)MT.Library.Enummation.DataType.Int:
                            int iVal = 0;
                            if(!string.IsNullOrWhiteSpace(value))
                            {
                                if(!int.TryParse(value, out iVal))
                                {
                                    errors.Add($"Trường <{item.Description}> sai định dạng kiểu dữ liệu.");
                                }
                                else
                                {
                                    data.SetValue(fieldName, iVal);
                                }
                               
                            }
                            else
                            {
                                data.SetValue(fieldName, value);
                            }
                            break;
                        case (int)MT.Library.Enummation.DataType.Long:
                            long lVal = 0;
                            if (!string.IsNullOrWhiteSpace(value))
                            {
                                if(!long.TryParse(value, out lVal))
                                {
                                    errors.Add($"Trường <{item.Description}> sai định dạng kiểu dữ liệu.");
                                }
                                else
                                {
                                    data.SetValue(fieldName, lVal);
                                }

                            }
                            else
                            {
                                data.SetValue(fieldName, value);
                            }
                            break;
                        case (int)MT.Library.Enummation.DataType.Decimal:
                            decimal dVal = 0;
                            if (!string.IsNullOrWhiteSpace(value))
                            {
                                if(!decimal.TryParse(value, out dVal))
                                {
                                    errors.Add($"Trường <{item.Description}> sai định dạng kiểu dữ liệu.");
                                }
                                else
                                {
                                    data.SetValue(fieldName, dVal);
                                }

                            }
                            else
                            {
                                data.SetValue(fieldName, value);
                            }
                            break;
                        case (int)MT.Library.Enummation.DataType.Date:
                        case (int)MT.Library.Enummation.DataType.DateTime:
                            DateTime dteVal =DateTime.MinValue;
                            if (!string.IsNullOrWhiteSpace(value))
                            {
                                string[] str = value.Split(new char[1] { '/' }, StringSplitOptions.RemoveEmptyEntries);

                                int iNam = int.Parse(str[2]);
                                int iThang = int.Parse(str[1]);
                                int iNgay= int.Parse(str[0]);

                                if (str.Length < 3 || iNam < 1753 || iThang > 12 || iNgay > 31)
                                {
                                    errors.Add($"Trường <{item.Description}> sai định dạng kiểu dữ liệu (dd/MM/yyyy).");
                                }
                                else
                                {
                                    data.SetValue(fieldName, new DateTime(iNam,iThang,iNgay));
                                }
                            }
                            else
                            {
                                data.SetValue(fieldName, value);
                            }
                            break;
                        case (int)MT.Library.Enummation.DataType.Bool:
                            bool bVal = false;
                            if (!string.IsNullOrWhiteSpace(value))
                            {
                                if ("1".Equals(value))
                                {
                                    data.SetValue(fieldName, true);
                                } else if ("0".Equals(value))
                                {
                                    data.SetValue(fieldName, false);
                                }
                                else
                                {
                                    if (!bool.TryParse(value, out bVal))
                                    {
                                        errors.Add($"Trường <{item.Description}> sai định dạng kiểu dữ liệu.");
                                    }
                                    else
                                    {
                                        data.SetValue(fieldName, bVal);
                                    }
                                }

                            }
                            else
                            {
                                data.SetValue(fieldName, value);
                            }
                            break;
                        default:
                            data.SetValue(fieldName, value);
                            break;
                    }
                  
                }
                //Vị trí của dòng
                data.SetValue(MT.Library.CommonKey.RowHandle, r);
                //Validate dữ liệu

                if (errors.Count > 0)
                {
                    SetDataError(data, false, string.Join(";", errors));
                }

                ValidData(data);

                lst.Add(data);
            }

            //Validate trùng bản ghi trên file nhập khẩu
            List<object> duplicateDatas = new List<object>();
            List<int> indexs = new List<int>();
            string fieldUnique = GetFieldUnique();
            int i = 0;
            foreach (var item in lst)
            {
                object vVal = item.GetValue<object>(fieldUnique);
                if (!duplicateDatas.Contains(vVal))
                {
                    duplicateDatas.Add(vVal);
                    indexs.Add(i);
                }
                else
                {
                    var f = _configImportMappings.Find(m => m.FieldName == fieldUnique);
                   var findIndex= duplicateDatas.FindIndex(m => object.Equals(m, vVal));
                    //Bản ghi đã bị trùng
                    string msg = item.GetValue<string>(MSC_ImportError);

                    if (!string.IsNullOrWhiteSpace(msg))
                    {
                        msg += "; " + $"<{f.Description}> của bản ghi này đã bị trùng với dữ liệu tại dòng {(indexs[findIndex] + 1)}";
                    }
                    else
                    {
                        msg= $"<{f.Description}> của bản ghi này này đã bị trùng với dữ liệu tại dòng {(indexs[findIndex] + 1)}";
                    }
                    SetDataError(item, false, msg);
                }
                i++;

                var msgError= item.GetValue<string>(MSC_ImportError);
                if (string.IsNullOrWhiteSpace(msgError))
                {
                    item.SetValue(MSC_ImportValid, true);
                    item.SetValue(MSC_ImportError,"<Hợp lệ>");
                }
            }
            return lst;
        }

        /// <summary>
        /// Hàm thực hiện validate dữ liệu
        /// </summary>
        /// <param name="rowData">Dữ liệu của dòng</param>
        /// <returns></returns>
        protected virtual void ValidData(object rowData)
        {
            List<string> errorMsg = new List<string>();
            string msg = rowData.GetValue<string>(MSC_ImportError);
            if (!string.IsNullOrWhiteSpace(msg))
            {
                errorMsg.Add(msg);
            }

            try
            {

                foreach (var item in _columnMatchWhenImportExcels)
                {
                    string fieldName = item.Destination;
                    if (item.DataType == (int)MT.Library.Enummation.DataType.Guid)
                    {
                        fieldName = $"{item.Destination}_Ten";
                    }
                    var val = rowData.GetValue<string>(fieldName);

                    if (item.IsRequired && string.IsNullOrWhiteSpace(val))
                    {
                        errorMsg.Add($"<{item.Description}> không được bỏ trống");
                    }
                    //Kiểm tra kiểu dữ liệu của bản ghi có hợp lệ
                    try
                    {
                        switch (item.DataType)
                        {
                            case (int)MT.Library.Enummation.DataType.Int:
                            case (int)MT.Library.Enummation.DataType.Long:
                                long lVal = 0;
                                if (!long.TryParse(val, out lVal))
                                {
                                    errorMsg.Add($"<{item.Description}> kiểu dữ liệu không đúng định dạng");
                                }
                                break;
                            case (int)MT.Library.Enummation.DataType.Date:
                            case (int)MT.Library.Enummation.DataType.DateTime:
                                DateTime dVal;
                                if (!DateTime.TryParse(val, out dVal))
                                {
                                    errorMsg.Add($"<{item.Description}> kiểu dữ liệu không đúng định dạng");
                                }
                                break;
                            case (int)MT.Library.Enummation.DataType.Decimal:
                                Decimal dmVal;
                                if (!Decimal.TryParse(val, out dmVal))
                                {
                                    errorMsg.Add($"<{item.Description}> kiểu dữ liệu không đúng định dạng");
                                }
                                break;

                            default:
                                break;
                        }
                    }
                    catch (OverflowException)
                    {
                        errorMsg.Add($"<{item.Description}> giá trị vượt quá kích thước của kiểu dữ liệu");
                    }
                    catch (Exception)
                    {
                        errorMsg.Add($"<{item.Description}> kiểu dữ liệu không đúng định dạng");
                    }
                }

                foreach (var item in _configImportMappings)
                {
                    if (item.IsLookup && !item.AutoInsert)
                    {
                        string displayValue = rowData.GetValue<string>($"{item.FieldName}_Ten");
                        if (string.IsNullOrWhiteSpace(displayValue) || string.IsNullOrWhiteSpace(item.LookupTableName)
                            || string.IsNullOrWhiteSpace(item.LookupColumnName))
                        {
                            continue;
                        }
                        Dictionary<string, Guid> dicData = new Dictionary<string, Guid>();
                        if (!_dicLookupData.TryGetValue(item.LookupTableName, out dicData))
                        {
                            string query = $@"SELECT Id,{item.LookupColumnName} FROM [{item.LookupTableName}] 
                                        WHERE [{item.LookupColumnName}] IS NOT NULL ORDER BY {MT.Library.CommonKey.ModifiedDate} DESC";
                            dicData = new Dictionary<string, Guid>();
                            _unitOfWork.ProcessIDataReader(query, (rd) =>
                            {
                                while (rd.Read())
                                {
                                    dicData.AddOrUpdate(rd.GetString(1).ToLower().Trim(), rd.GetGuid(0));
                                }
                            });

                            if (dicData.Count > 0)
                            {
                                _dicLookupData.TryAdd(item.LookupTableName, dicData);
                            }
                        }
                        string key = displayValue.ToLower().Trim();
                        if (dicData.ContainsKey(key))
                        {
                            rowData.SetValue(item.FieldName, dicData[key]);
                        }
                        else
                        {
                            errorMsg.Add($"{item.Description} <{displayValue}> không tồn tại trong hệ thống");
                        }
                    }
                }

                if (errorMsg.Count > 0)
                {
                    SetDataError(rowData, false, string.Join("; ", errorMsg));
                }
                else
                {
                    SetDataError(rowData, true);
                }
            }
            catch (Exception)
            {
                errorMsg.Add("Đã có lỗi xảy ra trong quá trình kiểm tra dữ liệu");
                SetDataError(rowData, false, string.Join("; ",errorMsg));
            }
        }

        /// <summary>
        /// Gán thông tin lỗi cho đối tượng nhập khẩu
        /// </summary>
        /// <param name="rowData"></param>
        /// <param name="isValid"></param>
        /// <param name="msg"></param>
        protected void SetDataError(object rowData, bool isValid,string msg = "")
        {
            rowData.SetValue(MSC_ImportValid, isValid);
            if(isValid)
            {
                msg = string.Empty;
            }
            rowData.SetValue(MSC_ImportError, msg);
        }

        /// <summary>
        /// Cập nhật thêm dữ liệu trước hiển thị
        /// </summary>
        /// <param name="rowData">Dòng dữ liệu hiện tại</param>
        public virtual void UpdateMoreData(object rowData)
        {
            var now = SysDateTime.Instance.Now();
            rowData.SetValue("Id", Guid.NewGuid());
            rowData.SetValue(MT.Library.CommonKey.CreatedBy, $"{MT.Library.SessionData.FullName}(Nhập khẩu)");
            rowData.SetValue(MT.Library.CommonKey.ModifiedBy, $"{MT.Library.SessionData.FullName}(Nhập khẩu)");
            rowData.SetValue(MT.Library.CommonKey.CreatedDate,now);
            rowData.SetValue(MT.Library.CommonKey.ModifiedDate,now);
            foreach (var item in _configImportMappings)
            {
                if (item.IsLookup && item.AutoInsert)
                {
                    string displayValue = rowData.GetValue<string>($"{item.FieldName}_Ten");
                    if (string.IsNullOrWhiteSpace(displayValue) || string.IsNullOrWhiteSpace(item.LookupTableName)
                        || string.IsNullOrWhiteSpace(item.LookupColumnName))
                    {
                        continue;
                    }
                    Dictionary<string, Guid> dicData = new Dictionary<string, Guid>();
                    if(!_dicLookupData.TryGetValue(item.LookupTableName,out dicData))
                    {
                        string query = $@"SELECT Id,{item.LookupColumnName} FROM [{item.LookupTableName}] 
                                        WHERE [{item.LookupColumnName}] IS NOT NULL ORDER BY {MT.Library.CommonKey.ModifiedDate} DESC";
                        dicData = new Dictionary<string, Guid>();
                        _unitOfWork.ProcessIDataReader(query, (rd) =>
                        {
                            while (rd.Read())
                            {
                                dicData.AddOrUpdate(rd.GetString(1).ToLower().Trim(), rd.GetGuid(0));
                            }
                        });

                        if (dicData.Count > 0)
                        {
                            _dicLookupData.TryAdd(item.LookupTableName, dicData);
                        }
                    }
                    string key = displayValue.ToLower().Trim();
                    if (dicData.ContainsKey(key)) {
                        rowData.SetValue(item.FieldName, dicData[key]);
                    }
                    else
                    {
                        //Insert ban ghi moi
                        var id = Guid.NewGuid();                       
                        var dicAdd = new Dictionary<string, object>
                            {
                                {item.LookupColumnName,displayValue.Trim() },
                                {"Id",id},
                                {MT.Library.CommonKey.CreatedBy,$"{MT.Library.SessionData.FullName}(Nhập khẩu)"},
                                {MT.Library.CommonKey.ModifiedBy,$"{MT.Library.SessionData.FullName}(Nhập khẩu)"},
                                {MT.Library.CommonKey.CreatedDate,now},
                                {MT.Library.CommonKey.ModifiedDate,now}
                            };
                        _unitOfWork.SaveEntity(dicAdd, item.LookupTableName,Enummation.MTEntityState.Add);
                        rowData.SetValue(item.FieldName, id);
                    }
                }
            }
        }

        /// <summary>
        /// Thực hiện insert toàn bộ dữ liệu vào DB
        /// </summary>
        /// <param name="tableName">Tên bảng insert</param>
        /// <param name="datas">Danh sách dữ liệu</param>
        private bool BulkInsertDatas(string tableName,IList datas)
        {
            try
            {
                Type type = Type.GetType($"MT.Data.BO.{_argumentImport.TableName},MT.Data");

                List<string> cols = GetColsInsert();

                if (cols.IndexOf(MT.Library.CommonKey.RowHandle)==-1)
                {
                    cols.Add(MT.Library.CommonKey.RowHandle);
                }
                if (cols.IndexOf(MT.Library.CommonKey.ImportValid) == -1)
                {
                    cols.Add(MT.Library.CommonKey.ImportValid);
                }
                DataTable _dt = MT.Library.Extensions.ExtensionMethod.ToDataTable(type,datas, cols.ToArray());
                if (_dt == null)
                {
                    return false;
                }
                _unitOfWork.BulkInsert(_dt, tableName,string.Join(",",cols));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }


        /// <summary>
        /// Lấy về danh sách cột tham quá trình insert or update
        /// </summary>
        /// <returns></returns>
        protected virtual List<string> GetColsInsert()
        {
            List<string> cols = _configImportMappings.FindAll(m=>!m.IgnoreDB).Select(m => m.FieldName).ToList();
            cols.Add("Id");
            cols.Add(MT.Library.CommonKey.CreatedBy);
            cols.Add(MT.Library.CommonKey.ModifiedBy);
            cols.Add(MT.Library.CommonKey.CreatedDate);
            cols.Add(MT.Library.CommonKey.ModifiedDate);
            return cols;
        }

        /// <summary>
        /// Lấy về danh sách cột tham quá trình insert or update
        /// </summary>
        /// <returns></returns>
        protected virtual List<string> GetColsUpdate()
        {
            List<string> colsUpdate = _configImportMappings.FindAll(m=>!m.IgnoreDB).Select(m => $"M.[{m.FieldName}]=T.[{m.FieldName}]").ToList();
            colsUpdate.Add($"M.[{MT.Library.CommonKey.ModifiedBy}]=N'{ MT.Library.SessionData.FullName} (Nhập khẩu)'");
            colsUpdate.Add($"M.[{MT.Library.CommonKey.ModifiedDate}]=getdate()");
            return colsUpdate;
        }

        /// <summary>
        /// Tạo bảng clone từ bảng gốc
        /// </summary>
        /// <param name="originTableName">Tên bảng Gốc</param>
        private string  CloneStructTable(string originTableName)
        {
            string tableTemp = $"Import_{originTableName}_{Guid.NewGuid().ToString("N")}";
            string query = $@"Select Top 0 *,CAST(0 AS INT) AS {MT.Library.CommonKey.RowHandle},CAST(0 AS INT) AS {MT.Library.CommonKey.ImportValid} into [{tableTemp}] from [{originTableName}]";
            _unitOfWork.Execute(query);
            return tableTemp;
        }

        /// <summary>
        /// Xóa bảng temp
        /// </summary>
        /// <param name="tableTemp">Tên bảng temp</param>
        private void DropTableTemp(string tableTemp)
        {
            if (string.IsNullOrWhiteSpace(tableTemp))
            {
                return;
            }
            string query = $@"IF OBJECT_ID(N'[dbo].[{tableTemp}]', N'U') IS NOT NULL DROP TABLE [dbo].[{tableTemp}]";
            _unitOfWork.Execute(query);
        }

        /// <summary>
        /// Lấy về trường unique phục vụ nhập khẩu
        /// </summary>
        protected virtual string GetFieldUnique()
        {
            var fieldUnique = _configImportMappings.Find(m => m.IsUnique);
            return fieldUnique?.FieldName;
        }

        /// <summary>
        /// Thêm điệu kiện where khi dùng nhập khẩu cập nhật
        /// </summary>
        protected virtual string AppendWhereUpdate()
        {
            return string.Empty;
        }

        /// <summary>
        /// Thực hiện chuyển dữ liệu vào bảng thật
        /// </summary>
        public ImportResult ExecuteDB(IList datas)
        {
            string tableTemp = string.Empty;
            ImportResult importResult = new ImportResult();
            try
            {
                var fieldUnique = GetFieldUnique();
                if (fieldUnique == null)
                {
                    importResult.ErrorMessage = "Chưa thiết lập trường unique.";
                    return importResult;
                }
                tableTemp =CloneStructTable(_argumentImport.TableName);
                //Đẩy dữ liệu vào bảng Temp TableName=Import_{OriginTable}

                importResult.Total = datas.Count;

                if (!BulkInsertDatas(tableTemp, datas))
                {
                    importResult.ErrorMessage = "Insert dữ liệu vào bảng Temp thất bại.";
                    return importResult;
                }
                
                void AddNewItem()
                {
                    List<string> cols = GetColsInsert();

                    string query = $@"INSERT INTO [{_argumentImport.TableName}]({string.Join(",", cols)})
                                      SELECT {string.Join(",", cols.Select(m=>"T."+m))} FROM [{tableTemp}] AS T
                                      JOIN (SELECT [{fieldUnique}] FROM [{tableTemp}] 
                                            EXCEPT 
                                            SELECT [{fieldUnique}] FROM [{_argumentImport.TableName}]) AS T2 
                                      ON T.[{fieldUnique}]=T2.[{fieldUnique}]";

                    _unitOfWork.Execute(query);

                    query = $"SELECT count(*) FROM [{tableTemp}] WHERE Id IN(SELECT Id FROM [{_argumentImport.TableName}])";

                    //Tổng số bản ghi thêm mới thành công
                   importResult.TotalAddNewSuccess= _unitOfWork.ExecuteScalar<int>(query);

                    //Thực hiện ghi kết quả các bản ghi thêm mới thành công ra file
                    query = $"SELECT {MT.Library.CommonKey.RowHandle} FROM [{tableTemp}] WHERE Id IN(SELECT Id FROM [{_argumentImport.TableName}])";

                    var rowHandles = _unitOfWork.Query<int>(query);

                    FormatCellResultImport(rowHandles, "Thêm mới thành công", TExcelColor.FromArgb(92, 184, 92,0));

                    //Thực hiện xóa các dữ liệu vừa thêm mới bên bảng temp đi
                    query = $@"DELETE FROM [{tableTemp}] WHERE Id IN(SELECT Id FROM [{_argumentImport.TableName}])";

                    _unitOfWork.Execute(query);
                }

                //Nếu nhập khẩu thêm mới thì move các bản ghi thêm mới sang bảng thật
                if (_argumentImport.AddNew)
                {
                    //Thêm mới
                    AddNewItem();
                }
                else
                {
                    //Thêm mới
                    AddNewItem();

                    List<string> colsUpdate = GetColsUpdate();

                    string appendWhere = AppendWhereUpdate();

                    //Cập nhật
                    string query = $@"UPDATE M
                                      SET {string.Join(",", colsUpdate)}
                                      FROM [{_argumentImport.TableName}] AS M
                                      JOIN [{tableTemp}] AS T ON M.[{fieldUnique}]=T.[{fieldUnique}] {appendWhere}";
                    
                    _unitOfWork.Execute(query);

                     query = $@"UPDATE T
                                      SET T.[{MT.Library.CommonKey.ImportValid}]=1
                                      FROM [{_argumentImport.TableName}] AS M
                                      JOIN [{tableTemp}] AS T ON M.[{fieldUnique}]=T.[{fieldUnique}] {appendWhere}";

                    _unitOfWork.Execute(query);

                    query = $"SELECT {MT.Library.CommonKey.RowHandle} FROM [{tableTemp}] WHERE {MT.Library.CommonKey.ImportValid}=1";

                    var rowHandles = _unitOfWork.Query<int>(query);

                    FormatCellResultImport(rowHandles, "Cập nhật thành công",TExcelColor.FromArgb(92, 184, 92,0));

                    //Thực hiện xóa các dữ liệu vừa vừa cập nhật thành công đi
                    query = $@"DELETE FROM [{tableTemp}] WHERE {MT.Library.CommonKey.ImportValid}=1";

                    _unitOfWork.Execute(query);

                    importResult.TotalUpdateSuccess = importResult.Total - importResult.TotalAddNewSuccess;
                }

                string queryAllData = $"SELECT {MT.Library.CommonKey.RowHandle} FROM [{tableTemp}] WHERE {MT.Library.CommonKey.ImportValid}=1";
                var remainRowHandles = _unitOfWork.Query<int>(queryAllData);

                FormatCellResultImport(remainRowHandles, "Nhập khẩu lỗi.", TExcelColor.FromArgb(223, 71, 89, 0));
                var now = SysDateTime.Instance.Now();
                string pathResultImport = $@"Temp\KQ_Nhap_Khau_{_argumentImport.TableName}_{now.ToString("ddMMyyyyHHmmss")}.xls";
                importResult.PathResultImport = pathResultImport;
                _xlsFile.Save(pathResultImport);
            }
            catch (Exception ex)
            {
                importResult.ErrorMessage = ex.Message;
            }
            finally
            {
                DropTableTemp(tableTemp);
            }

            return importResult;
        }

        /// <summary>
        /// Thực hiện formatcell kết quả nhập khẩu
        /// </summary>
        /// <param name="rowHandles">Rowformat</param>
        /// <param name="msg">Tên message</param>
        /// <param name="excelColor">Mầu của chữ</param>
        private void FormatCellResultImport(List<int> rowHandles,string msg, TExcelColor excelColor)
        {
            if (rowHandles?.Count > 0)
            {
                foreach (var row in rowHandles)
                {
                    int col = _columnMatchWhenImportExcels.Count + 2;
                    _xlsFile.SetCellValue(row, col, msg);
                    FlexCel.Core.TFlxFormat formatCell = _xlsFile.GetFormat(_xlsFile.GetCellFormat(row, col));
                    formatCell.WrapText = false;
                    //Set font chữ
                    formatCell.Font.Name = "Times New Roman";
                    formatCell.Font.Size20 = (int)(12 * 20);
                    formatCell.Font.Color = excelColor;
                    _xlsFile.SetCellFormat(row, col, _xlsFile.AddFormat(formatCell));
                }
            }
        }
    }
}
