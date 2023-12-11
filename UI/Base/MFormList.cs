using DevExpress.XtraGrid.Views.Base;
using FormUI.Base;
using MT.Library.BO;
using MT.Library.Extensions;
using MTControl;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using MT.Data.BO;
using DevExpress.XtraGrid.Views.Grid;

namespace FormUI
{
    public partial class MFormList : FormUI.FormUIBase
    {
        #region"Declare"

        /// <summary>
        /// Form chi tiết
        /// </summary>
        private FormUI.FormUIBase frmDetail;

        /// <summary>
        /// Xử lý nghiệp vụ load danh sách grid phân trang
        /// </summary>
        protected PagingList PagingList { get; set; }

        /// <summary>
        /// Xử lý các nghiệp vụ load danh sách tree phân trang
        /// </summary>
        protected PagingTreeList PagingTreeList { get; set; }

        /// <summary>
        /// Danh sách Detail của danh sách
        /// </summary>
        protected Dictionary<string,MGridControl> GrdDetails { get; set; }

        protected Dictionary<string, BackgroundWorker> BgWorkerDetails = new Dictionary<string, BackgroundWorker>();

        Guna.UI.WinForms.GunaContextMenuStrip gunaContextMenuStrip = new Guna.UI.WinForms.GunaContextMenuStrip();

        private Dictionary<string, ToolStripItem> _toolStripItems = new Dictionary<string, ToolStripItem>();

        public Dictionary<string, ToolStripItem> ToolStripItems
        {
            get
            {
                return _toolStripItems;
            }
        }

        /// <summary>
        /// Chỉ định control lưu thông tin tệp đính kèm
        /// </summary>
        public ucTepDinhKem ControlTepDinhKem { get; set; }
        #endregion

        #region"Contructor"
        public MFormList()
        {
            InitializeComponent();
            this.Text = string.Empty;
        }

        #endregion

        #region"Ovrrides"

        /// <summary>
        /// Thực hiện chức năng in
        /// </summary>
        protected void Print(object sender)
        {
            if (ConfigFormDetail.Grid == null)
            {
                return;
            }
            var currentData = ConfigFormDetail.Grid.GetRecordByRowSelected<object>();

            if (currentData == null)
            {
                return;
            }

            string keyFieldName = ConfigFormDetail.Grid.KeyName;
            var id = currentData.GetValue<object>(keyFieldName);

            ConfigExcel configExcel = new ConfigExcel();
            ConfigReport configReport = new ConfigReport();
            SetConfigBeforePrint(configExcel, configReport);
            if (configExcel.ParamsStore == null)
            {
                configExcel.ParamsStore = new Dictionary<string, object>();
            }
            if (!configExcel.ParamsStore.ContainsKey("Id"))
            {
                configExcel.ParamsStore.Add("Id", id);
            }
            
            using (MFormPrint mFormPrint = new MFormPrint(id, ConfigFormDetail.EntityName, configExcel, configReport))
            {
                mFormPrint.ShowDialog();
            }
        }


        /// <summary>
        /// Thiết lập config trước khi in
        /// </summary>
        /// <param name="configExcel">Config file excel</param>
        /// <param name="configReport">Config đối tượng thực hiện in</param>
        protected virtual void SetConfigBeforePrint(ConfigExcel configExcel, ConfigReport configReport)
        {
        }
        /// <summary>
        /// Hiển thị form chi tiết
        /// </summary>
        protected void ShowFormDetail(MTControl.FormAction formAction)
        {
            if (ConfigFormDetail==null)
            {
                throw new Exception("ConfigFormDetail chưa khai báo");
            }

            if (string.IsNullOrWhiteSpace(ConfigFormDetail.FormName))
            {
                throw new Exception($"ConfigFormDetail.FormName chưa khai báo");
            }

            if (string.IsNullOrWhiteSpace(ConfigFormDetail.EntityName))
            {
                throw new Exception($"ConfigFormDetail.EntityName chưa khai báo");
            }

            Type type = Type.GetType($"FormUI.{ConfigFormDetail.FormName},FormUI");
            if (type == null)
            {
                throw new Exception($"{ConfigFormDetail.FormName} not exists");
            }

            object currentData = null;
            this.frmDetail = (FormUI.FormUIBase)Activator.CreateInstance(type);
            this.frmDetail.FormAction = (int)formAction;
            this.frmDetail.EntityName = ConfigFormDetail.EntityName;
            this.frmDetail.ConfigFormDetail = this.ConfigFormDetail;
            this.frmDetail.ParentFrm = this;
            string keyFieldName = string.Empty;
            switch (formAction)
            {
                case MTControl.FormAction.Add:
                    break;
                case MTControl.FormAction.Duplicate:
                case MTControl.FormAction.View:
                case MTControl.FormAction.Edit:
                    if (IsFormTree())
                    {
                        MTreeView tv = ConfigFormDetail.Tree.GetMTreeControl();
                        keyFieldName=tv.KeyName;
                        currentData = ConfigFormDetail.Tree.GetDataByRowSelected<object>();
                    }
                    else
                    {
                        keyFieldName = ConfigFormDetail.Grid.KeyName;
                        currentData = ConfigFormDetail.Grid.GetRecordByRowSelected<object>();
                    }
                    this.frmDetail.FormId = currentData.GetValue<object>(keyFieldName);
                    break;
            }

            if (formAction == MTControl.FormAction.Edit)
            {
                //Kiểm tra phiếu/KH đã duyệt rồi thì không cho sửa
                if(ConfigFormDetail.Rep.CheckHasApproved(this.frmDetail.FormId, ConfigFormDetail.EntityName))
                {
                    MMessage.ShowWarning("Bạn không được phép sửa vì bản ghi đã được phê duyệt.");
                    return;
                }
            }

            this.frmDetail.ShowDialog();
        }

