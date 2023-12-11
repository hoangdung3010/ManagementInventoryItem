using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MT.Data.BO;
using DevExpress.Xpo;
using MT.Library.UW;
using MTControl;
using FlexCel.Render;
using FlexCel.Core;
using DevExpress.XtraSplashScreen;
using System.Diagnostics;

namespace FormUI.Base
{
    public partial class MUserControlParamRP : UserControl
    {
        #region"Declare"

        IOverlaySplashScreenHandle overlaySplashScreenHandle = null;
        /// <summary>
        /// Cấu hình báo cáo
        /// </summary>
        public ConfigReport ConfigReport { get; set; }

        private Dictionary<string, IEditControl> dicControls;

        public Dictionary<string, IEditControl> DicControls
        {
            get { return dicControls; }
            set { dicControls = value; }
        }

        private MDxValidationProvider ValidationProvider = null;

        public Control RootControl { get; set; }

        /// <summary>
        /// Action thực custom tham số tham số truyền vào store báo cáo
        /// </summary>
        public Action<ConfigExcel,Dictionary<string,object>> MyGetCustomParams { get; set; }

        /// <summary>
        /// Action thực custom tham số thiết lập báo cáo
        /// </summary>
        public Action<ConfigExcel> MySetCustomConfigExcel { get; set; }

        private ReportData _reportData;
        #endregion
        public MUserControlParamRP()
        {
            InitializeComponent();
        }

        #region"Sub/Func"
        /// <summary>
        /// Khởi tạo các thông số cho form
        /// dvthang-21.07.2021
        /// </summary>
        protected void InitForm()
        {
            SetReportData();
            if (RootControl == null)
            {
                RootControl = CommonFnUI.GetParentOfType<Form>(this);
            }
            if (_reportData != null && !string.IsNullOrWhiteSpace(_reportData.ReportName))
            {
                RootControl.Text = _reportData.ReportName;
            }
            dicControls = new Dictionary<string, IEditControl>();
            ValidationProvider = new MDxValidationProvider();
            //Lấy toàn bộ các control nhập liệu trên form
            dicControls = CommonFnUI.GetAllControls(RootControl, new Dictionary<string, IEditControl>());
            CommonFnUI.InitValidateControl(ValidationProvider, dicControls);
            //Clear validate lỗi trên form
            CommonFnUI.ClearValidateForm(this.ValidationProvider);

            mRadioGroupModePrint.SelectedIndex = 0;

            nbrFontSize.EditValue = 8;
            nbrRowHeight.EditValue = 1;
            nbrMarginTop.EditValue = 1;
            nbrMarginLeft.EditValue = 1;
            nbrMarginRight.EditValue = 0.5;
            nbrMarginBottom.EditValue = 1;
            chkConfigDefault.Checked = true;
        }

        /// <summary>
        /// Lấy thông tin về báo cáo
        /// </summary>
        private void SetReportData()
        {
            using (IUnitOfWork unitOfWork = new MT.Library.UW.UnitOfWork(MT.Library.SessionData.ConnectString))
            {
                string query = $"SELECT * FROM ReportData where DictionaryKey={(int)ConfigReport.DictionaryKey}";

                _reportData = unitOfWork.QueryFirstOrDefault<ReportData>(query);
            }
        }


