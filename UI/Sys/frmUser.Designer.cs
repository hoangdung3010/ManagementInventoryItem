
namespace FormUI
{
    partial class frmUser
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
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUser));
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.cboRoleId = new MTControl.MLookUpEdit();
            this.lblRoleId = new Guna.UI.WinForms.GunaLabel();
            this.gunaLabel1 = new Guna.UI.WinForms.GunaLabel();
            this.mtreeLookUpDonVi = new MTControl.MTreeLookUpEdit();
            this.mTreeLookUpEdit1TreeList = new DevExpress.XtraTreeList.TreeList();
            this.lblPlaceHolder = new Guna.UI.WinForms.GunaLabel();
            this.btnAddUser = new Guna.UI.WinForms.GunaButton();
            this.txtSearchUser = new DevExpress.XtraEditors.TextEdit();
            this.gridUser = new Guna.UI.WinForms.GunaDataGridView();
            this.FullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrganizationUnitName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRoleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatusName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMucTruyCapDuLieu = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colPermission = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colEdit = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colXoa = new System.Windows.Forms.DataGridViewLinkColumn();
            this.backgroundWorkerUser = new System.ComponentModel.BackgroundWorker();
            this.gunaContextMenuStripMoreButton = new Guna.UI.WinForms.GunaContextMenuStrip();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.thêmMớiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.delToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.viewPermissionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mứcTruyCậpDữLiệuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mtreeLookUpDonVi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mTreeLookUpEdit1TreeList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearchUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridUser)).BeginInit();
            this.gunaContextMenuStripMoreButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer3
            // 
            this.splitContainer3.BackColor = System.Drawing.Color.White;
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.splitContainer3.Panel1.Controls.Add(this.cboRoleId);
            this.splitContainer3.Panel1.Controls.Add(this.lblRoleId);
            this.splitContainer3.Panel1.Controls.Add(this.gunaLabel1);
            this.splitContainer3.Panel1.Controls.Add(this.mtreeLookUpDonVi);
            this.splitContainer3.Panel1.Controls.Add(this.lblPlaceHolder);
            this.splitContainer3.Panel1.Controls.Add(this.btnAddUser);
            this.splitContainer3.Panel1.Controls.Add(this.txtSearchUser);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.splitContainer3.Panel2.Controls.Add(this.gridUser);
            this.splitContainer3.Panel2.Padding = new System.Windows.Forms.Padding(8);
            this.splitContainer3.Size = new System.Drawing.Size(1118, 651);
            this.splitContainer3.SplitterDistance = 46;
            this.splitContainer3.SplitterWidth = 1;
            this.splitContainer3.TabIndex = 3;
            // 
            // cboRoleId
            // 
            this.cboRoleId.AddFields = null;
            this.cboRoleId.AliasFormQuickAdd = null;
            this.cboRoleId.ColumnsExtend = null;
            this.cboRoleId.Description = null;
            this.cboRoleId.DictionaryName = null;
            this.cboRoleId.EntityName = null;
            this.cboRoleId.Grid = null;
            this.cboRoleId.IsAutoLoad = false;
            this.cboRoleId.IsHideClearValue = false;
            this.cboRoleId.IsReadOnly = false;
            this.cboRoleId.IsSetValueManual = false;
            this.cboRoleId.KeyStore = null;
            this.cboRoleId.Location = new System.Drawing.Point(362, 14);
            this.cboRoleId.MapColumnName = null;
            this.cboRoleId.Name = "cboRoleId";
            this.cboRoleId.PrimaryKey = null;
            this.cboRoleId.QuickSearchName = null;
            this.cboRoleId.RepositoryItem = null;
            this.cboRoleId.SetField = null;
            this.cboRoleId.Size = new System.Drawing.Size(181, 23);
            this.cboRoleId.Sort = null;
            this.cboRoleId.TabIndex = 51;
            this.cboRoleId.ValueDefault = null;
            this.cboRoleId.EditValueChanged += new System.EventHandler(this.cboRoleId_EditValueChanged);
            // 
            // lblRoleId
            // 
            this.lblRoleId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblRoleId.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblRoleId.Location = new System.Drawing.Point(317, 17);
            this.lblRoleId.Margin = new System.Windows.Forms.Padding(3, 4, 3, 0);
            this.lblRoleId.Name = "lblRoleId";
            this.lblRoleId.Size = new System.Drawing.Size(49, 20);
            this.lblRoleId.TabIndex = 50;
            this.lblRoleId.Text = "Vai trò";
            // 
            // gunaLabel1
            // 
            this.gunaLabel1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.gunaLabel1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gunaLabel1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gunaLabel1.Location = new System.Drawing.Point(5, 18);
            this.gunaLabel1.MaximumSize = new System.Drawing.Size(93, 15);
            this.gunaLabel1.Name = "gunaLabel1";
            this.gunaLabel1.Size = new System.Drawing.Size(78, 15);
            this.gunaLabel1.TabIndex = 49;
            this.gunaLabel1.Text = "Thuộc đơn vị";
            // 
            // mtreeLookUpDonVi
            // 
            this.mtreeLookUpDonVi.AddFields = null;
            this.mtreeLookUpDonVi.AliasFormQuickAdd = null;
            this.mtreeLookUpDonVi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.mtreeLookUpDonVi.CustomSetFields = null;
            this.mtreeLookUpDonVi.Description = null;
            this.mtreeLookUpDonVi.DictionaryName = null;
            this.mtreeLookUpDonVi.EntityName = null;
            this.mtreeLookUpDonVi.Grid = null;
            this.mtreeLookUpDonVi.IsReadOnly = false;
            this.mtreeLookUpDonVi.IsSetValueManual = false;
            this.mtreeLookUpDonVi.KeyStore = null;
            this.mtreeLookUpDonVi.Location = new System.Drawing.Point(89, 14);
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
            this.mtreeLookUpDonVi.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.mtreeLookUpDonVi.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.mtreeLookUpDonVi.Properties.AutoHeight = false;
            this.mtreeLookUpDonVi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete, "", -1, true, false, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "Xóa", "ClearValue", null, DevExpress.Utils.ToolTipAnchor.Default),
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
            this.mtreeLookUpDonVi.Size = new System.Drawing.Size(222, 23);
            this.mtreeLookUpDonVi.TabIndex = 4;
            this.mtreeLookUpDonVi.EditValueChanged += new System.EventHandler(this.mtreeLookUpDonVi_EditValueChanged);
            // 
            // mTreeLookUpEdit1TreeList
            // 
            this.mTreeLookUpEdit1TreeList.KeyFieldName = "";
            this.mTreeLookUpEdit1TreeList.Location = new System.Drawing.Point(366, 225);
            this.mTreeLookUpEdit1TreeList.Name = "mTreeLookUpEdit1TreeList";
            this.mTreeLookUpEdit1TreeList.OptionsView.ShowAutoFilterRow = true;
            this.mTreeLookUpEdit1TreeList.OptionsView.ShowIndentAsRowStyle = true;
            this.mTreeLookUpEdit1TreeList.Size = new System.Drawing.Size(351, 200);
            this.mTreeLookUpEdit1TreeList.TabIndex = 0;
            // 
            // lblPlaceHolder
            // 
            this.lblPlaceHolder.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblPlaceHolder.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPlaceHolder.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblPlaceHolder.Location = new System.Drawing.Point(556, 17);
            this.lblPlaceHolder.MaximumSize = new System.Drawing.Size(93, 15);
            this.lblPlaceHolder.Name = "lblPlaceHolder";
            this.lblPlaceHolder.Size = new System.Drawing.Size(93, 15);
            this.lblPlaceHolder.TabIndex = 48;
            this.lblPlaceHolder.Text = "Tìm kiếm nhanh";
            // 
            // btnAddUser
            // 
            this.btnAddUser.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnAddUser.AnimationHoverSpeed = 0.07F;
            this.btnAddUser.AnimationSpeed = 0.03F;
            this.btnAddUser.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(117)))), ((int)(((byte)(188)))));
            this.btnAddUser.BorderColor = System.Drawing.Color.Black;
            this.btnAddUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddUser.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnAddUser.FocusedColor = System.Drawing.Color.Empty;
            this.btnAddUser.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAddUser.ForeColor = System.Drawing.Color.White;
            this.btnAddUser.Image = null;
            this.btnAddUser.ImageSize = new System.Drawing.Size(20, 20);
            this.btnAddUser.Location = new System.Drawing.Point(1017, 10);
            this.btnAddUser.Margin = new System.Windows.Forms.Padding(3, 3, 8, 3);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(169)))), ((int)(((byte)(25)))));
            this.btnAddUser.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnAddUser.OnHoverForeColor = System.Drawing.Color.White;
            this.btnAddUser.OnHoverImage = null;
            this.btnAddUser.OnPressedColor = System.Drawing.Color.Black;
            this.btnAddUser.Size = new System.Drawing.Size(92, 27);
            this.btnAddUser.TabIndex = 47;
            this.btnAddUser.Text = "Thêm mới";
            this.btnAddUser.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // txtSearchUser
            // 
            this.txtSearchUser.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtSearchUser.Location = new System.Drawing.Point(657, 11);
            this.txtSearchUser.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.txtSearchUser.MaximumSize = new System.Drawing.Size(188, 26);
            this.txtSearchUser.MinimumSize = new System.Drawing.Size(188, 26);
            this.txtSearchUser.Name = "txtSearchUser";
            this.txtSearchUser.Properties.Appearance.BorderColor = System.Drawing.Color.Silver;
            this.txtSearchUser.Properties.Appearance.Options.UseBorderColor = true;
            this.txtSearchUser.Properties.AutoHeight = false;
            this.txtSearchUser.Size = new System.Drawing.Size(188, 26);
            this.txtSearchUser.TabIndex = 45;
            this.txtSearchUser.ToolTip = "Nhập vai trò";
            this.txtSearchUser.ToolTipAnchor = DevExpress.Utils.ToolTipAnchor.Cursor;
            this.txtSearchUser.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.txtSearchUser.TextChanged += new System.EventHandler(this.txtSearchUser_TextChanged);
            // 
            // gridUser
            // 
            this.gridUser.AllowUserToAddRows = false;
            this.gridUser.AllowUserToDeleteRows = false;
            this.gridUser.AllowUserToOrderColumns = true;
            this.gridUser.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.gridUser.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridUser.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridUser.BackgroundColor = System.Drawing.Color.White;
            this.gridUser.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridUser.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.gridUser.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(117)))), ((int)(((byte)(188)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridUser.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gridUser.ColumnHeadersHeight = 26;
            this.gridUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridUser.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FullName,
            this.colUserName,
            this.colEmail,
            this.colOrganizationUnitName,
            this.colRoleName,
            this.colStatusName,
            this.colMucTruyCapDuLieu,
            this.colPermission,
            this.colEdit,
            this.colXoa});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(222)))), ((int)(((byte)(251)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridUser.DefaultCellStyle = dataGridViewCellStyle3;
            this.gridUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridUser.EnableHeadersVisualStyles = false;
            this.gridUser.GridColor = System.Drawing.Color.Gainsboro;
            this.gridUser.Location = new System.Drawing.Point(8, 8);
            this.gridUser.Margin = new System.Windows.Forms.Padding(8);
            this.gridUser.Name = "gridUser";
            this.gridUser.ReadOnly = true;
            this.gridUser.RowHeadersVisible = false;
            this.gridUser.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridUser.Size = new System.Drawing.Size(1102, 588);
            this.gridUser.TabIndex = 0;
            this.gridUser.Theme = Guna.UI.WinForms.GunaDataGridViewPresetThemes.Guna;
            this.gridUser.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.gridUser.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.gridUser.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.gridUser.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.gridUser.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.gridUser.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.gridUser.ThemeStyle.GridColor = System.Drawing.Color.Gainsboro;
            this.gridUser.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(117)))), ((int)(((byte)(188)))));
            this.gridUser.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.gridUser.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridUser.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.gridUser.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridUser.ThemeStyle.HeaderStyle.Height = 26;
            this.gridUser.ThemeStyle.ReadOnly = true;
            this.gridUser.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.gridUser.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.gridUser.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridUser.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.gridUser.ThemeStyle.RowsStyle.Height = 22;
            this.gridUser.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(222)))), ((int)(((byte)(251)))));
            this.gridUser.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.gridUser.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridUser_CellContentClick);
            this.gridUser.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gridUser_MouseDown);
            // 
            // FullName
            // 
            this.FullName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.FullName.DataPropertyName = "FullName";
            this.FullName.HeaderText = "Cán bộ";
            this.FullName.Name = "FullName";
            this.FullName.ReadOnly = true;
            // 
            // colUserName
            // 
            this.colUserName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colUserName.DataPropertyName = "UserName";
            this.colUserName.HeaderText = "Tài khoản";
            this.colUserName.Name = "colUserName";
            this.colUserName.ReadOnly = true;
            this.colUserName.Width = 184;
            // 
            // colEmail
            // 
            this.colEmail.DataPropertyName = "Email";
            this.colEmail.HeaderText = "Email";
            this.colEmail.Name = "colEmail";
            this.colEmail.ReadOnly = true;
            // 
            // colOrganizationUnitName
            // 
            this.colOrganizationUnitName.DataPropertyName = "OrganizationUnitName";
            this.colOrganizationUnitName.HeaderText = "Thuộc đơn vị";
            this.colOrganizationUnitName.Name = "colOrganizationUnitName";
            this.colOrganizationUnitName.ReadOnly = true;
            // 
            // colRoleName
            // 
            this.colRoleName.DataPropertyName = "RoleName";
            this.colRoleName.HeaderText = "Vai trò";
            this.colRoleName.Name = "colRoleName";
            this.colRoleName.ReadOnly = true;
            // 
            // colStatusName
            // 
            this.colStatusName.DataPropertyName = "StatusName";
            this.colStatusName.HeaderText = "Trạng thái";
            this.colStatusName.Name = "colStatusName";
            this.colStatusName.ReadOnly = true;
            // 
            // colMucTruyCapDuLieu
            // 
            this.colMucTruyCapDuLieu.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colMucTruyCapDuLieu.HeaderText = "";
            this.colMucTruyCapDuLieu.Name = "colMucTruyCapDuLieu";
            this.colMucTruyCapDuLieu.ReadOnly = true;
            this.colMucTruyCapDuLieu.Text = "Mức truy cập dữ liệu";
            this.colMucTruyCapDuLieu.UseColumnTextForLinkValue = true;
            this.colMucTruyCapDuLieu.Width = 120;
            // 
            // colPermission
            // 
            this.colPermission.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colPermission.DataPropertyName = "Id";
            this.colPermission.HeaderText = "";
            this.colPermission.Name = "colPermission";
            this.colPermission.ReadOnly = true;
            this.colPermission.Text = "Xem quyền";
            this.colPermission.UseColumnTextForLinkValue = true;
            this.colPermission.Width = 80;
            // 
            // colEdit
            // 
            this.colEdit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colEdit.DataPropertyName = "Id";
            this.colEdit.HeaderText = "";
            this.colEdit.Name = "colEdit";
            this.colEdit.ReadOnly = true;
            this.colEdit.Text = "Sửa";
            this.colEdit.UseColumnTextForLinkValue = true;
            this.colEdit.Width = 30;
            // 
            // colXoa
            // 
            this.colXoa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colXoa.DataPropertyName = "Id";
            this.colXoa.HeaderText = "";
            this.colXoa.Name = "colXoa";
            this.colXoa.ReadOnly = true;
            this.colXoa.Text = "Xóa";
            this.colXoa.UseColumnTextForLinkValue = true;
            this.colXoa.Width = 30;
            // 
            // backgroundWorkerUser
            // 
            this.backgroundWorkerUser.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerUser_DoWork);
            this.backgroundWorkerUser.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerUser_RunWorkerCompleted);
            // 
            // gunaContextMenuStripMoreButton
            // 
            this.gunaContextMenuStripMoreButton.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator3,
            this.thêmMớiToolStripMenuItem,
            this.editToolStripMenuItem,
            this.delToolStripMenuItem,
            this.toolStripSeparator2,
            this.viewPermissionToolStripMenuItem,
            this.mứcTruyCậpDữLiệuToolStripMenuItem});
            this.gunaContextMenuStripMoreButton.Name = "gunaContextMenuStripMoreButton";
            this.gunaContextMenuStripMoreButton.RenderStyle.ArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.gunaContextMenuStripMoreButton.RenderStyle.BorderColor = System.Drawing.Color.Gainsboro;
            this.gunaContextMenuStripMoreButton.RenderStyle.ColorTable = null;
            this.gunaContextMenuStripMoreButton.RenderStyle.RoundedEdges = true;
            this.gunaContextMenuStripMoreButton.RenderStyle.SelectionArrowColor = System.Drawing.Color.White;
            this.gunaContextMenuStripMoreButton.RenderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.gunaContextMenuStripMoreButton.RenderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.gunaContextMenuStripMoreButton.RenderStyle.SeparatorColor = System.Drawing.Color.Gainsboro;
            this.gunaContextMenuStripMoreButton.RenderStyle.TextRenderingHint = Guna.UI.WinForms.DrawingTextRenderingHint.SystemDefault;
            this.gunaContextMenuStripMoreButton.Size = new System.Drawing.Size(184, 126);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(180, 6);
            // 
            // thêmMớiToolStripMenuItem
            // 
            this.thêmMớiToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("thêmMớiToolStripMenuItem.Image")));
            this.thêmMớiToolStripMenuItem.Name = "thêmMớiToolStripMenuItem";
            this.thêmMớiToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.thêmMớiToolStripMenuItem.Text = "Thêm mới";
            this.thêmMớiToolStripMenuItem.Click += new System.EventHandler(this.thêmMớiToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("editToolStripMenuItem.Image")));
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.editToolStripMenuItem.Text = "Sửa";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // delToolStripMenuItem
            // 
            this.delToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("delToolStripMenuItem.Image")));
            this.delToolStripMenuItem.Name = "delToolStripMenuItem";
            this.delToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.delToolStripMenuItem.Text = "Xóa";
            this.delToolStripMenuItem.Click += new System.EventHandler(this.delToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(180, 6);
            // 
            // viewPermissionToolStripMenuItem
            // 
            this.viewPermissionToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("viewPermissionToolStripMenuItem.Image")));
            this.viewPermissionToolStripMenuItem.Name = "viewPermissionToolStripMenuItem";
            this.viewPermissionToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.viewPermissionToolStripMenuItem.Text = "Xem quyền";
            this.viewPermissionToolStripMenuItem.Click += new System.EventHandler(this.viewPermissionToolStripMenuItem_Click);
            // 
            // mứcTruyCậpDữLiệuToolStripMenuItem
            // 
            this.mứcTruyCậpDữLiệuToolStripMenuItem.Image = global::FormUI.Properties.Resources.SolidLightBlueDataBar_16x16;
            this.mứcTruyCậpDữLiệuToolStripMenuItem.Name = "mứcTruyCậpDữLiệuToolStripMenuItem";
            this.mứcTruyCậpDữLiệuToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.mứcTruyCậpDữLiệuToolStripMenuItem.Text = "Mức truy cập dữ liệu";
            this.mứcTruyCậpDữLiệuToolStripMenuItem.Click += new System.EventHandler(this.mứcTruyCậpDữLiệuToolStripMenuItem_Click);
            // 
            // frmUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1118, 651);
            this.Controls.Add(this.splitContainer3);
            this.Name = "frmUser";
            this.Text = "Danh sách người dùng";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmUser_FormClosed);
            this.Load += new System.EventHandler(this.frmUser_Load);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mtreeLookUpDonVi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mTreeLookUpEdit1TreeList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearchUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridUser)).EndInit();
            this.gunaContextMenuStripMoreButton.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer3;
        private DevExpress.XtraEditors.TextEdit txtSearchUser;
        private Guna.UI.WinForms.GunaDataGridView gridUser;
        private System.ComponentModel.BackgroundWorker backgroundWorkerUser;
        private Guna.UI.WinForms.GunaContextMenuStrip gunaContextMenuStripMoreButton;
        private System.Windows.Forms.ToolStripMenuItem viewPermissionToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem thêmMớiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem delToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private Guna.UI.WinForms.GunaButton btnAddUser;
        private Guna.UI.WinForms.GunaLabel lblPlaceHolder;
        private Guna.UI.WinForms.GunaLabel gunaLabel1;
        private MTControl.MTreeLookUpEdit mtreeLookUpDonVi;
        private DevExpress.XtraTreeList.TreeList mTreeLookUpEdit1TreeList;
        private Guna.UI.WinForms.GunaLabel lblRoleId;
        private MTControl.MLookUpEdit cboRoleId;
        private System.Windows.Forms.ToolStripMenuItem mứcTruyCậpDữLiệuToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn FullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrganizationUnitName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRoleName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatusName;
        private System.Windows.Forms.DataGridViewLinkColumn colMucTruyCapDuLieu;
        private System.Windows.Forms.DataGridViewLinkColumn colPermission;
        private System.Windows.Forms.DataGridViewLinkColumn colEdit;
        private System.Windows.Forms.DataGridViewLinkColumn colXoa;
    }
}