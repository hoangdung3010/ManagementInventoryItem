using DevExpress.XtraBars;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Localization;
using FontAwesome.Sharp;
using MT.Data.BO;
using MT.Data.Rep;
using MT.Library.Log;
using MTControl;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using MT.Library;

namespace FormUI
{
    public partial class frmMain : FormUI.FormUIBase
    {

        public Form currentChildForm;
        BarManager _barManager;

        PopupMenu _popupMenu;

        BarButtonItem _changePass;

        BarButtonItem _logout;

        /// <summary>
        /// Danh sách các button
        /// </summary>
        Dictionary<int, IconButton> _dicMenuItems = new Dictionary<int, IconButton>();

        /// <summary>
        /// Danh sách các button
        /// </summary>
        Dictionary<int, System.Windows.Forms.Panel> _dicSubMenus = new Dictionary<int, System.Windows.Forms.Panel>();

        public frmMain()
        {
            
            InitializeComponent();
            Init();
            _barManager = new BarManager();
            _barManager.Form = this;

            _popupMenu = new PopupMenu(_barManager);

            _changePass = new BarButtonItem(_barManager, "Thay đổi mật khẩu");
            _changePass.ItemClick -= _changePass_ItemClick;
            _changePass.ItemClick += _changePass_ItemClick;
            _logout = new BarButtonItem(_barManager, "Đăng xuất");
            _logout.ItemClick -= _logout_ItemClick;
            _logout.ItemClick += _logout_ItemClick;
            _popupMenu.AddItems(new BarButtonItem[] { _changePass, _logout });

            this.Name = Guid.NewGuid().ToString();

            this.Program = "Đăng nhập thành công";
        }



        #region"Sub/Func"
       
        /// <summary>
        /// Hàm khởi tạo các giá trị ban đâu
        /// </summary>
        private void Init()
        {
            lblMainTitle.Hide();
            btn_InfoUser.AutoSize = true;
            btn_InfoUser.Text = $"{MT.Library.SessionData.UserName}";
            var sysMenuRep = (SysMenuRepository)DBContext.GetRep<SysMenuRepository>();

            pnlLeftMenuMain.Controls.Clear();

            var sysMenus = sysMenuRep.GetSysMenus();
            RenderMenu(pnlLeftMenuMain, sysMenus);
            RegisterEventMenuItem();

            SetShowSubMenuDefault();
        }

