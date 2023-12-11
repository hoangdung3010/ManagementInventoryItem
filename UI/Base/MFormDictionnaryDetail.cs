using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSplashScreen;
using MT.Data.BO;
using MT.Data.Rep;
using MT.Library;
using MT.Library.BO;
using MT.Library.Extensions;
using MTControl;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
namespace FormUI
{
    public partial class MFormDictionnaryDetail : FormUI.FormUIBase
    {
        #region"Declare"
        private const string MSC_MTEntityState ="MTEntityState";
        //Có show toolbar hay không, mặc định là show
        private bool isShowToolbar = false;


        public bool IsShowToolbar
        {
            get { return isShowToolbar; }
            set { isShowToolbar = value; }
        }

        //Tiêu đề form
        private string titleForm;

        public string TitleForm
        {
            get { return titleForm; }
            set { titleForm = value; }
        }

        /// <summary>
        /// Vùng chứa tất cả các control trên form
        /// </summary>
        private Control controlRoot;

        public Control ControlRoot
        {
            get { return controlRoot; }
            set { controlRoot = value; }
        }

        private Dictionary<string, IEditControl> dicControls;

        public Dictionary<string, IEditControl> DicControls
        {
            get { return dicControls; }
            set { dicControls = value; }
        }

        private MDxValidationProvider ValidationProvider = null;

        /// <summary>
        /// Dữ liệu hiện tại của form master
        /// </summary>
        private BaseEntity currentData;

        public BaseEntity CurrentData
        {
            get { return currentData; }
            set { currentData = value; }
        }

        /// <summary>
        /// Dữ liệu gần nhất trên form
        /// </summary>
        private BaseEntity lastestData;
        public BaseEntity LastestData
        {
            get { return lastestData; }
            set { lastestData = value; }
        }


        /// <summary>
        /// Danh sách dữ liệu của detail
        /// </summary>
        private IList lstDetail;

        public IList LstDetail
        {
            get { return lstDetail; }
            set { lstDetail = value; }
        }

        /// <summary>
        /// Danh sách các grid chi tiết
        /// </summary>
        private Dictionary<string, MGridEditable> grdDetails;

        public Dictionary<string, MGridEditable> GrdDetails
        {
            get { return grdDetails; }
            set { grdDetails = value; }
        }

        protected object OldId { get; set; }

        //Bắt sự kiện khi cất load lại 1 số thông tin form danh sách trên form
        private System.EventHandler myEventHandlerReloadGrid;

        public System.EventHandler MyEventHandlerReloadGrid
        {
            get { return myEventHandlerReloadGrid; }
            set { myEventHandlerReloadGrid = value; }
        }

        /// <summary>
        /// Đánh là form có cất và thêm luôn không
        /// </summary>
        private bool isSaveNew = false;

        /// <summary>
        /// Mặc định form luôn được khởi tạo tham số hàm event Load
        /// Có những form đặc biệt sẽ không tự khởi tạo mà sẽ gọi hàm khởi tạo dưới form kế thừa
        /// </summary>
        private bool isInitForm = true;

        public bool IsInitForm
        {
            get { return isInitForm; }
            set { isInitForm = value; }
        }

        public bool IsShowMaximize { get; set; } = false;

        public Dictionary<string, BackgroundWorker> BgWorkers = new Dictionary<string, BackgroundWorker>();

        #endregion

        #region"Contructor"
        public MFormDictionnaryDetail()
            : base()
        {

            InitializeComponent();
            dicControls = new Dictionary<string, IEditControl>();
            ValidationProvider = new MDxValidationProvider();

            if (!string.IsNullOrEmpty(TitleForm))
            {
                this.Text = this.TitleForm;
            }
            //Khởi tạo danh sách Detail
            this.LstDetail = new List<BaseEntity>();

            tableLayoutPanelBottom.AutoSize = false;
            tableLayoutPanelBottom.Height = 32;

            if (IsShowMaximize)
            {
                iconPictureBoxMaximize.IconChar = FontAwesome.Sharp.IconChar.WindowMaximize;
            }

            this.Text = string.Empty;
        }

        #endregion

        #region"Sub/Func"

