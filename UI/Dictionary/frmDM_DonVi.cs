using DevExpress.Office.Utils;
using DevExpress.XtraSplashScreen;
using MT.Data.BO;
using MT.Data.Rep;
using MT.Library.Log;
using MTControl;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormUI
{
    public partial class frmDM_DonVi : FormUI.MFormList
    {
        #region"Property"
        TypeAssistant assistant;
        IOverlaySplashScreenHandle _handler;
        string searchValueDonVi = string.Empty;
        private DM_DonVi currentDM_DonVi = null;
        #endregion

        #region"Contructor"
        public frmDM_DonVi()
        {
            InitializeComponent();

            InitControl();

            InitTree();

            ConfigFormDetail = new ConfigFormDetail
            {
                Rep = DBContext.GetRep<DM_DonViRepository>(),
                FormName = "frmDM_DonViDetail",
                Tree = treePaging,
                MToolbarList = mToolbarList1,
                EntityName = "DM_DonVi",
                Title = "Đơn vị"
            };

            mToolbarList1.ButtonNames = new MButtonName[]
           {
                new MButtonName{CommandName=MCommandName.AddNew},
                new MButtonName{CommandName=MCommandName.Duplicate},
                new MButtonName{CommandName=MCommandName.View},
                new MButtonName{CommandName=MCommandName.Edit},
                new MButtonName{CommandName=MCommandName.Delete},              
                new MButtonName{CommandName=MCommandName.Refresh,BeginGroup=true},
                new MButtonName{CommandName=MCommandName.Help,BeginGroup=true}
           };

        }

        private void InitControl()
        {

        }


        #endregion

        #region"Sub/Func"
        /// <summary>
        /// Khởi tạo các cột trên tree
        /// </summary>
        /// Create by: dvthang:07.03.2017
        private void InitTree()
        {
            MTreeView tv = this.treePaging.GetMTreeControl();
            //
            tv.OptionsView.ShowAutoFilterRow = true;
            tv.OptionsBehavior.ReadOnly = true;
            tv.OptionsBehavior.EnableFiltering = true;
            tv.Nodes.Clear();
            tv.KeyName = "Id";
            tv.TableName = "DM_DonVi";
            tv.ParentFieldName = "sParentId";
            tv.KeyFieldName = "Id";
            tv.ViewName = "View_DM_DonVi";
            var colMaDonVi = this.treePaging.AddColumnText("sMaDonvi", "Mã đơn vị", 150, isFixWidth: true, fixedStyle: DevExpress.XtraTreeList.Columns.FixedStyle.Left);
            this.treePaging.AddColumnText("sTenDonvi", "Tên đơn vị", 300, isFixWidth: true);
            this.treePaging.AddColumnText("sTenCotBC", "Tên cột BC","Tên cột báo cáo", 180);
            this.treePaging.AddColumnText("iType_Ten", "Là con theo", 80);
            this.treePaging.AddColumnText("sGhiChu", "Ghi chú", 250);
        }
        #endregion

        #region"Overrides"
        protected override void ProcessItemClick(int tag, object sender)
        {
            if (tag == (int)MTControl.MCommandName.Refresh)
            {
                LoadTreePagingData();
                return;
            }
            base.ProcessItemClick(tag,sender);
        }
        public override void CallbackAfterSaveDetail(FormUIBase frm)
        {
            try
            {
                //base.CallbackAfterSaveDetail(frm);
                LoadTreePagingData();
                currentDM_DonVi = (DM_DonVi)((MFormDictionnaryDetail)frm).CurrentData;
            }
            catch (Exception ex)
            {
                MMessage.ShowError(ex.Message);
            }
        }

        #endregion

        #region"Event"
        private void frmDM_DonVi_Load(object sender, EventArgs e)
        {
            LoadTreePagingData();
        }

        private void backgroundWorkerLoadDonVi_DoWork(object sender, DoWorkEventArgs e)
        {
            searchValueDonVi = MT.Library.Utility.AddChar(searchValueDonVi).ToLower();
            DM_DonViRepository dM_DonViRepository = (DM_DonViRepository)DBContext.GetRep<DM_DonViRepository>();

            e.Result = dM_DonViRepository.GetAllByCondition(searchValueDonVi);
        }

        private void backgroundWorkerLoadDonVi_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                try
                {
                    var data = (List<DM_DonVi>)e.Result;

                    this.treePaging.GetMTbrPaging().SetDisplayPageInfo(1, 1, data.Count);

                    MTreeView tv = this.treePaging.GetMTreeControl();
                    tv.DataSource = data;
                    tv.ExpandAll();
                }
                catch (Exception ex)
                {
                    MMessage.ShowError(ex.Message);
                }

            }
            else
            {
                MMessage.ShowError(e.Error.Message);
            }

            CommonFnUI.CloseProgress(_handler);

        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadTreePagingData();
        }
        private void txtSearch_EditValueChanged(object sender, EventArgs e)
        {
            assistant = new TypeAssistant(1000);
            assistant.Idled += assistant_Idled;
            assistant.TextChanged();
        }

        private void assistant_Idled(object sender, EventArgs e)
        {
            LoadTreePagingData();
        }


        private void backgroundWorkerLoadDonVi_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (currentDM_DonVi != null)
                {
                    MTreeView tv = this.treePaging.GetMTreeControl();
                    var node = tv.FindNodeByKeyID(currentDM_DonVi.Id);
                    tv.SetFocusedNode(node);
                    //tv.SelectNode(node);
                    currentDM_DonVi = null;
                }
            }
            catch (Exception ex)
            {
                MMessage.ShowError(ex.Message);
            }
        }
        #endregion

        #region "Phuong Thuc"
        /// <summary>
        /// Load dữ liệu cho form
        /// </summary>
        private void LoadTreePagingData()
        {
            this.Invoke(
             new MethodInvoker(() =>
             {
                 searchValueDonVi = txtSearch.Text.Trim();
                 if (String.IsNullOrEmpty(searchValueDonVi))
                 {
                     PagingTreeList.Sort = "sMaDonVi";
                     RefreshData();
                 }
                 else
                 {
                     LoadFilteredTreePagingData();
                 }
             }));
        }

        /// <summary>
        /// Lấy dữ liệu theo từ khoá tìm kiếm
        /// </summary>
        private void LoadFilteredTreePagingData()
        {
            try
            {
                if (!backgroundWorkerLoadDonVi.IsBusy)
                {

                    _handler = CommonFnUI.ShowProgress(treePaging);
                    backgroundWorkerLoadDonVi.RunWorkerCompleted -= backgroundWorkerLoadDonVi_Completed;
                    backgroundWorkerLoadDonVi.RunWorkerCompleted += backgroundWorkerLoadDonVi_Completed;
                    backgroundWorkerLoadDonVi.RunWorkerAsync();
                }
            }
            catch (Exception ex)
            {
                LogHelper.AddError(ex);
            }
        }


        #endregion


    }
}
