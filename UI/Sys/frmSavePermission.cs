using MT.Data.Rep;
using MT.Library;
using MT.Library.Log;
using MT.Library.UW;
using MTControl;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace FormUI
{
    public partial class frmSavePermission : FormUI.FormUIBase
    {
        #region"Property"

        private RolePermission _rolePermission;

        Guna.UI.WinForms.GunaLabel _gunaLabel;

        private List<Guna.UI.WinForms.GunaCheckBox> gunaCheckBoxes = new List<Guna.UI.WinForms.GunaCheckBox>();

        private Guid _roleId;
        private string _roleName;

        EventHandler _onChangePermission;

        private frmPrivilege _frmParent;
        public EventHandler OnChangePermission
        {
            set
            {
                _onChangePermission = value;
            }
        }
        #endregion
        #region"Contructor"
        public frmSavePermission(frmPrivilege frm,Guid roleId,string roleName, MT.Library.RolePermission rolePermission, Guna.UI.WinForms.GunaLabel gunaLabel)
        {
            InitializeComponent();
            this._rolePermission = rolePermission;
            _gunaLabel = gunaLabel;
            _roleId = roleId;
            _roleName = roleName;
            _frmParent = frm;
            Init();
        }

        #endregion
        #region"Sub/Func"
        private void Init()
        {
            this.Program = $"Gán quyền cho vai trò <{_roleId}>";
            flowLayoutPanelPermission.Controls.Clear();
            lblTitle.Text = this._rolePermission.FormName;
            foreach (int item in Enum.GetValues(typeof(MT.Library.Enummation.PermissionValue)))
            {
                if ((this._rolePermission.MaxPermission & item) == item)
                {
                    Guna.UI.WinForms.GunaCheckBox gunaCheckBox = new Guna.UI.WinForms.GunaCheckBox();
                    gunaCheckBox.Name = item.ToString();
                    gunaCheckBox.Text = MT.Library.SessionData.DicPermissionName[item];
                    gunaCheckBox.Tag = item.ToString();
                    gunaCheckBox.CheckedChanged += new EventHandler(gunaCheckBox_CheckedChanged);
                    if ((this._rolePermission.Permission & item) == item)
                    {
                        gunaCheckBox.Checked = true;
                    }
                    flowLayoutPanelPermission.Controls.Add(gunaCheckBox);
                    gunaCheckBoxes.Add(gunaCheckBox);
                    
                }
            }


            if (this._rolePermission.Permission < (int)MT.Library.Enummation.PermissionValue.View)
            {
                foreach (var item in gunaCheckBoxes)
                {
                    if(int.Parse(item.Tag.ToString())!= (int)MT.Library.Enummation.PermissionValue.View) {
                        item.Enabled = false;
                    }
                }
            }
        }

        /// <summary>
        /// Đóng form
        /// </summary>
        private void CloseForm()
        {
            LogHelper.UpdateEvent(this.UUID);
        }

        /// <summary>
        /// Lấy về danh sách quyền
        /// </summary>
        /// <param name="permissionValue"></param>
        /// <returns></returns>
        List<string> GetPermissionNames(int permissionValue)
        {
            List<string> permissionNames = new List<string>();

            foreach (int item in Enum.GetValues(typeof(MT.Library.Enummation.PermissionValue)))
            {
                if ((permissionValue & item) == item)
                {
                    permissionNames.Add(MT.Library.SessionData.DicPermissionName[item]);
                }
            }

            return permissionNames;
        }
        #endregion
        #region"Event"

        private void gunaCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Guna.UI.WinForms.GunaCheckBox gunaCheckBox = sender as Guna.UI.WinForms.GunaCheckBox;
           
            if(int.Parse(gunaCheckBox.Tag.ToString()) == (int)MT.Library.Enummation.PermissionValue.View)
            {
                if (gunaCheckBox.Checked)
                {
                    foreach (var item in gunaCheckBoxes)
                    {
                        item.Enabled = true;
                    }
                }
                else
                {
                    foreach (var item in gunaCheckBoxes)
                    {
                        if(int.Parse(item.Tag.ToString())!= (int)MT.Library.Enummation.PermissionValue.View)
                        {
                            item.Checked = false;
                            item.Enabled = false;
                        }
                       
                    }
                    gunaCheckBox.Enabled = true;
                }
            }
            
        }
        private void frmSavePermission_Load(object sender, EventArgs e)
        {
            Guna.UI.Lib.GraphicsHelper.ShadowForm(this);
            LogHelper.AddEvent(this.UUID,this.Program);

           
        }

        private void pic_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSavePermission_FormClosed(object sender, FormClosedEventArgs e)
        {
            LogHelper.UpdateEvent(MT.Data.FormUIHandle.MSC_CHANGE_PASS);
            base.Dispose();
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            int permission = 0;
            foreach (var item in gunaCheckBoxes)
            {
                if (item.Checked)
                {
                    permission += int.Parse(item.Tag.ToString());
                }
            }
            if (permission > 0)
            {
                var rolePermissionRepository = (RolePermissionRepository)DBContext.GetRep<RolePermissionRepository>();
                int oldPermission = rolePermissionRepository.GetPermissionValue(_roleId, this._rolePermission.FormId);
                bool success = rolePermissionRepository.SaveRolePemission(this._rolePermission.FormId, permission, _roleId);
                if (success)
                {
                    //log
                    string oldPermissionNames = string.Join(", ", GetPermissionNames(oldPermission));
                    string newPermissionNames = string.Join(", ", GetPermissionNames(permission));
                    rolePermissionRepository.InsertAuditingLog("RolePermission", $"Phân quyền cho vai trò <{_roleName}>", "Sửa", $"Chức năng <{this._rolePermission.FormName}> thay đổi quyền từ <{oldPermissionNames}> thành <{newPermissionNames}>");

                    this._rolePermission.Permission = permission;

                    _onChangePermission(sender, e);
                    this.Close();
                }
            }
            else
            {
                
                var firstChildren = _frmParent._rolePermissions.Find(m => m.ParentId == _rolePermission.Id);
                if (firstChildren != null)
                {
                    MMessage.ShowQuestion($"Nếu bạn cấm quyền xem chức năng <{_rolePermission.FormName}> thì tất cả các chức năng con cũng sẽ bị cấm quyền.Bạn có chắc chắn không?(Y/N)", (msg) =>
                    {
                        this.Close();
                        _frmParent.SavePermission(_rolePermission, false);
                    });
                }
                else
                {
                    this.Close();
                    _frmParent.SavePermission(_rolePermission, false);

                }

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion


    }
}
