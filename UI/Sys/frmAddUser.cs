using MT.Data.BO;
using MT.Data.Rep;
using MT.Library.Log;
using MTControl;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace FormUI
{
    public partial class frmAddUser : FormUI.FormUIBase
    {
        #region"Property"
        EventHandler _onAddUser;
        int _state;//co xac dinh la insert hay edit
        SysUser _et;
        Guid? _oldRoleId;
        public EventHandler OnAddUser
        {
            set
            {
                _onAddUser = value;
            }
        }
        #endregion
        #region"Contructor"
        public frmAddUser()
        {
            InitializeComponent();
            Init();
        }
        public frmAddUser(int _state, SysUser _et=null)
        {
            InitializeComponent();

            this._state = _state;
            this._et = _et;
            if (this._state == (int)MT.Library.Enummation.MTEntityState.Edit)
            {
                _oldRoleId = this._et.RoleId;
            }
            Init();
        }
        #endregion

        #region"Sub/Func"
        /// <summary>
        /// Khởi tạo các thông tin trên form
        /// </summary>     
        private void Init()
        {
            this.Program = "Thêm mới người dùng";
            cboFullName.DictionaryName = "DM_CanBo";
            txtPass.Properties.PasswordChar = '*';
            InitLookup();
        }

        /// <summary>
        /// Khởi tạo các giá trị của lookup
        /// </summary>
        private void InitLookup()
        {
            if (this._state == (int)MT.Library.Enummation.MTEntityState.Edit)
            {
                cboFullName.SetReadOnly(true);
                mtreeLookUpDonVi.SetReadOnly(true);
            }
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

            string sWhere = "Id NOT IN(SELECT Id FROM dbo.SysUser)";
            if (this._state == (int)MT.Library.Enummation.MTEntityState.Edit)
            {
                sWhere = string.Empty;
            }
            cboFullName.Properties.DataSource = canBoRepository.GetData(typeof(MT.Data.BO.DM_CanBo), @"Id,sMaCanBo,sTenCanBo,sEmail,sDienThoai,sDM_ChucVu_Id,sDM_DonVi_Id,
                                                                                                        sDM_ChucVu_Id_Ten,sDM_DonVi_Id_Ten", sWhere, "sTen", viewName: "View_DM_CanBo");
            cboFullName.AddColumn("sMaCanBo", "Mã cán bộ", 100);
            cboFullName.AddColumn("sTenCanBo", "Tên cán bộ", 180);
            cboFullName.AddColumn("sEmail", "Email", 100);
            cboFullName.AddColumn("sDienThoai", "Số điện thoại", 100);
            cboFullName.AddColumn("sDM_ChucVu_Id_Ten", "Chức vụ", 120);
            cboFullName.AddColumn("sDM_DonVi_Id_Ten", "Thuộc đơn vị", 180);
            cboFullName.Properties.DisplayMember = "sTenCanBo";

            cboFullName.Properties.ValueMember = "Id";

            var sysRoleRep = (SysRoleRepository)DBContext.GetRep<SysRoleRepository>();
            cboGroupUser.DataSource = sysRoleRep.GetRoles();
            cboGroupUser.DisplayMember = "RoleName";

            cboGroupUser.ValueMember = "Id";

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
            mtreeLookUpDonVi.EditValue = null;
            rdAvaiable.Checked = true;
            cboGroupUser.SelectedIndex = 0;
            picImage.Image = FormUI.Properties.Resources.Login;
        }

        /// <summary>
        /// Bind data cho đối tượng
        /// </summary>
        /// <returns></returns>
        private new bool Validate()
        {
            string fullName = cboFullName.Text;
            string userName = MT.Library.Utility.AddChar(txtUserName.Text);
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

            if (!ValidateEmail(email))
            {
                MMessage.ShowWarning("Email không hợp lệ");
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
            Guid? id = null;
            if (this._state == (int)MT.Library.Enummation.MTEntityState.Edit)
            {
                id = _et.Id;
            }
            if (sysUserRep.CheckExists(userName, id))
            {
                MMessage.ShowWarning($"Tên đăng nhập <{userName}> đã tồn tại trong hệ thống");
                this.ActiveControl = txtUserName;
                return false;
            }

            //Kiểm tra nếu tk là quản trị hệ thống thì phải tồn tại ít nhất 2 tài khoản trở lên thì mới cho xóa
            if (id.HasValue && _oldRoleId.HasValue &&  _oldRoleId.Value == MT.Library.SessionData.AdministratorId && _oldRoleId.Value != Guid.Parse(cboGroupUser.SelectedValue.ToString()))
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
        /// Kiểm tra email có hợp lệ không
        /// </summary>
        /// <param name="email">Tên email</param>
        /// <returns>=true là đúng</returns>
        private bool ValidateEmail(string email)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            return match.Success;
        }
        /// <summary>
        /// Bind data cho đối tượng
        /// </summary>
        /// <returns></returns>
        private void BindData()
        {
            if (_et != null)
            {
                
                cboFullName.EditValue = _et.Id;
                if (!string.IsNullOrWhiteSpace(_et.UserName))
                {
                    txtUserName.Text = _et.UserName.ToString().Trim();
                }
                else
                {
                    txtUserName.Text = string.Empty;
                }
                if (!string.IsNullOrWhiteSpace(_et.Password))
                {
                    txtPass.Text = MT.Library.Utility.Decrypt(_et.Password.Trim());
                }
                else
                {
                    txtPass.Text = string.Empty;
                }
               

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
            else
            {
                ResetForm();
            }
            

        }
        /// <summary>
        /// Bind data cho đối tượng
        /// </summary>
        /// <returns></returns>
        private void MappingDataToEntity()
        {
            _et.Id = Guid.Parse(cboFullName.EditValue.ToString());
            _et.FullName = MT.Library.Utility.AddChar(cboFullName.Text);

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

            if (rdAvaiable.Checked)
            {
                _et.Active = true;
            }
            else
            {
                _et.Active = false;
            }
        }

        #endregion

        #region"Event"
        private void pic_Exit_Click(object sender, EventArgs e)
        {
            MMessage.ShowQuestion("Bạn muốn thoát không?", (msg) =>
            {
                this.Close();
            });
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
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
                    if (_onAddUser != null)
                    {
                        _onAddUser(sender, e);
                    }
                    if (_state == (int)MT.Library.Enummation.MTEntityState.Add)
                    {
                        MMessage.ShowQuestion("Bạn có muốn thêm nữa không?", (msg) =>
                        {
                            this.ResetForm();
                            return;
                        },()=>
                        {
                            this.Close();
                        });
                    }
                    else
                    {
                        this.Close();
                    }
                }
                else
                {
                    MMessage.ShowWarning(rs.UserMsg);
                }
            }
            catch (Exception ex)
            {
                MMessage.ShowError(ex.Message);
            }
        }

        private void gunaLinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!CommonFnUI.CheckPermission(MT.Data.FormUIHandle.MSC_USER, MT.Library.Enummation.PermissionValue.Add))
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
                        MMessage.ShowWarning("Tệp tin kh\x00f4ng tồn tại!");
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
            if (!CommonFnUI.CheckPermission(MT.Data.FormUIHandle.MSC_USER, MT.Library.Enummation.PermissionValue.Add))
            {
                MMessage.ShowWarning(MT.Library.CommonKey.MsgNotPermission);
                return;
            }
            this.picImage.Image = FormUI.Properties.Resources.Login;
        }

        private void frmAddUser_Load(object sender, EventArgs e)
        {
            Guna.UI.Lib.GraphicsHelper.ShadowForm(this);
            LogHelper.AddEvent(this.UUID, this.Program);
            BindData();

        }
        private void frmAddUser_FormClosed(object sender, FormClosedEventArgs e)
        {
            LogHelper.UpdateEvent(this.UUID);
            this.Dispose();
        }

        private void cboFullName_EditValueChanged(object sender, EventArgs e)
        {
            if (!cboFullName.ReadOnly)
            {
                MT.Data.BO.DM_CanBo dM_CanBo = cboFullName.GetRecordSelected<MT.Data.BO.DM_CanBo>();

                mtreeLookUpDonVi.EditValue = dM_CanBo?.sDM_DonVi_Id;
            }

        }
        #endregion


    }
}
