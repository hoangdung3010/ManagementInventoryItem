namespace FormUI
{
    partial class ucUserDetail
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions3 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject9 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject10 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject11 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject12 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.btnChangePrivilege = new FontAwesome.Sharp.IconButton();
            this.picImage = new Guna.UI.WinForms.GunaPictureBox();
            this.lblAvatar = new Guna.UI.WinForms.GunaLabel();
            this.cboGroupUser = new Guna.UI.WinForms.GunaComboBox();
            this.lblGroup = new Guna.UI.WinForms.GunaLabel();
            this.gunaVSeparator3 = new Guna.UI.WinForms.GunaVSeparator();
            this.lblName = new Guna.UI.WinForms.GunaLabel();
            this.lblFullName = new Guna.UI.WinForms.GunaLabel();
            this.btnSave = new FontAwesome.Sharp.IconButton();
            this.btnDelUser = new FontAwesome.Sharp.IconButton();
            this.rdoUnActive = new Guna.UI.WinForms.GunaRadioButton();
            this.rdAvaiable = new Guna.UI.WinForms.GunaRadioButton();
            this.lblStatus = new Guna.UI.WinForms.GunaLabel();
            this.lblPass = new Guna.UI.WinForms.GunaLabel();
            this.linkChooseImage = new Guna.UI.WinForms.GunaLinkLabel();
            this.lblDelImage = new Guna.UI.WinForms.GunaLinkLabel();
            this.mtreeLookUpDonVi = new MTControl.MTreeLookUpEdit();
            this.mTreeLookUpEdit1TreeList = new DevExpress.XtraTreeList.TreeList();
            this.gunaLabel1 = new Guna.UI.WinForms.GunaLabel();
            this.txtPass = new MTControl.MTextEdit();
            this.txtUserName = new MTControl.MTextEdit();
            this.cboFullName = new MTControl.MGridLookUpEdit();
            this.mGridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnEmployeeAccessLevel = new FontAwesome.Sharp.IconButton();
            this.gunaLabel2 = new Guna.UI.WinForms.GunaLabel();
            this.txtEmail = new MTControl.MTextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mtreeLookUpDonVi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mTreeLookUpEdit1TreeList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboFullName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mGridLookUpEdit1View)).BeginInit();
            this.SuspendLayout();
            // 
            // btnChangePrivilege
            // 
            this.btnChangePrivilege.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChangePrivilege.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangePrivilege.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnChangePrivilege.IconChar = FontAwesome.Sharp.IconChar.Key;
            this.btnChangePrivilege.IconColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnChangePrivilege.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnChangePrivilege.IconSize = 20;
            this.btnChangePrivilege.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnChangePrivilege.Location = new System.Drawing.Point(115, 228);
            this.btnChangePrivilege.Name = "btnChangePrivilege";
            this.btnChangePrivilege.Size = new System.Drawing.Size(282, 38);
            this.btnChangePrivilege.TabIndex = 10;
            this.btnChangePrivilege.Text = "XEM QUYỀN";
            this.btnChangePrivilege.UseVisualStyleBackColor = true;
            this.btnChangePrivilege.Click += new System.EventHandler(this.btnChangePrivilege_Click);
            // 
            // picImage
            // 
            this.picImage.BaseColor = System.Drawing.Color.White;
            this.picImage.Image = global::FormUI.Properties.Resources.Login;
            this.picImage.Location = new System.Drawing.Point(522, 137);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(73, 67);
            this.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picImage.TabIndex = 69;
            this.picImage.TabStop = false;
            // 
            // lblAvatar
            // 
            this.lblAvatar.AutoSize = true;
            this.lblAvatar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblAvatar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblAvatar.Location = new System.Drawing.Point(438, 160);
            this.lblAvatar.Name = "lblAvatar";
            this.lblAvatar.Size = new System.Drawing.Size(56, 15);
            this.lblAvatar.TabIndex = 68;
            this.lblAvatar.Text = "Hình ảnh";
            // 
            // cboGroupUser
            // 
            this.cboGroupUser.BackColor = System.Drawing.Color.Transparent;
            this.cboGroupUser.BaseColor = System.Drawing.Color.White;
            this.cboGroupUser.BorderColor = System.Drawing.Color.Silver;
            this.cboGroupUser.BorderSize = 1;
            this.cboGroupUser.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboGroupUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGroupUser.FocusedColor = System.Drawing.Color.Empty;
            this.cboGroupUser.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboGroupUser.ForeColor = System.Drawing.Color.Black;
            this.cboGroupUser.FormattingEnabled = true;
            this.cboGroupUser.Location = new System.Drawing.Point(522, 96);
            this.cboGroupUser.Name = "cboGroupUser";
            this.cboGroupUser.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.cboGroupUser.OnHoverItemForeColor = System.Drawing.Color.White;
            this.cboGroupUser.Size = new System.Drawing.Size(271, 26);
            this.cboGroupUser.TabIndex = 5;
            // 
            // lblGroup
            // 
            this.lblGroup.AutoSize = true;
            this.lblGroup.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblGroup.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblGroup.Location = new System.Drawing.Point(438, 105);
            this.lblGroup.Name = "lblGroup";
            this.lblGroup.Size = new System.Drawing.Size(41, 15);
            this.lblGroup.TabIndex = 66;
            this.lblGroup.Text = "Nhóm";
            // 
            // gunaVSeparator3
            // 
            this.gunaVSeparator3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gunaVSeparator3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.gunaVSeparator3.LineColor = System.Drawing.Color.Silver;
            this.gunaVSeparator3.Location = new System.Drawing.Point(404, 13);
            this.gunaVSeparator3.Name = "gunaVSeparator3";
            this.gunaVSeparator3.Size = new System.Drawing.Size(18, 262);
            this.gunaVSeparator3.TabIndex = 65;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblName.Location = new System.Drawing.Point(16, 61);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(88, 15);
            this.lblName.TabIndex = 63;
            this.lblName.Text = "Tên  đăng nhập";
            // 
            // lblFullName
            // 
            this.lblFullName.AutoSize = true;
            this.lblFullName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblFullName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFullName.Location = new System.Drawing.Point(19, 24);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(45, 15);
            this.lblFullName.TabIndex = 61;
            this.lblFullName.Text = "Cán bộ";
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnSave.IconChar = FontAwesome.Sharp.IconChar.Save;
            this.btnSave.IconColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnSave.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSave.IconSize = 16;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.Location = new System.Drawing.Point(624, 228);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(154, 38);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "LƯU THÔNG TIN";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelUser
            // 
            this.btnDelUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelUser.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelUser.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnDelUser.IconChar = FontAwesome.Sharp.IconChar.TrashAlt;
            this.btnDelUser.IconColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnDelUser.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnDelUser.IconSize = 16;
            this.btnDelUser.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelUser.Location = new System.Drawing.Point(441, 228);
            this.btnDelUser.Name = "btnDelUser";
            this.btnDelUser.Size = new System.Drawing.Size(154, 38);
            this.btnDelUser.TabIndex = 9;
            this.btnDelUser.Text = "XÓA TÀI KHOẢN";
            this.btnDelUser.UseVisualStyleBackColor = true;
            this.btnDelUser.Click += new System.EventHandler(this.btnDelUser_Click);
            // 
            // rdoUnActive
            // 
            this.rdoUnActive.BackColor = System.Drawing.Color.WhiteSmoke;
            this.rdoUnActive.BaseColor = System.Drawing.SystemColors.Control;
            this.rdoUnActive.CheckedOffColor = System.Drawing.Color.Gray;
            this.rdoUnActive.CheckedOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(117)))), ((int)(((byte)(188)))));
            this.rdoUnActive.FillColor = System.Drawing.Color.White;
            this.rdoUnActive.Location = new System.Drawing.Point(624, 58);
            this.rdoUnActive.Name = "rdoUnActive";
            this.rdoUnActive.Size = new System.Drawing.Size(87, 20);
            this.rdoUnActive.TabIndex = 4;
            this.rdoUnActive.Text = "Tạm ngưng";
            // 
            // rdAvaiable
            // 
            this.rdAvaiable.BackColor = System.Drawing.Color.WhiteSmoke;
            this.rdAvaiable.BaseColor = System.Drawing.SystemColors.Control;
            this.rdAvaiable.Checked = true;
            this.rdAvaiable.CheckedOffColor = System.Drawing.Color.Gray;
            this.rdAvaiable.CheckedOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(117)))), ((int)(((byte)(188)))));
            this.rdAvaiable.FillColor = System.Drawing.Color.White;
            this.rdAvaiable.Location = new System.Drawing.Point(522, 58);
            this.rdAvaiable.Name = "rdAvaiable";
            this.rdAvaiable.Size = new System.Drawing.Size(82, 20);
            this.rdAvaiable.TabIndex = 3;
            this.rdAvaiable.Text = "Hoạt động";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStatus.Location = new System.Drawing.Point(438, 63);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(59, 15);
            this.lblStatus.TabIndex = 55;
            this.lblStatus.Text = "Trạng thái";
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblPass.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPass.Location = new System.Drawing.Point(16, 107);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(57, 15);
            this.lblPass.TabIndex = 54;
            this.lblPass.Text = "Mật khẩu";
            // 
            // linkChooseImage
            // 
            this.linkChooseImage.AutoSize = true;
            this.linkChooseImage.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.linkChooseImage.Location = new System.Drawing.Point(606, 151);
            this.linkChooseImage.Name = "linkChooseImage";
            this.linkChooseImage.Size = new System.Drawing.Size(48, 15);
            this.linkChooseImage.TabIndex = 6;
            this.linkChooseImage.TabStop = true;
            this.linkChooseImage.Text = "Lấy ảnh";
            this.linkChooseImage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkChooseImage_LinkClicked);
            // 
            // lblDelImage
            // 
            this.lblDelImage.AutoSize = true;
            this.lblDelImage.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDelImage.Location = new System.Drawing.Point(606, 169);
            this.lblDelImage.Name = "lblDelImage";
            this.lblDelImage.Size = new System.Drawing.Size(50, 15);
            this.lblDelImage.TabIndex = 7;
            this.lblDelImage.TabStop = true;
            this.lblDelImage.Text = "Xóa ảnh";
            this.lblDelImage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblDelImage_LinkClicked);
            // 
            // mtreeLookUpDonVi
            // 
            this.mtreeLookUpDonVi.AddFields = null;
            this.mtreeLookUpDonVi.AliasFormQuickAdd = null;
            this.mtreeLookUpDonVi.CustomSetFields = null;
            this.mtreeLookUpDonVi.Description = null;
            this.mtreeLookUpDonVi.DictionaryName = null;
            this.mtreeLookUpDonVi.EntityName = null;
            this.mtreeLookUpDonVi.Grid = null;
            this.mtreeLookUpDonVi.IsReadOnly = false;
            this.mtreeLookUpDonVi.IsSetValueManual = false;
            this.mtreeLookUpDonVi.KeyStore = null;
            this.mtreeLookUpDonVi.Location = new System.Drawing.Point(522, 18);
            this.mtreeLookUpDonVi.MapColumnName = null;
            this.mtreeLookUpDonVi.Name = "mtreeLookUpDonVi";
            this.mtreeLookUpDonVi.Properties.ActionButtonIndex = 1;
            this.mtreeLookUpDonVi.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.mtreeLookUpDonVi.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.mtreeLookUpDonVi.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mtreeLookUpDonVi.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.mtreeLookUpDonVi.Properties.Appearance.Options.UseBackColor = true;
            this.mtreeLookUpDonVi.Properties.Appearance.Options.UseFont = true;
            this.mtreeLookUpDonVi.Properties.Appearance.Options.UseForeColor = true;
            this.mtreeLookUpDonVi.Properties.AutoHeight = false;
            this.mtreeLookUpDonVi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete, "", -1, true, false, false, editorButtonImageOptions3, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject9, serializableAppearanceObject10, serializableAppearanceObject11, serializableAppearanceObject12, "Xóa", "ClearValue", null, DevExpress.Utils.ToolTipAnchor.Default),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.mtreeLookUpDonVi.Properties.ImmediatePopup = true;
            this.mtreeLookUpDonVi.Properties.NullText = "";
            this.mtreeLookUpDonVi.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.mtreeLookUpDonVi.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.mtreeLookUpDonVi.Properties.TreeList = this.mTreeLookUpEdit1TreeList;
            this.mtreeLookUpDonVi.QuickSearchName = null;
            this.mtreeLookUpDonVi.RepositoryItem = null;
            this.mtreeLookUpDonVi.SetField = null;
            this.mtreeLookUpDonVi.Size = new System.Drawing.Size(271, 23);
            this.mtreeLookUpDonVi.TabIndex = 93;
            // 
            // mTreeLookUpEdit1TreeList
            // 
            this.mTreeLookUpEdit1TreeList.KeyFieldName = "";
            this.mTreeLookUpEdit1TreeList.Location = new System.Drawing.Point(9, 44);
            this.mTreeLookUpEdit1TreeList.Name = "mTreeLookUpEdit1TreeList";
            this.mTreeLookUpEdit1TreeList.OptionsView.ShowAutoFilterRow = true;
            this.mTreeLookUpEdit1TreeList.OptionsView.ShowIndentAsRowStyle = true;
            this.mTreeLookUpEdit1TreeList.Size = new System.Drawing.Size(400, 200);
            this.mTreeLookUpEdit1TreeList.TabIndex = 0;
            // 
            // gunaLabel1
            // 
            this.gunaLabel1.AutoSize = true;
            this.gunaLabel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gunaLabel1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gunaLabel1.Location = new System.Drawing.Point(437, 24);
            this.gunaLabel1.Name = "gunaLabel1";
            this.gunaLabel1.Size = new System.Drawing.Size(82, 15);
            this.gunaLabel1.TabIndex = 94;
            this.gunaLabel1.Text = "Thuộc đơn vị :";
            // 
            // txtPass
            // 
            this.txtPass.AutoIncrement = false;
            this.txtPass.Description = null;
            this.txtPass.Grid = null;
            this.txtPass.IsCustomHeight = false;
            this.txtPass.IsReadOnly = false;
            this.txtPass.IsSetValueManual = false;
            this.txtPass.Location = new System.Drawing.Point(116, 101);
            this.txtPass.MaxLength = 0;
            this.txtPass.Name = "txtPass";
            this.txtPass.RepositoryItem = null;
            this.txtPass.SetField = null;
            this.txtPass.Size = new System.Drawing.Size(281, 22);
            this.txtPass.TabIndex = 97;
            // 
            // txtUserName
            // 
            this.txtUserName.AutoIncrement = false;
            this.txtUserName.Description = null;
            this.txtUserName.Grid = null;
            this.txtUserName.IsCustomHeight = false;
            this.txtUserName.IsReadOnly = false;
            this.txtUserName.IsSetValueManual = false;
            this.txtUserName.Location = new System.Drawing.Point(116, 59);
            this.txtUserName.MaxLength = 0;
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.RepositoryItem = null;
            this.txtUserName.SetField = null;
            this.txtUserName.Size = new System.Drawing.Size(281, 22);
            this.txtUserName.TabIndex = 96;
            // 
            // cboFullName
            // 
            this.cboFullName.AddFields = null;
            this.cboFullName.AliasFormQuickAdd = null;
            this.cboFullName.Description = null;
            this.cboFullName.DictionaryName = null;
            this.cboFullName.EntityName = null;
            this.cboFullName.Grid = null;
            this.cboFullName.IsHideClearValue = false;
            this.cboFullName.IsSetValueManual = false;
            this.cboFullName.KeyStore = null;
            this.cboFullName.Location = new System.Drawing.Point(116, 20);
            this.cboFullName.MapColumnName = null;
            this.cboFullName.Name = "cboFullName";
            this.cboFullName.Properties.ActionButtonIndex = 1;
            this.cboFullName.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.cboFullName.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cboFullName.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.cboFullName.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cboFullName.Properties.Appearance.Options.UseBackColor = true;
            this.cboFullName.Properties.Appearance.Options.UseFont = true;
            this.cboFullName.Properties.Appearance.Options.UseForeColor = true;
            this.cboFullName.Properties.AutoHeight = false;
            this.cboFullName.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.cboFullName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete, "", -1, true, false, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "Xóa", "ClearValue", null, DevExpress.Utils.ToolTipAnchor.Default),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboFullName.Properties.DictionaryName = null;
            this.cboFullName.Properties.FieldName = null;
            this.cboFullName.Properties.GridMaster = null;
            this.cboFullName.Properties.ImmediatePopup = true;
            this.cboFullName.Properties.IsEditorFilterRow = false;
            this.cboFullName.Properties.IsOrigin = false;
            this.cboFullName.Properties.IsRequired = false;
            this.cboFullName.Properties.NullText = "";
            this.cboFullName.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.cboFullName.Properties.PopupView = this.mGridLookUpEdit1View;
            this.cboFullName.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cboFullName.QuickSearchName = null;
            this.cboFullName.RepositoryItem = null;
            this.cboFullName.SetField = null;
            this.cboFullName.Size = new System.Drawing.Size(281, 23);
            this.cboFullName.TabIndex = 95;
            // 
            // mGridLookUpEdit1View
            // 
            this.mGridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.mGridLookUpEdit1View.Name = "mGridLookUpEdit1View";
            this.mGridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.mGridLookUpEdit1View.OptionsView.ColumnAutoWidth = false;
            this.mGridLookUpEdit1View.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            this.mGridLookUpEdit1View.OptionsView.ShowAutoFilterRow = true;
            this.mGridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            this.mGridLookUpEdit1View.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.True;
            this.mGridLookUpEdit1View.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.True;
            // 
            // btnEmployeeAccessLevel
            // 
            this.btnEmployeeAccessLevel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEmployeeAccessLevel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmployeeAccessLevel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnEmployeeAccessLevel.IconChar = FontAwesome.Sharp.IconChar.Signal;
            this.btnEmployeeAccessLevel.IconColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnEmployeeAccessLevel.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnEmployeeAccessLevel.IconSize = 20;
            this.btnEmployeeAccessLevel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEmployeeAccessLevel.Location = new System.Drawing.Point(115, 184);
            this.btnEmployeeAccessLevel.Name = "btnEmployeeAccessLevel";
            this.btnEmployeeAccessLevel.Size = new System.Drawing.Size(281, 38);
            this.btnEmployeeAccessLevel.TabIndex = 98;
            this.btnEmployeeAccessLevel.Text = "MỨC TRUY CẬP DỮ LIỆU";
            this.btnEmployeeAccessLevel.UseVisualStyleBackColor = true;
            this.btnEmployeeAccessLevel.Click += new System.EventHandler(this.btnEmployeeAccessLevel_Click);
            // 
            // gunaLabel2
            // 
            this.gunaLabel2.AutoSize = true;
            this.gunaLabel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gunaLabel2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gunaLabel2.Location = new System.Drawing.Point(15, 149);
            this.gunaLabel2.Name = "gunaLabel2";
            this.gunaLabel2.Size = new System.Drawing.Size(36, 15);
            this.gunaLabel2.TabIndex = 99;
            this.gunaLabel2.Text = "Email";
            // 
            // txtEmail
            // 
            this.txtEmail.AutoIncrement = false;
            this.txtEmail.Description = null;
            this.txtEmail.Grid = null;
            this.txtEmail.IsCustomHeight = false;
            this.txtEmail.IsMail = true;
            this.txtEmail.IsReadOnly = false;
            this.txtEmail.IsSetValueManual = false;
            this.txtEmail.Location = new System.Drawing.Point(115, 142);
            this.txtEmail.MaxLength = 0;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.RepositoryItem = null;
            this.txtEmail.SetField = null;
            this.txtEmail.Size = new System.Drawing.Size(281, 22);
            this.txtEmail.TabIndex = 100;
            // 
            // ucUserDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.gunaLabel2);
            this.Controls.Add(this.btnEmployeeAccessLevel);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.cboFullName);
            this.Controls.Add(this.mtreeLookUpDonVi);
            this.Controls.Add(this.gunaLabel1);
            this.Controls.Add(this.lblDelImage);
            this.Controls.Add(this.linkChooseImage);
            this.Controls.Add(this.btnChangePrivilege);
            this.Controls.Add(this.picImage);
            this.Controls.Add(this.lblAvatar);
            this.Controls.Add(this.cboGroupUser);
            this.Controls.Add(this.lblGroup);
            this.Controls.Add(this.gunaVSeparator3);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblFullName);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnDelUser);
            this.Controls.Add(this.rdoUnActive);
            this.Controls.Add(this.rdAvaiable);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblPass);
            this.Name = "ucUserDetail";
            this.Size = new System.Drawing.Size(813, 288);
            this.Load += new System.EventHandler(this.ucUserDetail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mtreeLookUpDonVi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mTreeLookUpEdit1TreeList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboFullName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mGridLookUpEdit1View)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private FontAwesome.Sharp.IconButton btnChangePrivilege;
        private Guna.UI.WinForms.GunaPictureBox picImage;
        private Guna.UI.WinForms.GunaLabel lblAvatar;
        private Guna.UI.WinForms.GunaComboBox cboGroupUser;
        private Guna.UI.WinForms.GunaLabel lblGroup;
        private Guna.UI.WinForms.GunaVSeparator gunaVSeparator3;
        private Guna.UI.WinForms.GunaLabel lblName;
        private Guna.UI.WinForms.GunaLabel lblFullName;
        private FontAwesome.Sharp.IconButton btnSave;
        private FontAwesome.Sharp.IconButton btnDelUser;
        private Guna.UI.WinForms.GunaRadioButton rdoUnActive;
        private Guna.UI.WinForms.GunaRadioButton rdAvaiable;
        private Guna.UI.WinForms.GunaLabel lblStatus;
        private Guna.UI.WinForms.GunaLabel lblPass;
        private Guna.UI.WinForms.GunaLinkLabel linkChooseImage;
        private Guna.UI.WinForms.GunaLinkLabel lblDelImage;
        private MTControl.MTreeLookUpEdit mtreeLookUpDonVi;
        private DevExpress.XtraTreeList.TreeList mTreeLookUpEdit1TreeList;
        private Guna.UI.WinForms.GunaLabel gunaLabel1;
        private MTControl.MTextEdit txtPass;
        private MTControl.MTextEdit txtUserName;
        private MTControl.MGridLookUpEdit cboFullName;
        private DevExpress.XtraGrid.Views.Grid.GridView mGridLookUpEdit1View;
        private FontAwesome.Sharp.IconButton btnEmployeeAccessLevel;
        private Guna.UI.WinForms.GunaLabel gunaLabel2;
        private MTControl.MTextEdit txtEmail;
    }
}
