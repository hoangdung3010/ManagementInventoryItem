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
    public partial class frmUser : FormUI.FormUIBase
    {
        #region"Property"

        TypeAssistant assistantRoles;

        string searchUserName = string.Empty;

        BindingSource _bsUser = new BindingSource();

        DataTable _dtUser = null;

        Guid? orgId = null;
        Guid? roleId = null;

        #endregion
        public frmUser()
        {
            InitializeComponent();
            Init();
        }

        #region"Sub/Func"
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
            cboRoleId.Properties.DataSource = DBContext.GetRep<MT.Data.Rep.SysRoleRepository>().GetData(typeof(MT.Data.BO.SysRole), columns: "Id,RoleName", viewName: "SysRoles");

            mtreeLookUpDonVi.Properties.DisplayMember = "sTenDonvi";
            mtreeLookUpDonVi.Properties.ValueMember = "Id";
            var treeList = mtreeLookUpDonVi.Properties.TreeList;
            treeList.KeyFieldName = "Id";
            treeList.ParentFieldName = "sParentId";
            mtreeLookUpDonVi.AddColumn("sMaDonvi", "Mã đơn vị", 120);
            mtreeLookUpDonVi.AddColumn("sTenDonvi", "Tên đơn vị", 180, true);
            mtreeLookUpDonVi.SetReadOnly(false);
            mtreeLookUpDonVi.Properties.NullValuePrompt = "Tất cả";
            mtreeLookUpDonVi.Properties.DataSource = DBContext.GetRep2<MT.Data.Rep.DM_DonViRepository>().GetRecursiveOrgById(MT.Library.SessionData.OrganizationUnitId);
        }

        /// <summary>
        /// Khởi tạo các thông tin trên form
        /// </summary>     
        private void Init()
        {
            gridUser.AutoGenerateColumns = false;
            gridUser.ReadOnly = true;
            InitLookup();
        }

        /// <summary>
        /// Load dữ liệu cho form
        /// </summary>
        private void LoadUsersData()
        {
            try
            {
                if (mtreeLookUpDonVi.EditValue != null)
                {
                    orgId = Guid.Parse(mtreeLookUpDonVi.EditValue.ToString());
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
                if (!string.IsNullOrEmpty(txtSearchUser.Text))
                {
                    searchUserName = txtSearchUser.Text.Trim();
                }
                else
                {
                    searchUserName = string.Empty;
                }

                if (!backgroundWorkerUser.IsBusy)
                {
                    backgroundWorkerUser.RunWorkerAsync();
                }
            }
            catch (Exception ex)
            {
                CommonFnUI.HandleException(ex);
            }
        }
        
        /// <summary>
        /// Thiết lập mức truy cập dữ liệu
        /// </summary>
        private void SetEmployeeAccessLevel()
        {
            try
            {
                if (!CommonFnUI.CheckPermission(MT.Data.FormUIHandle.MSC_USER, MT.Library.Enummation.PermissionValue.EmployeeAccessLevel))
                {
                    MMessage.ShowWarning(MT.Library.CommonKey.MsgNotPermission);
                    return;
                }

                if (_dtUser?.Rows.Count > 0 && _bsUser.Position < 0)
                {
                    MMessage.ShowWarning("Bạn phải chọn một tài khoản phân quyền mức truy cập dữ liệu");
                    return;
                }
                SysUser sysUser = new SysUser();
                Guid id = Guid.Parse(_dtUser.Rows[_bsUser.Position]["Id"].ToString());
                sysUser.Id = id;
                string roleName = Convert.ToString(_dtUser.Rows[_bsUser.Position]["RoleName"]);
                sysUser.RoleName = roleName;
                sysUser.RoleId = Guid.Parse(_dtUser.Rows[_bsUser.Position]["RoleId"].ToString());
                sysUser.Active = Convert.ToBoolean(_dtUser.Rows[_bsUser.Position]["Active"]);
                sysUser.OrganizationUnitId = Guid.Parse(_dtUser.Rows[_bsUser.Position]["OrganizationUnitId"].ToString());
                sysUser.Email = Convert.ToString(_dtUser.Rows[_bsUser.Position]["Email"]);
                sysUser.Password = Convert.ToString(_dtUser.Rows[_bsUser.Position]["Password"]);
                object objPic = _dtUser.Rows[_bsUser.Position]["Picture"];
                if (objPic != null)
                {
                    sysUser.Picture = (byte[])_dtUser.Rows[_bsUser.Position]["Picture"];
                }
                using (frmEmployeeAccessLevel frm = new frmEmployeeAccessLevel(sysUser))
                {
                    frm.ShowDialog();
                }
            }
            catch (Exception ex)
            {

                CommonFnUI.HandleException(ex);
            }
        }
        #endregion
        #region"Event"
        private void txtSearchUser_TextChanged(object sender, EventArgs e)
        {
            assistantRoles = new TypeAssistant(1000);
            assistantRoles.Idled += assistantUser_Idled;
            assistantRoles.TextChanged();
        }

        private void assistantUser_Idled(object sender, EventArgs e)
        {
            this.Invoke(
             new MethodInvoker(() =>
             {
                 searchUserName = txtSearchUser.Text.Trim();
                 if (!backgroundWorkerUser.IsBusy)
                 {
                     backgroundWorkerUser.RunWorkerAsync();
                 }
             }));
        }

        private void backgroundWorkerUser_DoWork(object sender, DoWorkEventArgs e)
        {
            searchUserName = MT.Library.Utility.AddChar(searchUserName);

            SysUserRepository sysUserRepository = (SysUserRepository)DBContext.GetRep<SysUserRepository>();

            _dtUser = sysUserRepository.GetAllByCondition(roleId,orgId,searchUserName);
            e.Result = _dtUser;
        }
        private void backgroundWorkerUser_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                _bsUser.DataSource = e.Result;
                gridUser.DataSource = _bsUser;
                if (_bsUser.Count > 0)
                {
                    _bsUser.Position = 0;
                }
            }
            else
            {
                CommonFnUI.HandleException(e.Error);
            }
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            if (!CommonFnUI.CheckPermission(this.GetType().Name, MT.Library.Enummation.PermissionValue.Add))
            {
                MMessage.ShowWarning(MT.Library.CommonKey.MsgNotPermission);
                return;
            }
            frmAddUser frm = new frmAddUser((int)MT.Library.Enummation.MTEntityState.Add);
            frm.OnAddUser = new EventHandler(on_ReloadUser);
            frm.ShowDialog();
        }

        private void on_ReloadUser(object sender, EventArgs e)
        {
            if (!backgroundWorkerUser.IsBusy)
            {
                backgroundWorkerUser.RunWorkerAsync();
            }
        }
        private void gridUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 6)
                {
                    SetEmployeeAccessLevel();
                }
                if (e.ColumnIndex == 7)
                {
                    //Xem quyền
                    if (!CommonFnUI.CheckPermission(this.GetType().Name, MT.Library.Enummation.PermissionValue.ViewPermission))
                    {
                        MMessage.ShowWarning(MT.Library.CommonKey.MsgNotPermission);
                        return;
                    }
                    Guid roleId = Guid.Parse(_dtUser.Rows[e.RowIndex]["RoleId"].ToString());
                    string roleName = _dtUser.Rows[e.RowIndex]["RoleName"].ToString();
                    using (frmPrivilege frm = new frmPrivilege(roleId, roleName, true))
                    {
                        frm.ShowDialog();
                    }
                }
                //Sửa
                if (e.ColumnIndex == 8)
                {
                    if (!CommonFnUI.CheckPermission(this.GetType().Name, MT.Library.Enummation.PermissionValue.Edit))
                    {
                        MMessage.ShowWarning(MT.Library.CommonKey.MsgNotPermission);
                        return;
                    }

                    SysUser sysUser = new SysUser();
                    Guid id =Guid.Parse(_dtUser.Rows[e.RowIndex]["Id"].ToString());
                    sysUser.Id = id;
                    string roleName =Convert.ToString(_dtUser.Rows[e.RowIndex]["RoleName"]);
                    sysUser.RoleName = roleName;
                    sysUser.RoleId = Guid.Parse(_dtUser.Rows[e.RowIndex]["RoleId"].ToString());
                    sysUser.Active = Convert.ToBoolean(_dtUser.Rows[e.RowIndex]["Active"]);
                    sysUser.OrganizationUnitId= Guid.Parse(_dtUser.Rows[e.RowIndex]["OrganizationUnitId"].ToString());
                    sysUser.Email =Convert.ToString(_dtUser.Rows[e.RowIndex]["Email"]);
                    sysUser.Password = Convert.ToString(_dtUser.Rows[e.RowIndex]["Password"]);
                    sysUser.UserName= Convert.ToString(_dtUser.Rows[e.RowIndex]["UserName"]);
                    object objPic = _dtUser.Rows[e.RowIndex]["Picture"];
                    if (objPic != null)
                    {
                        sysUser.Picture = (byte[])_dtUser.Rows[e.RowIndex]["Picture"];
                    }
                    frmAddUser frm = new frmAddUser((int)MT.Library.Enummation.MTEntityState.Edit, sysUser);
                    frm.OnAddUser = new EventHandler(on_ReloadUser);
                    frm.ShowDialog();
                }
                //Xóa
                if (e.ColumnIndex == 9)
                {
                    delToolStripMenuItem_Click(sender, e);
                }
            }
        }
        private void frmUser_FormClosed(object sender, FormClosedEventArgs e)
        {
            LogHelper.UpdateEvent(UUID);
            this.Dispose();
        }

        private void gridUser_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                gunaContextMenuStripMoreButton.Show(gridUser, new Point(e.X, e.Y));
            }
        }

        private void viewPermissionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CommonFnUI.CheckPermission(this.GetType().Name, MT.Library.Enummation.PermissionValue.ViewPermission))
            {
                MMessage.ShowWarning(MT.Library.CommonKey.MsgNotPermission);
                return;
            }
            if (_bsUser.Position > -1)
            {
                Guid roleId = Guid.Parse(_dtUser.Rows[_bsUser.Position]["RoleId"].ToString());
                string roleName = _dtUser.Rows[_bsUser.Position]["RoleName"].ToString();
                using (frmPrivilege frm = new frmPrivilege(roleId, roleName, true))
                {
                    frm.ShowDialog();
                }
            }
            else
            {
                MMessage.ShowWarning("Bạn phải chọn một vai trò để phân quyền");
            }
        }
        private void thêmMớiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CommonFnUI.CheckPermission(this.GetType().Name, MT.Library.Enummation.PermissionValue.Add))
            {
                MMessage.ShowWarning(MT.Library.CommonKey.MsgNotPermission);
                return;
            }
            frmAddUser frm = new frmAddUser((int)MT.Library.Enummation.MTEntityState.Add);
            frm.OnAddUser = new EventHandler(on_ReloadUser);
            frm.ShowDialog();
        }
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CommonFnUI.CheckPermission(this.GetType().Name, MT.Library.Enummation.PermissionValue.Edit))
            {
                MMessage.ShowWarning(MT.Library.CommonKey.MsgNotPermission);
                return;
            }
            if (_bsUser.Position < 0)
            {
                MMessage.ShowWarning("Bạn vui lòng chọn người dùng để sửa");
                return;
            }
            
            SysUser sysUser = new SysUser();
            Guid id = Guid.Parse(_dtUser.Rows[_bsUser.Position]["Id"].ToString());
            sysUser.Id = id;
            string roleName = Convert.ToString(_dtUser.Rows[_bsUser.Position]["RoleName"]);
            sysUser.RoleName = roleName;
            sysUser.RoleId = Guid.Parse(_dtUser.Rows[_bsUser.Position]["RoleId"].ToString());
            sysUser.Active = Convert.ToBoolean(_dtUser.Rows[_bsUser.Position]["Active"]);
            sysUser.OrganizationUnitId = Guid.Parse(_dtUser.Rows[_bsUser.Position]["OrganizationUnitId"].ToString());
            sysUser.Email = Convert.ToString(_dtUser.Rows[_bsUser.Position]["Email"]);
            sysUser.Password = Convert.ToString(_dtUser.Rows[_bsUser.Position]["Password"]);
            object objPic = _dtUser.Rows[_bsUser.Position]["Picture"];
            if (objPic != null)
            {
                sysUser.Picture = (byte[])_dtUser.Rows[_bsUser.Position]["Picture"];
            }
            frmAddUser frm = new frmAddUser((int)MT.Library.Enummation.MTEntityState.Edit, sysUser);
            frm.OnAddUser = new EventHandler(on_ReloadUser);
            frm.ShowDialog();
        }
        private void delToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CommonFnUI.CheckPermission(this.GetType().Name, MT.Library.Enummation.PermissionValue.Delete))
                {
                    MMessage.ShowWarning(MT.Library.CommonKey.MsgNotPermission);
                    return;
                }
                if (_bsUser.Position < 0)
                {
                    MMessage.ShowWarning("Bạn vui lòng chọn vai trò cần xóa");
                    return;
                }

                Guid id = Guid.Parse(_dtUser.Rows[_bsUser.Position]["Id"].ToString());
                Guid roleId = Guid.Parse(_dtUser.Rows[_bsUser.Position]["RoleId"].ToString());
                string userName = _dtUser.Rows[_bsUser.Position]["UserName"].ToString();
                var sysUserRep = (SysUserRepository)DBContext.GetRep<SysUserRepository>();

                //Kiểm tra nếu tk là quản trị hệ thống thì phải tồn tại ít nhất 2 tài khoản trở lên thì mới cho xóa
                if (roleId == MT.Library.SessionData.AdministratorId)
                {
                    if (!sysUserRep.IsAdministrator(id))
                    {
                        MMessage.ShowWarning($"Bạn không thể xóa tài khoản <{userName}>. Vì hệ thống phải tồn tại ít nhất một tài khoản có vai trò <Administrator>");
                        return;
                    }
                }

                //Kiểm tra không cho tk của chính mình

                if (id == MT.Library.SessionData.UserId)
                {
                    MMessage.ShowWarning($"Bạn không được xóa tài khoản của chính mình.");
                    return;
                }
                SysUser _et = new SysUser
                {
                    Id = id,
                    UserName = userName,
                    RoleId = roleId
                };
                MMessage.ShowQuestion($"Bạn muốn chắc chắn muốn xóa tài khoản <{userName}> không?(Y/N)", (msg) =>
                {
                    var rs = sysUserRep.DeleteData(new List<object> { _et });
                    if (rs.Success)
                    {
                        LoadUsersData();
                    }
                });
            }
            catch (Exception ex)
            {
                CommonFnUI.HandleException(ex);
            }
        }

        private void frmUser_Load(object sender, EventArgs e)
        {
            if (!backgroundWorkerUser.IsBusy)
            {
                backgroundWorkerUser.RunWorkerAsync();
            }
        }
        private void mtreeLookUpDonVi_EditValueChanged(object sender, EventArgs e)
        {
            LoadUsersData();
        }
        private void cboRoleId_EditValueChanged(object sender, EventArgs e)
        {
            LoadUsersData();
        }
        private void mứcTruyCậpDữLiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetEmployeeAccessLevel();
        }
        #endregion


    }
}