        /// <summary>
        /// Thực hiện ẩn hiện các button trên toolbar danh sách
        /// </summary>
        protected virtual void CustomSetEnableButtonOnToolbar(MToolbarList mToolbar, MBindingSource mBindingSource)
        {

        }

        /// <summary>
        /// Thực hiện xử lý sau khi lưu form chi tiết xong
        /// </summary>
        /// <param name="frm">Form thực hiện chức năng lưu</param>
        public virtual void CallbackAfterSaveDetail(FormUI.FormUIBase frm)
        {
            RefreshData();
        }

        /// <summary>
        /// Hàm kiểm tra form có phải dạng tree không
        /// </summary>
        /// <returns>=true: Form tree, ngược lại không</returns>
        private bool IsFormTree()
        {
            if (ConfigFormDetail.Tree != null)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Thực hiện chức năng xóa trên danh sách
        /// </summary>
        /// dvthang-11.04.2021
        private void DeleteData()
        {
            if (ConfigFormDetail.Rep == null)
            {
                throw new Exception($"Bạn chưa phải tạo {ConfigFormDetail.Rep}");
            }
            IList lstData = null;
            if (IsFormTree())
            {
                var treeControl = ConfigFormDetail.Tree.GetMTreeControl();
                lstData = new List<object>() { treeControl.GetDataByRowSelected<object>() };
            }
            else
            {
                lstData = ConfigFormDetail.Grid.GetListRecordByRowsSelected<object>();
            }
            
            if (lstData.Count > 0)
            {
                ResultData resultData= ConfigFormDetail.Rep.DeleteData(lstData);
                if (!string.IsNullOrWhiteSpace(resultData.UserMsg))
                {
                    MMessage.ShowWarning(resultData.UserMsg);
                }
                else
                {
                    RefreshData();                    
                }
            }
            else
            {
                MMessage.ShowWarning("Bạn phải chọn ít nhất một thông tin. Vui lòng kiểm tra lại.");
            }
        }
        #endregion

        #region"Sub/func"
        /// <summary>
        /// Khởi tạo các giá trị ban đầu của form
        /// </summary>
        private void Init()
        {
            if (ConfigFormDetail == null)
            {
                throw new Exception("ConfigFormDetail chưa khai báo");
            }

            if (GrdDetails != null)
            {
                foreach (var item in GrdDetails)
                {
                    var worker = new BackgroundWorker();
                    worker.DoWork -= workerDetail_DoWork;
                    worker.RunWorkerCompleted -= workerDetail_Completed;
                    worker.DoWork += workerDetail_DoWork;
                    worker.RunWorkerCompleted += workerDetail_Completed;
                    BgWorkerDetails.Add(item.Key, worker);
                }
            }
            if (IsFormTree())
            {
                PagingTreeList = new PagingTreeList(ConfigFormDetail.Tree)
                {
                    BaseRepository = ConfigFormDetail.Rep
                };
                PagingTreeList.LoadDataFinish = new EventHandler<EventLoadDataFinishArgs>(Grid_EventLoadDataFinish);
                ConfigFormDetail.Tree.GetMTbrPaging().SetPageSize(-1);
                ConfigFormDetail.Tree.GetMTreeControl().MouseClick -= Tree_MouseClick;
                ConfigFormDetail.Tree.GetMTreeControl().MouseClick += Tree_MouseClick;
            }
            else
            {
                PagingList = new PagingList(ConfigFormDetail.Grid)
                {
                    BaseRepository = ConfigFormDetail.Rep
                };

                PagingList.LoadDataFinish = new EventHandler<EventLoadDataFinishArgs>(Grid_EventLoadDataFinish);
                var grid = ConfigFormDetail.Grid.GetMGridControl();
                grid.FirstView.FocusedRowChanged -= FirstView_FocusedRowChanged;
                grid.FirstView.FocusedRowChanged += FirstView_FocusedRowChanged;
                grid.MouseClick -= Grid_MouseClick;
                grid.MouseClick += Grid_MouseClick; 
                grid.DoubleClick -= Grid_DoubleClick;
                grid.DoubleClick += Grid_DoubleClick;
                grid.UserCustomDrawCell -= FirstView_UserCustomDrawCell;
                grid.UserCustomDrawCell += FirstView_UserCustomDrawCell;

                grid.RowCellStyle -= FirstView_RowCellStyle;
                grid.RowCellStyle += FirstView_RowCellStyle;
            }

            //Đăng ký event cho toolbar
            if (ConfigFormDetail.MToolbarList!=null)
            {
                ConfigFormDetail.MToolbarList.MyEventHandler -= toolBar_ItemClick;
                ConfigFormDetail.MToolbarList.MyEventHandler += toolBar_ItemClick;

                if (ConfigFormDetail.MToolbarList.ButtonNames != null)
                {
                    foreach (var item in ConfigFormDetail.MToolbarList.ButtonNames)
                    {
                        var toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
                        toolStripMenuItem.Name = item.CommandName.ToString();
                        toolStripMenuItem.Tag = (int)item.CommandName;
                        toolStripMenuItem.Text = string.IsNullOrWhiteSpace(item.Caption) ? ConfigFormDetail.MToolbarList.GetCommandTextButtonItem(typeof(MCommandName), (int)item.CommandName) : item.Caption;
                        toolStripMenuItem.Image = ConfigFormDetail.MToolbarList.GetImageButton(item);
                        toolStripMenuItem.Click += ToolStripMenuItem_Click;
                        if (item.BeginGroup)
                        {
                            var toolStripMenuItemSeparator = new System.Windows.Forms.ToolStripSeparator();
                            gunaContextMenuStrip.Items.Add(toolStripMenuItemSeparator);

                        }
                        _toolStripItems.Add(item.CommandName.ToString() ,toolStripMenuItem);
                        gunaContextMenuStrip.Items.Add(toolStripMenuItem);
                    }
                }

                foreach (var item in ConfigFormDetail.MToolbarList.ButtonNames)
                {
                    SetEnableButtonOnToolbar(item.CommandName,false);
                }
            }

            
        }

        /// <summary>
        /// Event double click thì show form chi tiết
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Grid_DoubleClick(object sender, EventArgs e)
        {
            if (!CommonFnUI.CheckPermission(this.GetType().Name, MT.Library.Enummation.PermissionValue.ViewDetail))
            {
                MMessage.ShowWarning("Bạn không có quyền thực hiện chức năng này");
                return;
            }
            this.ShowFormDetail(MTControl.FormAction.View);
        }

        /// <summary>
        /// Custom lại nội dung hiển thị trên cell grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FirstView_UserCustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
        {
            MGridView mGridView=(MGridView)sender;
            GridMasterCustomDrawCell(mGridView, e);
        }

        /// <summary>
        /// Custom lại nội dung hiển thị trên cell grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FirstView_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            MGridView mGridView = (MGridView)sender;
            GridMasterCustomRowCellStyle(mGridView, e);
        }

