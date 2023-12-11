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
using MTControl;
using FontAwesome.Sharp;
using FormUI.Base;
using MT.Data.Rep;
using MT.Library.BO;
using MT.Library;
using FormUI.Args;
using System.Collections;
using FormUI.Dictionary;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.Utils;
using System.Diagnostics;

namespace FormUI
{
    public partial class ucTepDinhKem : FormUIUserControl
    {
        public Guid? RefId { get; set; }

        public  string TableName { get; set; }

        public FormAction FormAction { get; set; }

        /// <summary>
        /// Đánh dấu là đã load dữ liệu
        /// </summary>
        public bool IsLoaded { get; set; }
        public ucTepDinhKem()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Khởi tạo thông tin grid
        /// </summary>
        private void InitGrid()
        {
            grid.TableName =typeof(TepDinhKem).Name;
            grid.SetReadOnly(false);
            grid.DisableFieldNames = "iSTT,sTen,sExtention,fSize,sGhiChu,dCreatedDate,sCreatedBy";
            grid.AddColumnText("iSTT", "STT", "Số thứ tự", 100);
            grid.AddColumnText("sTen", "Tên tệp", "Tên tệp đính kèm", 200);
            grid.AddColumnText("sExtention", "Định dạng", "Định dạng", 100);
            grid.AddColumnText("fSize", "Kích thước (Kb)", "Kích thước (Kb)", 100);
            grid.AddColumnText("sGhiChu", "Ghi chú", "Ghi chú", 300);
            grid.AddColumnText("dCreatedDate", "Ngày tạo", "Ngày tạo", 130);
            grid.AddColumnText("sCreatedBy", "Người tạo", "Người tạo", 180);
            var col = grid.AddColumnText("Id", "Hành động", 100, dataType: MTControl.DataTypeColumn.Button,
               fixedStyle: DevExpress.XtraGrid.Columns.FixedStyle.Right);

            grid.FirstView.MouseUp += FirstView_MouseUp;

            MRepositoryItemButtonEdit colsAction = (MRepositoryItemButtonEdit)col.ColumnEdit;
            colsAction.TextEditStyle = TextEditStyles.HideTextEditor;
            colsAction.Buttons.Clear();
            var linkDownLoad = new EditorButton(ButtonPredefines.Glyph, "Tải về", 80, true, true, false, null);
            linkDownLoad.Tag = "LinkDownLoad";
            linkDownLoad.Appearance.ForeColor = Color.White;
            linkDownLoad.AppearanceHovered.ForeColor = Color.Black;
            linkDownLoad.AppearancePressed.ForeColor = Color.Black;
            colsAction.Buttons.Add(linkDownLoad);

            var editorButton = new EditorButton(ButtonPredefines.Glyph, "Xóa", 80, true, true, false, null);
            editorButton.Tag = "Delete";
            editorButton.Appearance.ForeColor = Color.White;
            editorButton.AppearanceHovered.ForeColor = Color.Black;
            editorButton.AppearancePressed.ForeColor = Color.Black;
            colsAction.Buttons.Add(editorButton);
        }