        /// <summary>
        /// Thực hiện tạo config excel
        /// </summary>
        /// <returns></returns>
        protected ConfigExcel CreateConfigExcel()
        {
            ConfigExcel configExcel = new ConfigExcel();

            configExcel.RowHeight = (int)nbrRowHeight.Value;

            configExcel.IsFixedHeight = (bool)mRadioGroupModePrint.EditValue;

            configExcel.MarginRight = Convert.ToSingle(nbrMarginRight.Value);

            configExcel.MarginTop = Convert.ToSingle(nbrMarginTop.Value);

            configExcel.MarginLeft = Convert.ToSingle(nbrMarginLeft.Value);
            configExcel.MarginBottom = Convert.ToSingle(nbrMarginBottom.Value);

            configExcel.FontSize = Convert.ToSingle(nbrFontSize.EditValue);

            using (IUnitOfWork unitOfWork = new MT.Library.UW.UnitOfWork(MT.Library.SessionData.ConnectString))
            {
                var rep = MT.Data.FactoryReport.Create(unitOfWork, ConfigReport.RepName);

                configExcel.ShowColumnsOrder = ConfigReport.ShowColumnsOrder;

                configExcel.ParamsStore= GetCustomParams(configExcel);

                configExcel.ParametersExcel  = new Dictionary<string, MTParameter>();
                if (configExcel.ParamsStore != null)
                {
                    foreach (var item in configExcel.ParamsStore)
                    {
                        configExcel.ParametersExcel.Add(item.Key, new MTParameter
                        {
                            Value = MT.Library.Utility.FormatValue(item.Value)
                        });
                    }
                }

                SetCustomConfigExcel(configExcel);

                configExcel.StartRowIndex = _reportData.StartRow;

                if (string.IsNullOrWhiteSpace(configExcel.Title))
                {
                    configExcel.Title = _reportData.ReportName;
                }
            }
            return configExcel;
        }
        #endregion

        #region"Event"
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                string formId = CommonFnUI.GetParentOfType<Form>(this).GetType().Name;
                if (!CommonFnUI.CheckPermission(formId, MT.Library.Enummation.PermissionValue.In))
                {
                    MMessage.ShowWarning("Bạn không có quyền thực hiện chức năng này.");
                    return;
                }