        /// <summary>
        /// Hàm thực hiện custom cell của grid trên danh dách
        /// </summary>
        protected virtual void GridMasterCustomRowCellStyle(MGridView view, RowCellStyleEventArgs e)
        {
            //todo
        }

        /// <summary>
        /// Thực hiện  làm mới danh sách
        /// </summary>
        public  void RefreshData()
        {
            if (IsFormTree())
            {
                PagingTreeList.LoadData();
            }
            else
            {
                PagingList.LoadData();

            }
          
        }

        /// <summary>
        /// Xử lý sự kiện click và các item trên grid
        /// </summary>
        /// <param name="tag"></param>
        protected virtual void ProcessItemClick(int tag, object sender)
        {
            switch (tag)
            {
                case (int)MTControl.MCommandName.AddNew:
                    if (!CommonFnUI.CheckPermission(this.GetType().Name, MT.Library.Enummation.PermissionValue.Add))
                    {
                        MMessage.ShowWarning("Bạn không có quyền thực hiện chức năng này");
                        return;
                    }
                    this.ShowFormDetail(MTControl.FormAction.Add);
                    break;
                case (int)MTControl.MCommandName.Duplicate:
                    if (!CommonFnUI.CheckPermission(this.GetType().Name, MT.Library.Enummation.PermissionValue.Duplicate))
                    {
                        MMessage.ShowWarning("Bạn không có quyền thực hiện chức năng này");
                        return;
                    }
                    this.ShowFormDetail(MTControl.FormAction.Duplicate);
                    break;
                case (int)MTControl.MCommandName.View:
                    if (!CommonFnUI.CheckPermission(this.GetType().Name, MT.Library.Enummation.PermissionValue.ViewDetail))
                    {
                        MMessage.ShowWarning("Bạn không có quyền thực hiện chức năng này");
                        return;
                    }
                    this.ShowFormDetail(MTControl.FormAction.View);
                    break;
                case (int)MTControl.MCommandName.Edit:
                    if (!CommonFnUI.CheckPermission(this.GetType().Name, MT.Library.Enummation.PermissionValue.Edit))
                    {
                        MMessage.ShowWarning("Bạn không có quyền thực hiện chức năng này");
                        return;
                    }

                    //Kiểm tra nếu đối tượng là 1 KH/Phiếu mà trạng thái đã duyệt thì không cho sửa nữa

                    this.ShowFormDetail(MTControl.FormAction.Edit);
                    break;
                case (int)MTControl.MCommandName.Delete:
                    if (!CommonFnUI.CheckPermission(this.GetType().Name, MT.Library.Enummation.PermissionValue.Delete))
                    {
                        MMessage.ShowWarning("Bạn không có quyền thực hiện chức năng này");
                        return;
                    }
                    Action<string> dg = (s) =>
                    {
                        this.DeleteData();
                    };
                    MTControl.MMessage.ShowQuestion("Bạn có chắc chắn muốn xóa bản ghi đã chọn không?(Y/N)", dg);
                    break;
                case (int)MTControl.MCommandName.Refresh:
                    RefreshData();
                    break;

                case (int)MTControl.MCommandName.Help:
                    break;

                case (int)MTControl.MCommandName.Print:
                    if (!CommonFnUI.CheckPermission(this.GetType().Name, MT.Library.Enummation.PermissionValue.In))
                    {
                        MMessage.ShowWarning("Bạn không có quyền thực hiện chức năng này");
                        return;
                    }
                    Print(sender);
                    break;

                case (int)MTControl.MCommandName.Excel:
                    if (!CommonFnUI.CheckPermission(this.GetType().Name, MT.Library.Enummation.PermissionValue.Export))
                    {
                        MMessage.ShowWarning("Bạn không có quyền thực hiện chức năng này");
                        return;
                    }
                    ExportExcel(sender);
                    break;
            }
        }