        /// <summary>
        /// Thiết lập dữ liệu gần nhất lưu trên form
        /// </summary>
        void SetDuLieuGanNhat()
        {
            try
            {
                DuLieuGanNhatTrenForm duLieuGanNhatTrenForm = DBContext.GetRep2<DuLieuGanNhatTrenFormRepository>()
                                                                                    .GetNhatTrenForm(this.EntityName);

                if (duLieuGanNhatTrenForm != null)
                {
                    object data = MT.Library.Utility.DeserializeObject(duLieuGanNhatTrenForm.sFormData, this.currentData.GetType());

                    var pInfos = data.GetType().GetProperties(BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance).Where(p => p.GetIndexParameters().Length == 0);
                    foreach (var item in pInfos)
                    {
                        this.currentData.SetValue(item.Name, data.GetValue<object>(item.Name));
                    }
                }
            }
            catch
            {
            }
        }


        /// <summary>
        /// bindding data cho các control trên form
        /// </summary>
        /// Create by: dvthang:05.03.3017
        private void BindDataToForm(List<string> ignoreColumnBindding = null)
        {
            try
            {

                if (!string.IsNullOrEmpty(this.EntityName))
                {
                    switch (this.FormAction)
                    {
                        case (int)MTControl.FormAction.Add:
                            if (!string.IsNullOrWhiteSpace(ConfigFormDetail.Title))
                            {
                                lblTitleFormDetail.Text = $"Thêm mới {ConfigFormDetail.Title}";
                            }
                           
                            this.currentData = (BaseEntity)CommonFnUI.GetInstance(this.EntityName);

                            SetDuLieuGanNhat();

                            if (this.currentData != null &&  !this.currentData.HasIdentity())
                            {
                                this.currentData.SetIdentity(Guid.NewGuid());
                            }
                            if (this.GrdDetails != null)
                            {
                                foreach (var pair in this.GrdDetails)
                                {
                                    if (pair.Value != null)
                                    {
                                        pair.Value.GrdDetail.LoadData(null);

                                        if (pair.Value.GrdDetail.FirstView.DataRowCount == 0)
                                        {
                                            pair.Value.GrdDetail.AddRow();
                                        }
                                    }
                                }
                            }

                            this.ConfigFormDetail.Rep.SetCodeNew(this.currentData);
                            break;
                        case (int)MTControl.FormAction.Edit:
                            
                        case (int)MTControl.FormAction.View:
                            this.currentData = this.GetDataById(this.FormId);

                            if(this.FormAction== (int)MTControl.FormAction.Edit)
                            {
                                if (!string.IsNullOrWhiteSpace(ConfigFormDetail.Title))
                                {
                                    lblTitleFormDetail.Text = $"Sửa {ConfigFormDetail.Title}";
                                }
                            }
                            else
                            {
                                if (!string.IsNullOrWhiteSpace(ConfigFormDetail.Title))
                                {
                                    lblTitleFormDetail.Text = $"Xem {ConfigFormDetail.Title}";
                                }
                            }

                            if (this.GrdDetails != null)
                            {
                                foreach (var pair in this.GrdDetails)
                                {
                                    if (!BgWorkers[pair.Key].IsBusy)
                                    {
                                        BgWorkers[pair.Key].RunWorkerAsync(pair.Key);
                                    }
                                }
                            }
                            break;
                        case (int)MTControl.FormAction.Duplicate:
                            if (!string.IsNullOrWhiteSpace(ConfigFormDetail.Title))
                            {
                                lblTitleFormDetail.Text = $"Thêm mới {ConfigFormDetail.Title}";
                            }
                            this.currentData = this.GetDataById(this.FormId);
                            if (this.currentData!=null && !this.currentData.HasIdentity())
                            {
                                this.currentData.SetIdentity(Guid.NewGuid());
                            }

                            this.ConfigFormDetail.Rep.SetCodeNew(this.currentData);

                            //Lấy data cho danh sách detail
                            if (this.GrdDetails != null)
                            {
                                foreach (var pair in this.GrdDetails)
                                {
                                    IList lstData = this.GetDetailByMasterID(pair.Key, this.FormId);
                                    if (lstData != null && lstData.Count > 0)
                                    {
                                        foreach (var item in lstData)
                                        {
                                            BaseEntity baseEntity = (BaseEntity)item;
                                            if (this.FormAction == (int)MTControl.FormAction.Duplicate)
                                            {
                                                baseEntity.SetIdentity(Guid.NewGuid());
                                                baseEntity.MTEntityState =(Enummation.MTEntityState)MTControl.FormAction.Add;
                                            }
                                        }
                                    }
                                    if (pair.Value != null)
                                    {
                                        pair.Value.GrdDetail.LoadData(lstData);
                                    }
                                }

                            }
                            break;
                    }
                    if (this.currentData != null)
                    {
                        this.currentData.SetValue(MSC_MTEntityState, (int)this.FormAction);
                        this.currentData = PrepareDataBeforeBindDataForm();
                        if (this.IsQuickAdd)
                        {
                            btnSaveNew.Visible = false;
                        }
                      
                        CommonFnUI.BinddingValueIntoControl(this.currentData, dicControls,
                            dicDetails:null,ignoreColumnBindding: ignoreColumnBindding);
                        this.BindingDataIntoFormSucces();
                    }
                }
            }
            catch (Exception ex)
            {
                CommonFnUI.HandleException(ex);
            }
        }