                bool isValid = CommonFnUI.IsValidAll(ValidationProvider, dicControls);
                if (isValid)
                {
                    overlaySplashScreenHandle = CommonFnUI.ShowProgress(this);
                    if (!backgroundWorkerPDF.IsBusy)
                    {
                        ConfigExcel configExcel = CreateConfigExcel();
                        backgroundWorkerPDF.RunWorkerAsync(configExcel);
                    }

                }

            }
            catch (Exception ex)
            {
                CommonFnUI.ShowError(ex, "Xuất báo cáo");
            }
        }

        /// <summary>
        /// Thực hiện tạo đối tượng exelFile
        /// </summary>
        /// <returns></returns>
        private ResultExcelFile CreateExcelFile(ConfigExcel configExcel)
        {
            ResultExcelFile resultExcelFile = new ResultExcelFile();
            using (IUnitOfWork unitOfWork = new MT.Library.UW.UnitOfWork(MT.Library.SessionData.ConnectString))
            {
                var rep = MT.Data.FactoryReport.Create(unitOfWork, ConfigReport.RepName);
                resultExcelFile.ReportData = _reportData;
                resultExcelFile.FlexCelResult = rep.CreateReport(configExcel, _reportData);
            }
            return resultExcelFile;
        }
        private void MUserControlParamRP_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                InitForm();
            }
            
        }

        /// <summary>
        /// Đóng form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
           var frmParent= CommonFnUI.GetParentOfType<Form>(this);
            if (frmParent != null)
            {
                frmParent.Close();
                frmParent.Dispose();
            }
        }

        /// <summary>
        /// Thực hiện xuất excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            string formId = CommonFnUI.GetParentOfType<Form>(this).GetType().Name;
            if (!CommonFnUI.CheckPermission(formId, MT.Library.Enummation.PermissionValue.Export))
            {
                MMessage.ShowWarning("Bạn không có quyền thực hiện chức năng này.");
                return;
            }

            bool isValid = CommonFnUI.IsValidAll(ValidationProvider, dicControls);
            if (isValid)
            {
                
                if (!backgroundWorkerExcel.IsBusy)
                {
                    overlaySplashScreenHandle= CommonFnUI.ShowProgress(this);
                    ConfigExcel configExcel = CreateConfigExcel();
                    backgroundWorkerExcel.RunWorkerAsync(configExcel);
                }
               
            }
        }

        /// <summary>
        /// Thực hiện xuất PDF
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorkerPDF_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result= CreateExcelFile(e.Argument as ConfigExcel);
        }

        /// <summary>
        /// Sau khi xuất pdf xong
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorkerPDF_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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

                    string pathTempSaveFile = System.IO.Path.Combine(pathFolderTemp, $"{System.IO.Path.GetFileNameWithoutExtension(resultExcelFile.ReportData.FileName)}.pdf");

                    // 2. Xuất dữ liệu ra máy in
                    using (var pdf = new FlexCelPdfExport(resultExcelFile.FlexCelResult, true))
                    {
                        pdf.Export(pathTempSaveFile);
                    }
                    using (MFormPDFViewer formPDFViewer = new MFormPDFViewer(resultExcelFile.FlexCelResult, pathTempSaveFile))
                    {
                        formPDFViewer.ShowDialog();
                        MT.Library.FileHelper.DeleteFile(pathTempSaveFile);
                    }
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
            if (overlaySplashScreenHandle != null)
            {
                CommonFnUI.CloseProgress(overlaySplashScreenHandle);
            }
        }

        /// <summary>
        /// Thực hiện xuất excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorkerExcel_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = CreateExcelFile(e.Argument as ConfigExcel);
        }
        
        /// <summary>
        /// Sau khi xuất excel xong
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorkerExcel_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                var resultExcelFile = e.Result as ResultExcelFile;
                if (resultExcelFile.FlexCelResult != null)
                {
                   

                    FolderBrowserDialog folderDlg = new FolderBrowserDialog();
                    folderDlg.ShowNewFolderButton = true;
                    DialogResult result = folderDlg.ShowDialog();
                    string path;
                    if (result == DialogResult.OK)
                    {
                        path = folderDlg.SelectedPath;
                        string sPath_Out_Excel = System.IO.Path.Combine(path, resultExcelFile.ReportData.FileName);
                        resultExcelFile.FlexCelResult.Save(sPath_Out_Excel);
                        MTLib.Utility.OpenFile(sPath_Out_Excel);
                    }
                }
                else
                {
                    MMessage.ShowError($"Đã có lỗi xảy ra trong quá trình xử lý.");
                }
            }
            else
            {
                MMessage.ShowError($"Đã có lỗi xảy ra trong quá trình xử lý: {e.Error.Message}.");
            }
            if (overlaySplashScreenHandle != null)
            {
                CommonFnUI.CloseProgress(overlaySplashScreenHandle);
            }
        }

        #endregion


        #region"Overrides"
        /// <summary>
        /// Custom lại thông tin config excel
        /// </summary>
        /// <param name="configExcel"></param>
        protected virtual void SetCustomConfigExcel(ConfigExcel configExcel)
        {
            //todo
            if (this.MySetCustomConfigExcel != null)
            {
                this.MySetCustomConfigExcel(configExcel);
            }
        }

        /// <summary>
        /// Lấy danh sách tham số trên form truyền vào store báo cáo
        /// </summary>
        protected virtual Dictionary<string, object> GetCustomParams(ConfigExcel configExcel)
        {
            Dictionary<string, object> dicData = new Dictionary<string, object>();
            if (dicControls != null)
            {
                foreach (var c in dicControls)
                {
                    CommonFnUI.BinddingValueIntoDictionary(ref dicData, c.Value);
                }
            }
            if (this.MyGetCustomParams != null)
            {
                this.MyGetCustomParams(configExcel, dicData);
            }
            return dicData;
        }


        private void chkConfigDefault_CheckedChanged(object sender, EventArgs e)
        {
            bool bChecked= chkConfigDefault.Checked;
            nbrRowHeight.SetReadOnly(bChecked);
            nbrFontSize.SetReadOnly(bChecked);
            nbrMarginRight.SetReadOnly(bChecked);
            nbrMarginLeft.SetReadOnly(bChecked);
            nbrMarginTop.SetReadOnly(bChecked);
            nbrMarginBottom.SetReadOnly(bChecked);
        }
        #endregion


    }
}