        /// <summary>
        /// Thực hiện xuất excel cho màn hình danh sách
        /// </summary>
        private void ExportExcel(object sender)
        {
            if (IsFormTree())
            {
                if (ConfigFormDetail.Tree != null)
                {
                    PagingTreeList.ExportData();
                }
            }
            else
            {
                if (ConfigFormDetail.Grid != null)
                {
                    PagingList.ExportData();
                }
            }
        }
        #endregion
        #region"Overrides"

        /// <summary>
        /// Hàm thực hiện custom cell của grid trên danh dách
        /// </summary>
        protected virtual void GridMasterCustomDrawCell(MGridView view, RowCellCustomDrawEventArgs e)
        {
            //todo
        }


        /// <summary>
        /// Custom sự kiện focus vào row trên grid master
        /// </summary>
        /// <param name="gridVIew"></param>
        /// <param name="e"></param>
        protected virtual void CustomFocusedRowChangedOnGrdMaster(object masterId, MGridView gridVIew, FocusedRowChangedEventArgs e)
        {
            if (ControlTepDinhKem != null)
            {
                ControlTepDinhKem.TableName = this.ConfigFormDetail.EntityName;
                ControlTepDinhKem.FormAction = MTControl.FormAction.View;

                if (masterId != null)
                {
                    ControlTepDinhKem.RefId = (Guid)masterId;
                }
                else
                {
                    ControlTepDinhKem.RefId =Guid.Empty;
                }
                if (ControlTepDinhKem.IsLoaded)
                {
                    ControlTepDinhKem.LoadData();
                }
            }
            //todo
        }

