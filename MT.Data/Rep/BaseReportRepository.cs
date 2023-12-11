using FlexCel.Core;
using FlexCel.XlsAdapter;
using MT.Data.BO;
using MT.Data.Rep;
using MT.Library.Extensions;
using MT.Library.UW;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MT.Data
{
    public class BaseReportRepository : IBaseReportRepository
    {
        protected readonly IUnitOfWork _unitOfWork;

        private ConfigExcel _configExcel;
        public BaseReportRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #region"Sub/Func"
        /// <summary>
        /// Kiểm tra file có tồn tại không
        /// </summary>
        /// <param name="pathFileName">Tên file</param>
        /// <returns>=true là tồn tai, ngược lại thì ko tồn tại</returns>
        private bool CheckExistsFileName(string pathFileName)
        {
            if (System.IO.File.Exists(pathFileName))
            {
                return true;
            }
            return false;
        }
       
        /// <summary>
        /// Thực hiện tạo file excel
        /// </summary>
        /// <param name="pathFileName">Đường dẫn file</param>
        public void CreateExcel(string pathFileName)
        {
            FlexCel.XlsAdapter.XlsFile result = new FlexCel.XlsAdapter.XlsFile(1,true);
            result.Save(pathFileName);
        }
        /// <summary>
        /// Hàm tạo báo cáo, dùng khi đã có đầy đủ dữ liệu xuất ra
        /// </summary>
        /// <param name="pathFileName">Đường dẫn đầy đủ của file</param>
        /// <param name="data">Danh sách dữ liệu</param>
        /// <returns>Trả về nội dung file excel</returns>
        public ExcelFile CreateReport(ConfigExcel configExcel, string pathFileName, DataSet ds)
        {
            configExcel.CurrenRowIndex = configExcel.StartRowIndex;
            _configExcel = configExcel;
            if (!CheckExistsFileName(pathFileName))
            {
                throw new Exception($"{pathFileName} not exists");
            }

            if(configExcel.ShowColumnsOrder==null || configExcel.ShowColumnsOrder.Count == 0)
            {
                throw new Exception($"Bạn chưa thiết lập ShowColumnsOrder trong ConfigExcel");
            }
            FlexCel.XlsAdapter.XlsFile result = new FlexCel.XlsAdapter.XlsFile(true);
            result.Open(pathFileName);

            DataTable data = new DataTable();
            if (ds.Tables?.Count > 0)
            {
                data = ds.Tables[0];
            }

            FlexCel.Report.FlexCelReport fr = new FlexCel.Report.FlexCelReport();

            //0.Truyền param vào file excel
            InitParameterExcel(configExcel, result, fr);

            //1. Tạo header báo cáo
            RenderHeaderReport(configExcel,result, fr, data);
            //2. Tạo nội dung báo cáo(phần body)
            RenderBodyReport(configExcel,result, fr, data);
            //3. Render phần chân báo cáo(footer)
            RenderFooterReport(configExcel,result, fr, data);

            AddTable(fr, ds);
            fr.Run(result);

            //4. Thiết lập margin trước khi in
            SetPrintMargin(configExcel, result);
            return result;
        }

        /// <summary>
        /// Hàm tạo báo cáo dùng khi cần lấy dữ liệu từ store trong bảng Report để xuất ra file
        /// </summary>
        /// <param name="pathFileName">Đường dẫn đầy đủ của file</param>
        /// <param name="data">Danh sách dữ liệu</param>
        /// <param name="paramStore">Tham số truyền vào store</param>
        /// <returns>Trả về nội dung file excel</returns>
        public ExcelFile CreateReport(ConfigExcel configExcel,ReportData reportData)
        {
            configExcel.CurrenRowIndex = configExcel.StartRowIndex;
            _configExcel = configExcel;
            string pathFileName=$@"Template\{reportData.FileName}";
            if (reportData.IsPrintVoucher)
            {
                pathFileName = $@"Template\Prints\{reportData.FileName}";
            }

            if (!CheckExistsFileName(pathFileName))
            {
                throw new Exception($"{pathFileName} not exists");
            }

            if (configExcel.ShowColumnsOrder == null || configExcel.ShowColumnsOrder.Count == 0)
            {
                throw new Exception($"Bạn chưa thiết lập ShowColumnsOrder trong ConfigExcel");
            }

            FlexCel.XlsAdapter.XlsFile result = new FlexCel.XlsAdapter.XlsFile(true);

            result.Open(pathFileName);

            DataSet ds = _unitOfWork.QueryDataSet(reportData.StoreName, configExcel.ParamsStore, CommandType.StoredProcedure);

            DataTable data = new DataTable();
            if (ds.Tables?.Count > 0)
            {
                 data = ds.Tables[0];
            }

            FlexCel.Report.FlexCelReport fr = new FlexCel.Report.FlexCelReport();

            //0.Truyền param vào file excel
            InitParameterExcel(configExcel, result, fr);

            //1. Tạo header báo cáo
            RenderHeaderReport(configExcel,result, fr, data);
            //2. Tạo nội dung báo cáo(phần body)
            RenderBodyReport(configExcel,result, fr, data);
            //3. Render phần chân báo cáo(footer)
            RenderFooterReport(configExcel,result, fr, data);
            
            AddTable(fr, ds);
            fr.Run(result);


            //4. Thiết lập margin trước khi in
            SetPrintMargin(configExcel, result);
            return result;
        }

        /// <summary>
        /// Thực hiện add table vào template
        /// </summary>
        /// <param name="fr">Đối tượng xuất báo cáo</param>
        /// <param name="ds">Đối tượng chứa danh sách bảng</param>
        public virtual void AddTable(FlexCel.Report.FlexCelReport fr, DataSet ds)
        {
            fr.ClearTables();
            //Đặt bảng theo nguyên tắc từ T1=>Tn
            if (ds != null)
            {
                for (int i = 0; i < ds.Tables.Count; i++)
                {
                    ds.Tables[i].TableName = $"T{i + 1}";
                }
            }
            fr.AddTable(ds, disposeMode: FlexCel.Report.TDisposeMode.DisposeAfterRun);
        }

        /// <summary>
        /// Căn chỉnh margin trước khi in
        /// </summary>
        /// <param name="configExcel">Thông tin cấu hình excel</param>
        /// <param name="result">Đối tượng excel</param>
        protected virtual void SetPrintMargin(ConfigExcel configExcel, FlexCel.XlsAdapter.XlsFile result)
        {
            ////////////////////////////////////////
            //7. Thiết lập tham số máy in
            //Inch: Lấy giá trị dạng cm
            TXlsMargins _TXlsMargins = new TXlsMargins();
            var _rRight = (double)(configExcel.MarginRight) / (2.54);
            var _rLeft = (double)(configExcel.MarginLeft) / (2.54);
            var _rTop = (double)(configExcel.MarginTop) / (2.54);
            var _rBottom = (double)(configExcel.MarginBottom) / (2.54);
            //SetPrintMargins
            _TXlsMargins.Left = (double)_rLeft;
            _TXlsMargins.Right = (double)_rRight;
            _TXlsMargins.Top = (double)_rTop;
            _TXlsMargins.Bottom = (double)_rBottom;
            //
            result.SetPrintMargins(_TXlsMargins);
        }
        
        /// <summary>
        /// Trả về text căn trái,phải hay giữa
        /// </summary>
        /// <returns></returns>
        private FlexCel.Core.THFlxAlignment GetHFlxAlignmentByData(DataColumn column)
        {
            if (column == null)
            {
                return FlexCel.Core.THFlxAlignment.left;
            }
            /*Boolean
            Byte
            Char
            DateTime
            Decimal
            Double
            Int16
            Int32
            Int64
            SByte
            Single
            String
            TimeSpan
            UInt16
            UInt32
            UInt64
            */
            switch (column.DataType.Name)
            {
                case "Char":
                case "String":
                    return FlexCel.Core.THFlxAlignment.left;
                case "DateTime":
                case "TimeSpan":
                    return FlexCel.Core.THFlxAlignment.center;
                case "Byte":
                case "Decimal":
                case "Double":
                case "Int16":
                case "Int32":
                case "Int64":
                case "SByte":
                case "Single":
                case "UInt16":
                case "UInt32":
                case "UInt64":
                    return FlexCel.Core.THFlxAlignment.right;
            }

            return FlexCel.Core.THFlxAlignment.left;
        }

        /// <summary>
        /// Convert giá trị của rowCell sang string
        /// </summary>
        private string ConvertCellValueToString(ConfigExcel configExcel, DataRow dataRow,string fieldName)
        {
            object vVal = null;
            if (dataRow == null 
                || !dataRow.Table.Columns.Contains(fieldName) 
                || dataRow.IsNull(fieldName) 
                || "0".Equals(dataRow.GetRowCellValue<object>(fieldName)))
            {
                return string.Empty;
            }
           
            if(configExcel.DefineColumnWithEnum?.Count>0
                && configExcel.DefineColumnWithEnum.ContainsKey(fieldName))
            {
                var eValue = dataRow.GetRowCellValue<object>(fieldName);
                if (eValue == null)
                {
                    eValue = 0;
                }
                string enumName = configExcel.DefineColumnWithEnum[fieldName];
                MTControl.DisplayEnum displayEnum = displayEnum = MTControl.MCommon.GetDisplayEnum(enumName,
                    Convert.ToInt32(eValue));
                if (displayEnum != null)
                {
                    return displayEnum.Text;
                }
                else
                {
                    vVal = dataRow.Field<object>(fieldName);
                    return MT.Library.Utility.FormatValue(vVal);
                }
            }
            vVal= dataRow.Field<object>(fieldName);
            return MT.Library.Utility.FormatValue(vVal);
        }
        #endregion

        #region"Overrides"

        /// <summary>
        /// Truyền các biến khai báo trên excel
        /// </summary>
        /// <param name="result">Đối tượng thao tác file excel</param>
        /// <param name="fr">Đối tượng xuất file excel ra báo cáo </param>
        protected void InitParameterExcel(ConfigExcel configExcel,FlexCel.XlsAdapter.XlsFile result,
            FlexCel.Report.FlexCelReport fr)
        {
            CustomInitParameterExcel(configExcel, result, fr);

            if (configExcel.ParametersExcel != null)
            {
                foreach (var item in configExcel.ParametersExcel)
                {
                    fr.SetValue(item.Key, item.Value.Value);
                }
            }

            fr.SetValue("Title", configExcel.Title);

            fr.SetValue("SubTitle", configExcel.SubTitle);
        }

        /// <summary>
        /// Xử lý chèn thêm tham số vào báo cáo
        /// </summary>
        /// <param name="configExcel"></param>
        /// <param name="result"></param>
        /// <param name="fr"></param>
        protected virtual void CustomInitParameterExcel(ConfigExcel configExcel, FlexCel.XlsAdapter.XlsFile result,
            FlexCel.Report.FlexCelReport fr)
        {
            if (configExcel.ParametersExcel == null)
            {
                configExcel.ParametersExcel = new Dictionary<string, MTParameter>();
            }
            configExcel.ParametersExcel.AddOrUpdate("OrganizationUnitName", new MTParameter
            {
                Value = MT.Library.SessionData.OrganizationUnitName,
                OriginValue = MT.Library.SessionData.OrganizationUnitName,
            });
            configExcel.ParametersExcel.AddOrUpdate("FullName",new MTParameter
            {
                Value = MT.Library.SessionData.FullName,
                OriginValue = MT.Library.SessionData.FullName,
            });
            DateTime now = SysDateTime.Instance.Now();
            configExcel.ParametersExcel.AddOrUpdate("dNgayIn", new MTParameter
            {
                Value = $"Ngày {now.Day.ToString().PadLeft(2,'0')}, Tháng {now.Month.ToString().PadLeft(2, '0')}, Năm {now.Year}",
                OriginValue = now,
            });

            if (configExcel.IsFixedHeight)
            {
                if (configExcel.RowHeight <= 0)
                {
                    fr.SetValue("iRowHeight", 566);
                }
                else
                {
                    fr.SetValue("iRowHeight", configExcel.RowHeight * 566);
                }
            }
            else
            {
                fr.SetValue("iRowHeight", "AUTOFIT");
            }

            int fontSize = 0;
            if (configExcel.FontSize <= 0)
            {
                fontSize= (int)(8 * 20);
                fr.SetValue("fFontSize", fontSize);
            }
            else
            {
                fontSize=(int)(configExcel.FontSize * 20);
                fr.SetValue("fFontSize", fontSize);
            }
            //todo
        }

        /// <summary>
        /// Hàm thực hiện vẽ header báo cáo
        /// </summary>
        /// <param name="result">Đối tượng thao tác file excel</param>
        /// <param name="fr">Đối tượng xuất file excel ra báo cáo </param>
        /// <param name="data">Dữ liệu báo cáo</param>
        protected virtual void RenderHeaderReport(ConfigExcel configExcel, FlexCel.XlsAdapter.XlsFile result, 
            FlexCel.Report.FlexCelReport fr,
            DataTable data)
        {
            if (configExcel?.HeaderTables?.Count > 0)
            {
                int jColIndex = 0;
               
                //Vẽ danh sách cột động
                foreach (var item in configExcel.HeaderTables)
                {
                    int fontSize = 11 * 20;
                    MTCell mTCellEmpty = new MTCell
                    {
                        Row = null,
                        Column = new DataColumn(item.DataIndex, typeof(string)),
                        RowIndex = configExcel.HeaderPositionIndex,
                        ColIndex = jColIndex + 1,
                        OriginValue = item.HeaderText,
                        StringValue = item.HeaderText,
                        AllowHtml = true,
                        IsHeaderText=true,
                        FontSize= fontSize,
                        FontStyle =TFlxFontStyles.Bold
                    };
                    //1. Tạo cột header
                    SetCustomCellValue(configExcel, result, mTCellEmpty);
                    result.SetColWidth(mTCellEmpty.ColIndex, item.Width * 25);

                    //2.SetFormat
                    var formatCellEmpty = SetCustomCellFormat(configExcel, result, mTCellEmpty);
                 
                    result.SetCellFormat(mTCellEmpty.RowIndex, mTCellEmpty.ColIndex, result.AddFormat(formatCellEmpty));

                    jColIndex++;
                }

                configExcel.StartRowIndex = configExcel.HeaderPositionIndex + 1;
                configExcel.CurrenRowIndex = configExcel.StartRowIndex;
            }
        }

        /// <summary>
        /// Hàm thực hiện vẽ body báo cáo
        /// </summary>
        /// <param name="result">Đối tượng thao tác file excel</param>
        /// <param name="fr">Đối tượng xuất file excel ra báo cáo </param>
        /// <param name="data">Dữ liệu báo cáo</param>
        protected virtual void RenderBodyReport(ConfigExcel configExcel, FlexCel.XlsAdapter.XlsFile result,
            FlexCel.Report.FlexCelReport fr,
            DataTable data)
        {
            if (data?.Rows.Count > 0)
            {
                // Đưa bảng dữ liệu vào file
                for (int iRow = 0; iRow < data.Rows.Count; iRow++)
                {
                    DataRow dataRow = data.Rows[iRow];
                    int jColIndex = 0;
                    foreach (var item in configExcel.ShowColumnsOrder)
                    {
                        if (!data.Columns.Contains(item))
                        {
                            MTCell mTCellEmpty = new MTCell
                            {
                                Row = dataRow,
                                Column = new DataColumn(item,typeof(string)),
                                RowIndex = configExcel.CurrenRowIndex,
                                ColIndex = jColIndex + 1,
                                OriginValue = string.Empty,
                                StringValue = string.Empty,
                                AllowHtml = false
                            };

                            if (configExcel.HeaderTables?.Find(m => m.DataIndex == item)?.IsHtmlDraw==true)
                            {
                                mTCellEmpty.AllowHtml = true;
                            }

                            SetCustomCellValue(configExcel, result, mTCellEmpty);

                            //2.SetFormat
                            var formatCellEmpty = SetCustomCellFormat(configExcel, result, mTCellEmpty);
                            result.SetCellFormat(mTCellEmpty.RowIndex, mTCellEmpty.ColIndex, result.AddFormat(formatCellEmpty));

                            jColIndex++;
                            continue;
                        }
                        DataColumn dataColumn = dataRow.Table.Columns[item];
                        
                        //1.SetValue
                        object originValue = dataRow.GetRowCellValue<object>(item);
                        string stringValue = ConvertCellValueToString(configExcel,dataRow, item);

                        MTCell mTCell = new MTCell
                        {
                            Row = dataRow,
                            Column= dataColumn,
                            RowIndex = configExcel.CurrenRowIndex,
                            ColIndex=jColIndex+1,
                            OriginValue= originValue,
                            StringValue= stringValue,
                            AllowHtml=false
                        };
                        if (configExcel.HeaderTables?.Find(m => m.DataIndex == item)?.IsHtmlDraw == true)
                        {
                            mTCell.AllowHtml = true;
                        }

                        SetCustomCellValue(configExcel,result, mTCell);
                        
                        //2.SetFormat
                        var formatCell = SetCustomCellFormat(configExcel, result, mTCell);
                        result.SetCellFormat(mTCell.RowIndex, mTCell.ColIndex, result.AddFormat(formatCell));

                        jColIndex++;
                    }

                    SetCustomRowStyle(configExcel, result, data);

                    if (configExcel.IsFixedHeight)
                    {
                        if (configExcel.RowHeight <= 0)
                        {
                            configExcel.RowHeight = 566;
                        }
                        result.SetRowHeight(configExcel.CurrenRowIndex, configExcel.RowHeight*566);
                    }
                    else
                    {
                        result.SetAutoRowHeight(configExcel.CurrenRowIndex, true);
                        result.AutofitRow(configExcel.CurrenRowIndex, false, 1);
                    }
                    if (iRow < data.Rows.Count - 1)
                    {
                        InsertRow(result, configExcel.CurrenRowIndex);
                    }
                    configExcel.CurrenRowIndex++;
                    
                }
            }
         }

        /// <summary>
        /// Hàm thực hiện custom style của row(Dùng trong trường hợp muốn merge row)
        /// </summary>
        ///<param name="configExcel">Thông tin cấu hình excel</param>
        /// <param name="result">Đối tượng thao tác file excel</param>
        protected virtual void SetCustomRowStyle(ConfigExcel configExcel, FlexCel.XlsAdapter.XlsFile result, DataTable data)
        {

        }

        /// <summary>
        /// Hàm thực hiện vẽ body báo cáo
        /// </summary>
        ///<param name="configExcel">Thông tin cấu hình excel</param>
        /// <param name="result">Đối tượng thao tác file excel</param>
        /// <param name="fr">Đối tượng xuất file excel ra báo cáo </param>
        /// <param name="mTCell">Thông tin của cell</param>
        protected virtual void SetCustomCellValue(ConfigExcel configExcel, FlexCel.XlsAdapter.XlsFile result,
            MTCell mTCell)
        {
            if (mTCell.AllowHtml)
            {
                result.SetCellFromHtml(mTCell.RowIndex, mTCell.ColIndex, mTCell.StringValue);
            }
            else
            {
                result.SetCellValue(mTCell.RowIndex, mTCell.ColIndex, mTCell.StringValue);
            }
        }

        /// <summary>
        /// Thực hiện insert dòng mới từ dòng hiện tại
        /// </summary>
        /// <param name="result">Đối tượng thao tác excel</param>
        /// <param name="currentRow">Đòng hiện tại</param>
        /// Trả về vị trí dòng đầu tiên được insert
        protected int InsertRow(FlexCel.XlsAdapter.XlsFile result,int currentRow,int rowCount=1)
        {
            result.InsertAndCopyRange(new TXlsCellRange(currentRow, 1, currentRow,1),
                         currentRow + rowCount, 1,1, TFlxInsertMode.ShiftRowDown,TRangeCopyMode.AllIncludingDontMoveAndSizeObjects);
            return currentRow + rowCount;
        }

        /// <summary>
        /// Hàm thực hiện vẽ body báo cáo
        /// </summary>
        ///<param name="configExcel">Thông tin cấu hình excel</param>
        /// <param name="result">Đối tượng thao tác file excel</param>
        /// <param name="fr">Đối tượng xuất file excel ra báo cáo </param>
        /// <param name="mTCell">Thông tin của cell</param>
        protected virtual FlexCel.Core.TFlxFormat SetCustomCellFormat(ConfigExcel configExcel, FlexCel.XlsAdapter.XlsFile result,
           MTCell mTCell)
        {
            FlexCel.Core.TFlxFormat formatCell = result.GetFormat(result.GetCellFormat(mTCell.RowIndex, mTCell.ColIndex));
            //Căn lề
            formatCell.VAlignment = TVFlxAlignment.center;
            if (!mTCell.IsHeaderText)
            {
                formatCell.HAlignment = GetHFlxAlignmentByData(mTCell.Column);
            }
            else
            {
                formatCell.HAlignment = THFlxAlignment.center;
            }

            if (configExcel.DefineColumnWithEnum?.Count > 0
                && configExcel.DefineColumnWithEnum.ContainsKey(mTCell.Column.ColumnName))
            {
                formatCell.HAlignment = THFlxAlignment.left;
            }

            if (!mTCell.WrapText && formatCell.HAlignment == THFlxAlignment.left)
            {
                formatCell.WrapText = true;
            }
            else
            {
                formatCell.WrapText = mTCell.WrapText;
            }
            //Border
            if (!mTCell.IsHeaderText)
            {
                formatCell.Borders.SetAllBorders(TFlxBorderStyle.Thin, TExcelColor.Automatic);
            }
            else
            {
                formatCell.Borders.SetAllBorders(TFlxBorderStyle.Medium, TExcelColor.Automatic);
            }

            //Set font chữ
            formatCell.Font.Name = "Times New Roman";
            
            formatCell.Font.Size20 = (int)(configExcel.FontSize*20);
            if (mTCell.FontSize <= 0)
            {
                formatCell.Font.Size20 =(int)(configExcel.FontSize * 20);
            }
            else
            {
                formatCell.Font.Size20 = mTCell.FontSize;
            }
            formatCell.Font.Style = mTCell.FontStyle;
            formatCell.Indent= 0;
            return formatCell;
        }

        /// <summary>
        /// Hàm thực hiện vẽ body báo cáo
        /// </summary>
        /// <param name="result">Đối tượng thao tác file excel</param>
        /// <param name="fr">Đối tượng xuất file excel ra báo cáo </param>
        /// <param name="data">Dữ liệu báo cáo</param>
        protected virtual void RenderFooterReport(ConfigExcel configExcel, FlexCel.XlsAdapter.XlsFile result,
            FlexCel.Report.FlexCelReport fr,
            DataTable data)
        {
            result.HideZeroValues = true;
        }

        #endregion
    }
}
