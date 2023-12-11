using MT.Data;
using MT.Data.BO;
using MT.Data.Rep;
using MT.Library.Log;
using MTControl;
using System;
using System.Windows.Forms;

namespace FormUI
{
    public partial class frmAddRole : FormUI.FormUIBase
    {
        #region"Property"
        EventHandler _onaddRole;//dung de truyen du lieu qua frmchucvu
        int _state;//co xac dinh la insert hay edit
        SysRole _et;

        public EventHandler OnAddRole
        {
            set
            {
                _onaddRole = value;
            }
        }

        #endregion
        #region"Contructor"
        public frmAddRole(int _state)
        {
            InitializeComponent();
            this.AcceptButton = btnSave;
            this._state = _state;
            Init();
        }

        public frmAddRole(SysRole et, int state)
        {
            InitializeComponent();

            this.AcceptButton = btnSave;
            this._state = state;
            this._et = et;
            Init();
            BindData();
        }
        #endregion

        #region"Sub/Func"
        /// <summary>
        /// Khởi tạo các thông tin trên form
        /// </summary>     
        private void Init()
        {

            if (_state == (int)MT.Library.Enummation.MTEntityState.Add)
            {
                _et = new SysRole();
                this.lblTitle.Text = "Thêm mới vai trò".ToUpper();
            }
            else
            {
                this.lblTitle.Text = "Sửa vai trò".ToUpper();
                string roleName = this._et.RoleName;
                if (this._et.IsSystem)
                {
                    rdAvaiable.Enabled = false;
                    rdUnAvaiable.Enabled = false;
                }
            }

            this.Program = this.Text;
        }

        /// <summary>
        /// Reset giá trị trên form
        /// </summary>
        public void ResetForm()
        {
            _et = new SysRole();
            txtRoleName.Text = "";
            txtRoleName.Focus();
        }

        /// <summary>
        /// Bind data cho đối tượng
        /// </summary>
        /// <returns></returns>
        private new bool Validate()
        {
          
            string roleName = txtRoleName.Text;
            
            if (string.IsNullOrEmpty(roleName))
            {
                MMessage.ShowWarning("Tên vai trò không được trống");
                this.ActiveControl = txtRoleName;
                return false;
            }
            SysRoleRepository sysRoleRepository=  (SysRoleRepository)DBContext.GetRep<SysRoleRepository>();
            if (sysRoleRepository.CheckExists(roleName,_et.Id))
            {
                MMessage.ShowWarning("Vai trò đã tồn tại trong hệ thống");
                this.ActiveControl = txtRoleName;
                return false;
            }
            return true;
        }

        /// <summary>
        /// Bind data cho đối tượng
        /// </summary>
        /// <returns></returns>
        private void BindData()
        {
            txtRoleName.Text = _et.RoleName;
        }
        /// <summary>
        /// Bind data cho đối tượng
        /// </summary>
        /// <returns></returns>
        private void MappingDataToEntity()
        {
            var now = SysDateTime.Instance.Now();
            _et.RoleName =MT.Library.Utility.AddChar(txtRoleName.Text.Trim());

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
            bool kq = false;
            try
            {
                if (!Validate())
                {
                    return;
                }

                MappingDataToEntity();

                SysRoleRepository sysRoleRepository = (SysRoleRepository)DBContext.GetRep<SysRoleRepository>();
                _et.MTEntityState = (MT.Library.Enummation.MTEntityState)_state;
                var rs = sysRoleRepository.SaveData(_et);
                if (rs.Success)
                {
                    if (_onaddRole != null)
                    {
                        _onaddRole(sender,e);
                    }
                    if (_state == (int)MT.Library.Enummation.MTEntityState.Add)
                    {
                        MMessage.ShowQuestion("Bạn có muốn thêm nữa không?", (msg) =>
                        {
                            this.ResetForm();
                            return;
                        });
                    }
                    else
                    {
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.AddError(ex, "Lưu thất bại");
            }
        }

        private void frmAddRooms_Load(object sender, EventArgs e)
        {
            Guna.UI.Lib.GraphicsHelper.ShadowForm(this);
            LogHelper.AddEvent(this.UUID,this.Program);
        }

        private void frmAddRooms_FormClosed(object sender, FormClosedEventArgs e)
        {
            LogHelper.UpdateEvent(this.UUID);
            this.Dispose();
        }

        #endregion


    }
}