        /// <summary>
        /// Custom lại hành đồng sau khi load xong detail theo id master
        /// </summary>
        /// <param name="gridControl"></param>
        /// <param name="data">Dữ liệu</param>
        protected virtual void CustomLoadFinishDetailByMaster(MGridControl gridControl,IList data)
        {
            //todo
        }

        /// <summary>
        /// Hàm thực hiện lấy về danh sách detail theo id của bản ghi master
        /// </summary>
        /// <param name="tableName">Tên bảng</param>
        /// <param name="masterId">Id của master</param>
        protected virtual IList GetDetailByMasterID(string tableName, object masterId)
        {
            if (GrdDetails == null || GrdDetails.Count == 0 || string.IsNullOrWhiteSpace(tableName))
            {
                return null;
            }
            string viewName = GrdDetails[tableName].ViewName;
            return this.ConfigFormDetail.Rep.GetDetailsByMasterID2(viewName, tableName, masterId);
        }

        /// <summary>
        /// Thực hiện cho phép và ko cho phép thao tác với button toolbar
        /// </summary>
        /// <param name="commandName">Tên hành đồng</param>
        /// <param name="isEnable">=true: Cho phép thao tác, ngược lại thì không</param>
        protected void SetEnableButtonOnToolbar(MTControl.MCommandName commandName,bool isEnable)
        {
            if (ConfigFormDetail.MToolbarList != null)
            {
                ConfigFormDetail.MToolbarList.SetEnable(commandName, isEnable);
            }

            if (_toolStripItems.ContainsKey(commandName.ToString()))
            {
                _toolStripItems[commandName.ToString()].Enabled = isEnable;
            }
        }
        #endregion

        #region"Event"

        /// <summary>
        /// Bắt event load dữ liệu thành công
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void Grid_EventLoadDataFinish(object sender, EventLoadDataFinishArgs e)
        {
            SetEnableButtonOnToolbar(MTControl.MCommandName.AddNew, true);
            SetEnableButtonOnToolbar(MTControl.MCommandName.Help, true);
            SetEnableButtonOnToolbar(MTControl.MCommandName.Refresh, true);
            object masterId = null;
            if (e.BinddingSource==null || e.BinddingSource.Count == 0)
            {
                SetEnableButtonOnToolbar(MTControl.MCommandName.Duplicate,false);
                SetEnableButtonOnToolbar(MTControl.MCommandName.Edit, false);
                SetEnableButtonOnToolbar(MTControl.MCommandName.View, false);
                SetEnableButtonOnToolbar(MTControl.MCommandName.Delete, false);
                SetEnableButtonOnToolbar(MTControl.MCommandName.Print, false);
                SetEnableButtonOnToolbar(MTControl.MCommandName.Excel, false);

            }
            else
            {
                SetEnableButtonOnToolbar(MTControl.MCommandName.Duplicate, true);
                SetEnableButtonOnToolbar(MTControl.MCommandName.Edit, true);
                SetEnableButtonOnToolbar(MTControl.MCommandName.View, true);
                SetEnableButtonOnToolbar(MTControl.MCommandName.Delete, true);
                SetEnableButtonOnToolbar(MTControl.MCommandName.Print, true);
                SetEnableButtonOnToolbar(MTControl.MCommandName.Excel, true);
                if (ConfigFormDetail.Grid != null)
                {
                    MGridControl grd = ConfigFormDetail.Grid.GetMGridControl();
                    string primaryKeyName = grd.KeyName;
                    if (string.IsNullOrWhiteSpace(primaryKeyName))
                    {
                        primaryKeyName = "Id";
                    }
                    masterId = grd.FirstView.GetFocusedRowCellValue(primaryKeyName);
                }
            }

            CustomSetEnableButtonOnToolbar(ConfigFormDetail.MToolbarList ,e.BinddingSource);

            if (BgWorkerDetails != null && BgWorkerDetails.Count > 0)
            {
                foreach (var item in BgWorkerDetails)
                {
                    if (!item.Value.IsBusy)
                    {
                        item.Value.RunWorkerAsync(new SelectionResult
                        {
                            TableName = item.Key,
                            MasterId = masterId
                        });
                    }
                }
            }
        }
        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem toolStripMenuItem = sender as ToolStripMenuItem;
            if (toolStripMenuItem.Tag != null)
            {
                ProcessItemClick((int)toolStripMenuItem.Tag, sender);
            }
        }

