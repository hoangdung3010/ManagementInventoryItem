namespace FormUI
{
    partial class frmGeneratorMaVach
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGeneratorMaVach));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnExport = new MTControl.MSimpleButton();
            this.cboSP = new MTControl.MLookUpEdit();
            this.cboNCC = new MTControl.MLookUpEdit();
            this.mLabel7 = new MTControl.MLabel();
            this.btnGenerator = new MTControl.MSimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNamSX = new MTControl.MTextEdit();
            this.mLabel6 = new MTControl.MLabel();
            this.txtSoKetThuc = new MTControl.MTextEdit();
            this.mLabel5 = new MTControl.MLabel();
            this.txtSoBatDau = new MTControl.MTextEdit();
            this.mLabel4 = new MTControl.MLabel();
            this.txtMaNhomTrangThietBi = new MTControl.MTextEdit();
            this.mLabel3 = new MTControl.MLabel();
            this.mLabel2 = new MTControl.MLabel();
            this.txtNguon = new MTControl.MTextEdit();
            this.mLabel1 = new MTControl.MLabel();
            this.grdMaVach = new MTControl.MGridControl();
            this.mGridView1 = new MTControl.MGridView();
            this.bgWorkerSinhMaVach = new System.ComponentModel.BackgroundWorker();
            this.bgExport = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdMaVach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnExport);
            this.splitContainer1.Panel1.Controls.Add(this.cboSP);
            this.splitContainer1.Panel1.Controls.Add(this.cboNCC);
            this.splitContainer1.Panel1.Controls.Add(this.mLabel7);
            this.splitContainer1.Panel1.Controls.Add(this.btnGenerator);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.txtNamSX);
            this.splitContainer1.Panel1.Controls.Add(this.mLabel6);
            this.splitContainer1.Panel1.Controls.Add(this.txtSoKetThuc);
            this.splitContainer1.Panel1.Controls.Add(this.mLabel5);
            this.splitContainer1.Panel1.Controls.Add(this.txtSoBatDau);
            this.splitContainer1.Panel1.Controls.Add(this.mLabel4);
            this.splitContainer1.Panel1.Controls.Add(this.txtMaNhomTrangThietBi);
            this.splitContainer1.Panel1.Controls.Add(this.mLabel3);
            this.splitContainer1.Panel1.Controls.Add(this.mLabel2);
            this.splitContainer1.Panel1.Controls.Add(this.txtNguon);
            this.splitContainer1.Panel1.Controls.Add(this.mLabel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.grdMaVach);
            this.splitContainer1.Size = new System.Drawing.Size(843, 565);
            this.splitContainer1.SplitterDistance = 184;
            this.splitContainer1.TabIndex = 0;
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnExport.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnExport.Appearance.Options.UseFont = true;
            this.btnExport.Appearance.Options.UseForeColor = true;
            this.btnExport.ColumnName = "";
            this.btnExport.Description = null;
            this.btnExport.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.ImageOptions.Image")));
            this.btnExport.Location = new System.Drawing.Point(746, 153);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(86, 24);
            this.btnExport.TabIndex = 17;
            this.btnExport.Text = "Xuất excel";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // cboSP
            // 
            this.cboSP.AddFields = null;
            this.cboSP.AliasFormQuickAdd = null;
            this.cboSP.ColumnsExtend = null;
            this.cboSP.Description = null;
            this.cboSP.DictionaryName = null;
            this.cboSP.EntityName = null;
            this.cboSP.Grid = null;
            this.cboSP.IsAutoLoad = false;
            this.cboSP.IsHideClearValue = false;
            this.cboSP.IsReadOnly = false;
            this.cboSP.IsSetValueManual = false;
            this.cboSP.KeyStore = null;
            this.cboSP.Location = new System.Drawing.Point(124, 94);
            this.cboSP.MapColumnName = null;
            this.cboSP.Name = "cboSP";
            this.cboSP.PrimaryKey = null;
            this.cboSP.QuickSearchName = null;
            this.cboSP.RepositoryItem = null;
            this.cboSP.SetField = null;
            this.cboSP.Size = new System.Drawing.Size(215, 23);
            this.cboSP.Sort = null;
            this.cboSP.TabIndex = 16;
            this.cboSP.ValueDefault = null;
            // 
            // cboNCC
            // 
            this.cboNCC.AddFields = null;
            this.cboNCC.AliasFormQuickAdd = null;
            this.cboNCC.ColumnsExtend = null;
            this.cboNCC.Description = null;
            this.cboNCC.DictionaryName = null;
            this.cboNCC.EntityName = null;
            this.cboNCC.Grid = null;
            this.cboNCC.IsAutoLoad = false;
            this.cboNCC.IsHideClearValue = false;
            this.cboNCC.IsReadOnly = false;
            this.cboNCC.IsSetValueManual = false;
            this.cboNCC.KeyStore = null;
            this.cboNCC.Location = new System.Drawing.Point(124, 38);
            this.cboNCC.MapColumnName = null;
            this.cboNCC.Name = "cboNCC";
            this.cboNCC.PrimaryKey = null;
            this.cboNCC.QuickSearchName = null;
            this.cboNCC.RepositoryItem = null;
            this.cboNCC.SetField = null;
            this.cboNCC.Size = new System.Drawing.Size(215, 23);
            this.cboNCC.Sort = null;
            this.cboNCC.TabIndex = 15;
            this.cboNCC.ValueDefault = null;
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
            this.mLabel7.Location = new System.Drawing.Point(51, 98);
            this.mLabel7.Name = "mLabel7";
            this.mLabel7.Size = new System.Drawing.Size(64, 13);
            this.mLabel7.TabIndex = 14;
            this.mLabel7.Text = "Mã sản phẩm";
            // 
            // btnGenerator
            // 
            this.btnGenerator.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnGenerator.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnGenerator.Appearance.Options.UseFont = true;
            this.btnGenerator.Appearance.Options.UseForeColor = true;
            this.btnGenerator.ColumnName = "";
            this.btnGenerator.Description = null;
            this.btnGenerator.Location = new System.Drawing.Point(202, 153);
            this.btnGenerator.Name = "btnGenerator";
            this.btnGenerator.Size = new System.Drawing.Size(157, 24);
            this.btnGenerator.TabIndex = 7;
            this.btnGenerator.Text = "Thực hiện sinh mã vạch";
            this.btnGenerator.Click += new System.EventHandler(this.btnGenerator_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(365, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(283, 119);
            this.label1.TabIndex = 12;
            this.label1.Text = "Mã vạch gồm 15 số bao gồm như sau:\r\n - Nguồn 1 số\r\n - Nhà cung cấp 1 số\r\n-  Mã nh" +
    "óm trang bị 2 số\r\n-  Mã sản phẩm 4 số\r\n-  Số series 5 số \r\n-  Năm sx 2 số cuối c" +
    "ủa năm";
            // 
            // txtNamSX
            // 
            this.txtNamSX.AutoIncrement = false;
            this.txtNamSX.Description = null;
            this.txtNamSX.Grid = null;
            this.txtNamSX.IsCustomHeight = false;
            this.txtNamSX.IsReadOnly = false;
            this.txtNamSX.IsSetValueManual = false;
            this.txtNamSX.Location = new System.Drawing.Point(124, 154);
            this.txtNamSX.MaxLength = 0;
            this.txtNamSX.Name = "txtNamSX";
            this.txtNamSX.RepositoryItem = null;
            this.txtNamSX.SetField = null;
            this.txtNamSX.Size = new System.Drawing.Size(65, 22);
            this.txtNamSX.TabIndex = 6;
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
            this.mLabel6.Location = new System.Drawing.Point(53, 158);
            this.mLabel6.Name = "mLabel6";
            this.mLabel6.Size = new System.Drawing.Size(65, 13);
            this.mLabel6.TabIndex = 10;
            this.mLabel6.Text = "Năm sản xuất";
            // 
            // txtSoKetThuc
            // 
            this.txtSoKetThuc.AutoIncrement = false;
            this.txtSoKetThuc.Description = null;
            this.txtSoKetThuc.Grid = null;
            this.txtSoKetThuc.IsCustomHeight = false;
            this.txtSoKetThuc.IsReadOnly = false;
            this.txtSoKetThuc.IsSetValueManual = false;
            this.txtSoKetThuc.Location = new System.Drawing.Point(289, 124);
            this.txtSoKetThuc.MaxLength = 0;
            this.txtSoKetThuc.Name = "txtSoKetThuc";
            this.txtSoKetThuc.RepositoryItem = null;
            this.txtSoKetThuc.SetField = null;
            this.txtSoKetThuc.Size = new System.Drawing.Size(70, 22);
            this.txtSoKetThuc.TabIndex = 5;
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
            this.mLabel5.Location = new System.Drawing.Point(202, 128);
            this.mLabel5.Name = "mLabel5";
            this.mLabel5.Size = new System.Drawing.Size(82, 13);
            this.mLabel5.TabIndex = 8;
            this.mLabel5.Text = "Số serial kết thúc";
            // 
            // txtSoBatDau
            // 
            this.txtSoBatDau.AutoIncrement = false;
            this.txtSoBatDau.Description = null;
            this.txtSoBatDau.Grid = null;
            this.txtSoBatDau.IsCustomHeight = false;
            this.txtSoBatDau.IsReadOnly = false;
            this.txtSoBatDau.IsSetValueManual = false;
            this.txtSoBatDau.Location = new System.Drawing.Point(124, 123);
            this.txtSoBatDau.MaxLength = 0;
            this.txtSoBatDau.Name = "txtSoBatDau";
            this.txtSoBatDau.RepositoryItem = null;
            this.txtSoBatDau.SetField = null;
            this.txtSoBatDau.Size = new System.Drawing.Size(65, 22);
            this.txtSoBatDau.TabIndex = 4;
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
            this.mLabel4.Location = new System.Drawing.Point(39, 127);
            this.mLabel4.Name = "mLabel4";
            this.mLabel4.Size = new System.Drawing.Size(80, 13);
            this.mLabel4.TabIndex = 6;
            this.mLabel4.Text = "Số serial bắt đầu";
            // 
            // txtMaNhomTrangThietBi
            // 
            this.txtMaNhomTrangThietBi.AutoIncrement = false;
            this.txtMaNhomTrangThietBi.Description = null;
            this.txtMaNhomTrangThietBi.Grid = null;
            this.txtMaNhomTrangThietBi.IsCustomHeight = false;
            this.txtMaNhomTrangThietBi.IsReadOnly = false;
            this.txtMaNhomTrangThietBi.IsSetValueManual = false;
            this.txtMaNhomTrangThietBi.Location = new System.Drawing.Point(124, 66);
            this.txtMaNhomTrangThietBi.MaxLength = 0;
            this.txtMaNhomTrangThietBi.Name = "txtMaNhomTrangThietBi";
            this.txtMaNhomTrangThietBi.RepositoryItem = null;
            this.txtMaNhomTrangThietBi.SetField = null;
            this.txtMaNhomTrangThietBi.Size = new System.Drawing.Size(100, 22);
            this.txtMaNhomTrangThietBi.TabIndex = 2;
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
            this.mLabel3.Location = new System.Drawing.Point(12, 70);
            this.mLabel3.Name = "mLabel3";
            this.mLabel3.Size = new System.Drawing.Size(105, 13);
            this.mLabel3.TabIndex = 4;
            this.mLabel3.Text = "Mã nhóm trang thiết bị";
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
            this.mLabel2.Location = new System.Drawing.Point(50, 40);
            this.mLabel2.Name = "mLabel2";
            this.mLabel2.Size = new System.Drawing.Size(68, 13);
            this.mLabel2.TabIndex = 2;
            this.mLabel2.Text = "Nhà cung cấp";
            // 
            // txtNguon
            // 
            this.txtNguon.AutoIncrement = false;
            this.txtNguon.Description = null;
            this.txtNguon.Grid = null;
            this.txtNguon.IsCustomHeight = false;
            this.txtNguon.IsReadOnly = false;
            this.txtNguon.IsSetValueManual = false;
            this.txtNguon.Location = new System.Drawing.Point(124, 12);
            this.txtNguon.MaxLength = 0;
            this.txtNguon.Name = "txtNguon";
            this.txtNguon.RepositoryItem = null;
            this.txtNguon.SetField = null;
            this.txtNguon.Size = new System.Drawing.Size(100, 22);
            this.txtNguon.TabIndex = 0;
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
            this.mLabel1.Location = new System.Drawing.Point(85, 15);
            this.mLabel1.Name = "mLabel1";
            this.mLabel1.Size = new System.Drawing.Size(32, 13);
            this.mLabel1.TabIndex = 0;
            this.mLabel1.Text = "Nguồn";
            // 
            // grdMaVach
            // 
            this.grdMaVach.Columns = null;
            this.grdMaVach.ColumnSortInfoCollectionChanged = null;
            this.grdMaVach.CustomModelFields = null;
            this.grdMaVach.CustomRowCellEditing = null;
            this.grdMaVach.Description = null;
            this.grdMaVach.DisableFieldNames = null;
            this.grdMaVach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdMaVach.FilterObjects = null;
            this.grdMaVach.FuncCustomRecordBeforeAddRow = null;
            this.grdMaVach.IsEditable = false;
            this.grdMaVach.IsHideActionAdd = false;
            this.grdMaVach.IsRemoteFilter = false;
            this.grdMaVach.IsSetValueManual = false;
            this.grdMaVach.IsShowDetailButtons = false;
            this.grdMaVach.IsShowFilter = false;
            this.grdMaVach.IsShowHorizontalLine = false;
            this.grdMaVach.IsShowPaging = false;
            this.grdMaVach.IsShowVerticalLine = false;
            this.grdMaVach.KeyName = null;
            this.grdMaVach.Location = new System.Drawing.Point(0, 0);
            this.grdMaVach.MainView = this.mGridView1;
            this.grdMaVach.MarkLoading = false;
            this.grdMaVach.Name = "grdMaVach";
            this.grdMaVach.RowCellStyle = null;
            this.grdMaVach.SetField = null;
            this.grdMaVach.Size = new System.Drawing.Size(843, 377);
            this.grdMaVach.Sort = null;
            this.grdMaVach.StartRemoteFilterRow = null;
            this.grdMaVach.Sumary = null;
            this.grdMaVach.TabIndex = 0;
            this.grdMaVach.TableName = null;
            this.grdMaVach.UserCustomDrawCell = null;
            this.grdMaVach.ValidEditValueChanging = null;
            this.grdMaVach.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.mGridView1});
            this.grdMaVach.ViewName = null;
            // 
            // mGridView1
            // 
            this.mGridView1.GridControl = this.grdMaVach;
            this.mGridView1.IsFilterServer = false;
            this.mGridView1.Name = "mGridView1";
            this.mGridView1.OptionsView.ColumnAutoWidth = false;
            this.mGridView1.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            this.mGridView1.RaiseEventCellValueChanged = false;
            // 
            // bgWorkerSinhMaVach
            // 
            this.bgWorkerSinhMaVach.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorkerSinhMaVach_DoWork);
            this.bgWorkerSinhMaVach.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorkerSinhMaVach_RunWorkerCompleted);
            // 
            // bgExport
            // 
            this.bgExport.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgExport_DoWork);
            this.bgExport.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgExport_RunWorkerCompleted);
            // 
            // frmGeneratorMaVach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 565);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmGeneratorMaVach";
            this.Text = "Quản lý sinh mã vạch";
            this.Load += new System.EventHandler(this.frmGeneratorMaVach_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdMaVach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private MTControl.MLabel mLabel1;
        private MTControl.MLabel mLabel2;
        private MTControl.MTextEdit txtNguon;
        private MTControl.MTextEdit txtMaNhomTrangThietBi;
        private MTControl.MLabel mLabel3;
        private MTControl.MTextEdit txtSoBatDau;
        private MTControl.MLabel mLabel4;
        private MTControl.MTextEdit txtSoKetThuc;
        private MTControl.MLabel mLabel5;
        private MTControl.MTextEdit txtNamSX;
        private MTControl.MLabel mLabel6;
        private System.Windows.Forms.Label label1;
        private MTControl.MSimpleButton btnGenerator;
        private MTControl.MGridControl grdMaVach;
        private MTControl.MGridView mGridView1;
        private System.ComponentModel.BackgroundWorker bgWorkerSinhMaVach;
        private MTControl.MLabel mLabel7;
        private MTControl.MLookUpEdit cboNCC;
        private MTControl.MLookUpEdit cboSP;
        private MTControl.MSimpleButton btnExport;
        private System.ComponentModel.BackgroundWorker bgExport;
    }
}