        private void FirstView_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.grid.FirstView == null)
            {
                return;
            }
            GridViewInfo viewInfo = this.grid.FirstView.GetViewInfo() as GridViewInfo;
            GridHitInfo hitInfo = this.grid.FirstView.CalcHitInfo(e.Location);
            if (hitInfo.InRowCell)
            {

                GridCellInfo cell = viewInfo.GetGridCellInfo(hitInfo);
                if (cell == null || cell.Column == null || cell.Column.View == null) return;
                Point hitPoint = GetCellPoint(cell, e.Location);
                ButtonEditViewInfo buttonEditViewInfo = cell.ViewInfo as ButtonEditViewInfo;
                if (buttonEditViewInfo == null)
                {
                    return;
                }
                this.grid.FirstView.FocusedRowHandle = hitInfo.RowHandle;
                this.grid.FirstView.FocusedColumn = hitInfo.Column;
                DXMouseEventArgs.GetMouseArgs(e).Handled = true;

                DevExpress.XtraEditors.Drawing.EditorButtonObjectInfoArgs buttonInfoByPoint = buttonEditViewInfo.ButtonInfoByPoint(hitPoint);
                if (buttonInfoByPoint != null && buttonInfoByPoint.Button.Tag!=null)
                {
                    switch (buttonInfoByPoint.Button.Tag.ToString())
                    {
                        case "Delete":
                            btnDelete_Click(buttonInfoByPoint.Button, new EventArgs { });
                            break;
                        case "LinkDownLoad":
                            linkDownLoad_Click(buttonInfoByPoint.Button, new EventArgs { });
                            break;
                    }
                }
            }
        }

        protected Point GetCellPoint(object cellInfo, Point point)
        {
            GridCellInfo cell = cellInfo as GridCellInfo;
            if (cell != null) point.Offset(-cell.CellValueRect.X, -cell.CellValueRect.Y);
            return point;
        }

        /// <summary>
        /// Tải tệp đính kèm về máy
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkDownLoad_Click(object sender,EventArgs e)
        {
            try
            {
                var selectedRecord = this.grid.GetRecordByRowSelected<TepDinhKem>();
                byte[] binaryData = selectedRecord.byBinaryData;
                if (selectedRecord.byBinaryData == null || selectedRecord.byBinaryData.Length == 0)
                {
                    binaryData = DBContext.GetRep2<TepDinhKemRepository>().GetBinaryData(selectedRecord.Id);
                }
                if (binaryData?.Length > 0)
                {
                    FolderBrowserDialog folderDlg = new FolderBrowserDialog();
                    folderDlg.ShowNewFolderButton = true;
                    DialogResult result = folderDlg.ShowDialog();
                    string path;
                    if (result == DialogResult.OK)
                    {
                        path = folderDlg.SelectedPath;
                        string downloadPath = System.IO.Path.Combine(path, $"{selectedRecord.sTenGoc}");
                        System.IO.File.WriteAllBytes(downloadPath, binaryData);
                        MTLib.Utility.OpenFile(downloadPath);
                    }
                }
                else
                {
                    MMessage.ShowWarning("Tệp đính kèm không tồn tại");
                }
            }
            catch (Exception ex)
            {
                CommonFnUI.HandleException(ex);
            }

            
        }

       

        /// <summary>
        /// Thực hiện hành động thêm mới đính kèm vào grid
        /// </summary>
        /// <param name="sender"></param>
        private void btnAdd_Click(object sender,EventArgs e)
        {
            try
            {
                using(frmTepDinhKemDetail frm=new frmTepDinhKemDetail())
                {
                    
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        var getCurrentData = frm.GetCurrentData();
                        getCurrentData.sTableName = this.TableName;
                        getCurrentData.SortOrder = this.grid.FirstView.DataRowCount + 1;
                        getCurrentData.dCreatedDate = SysDateTime.Instance.Now();
                        getCurrentData.Id = Guid.NewGuid();
                        getCurrentData.sRefId = this.RefId.GetValueOrDefault();
                        if (this.FormAction == MTControl.FormAction.View)
                        {
                            var selectedRecord = grid.GetRecordByRowSelected<TepDinhKem>();
                            var result = DBContext.GetRep2<TepDinhKemRepository>().SaveData(getCurrentData);
                            if (result.Success)
                            {
                                LoadData();
                            }
                            else
                            {
                                MMessage.ShowError(result.UserMsg);
                            }
                        }
                        else
                        {
                            this.grid.AddRow();
                            var selectedRecord = this.grid.GetRecordByRowSelected<TepDinhKem>();
                            if (selectedRecord != null)
                            {
                                var now = SysDateTime.Instance.Now();
                                selectedRecord.sTen = getCurrentData.sTen;
                                selectedRecord.sTenGoc = getCurrentData.sTenGoc;
                                selectedRecord.sTableName = getCurrentData.sTableName;
                                selectedRecord.sRefId = getCurrentData.sRefId;
                                selectedRecord.fSize = getCurrentData.fSize;
                                selectedRecord.sExtention = getCurrentData.sExtention;
                                selectedRecord.byBinaryData = getCurrentData.byBinaryData;
                                selectedRecord.dCreatedDate =now;
                                selectedRecord.sCreatedBy = MT.Library.SessionData.UserName;
                                selectedRecord.iSTT = this.grid.FirstView.DataRowCount;
                                selectedRecord.SortOrder = this.grid.FirstView.DataRowCount;
                                selectedRecord.dCreatedDate = now;
                            }
                            UpdateSTT();
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                CommonFnUI.HandleException(ex);
            }
        }

        /// <summary>
        /// Thực hiện hành động xóa đính kèm trên grid
        /// </summary>
        /// <param name="sender"></param>
        private void btnDelete_Click(object sender,EventArgs e)
        {
            try
            {
                if (this.grid.FirstView.FocusedRowHandle >= 0)
                {
                    if (this.FormAction == MTControl.FormAction.View)
                    {
                        Action<string> dg = (s) =>
                        {
                            var selectedRecord = grid.GetRecordByRowSelected<TepDinhKem>();
                            var result = DBContext.GetRep2<TepDinhKemRepository>().DeleteData(new List<object> { selectedRecord });
                            if (result.Success)
                            {
                                this.grid.DeleteRow();
                                UpdateSTT();
                            }
                            else
                            {
                                MMessage.ShowError(result.UserMsg);
                            }
                        };
                        MTControl.MMessage.ShowQuestion("Bạn có chắc chắn muốn xóa bản ghi đã chọn không?(Y/N)", dg);
                        
                    }
                    else
                    {
                        this.grid.DeleteRow();
                        UpdateSTT();
                    }
                }
                else
                {
                    MMessage.ShowWarning("Bạn chưa chọn bản ghi để xóa");
                }
            }
            catch (Exception ex)
            {

                CommonFnUI.HandleException(ex);
            }
        }
        private void ucTepDinhKem_Load(object sender, EventArgs e)
        {
            bool isDesignMode = DesignMode ||(LicenseManager.UsageMode == LicenseUsageMode.Designtime);
            if (!isDesignMode)
            {
                InitGrid();
                LoadData();
            }
          
        }

        /// <summary>
        /// Bắt đầu load data
        /// </summary>
        public void LoadData()
        {
            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync(new ArgLoadTepDinhKem { sRefId=this.RefId.GetValueOrDefault(),sTableName=this.TableName});
            }
           
        }

        /// <summary>
        /// Cập nhật lại cột số thứ tự ở màn hình danh sách
        /// </summary>
        private void UpdateSTT()
        {
            var datas = grid.BindingListData;
            for (int i = 0; i < grid.BindingListData.Count; i++)
            {
                grid.SetValueCell(i, "iSTT", i + 1);
            }
        }

       /// <summary>
       /// wk_load dữ liệu
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            ArgLoadTepDinhKem argLoadTepDinhKem = (ArgLoadTepDinhKem)e.Argument;

            e.Result = DBContext.GetRep2<TepDinhKemRepository>().GetDataByRefId(argLoadTepDinhKem.sRefId, argLoadTepDinhKem.sTableName);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            IsLoaded = true;
            if (e.Error == null)
            {
                if (e.Result != null)
                {
                    foreach (TepDinhKem tepDinhKem in (IList)e.Result)
                    {
                        tepDinhKem.MTEntityState = Enummation.MTEntityState.None;
                    }
                    grid.LoadData((IList)e.Result);
                }
                else
                {
                    grid.LoadData(null);
                }
            }
            else
            {
                CommonFnUI.ShowError(e.Error, "Tệp đính kèm");
            }
            
        }

        /// <summary>
        /// Thực hiện nạp lại danh sách
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mSimpleButton1_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        /// <summary>
        /// Lấy danh sách dữ liệu thay đổi trên grid
        /// </summary>
        public IList GetDataChanges()
        {
            return this.grid.GetDataChanges();
        }
    }
}
