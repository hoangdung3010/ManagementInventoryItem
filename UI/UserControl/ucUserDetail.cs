using FormUI.Base;
using MT.Data;
using MT.Data.BO;
using MT.Data.Rep;
using MT.Library.UW;
using MTControl;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace FormUI
{
    public partial class ucUserDetail : FormUIUserControl
    {
        #region"Property"
        EventHandler _onDeleteData;//dung de truyen du lieu qua frmchucvu
        int _state;//co xac dinh la insert hay edit
        SysUser _et;
        Guid _oldRoleId;
        public EventHandler OnDeleteData
        {
            set
            {
                _onDeleteData = value;
            }
        }

        #endregion
        #region"Contructor"
        public ucUserDetail()
        {
            InitializeComponent();
        }
        public ucUserDetail(SysUser _et, int _state)
        {
            InitializeComponent();

            this._state = _state;
            Init();
            this._et = _et;

            _oldRoleId = this._et.RoleId.Value;

        }
        #endregion

        #region"Sub/Func"
        /// <summary>
        /// Khởi tạo các thông tin trên form
        /// </summary>     
        private void Init()
        {
            cboFullName.SetReadOnly(true);
            mtreeLookUpDonVi.SetReadOnly(true);
            _et = new SysUser();
            InitLookup();
        }

        /// <summary>
        /// Khởi tạo các giá trị của lookup
        /// </summary>
        private void InitLookup()
        {
            mtreeLookUpDonVi.Properties.DisplayMember = "sTenDonvi";
            mtreeLookUpDonVi.Properties.ValueMember = "Id";
            var treeList = mtreeLookUpDonVi.Properties.TreeList;
            treeList.KeyFieldName = "Id";
            treeList.ParentFieldName = "sParentId";
            mtreeLookUpDonVi.AddColumn("sMaDonvi", "Mã đơn vị", 120);
            mtreeLookUpDonVi.AddColumn("sTenDonvi", "Tên đơn vị", 180, true);
            mtreeLookUpDonVi.Properties.DataSource = DBContext.GetRep<MT.Data.Rep.DM_DonViRepository>().GetData(typeof(MT.Data.BO.DM_DonVi));
            mtreeLookUpDonVi.AliasFormQuickAdd = "DM_DonVi";

            DM_CanBoRepository canBoRepository = (DM_CanBoRepository)DBContext.GetRep<DM_CanBoRepository>();

            cboFullName.Properties.DataSource = canBoRepository.GetData(typeof(MT.Data.BO.DM_CanBo), @"Id,sMaCanBo,sTenCanBo,sEmail,sDienThoai,sDM_ChucVu_Id,sDM_DonVi_Id,
                                                                                                        sDM_ChucVu_Id_Ten,sDM_DonVi_Id_Ten", "", "sTen", viewName: "View_DM_CanBo");
            cboFullName.AddColumn("sMaCanBo", "Mã cán bộ", 100);
            cboFullName.AddColumn("sTenCanBo", "Tên cán bộ", 180);
            cboFullName.AddColumn("sEmail", "Email", 100);
            cboFullName.AddColumn("sDienThoai", "Số điện thoại", 100);
            cboFullName.AddColumn("sDM_ChucVu_Id_Ten", "Chức vụ", 120);
            cboFullName.AddColumn("sDM_DonVi_Id_Ten", "Thuộc đơn vị", 180);
            cboFullName.Properties.DisplayMember = "sTenCanBo";

            cboFullName.Properties.ValueMember = "Id";
        }
        /// <summary>
        /// Reset giá trị trên form
        /// </summary>
        public void ResetForm()
        {
            _et = new SysUser();
            cboFullName.EditValue = null;
            txtUserName.Text = "";
            txtPass.Text = "";
            txtEmail.Text = "";
            rdAvaiable.Checked = true;
            cboGroupUser.SelectedIndex = 0;
            mtreeLookUpDonVi.EditValue = null;
        }

        /// <summary>
        /// Bind data cho đối tượng
        /// </summary>
        /// <returns></returns>
        private new bool Validate()
        {
            string userName = txtUserName.Text;
            string pass = txtPass.Text;
            string email = txtEmail.Text;
            bool active = rdAvaiable.Checked;
            if (cboFullName.EditValue == null)
            {
                MMessage.ShowWarning("Cán bộ không được bỏ trống");
                this.ActiveControl = cboFullName;
                return false;
            }

            if (string.IsNullOrEmpty(userName))
            {
                MMessage.ShowWarning("Tên đăng nhập không được bỏ trống");
                this.ActiveControl = txtUserName;
                return false;
            }


            if (string.IsNullOrEmpty(pass))
            {
                MMessage.ShowWarning("Mật khẩu không được bỏ trống");
                this.ActiveControl = txtPass;
                return false;
            }

            if (string.IsNullOrEmpty(email))
            {
                MMessage.ShowWarning("Email không được bỏ trống");
                this.ActiveControl = txtEmail;
                return false;
            }

            if (mtreeLookUpDonVi.GetValue() == null)
            {
                MMessage.ShowWarning("Đơn vị không được bỏ trống");
                this.ActiveControl = mtreeLookUpDonVi;
                return false;
            }
            var sysUserRep = (SysUserRepository)DBContext.GetRep<SysUserRepository>();
            if (sysUserRep.CheckExists(userName, _et.Id))
            {
                MMessage.ShowWarning($"Tên đăng nhập <{userName}> đã tồn tại trong hệ thống");
                this.ActiveControl = txtUserName;
                return false;
            }

            //Kiểm tra nếu tk là quản trị hệ thống thì phải tồn tại ít nhất 2 tài khoản trở lên thì mới cho xóa
            if (_oldRoleId == MT.Library.SessionData.AdministratorId && _oldRoleId != Guid.Parse(cboGroupUser.SelectedValue.ToString()))
            {
                if (!sysUserRep.IsAdministrator(_et.Id))
                {
                    cboGroupUser.SelectedValue = _oldRoleId;
                    MMessage.ShowWarning($"Bạn không thể chuyển vai trò cho tài khoản <{_et.UserName}>. Vì hệ thống phải tồn tại ít nhất một tài khoản có vai trò <Administrator>");
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Bind data cho đối tượng
        /// </summary>
        /// <returns></returns>
        private void BindData()
        {
            var sysRoleRep = (SysRoleRepository)DBContext.GetRep<SysRoleRepository>();
            cboGroupUser.DataSource = sysRoleRep.GetRoles();
            cboGroupUser.DisplayMember = "RoleName";

            cboGroupUser.ValueMember = "Id";

            cboFullName.EditValue = _et.Id;
            txtUserName.Text = _et.UserName.Trim();

            txtPass.Text = MT.Library.Utility.Decrypt(_et.Password.Trim());

            if (string.IsNullOrEmpty(_et.Email))
            {
                _et.Email = "";
            }
            txtEmail.Text = _et.Email.Trim();

            cboGroupUser.SelectedValue = _et.RoleId;
            mtreeLookUpDonVi.SetValue(_et.OrganizationUnitId);
            if (_et.Picture != null && _et.Picture.Length > 0)
            {
                MemoryStream ms = new MemoryStream((byte[])_et.Picture);
                picImage.Image = Image.FromStream(ms);
            }

            if (_et.Active)
            {
                rdAvaiable.Checked = true;
            }
            else
            {
                rdoUnActive.Checked = true;
            }


        }

        /// <summary>
        /// Cập nhật ảnh đại diện cho nhân viên
        /// </summary>
        /// <param name="bytesImage">Mảng ảnh</param>
        public void SetPicture(byte[] bytesImage)
        {
            if (bytesImage != null)
            {
                MemoryStream ms = new MemoryStream(bytesImage);
                picImage.Image = Image.FromStream(ms);
            }
            else
            {
                picImage.Image = null;
            }

        }

        /// <summary>
        /// Bind data cho đối tượng
        /// </summary>
        /// <returns></returns>
        private void MappingDataToEntity()
        {
            _et.Id = Guid.Parse(cboFullName.EditValue.ToString());
            _et.FullName = MT.Library.Utility.AddChar(cboFullName.Text.Trim());

            _et.UserName = MT.Library.Utility.AddChar(txtUserName.Text.Trim());
            _et.Password = MT.Library.Utility.Encrypt(MT.Library.Utility.AddChar(txtPass.Text.Trim()));
            _et.Email = MT.Library.Utility.AddChar(txtEmail.Text.Trim());

            _et.RoleId = Guid.Parse(cboGroupUser.SelectedValue.ToString());
            _et.OrganizationUnitId = Guid.Parse(mtreeLookUpDonVi.GetValue().ToString());
            if (picImage.Image != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    picImage.Image.Save(ms, ImageFormat.Jpeg);
                    byte[] photo_aray = new byte[ms.Length];
                    ms.Position = 0;
                    ms.Read(photo_aray, 0, photo_aray.Length);
                    _et.Picture = photo_aray;
                }
            }
            else
            {
                _et.Picture = null;
            }
            var now = SysDateTime.Instance.Now();
            _et.sCreatedBy = MT.Library.SessionData.UserName;
            _et.dCreatedDate = now;
            _et.sModifiedBy = MT.Library.SessionData.UserName;
            _et.dModifiedDate = now;
            _et.Active = rdAvaiable.Checked;
        }


        #endregion

        #region"Event"

        private void ucUserDetail_Load(object sender, EventArgs e)
        {
            txtPass.Properties.PasswordChar = '*';
            BindData();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CommonFnUI.CheckPermission(MT.Data.FormUIHandle.MSC_USER, MT.Library.Enummation.PermissionValue.Edit))
                {
                    MMessage.ShowWarning(MT.Library.CommonKey.MsgNotPermission);
                    return;
                }

                if (!Validate())
                {
                    return;
                }

                MappingDataToEntity();

                var sysUserRep = (SysUserRepository)DBContext.GetRep<SysUserRepository>();
                _et.MTEntityState = (MT.Library.Enummation.MTEntityState)_state;
                var rs = sysUserRep.SaveData(_et);
                if (rs.Success)
                {
                    _oldRoleId = _et.RoleId.Value;
                    MMessage.ShowInfor("Lưu thành công");
                }
                else
                {
                    if (!string.IsNullOrEmpty(rs.UserMsg))
                    {
                        MMessage.ShowWarning(rs.UserMsg);
                    }
                }
            }
            catch (Exception ex)
            {
                MMessage.ShowError("Lưu thất bại");
            }
        }
        private void btnDelUser_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CommonFnUI.CheckPermission(MT.Data.FormUIHandle.MSC_USER, MT.Library.Enummation.PermissionValue.Delete))
                {
                    MMessage.ShowWarning(MT.Library.CommonKey.MsgNotPermission);
                    return;
                }

                string query = string.Empty;

                var sysUserRep = (SysUserRepository)DBContext.GetRep<SysUserRepository>();
                //Kiểm tra nếu tk là quản trị hệ thống thì phải tồn tại ít nhất 2 tài khoản trở lên thì mới cho xóa
                if (_et.RoleId == MT.Library.SessionData.AdministratorId)
                {
                    if (!sysUserRep.IsAdministrator(_et.Id))
                    {
                        MMessage.ShowWarning($"Bạn không thể xóa tài khoản <{_et.UserName}>. Vì hệ thống phải tồn tại ít nhất một tài khoản có vai trò <Administrator>");
                        return;
                    }
                }

                //Kiểm tra không cho tk của chính mình

                if (_et.Id == MT.Library.SessionData.UserId)
                {
                    MMessage.ShowWarning($"Bạn không được xóa tài khoản của chính mình.");
                    return;
                }

                MMessage.ShowQuestion($"Bạn muốn chắc chắn muốn xóa tài khoản <{_et.UserName}> không?(Y/N)", (msg) =>
                {
                    var rs = sysUserRep.DeleteData(new List<object> { _et });
                    if (rs.Success)
                    {
                        if (_onDeleteData != null)
                        {
                            _onDeleteData(sender, e);
                        }
                        MMessage.ShowInfor("Xóa thành công");
                    }
                });

            }
            catch (Exception ex)
            {
                MMessage.ShowError(ex.Message);
            }
        }


        private void linkChooseImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!CommonFnUI.CheckPermission(MT.Data.FormUIHandle.MSC_USER, MT.Library.Enummation.PermissionValue.Edit))
            {
                MMessage.ShowWarning(MT.Library.CommonKey.MsgNotPermission);
                return;
            }
            OpenFileDialog dialog = new OpenFileDialog
            {
                Title = "Chọn ảnh đại diện",
                Filter = "JPG File |*.jpg|PNG File |*.png|SVG File |*.svg|GIF File |*.gif|Ico File |*.ico| BITMAP File|*.bmp| JPEG File|*.jpeg | All Graphic File|(*.jpg)||(*.bmp) "
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                if ((dialog.FileName == "") || !File.Exists(dialog.FileName))
                {
                    if (dialog.CheckFileExists)
                    {
                        MMessage.ShowInfor("Tệp tin kh\x00f4ng tồn tại!");
                    }
                }
                else
                {
                    this.picImage.ImageLocation = dialog.FileName;
                }
            }
        }

        private void lblDelImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!CommonFnUI.CheckPermission(MT.Data.FormUIHandle.MSC_USER, MT.Library.Enummation.PermissionValue.Edit))
            {
                MMessage.ShowWarning(MT.Library.CommonKey.MsgNotPermission);
                return;
            }
            this.picImage.Image = FormUI.Properties.Resources.Login;
        }

        private void btnChangePrivilege_Click(object sender, EventArgs e)
        {
            if (!CommonFnUI.CheckPermission(MT.Data.FormUIHandle.MSC_USER, MT.Library.Enummation.PermissionValue.ViewPermission))
            {
                MMessage.ShowWarning(MT.Library.CommonKey.MsgNotPermission);
                return;
            }

            if (!object.Equals(cboGroupUser.SelectedValue, _et.RoleId))
            {
                MMessage.ShowWarning($"Bạn đã thay đổi vai trò của tài khoản <{_et.UserName}>. Vui lòng thực hiện lưu thông tin trước khi xem quyền.");
                return;
            }
            using (frmPrivilege frm = new frmPrivilege(_et.RoleId.Value, cboGroupUser.Text, true))
            {
                frm.ShowDialog();
            }
        }

        /// <summary>
        /// Mức truy cập dữ liệu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEmployeeAccessLevel_Click(object sender, EventArgs e)
        {
            using (frmEmployeeAccessLevel frm = new frmEmployeeAccessLevel(_et))
            {
                frm.ShowDialog();
            }

        }
        #endregion


    }
}
