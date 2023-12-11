namespace FormUI
{
    partial class frmAddUser
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions2 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddUser));
            this.lblAvatar = new Guna.UI.WinForms.GunaLabel();
            this.lblGroup = new Guna.UI.WinForms.GunaLabel();
            this.gunaVSeparator3 = new Guna.UI.WinForms.GunaVSeparator();
            this.lblName = new Guna.UI.WinForms.GunaLabel();
            this.lblFullName = new Guna.UI.WinForms.GunaLabel();
            this.lblStatus = new Guna.UI.WinForms.GunaLabel();
            this.lblPass = new Guna.UI.WinForms.GunaLabel();
            this.gunaLabel5 = new Guna.UI.WinForms.GunaLabel();
            this.pic_Exit = new FontAwesome.Sharp.IconPictureBox();
            this.rdoUnActive = new Guna.UI.WinForms.GunaRadioButton();
            this.rdAvaiable = new Guna.UI.WinForms.GunaRadioButton();
            this.cboGroupUser = new Guna.UI.WinForms.GunaComboBox();
            this.btnCancel = new Guna.UI.WinForms.GunaButton();
            this.btnSave = new Guna.UI.WinForms.GunaButton();
            this.lblDelImage = new Guna.UI.WinForms.GunaLinkLabel();
            this.lblChooseImage = new Guna.UI.WinForms.GunaLinkLabel();
            this.picImage = new Guna.UI.WinForms.GunaPictureBox();
            this.gunaDragControl1 = new Guna.UI.WinForms.GunaDragControl(this.components);
            this.gunaLabel1 = new Guna.UI.WinForms.GunaLabel();
            this.mtreeLookUpDonVi = new MTControl.MTreeLookUpEdit();
            this.mTreeLookUpEdit1TreeList = new DevExpress.XtraTreeList.TreeList();
            this.cboFullName = new MTControl.MGridLookUpEdit();
            this.mGridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.txtUserName = new MTControl.MTextEdit();
            this.txtPass = new MTControl.MTextEdit();
            this.txtEmail = new MTControl.MTextEdit();
            this.gunaLabel2 = new Guna.UI.WinForms.GunaLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Exit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mtreeLookUpDonVi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mTreeLookUpEdit1TreeList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboFullName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mGridLookUpEdit1View)).BeginInit();
            this.SuspendLayout();
            // 
            // lblAvatar
            // 
            this.lblAvatar.AutoSize = true;
            this.lblAvatar.BackColor = System.Drawing.Color.Gainsboro;
            this.lblAvatar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblAvatar.Location = new System.Drawing.Point(440, 225);
            this.lblAvatar.Name = "lblAvatar";
            this.lblAvatar.Size = new System.Drawing.Size(62, 15);
            this.lblAvatar.TabIndex = 68;
            this.lblAvatar.Text = "Hình ảnh :";
            // 
            // lblGroup
            // 
            this.lblGroup.AutoSize = true;
            this.lblGroup.BackColor = System.Drawing.Color.Gainsboro;
            this.lblGroup.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblGroup.Location = new System.Drawing.Point(440, 174);
            this.lblGroup.Name = "lblGroup";
            this.lblGroup.Size = new System.Drawing.Size(46, 15);
            this.lblGroup.TabIndex = 66;
            this.lblGroup.Text = "Vai trò :";
            // 
            // gunaVSeparator3
            // 
            this.gunaVSeparator3.BackColor = System.Drawing.Color.Gainsboro;
            this.gunaVSeparator3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.gunaVSeparator3.LineColor = System.Drawing.Color.Silver;
            this.gunaVSeparator3.Location = new System.Drawing.Point(414, 92);
            this.gunaVSeparator3.Name = "gunaVSeparator3";
            this.gunaVSeparator3.Size = new System.Drawing.Size(10, 215);
            this.gunaVSeparator3.TabIndex = 65;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.BackColor = System.Drawing.Color.Gainsboro;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblName.Location = new System.Drawing.Point(18, 134);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(71, 15);
            this.lblName.TabIndex = 63;
            this.lblName.Text = "Đăng nhập :";
            // 
            // lblFullName
            // 
            this.lblFullName.AutoSize = true;
            this.lblFullName.BackColor = System.Drawing.Color.Gainsboro;
            this.lblFullName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFullName.Location = new System.Drawing.Point(18, 98);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(51, 15);
            this.lblFullName.TabIndex = 61;
            this.lblFullName.Text = "Cán bộ :";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.BackColor = System.Drawing.Color.Gainsboro;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStatus.Location = new System.Drawing.Point(440, 135);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(65, 15);
            this.lblStatus.TabIndex = 55;
            this.lblStatus.Text = "Trạng thái :";
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.BackColor = System.Drawing.Color.Gainsboro;
            this.lblPass.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPass.Location = new System.Drawing.Point(18, 171);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(63, 15);
            this.lblPass.TabIndex = 54;
            this.lblPass.Text = "Mật khẩu :";
            // 
            // gunaLabel5
            // 
            this.gunaLabel5.AutoSize = true;
            this.gunaLabel5.BackColor = System.Drawing.Color.Gainsboro;
            this.gunaLabel5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.gunaLabel5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gunaLabel5.Location = new System.Drawing.Point(320, 15);
            this.gunaLabel5.Name = "gunaLabel5";
            this.gunaLabel5.Size = new System.Drawing.Size(208, 21);
            this.gunaLabel5.TabIndex = 74;
            this.gunaLabel5.Text = "THÔNG TIN NGƯỜI DÙNG";
            // 
            // pic_Exit
            // 
            this.pic_Exit.BackColor = System.Drawing.Color.White;
            this.pic_Exit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pic_Exit.ForeColor = System.Drawing.SystemColors.WindowText;
            this.pic_Exit.IconChar = FontAwesome.Sharp.IconChar.Times;
            this.pic_Exit.IconColor = System.Drawing.SystemColors.WindowText;
            this.pic_Exit.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.pic_Exit.IconSize = 15;
            this.pic_Exit.Location = new System.Drawing.Point(800, 1);
            this.pic_Exit.Name = "pic_Exit";
            this.pic_Exit.Size = new System.Drawing.Size(17, 15);
            this.pic_Exit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pic_Exit.TabIndex = 76;
            this.pic_Exit.TabStop = false;
            this.pic_Exit.Click += new System.EventHandler(this.pic_Exit_Click);
            // 
            // rdoUnActive
            // 
            this.rdoUnActive.BackColor = System.Drawing.Color.White;
            this.rdoUnActive.BaseColor = System.Drawing.SystemColors.Control;
            this.rdoUnActive.CheckedOffColor = System.Drawing.Color.Gray;
            this.rdoUnActive.CheckedOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(117)))), ((int)(((byte)(188)))));
            this.rdoUnActive.FillColor = System.Drawing.Color.White;
            this.rdoUnActive.Location = new System.Drawing.Point(708, 130);
            this.rdoUnActive.Name = "rdoUnActive";
            this.rdoUnActive.Size = new System.Drawing.Size(87, 20);
            this.rdoUnActive.TabIndex = 6;
            this.rdoUnActive.Text = "Tạm ngưng";
            // 
            // rdAvaiable
            // 
            this.rdAvaiable.BackColor = System.Drawing.Color.White;
            this.rdAvaiable.BaseColor = System.Drawing.SystemColors.Control;
            this.rdAvaiable.Checked = true;
            this.rdAvaiable.CheckedOffColor = System.Drawing.Color.Gray;
            this.rdAvaiable.CheckedOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(117)))), ((int)(((byte)(188)))));
            this.rdAvaiable.FillColor = System.Drawing.Color.White;
            this.rdAvaiable.Location = new System.Drawing.Point(524, 130);
            this.rdAvaiable.Name = "rdAvaiable";
            this.rdAvaiable.Size = new System.Drawing.Size(82, 20);
            this.rdAvaiable.TabIndex = 5;
            this.rdAvaiable.Text = "Hoạt động";
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
            this.cboGroupUser.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboGroupUser.ForeColor = System.Drawing.Color.Black;
            this.cboGroupUser.FormattingEnabled = true;
            this.cboGroupUser.Location = new System.Drawing.Point(524, 168);
            this.cboGroupUser.Name = "cboGroupUser";
            this.cboGroupUser.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.cboGroupUser.OnHoverItemForeColor = System.Drawing.Color.White;
            this.cboGroupUser.Size = new System.Drawing.Size(271, 24);
            this.cboGroupUser.TabIndex = 7;
            // 
            // btnCancel
            // 
            this.btnCancel.AnimationHoverSpeed = 0.07F;
            this.btnCancel.AnimationSpeed = 0.03F;
            this.btnCancel.BaseColor = System.Drawing.Color.White;
            this.btnCancel.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnCancel.BorderSize = 1;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnCancel.FocusedColor = System.Drawing.Color.Empty;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnCancel.Image = null;
            this.btnCancel.ImageSize = new System.Drawing.Size(20, 20);
            this.btnCancel.Location = new System.Drawing.Point(637, 273);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(169)))), ((int)(((byte)(25)))));
            this.btnCancel.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(169)))), ((int)(((byte)(25)))));
            this.btnCancel.OnHoverForeColor = System.Drawing.Color.White;
            this.btnCancel.OnHoverImage = null;
            this.btnCancel.OnPressedColor = System.Drawing.Color.Black;
            this.btnCancel.Size = new System.Drawing.Size(158, 34);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "HỦY";
            this.btnCancel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnCancel.Click += new System.EventHandler(this.pic_Exit_Click);
            // 
            // btnSave
            // 
            this.btnSave.AnimationHoverSpeed = 0.07F;
            this.btnSave.AnimationSpeed = 0.03F;
            this.btnSave.BaseColor = System.Drawing.Color.White;
            this.btnSave.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnSave.BorderSize = 1;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnSave.FocusedColor = System.Drawing.Color.Empty;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnSave.Image = null;
            this.btnSave.ImageSize = new System.Drawing.Size(20, 20);
            this.btnSave.Location = new System.Drawing.Point(448, 273);
            this.btnSave.Name = "btnSave";
            this.btnSave.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(169)))), ((int)(((byte)(25)))));
            this.btnSave.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(169)))), ((int)(((byte)(25)))));
            this.btnSave.OnHoverForeColor = System.Drawing.Color.White;
            this.btnSave.OnHoverImage = null;
            this.btnSave.OnPressedColor = System.Drawing.Color.Black;
            this.btnSave.Size = new System.Drawing.Size(158, 34);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "LƯU THÔNG TIN";
            this.btnSave.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblDelImage
            // 
            this.lblDelImage.AutoSize = true;
            this.lblDelImage.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDelImage.Location = new System.Drawing.Point(579, 227);
            this.lblDelImage.Name = "lblDelImage";
            this.lblDelImage.Size = new System.Drawing.Size(50, 15);
            this.lblDelImage.TabIndex = 9;
            this.lblDelImage.TabStop = true;
            this.lblDelImage.Text = "Xóa ảnh";
            this.lblDelImage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblDelImage_LinkClicked);
            // 
            // lblChooseImage
            // 
            this.lblChooseImage.AutoSize = true;
            this.lblChooseImage.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblChooseImage.Location = new System.Drawing.Point(579, 209);
            this.lblChooseImage.Name = "lblChooseImage";
            this.lblChooseImage.Size = new System.Drawing.Size(48, 15);
            this.lblChooseImage.TabIndex = 8;
            this.lblChooseImage.TabStop = true;
            this.lblChooseImage.Text = "Lấy ảnh";
            this.lblChooseImage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.gunaLinkLabel1_LinkClicked);
            // 
            // picImage
            // 
            this.picImage.BaseColor = System.Drawing.Color.White;
            this.picImage.Image = global::FormUI.Properties.Resources.Login;
            this.picImage.Location = new System.Drawing.Point(524, 209);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(49, 33);
            this.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picImage.TabIndex = 91;
            this.picImage.TabStop = false;
            // 
            // gunaDragControl1
            // 
            this.gunaDragControl1.TargetControl = this;
            // 
            // gunaLabel1
            // 
            this.gunaLabel1.AutoSize = true;
            this.gunaLabel1.BackColor = System.Drawing.Color.Gainsboro;
            this.gunaLabel1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gunaLabel1.Location = new System.Drawing.Point(439, 98);
            this.gunaLabel1.Name = "gunaLabel1";
            this.gunaLabel1.Size = new System.Drawing.Size(82, 15);
            this.gunaLabel1.TabIndex = 92;
            this.gunaLabel1.Text = "Thuộc đơn vị :";
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
            this.mtreeLookUpDonVi.IsReadOnly = true;
            this.mtreeLookUpDonVi.IsSetValueManual = false;
            this.mtreeLookUpDonVi.KeyStore = null;
            this.mtreeLookUpDonVi.Location = new System.Drawing.Point(524, 92);
            this.mtreeLookUpDonVi.MapColumnName = null;
            this.mtreeLookUpDonVi.Name = "mtreeLookUpDonVi";
            this.mtreeLookUpDonVi.Properties.ActionButtonIndex = 1;
            this.mtreeLookUpDonVi.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.mtreeLookUpDonVi.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.mtreeLookUpDonVi.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mtreeLookUpDonVi.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.mtreeLookUpDonVi.Properties.Appearance.Options.UseBackColor = true;
            this.mtreeLookUpDonVi.Properties.Appearance.Options.UseFont = true;
            this.mtreeLookUpDonVi.Properties.Appearance.Options.UseForeColor = true;
            this.mtreeLookUpDonVi.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.mtreeLookUpDonVi.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.mtreeLookUpDonVi.Properties.AutoHeight = false;
            this.mtreeLookUpDonVi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete, "", -1, true, false, false, editorButtonImageOptions2, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, serializableAppearanceObject6, serializableAppearanceObject7, serializableAppearanceObject8, "Xóa", "ClearValue", null, DevExpress.Utils.ToolTipAnchor.Default),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.mtreeLookUpDonVi.Properties.ImmediatePopup = true;
            this.mtreeLookUpDonVi.Properties.NullText = "";
            this.mtreeLookUpDonVi.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.mtreeLookUpDonVi.Properties.ReadOnly = true;
            this.mtreeLookUpDonVi.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.mtreeLookUpDonVi.Properties.TreeList = this.mTreeLookUpEdit1TreeList;
            this.mtreeLookUpDonVi.QuickSearchName = null;
            this.mtreeLookUpDonVi.RepositoryItem = null;
            this.mtreeLookUpDonVi.SetField = null;
            this.mtreeLookUpDonVi.Size = new System.Drawing.Size(271, 23);
            this.mtreeLookUpDonVi.TabIndex = 4;
            // 
            // mTreeLookUpEdit1TreeList
            // 
            this.mTreeLookUpEdit1TreeList.KeyFieldName = "";
            this.mTreeLookUpEdit1TreeList.Location = new System.Drawing.Point(0, 0);
            this.mTreeLookUpEdit1TreeList.Name = "mTreeLookUpEdit1TreeList";
            this.mTreeLookUpEdit1TreeList.OptionsView.ShowAutoFilterRow = true;
            this.mTreeLookUpEdit1TreeList.OptionsView.ShowIndentAsRowStyle = true;
            this.mTreeLookUpEdit1TreeList.Size = new System.Drawing.Size(400, 200);
            this.mTreeLookUpEdit1TreeList.TabIndex = 0;
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
            this.cboFullName.Location = new System.Drawing.Point(102, 92);
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
            this.cboFullName.Size = new System.Drawing.Size(290, 23);
            this.cboFullName.TabIndex = 0;
            this.cboFullName.EditValueChanged += new System.EventHandler(this.cboFullName_EditValueChanged);
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
            // txtUserName
            // 
            this.txtUserName.AutoIncrement = false;
            this.txtUserName.Description = null;
            this.txtUserName.Grid = null;
            this.txtUserName.IsCustomHeight = false;
            this.txtUserName.IsReadOnly = false;
            this.txtUserName.IsSetValueManual = false;
            this.txtUserName.Location = new System.Drawing.Point(102, 130);
            this.txtUserName.MaxLength = 0;
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.RepositoryItem = null;
            this.txtUserName.SetField = null;
            this.txtUserName.Size = new System.Drawing.Size(290, 22);
            this.txtUserName.TabIndex = 1;
            // 
            // txtPass
            // 
            this.txtPass.AutoIncrement = false;
            this.txtPass.Description = null;
            this.txtPass.Grid = null;
            this.txtPass.IsCustomHeight = false;
            this.txtPass.IsReadOnly = false;
            this.txtPass.IsSetValueManual = false;
            this.txtPass.Location = new System.Drawing.Point(102, 168);
            this.txtPass.MaxLength = 0;
            this.txtPass.Name = "txtPass";
            this.txtPass.RepositoryItem = null;
            this.txtPass.SetField = null;
            this.txtPass.Size = new System.Drawing.Size(290, 22);
            this.txtPass.TabIndex = 2;
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
            this.txtEmail.Location = new System.Drawing.Point(102, 205);
            this.txtEmail.MaxLength = 0;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.RepositoryItem = null;
            this.txtEmail.SetField = "Email";
            this.txtEmail.Size = new System.Drawing.Size(290, 22);
            this.txtEmail.TabIndex = 3;
            // 
            // gunaLabel2
            // 
            this.gunaLabel2.AutoSize = true;
            this.gunaLabel2.BackColor = System.Drawing.Color.Gainsboro;
            this.gunaLabel2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gunaLabel2.Location = new System.Drawing.Point(18, 208);
            this.gunaLabel2.Name = "gunaLabel2";
            this.gunaLabel2.Size = new System.Drawing.Size(42, 15);
            this.gunaLabel2.TabIndex = 94;
            this.gunaLabel2.Text = "Email :";
            // 
            // frmAddUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(817, 326);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.gunaLabel2);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.cboFullName);
            this.Controls.Add(this.mtreeLookUpDonVi);
            this.Controls.Add(this.gunaLabel1);
            this.Controls.Add(this.pic_Exit);
            this.Controls.Add(this.lblDelImage);
            this.Controls.Add(this.gunaLabel5);
            this.Controls.Add(this.lblChooseImage);
            this.Controls.Add(this.rdAvaiable);
            this.Controls.Add(this.lblPass);
            this.Controls.Add(this.picImage);
            this.Controls.Add(this.rdoUnActive);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.cboGroupUser);
            this.Controls.Add(this.lblFullName);
            this.Controls.Add(this.lblAvatar);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblGroup);
            this.Controls.Add(this.gunaVSeparator3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAddUser";
            this.Text = "Add User";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmAddUser_FormClosed);
            this.Load += new System.EventHandler(this.frmAddUser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pic_Exit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mtreeLookUpDonVi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mTreeLookUpEdit1TreeList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboFullName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mGridLookUpEdit1View)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI.WinForms.GunaLabel lblAvatar;
        private Guna.UI.WinForms.GunaLabel lblGroup;
        private Guna.UI.WinForms.GunaVSeparator gunaVSeparator3;
        private Guna.UI.WinForms.GunaLabel lblName;
        private Guna.UI.WinForms.GunaLabel lblFullName;
        private Guna.UI.WinForms.GunaLabel lblStatus;
        private Guna.UI.WinForms.GunaLabel lblPass;
        private Guna.UI.WinForms.GunaLabel gunaLabel5;
        private FontAwesome.Sharp.IconPictureBox pic_Exit;
        private Guna.UI.WinForms.GunaRadioButton rdoUnActive;
        private Guna.UI.WinForms.GunaRadioButton rdAvaiable;
        private Guna.UI.WinForms.GunaComboBox cboGroupUser;
        private Guna.UI.WinForms.GunaButton btnCancel;
        private Guna.UI.WinForms.GunaButton btnSave;
        private Guna.UI.WinForms.GunaLinkLabel lblDelImage;
        private Guna.UI.WinForms.GunaLinkLabel lblChooseImage;
        private Guna.UI.WinForms.GunaPictureBox picImage;
        private Guna.UI.WinForms.GunaDragControl gunaDragControl1;
        private Guna.UI.WinForms.GunaLabel gunaLabel1;
        private MTControl.MTreeLookUpEdit mtreeLookUpDonVi;
        private DevExpress.XtraTreeList.TreeList mTreeLookUpEdit1TreeList;
        private MTControl.MGridLookUpEdit cboFullName;
        private DevExpress.XtraGrid.Views.Grid.GridView mGridLookUpEdit1View;
        private MTControl.MTextEdit txtUserName;
        private MTControl.MTextEdit txtPass;
        private MTControl.MTextEdit txtEmail;
        private Guna.UI.WinForms.GunaLabel gunaLabel2;
    }
}