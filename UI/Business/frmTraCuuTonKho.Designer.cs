
namespace FormUI
{
    partial class frmTraCuuTonKho
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
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTraCuuTonKho));
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbosSanPham = new MTControl.MCheckComboBox();
            this.chkMaVachThucTeTrongKho = new MTControl.MCheckBoxEdit();
            this.chkTaiKho = new MTControl.MCheckBoxEdit();
            this.chkConTon = new MTControl.MCheckBoxEdit();
            this.btnSearch = new FontAwesome.Sharp.IconButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.grd = new MTControl.MGridControl();
            this.mGridView1 = new MTControl.MGridView();
            this.txtMaVach = new MTControl.MTextEdit();
            this.mLabel2 = new MTControl.MLabel();
            this.mLabel1 = new MTControl.MLabel();
            this.treesDM_DonVi_Id_DonVi = new MTControl.MTreeLookUpEdit();
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.mLabel15 = new MTControl.MLabel();
            this.gunaControlBoxMaximumOrMiximum = new Guna.UI.WinForms.GunaControlBox();
            this.gunaControlBoxClose = new Guna.UI.WinForms.GunaControlBox();
            this.gunaControlBoxHide = new Guna.UI.WinForms.GunaControlBox();
            this.gunaResize1 = new Guna.UI.WinForms.GunaResize(this.components);
            this.gunaDragControl2 = new Guna.UI.WinForms.GunaDragControl(this.components);
            this.mSimpleButton1 = new MTControl.MSimpleButton();
            this.btnHelp = new MTControl.MSimpleButton();
            this.btnCancel = new MTControl.MSimpleButton();
            this.lblTitleFormDetail = new MTControl.MLabel();
            this.bgLoadGrid = new System.ComponentModel.BackgroundWorker();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbosSanPham.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkMaVachThucTeTrongKho.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkTaiKho.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkConTon.Properties)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treesDM_DonVi_Id_DonVi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.cbosSanPham);
            this.panel1.Controls.Add(this.chkMaVachThucTeTrongKho);
            this.panel1.Controls.Add(this.chkTaiKho);
            this.panel1.Controls.Add(this.chkConTon);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.txtMaVach);
            this.panel1.Controls.Add(this.mLabel2);
            this.panel1.Controls.Add(this.mLabel1);
            this.panel1.Controls.Add(this.treesDM_DonVi_Id_DonVi);
            this.panel1.Controls.Add(this.mLabel15);
            this.panel1.Location = new System.Drawing.Point(7, 29);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1116, 631);
            this.panel1.TabIndex = 66;
            // 
            // cbosSanPham
            // 
            this.cbosSanPham.AliasFormQuickAdd = null;
            this.cbosSanPham.Description = null;
            this.cbosSanPham.DictionaryName = null;
            this.cbosSanPham.EntityName = null;
            this.cbosSanPham.Grid = null;
            this.cbosSanPham.IsSetValueManual = false;
            this.cbosSanPham.KeyStore = null;
            this.cbosSanPham.Location = new System.Drawing.Point(68, 50);
            this.cbosSanPham.Name = "cbosSanPham";
            this.cbosSanPham.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cbosSanPham.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.cbosSanPham.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cbosSanPham.Properties.Appearance.Options.UseBackColor = true;
            this.cbosSanPham.Properties.Appearance.Options.UseFont = true;
            this.cbosSanPham.Properties.Appearance.Options.UseForeColor = true;
            this.cbosSanPham.Properties.AutoHeight = false;
            this.cbosSanPham.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbosSanPham.QuickSearchName = null;
            this.cbosSanPham.RepositoryItem = null;
            this.cbosSanPham.SetField = null;
            this.cbosSanPham.Size = new System.Drawing.Size(438, 23);
            this.cbosSanPham.TabIndex = 74;
            this.cbosSanPham.EditValueChanged += new System.EventHandler(this.cbosSanPham_EditValueChanged_1);
            // 
            // chkMaVachThucTeTrongKho
            // 
            this.chkMaVachThucTeTrongKho.Description = null;
            this.chkMaVachThucTeTrongKho.IsSetValueManual = false;
            this.chkMaVachThucTeTrongKho.Location = new System.Drawing.Point(525, 21);
            this.chkMaVachThucTeTrongKho.Name = "chkMaVachThucTeTrongKho";
            this.chkMaVachThucTeTrongKho.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.chkMaVachThucTeTrongKho.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.chkMaVachThucTeTrongKho.Properties.Appearance.Options.UseFont = true;
            this.chkMaVachThucTeTrongKho.Properties.Appearance.Options.UseForeColor = true;
            this.chkMaVachThucTeTrongKho.Properties.AutoHeight = false;
            this.chkMaVachThucTeTrongKho.Properties.AutoWidth = true;
            this.chkMaVachThucTeTrongKho.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.chkMaVachThucTeTrongKho.Properties.Caption = "Chỉ hiển thị mã vạch đang có thực tế trong kho";
            this.chkMaVachThucTeTrongKho.SetField = null;
            this.chkMaVachThucTeTrongKho.Size = new System.Drawing.Size(247, 22);
            this.chkMaVachThucTeTrongKho.TabIndex = 3;
            this.chkMaVachThucTeTrongKho.CheckedChanged += new System.EventHandler(this.chkMaVachThucTeTrongKho_CheckedChanged);
            // 
            // chkTaiKho
            // 
            this.chkTaiKho.Description = null;
            this.chkTaiKho.IsSetValueManual = false;
            this.chkTaiKho.Location = new System.Drawing.Point(525, 50);
            this.chkTaiKho.Name = "chkTaiKho";
            this.chkTaiKho.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.chkTaiKho.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.chkTaiKho.Properties.Appearance.Options.UseFont = true;
            this.chkTaiKho.Properties.Appearance.Options.UseForeColor = true;
            this.chkTaiKho.Properties.AutoHeight = false;
            this.chkTaiKho.Properties.AutoWidth = true;
            this.chkTaiKho.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.chkTaiKho.Properties.Caption = "Chỉ hiển thị tồn tại kho, không bao gồm mã vạch đơn vị nhập về sử dụng";
            this.chkTaiKho.SetField = null;
            this.chkTaiKho.Size = new System.Drawing.Size(369, 22);
            this.chkTaiKho.TabIndex = 5;
            this.chkTaiKho.CheckedChanged += new System.EventHandler(this.chkTaiKho_CheckedChanged);
            // 
            // chkConTon
            // 
            this.chkConTon.Description = null;
            this.chkConTon.IsSetValueManual = false;
            this.chkConTon.Location = new System.Drawing.Point(775, 21);
            this.chkConTon.Name = "chkConTon";
            this.chkConTon.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.chkConTon.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.chkConTon.Properties.Appearance.Options.UseFont = true;
            this.chkConTon.Properties.Appearance.Options.UseForeColor = true;
            this.chkConTon.Properties.AutoHeight = false;
            this.chkConTon.Properties.AutoWidth = true;
            this.chkConTon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.chkConTon.Properties.Caption = "Chỉ hiển thị mã vạch còn tồn";
            this.chkConTon.SetField = null;
            this.chkConTon.Size = new System.Drawing.Size(159, 22);
            this.chkConTon.TabIndex = 4;
            this.chkConTon.CheckedChanged += new System.EventHandler(this.chkConTon_CheckedChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnSearch.IconColor = System.Drawing.Color.Black;
            this.btnSearch.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSearch.Location = new System.Drawing.Point(526, 78);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(79, 23);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.grd);
            this.panel2.Location = new System.Drawing.Point(3, 120);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1110, 504);
            this.panel2.TabIndex = 73;
            // 
            // grd
            // 
            this.grd.Columns = null;
            this.grd.ColumnSortInfoCollectionChanged = null;
            this.grd.CustomModelFields = null;
            this.grd.CustomRowCellEditing = null;
            this.grd.Description = null;
            this.grd.DisableFieldNames = null;
            this.grd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd.FilterObjects = null;
            this.grd.FuncCustomRecordBeforeAddRow = null;
            this.grd.IsEditable = false;
            this.grd.IsHideActionAdd = false;
            this.grd.IsRemoteFilter = false;
            this.grd.IsSetValueManual = false;
            this.grd.IsShowDetailButtons = false;
            this.grd.IsShowFilter = false;
            this.grd.IsShowHorizontalLine = false;
            this.grd.IsShowPaging = false;
            this.grd.IsShowVerticalLine = false;
            this.grd.KeyName = null;
            this.grd.Location = new System.Drawing.Point(0, 0);
            this.grd.MainView = this.mGridView1;
            this.grd.Margin = new System.Windows.Forms.Padding(0);
            this.grd.MarkLoading = false;
            this.grd.Name = "grd";
            this.grd.RowCellStyle = null;
            this.grd.SetField = null;
            this.grd.Size = new System.Drawing.Size(1110, 504);
            this.grd.Sort = null;
            this.grd.StartRemoteFilterRow = null;
            this.grd.Sumary = null;
            this.grd.TabIndex = 0;
            this.grd.TableName = null;
            this.grd.UserCustomDrawCell = null;
            this.grd.ValidEditValueChanging = null;
            this.grd.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.mGridView1});
            this.grd.ViewName = null;
            // 
            // mGridView1
            // 
            this.mGridView1.GridControl = this.grd;
            this.mGridView1.IsFilterServer = false;
            this.mGridView1.Name = "mGridView1";
            this.mGridView1.OptionsView.ColumnAutoWidth = false;
            this.mGridView1.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            this.mGridView1.RaiseEventCellValueChanged = false;
            // 
            // txtMaVach
            // 
            this.txtMaVach.AutoIncrement = false;
            this.txtMaVach.Description = null;
            this.txtMaVach.Grid = null;
            this.txtMaVach.IsCustomHeight = false;
            this.txtMaVach.IsReadOnly = false;
            this.txtMaVach.IsRequired = true;
            this.txtMaVach.IsSetValueManual = false;
            this.txtMaVach.Location = new System.Drawing.Point(68, 79);
            this.txtMaVach.MaxLength = 50;
            this.txtMaVach.Name = "txtMaVach";
            this.txtMaVach.RepositoryItem = null;
            this.txtMaVach.SetField = "sChu";
            this.txtMaVach.Size = new System.Drawing.Size(438, 22);
            this.txtMaVach.TabIndex = 2;
            this.txtMaVach.EditValueChanged += new System.EventHandler(this.txtMaVach_EditValueChanged);
            // 
            // mLabel2
            // 
            this.mLabel2.AllowHtmlString = true;
            this.mLabel2.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mLabel2.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.mLabel2.Appearance.Options.UseFont = true;
            this.mLabel2.Appearance.Options.UseForeColor = true;
            this.mLabel2.Appearance.Options.UseTextOptions = true;
            this.mLabel2.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.mLabel2.ColumnName = "";
            this.mLabel2.Description = null;
            this.mLabel2.IsRequired = false;
            this.mLabel2.Location = new System.Drawing.Point(11, 84);
            this.mLabel2.Name = "mLabel2";
            this.mLabel2.Size = new System.Drawing.Size(42, 13);
            this.mLabel2.TabIndex = 70;
            this.mLabel2.Text = "Mã vạch";
            // 
            // mLabel1
            // 
            this.mLabel1.AllowHtmlString = true;
            this.mLabel1.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mLabel1.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.mLabel1.Appearance.Options.UseFont = true;
            this.mLabel1.Appearance.Options.UseForeColor = true;
            this.mLabel1.Appearance.Options.UseTextOptions = true;
            this.mLabel1.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.mLabel1.ColumnName = "";
            this.mLabel1.Description = null;
            this.mLabel1.IsRequired = false;
            this.mLabel1.Location = new System.Drawing.Point(11, 53);
            this.mLabel1.Name = "mLabel1";
            this.mLabel1.Size = new System.Drawing.Size(48, 13);
            this.mLabel1.TabIndex = 68;
            this.mLabel1.Text = "Sản phẩm";
            // 
            // treesDM_DonVi_Id_DonVi
            // 
            this.treesDM_DonVi_Id_DonVi.AddFields = null;
            this.treesDM_DonVi_Id_DonVi.AliasFormQuickAdd = null;
            this.treesDM_DonVi_Id_DonVi.CustomSetFields = null;
            this.treesDM_DonVi_Id_DonVi.Description = null;
            this.treesDM_DonVi_Id_DonVi.DictionaryName = null;
            this.treesDM_DonVi_Id_DonVi.EntityName = null;
            this.treesDM_DonVi_Id_DonVi.Grid = null;
            this.treesDM_DonVi_Id_DonVi.IsReadOnly = false;
            this.treesDM_DonVi_Id_DonVi.IsRequired = true;
            this.treesDM_DonVi_Id_DonVi.IsSetValueManual = false;
            this.treesDM_DonVi_Id_DonVi.KeyStore = null;
            this.treesDM_DonVi_Id_DonVi.Location = new System.Drawing.Point(68, 19);
            this.treesDM_DonVi_Id_DonVi.MapColumnName = null;
            this.treesDM_DonVi_Id_DonVi.Name = "treesDM_DonVi_Id_DonVi";
            this.treesDM_DonVi_Id_DonVi.Properties.ActionButtonIndex = 1;
            this.treesDM_DonVi_Id_DonVi.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.treesDM_DonVi_Id_DonVi.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.treesDM_DonVi_Id_DonVi.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treesDM_DonVi_Id_DonVi.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treesDM_DonVi_Id_DonVi.Properties.Appearance.Options.UseBackColor = true;
            this.treesDM_DonVi_Id_DonVi.Properties.Appearance.Options.UseFont = true;
            this.treesDM_DonVi_Id_DonVi.Properties.Appearance.Options.UseForeColor = true;
            this.treesDM_DonVi_Id_DonVi.Properties.AutoHeight = false;
            this.treesDM_DonVi_Id_DonVi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete, "", -1, true, false, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "Xóa", "ClearValue", null, DevExpress.Utils.ToolTipAnchor.Default),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.treesDM_DonVi_Id_DonVi.Properties.ImmediatePopup = true;
            this.treesDM_DonVi_Id_DonVi.Properties.NullText = "";
            this.treesDM_DonVi_Id_DonVi.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.treesDM_DonVi_Id_DonVi.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.treesDM_DonVi_Id_DonVi.Properties.TreeList = this.treeList1;
            this.treesDM_DonVi_Id_DonVi.QuickSearchName = null;
            this.treesDM_DonVi_Id_DonVi.RepositoryItem = null;
            this.treesDM_DonVi_Id_DonVi.SetField = "sDM_DonVi_Id_Xuat";
            this.treesDM_DonVi_Id_DonVi.Size = new System.Drawing.Size(438, 23);
            this.treesDM_DonVi_Id_DonVi.TabIndex = 0;
            this.treesDM_DonVi_Id_DonVi.EditValueChanged += new System.EventHandler(this.treesDM_DonVi_Id_DonVi_EditValueChanged);
            // 
            // treeList1
            // 
            this.treeList1.KeyFieldName = "";
            this.treeList1.Location = new System.Drawing.Point(446, 215);
            this.treeList1.Name = "treeList1";
            this.treeList1.OptionsView.ShowAutoFilterRow = true;
            this.treeList1.OptionsView.ShowIndentAsRowStyle = true;
            this.treeList1.Size = new System.Drawing.Size(400, 200);
            this.treeList1.TabIndex = 0;
            // 
            // mLabel15
            // 
            this.mLabel15.AllowHtmlString = true;
            this.mLabel15.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mLabel15.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.mLabel15.Appearance.Options.UseFont = true;
            this.mLabel15.Appearance.Options.UseForeColor = true;
            this.mLabel15.Appearance.Options.UseTextOptions = true;
            this.mLabel15.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.mLabel15.ColumnName = "";
            this.mLabel15.Description = null;
            this.mLabel15.IsRequired = false;
            this.mLabel15.Location = new System.Drawing.Point(11, 21);
            this.mLabel15.Name = "mLabel15";
            this.mLabel15.Size = new System.Drawing.Size(31, 13);
            this.mLabel15.TabIndex = 64;
            this.mLabel15.Text = "Đơn vị";
            // 
            // gunaControlBoxMaximumOrMiximum
            // 
            this.gunaControlBoxMaximumOrMiximum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gunaControlBoxMaximumOrMiximum.Animated = true;
            this.gunaControlBoxMaximumOrMiximum.AnimationHoverSpeed = 0.07F;
            this.gunaControlBoxMaximumOrMiximum.AnimationSpeed = 0.03F;
            this.gunaControlBoxMaximumOrMiximum.ControlBoxType = Guna.UI.WinForms.FormControlBoxType.MaximizeBox;
            this.gunaControlBoxMaximumOrMiximum.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(85)))), ((int)(((byte)(244)))));
            this.gunaControlBoxMaximumOrMiximum.IconSize = 12F;
            this.gunaControlBoxMaximumOrMiximum.Location = new System.Drawing.Point(1088, 0);
            this.gunaControlBoxMaximumOrMiximum.MaximumSize = new System.Drawing.Size(20, 20);
            this.gunaControlBoxMaximumOrMiximum.MinimumSize = new System.Drawing.Size(20, 20);
            this.gunaControlBoxMaximumOrMiximum.Name = "gunaControlBoxMaximumOrMiximum";
            this.gunaControlBoxMaximumOrMiximum.OnHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(58)))), ((int)(((byte)(183)))));
            this.gunaControlBoxMaximumOrMiximum.OnHoverIconColor = System.Drawing.Color.White;
            this.gunaControlBoxMaximumOrMiximum.OnPressedColor = System.Drawing.Color.Black;
            this.gunaControlBoxMaximumOrMiximum.Size = new System.Drawing.Size(20, 20);
            this.gunaControlBoxMaximumOrMiximum.TabIndex = 8;
            // 
            // gunaControlBoxClose
            // 
            this.gunaControlBoxClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gunaControlBoxClose.Animated = true;
            this.gunaControlBoxClose.AnimationHoverSpeed = 0.07F;
            this.gunaControlBoxClose.AnimationSpeed = 0.03F;
            this.gunaControlBoxClose.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(85)))), ((int)(((byte)(244)))));
            this.gunaControlBoxClose.IconSize = 12F;
            this.gunaControlBoxClose.Location = new System.Drawing.Point(1113, 0);
            this.gunaControlBoxClose.MaximumSize = new System.Drawing.Size(20, 20);
            this.gunaControlBoxClose.MinimumSize = new System.Drawing.Size(20, 20);
            this.gunaControlBoxClose.Name = "gunaControlBoxClose";
            this.gunaControlBoxClose.OnHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(58)))), ((int)(((byte)(183)))));
            this.gunaControlBoxClose.OnHoverIconColor = System.Drawing.Color.White;
            this.gunaControlBoxClose.OnPressedColor = System.Drawing.Color.Black;
            this.gunaControlBoxClose.Size = new System.Drawing.Size(20, 20);
            this.gunaControlBoxClose.TabIndex = 6;
            // 
            // gunaControlBoxHide
            // 
            this.gunaControlBoxHide.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gunaControlBoxHide.Animated = true;
            this.gunaControlBoxHide.AnimationHoverSpeed = 0.07F;
            this.gunaControlBoxHide.AnimationSpeed = 0.03F;
            this.gunaControlBoxHide.ControlBoxType = Guna.UI.WinForms.FormControlBoxType.MinimizeBox;
            this.gunaControlBoxHide.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(85)))), ((int)(((byte)(244)))));
            this.gunaControlBoxHide.IconSize = 12F;
            this.gunaControlBoxHide.Location = new System.Drawing.Point(1060, 0);
            this.gunaControlBoxHide.MaximumSize = new System.Drawing.Size(20, 20);
            this.gunaControlBoxHide.Name = "gunaControlBoxHide";
            this.gunaControlBoxHide.OnHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(58)))), ((int)(((byte)(183)))));
            this.gunaControlBoxHide.OnHoverIconColor = System.Drawing.Color.White;
            this.gunaControlBoxHide.OnPressedColor = System.Drawing.Color.Black;
            this.gunaControlBoxHide.Size = new System.Drawing.Size(20, 20);
            this.gunaControlBoxHide.TabIndex = 7;
            // 
            // gunaResize1
            // 
            this.gunaResize1.TargetForm = this;
            // 
            // gunaDragControl2
            // 
            this.gunaDragControl2.TargetControl = this;
            // 
            // mSimpleButton1
            // 
            this.mSimpleButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.mSimpleButton1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.mSimpleButton1.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.mSimpleButton1.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.mSimpleButton1.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mSimpleButton1.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.mSimpleButton1.Appearance.Options.UseBackColor = true;
            this.mSimpleButton1.Appearance.Options.UseBorderColor = true;
            this.mSimpleButton1.Appearance.Options.UseFont = true;
            this.mSimpleButton1.Appearance.Options.UseForeColor = true;
            this.mSimpleButton1.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(222)))), ((int)(((byte)(251)))));
            this.mSimpleButton1.AppearanceHovered.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(222)))), ((int)(((byte)(251)))));
            this.mSimpleButton1.AppearanceHovered.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(214)))), ((int)(((byte)(214)))));
            this.mSimpleButton1.AppearanceHovered.Options.UseBackColor = true;
            this.mSimpleButton1.AppearanceHovered.Options.UseBorderColor = true;
            this.mSimpleButton1.AppearancePressed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(222)))), ((int)(((byte)(251)))));
            this.mSimpleButton1.AppearancePressed.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(222)))), ((int)(((byte)(251)))));
            this.mSimpleButton1.AppearancePressed.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(210)))));
            this.mSimpleButton1.AppearancePressed.Options.UseBackColor = true;
            this.mSimpleButton1.AppearancePressed.Options.UseBorderColor = true;
            this.mSimpleButton1.ColumnName = "";
            this.mSimpleButton1.Description = null;
            this.mSimpleButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("mSimpleButton1.ImageOptions.Image")));
            this.mSimpleButton1.Location = new System.Drawing.Point(9, 664);
            this.mSimpleButton1.Margin = new System.Windows.Forms.Padding(8, 8, 3, 8);
            this.mSimpleButton1.Name = "mSimpleButton1";
            this.mSimpleButton1.Size = new System.Drawing.Size(68, 24);
            this.mSimpleButton1.TabIndex = 14;
            this.mSimpleButton1.Text = "Trợ giúp";
            // 
            // btnHelp
            // 
            this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnHelp.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.btnHelp.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.btnHelp.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.btnHelp.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnHelp.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnHelp.Appearance.Options.UseBackColor = true;
            this.btnHelp.Appearance.Options.UseBorderColor = true;
            this.btnHelp.Appearance.Options.UseFont = true;
            this.btnHelp.Appearance.Options.UseForeColor = true;
            this.btnHelp.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(222)))), ((int)(((byte)(251)))));
            this.btnHelp.AppearanceHovered.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(222)))), ((int)(((byte)(251)))));
            this.btnHelp.AppearanceHovered.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(214)))), ((int)(((byte)(214)))));
            this.btnHelp.AppearanceHovered.Options.UseBackColor = true;
            this.btnHelp.AppearanceHovered.Options.UseBorderColor = true;
            this.btnHelp.AppearancePressed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(222)))), ((int)(((byte)(251)))));
            this.btnHelp.AppearancePressed.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(222)))), ((int)(((byte)(251)))));
            this.btnHelp.AppearancePressed.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(210)))));
            this.btnHelp.AppearancePressed.Options.UseBackColor = true;
            this.btnHelp.AppearancePressed.Options.UseBorderColor = true;
            this.btnHelp.ColumnName = "";
            this.btnHelp.Description = null;
            this.btnHelp.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnHelp.ImageOptions.Image")));
            this.btnHelp.Location = new System.Drawing.Point(-205, 664);
            this.btnHelp.Margin = new System.Windows.Forms.Padding(8, 8, 3, 8);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(69, 24);
            this.btnHelp.TabIndex = 13;
            this.btnHelp.Text = "Trợ giúp";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.btnCancel.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.btnCancel.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(214)))), ((int)(((byte)(214)))));
            this.btnCancel.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnCancel.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCancel.Appearance.Options.UseBackColor = true;
            this.btnCancel.Appearance.Options.UseBorderColor = true;
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.Appearance.Options.UseForeColor = true;
            this.btnCancel.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(222)))), ((int)(((byte)(251)))));
            this.btnCancel.AppearanceHovered.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(222)))), ((int)(((byte)(251)))));
            this.btnCancel.AppearanceHovered.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(214)))), ((int)(((byte)(214)))));
            this.btnCancel.AppearanceHovered.Options.UseBackColor = true;
            this.btnCancel.AppearanceHovered.Options.UseBorderColor = true;
            this.btnCancel.AppearancePressed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(222)))), ((int)(((byte)(251)))));
            this.btnCancel.AppearancePressed.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(222)))), ((int)(((byte)(251)))));
            this.btnCancel.AppearancePressed.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(210)))));
            this.btnCancel.AppearancePressed.Options.UseBackColor = true;
            this.btnCancel.AppearancePressed.Options.UseBorderColor = true;
            this.btnCancel.ColumnName = "";
            this.btnCancel.Description = null;
            this.btnCancel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.ImageOptions.Image")));
            this.btnCancel.Location = new System.Drawing.Point(1056, 664);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 8, 8, 8);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(65, 24);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Hủy bỏ";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblTitleFormDetail
            // 
            this.lblTitleFormDetail.AllowHtmlString = true;
            this.lblTitleFormDetail.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblTitleFormDetail.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTitleFormDetail.Appearance.Options.UseFont = true;
            this.lblTitleFormDetail.Appearance.Options.UseForeColor = true;
            this.lblTitleFormDetail.Appearance.Options.UseTextOptions = true;
            this.lblTitleFormDetail.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lblTitleFormDetail.ColumnName = "";
            this.lblTitleFormDetail.Description = null;
            this.lblTitleFormDetail.IsRequired = false;
            this.lblTitleFormDetail.IsTitleForm = true;
            this.lblTitleFormDetail.Location = new System.Drawing.Point(7, 2);
            this.lblTitleFormDetail.Name = "lblTitleFormDetail";
            this.lblTitleFormDetail.Size = new System.Drawing.Size(126, 22);
            this.lblTitleFormDetail.TabIndex = 9;
            this.lblTitleFormDetail.Text = "Tra cứu tồn kho";
            // 
            // bgLoadGrid
            // 
            this.bgLoadGrid.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgLoadGrid_DoWork);
            this.bgLoadGrid.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgLoadGrid_RunWorkerCompleted);
            // 
            // frmTraCuuTonKho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(219)))), ((int)(((byte)(233)))));
            this.ClientSize = new System.Drawing.Size(1134, 695);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.mSimpleButton1);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblTitleFormDetail);
            this.Controls.Add(this.gunaControlBoxMaximumOrMiximum);
            this.Controls.Add(this.gunaControlBoxClose);
            this.Controls.Add(this.gunaControlBoxHide);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmTraCuuTonKho";
            this.Load += new System.EventHandler(this.frmTraCuuTonKho_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbosSanPham.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkMaVachThucTeTrongKho.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkTaiKho.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkConTon.Properties)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treesDM_DonVi_Id_DonVi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Guna.UI.WinForms.GunaControlBox gunaControlBoxMaximumOrMiximum;
        public Guna.UI.WinForms.GunaControlBox gunaControlBoxClose;
        public Guna.UI.WinForms.GunaControlBox gunaControlBoxHide;
        protected MTControl.MLabel lblTitleFormDetail;
        public MTControl.MSimpleButton btnHelp;
        public MTControl.MSimpleButton btnCancel;
        public MTControl.MSimpleButton mSimpleButton1;
        private MTControl.MLabel mLabel15;
        private Guna.UI.WinForms.GunaResize gunaResize1;
        private Guna.UI.WinForms.GunaDragControl gunaDragControl2;
        private System.Windows.Forms.Panel panel1;
        private MTControl.MLabel mLabel1;
        private MTControl.MTreeLookUpEdit treesDM_DonVi_Id_DonVi;
        private DevExpress.XtraTreeList.TreeList treeList1;
        private MTControl.MLabel mLabel2;
        private MTControl.MTextEdit txtMaVach;
        private System.Windows.Forms.Panel panel2;
        private MTControl.MGridControl grd;
        private MTControl.MGridView mGridView1;
        private FontAwesome.Sharp.IconButton btnSearch;
        private System.ComponentModel.BackgroundWorker bgLoadGrid;
        private MTControl.MCheckBoxEdit chkConTon;
        private MTControl.MCheckBoxEdit chkTaiKho;
        private MTControl.MCheckBoxEdit chkMaVachThucTeTrongKho;
        private MTControl.MCheckComboBox cbosSanPham;
    }
}