        /// <summary>
        /// Gán thêm 1 số giá trị mặc định cho form trước khi bindding
        /// </summary>
        /// Create by: dvthang:12.03.2017
        protected virtual BaseEntity PrepareDataBeforeBindDataForm()
        {
            var gridMLookup = this.ControlCallForm as MLookUpEdit;
            if (gridMLookup != null && gridMLookup.Grid != null && gridMLookup.Grid.FirstView.FocusedColumn!=null)
            {
                Form form = gridMLookup.FindForm();
                //form thêm nhanh từ grid chi tiết
                switch (gridMLookup.Grid.FirstView.FocusedColumn.FieldName)
                {
                    case "sDM_SanPham_Id":
                        Dictionary<string, object> dicDataDefault=new Dictionary<string, object>();
                        if (form is MFormDictionnaryDetail)
                        {
                            dicDataDefault = ((MFormDictionnaryDetail)form).SetDefaultValueFormQuickAdd();
                        }
                        else if(form is MFormBusinessDetail)
                        {
                            dicDataDefault = ((MFormBusinessDetail)form).SetDefaultValueFormQuickAdd();
                           
                        }

                        foreach (var item in dicDataDefault)
                        {
                            this.currentData.SetValue("sDM_NhaCC_Id", item.Value);
                        }
                        break;
                    case "sDM_DonViTinh_Id":
                        break;
                    case "sDM_PhuKien_Id":
                        
                        if (dicControls.ContainsKey("sDM_SanPham_Id"))
                        {
                            this.currentData.SetValue("sDM_SanPham_Id", 
                                gridMLookup.Grid.FirstView.GetRowCellValue(gridMLookup.Grid.FirstView.FocusedRowHandle, "sDM_SanPham_Id"));
                            CommonFnUI.SetReaOnlyForControlByFormAction(true, new Dictionary<string, IEditControl> { { "sDM_SanPham_Id", dicControls["sDM_SanPham_Id"] } });
                        }
                        break;
                }
            }
            else
            {
                var gridTreeMLookup = this.ControlCallForm as MTreeLookUpEdit;
                if (gridTreeMLookup != null && gridTreeMLookup.Grid != null && gridTreeMLookup.Grid.FirstView.FocusedColumn!=null)
                {
                    //form thêm nhanh từ grid chi tiết
                    switch (gridTreeMLookup.Grid.FirstView.FocusedColumn.FieldName)
                    {
                        case "sDM_DonVi_Id_DonViNhap":
                            var objValue = gridTreeMLookup.Grid.FirstView.GetRowCellValue(gridTreeMLookup.Grid.FirstView.FocusedRowHandle, gridTreeMLookup.Grid.FirstView.FocusedColumn);
                            
                            if(objValue==null || Guid.Empty.ToString().Equals(objValue.ToString()))
                            {
                                this.currentData.SetValue("sParentId", MT.Library.SessionData.OrganizationUnitId);
                            }
                            else
                            {
                                this.currentData.SetValue("sParentId", objValue);
                            }
                           
                            if (dicControls.ContainsKey("sParentId"))
                            {
                                CommonFnUI.SetReaOnlyForControlByFormAction(true, new Dictionary<string, IEditControl> { { "sParentId", dicControls["sParentId"] } });
                            }
                            break;
                    }
                }

            }

            return this.currentData;
        }

