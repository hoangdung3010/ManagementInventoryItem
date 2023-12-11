using DevExpress.XtraBars;
using DevExpress.XtraSplashScreen;
using MT.Data.Rep;
using MT.Library;
using MT.Library.Log;
using MT.Library.UW;
using MTControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace FormUI
{
    public partial class frmPrivilege : FormUI.FormUIBase
    {
        #region"Property"
        private Dictionary<string, Guna.UI.WinForms.GunaLabel> dicLabels = new Dictionary<string, Guna.UI.WinForms.GunaLabel>();

        private Dictionary<string, Guna.UI.WinForms.GunaWinSwitch> dicGunaWinSwitchs = new Dictionary<string, Guna.UI.WinForms.GunaWinSwitch>();

        private RolePermission _rolePermission;

        private Guid _roleId;

        public List<RolePermission> _rolePermissions;

        private Dictionary<string, Guna.UI.WinForms.GunaLabel> dicaLabelRightDot = new Dictionary<string, Guna.UI.WinForms.GunaLabel>();

        private Dictionary<string, PopupMenu> dicPopup = new Dictionary<string, PopupMenu>();

        private bool _isView;
        private string _roleName;

        private IOverlaySplashScreenHandle _overlaySplashScreenHandle=null;
        BarManager _barManagerPermission;

        #endregion
        #region"Contructor"
        public frmPrivilege(Guid roleId, string roleName, bool isView = false)
        {
            InitializeComponent();
            _roleId = roleId;
            _isView = isView;
#if DEBUG
            _isView = false;
#endif

            _roleName = roleName;

            this.Program = $"Phân theo cho vai trò <{_roleName}>";
        }

        #endregion
        #region"Sub/Func"
        private void ShowSavePermission(RolePermission rolePermission, Guna.UI.WinForms.GunaLabel gunaLabel)
        {
            var permission = _rolePermissions.Find(m => m.FormId == rolePermission.FormId);
            if (permission == null)
            {
                permission = new RolePermission { FormId = rolePermission.FormId };

                SessionData.RolePermissions.Add(permission);
            }
            frmSavePermission frmSavePermission = new frmSavePermission(this, _roleId,_roleName, rolePermission, gunaLabel);
            frmSavePermission.OnChangePermission = new EventHandler(onChangePermission);
            frmSavePermission.ShowDialog();
        }

        private void DrawTreeMenu(List<RolePermission> originRolePermissions, List<RolePermission> userPermissions, int level = 0)
        {
            if (userPermissions == null)
            {
                return;
            }

            foreach (var item in userPermissions)
            {
                if (item.IsActive)
                {
                    continue;
                }

                item.IsActive = true;
                Guna.UI.WinForms.GunaPanel gunaPanel = new Guna.UI.WinForms.GunaPanel();
                gunaPanel.Width = flowLayoutPanelPermission.Width;
                gunaPanel.AutoSize = true;

                gunaPanel.Margin = new Padding(0, 0, 0, 0);
                SplitContainer splitContainer = new SplitContainer();
                splitContainer.FixedPanel = FixedPanel.Panel1;
                splitContainer.Dock = DockStyle.Fill;

                gunaPanel.Controls.Add(splitContainer);

                flowLayoutPanelPermission.Controls.Add(gunaPanel);

                gunaPanel.MinimumSize = new Size(flowLayoutPanelPermission.Width, 40);

                splitContainer.SplitterDistance = splitContainer.Width - splitContainer.SplitterWidth - 560;

                Guna.UI.WinForms.GunaLabel gunaLabel = new Guna.UI.WinForms.GunaLabel();
                gunaLabel.Location = new Point(16 + (level * 20), 10);
                gunaLabel.Text = item.FormName.ToUpper();
                gunaLabel.Tag = item.FormId;
                gunaLabel.AutoSize = true;
                if (level == 0)
                {
                    gunaLabel.ForeColor = System.Drawing.Color.CornflowerBlue;
                    gunaLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
                }
                else
                {
                    gunaLabel.ForeColor = System.Drawing.Color.Black;
                    gunaLabel.Font = new System.Drawing.Font("Segoe UI", (10 - level), System.Drawing.FontStyle.Bold);
                }


                splitContainer.Panel1.Controls.Add(gunaLabel);

                FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();
                flowLayoutPanel.FlowDirection = FlowDirection.LeftToRight;
                flowLayoutPanel.AutoSize = true;
                flowLayoutPanel.Location = new Point(0, 20);
                flowLayoutPanel.Dock = DockStyle.Fill;

                splitContainer.Panel2.Controls.Add(flowLayoutPanel);

                Guna.UI.WinForms.GunaWinSwitch winSwitch = new Guna.UI.WinForms.GunaWinSwitch();

                flowLayoutPanel.Controls.Add(winSwitch);
                winSwitch.Tag = item;
                winSwitch.Click += new EventHandler(winSwitch_Click);
                winSwitch.Enabled = !_isView;
                dicGunaWinSwitchs.Add(item.FormId, winSwitch);

                Guna.UI.WinForms.GunaLabel gunaLabelRight = new Guna.UI.WinForms.GunaLabel();

                flowLayoutPanel.Controls.Add(gunaLabelRight);
                gunaLabelRight.Margin = new Padding(0, 3, 0, 0);
                gunaLabelRight.Text = "Q";
                gunaLabelRight.AutoSize = true;

                Guna.UI.WinForms.GunaLabel _gunaLabelRightDot = new Guna.UI.WinForms.GunaLabel();

                flowLayoutPanel.Controls.Add(_gunaLabelRightDot);
                _gunaLabelRightDot.Margin = new Padding(0, 0, 0, 0);
                _gunaLabelRightDot.Text = "...";
                _gunaLabelRightDot.AutoSize = true;
                _gunaLabelRightDot.ForeColor = System.Drawing.Color.Black;
                _gunaLabelRightDot.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold);
                _gunaLabelRightDot.Cursor = System.Windows.Forms.Cursors.Hand;
                _gunaLabelRightDot.MouseUp += new MouseEventHandler(popupMenuPermission_MouseUp);
                _gunaLabelRightDot.Tag = item;
                dicaLabelRightDot.Add(item.FormId, _gunaLabelRightDot);
                List<string> permissionNames = new List<string>();


                foreach (int itemPermission in Enum.GetValues(typeof(MT.Library.Enummation.PermissionValue)))
                {
                    if ((item.MaxPermission & itemPermission) == itemPermission && (item.Permission & itemPermission) == itemPermission)
                    {
                        permissionNames.Add(MT.Library.SessionData.DicPermissionName[itemPermission]);
                    }

                }

                if (permissionNames.Count > 0)
                {
                    winSwitch.Checked = true;
                }
                if (permissionNames.Count > 9)
                {
                    _gunaLabelRightDot.Show();
                    gunaLabelRight.Text = string.Join(", ", permissionNames.Skip(0).Take(9));
                }
                else
                {
                    _gunaLabelRightDot.Hide();
                    gunaLabelRight.Text = string.Join(", ", permissionNames);
                }

                _barManagerPermission = new BarManager();
                _barManagerPermission.Form = this;

                var _popupMenuPermission = new PopupMenu(_barManagerPermission);

                dicPopup.Add(item.FormId, _popupMenuPermission);

                if (permissionNames.Count > 9)
                {

                    var ps = permissionNames.Skip(9);
                    foreach (var p in ps)
                    {
                        var menuItemP = new BarButtonItem(_barManagerPermission, p);
                        _popupMenuPermission.AddItem(menuItemP);
                    }
                }


                dicLabels.Add(item.FormId, gunaLabelRight);

                FontAwesome.Sharp.IconPictureBox iconPictureBox = new FontAwesome.Sharp.IconPictureBox();
                iconPictureBox.BackColor = System.Drawing.Color.White;
                iconPictureBox.ForeColor = System.Drawing.SystemColors.ControlText;
                iconPictureBox.IconChar = FontAwesome.Sharp.IconChar.ChevronDown;
                iconPictureBox.IconColor = System.Drawing.SystemColors.ControlText;
                iconPictureBox.IconSize = 19;
                iconPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
                iconPictureBox.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
                iconPictureBox.Size = new System.Drawing.Size(28, 19);
                iconPictureBox.Click += new EventHandler(icon_Click_ShowSavePermission);
                iconPictureBox.Tag = item;
                flowLayoutPanel.Controls.Add(iconPictureBox);

                var childrens = originRolePermissions.FindAll(m => m.ParentId == item.Id && !m.IsActive && m.Id != item.Id)
                    .OrderBy(m => m.SortOrder).ToList();
                if (childrens != null && childrens.Count > 0)
                {
                    DrawTreeMenu(originRolePermissions,childrens, (level + 1));
                }
            }
        }

        public void SavePermission(RolePermission rolePermission, bool chked)
        {
            if (rolePermission != null)
            {

                RolePermissionRepository rolePermissionRepository = (RolePermissionRepository)DBContext.GetRep<RolePermissionRepository>();

                if (chked)
                {
                    rolePermission.Permission = rolePermission.MaxPermission;
                }
                else
                {
                    rolePermission.Permission = 0;
                }

                int oldPermission = rolePermissionRepository.GetPermissionValue(_roleId, rolePermission.FormId);
                rolePermissionRepository.SaveRolePemission(rolePermission.FormId, rolePermission.Permission, _roleId);
                //log
                string oldPermissionNames = string.Join(", ", GetPermissionNames(oldPermission));
                string newPermissionNames = string.Join(", ", GetPermissionNames(rolePermission.Permission));
                rolePermissionRepository.InsertAuditingLog("RolePermission", $"Phân quyền cho vai trò <{_roleName}>", "Sửa", $"Chức năng <{rolePermission.FormName}> thay đổi quyền từ <{oldPermissionNames}> thành <{newPermissionNames}>");

                if (chked)
                {

                    ShowLabelPermission(GetPermissionNames(rolePermission.MaxPermission), rolePermission.FormId);
                }
                else
                {
                    dicLabels[rolePermission.FormId].Text = string.Empty;
                    dicGunaWinSwitchs[rolePermission.FormId].Checked = false;
                }

                if (!chked)
                {
                    var childrens = _rolePermissions.FindAll(m => m.ParentId == rolePermission.Id);
                    if (childrens != null && childrens.Count>0)
                    {
                        foreach (var item in childrens)
                        {
                            SavePermission(item, chked);
                            dicGunaWinSwitchs[item.FormId].Checked = false;
                        }
                    }
                    else
                    {
                        ShowLabelPermission(new List<string>(), rolePermission.FormId);
                    }
                }

            }
        }

        void ShowLabelPermission(List<string> permissionNames,string formId)
        {
            if (permissionNames.Count > 9)
            {
                dicLabels[formId].Text = string.Join(", ", permissionNames.Skip(0).Take(7));
                dicaLabelRightDot[formId].Show();
                var ps = permissionNames.Skip(9);
                dicPopup[formId].ItemLinks.Clear();
                foreach (var p in ps)
                {
                    var menuItemP = new BarButtonItem(_barManagerPermission, p);
                    dicPopup[formId].AddItem(menuItemP);
                }
            }
            else
            {
                dicaLabelRightDot[formId].Hide();
                dicLabels[formId].Text = string.Join(", ", permissionNames);
            }
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

        private void popupMenuPermission_MouseUp(object sender, MouseEventArgs e)
        {
            Guna.UI.WinForms.GunaLabel label = sender as Guna.UI.WinForms.GunaLabel;
            if (e.Button == MouseButtons.Left)
            {
                MT.Library.RolePermission rolePermission = label.Tag as MT.Library.RolePermission;
                dicPopup[rolePermission.FormId].ShowPopup(Control.MousePosition);
            }
        }

        /// <summary>
        /// Hiển thị form permission
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void icon_Click_ShowSavePermission(object sender, EventArgs e)
        {
            if (_isView)
            {
                return;
            }
            FontAwesome.Sharp.IconPictureBox iconPictureBox = sender as FontAwesome.Sharp.IconPictureBox;
            MT.Library.RolePermission rolePermission = iconPictureBox.Tag as MT.Library.RolePermission;
            
            var parent = _rolePermissions.Find(m => m.Id == rolePermission.ParentId);
            if (parent == null || dicGunaWinSwitchs[parent.FormId].Checked)
            {
                _rolePermission = rolePermission;
                ShowSavePermission(_rolePermission, dicLabels[rolePermission.FormId]);
            }
            else
            {
                if (parent != null)
                {
                    MMessage.ShowWarning($"Bạn phải cấp quyền xem cho chức năng <{parent.FormName}> trước khi thực hiện chức năng này.");
                }
                
            }
              
        }

        private void winSwitch_Click(object sender, EventArgs e)
        {
            Guna.UI.WinForms.GunaWinSwitch gunaWinSwitch = sender as Guna.UI.WinForms.GunaWinSwitch;
            MT.Library.RolePermission rolePermission = gunaWinSwitch.Tag as MT.Library.RolePermission;
            if (!gunaWinSwitch.Checked)
            {
                var firstChildren = _rolePermissions.Find(m => m.ParentId == rolePermission.Id);
                if (firstChildren != null)
                {
                    MMessage.ShowQuestion($"Nếu bạn cấm quyền xem chức năng <{rolePermission.FormName}> thì tất cả các chức năng con cũng sẽ bị cấm quyền.Bạn có chắc chắn không?(Y/N)", (msg) =>
                    {
                        SavePermission(rolePermission, false);

                    }, () =>
                    {
                        gunaWinSwitch.Checked = true;
                    });
                }
                else
                {
                    SavePermission(rolePermission, false);
                   
                }
               
            }
            else
            {
                var parent = _rolePermissions.Find(m => m.Id == rolePermission.ParentId);
                if(parent!=null && !dicGunaWinSwitchs[parent.FormId].Checked)
                {
                    dicGunaWinSwitchs[rolePermission.FormId].Checked = false;
                }
                else
                {
                    SavePermission(rolePermission, true);
                }
            }
        }

        private void onChangePermission(object sender, EventArgs e)
        {
            var userPermission =_rolePermissions.Find(m => m.FormId == this._rolePermission.FormId);
            if (userPermission == null ||userPermission.Permission == 0)
            {
                dicGunaWinSwitchs[userPermission.FormId].Checked = false;
                dicaLabelRightDot[userPermission.FormId].Hide();
                return;
            }

            dicGunaWinSwitchs[this._rolePermission.FormId].Checked = true;

            List<string> permissionNames = new List<string>();
            foreach (int item in Enum.GetValues(typeof(MT.Library.Enummation.PermissionValue)))
            {
                if ((this._rolePermission.MaxPermission & item) == item
                    && (userPermission.Permission & item) == item)
                {
                    permissionNames.Add(MT.Library.SessionData.DicPermissionName[item]);
                }

            }

            ShowLabelPermission(permissionNames, userPermission.FormId);
        }

        private void frmPrivilege_Load(object sender, EventArgs e)
        {
            Guna.UI.Lib.GraphicsHelper.ShadowForm(this);
          
            LogHelper.AddEvent(this.UUID,this.Program);

            lblPrivilegeList.Text = $"DANH SÁCH QUYỀN CỦA VAI TRÒ <{_roleName}>".ToUpper();

            if (!backgroundWorkerLoadMenu.IsBusy)
            {
                _overlaySplashScreenHandle= CommonFnUI.ShowProgress(flowLayoutPanelPermission);
                backgroundWorkerLoadMenu.RunWorkerAsync();
            }
        }

        private void pic_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPrivilege_FormClosed(object sender, FormClosedEventArgs e)
        {
            LogHelper.UpdateEvent(this.UUID);
            base.Dispose();
        }

        private void backgroundWorkerLoadMenu_DoWork(object sender, DoWorkEventArgs e)
        {
            var rolePermissionRepository = (RolePermissionRepository)DBContext.GetRep<RolePermissionRepository>();
            e.Result = rolePermissionRepository.GetRolePemissions(_roleId);
        }

        private void backgroundWorkerLoadMenu_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                _rolePermissions = e.Result as List<MT.Library.RolePermission>;
                DrawTreeMenu(_rolePermissions,_rolePermissions);
            }
            else
            {
                MMessage.ShowError(e.Error.Message);
            }
            CommonFnUI.CloseProgress(_overlaySplashScreenHandle);
        }
#endregion


    }
}
