using DevExpress.XtraSplashScreen;
using MT.Data.BO;
using MT.Data.Rep;
using MT.Library.Log;
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
    public partial class frmOldUser : FormUI.FormUIBase
    {
        #region"Property"
        IOverlaySplashScreenHandle _handler;
        TypeAssistant assistantUser;

        string searchValueUser = string.Empty;

        int _currentPage = 1;
        int _pageSize = 10;
        Guid? orgId = null;
        Guid? roleId = null;
        MViewPaging _viewPaging;
        #endregion
        public frmOldUser()
        {
            InitializeComponent();
            Init();
        }

        #region"Sub/Func"

        /// <summary>
        /// Khởi tạo các thông tin trên form
        /// </summary>     
        private void Init()
        {
            _viewPaging = new MViewPaging();
            _viewPaging.PageSize = 10;
            _viewPaging.SetPagedDataSource(0, mDataNavigatorPaging1, LoadUsersData);
            lblPlaceHolder.ForeColor = System.Drawing.SystemColors.WindowText;
            lblSearchAdvanced.ForeColor = System.Drawing.SystemColors.WindowText;
            lblRoleId.ForeColor = System.Drawing.SystemColors.WindowText;
            InitLookup();
        }

        /// <summary>
        /// Khởi tạo các giá trị của lookup
        /// </summary>
        private void InitLookup()
        {
            cboRoleId.Properties.DisplayMember = "RoleName";
            cboRoleId.Properties.ValueMember = "Id";
            cboRoleId.AddColumn("RoleName", "Vai trò", 180);
            cboRoleId.Properties.NullValuePrompt = "Tất cả";
            cboRoleId.Properties.ShowHeader = false;
            cboRoleId.Properties.DataSource = DBContext.GetRep<MT.Data.Rep.SysRoleRepository>().GetData(typeof(MT.Data.BO.SysRole), columns: "Id,RoleName",viewName: "SysRoles");

            mtreeLookUpDonVi.Properties.DisplayMember = "sTenDonvi";
            mtreeLookUpDonVi.Properties.ValueMember = "Id";
            var treeList = mtreeLookUpDonVi.Properties.TreeList;
            treeList.KeyFieldName = "Id";
            treeList.ParentFieldName = "sParentId";
            mtreeLookUpDonVi.AddColumn("sMaDonvi", "Mã đơn vị", 120);
            mtreeLookUpDonVi.AddColumn("sTenDonvi", "Tên đơn vị", 180, true);
            mtreeLookUpDonVi.SetReadOnly(false);
            mtreeLookUpDonVi.Properties.NullValuePrompt = "Tất cả";
            mtreeLookUpDonVi.Properties.DataSource = DBContext.GetRep<MT.Data.Rep.DM_DonViRepository>().GetData(typeof(MT.Data.BO.DM_DonVi), columns: "Id,sParentId,sMaDonvi,sTenDonvi");
        }
        /// <summary>
        /// Load dữ liệu cho form
        /// </summary>
        private void LoadUsersData()
        {
            try
            {
                _currentPage = _viewPaging.CurrentPage;
                _pageSize = _viewPaging.PageSize;
                if (mtreeLookUpDonVi.EditValue != null)
                {
                    orgId =Guid.Parse(mtreeLookUpDonVi.EditValue.ToString());
                }
                else
                {
                    orgId = null;
                }
                if (cboRoleId.EditValue != null)
                {
                    roleId = Guid.Parse(cboRoleId.EditValue.ToString());
                }
                else
                {
                    roleId = null;
                }
                if (!backgroundWorkerLoadUser.IsBusy)
                {
                    _handler = CommonFnUI.ShowProgress(flowLayoutPanelUser);
                    backgroundWorkerLoadUser.RunWorkerAsync();
                }
            }
            catch (Exception ex)
            {
                LogHelper.AddError(ex);
            }
        }

        #endregion

        #region"Event"
        private void frmUser_Load(object sender, EventArgs e)
        {
            LogHelper.AddEvent(UUID, "Quản lý người dùng");
            LoadUsersData();
        }
        private void btnAddNewUser_Click(object sender, EventArgs e)
        {
            if (!CommonFnUI.CheckPermission(this.GetType().Name, MT.Library.Enummation.PermissionValue.Add))
            {
                MMessage.ShowWarning(MT.Library.CommonKey.MsgNotPermission);
                return;
            }

            frmAddUser frm = new frmAddUser((int)MT.Library.Enummation.MTEntityState.Add);
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.OnAddUser = new EventHandler(onRefreshListUser);
            frm.ShowDialog();
        }

        private void onRefreshListUser(object sender, EventArgs e)
        {
            LoadUsersData();
        }

        private void backgroundWorkerLoadUser_DoWork(object sender, DoWorkEventArgs e)
        {
            searchValueUser = MT.Library.Utility.AddChar(searchValueUser);
            SysUserRepository sysUserRepository = (SysUserRepository)DBContext.GetRep<SysUserRepository>();
            e.Result = sysUserRepository.GetAllByCondition(roleId,orgId, searchValueUser,_currentPage,_pageSize);
        }

        private void backgroundWorkerLoadUser_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                try
                {
                    Dictionary<Guid, ucUserDetail> dicUcUserDetail = new Dictionary<Guid, ucUserDetail>();

                    flowLayoutPanelUser.AutoSize = false;
                    flowLayoutPanelUser.AutoSizeMode = AutoSizeMode.GrowOnly;
                    flowLayoutPanelUser.FlowDirection = FlowDirection.TopDown;
                    flowLayoutPanelUser.AutoScroll = true;
                    flowLayoutPanelUser.WrapContents = false;
                    flowLayoutPanelUser.Controls.Clear();
                    if (e.Result != null)
                    {
                        var resultPaging = e.Result as ResultPaging;

                        var sysUsers = resultPaging.Data as List<SysUser>;
                        _viewPaging.SetPagedDataSource(resultPaging.Total, mDataNavigatorPaging1,LoadUsersData);
                        int left = 0;
                        int y = 0;
                        foreach (SysUser item in sysUsers)
                        {
                            ucUserDetail ucUserDetail = new ucUserDetail(item, (int)MT.Library.Enummation.MTEntityState.Edit);
                            if (!dicUcUserDetail.ContainsKey(item.Id))
                            {
                                dicUcUserDetail.Add(item.Id, ucUserDetail);
                            }

                            ucUserDetail.OnDeleteData = new EventHandler(onRefreshListUser);
                            ucUserDetail.Anchor = System.Windows.Forms.AnchorStyles.None;
                            ucUserDetail.ForeColor = System.Drawing.SystemColors.ControlText;

                            ucUserDetail.Name = item.Id.ToString();
                            left = (this.ClientSize.Width - ucUserDetail.Width) / 2;
                            ucUserDetail.Margin = new Padding(left, 8, 8, 4);
                            ucUserDetail.Hide();
                            ucUserDetail.Location = new Point(left, -1 + y);
                            flowLayoutPanelUser.Controls.Add(ucUserDetail);

                            y += ucUserDetail.Height;
                        }

                        foreach (var item in dicUcUserDetail)
                        {
                            item.Value.Show();
                        }
                    }

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

        private void txtSearchUser_TextChanged(object sender, EventArgs e)
        {
            assistantUser = new TypeAssistant(1000);
            assistantUser.Idled += assistantUser_Idled;
            assistantUser.TextChanged();
        }

        private void assistantUser_Idled(object sender, EventArgs e)
        {
            this.Invoke(
             new MethodInvoker(() =>
             {
                 searchValueUser = txtSearchUser.Text.Trim();
                 LoadUsersData();
             }));
        }

        /// <summary>
        /// Event tim kiem nguoi dung theo don vị
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mtreeLookUpDonVi_EditValueChanged(object sender, EventArgs e)
        {
            LoadUsersData();
        }

        private void cboRoleId_EditValueChanged(object sender, EventArgs e)
        {
            LoadUsersData();
        }
        #endregion


    }
}
