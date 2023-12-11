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
    public partial class frmRole : FormUI.FormUIBase
    {
        #region"Property"

        TypeAssistant assistantRoles;

        string searchRoleName = string.Empty;

        IOverlaySplashScreenHandle _handler;

        BindingSource _bsRole = new BindingSource();

        DataTable _dtRole = null;
        #endregion
        public frmRole()
        {
            InitializeComponent();
            gridRole.AutoGenerateColumns = false;
            gridRole.ReadOnly = true;
        }

        #region"Sub/Func"
        /// <summary>
        /// Khởi tạo các thông tin trên form
        /// </summary>     
        private void Init()
        {
            gridRole.AutoGenerateColumns = false;
            gridRole.ReadOnly = true;
        }
        #endregion
        #region"Event"
        private void txtSearchRole_TextChanged(object sender, EventArgs e)
        {
            assistantRoles = new TypeAssistant(1000);
            assistantRoles.Idled += assistantRoles_Idled;
            assistantRoles.TextChanged();
        }

        private void assistantRoles_Idled(object sender, EventArgs e)
        {
            this.Invoke(
             new MethodInvoker(() =>
             {
                 searchRoleName = txtSearchRole.Text.Trim();
                 if (!backgroundWorkerRole.IsBusy)
                 {
                     _handler = CommonFnUI.ShowProgress(gridRole);
                     backgroundWorkerRole.RunWorkerAsync();
                 }
             }));
        }

        private void backgroundWorkerRole_DoWork(object sender, DoWorkEventArgs e)
        {
            searchRoleName = MT.Library.Utility.AddChar(searchRoleName);

            SysRoleRepository sysRoleRepository = (SysRoleRepository)DBContext.GetRep<SysRoleRepository>();

            _dtRole = sysRoleRepository.GetAllByCondition(searchRoleName);
            e.Result = _dtRole;
        }
        private void backgroundWorkerRole_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                _bsRole.DataSource = e.Result;
                gridRole.DataSource = _bsRole;
                if (_bsRole.Count > 0)
                {
                    _bsRole.Position = 0;
                }
            }
            else
            {
                MMessage.ShowError(e.Error.Message);
            }

            CommonFnUI.CloseProgress(_handler);
        }

        private void btnAddRole_Click(object sender, EventArgs e)
        {
            if (!CommonFnUI.CheckPermission(this.GetType().Name, MT.Library.Enummation.PermissionValue.Add))
            {
                MMessage.ShowWarning(MT.Library.CommonKey.MsgNotPermission);
                return;
            }
            frmAddRole frm = new frmAddRole((int)MT.Library.Enummation.MTEntityState.Add);
            frm.OnAddRole = new EventHandler(on_ReloadRole);
            frm.ShowDialog();
        }

        private void on_ReloadRole(object sender, EventArgs e)
        {
            if (!backgroundWorkerRole.IsBusy)
            {
                _handler = CommonFnUI.ShowProgress(gridRole);
                backgroundWorkerRole.RunWorkerAsync();
            }
        }
        private void gridRole_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //Phân quyền
                if (e.ColumnIndex == 2)
                {
                    if (!CommonFnUI.CheckPermission(this.GetType().Name, MT.Library.Enummation.PermissionValue.Permission))
                    {
                        MMessage.ShowWarning(MT.Library.CommonKey.MsgNotPermission);
                        return;
                    }

                    Guid id =Guid.Parse(_dtRole.Rows[e.RowIndex]["Id"].ToString());
                    string roleName = gridRole.Rows[e.RowIndex].Cells[0].Value.ToString();
                    bool isSystem = Convert.ToBoolean(_dtRole.Rows[e.RowIndex]["IsSystem"]);
                    frmPrivilege frmPrivilege = new frmPrivilege(id, roleName, id == MT.Library.SessionData.AdministratorId);
                    frmPrivilege.ShowDialog();
                }
                //Sửa
                if (e.ColumnIndex == 3)
                {
                    if (!CommonFnUI.CheckPermission(this.GetType().Name, MT.Library.Enummation.PermissionValue.Edit))
                    {
                        MMessage.ShowWarning(MT.Library.CommonKey.MsgNotPermission);
                        return;
                    }

                    SysRole sysRole = new SysRole();
                    Guid id =Guid.Parse(_dtRole.Rows[e.RowIndex]["Id"].ToString());
                    sysRole.Id = id;
                    string roleName = gridRole.Rows[e.RowIndex].Cells[0].Value.ToString();
                    bool isSystem = Convert.ToBoolean(_dtRole.Rows[e.RowIndex]["IsSystem"]);
                    sysRole.IsSystem = isSystem;
                    sysRole.RoleName = roleName;
                    sysRole.Active = Convert.ToBoolean(_dtRole.Rows[e.RowIndex]["Active"]);

                    frmAddRole frm = new frmAddRole(sysRole, (int)MT.Library.Enummation.MTEntityState.Edit);
                    frm.OnAddRole = new EventHandler(on_ReloadRole);
                    frm.ShowDialog();
                }
                //Xóa
                if (e.ColumnIndex == 4)
                {
                    if (!CommonFnUI.CheckPermission(this.GetType().Name, MT.Library.Enummation.PermissionValue.Delete))
                    {
                        MMessage.ShowWarning(MT.Library.CommonKey.MsgNotPermission);
                        return;
                    }

                    string roleName = gridRole.Rows[e.RowIndex].Cells[0].Value.ToString();
                    bool isSystem = Convert.ToBoolean(_dtRole.Rows[e.RowIndex]["IsSystem"]);
                    if (isSystem)
                    {
                        MMessage.ShowWarning($"Vai trò <{roleName}> là dữ liệu mang đi của hệ thống. Bạn không thể xóa.");
                        return;
                    }
                    Guid roleId =Guid.Parse(_dtRole.Rows[e.RowIndex]["Id"].ToString());
                    var sysUserRep = (SysUserRepository)DBContext.GetRep<SysUserRepository>();
                    if (sysUserRep.CountUserByRoleId(roleId) > 0)
                    {
                        MMessage.ShowWarning($"Đã có người dùng thuộc vai trò <{roleName}>. Bạn phải xóa hết các dữ liệu phát sinh trước khi xóa vai trò này.");
                        return;
                    }


                    MMessage.ShowQuestion($"Bạn có chắc chắn muốn xóa vai trò <{roleName}> không?(Y/N)", (msg) =>
                    {
                        SysRole sysRoleET = new SysRole();
                        sysRoleET.Id = roleId;
                        sysRoleET.IsSystem = isSystem;
                        sysRoleET.RoleName = roleName;

                        var sysRoleRep = DBContext.GetRep<SysRoleRepository>();
                        var rs = sysRoleRep.DeleteData(new List<object> { sysRoleET });

                        if (rs.Success)
                        {
                            on_ReloadRole(null, null);
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(rs.UserMsg))
                            {
                                MMessage.ShowError(rs.UserMsg);
                            }
                        }
                    });
                }
            }
        }
        private void frmRole_FormClosed(object sender, FormClosedEventArgs e)
        {
            LogHelper.UpdateEvent(UUID);
            this.Dispose();
        }

        private void gridRole_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                gunaContextMenuStripMoreButton.Show(gridRole, new Point(e.X, e.Y));
            }
        }

        private void rolePermissionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CommonFnUI.CheckPermission(this.GetType().Name, MT.Library.Enummation.PermissionValue.Permission))
            {
                MMessage.ShowWarning(MT.Library.CommonKey.MsgNotPermission);
                return;
            }
            if (_bsRole.Position > -1)
            {
                Guid id =Guid.Parse(_dtRole.Rows[_bsRole.Position]["Id"].ToString());
                string roleName = gridRole.Rows[_bsRole.Position].Cells[0].Value.ToString();
                bool isSystem = Convert.ToBoolean(_dtRole.Rows[_bsRole.Position]["IsSystem"]);
                frmPrivilege frmPrivilege = new frmPrivilege(id, roleName, id == MT.Library.SessionData.AdministratorId);
                frmPrivilege.ShowDialog();
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
            frmAddRole frm = new frmAddRole((int)MT.Library.Enummation.MTEntityState.Add);
            frm.OnAddRole = new EventHandler(on_ReloadRole);
            frm.ShowDialog();
        }
        private void sửaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CommonFnUI.CheckPermission(this.GetType().Name, MT.Library.Enummation.PermissionValue.Edit))
            {
                MMessage.ShowWarning(MT.Library.CommonKey.MsgNotPermission);
                return;
            }
            if (_bsRole.Position < 0)
            {
                MMessage.ShowWarning("Bạn vui lòng chọn vai trò để sửa");
                return;
            }
            SysRole sysRole = new SysRole();
            Guid id = Guid.Parse(_dtRole.Rows[_bsRole.Position]["Id"].ToString());
            sysRole.Id = id;
            string roleName = gridRole.Rows[_bsRole.Position].Cells[0].Value.ToString();
            bool isSystem = Convert.ToBoolean(_dtRole.Rows[_bsRole.Position]["IsSystem"]);
            sysRole.IsSystem = isSystem;
            sysRole.RoleName = roleName;
            sysRole.Active = Convert.ToBoolean(_dtRole.Rows[_bsRole.Position]["Active"]);

            frmAddRole frm = new frmAddRole(sysRole, (int)MT.Library.Enummation.MTEntityState.Edit);
            frm.OnAddRole = new EventHandler(on_ReloadRole);
            frm.ShowDialog();
        }
        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CommonFnUI.CheckPermission(this.GetType().Name, MT.Library.Enummation.PermissionValue.Delete))
            {
                MMessage.ShowWarning(MT.Library.CommonKey.MsgNotPermission);
                return;
            }
            if (_bsRole.Position < 0)
            {
                MMessage.ShowWarning("Bạn vui lòng chọn vai trò cần xóa");
                return;
            }
            string roleName = gridRole.Rows[_bsRole.Position].Cells[0].Value.ToString();
            bool isSystem = Convert.ToBoolean(_dtRole.Rows[_bsRole.Position]["IsSystem"]);
            if (isSystem)
            {
                MMessage.ShowWarning($"Vai trò <{roleName}> là dữ liệu mang đi của hệ thống. Bạn không thể xóa.");
                return;
            }
            Guid roleId =Guid.Parse(_dtRole.Rows[_bsRole.Position]["Id"].ToString());
            var sysUserRep = (SysUserRepository)DBContext.GetRep<SysUserRepository>();
            if (sysUserRep.CountUserByRoleId(roleId) > 0)
            {
                MMessage.ShowWarning($"Đã có người dùng thuộc vai trò <{roleName}>. Bạn phải xóa hết các dữ liệu phát sinh trước khi xóa vai trò này.");
                return;
            }
            MMessage.ShowQuestion($"Bạn có chắc chắn muốn xóa vai trò <{roleName}> không?(Y/N)", (msg) =>
            {
                SysRole sysRole = new SysRole();
                sysRole.Id = roleId;
                sysRole.IsSystem = isSystem;
                sysRole.RoleName = roleName;

                var sysRoleRep = (SysRoleRepository)DBContext.GetRep<SysRoleRepository>();

                var rs = sysRoleRep.DeleteData(new List<object> { sysRole });
                if (rs.Success)
                {
                    on_ReloadRole(null, null);
                }
                else
                {
                    if (!string.IsNullOrEmpty(rs.UserMsg))
                    {
                        MMessage.ShowError(rs.UserMsg);
                    }
                }

            });
        }

        private void frmRole_Load(object sender, EventArgs e)
        {
            LogHelper.AddEvent(UUID, "Quản lý vai trò");
            //Vai trò
            if (!backgroundWorkerRole.IsBusy)
            {
                backgroundWorkerRole.RunWorkerAsync();
            }
        }
        #endregion


    }
}
