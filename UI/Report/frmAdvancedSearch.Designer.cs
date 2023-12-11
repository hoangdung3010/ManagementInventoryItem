
namespace FormUI
{
    partial class frmAdvancedSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdvancedSearch));
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.grdMaster = new MTControl.MGridControl();
            this.mGridView1 = new MTControl.MGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnExport = new MTControl.MSimpleButton();
            this.groupControl4 = new DevExpress.XtraEditors.GroupControl();
            this.txtGhiChu = new MTControl.MTextEdit();
            this.mLabel9 = new MTControl.MLabel();
            this.cboTreeDonViSuDung = new MTControl.MTreeLookUpEdit();
            this.mTreeLookUpEdit1TreeList = new DevExpress.XtraTreeList.TreeList();
            this.mLabel8 = new MTControl.MLabel();
            this.cboTrangThai = new MTControl.MComboBox();
            this.mLabel7 = new MTControl.MLabel();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.txtXuatXu = new MTControl.MTextEdit();
            this.mLabel6 = new MTControl.MLabel();
            this.spinNamSX = new MTControl.MSpinEdit();
            this.mLabel5 = new MTControl.MLabel();
            this.cboMangLienLac = new MTControl.MLookUpEdit();
            this.mLabel4 = new MTControl.MLabel();
            this.cboTenSanPham = new MTControl.MLookUpEdit();
            this.mLabel3 = new MTControl.MLabel();
            this.txtMaSanPham = new MTControl.MTextEdit();
            this.mLabel2 = new MTControl.MLabel();
            this.txtsMaVach = new MTControl.MTextEdit();
            this.mLabel1 = new MTControl.MLabel();
            this.btnSearch = new MTControl.MSimpleButton();
            this.bgTimKiem = new System.ComponentModel.BackgroundWorker();
            this.bgExportData = new System.ComponentModel.BackgroundWorker();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).BeginInit();
            this.groupControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboTreeDonViSuDung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mTreeLookUpEdit1TreeList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.groupControl2);
            this.panel2.Location = new System.Drawing.Point(5, 279);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1088, 380);
            this.panel2.TabIndex = 1;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.grdMaster);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(0, 0);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(1088, 380);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "Kết quả tìm kiếm";
            // 
            // grdMaster
            // 
            this.grdMaster.Columns = null;
            this.grdMaster.ColumnSortInfoCollectionChanged = null;
            this.grdMaster.CustomModelFields = null;
            this.grdMaster.CustomRowCellEditing = null;
            this.grdMaster.Description = null;
            this.grdMaster.DisableFieldNames = null;
            this.grdMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdMaster.FilterObjects = null;
            this.grdMaster.FuncCustomRecordBeforeAddRow = null;
            this.grdMaster.IsEditable = false;
            this.grdMaster.IsHideActionAdd = false;
            this.grdMaster.IsRemoteFilter = false;
            this.grdMaster.IsSetValueManual = false;
            this.grdMaster.IsShowDetailButtons = false;
            this.grdMaster.IsShowFilter = false;
            this.grdMaster.IsShowHorizontalLine = false;
            this.grdMaster.IsShowPaging = false;
            this.grdMaster.IsShowVerticalLine = false;
            this.grdMaster.KeyName = null;
            this.grdMaster.Location = new System.Drawing.Point(2, 23);
            this.grdMaster.MainView = this.mGridView1;
            this.grdMaster.MarkLoading = false;
            this.grdMaster.Name = "grdMaster";
            this.grdMaster.RowCellStyle = null;
            this.grdMaster.SetField = null;
            this.grdMaster.Size = new System.Drawing.Size(1084, 355);
            this.grdMaster.Sort = null;
            this.grdMaster.StartRemoteFilterRow = null;
            this.grdMaster.Sumary = null;
            this.grdMaster.TabIndex = 0;
            this.grdMaster.TableName = null;
            this.grdMaster.UserCustomDrawCell = null;
            this.grdMaster.ValidEditValueChanging = null;
            this.grdMaster.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.mGridView1});
            this.grdMaster.ViewName = null;
            // 
            // mGridView1
            // 
            this.mGridView1.GridControl = this.grdMaster;
            this.mGridView1.IsFilterServer = false;
            this.mGridView1.Name = "mGridView1";
            this.mGridView1.OptionsView.ColumnAutoWidth = false;
            this.mGridView1.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            this.mGridView1.RaiseEventCellValueChanged = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.groupControl1);
            this.panel1.Location = new System.Drawing.Point(5, 6);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1088, 272);
            this.panel1.TabIndex = 0;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.btnExport);
            this.groupControl1.Controls.Add(this.groupControl4);
            this.groupControl1.Controls.Add(this.groupControl3);
            this.groupControl1.Controls.Add(this.btnSearch);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1088, 272);
            this.groupControl1.TabIndex = 35;
            this.groupControl1.Text = "Tìm kiếm sản phẩm";
            // 
            // btnExport
            // 
            this.btnExport.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnExport.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnExport.Appearance.Options.UseFont = true;
            this.btnExport.Appearance.Options.UseForeColor = true;
            this.btnExport.ColumnName = "";
            this.btnExport.Description = null;
            this.btnExport.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.ImageOptions.Image")));
            this.btnExport.Location = new System.Drawing.Point(88, 242);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(86, 24);
            this.btnExport.TabIndex = 1;
            this.btnExport.Text = "Xuất excel";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // groupControl4
            // 
            this.groupControl4.Controls.Add(this.txtGhiChu);
            this.groupControl4.Controls.Add(this.mLabel9);
            this.groupControl4.Controls.Add(this.cboTreeDonViSuDung);
            this.groupControl4.Controls.Add(this.mLabel8);
            this.groupControl4.Controls.Add(this.cboTrangThai);
            this.groupControl4.Controls.Add(this.mLabel7);
            this.groupControl4.Location = new System.Drawing.Point(458, 24);
            this.groupControl4.Name = "groupControl4";
            this.groupControl4.Size = new System.Drawing.Size(625, 212);
            this.groupControl4.TabIndex = 36;
            this.groupControl4.Text = "Thiết lập tham số khác";
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.AutoIncrement = false;
            this.txtGhiChu.Description = null;
            this.txtGhiChu.Grid = null;
            this.txtGhiChu.IsCustomHeight = false;
            this.txtGhiChu.IsReadOnly = false;
            this.txtGhiChu.IsSetValueManual = false;
            this.txtGhiChu.Location = new System.Drawing.Point(144, 90);
            this.txtGhiChu.MaxLength = 0;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.RepositoryItem = null;
            this.txtGhiChu.SetField = null;
            this.txtGhiChu.Size = new System.Drawing.Size(375, 22);
            this.txtGhiChu.TabIndex = 14;
            // 
            // mLabel9
            // 
            this.mLabel9.AllowHtmlString = true;
            this.mLabel9.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mLabel9.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.mLabel9.Appearance.Options.UseFont = true;
            this.mLabel9.Appearance.Options.UseForeColor = true;
            this.mLabel9.Appearance.Options.UseTextOptions = true;
            this.mLabel9.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.mLabel9.ColumnName = "";
            this.mLabel9.Description = null;
            this.mLabel9.IsRequired = false;
            this.mLabel9.Location = new System.Drawing.Point(13, 96);
            this.mLabel9.Name = "mLabel9";
            this.mLabel9.Size = new System.Drawing.Size(36, 13);
            this.mLabel9.TabIndex = 15;
            this.mLabel9.Text = "Ghi chú";
            // 
            // cboTreeDonViSuDung
            // 
            this.cboTreeDonViSuDung.AddFields = null;
            this.cboTreeDonViSuDung.AliasFormQuickAdd = null;
            this.cboTreeDonViSuDung.CustomSetFields = null;
            this.cboTreeDonViSuDung.Description = null;
            this.cboTreeDonViSuDung.DictionaryName = null;
            this.cboTreeDonViSuDung.EntityName = null;
            this.cboTreeDonViSuDung.Grid = null;
            this.cboTreeDonViSuDung.IsReadOnly = false;
            this.cboTreeDonViSuDung.IsSetValueManual = false;
            this.cboTreeDonViSuDung.KeyStore = null;
            this.cboTreeDonViSuDung.Location = new System.Drawing.Point(144, 59);
            this.cboTreeDonViSuDung.MapColumnName = null;
            this.cboTreeDonViSuDung.Name = "cboTreeDonViSuDung";
            this.cboTreeDonViSuDung.Properties.ActionButtonIndex = 1;
            this.cboTreeDonViSuDung.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.cboTreeDonViSuDung.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cboTreeDonViSuDung.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.cboTreeDonViSuDung.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cboTreeDonViSuDung.Properties.Appearance.Options.UseBackColor = true;
            this.cboTreeDonViSuDung.Properties.Appearance.Options.UseFont = true;
            this.cboTreeDonViSuDung.Properties.Appearance.Options.UseForeColor = true;
            this.cboTreeDonViSuDung.Properties.AutoHeight = false;
            this.cboTreeDonViSuDung.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete, "", -1, true, false, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "Xóa", "ClearValue", null, DevExpress.Utils.ToolTipAnchor.Default),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboTreeDonViSuDung.Properties.ImmediatePopup = true;
            this.cboTreeDonViSuDung.Properties.NullText = "";
            this.cboTreeDonViSuDung.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.cboTreeDonViSuDung.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cboTreeDonViSuDung.Properties.TreeList = this.mTreeLookUpEdit1TreeList;
            this.cboTreeDonViSuDung.QuickSearchName = null;
            this.cboTreeDonViSuDung.RepositoryItem = null;
            this.cboTreeDonViSuDung.SetField = null;
            this.cboTreeDonViSuDung.Size = new System.Drawing.Size(375, 23);
            this.cboTreeDonViSuDung.TabIndex = 1;
            // 
            // mTreeLookUpEdit1TreeList
            // 
            this.mTreeLookUpEdit1TreeList.Location = new System.Drawing.Point(0, 0);
            this.mTreeLookUpEdit1TreeList.Name = "mTreeLookUpEdit1TreeList";
            this.mTreeLookUpEdit1TreeList.OptionsView.ShowAutoFilterRow = true;
            this.mTreeLookUpEdit1TreeList.OptionsView.ShowIndentAsRowStyle = true;
            this.mTreeLookUpEdit1TreeList.Size = new System.Drawing.Size(400, 200);
            this.mTreeLookUpEdit1TreeList.TabIndex = 0;
            // 
            // mLabel8
            // 
            this.mLabel8.AllowHtmlString = true;
            this.mLabel8.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mLabel8.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.mLabel8.Appearance.Options.UseFont = true;
            this.mLabel8.Appearance.Options.UseForeColor = true;
            this.mLabel8.Appearance.Options.UseTextOptions = true;
            this.mLabel8.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.mLabel8.ColumnName = "";
            this.mLabel8.Description = null;
            this.mLabel8.IsRequired = false;
            this.mLabel8.Location = new System.Drawing.Point(13, 63);
            this.mLabel8.Name = "mLabel8";
            this.mLabel8.Size = new System.Drawing.Size(121, 13);
            this.mLabel8.TabIndex = 13;
            this.mLabel8.Text = "Đơn vị được cấp sử dụng";
            // 
            // cboTrangThai
            // 
            this.cboTrangThai.DefaultValueEnum = -1;
            this.cboTrangThai.Description = null;
            this.cboTrangThai.EntityName = false;
            this.cboTrangThai.EnumData = null;
            this.cboTrangThai.Grid = null;
            this.cboTrangThai.IsAutoLoad = false;
            this.cboTrangThai.IsReadOnly = false;
            this.cboTrangThai.IsSetValueManual = false;
            this.cboTrangThai.LastAcceptedSelectedIndex = 0;
            this.cboTrangThai.Location = new System.Drawing.Point(144, 29);
            this.cboTrangThai.Name = "cboTrangThai";
            this.cboTrangThai.NoDefaultValue = false;
            this.cboTrangThai.RepositoryItem = null;
            this.cboTrangThai.SetField = null;
            this.cboTrangThai.Size = new System.Drawing.Size(142, 23);
            this.cboTrangThai.TabIndex = 0;
            // 
            // mLabel7
            // 
            this.mLabel7.AllowHtmlString = true;
            this.mLabel7.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mLabel7.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.mLabel7.Appearance.Options.UseFont = true;
            this.mLabel7.Appearance.Options.UseForeColor = true;
            this.mLabel7.Appearance.Options.UseTextOptions = true;
            this.mLabel7.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.mLabel7.ColumnName = "";
            this.mLabel7.Description = null;
            this.mLabel7.IsRequired = false;
            this.mLabel7.Location = new System.Drawing.Point(13, 33);
            this.mLabel7.Name = "mLabel7";
            this.mLabel7.Size = new System.Drawing.Size(48, 13);
            this.mLabel7.TabIndex = 11;
            this.mLabel7.Text = "Trạng thái";
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.txtXuatXu);
            this.groupControl3.Controls.Add(this.mLabel6);
            this.groupControl3.Controls.Add(this.spinNamSX);
            this.groupControl3.Controls.Add(this.mLabel5);
            this.groupControl3.Controls.Add(this.cboMangLienLac);
            this.groupControl3.Controls.Add(this.mLabel4);
            this.groupControl3.Controls.Add(this.cboTenSanPham);
            this.groupControl3.Controls.Add(this.mLabel3);
            this.groupControl3.Controls.Add(this.txtMaSanPham);
            this.groupControl3.Controls.Add(this.mLabel2);
            this.groupControl3.Controls.Add(this.txtsMaVach);
            this.groupControl3.Controls.Add(this.mLabel1);
            this.groupControl3.Location = new System.Drawing.Point(7, 24);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(445, 212);
            this.groupControl3.TabIndex = 35;
            this.groupControl3.Text = "Thiết lập tham số sản phẩm";
            // 
            // txtXuatXu
            // 
            this.txtXuatXu.AutoIncrement = false;
            this.txtXuatXu.Description = null;
            this.txtXuatXu.Grid = null;
            this.txtXuatXu.IsCustomHeight = false;
            this.txtXuatXu.IsReadOnly = false;
            this.txtXuatXu.IsSetValueManual = false;
            this.txtXuatXu.Location = new System.Drawing.Point(86, 172);
            this.txtXuatXu.MaxLength = 0;
            this.txtXuatXu.Name = "txtXuatXu";
            this.txtXuatXu.RepositoryItem = null;
            this.txtXuatXu.SetField = null;
            this.txtXuatXu.Size = new System.Drawing.Size(348, 22);
            this.txtXuatXu.TabIndex = 5;
            // 
            // mLabel6
            // 
            this.mLabel6.AllowHtmlString = true;
            this.mLabel6.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mLabel6.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.mLabel6.Appearance.Options.UseFont = true;
            this.mLabel6.Appearance.Options.UseForeColor = true;
            this.mLabel6.Appearance.Options.UseTextOptions = true;
            this.mLabel6.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.mLabel6.ColumnName = "";
            this.mLabel6.Description = null;
            this.mLabel6.IsRequired = false;
            this.mLabel6.Location = new System.Drawing.Point(10, 176);
            this.mLabel6.Name = "mLabel6";
            this.mLabel6.Size = new System.Drawing.Size(36, 13);
            this.mLabel6.TabIndex = 10;
            this.mLabel6.Text = "Xuất xứ";
            // 
            // spinNamSX
            // 
            this.spinNamSX.DataType = MTControl.FormatType.Year;
            this.spinNamSX.DecimalCount = ((byte)(0));
            this.spinNamSX.Description = null;
            this.spinNamSX.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinNamSX.Grid = null;
            this.spinNamSX.IsReadOnly = false;
            this.spinNamSX.IsSetValueManual = false;
            this.spinNamSX.Location = new System.Drawing.Point(86, 145);
            this.spinNamSX.Name = "spinNamSX";
            this.spinNamSX.SetField = null;
            this.spinNamSX.Size = new System.Drawing.Size(130, 22);
            this.spinNamSX.TabIndex = 4;
            // 
            // mLabel5
            // 
            this.mLabel5.AllowHtmlString = true;
            this.mLabel5.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mLabel5.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.mLabel5.Appearance.Options.UseFont = true;
            this.mLabel5.Appearance.Options.UseForeColor = true;
            this.mLabel5.Appearance.Options.UseTextOptions = true;
            this.mLabel5.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.mLabel5.ColumnName = "";
            this.mLabel5.Description = null;
            this.mLabel5.IsRequired = false;
            this.mLabel5.Location = new System.Drawing.Point(10, 150);
            this.mLabel5.Name = "mLabel5";
            this.mLabel5.Size = new System.Drawing.Size(65, 13);
            this.mLabel5.TabIndex = 8;
            this.mLabel5.Text = "Năm sản xuất";
            // 
            // cboMangLienLac
            // 
            this.cboMangLienLac.AddFields = null;
            this.cboMangLienLac.AliasFormQuickAdd = null;
            this.cboMangLienLac.ColumnsExtend = null;
            this.cboMangLienLac.Description = null;
            this.cboMangLienLac.DictionaryName = null;
            this.cboMangLienLac.EntityName = null;
            this.cboMangLienLac.Grid = null;
            this.cboMangLienLac.IsAutoLoad = false;
            this.cboMangLienLac.IsHideClearValue = false;
            this.cboMangLienLac.IsReadOnly = false;
            this.cboMangLienLac.IsSetValueManual = false;
            this.cboMangLienLac.KeyStore = null;
            this.cboMangLienLac.Location = new System.Drawing.Point(86, 87);
            this.cboMangLienLac.MapColumnName = null;
            this.cboMangLienLac.Name = "cboMangLienLac";
            this.cboMangLienLac.PrimaryKey = null;
            this.cboMangLienLac.QuickSearchName = null;
            this.cboMangLienLac.RepositoryItem = null;
            this.cboMangLienLac.SetField = null;
            this.cboMangLienLac.Size = new System.Drawing.Size(348, 23);
            this.cboMangLienLac.Sort = null;
            this.cboMangLienLac.TabIndex = 2;
            this.cboMangLienLac.ValueDefault = null;
            // 
            // mLabel4
            // 
            this.mLabel4.AllowHtmlString = true;
            this.mLabel4.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mLabel4.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.mLabel4.Appearance.Options.UseFont = true;
            this.mLabel4.Appearance.Options.UseForeColor = true;
            this.mLabel4.Appearance.Options.UseTextOptions = true;
            this.mLabel4.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.mLabel4.ColumnName = "";
            this.mLabel4.Description = null;
            this.mLabel4.IsRequired = false;
            this.mLabel4.Location = new System.Drawing.Point(10, 92);
            this.mLabel4.Name = "mLabel4";
            this.mLabel4.Size = new System.Drawing.Size(63, 13);
            this.mLabel4.TabIndex = 6;
            this.mLabel4.Text = "Mạng liên lạc";
            // 
            // cboTenSanPham
            // 
            this.cboTenSanPham.AddFields = null;
            this.cboTenSanPham.AliasFormQuickAdd = null;
            this.cboTenSanPham.ColumnsExtend = null;
            this.cboTenSanPham.Description = null;
            this.cboTenSanPham.DictionaryName = null;
            this.cboTenSanPham.EntityName = null;
            this.cboTenSanPham.Grid = null;
            this.cboTenSanPham.IsAutoLoad = false;
            this.cboTenSanPham.IsHideClearValue = false;
            this.cboTenSanPham.IsReadOnly = false;
            this.cboTenSanPham.IsSetValueManual = false;
            this.cboTenSanPham.KeyStore = null;
            this.cboTenSanPham.Location = new System.Drawing.Point(86, 59);
            this.cboTenSanPham.MapColumnName = null;
            this.cboTenSanPham.Name = "cboTenSanPham";
            this.cboTenSanPham.PrimaryKey = null;
            this.cboTenSanPham.QuickSearchName = null;
            this.cboTenSanPham.RepositoryItem = null;
            this.cboTenSanPham.SetField = null;
            this.cboTenSanPham.Size = new System.Drawing.Size(348, 23);
            this.cboTenSanPham.Sort = null;
            this.cboTenSanPham.TabIndex = 1;
            this.cboTenSanPham.ValueDefault = null;
            // 
            // mLabel3
            // 
            this.mLabel3.AllowHtmlString = true;
            this.mLabel3.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mLabel3.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.mLabel3.Appearance.Options.UseFont = true;
            this.mLabel3.Appearance.Options.UseForeColor = true;
            this.mLabel3.Appearance.Options.UseTextOptions = true;
            this.mLabel3.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.mLabel3.ColumnName = "";
            this.mLabel3.Description = null;
            this.mLabel3.IsRequired = false;
            this.mLabel3.Location = new System.Drawing.Point(10, 63);
            this.mLabel3.Name = "mLabel3";
            this.mLabel3.Size = new System.Drawing.Size(68, 13);
            this.mLabel3.TabIndex = 4;
            this.mLabel3.Text = "Tên sản phẩm";
            // 
            // txtMaSanPham
            // 
            this.txtMaSanPham.AutoIncrement = false;
            this.txtMaSanPham.Description = null;
            this.txtMaSanPham.Grid = null;
            this.txtMaSanPham.IsCustomHeight = false;
            this.txtMaSanPham.IsReadOnly = false;
            this.txtMaSanPham.IsSetValueManual = false;
            this.txtMaSanPham.Location = new System.Drawing.Point(86, 31);
            this.txtMaSanPham.MaxLength = 0;
            this.txtMaSanPham.Name = "txtMaSanPham";
            this.txtMaSanPham.RepositoryItem = null;
            this.txtMaSanPham.SetField = null;
            this.txtMaSanPham.Size = new System.Drawing.Size(217, 22);
            this.txtMaSanPham.TabIndex = 0;
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
            this.mLabel2.Location = new System.Drawing.Point(10, 35);
            this.mLabel2.Name = "mLabel2";
            this.mLabel2.Size = new System.Drawing.Size(64, 13);
            this.mLabel2.TabIndex = 2;
            this.mLabel2.Text = "Mã sản phẩm";
            // 
            // txtsMaVach
            // 
            this.txtsMaVach.AutoIncrement = false;
            this.txtsMaVach.Description = null;
            this.txtsMaVach.Grid = null;
            this.txtsMaVach.IsCustomHeight = false;
            this.txtsMaVach.IsReadOnly = false;
            this.txtsMaVach.IsSetValueManual = false;
            this.txtsMaVach.Location = new System.Drawing.Point(86, 115);
            this.txtsMaVach.MaxLength = 0;
            this.txtsMaVach.Name = "txtsMaVach";
            this.txtsMaVach.RepositoryItem = null;
            this.txtsMaVach.SetField = null;
            this.txtsMaVach.Size = new System.Drawing.Size(348, 22);
            this.txtsMaVach.TabIndex = 3;
            this.txtsMaVach.EditValueChanged += new System.EventHandler(this.txtsMaVach_EditValueChanged);
            this.txtsMaVach.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtsMaVach_KeyDown);
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
            this.mLabel1.Location = new System.Drawing.Point(10, 119);
            this.mLabel1.Name = "mLabel1";
            this.mLabel1.Size = new System.Drawing.Size(41, 13);
            this.mLabel1.TabIndex = 0;
            this.mLabel1.Text = "Mã vạch";
            // 
            // btnSearch
            // 
            this.btnSearch.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnSearch.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnSearch.Appearance.Options.UseFont = true;
            this.btnSearch.Appearance.Options.UseForeColor = true;
            this.btnSearch.ColumnName = "";
            this.btnSearch.Description = null;
            this.btnSearch.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.ImageOptions.Image")));
            this.btnSearch.Location = new System.Drawing.Point(7, 242);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(73, 24);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // bgTimKiem
            // 
            this.bgTimKiem.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgTimKiem_DoWork);
            this.bgTimKiem.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgTimKiem_RunWorkerCompleted);
            // 
            // bgExportData
            // 
            this.bgExportData.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgExportData_DoWork);
            this.bgExportData.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgExportData_RunWorkerCompleted);
            // 
            // frmAdvancedSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1093, 662);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAdvancedSearch";
            this.Text = "frmLichSuNhapXuatSP";
            this.Load += new System.EventHandler(this.frmAdvancedSearch_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).EndInit();
            this.groupControl4.ResumeLayout(false);
            this.groupControl4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboTreeDonViSuDung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mTreeLookUpEdit1TreeList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            this.groupControl3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private MTControl.MLabel mLabel1;
        private MTControl.MTextEdit txtsMaVach;
        private MTControl.MSimpleButton btnSearch;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraEditors.GroupControl groupControl4;
        private MTControl.MSimpleButton btnExport;
        private MTControl.MLabel mLabel2;
        private MTControl.MTextEdit txtMaSanPham;
        private MTControl.MLabel mLabel3;
        private MTControl.MLookUpEdit cboTenSanPham;
        private MTControl.MLookUpEdit cboMangLienLac;
        private MTControl.MLabel mLabel4;
        private MTControl.MLabel mLabel5;
        private MTControl.MTextEdit txtXuatXu;
        private MTControl.MLabel mLabel6;
        private MTControl.MSpinEdit spinNamSX;
        private MTControl.MLabel mLabel7;
        private MTControl.MLabel mLabel8;
        private MTControl.MComboBox cboTrangThai;
        private MTControl.MTreeLookUpEdit cboTreeDonViSuDung;
        private DevExpress.XtraTreeList.TreeList mTreeLookUpEdit1TreeList;
        private MTControl.MGridControl grdMaster;
        private MTControl.MGridView mGridView1;
        private System.ComponentModel.BackgroundWorker bgTimKiem;
        private MTControl.MTextEdit txtGhiChu;
        private MTControl.MLabel mLabel9;
        private System.ComponentModel.BackgroundWorker bgExportData;
    }
}