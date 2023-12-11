using DevExpress.XtraEditors.Repository;
using DevExpress.XtraPrinting.Native;
using DevExpress.XtraSplashScreen;
using FlexCel.XlsAdapter;
using FormUI.Base;
using MT.Data;
using MT.Data.BO;
using MT.Data.Rep;
using MT.Library.Extensions;
using MTControl;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormUI
{
    public partial class frmImportData : MXTraForm
    {
        public ImportDataType  ImportDataType { get; set; }

        IList _importDatas = null;

        IOverlaySplashScreenHandle _overlaySplashScreenHandle;

        List<ColumnMatchWhenImportExcel> columnMatchWhenImportExcels = null;

        bool _initColumnMatch = false;

        string pathResultImport = string.Empty;
        public frmImportData()
        {
            InitializeComponent();
            
        }

        /// <summary>
        /// Khởi tạo các giá trị trên form
        /// </summary>
        private void Init()
        {
            cboDataType.EnumData = "ImportDataType";
            btnPrevious.Enabled = false;
            btnNext.Enabled = false;
           
            if ((int)ImportDataType > 0)
            {
                cboDataType.SetSelectedIndex((int)ImportDataType);
                cboDataType.SetReadOnly(true);
            }
            richTextBoxB3.BackColor = Color.FromArgb(214,219,233);

            DBContext.ImportRepository = DBContext.GetImportRepByType(ImportDataType);
        }

        /// <summary>
        /// Khởi tạo grid matchColumn
        /// </summary>
        private void InitGridColumnMatch()
        {

            grdColumnMatch.ClearAllColumn();
            grdColumnMatch.IsEditable = true;
            grdColumnMatch.DisableFieldNames = "SourceDisplay,Description,Value";
            grdColumnMatch.TableName = "ColumnMatchWhenImportExcel";
            var col = grdColumnMatch.AddColumnText("SourceDisplay", "Trường trên tệp nguồn", "Trường trên tệp nguồn", 200, isFixWidth: true,
               fixedStyle: DevExpress.XtraGrid.Columns.FixedStyle.Left);
            col = grdColumnMatch.AddColumnText("Destination", "Trường trên phần mềm", "Trường trên phần mềm", 250, isFixWidth: true, dataType: DataTypeColumn.LookUpEdit);

            ImportDataType = (ImportDataType)cboDataType.GetValue();

            MRepositoryItemLookUpEdit colsDestination = (MRepositoryItemLookUpEdit)col.ColumnEdit;
            colsDestination.AddColumn("Description", "Tên trường", 200);
            colsDestination.DataSource = DBContext.ImportRepository.GetConfigImportMapping(ImportDataType.ToString());
            colsDestination.DisplayMember = "Description";
            colsDestination.ValueMember = "FieldName";

            col = grdColumnMatch.AddColumnText("Description", "Diễn giải", "Diễn giải", 300);
            col = grdColumnMatch.AddColumnText("Value", "Dữ liệu mẫu trên tệp", "Dữ liệu mẫu trên tệp", 250, isFixWidth: true,
                 fixedStyle: DevExpress.XtraGrid.Columns.FixedStyle.Right);            
            grdCheckData.TableName = ImportDataType.ToString();

        }

        /// <summary>
        /// Thực hiện download mẫu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDownload_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = true;
            DialogResult result = folderDlg.ShowDialog();
            string path;
            if (result == DialogResult.OK)
            {
                path = folderDlg.SelectedPath;

                ImportDataType = (ImportDataType)cboDataType.GetValue();

                string templatepath = $@"Template\Import\{ImportDataType.ToString()}.xls";


                if (System.IO.File.Exists(templatepath))
                {
                    string downloadPath = System.IO.Path.Combine(path,$"{ImportDataType.ToString()}.xls");
                    System.IO.File.Copy(templatepath, downloadPath,true);

                    MTLib.Utility.OpenFile(downloadPath);
                }
               
            }
        }

        /// <summary>
        /// Thực hiện upload file excel lên
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSourcePath_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.InitialDirectory = "c:\\";
                    openFileDialog.Filter = "Excel Files(.xls)|*.xls|Excel Files(.xlsx)|*.xlsx";
                    openFileDialog.FilterIndex = 2;
                    openFileDialog.RestoreDirectory = true;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = openFileDialog.FileName;
                        txtBrowserFile.Text = filePath;

                        DBContext.ImportRepository.OpenXlsFile(filePath);

                        if (!DBContext.ImportRepository.ValidFile())
                        {
                            MMessage.ShowWarning("Định dạng tệp không đúng.");
                            return;
                        }

                        SetSheets();

                        btnNext.Enabled = true;

                    }
                }
            }
            catch (Exception ex)
            {
                CommonFnUI.HandleException(ex);
            }
        }

        /// <summary>
        /// Đọc số sheet của file
        /// </summary>
       
        void SetSheets()
        {
            List<string> sheetNames = DBContext.ImportRepository.GetSheetsName();
            
            cboSheet.Properties.DataSource = sheetNames;

            if (sheetNames.Count > 0)
            {
                cboSheet.EditValue = sheetNames.FirstOrDefault();
            }
        }


        private void frmImportData_Load(object sender, EventArgs e)
        {
            Init();
            nbrRowPosition.Value = 1;
            rdoImportType.EditValue = 1;
            ShowOrHideResultImport(false);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (cboDataType.EditValue == null)
            {
                MMessage.ShowWarning("Loại dữ liệu nhập khẩu không được bỏ trống.");
                return;
            }
            
            if (!DBContext.ImportRepository.ValidFile())
            {
                MMessage.ShowWarning("Định dạng tệp không đúng.");
                return;
            }
            ImportDataType = (ImportDataType)cboDataType.GetValue();
            if (tabControl.SelectedTabPageIndex< tabControl.TabPages.Count)
            {
                DBContext.ImportRepository.SetConfig(new ArgumentImport
                {
                    TableName = ImportDataType.ToString(),
                    ActiveSheet = cboSheet.ItemIndex + 1,
                    AddNew = int.Parse(rdoImportType.EditValue.ToString())==1?true:false,
                    RowPosition = int.Parse(nbrRowPosition.Value.ToString()),
                });
                tabControl.SelectedTabPageIndex ++;
                progressBarExeImport.Hide();
                switch (tabControl.SelectedTabPageIndex)
                {
                    case 1:
                        if (_initColumnMatch == false)
                        {
                            InitGridColumnMatch();
                            //Thực hiện ghép cột tự động
                            columnMatchWhenImportExcels = DBContext.ImportRepository.ColumnMatch();
                            //Binding source trên grid
                            grdColumnMatch.DataSource = columnMatchWhenImportExcels;

                            _initColumnMatch = true;
                        }
                        break;
                    case 2:
                        CheckData();
                        break;
                    case 3:
                        NextImportDB();
                        break;
                }
                btnPrevious.Enabled = true;
            }
            if (tabControl.SelectedTabPageIndex == tabControl.TabPages.Count-1)
            {
                btnNext.Enabled = false;
            }
        }

        /// <summary>
        /// B3. Kiểm tra dữ liệu
        /// </summary>
        private void CheckData()
        {
            
            grdCheckData.ClearAllColumn();
            foreach (var item in columnMatchWhenImportExcels)
            {
                string fieldName = item.Destination;
                DevExpress.XtraGrid.Columns.FixedStyle fixedStyle = DevExpress.XtraGrid.Columns.FixedStyle.None;
                if (item.IsLock)
                {
                    fixedStyle = DevExpress.XtraGrid.Columns.FixedStyle.Left;
                }
                switch (item.DataType)
                {
                    case (int)MT.Library.Enummation.DataType.Guid:
                        fieldName = $"{item.Destination}_Ten";
                        break;
                }
                var col = grdCheckData.AddColumnText(fieldName, item.Description,
                   item.SourceDisplay, width: item.Width, fixedStyle: fixedStyle);
            }
            grdCheckData.SetMutiSelectRows(true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect);
            var col2=grdCheckData.AddColumnText("ImportError", "Tình trạng",
                   "Tình trạng", width: 300, fixedStyle: DevExpress.XtraGrid.Columns.FixedStyle.Right);

            RepositoryItemMemoEdit repositoryItemMemoEdit = new RepositoryItemMemoEdit();
            repositoryItemMemoEdit.WordWrap = true;
            col2.ColumnEdit = repositoryItemMemoEdit;

            grdCheckData.FirstView.OptionsView.RowAutoHeight = true;

            _importDatas = DBContext.ImportRepository.ReadData();
            btnNext.Enabled = true;
            if (_importDatas?.Count==0 || AnyDataInValid())
            {
                btnNext.Enabled = false;
            }

            SetStatusData();

            grdCheckData.DataSource = _importDatas;
        }

        /// <summary>
        /// Cập nhật trạng thái của dữ liệu
        /// </summary>
        void SetStatusData()
        {
            int countInvalid = 0;
            foreach (var item in _importDatas)
            {
                if (!item.GetValue<bool>("ImportValid"))
                {
                    countInvalid++;
                }
            }

            string formatCountInValid = countInvalid > 0 ? MT.Library.Utility.FormatValue(countInvalid) : "0";
            string formatCountValid = (_importDatas.Count - countInvalid) > 0 ? MT.Library.Utility.FormatValue((_importDatas.Count - countInvalid)) : "0";

            lblValid.Text = $"{formatCountValid}/{MT.Library.Utility.FormatValue(_importDatas.Count)} dòng dữ liệu hợp lệ.";

            lblInvalid.Text = $"{formatCountInValid}/{MT.Library.Utility.FormatValue(_importDatas.Count)} dòng dữ liệu không hợp lệ.";
        }

        /// <summary>
        /// Kiểm tra bản ghi có bị invalid không
        /// </summary>
        /// <returns></returns>
        bool AnyDataInValid()
        {
            if (_importDatas == null || _importDatas.Count == 0)
            {
                return true;
            }
            foreach (var item in _importDatas)
            {
                if (!item.GetValue<bool>("ImportValid"))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// B4. Chuyển sang bước 4 để import vào databse
        /// </summary>
        private void NextImportDB()
        {
            if (AnyDataInValid())
            {
                MMessage.ShowWarning("Dữ liệu tệp nhập khẩu đang có lỗi. Bạn vui lòng sửa hết lỗi trước khi thực hiện tiếp.");
                return;
            }

            if (!bgExecuteImport.IsBusy)
            {
                progressBarExeImport.Show();
                _overlaySplashScreenHandle =CommonFnUI.ShowProgress(this);
                bgExecuteImport.RunWorkerAsync();
            }

        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (tabControl.SelectedTabPageIndex >0)
            {
                tabControl.SelectedTabPageIndex--;
                btnNext.Enabled = true;
            }

            if (tabControl.SelectedTabPageIndex == 0)
            {
                btnPrevious.Enabled = false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bgExecuteImport_DoWork(object sender, DoWorkEventArgs e)
        {
            foreach (var item in _importDatas)
            {
                DBContext.ImportRepository.UpdateMoreData(item);
            }

            var importResult = DBContext.ImportRepository.ExecuteDB(_importDatas);

            e.Result = importResult;
        }

        private void bgExecuteImport_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBarExeImport.Hide();
            if (_overlaySplashScreenHandle != null)
            {
                CommonFnUI.CloseProgress(_overlaySplashScreenHandle);
            }
            ImportResult importResult = e.Result as ImportResult;

            if (e.Error == null)
            {
                if (!string.IsNullOrWhiteSpace(importResult.ErrorMessage))
                {
                    lblAddSuccess.Text = $"0/{ MT.Library.Utility.FormatValue(importResult.Total)} được thêm mới thành công";

                    lblUpdateSuccess.Text = $"0/{ MT.Library.Utility.FormatValue(importResult.Total)} được cập nhật thành công";
                    CommonFnUI.ShowError(new Exception(importResult.ErrorMessage), "Nhập khẩu");

                    return;
                }

                string formatAddNewSuccess = importResult.TotalAddNewSuccess > 0 ? MT.Library.Utility.FormatValue(importResult.TotalAddNewSuccess) : "0";
                string formatUpdateSuccess = importResult.TotalUpdateSuccess > 0 ? MT.Library.Utility.FormatValue(importResult.TotalUpdateSuccess) : "0";
                lblAddSuccess.Text = $"{formatAddNewSuccess }/{ MT.Library.Utility.FormatValue(importResult.Total)} được thêm mới thành công";

                lblUpdateSuccess.Text = $"{formatUpdateSuccess}/{ MT.Library.Utility.FormatValue(importResult.Total)} được cập nhật thành công";
            }
            else
            {
                lblAddSuccess.Text = $"0/{ MT.Library.Utility.FormatValue(importResult.Total)} được thêm mới thành công";

                lblUpdateSuccess.Text = $"0/{ MT.Library.Utility.FormatValue(importResult.Total)} được cập nhật thành công";
                CommonFnUI.ShowError(e.Error, "Nhập khẩu");
            }
            pathResultImport = importResult.PathResultImport;

            ShowOrHideResultImport(true);
        }

        /// <summary>
        /// Ẩn hiện file kết quả nhập khẩu
        /// </summary>
        private void ShowOrHideResultImport(bool isShow)
        {
            lblResultImport.Visible = isShow;
            btnViewResultImport.Visible = isShow;
        }

        private void btnEditFile_Click(object sender, EventArgs e)
        {
            string templatepath = txtBrowserFile.Text;
            if (string.IsNullOrWhiteSpace(templatepath))
            {
                MMessage.ShowInfor("Vui lòng quay lại bước 1 chọn tệp dữ liệu trước khi thực hiện chức năng này.");

                return;
            }
            if (System.IO.File.Exists(templatepath))
            {
                MTLib.Utility.OpenFile(templatepath);
            }
        }

        private void btnCheckData_Click(object sender, EventArgs e)
        {
            try
            {
                DBContext.ImportRepository.OpenXlsFile(txtBrowserFile.Text);
                CheckData();
            }
            catch (Exception ex)
            {
                CommonFnUI.ShowError(ex, "Nhập khẩu-Kiểm tra lại dữ liệu");
            }
        }

        private void tabControl_SelectedPageChanging(object sender, DevExpress.XtraTab.TabPageChangingEventArgs e)
        {
            if (e.PrevPage == tabSelectFile)
            {
                if (string.IsNullOrWhiteSpace(txtBrowserFile.Text))
                {
                    e.Cancel = true;
                    MMessage.ShowWarning("Bạn vui lòng chọn đường dẫn tệp dữ liệu nguồn.");
                    return;
                }

                if (cboSheet.EditValue==null)
                {
                    e.Cancel = true;
                    MMessage.ShowWarning("Bạn vui lòng chọn sheet nhập khẩu trên tệp dữ liệu nguồn.");
                    return;
                }

                if (nbrRowPosition.EditValue == null ||int.Parse(nbrRowPosition.EditValue.ToString())<=0)
                {
                    e.Cancel = true;
                    MMessage.ShowWarning("Bạn vui lòng nhập vị trí dòng làm tiêu đề cột trên tệp dữ liệu nguồn.");
                    return;
                }
            }
            if (e.PrevPage == tabMerge)
            {
                //1. Kiểm đã có ghép cột chưa
                if (columnMatchWhenImportExcels == null || columnMatchWhenImportExcels.Count == 0)
                {
                    e.Cancel = true;
                    MMessage.ShowWarning("Bạn chưa thiết lập ghép cột trên tệp dữ liệu nguồn với cột trên phần mềm.");
                    
                    return;
                }
                //2. Kiểm tra xem có thông tin nào chưa được ghép không
                foreach (var item in columnMatchWhenImportExcels)
                {
                    if (string.IsNullOrWhiteSpace(item.Destination))
                    {
                        e.Cancel = true;
                        MMessage.ShowWarning($"Bạn chưa thiết lập ghép cột <{item.SourceDisplay}> trên tệp dữ liệu nguồn với cột trên phần mềm.");
                        return;
                    }
                }

                //3. Kiểm tra có thông tin nào bị ghep trùng không
                var results = from p in columnMatchWhenImportExcels
                              group p by p.Destination into g
                              select new { Destination = g.Key, Info = g };

                foreach (var item in results)
                {
                    if (item.Info.Count() > 1)
                    {
                        e.Cancel = true;
                        MMessage.ShowWarning($"Cột <{item.Info.FirstOrDefault().SourceDisplay}> trên tệp dữ liệu nguồn bị ghép trùng với cột trên phần mềm.");
                        return;
                    }
                }

            }
        }

        private void cboDataType_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (e.OldValue != e.NewValue)
            {
                _initColumnMatch = false;
            }
        }

        private void btnViewResultImport_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(pathResultImport))
            {
                MTLib.Utility.OpenFile(pathResultImport);
            }
        }
    }
}
