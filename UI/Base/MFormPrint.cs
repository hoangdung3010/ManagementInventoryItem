using DevExpress.XtraSplashScreen;
using FlexCel.Render;
using MT.Data.BO;
using MT.Data.Rep;
using MT.Library.UW;
using MTControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormUI
{
    public partial class MFormPrint : FormUI.FormUIBase
    {
        #region"Declare"
        IOverlaySplashScreenHandle _overlaySplashScreenHandle = null;
        private ConfigExcel _configExcel;
        private ConfigReport _configReport;
        private object _id;
        private string _tableName;
        private string _pathOutputPDF;
        #endregion

        public MFormPrint(object id, string tableName, ConfigExcel configExcel = null, ConfigReport configReport = null)
        {
            InitializeComponent();
            _id = id;
            _tableName = tableName;
            _configExcel = configExcel;
            _configReport = configReport;
        }

        #region"Sub/Func"

        /// <summary>
        /// Thực hiện tạo đối tượng exelFile
        /// </summary>
        /// <returns></returns>
        private ResultExcelFile CreateExcelFile()
        {
            ResultExcelFile resultExcelFile = new ResultExcelFile();
            using (IUnitOfWork unitOfWork = new MT.Library.UW.UnitOfWork(MT.Library.SessionData.ConnectString))
            {
                var rep = MT.Data.FactoryReport.Create(unitOfWork, _configReport.RepName);

                string query = $"SELECT * FROM ReportData where DictionaryKey={(int)_configReport.DictionaryKey}";

                ReportData reportData = unitOfWork.QueryFirstOrDefault<ReportData>(query);

                if (MT.Library.Utility.CheckForSQLInjection(_tableName))
                {
                    throw new Exception($"{_tableName} is injection");
                }
                if (_configExcel.ParametersExcel == null)
                {
                    _configExcel.ParametersExcel = new Dictionary<string, MTParameter>();
                }
                if (reportData.IsPrintVoucher)
                {
                    query = $@"IF OBJECT_ID('View_{_tableName}', 'V') IS NOT NULL SELECT * FROM View_{_tableName} WHERE Id=@Id 
                                ELSE SELECT * FROM {_tableName} WHERE Id=@Id ";

                    Dictionary<string,object> dicData = unitOfWork.QueryDictionary(query, new {Id=_id});
                    if (dicData != null)
                    {
                        foreach (var item in dicData)
                        {
                            _configExcel.ParametersExcel.Add(item.Key, new MTParameter { OriginValue = item.Value,
                                Value = MT.Library.Utility.FormatValue(item.Value) });
                        }
                    }
                }

                resultExcelFile.ReportData = reportData;

                _configExcel.StartRowIndex = reportData.StartRow;
                _configExcel.Title = reportData.ReportName;

                resultExcelFile.FlexCelResult = rep.CreateReport(_configExcel, reportData);
            }
            return resultExcelFile;
        }

#endregion

#region"Event"
        private void MFormPrint_Load(object sender, EventArgs e)
        {
            try
            {
                _overlaySplashScreenHandle = CommonFnUI.ShowProgress(this);
                if (!backgroundWorkerPrint.IsBusy)
                {
                    backgroundWorkerPrint.RunWorkerAsync();
                }
            }
            catch (Exception ex)
            {
                CommonFnUI.ShowError(ex, "Xuất báo cáo");
            }
        }

        /// <summary>
        /// Xử lý xuất báo cáo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorkerPrint_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = CreateExcelFile();
        }

        /// <summary>
        /// Hiển thị lên form in
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorkerPrint_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                var resultExcelFile = e.Result as ResultExcelFile;
                if (resultExcelFile.FlexCelResult != null)
                {
                    string pathFolderTemp = Application.StartupPath + "\\Temp";

                    if (!System.IO.Directory.Exists(pathFolderTemp))
                    {
                        System.IO.Directory.CreateDirectory(pathFolderTemp);
                    }

                    _pathOutputPDF = System.IO.Path.Combine(pathFolderTemp, $"{System.IO.Path.GetFileNameWithoutExtension(resultExcelFile.ReportData.FileName)}.pdf");
                    resultExcelFile.FlexCelResult.HideZeroValues = true;
                    // 2. Xuất dữ liệu ra máy in
                    using (var pdf = new FlexCelPdfExport(resultExcelFile.FlexCelResult, true))
                    {
                        pdf.Export(_pathOutputPDF);
                    }
                    pdfViewer1.LoadDocument(_pathOutputPDF);
                    this.pdfZoom100CheckItem1.Checked = true;
                }
                else
                {
                    MMessage.ShowError($"Đã có lỗi xảy ra trong quá trình xử lý.");
                }
            }
            else
            {
                MMessage.ShowError($"Đã có lỗi xảy ra trong quá trình xử lý: {e.Error.Message}");
            }
            if (_overlaySplashScreenHandle != null)
            {
                CommonFnUI.CloseProgress(_overlaySplashScreenHandle);
            }
        }

        private void MFormPrint_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if (System.IO.File.Exists(_pathOutputPDF))
                {
                    MT.Library.FileHelper.DeleteFile(_pathOutputPDF);
                }
            }
            catch (Exception)
            {
                //todo
            }
        }
#endregion


    }
}