        /// <summary>
        /// Gán giá trị control trên form cho object
        /// </summary>
        private BaseEntity BindingValueIntoObject(ref object masterID)
        {
            if (dicControls != null)
            {
                foreach (var c in dicControls)
                {
                    CommonFnUI.BinddingValueIntoObject(this.currentData,c.Value);
                }
                switch (this.FormAction)
                {
                    case (int)MTControl.FormAction.Add:
                    case (int)MTControl.FormAction.Edit:
                    case (int)MTControl.FormAction.View:
                    case (int)MTControl.FormAction.Delete:
                        this.currentData.SetValue("MTEntityState",(int)this.FormAction);
                        break;
                    case (int)MTControl.FormAction.Duplicate:
                        this.currentData.SetValue("MTEntityState", (int)MTControl.FormAction.Add);
                        break;
                }
            }
            return this.currentData;
        }
        #endregion

        #region"Ovrrides"
        /// <summary>
        /// Nạp giá trị cho form thành công
        /// </summary>
        /// Create by: dvthang:12.03.2017
        protected virtual void BindingDataIntoFormSucces()
        {
        }
        /// <summary>
        /// Bắt đầu gọi lên BL để cất Data
        /// </summary>
        /// <returns></returns>
        protected virtual ResultData SubmitData(BaseEntity entity)
        {
            return this.ConfigFormDetail.Rep.SaveData(entity);
        }