        /// <summary>
        /// Hàm render Menu
        /// </summary>
        /// <param name="datas">Danh sách menu</param>
        /// <param name="level"></param>
        private void RenderMenu(Panel root, IList<SysMenu> datas, int level = 0,int index=0)
        {
            if (datas != null && datas.Count > 0)
            {
                var sortOrderDatas = datas.OrderByDescending(m => m.SortOrder);
                void AddButton(Panel rootButton,SysMenu sysMenu)
                {
                    IconButton iconButton = new IconButton();
                    iconButton.Cursor = System.Windows.Forms.Cursors.Hand;

                    iconButton.FlatAppearance.BorderSize = 0;
                    iconButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(117)))), ((int)(((byte)(188)))));
                    iconButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                    iconButton.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
                    iconButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    iconButton.ForeColor = System.Drawing.Color.WhiteSmoke;
                    iconButton.IconChar =Utility.ParseEnum<FontAwesome.Sharp.IconChar>(sysMenu.IconCls, FontAwesome.Sharp.IconChar.Circle);
                    iconButton.IconColor = System.Drawing.Color.WhiteSmoke;
                    iconButton.IconSize = 20;
                    iconButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
                    iconButton.Name = $"btnMenuItem_{sysMenu.Id}";
                    int paddingLeft = level * 4 + 4;
                    iconButton.Padding = new System.Windows.Forms.Padding(paddingLeft, 0, 10, 0);
                    iconButton.Rotation = 0D;
                    iconButton.TabIndex = index;
                    iconButton.Text = sysMenu.MenuName;
                    iconButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                    iconButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
                    iconButton.UseVisualStyleBackColor = true;
                    iconButton.Height = 30;
                    iconButton.Tag = sysMenu;
                    if (level == 0)
                    {
                        iconButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
                        iconButton.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    }
                    else
                    {
                        iconButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(66)))));
                        iconButton.ForeColor = System.Drawing.Color.LightGray;
                        iconButton.Padding = new System.Windows.Forms.Padding(20, 0, 10, 0);
                        iconButton.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    }
                    rootButton.Controls.Add(iconButton);
                    iconButton.Dock = System.Windows.Forms.DockStyle.Top;

                    _dicMenuItems.Add(sysMenu.Id, iconButton);
                }

                foreach (var item in sortOrderDatas)
                {
                   var roleP= SessionData.RolePermissions.Find(m => m.FormId == item.FormName);
                    if(roleP!=null && ((roleP.Permission & (int)MT.Library.Enummation.PermissionValue.View) == (int)MT.Library.Enummation.PermissionValue.View))
                    {
                        //Kiểm tra có con không
                        if (!item.Leaf)
                        {
                            index++;
                            var panelSubMenu = new System.Windows.Forms.Panel();
                            panelSubMenu.Name = $"panelSubMenu_{item.Id}";
                            panelSubMenu.TabIndex = index;
                            panelSubMenu.Tag = item;
                            panelSubMenu.AutoSize = true;
                            pnlLeftMenuMain.Controls.Add(panelSubMenu);
                            panelSubMenu.Dock = System.Windows.Forms.DockStyle.Top;
                            panelSubMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(66)))));
                            panelSubMenu.Visible = false;
                            _dicSubMenus.Add(item.Id, panelSubMenu);
                            IList<SysMenu> childrens = item.Data as IList<SysMenu>;
                            RenderMenu(panelSubMenu, childrens, level + 1, 0);
                            AddButton(root, item);
                        }
                        else
                        {
                            AddButton(root, item);
                            index++;
                        }
                    }
                }
            }
            else
            {
                level = 0;
            }
        }

        /// <summary>
        /// Hiển thị menu con mặc định khi lần đầu lóa
        /// </summary>
        private void SetShowSubMenuDefault()
        {
            if (_dicSubMenus.Count > 0)
            {
                ShowSubMenu(_dicSubMenus.Values.LastOrDefault());
            }
        }

        /// <summary>
        /// Thực hiện ẩn hết menu con
        /// </summary>
        private void RegisterEventMenuItem()
        {
            foreach (var item in _dicMenuItems)
            {
                item.Value.Click -= MenuItem_Click;
                item.Value.Click += MenuItem_Click;
            }
        }

        /// <summary>
        /// Xử lý event click vào menu cha thì hiển thị menu con
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                IconButton iconButton = sender as IconButton;
                if (iconButton == null)
                {
                    return;
                }

                SysMenu sysMenu = iconButton.Tag as SysMenu;
                if (sysMenu == null)
                {
                    return;
                }

                if (_dicSubMenus.ContainsKey(sysMenu.Id))
                {
                    ShowSubMenu(_dicSubMenus[sysMenu.Id]);
                }
                else
                {
                    ActiveMenuItem(iconButton);
                    if (currentChildForm != null)
                    {
                        currentChildForm.Dispose();
                        currentChildForm = null;
                    }
                    Type type = Type.GetType($"FormUI.{sysMenu.FormName},FormUI");
                    if (type == null)
                    {
                        throw new Exception($"{sysMenu.FormName} not exists");
                    }

                    currentChildForm = (Form)Activator.CreateInstance(type);

                    if (currentChildForm != null)
                    {
                        if (sysMenu.IsShowDialog)
                        {
                            currentChildForm.StartPosition = FormStartPosition.CenterParent;
                            currentChildForm.ShowDialog();
                            currentChildForm.Dispose();
                        }
                        else
                        {
                            lblMainTitle.Show();
                            lblMainTitle.Text = sysMenu.MenuName;
                            currentChildForm = CommonFnUI.OpenChildForm(this.pnlBody, currentChildForm);
                        }
                        
                    }
                }
            }
            catch (Exception ex)
            {

                MMessage.ShowError(ex.Message);
            }
        }

        IconButton currentMenuItem = null;

        /// <summary>
        /// Thực hiện active menuitem được chọn
        /// </summary>
        /// <param name="menuActive"></param>
        private void ActiveMenuItem(IconButton menuActive)
        {
            if (currentMenuItem != null)
            {
                currentMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(66)))));
            }
            menuActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(117)))), ((int)(((byte)(188)))));
            currentMenuItem = menuActive;
        }

        /// <summary>
        /// Thực hiện ẩn hết menu con
        /// </summary>
        private void HideSubMenu()
        {
            foreach (var item in _dicSubMenus)
            {
                if (item.Value.Visible)
                {
                    item.Value.Visible = false;
                }
            }
        }

        /// <summary>
        /// Thực hiện hiển thị hết menu con
        /// </summary>
        private void ShowSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                HideSubMenu();
                subMenu.Visible = true;
            }
            else
            {
                HideSubMenu();
            }
        }


        /// <summary>
        /// Hủy bỏ event đã đăng ký
        /// </summary>
        public void UnRegisterEvent()
        {
            _changePass.ItemClick -= _changePass_ItemClick;
            _logout.ItemClick -= _logout_ItemClick;
            this.Load -= frmMain_Load;
            this.FormClosing -= frmMain_FormClosing;
            this.FormClosed -= frmMain_FormClosed;
        }

        /// <summary>
        /// Kiểm tra xem có hiển thị màn hình yêu cầu đổi mật khẩu hay không
        /// </summary>
        /// <returns>=true Yêu cầu đổi, ngược lại không</returns>
        private bool IsShowFormChangePass()
        {
            bool isChange = false;
            try
            {
                MT.Library.DBOption dBOptionViewModel = MT.Library.SessionData.DBOptions?.Find(m=>m.OptionId.Equals(MT.Library.CommonKey.MonthsChangePass,StringComparison.OrdinalIgnoreCase));

                int monthsChange = 24;// truong
                if (dBOptionViewModel != null)
                {
                    monthsChange = int.Parse(dBOptionViewModel.OptionValue);
                }
                var sysUserRepository = (SysUserRepository)DBContext.GetRep<SysUserRepository>();
                DateTime changePass = sysUserRepository.GetPasswordChangeTime();

                TimeSpan timeSpan = SysDateTime.Instance.Now().Subtract(changePass);
                const double daysToMonths = 30.4368499;
                double months = (double)timeSpan.Days / daysToMonths;
                if (months > monthsChange)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                MMessage.ShowError(ex.Message);
            }
            return isChange;
        }

        /// <summary>
        /// Hàm ẩn hiện toolbar download file
        /// </summary>
        /// <param name="isShow">=true hiển thị, ngược lại ko</param>
        private void ShowOrHideToolbarDownload(bool isShow)
        {
            if (isShow)
            {
                this.splitContainerMain.Panel2Collapsed = false;
                this.splitContainerMain.Panel2.Show();
            }
            else
            {
                this.splitContainerMain.Panel2Collapsed = true;
                this.splitContainerMain.Panel2.Hide();
            }
            
        }

        
        #endregion

        #region"Event"

        /// <summary>
        /// Event đóng form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pic_Exit_Click(object sender, EventArgs e)
        {
            try
            {
                pic_Exit.Enabled = false;
                MMessage.ShowQuestion("Bạn có chắc muốn thoát khỏi ứng dụng này không?(Y/N)", (msg) =>
                {
                    LogHelper.UpdateEvent(MT.Data.FormUIHandle.MSC_MAIN);

                    this.Close();
                });
                pic_Exit.Enabled = true;
            }
            catch (Exception ex)
            {
                MMessage.ShowError(ex.Message);
            }
        }


        private  void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                
                CommonFnUI.Main = this;
                ShowOrHideToolbarDownload(true);
                LogHelper.AddEvent(this.UUID, this.Program);

                lblMainTitle.Show();
                lblMainTitle.Text = "Bàn làm việc";
                currentChildForm = new FormUI.frmOrverview();
                currentChildForm = CommonFnUI.OpenChildForm(this.pnlBody, currentChildForm);

                lblVersion.Text = MT.Library.SessionData.VersionName;

                string strData = "Dữ liệu: Ban cơ yếu";
                switch (MT.Library.SessionData.OrganizationUnitType)
                {
                    case (int)MT.Data.OrganizationUnitType.BCY:
                        strData = "Dữ liệu: Ban cơ yếu";
                        break;
                    case (int)MT.Data.OrganizationUnitType.CA:
                        strData = "Dữ liệu: Công an";
                        break;
                    case (int)MT.Data.OrganizationUnitType.QĐ:
                        strData = "Dữ liệu: Quân đội";
                        break;
                    case (int)MT.Data.OrganizationUnitType.ĐCQ:
                        strData = "Dữ liệu: Đảng chính quyền";
                        break;
                }

                lblDescription.Text = $"Tài khoản <{MT.Library.SessionData.UserName}>, thuộc đơn vị <{MT.Library.SessionData.OrganizationUnitName}> đăng nhập lúc <{SysDateTime.Instance.Now().ToString("dd/MM/yyyy hh:mm:ss")}>. {strData}";

                //Active bàn làm việc
                if (_dicMenuItems?.Count>0 && _dicMenuItems.ContainsKey(70))
                {
                    ActiveMenuItem(_dicMenuItems[70]);
                }

                //Check xem có phải đổi mật khẩu không
                if (IsShowFormChangePass())
                {
                    frmChangePass frm = new frmChangePass();
                    frm.SetTitle("YÊU CẦU ĐỔI MẬT KHẨU");
                    frm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MMessage.ShowError(ex.Message);
            }
        }
        
        private void btn_InfoUser_MouseClick(object sender, MouseEventArgs e)
        {
            _popupMenu.ShowPopup(Control.MousePosition);
        }
        private void _logout_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                LogHelper.UpdateEvent(this.UUID);
                this.Hide();
                this.Close();
                using (frmLogin frm = new frmLogin())
                {
                    frm.ShowDialog();
                    frm.BringToFront();
                }
            }
            catch (Exception ex)
            {
                MMessage.ShowError(ex.Message);
            }
        }

        private void _changePass_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmChangePass frm = new frmChangePass();
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MMessage.ShowError(ex.Message);
            }
        }


        private void pic_Minimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        #endregion

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                var handler = CommonFnUI.ShowProgress(pnlBody);
                try
                {
                    LogHelper.UpdateEvent(this.UUID);
                }
                catch (Exception)
                {
                    //todo
                }
                this.Dispose();
                Application.Exit();
                CommonFnUI.CloseProgress(handler);
            }
            catch (Exception ex)
            {
                MMessage.ShowError(ex.Message);
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void iconBtnCollapseMenu_Click(object sender, EventArgs e)
        {
            if (!splitBody.Collapsed)
            {
                splitBody.CollapsePanel = DevExpress.XtraEditors.SplitCollapsePanel.Panel1;
                splitBody.SetPanelCollapsed(true);
            }
            else
            {
                splitBody.CollapsePanel = DevExpress.XtraEditors.SplitCollapsePanel.Panel1;
                splitBody.SetPanelCollapsed(false);
            }
        }

        private void iconSearchTonKHo_Click(object sender, EventArgs e)
        {
            using (frmTraCuuTonKho frm=new frmTraCuuTonKho())
            {
                frm.ShowDialog();
                frm.Dispose();
            }
        }

        private void btnAddRole_Click(object sender, EventArgs e)
        {
            using (frmTraCuuTonKho frm = new frmTraCuuTonKho())
            {
                frm.ShowDialog();
                frm.Dispose();
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