        /// <summary>
        /// Bắt event click vào row của gridcontrol
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FirstView_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            try
            {
                MGridView gridVIew = (sender as MGridView);
                MGridControl grd = ConfigFormDetail.Grid.GetMGridControl();
                string primaryKeyName = grd.KeyName;
                if (string.IsNullOrWhiteSpace(primaryKeyName))
                {
                    primaryKeyName = "Id";
                }
                object masterId = gridVIew.GetFocusedRowCellValue(primaryKeyName);
                CustomFocusedRowChangedOnGrdMaster(masterId, gridVIew, e);

                //Thực hiện load Detail
                if (masterId != null
                    && BgWorkerDetails != null)
                {
                    foreach (var item in BgWorkerDetails)
                    {
                        if (!item.Value.IsBusy)
                        {
                            item.Value.RunWorkerAsync(new SelectionResult
                            {
                                TableName = item.Key,
                                MasterId = masterId
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                MMessage.ShowError(ex.Message);
            }
        }


        /// <summary>
        /// Bắt event show form detail
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// Create by: dvthang:11.04.2021
        private void toolBar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (e.Item.Tag != null)
            {
                ProcessItemClick((int)e.Item.Tag,sender);
            }
        }

        /// <summary>
        /// Sự kiện load form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MFormList_Load(object sender, EventArgs e)
        {
            bool isDesignMode = DesignMode || (LicenseManager.UsageMode == LicenseUsageMode.Designtime);
            if (!isDesignMode)
            {
                this.Text = string.Empty;
                Init();
            }
        }

        /// <summary>
        /// Gọi hàm load data cho grid
        /// </summary>
        /// <param name="sender"></param>
        /// Create by: dvthang:04.03.2017
        private void workerDetail_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            SelectionResult selectionResult = e.Argument as SelectionResult;
            try
            {
                if(selectionResult.MasterId==null)
                {
                    e.Result = new ResultDetail
                    {
                        TableName = selectionResult?.TableName,
                        Data = null
                    };
                }
                else
                {
                    //todo
                    e.Result = new ResultDetail
                    {
                        TableName = selectionResult?.TableName,
                        Data = GetDetailByMasterID(selectionResult?.TableName,
                        selectionResult?.MasterId)
                    };
                }
            }
            finally
            {
                GrdDetails[selectionResult.TableName].Invoke(new Action(() =>
                {
                    GrdDetails[selectionResult.TableName].FirstView.HideLoadingPanel();
                }));
            }
            
        }

        /// <summary>
        /// Nạp data cho grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// Create by: dvthang:04.03.2017
        private void workerDetail_Completed(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                ResultDetail resultDetail = e.Result as ResultDetail;
                if (resultDetail == null)
                {
                    GrdDetails[resultDetail.TableName].DataSource=null;
                }
                else
                {
                    GrdDetails[resultDetail.TableName].DataSource=resultDetail.Data;

                    if (resultDetail.Data!=null && resultDetail.Data.Count > 0)
                    {
                        GrdDetails[resultDetail.TableName].FirstView.FocusedRowHandle = 0;
                        GrdDetails[resultDetail.TableName].FirstView.SelectRow(0);

                        CustomLoadFinishDetailByMaster(GrdDetails[resultDetail.TableName], resultDetail.Data);
                    }


                }
            }
            else
            {
                MMessage.ShowError(e.Error.Message);
            }
        }

        /// <summary>
        /// Click chuột phải vào thì hiển thị contextmenu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tree_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var tree = ConfigFormDetail.Tree.GetMTreeControl();
                gunaContextMenuStrip.Show(tree, new Point(e.X, e.Y));
            }
        }

        /// <summary>
        /// Click chuột phải vào thì hiển thị contextmenu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Grid_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var grid = ConfigFormDetail.Grid.GetMGridControl();
                gunaContextMenuStrip.Show(grid, new Point(e.X, e.Y));
            }
        }
        #endregion


    }
}