        /// <summary>
        /// Trả về objec theo Id của master
        /// </summary>
        /// Create by: dvthang:05.03.2017
        public virtual BaseEntity GetDataById(object id)
        {
            return this.ConfigFormDetail.Rep.GetDataById(id);
        }

        
        /// <summary>
        /// Cất các thông tin trên form
        /// </summary>
        /// Create by: dvthang:05.03.2017
        /// EditBy: truongnm:12.08.2018
        public virtual void SaveData(object sender, EventArgs e)
        {
            try
            {
                bool isValid = CommonFnUI.IsValidAll(ValidationProvider, dicControls);

                if (isValid)
                {
                    if (this.GrdDetails != null)
                    {
                        foreach (var pair in this.GrdDetails)
                        {
                            if (pair.Value.GrdDetail.FirstView.DataRowCount > 0)
                            {
                                for (int i = 0; i < pair.Value.GrdDetail.FirstView.DataRowCount; i++)
                                {
                                    if (!pair.Value.GrdDetail.FirstView.IsValidRowHandle(i))
                                    {
                                        isValid = false;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    
                    if (!isValid)
                    {
                        return;
                    }
                    object masterID = null;
                    this.currentData = this.BindingValueIntoObject(ref masterID);

                    if (this.FormAction == (int)MTControl.FormAction.Add)
                    {
                        lastestData = (BaseEntity)this.currentData.Clone();
                    }
                    if (this.GrdDetails != null)
                    {
                        this.LstDetail = new List<BaseEntity>();
                        foreach (var pair in this.GrdDetails)
                        {
                            MGridControl grdDetail = this.GrdDetails[pair.Key].GrdDetail;
                            if (string.IsNullOrEmpty(grdDetail.SetField))
                            {
                                continue;
                            }
                            IList lstData = grdDetail.GetDataChanges();
                            if(lstData!=null && lstData.Count > 0)
                            {
                                this.currentData.SetValue(grdDetail.SetField, lstData);
                            }
                        }
                    }

                    SplashScreenManager.ShowForm(this, typeof(WaitFormCustom), true, true, false);

                    ResultData resultData = SubmitData(this.currentData);
                    if (resultData.Success)
                    {
                        if (lastestData != null)
                        {
                            DBContext.GetRep2<DuLieuGanNhatTrenFormRepository>().SaveData(new DuLieuGanNhatTrenForm
                            {
                                sTableName = lastestData.TableName,
                                sFormData = MT.Library.Utility.SerializeObject(lastestData),
                                sUserId = MT.Library.SessionData.UserId,
                                MTEntityState = Enummation.MTEntityState.Add
                            });
                        }

                        if (!this.IsQuickAdd)
                        {
                            //Callback thông tin form danh sách
                            if (this.ParentFrm != null )
                            {
                                (this.ParentFrm as MFormList).CallbackAfterSaveDetail(this);
                            }

                            SaveSucess(isSaveNew);

                            if (!isSaveNew)
                            {
                                this.CloseForm();
                            }
                            else
                            {
                                isSaveNew = false;
                                this.FormAction = (int)MTControl.FormAction.Add;
                                this.BindDataToForm();
                            }
                        }
                        else
                        {
                            this.AddQuickAddItem(this.ControlCallForm);
                            this.CloseForm();
                        }
                    }
                    else
                    {
                        HideMask();
                        if (!string.IsNullOrWhiteSpace(resultData.UserMsg))
                        {
                            MMessage.ShowWarning(resultData.UserMsg);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                HideMask();
                CommonFnUI.HandleException(ex);
            }
            finally
            {
                HideMask();
            }
        }

        /// <summary>
        /// Xử lý sau khi lưu thành công
        /// </summary>
        /// <param name="isSaveNew"></param>
        protected virtual void SaveSucess(bool isSaveNew)
        {

        }

        /// <summary>
        /// Xử lý việc thêm nhanh đối tượng vào combo
        /// </summary>
        /// Create by: dvthang:21.10.2017
        private void AddQuickAddItem(object controlQuickAdd)
        {
            if (controlQuickAdd != null)
            {
                //Ctype ctype
                Ctype ctype = controlQuickAdd.GetValue<Ctype>("Mtype");
                switch (ctype)
                {
                    case Ctype.MGridLookUpEdit:
                        MGridLookUpEdit grd = controlQuickAdd as MGridLookUpEdit;
                        if (grd != null)
                        {
                            grd.PushItem(this.currentData);
                            grd.EditValue = this.currentData.GetValue<object>(grd.Properties.ValueMember);

                            if (grd.Grid != null)
                            {
                                var gridView = grd.Grid.FirstView;
                                var repGridLookUpEdit = grd.Grid.RepositoryItems[gridView.FocusedColumn.VisibleIndex] as MRepositoryItemGridLookUpEdit;
                                if (repGridLookUpEdit != null)
                                {
                                    repGridLookUpEdit.PushItem(this.currentData);
                                }
                                gridView.SetRowCellValue(gridView.FocusedRowHandle, gridView.FocusedColumn,
                                    this.currentData.GetValue<object>(grd.Properties.ValueMember));
                            }
                        }
                        break;
                    case Ctype.MLookUpEdit:
                        MLookUpEdit lookUp = controlQuickAdd as MLookUpEdit;
                        if (lookUp != null)
                        {
                            lookUp.PushItem(this.currentData);
                            lookUp.EditValue = this.currentData.GetValue<object>(lookUp.Properties.ValueMember);
                            if (lookUp.Grid != null)
                            {
                                var gridView = lookUp.Grid.FirstView;
                                var repLookUpEdit= lookUp.Grid.RepositoryItems[gridView.FocusedColumn.VisibleIndex] as MRepositoryItemLookUpEdit;
                                if(repLookUpEdit!=null)
                                {
                                    repLookUpEdit.PushItem(this.currentData);
                                }
                                gridView.SetRowCellValue(gridView.FocusedRowHandle, gridView.FocusedColumn,
                                    this.currentData.GetValue<object>(lookUp.Properties.ValueMember));
                            }
                        }
                        break;
                    case Ctype.MTreeLookUpEdit:
                        MTreeLookUpEdit treeLookUp = controlQuickAdd as MTreeLookUpEdit;
                        if (treeLookUp != null)
                        {
                            treeLookUp.PushItem(this.currentData);
                            treeLookUp.EditValue = this.currentData.GetValue<object>(treeLookUp.Properties.ValueMember);
                            if (treeLookUp.Grid != null)
                            {
                                var gridView = treeLookUp.Grid.FirstView;
                                gridView.SetRowCellValue(gridView.FocusedRowHandle, gridView.FocusedColumn,
                                    this.currentData.GetValue<object>(treeLookUp.Properties.ValueMember));
                            }
                        }
                        break;
                }
            }
        }


        /// <summary>
        /// Ẩn mask khi có lỗi xảy ra
        /// </summary>
        /// Create by: dvthang:04.10.2017
        protected void HideMask()
        {
            SplashScreenManager.CloseForm(false);
        }

        /// <summary>
        /// Hàm thực hiện lấy về danh sách detail theo id của bản ghi master
        /// </summary>
        /// <param name="tableName">Tên bảng</param>
        /// <param name="masterId">Id của master</param>
        protected virtual IList GetDetailByMasterID(string tableName, object masterId)
        {
            if(grdDetails==null || grdDetails.Count == 0)
            {
                return null;
            }
            string viewName = grdDetails[tableName].GrdDetail.ViewName;
            return this.ConfigFormDetail.Rep.GetDetailsByMasterID2(viewName,tableName, masterId);
        }

        /// <summary>
        /// Gán giá trị mặc định cho form thêm nhanh
        /// </summary>
        /// <returns>Key(Tên thuộc tính),Value: Giá trị control</returns>
        public virtual Dictionary<string, object> SetDefaultValueFormQuickAdd()
        {
            return new Dictionary<string, object>();
        }
        #endregion

        #region"Implement"

        #endregion

        #region"Event"

        /// <summary>
        /// Gọi hàm load data cho grid
        /// </summary>
        /// <param name="sender"></param>
        /// Create by: dvthang:04.03.2017
        private void workerDetail_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            //todo
            e.Result =new ResultDetail { TableName= e.Argument.ToString(), Data =GetDetailByMasterID(e.Argument.ToString(), this.currentData.GetIdentity()) };
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
                    grdDetails[resultDetail.TableName].GrdDetail.LoadData(null);
                }
                else
                {
                    grdDetails[resultDetail.TableName].GrdDetail.LoadData(resultDetail.Data);
                }
            }
            else
            {
                MMessage.ShowError(e.Error.Message);
            }
        }


        private void btnPrint_Click(object sender, EventArgs e)
        {
            Print();
        }
        /// <summary>
        /// Thực hiện lệnh in
        /// </summary>
        /// <returns></returns>
        protected virtual bool Print()
        {
            return true;
        }

        private void pic_Exit_Click(object sender, EventArgs e)
        {
            CloseForm();
        }
        /// <summary>
        /// Đóng form
        /// </summary>
        public void CloseForm()
        {
            if (BgWorkers != null)
            {
                foreach (var item in BgWorkers)
                {
                    item.Value.Dispose();
                }

                BgWorkers = new Dictionary<string, BackgroundWorker>();
            }
            this.Close();
        }
        /// <summary>
        /// Load data cho form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MFormDictionnaryDetail_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                Guna.UI.Lib.GraphicsHelper.ShadowForm(this);
                this.Text = string.Empty;
                pic_Exit.Location = new System.Drawing.Point(this.Width - 20, 5);
                iconPictureBoxMaximize.Location = new System.Drawing.Point(this.Width - 40, 6);

                if (IsShowMaximize)
                {
                    iconPictureBoxMaximize.Show();
                }
                else
                {
                    iconPictureBoxMaximize.Hide();
                }

                if (grdDetails != null && grdDetails.Count > 0)
                {
                    foreach (var item in grdDetails)
                    {
                        var worker = new BackgroundWorker();
                        worker.DoWork -= workerDetail_DoWork;
                        worker.RunWorkerCompleted -= workerDetail_Completed;
                        worker.DoWork += workerDetail_DoWork;
                        worker.RunWorkerCompleted += workerDetail_Completed;
                        BgWorkers.Add(item.Key, worker);

                    }
                }


                if (this.IsInitForm)
                {
                    this.InitForm(this.controlRoot == null ? this : this.controlRoot);
                }
                this.SetViewModeControlByFromAction();

                this.BindDataToForm();
            }
        }

        /// <summary>
        /// Trước khi load form muốn làm cái gì đó thì overirdes lại hàm này
        /// </summary>
        /// Create by: dvthang:26.11.2017
        protected virtual void SetViewModeControlByFromAction()
        {
            switch (this.FormAction)
            {
                case (int)MTControl.FormAction.View:
                    CommonFnUI.SetReaOnlyForControlByFormAction(true, dicControls);
                    btnSave.Enabled = false;
                    btnSaveNew.Enabled = false;
                    if (grdDetails != null)
                    {
                        foreach (var item in grdDetails)
                        {
                            item.Value.SetReadOnly(true);
                        }
                    }
                    break;
                default:
                    btnSave.Enabled = true;
                    btnSaveNew.Enabled = true;
                    CommonFnUI.SetReaOnlyForControlByFormAction(false, dicControls);
                    if (grdDetails != null)
                    {
                        foreach (var item in grdDetails)
                        {
                            item.Value.SetReadOnly(false);
                        }
                    }
                    break;
            }
         }

        /// <summary>
        /// Khởi tạo các thông số cho form
        /// dvthang-08.09.2016
        /// </summary>
        protected void InitForm(Control c)
        {
            //Lấy toàn bộ các control nhập liệu trên form
            this.controlRoot = c;

            dicControls = CommonFnUI.GetAllControls(controlRoot, new Dictionary<string, IEditControl>());
            CommonFnUI.InitValidateControl(ValidationProvider, dicControls);
            //Clear validate lỗi trên form
            CommonFnUI.ClearValidateForm(this.ValidationProvider);

            if (this.grdDetails != null)
            {
                foreach (var item in this.grdDetails)
                {
                    item.Value.GrdDetail.TableName = item.Key;
                    item.Value.GrdDetail.CustomRowCellEditing = new EventHandler<DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs>(gridControlCustomRowCellEdit);
                    item.Value.GrdDetail.FirstView.CellValueChanged -= FirstView_CellValueChanged;
                    item.Value.GrdDetail.FirstView.CellValueChanged += FirstView_CellValueChanged;
                }
            }
        }

        /// <summary>
        /// Bắt event cell của grid thay đổi giá trị
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FirstView_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            var grd = (sender as MGridView).GridControl;
            CustomRowCellValueChangedGridDetail((MGridControl)grd, e);
        }

        /// <summary>
        /// Thò ra hàm để form chi tiết tự overrides lại khi cần custom lại giá trị của cell trên grid
        /// </summary>
        /// <param name="mGridControl"></param>
        /// <param name="e"></param>
        protected virtual void CustomRowCellValueChangedGridDetail(MGridControl gridView, CellValueChangedEventArgs e)
        {
            //todo
          
        }


        /// <summary>
        /// Thò ra hàm để form chi tiết tự overrides lại khi cần
        /// </summary>
        /// <param name="mGridControl"></param>
        /// <param name="e"></param>
        protected virtual void CustomRowCellGridDetail(MGridControl mGridControl, RepositoryItem repository, CustomRowCellEditEventArgs e)
        {
            //todo
        }

        /// <summary>
        /// Bắt event cellediting
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridControlCustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
        {
            RepositoryItem repositoryItem = sender as RepositoryItem;
            CustomRowCellGridDetail(repositoryItem.Tag as MGridControl, repositoryItem, e);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Thực hiện cất thông tin trên form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            string formDetail = this.GetType().Name;
            int index = formDetail.LastIndexOf("Detail");
            string formId = formDetail.Substring(0, index);

            if (!CommonFnUI.CheckPermission(formId, MT.Library.Enummation.PermissionValue.Add,
                MT.Library.Enummation.PermissionValue.Edit,
                MT.Library.Enummation.PermissionValue.Duplicate))
            {
                MMessage.ShowWarning("Bạn không có quyền thực hiện chức năng này");
                return;
            }

            this.SaveData(sender, e);
        }

        /// <summary>
        /// Thực cất và thêm trên form danh sách
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveNew_Click(object sender, EventArgs e)
        {
            string formDetail = this.GetType().Name;
            int index = formDetail.LastIndexOf("Detail");
            string formId = formDetail.Substring(0, index);

            if (!CommonFnUI.CheckPermission(formId, MT.Library.Enummation.PermissionValue.Add,
                MT.Library.Enummation.PermissionValue.Edit,
                MT.Library.Enummation.PermissionValue.Duplicate))
            {
                MMessage.ShowWarning("Bạn không có quyền thực hiện chức năng này");
                return;
            }

            isSaveNew = true;
            this.SaveData(sender, e);
        }

        /// <summary>
        /// Hiển thị form help
        /// </summary>
        /// Create by: dvthang:19.11.2017
        public virtual void OpenHelp()
        {
            MFormHelp frm = new MFormHelp();
            frm.sFormName = this.Name;
            frm.ShowDialog();
            frm.Dispose();
        }

        /// <summary>
        /// Nút phóng to thu nhỏ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void iconPictureBoxMaximize_Click(object sender, EventArgs e)
        {
            if (IsShowMaximize)
            {
                iconPictureBoxMaximize.IconChar = FontAwesome.Sharp.IconChar.WindowMinimize;
                this.WindowState = FormWindowState.Minimized;
                IsShowMaximize = false;
            }
            else
            {
                iconPictureBoxMaximize.IconChar = FontAwesome.Sharp.IconChar.WindowMaximize;
                this.WindowState = FormWindowState.Maximized;
                IsShowMaximize = true;
            }
        }
        #endregion


    }
}

