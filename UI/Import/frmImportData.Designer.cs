namespace FormUI
{
    partial class frmImportData
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImportData));
            this.tabControl = new MTControl.MXtraTabControl();
            this.tabSelectFile = new DevExpress.XtraTab.XtraTabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.iconPictureBox2 = new FontAwesome.Sharp.IconPictureBox();
            this.btnSourcePath = new FontAwesome.Sharp.IconPictureBox();
            this.cboDataType = new MTControl.MComboBox();
            this.iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            this.mLabel6 = new MTControl.MLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rdoImportType = new MTControl.MRadioGroup();
            this.mLabel5 = new MTControl.MLabel();
            this.nbrRowPosition = new MTControl.MSpinEdit();
            this.mLabel4 = new MTControl.MLabel();
            this.cboSheet = new MTControl.MLookUpEdit();
            this.mLabel3 = new MTControl.MLabel();
            this.txtBrowserFile = new MTControl.MTextEdit();
            this.mLabel2 = new MTControl.MLabel();
            this.mLabel1 = new MTControl.MLabel();
            this.tabMerge = new DevExpress.XtraTab.XtraTabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.grdColumnMatch = new MTControl.MGridControl();
            this.mGridView1 = new MTControl.MGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.tabCheckData = new DevExpress.XtraTab.XtraTabPage();
            this.panel5 = new System.Windows.Forms.Panel();
            this.grdCheckData = new MTControl.MGridControl();
            this.mGridView2 = new MTControl.MGridView();
            this.richTextBoxB3 = new System.Windows.Forms.RichTextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCheckData = new Guna.UI.WinForms.GunaButton();
            this.btnEditFile = new Guna.UI.WinForms.GunaButton();
            this.lblInvalid = new MTControl.MLabel();
            this.lblValid = new MTControl.MLabel();
            this.tabResult = new DevExpress.XtraTab.XtraTabPage();
            this.btnViewResultImport = new FontAwesome.Sharp.IconPictureBox();
            this.lblResultImport = new MTControl.MLabel();
            this.progressBarExeImport = new System.Windows.Forms.ProgressBar();
            this.lblUpdateSuccess = new MTControl.MLabel();
            this.lblAddSuccess = new MTControl.MLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnHelp = new MTControl.MSimpleButton();
            this.btnPrevious = new MTControl.MSimpleButton();
            this.btnNext = new MTControl.MSimpleButton();
            this.btnCancel = new MTControl.MSimpleButton();
            this.bgExecuteImport = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabSelectFile.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSourcePath)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdoImportType.Properties)).BeginInit();
            this.tabMerge.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdColumnMatch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.tabCheckData.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCheckData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mGridView2)).BeginInit();
            this.panel4.SuspendLayout();
            this.tabResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnViewResultImport)).BeginInit();
            this.pnlBody.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(117)))), ((int)(((byte)(188)))));
            this.tabControl.Appearance.Options.UseForeColor = true;
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Left;
            this.tabControl.HeaderOrientation = DevExpress.XtraTab.TabOrientation.Horizontal;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedTabPage = this.tabSelectFile;
            this.tabControl.Size = new System.Drawing.Size(1022, 585);
            this.tabControl.TabIndex = 0;
            this.tabControl.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabSelectFile,
            this.tabMerge,
            this.tabCheckData,
            this.tabResult});
            this.tabControl.SelectedPageChanging += new DevExpress.XtraTab.TabPageChangingEventHandler(this.tabControl_SelectedPageChanging);
            // 
            // tabSelectFile
            // 
            this.tabSelectFile.Appearance.Header.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tabSelectFile.Appearance.Header.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tabSelectFile.Appearance.Header.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(118)))));
            this.tabSelectFile.Appearance.Header.Options.UseBorderColor = true;
            this.tabSelectFile.Appearance.Header.Options.UseFont = true;
            this.tabSelectFile.Appearance.Header.Options.UseForeColor = true;
            this.tabSelectFile.Controls.Add(this.panel1);
            this.tabSelectFile.Name = "tabSelectFile";
            this.tabSelectFile.Size = new System.Drawing.Size(900, 583);
            this.tabSelectFile.Text = "1. Chọn tệp nguồn";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.iconPictureBox2);
            this.panel1.Controls.Add(this.btnSourcePath);
            this.panel1.Controls.Add(this.cboDataType);
            this.panel1.Controls.Add(this.iconPictureBox1);
            this.panel1.Controls.Add(this.mLabel6);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.rdoImportType);
            this.panel1.Controls.Add(this.mLabel5);
            this.panel1.Controls.Add(this.nbrRowPosition);
            this.panel1.Controls.Add(this.mLabel4);
            this.panel1.Controls.Add(this.cboSheet);
            this.panel1.Controls.Add(this.mLabel3);
            this.panel1.Controls.Add(this.txtBrowserFile);
            this.panel1.Controls.Add(this.mLabel2);
            this.panel1.Controls.Add(this.mLabel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(900, 583);
            this.panel1.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label7.Location = new System.Drawing.Point(151, 316);
            this.label7.Margin = new System.Windows.Forms.Padding(0);
            this.label7.MaximumSize = new System.Drawing.Size(424, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(421, 45);
            this.label7.TabIndex = 23;
            this.label7.Text = "Nên sử dụng theo định dạng tệp dữ liệu mẫu của chương trình, chương trình sẽ tự đ" +
    "ộng nhận biết các cột dữ liệu trên tệp với các thông tin tương ứng trên chương t" +
    "rình";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label6.Location = new System.Drawing.Point(149, 233);
            this.label6.Margin = new System.Windows.Forms.Padding(0);
            this.label6.MaximumSize = new System.Drawing.Size(424, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(419, 30);
            this.label6.TabIndex = 22;
            this.label6.Text = "Dữ liệu trên tệp mà chưa có trên hệ thống sẽ được thêm mới. Dữ liệu mà đã có trên" +
    " hệ thống sẽ được cập nhật vào.";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label5.Location = new System.Drawing.Point(149, 164);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.MaximumSize = new System.Drawing.Size(424, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(419, 30);
            this.label5.TabIndex = 21;
            this.label5.Text = "Dữ liệu trên tệp mà chưa có trên hệ thống sẽ được thêm mới. Dữ liệu mà đã có trên" +
    " hệ thống sẽ không được cập nhật vào.";
            // 
            // iconPictureBox2
            // 
            this.iconPictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.iconPictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconPictureBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(117)))), ((int)(((byte)(188)))));
            this.iconPictureBox2.IconChar = FontAwesome.Sharp.IconChar.Download;
            this.iconPictureBox2.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(117)))), ((int)(((byte)(188)))));
            this.iconPictureBox2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox2.IconSize = 24;
            this.iconPictureBox2.Location = new System.Drawing.Point(150, 284);
            this.iconPictureBox2.Name = "iconPictureBox2";
            this.iconPictureBox2.Size = new System.Drawing.Size(30, 24);
            this.iconPictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.iconPictureBox2.TabIndex = 20;
            this.iconPictureBox2.TabStop = false;
            this.iconPictureBox2.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // btnSourcePath
            // 
            this.btnSourcePath.BackColor = System.Drawing.Color.Transparent;
            this.btnSourcePath.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSourcePath.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(117)))), ((int)(((byte)(188)))));
            this.btnSourcePath.IconChar = FontAwesome.Sharp.IconChar.FileUpload;
            this.btnSourcePath.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(117)))), ((int)(((byte)(188)))));
            this.btnSourcePath.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSourcePath.IconSize = 24;
            this.btnSourcePath.Location = new System.Drawing.Point(581, 45);
            this.btnSourcePath.Name = "btnSourcePath";
            this.btnSourcePath.Size = new System.Drawing.Size(28, 24);
            this.btnSourcePath.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnSourcePath.TabIndex = 19;
            this.btnSourcePath.TabStop = false;
            this.btnSourcePath.Click += new System.EventHandler(this.btnSourcePath_Click);
            // 
            // cboDataType
            // 
            this.cboDataType.DefaultValueEnum = -1;
            this.cboDataType.Description = null;
            this.cboDataType.EntityName = false;
            this.cboDataType.EnumData = null;
            this.cboDataType.Grid = null;
            this.cboDataType.IsAutoLoad = false;
            this.cboDataType.IsReadOnly = false;
            this.cboDataType.IsSetValueManual = false;
            this.cboDataType.LastAcceptedSelectedIndex = 0;
            this.cboDataType.Location = new System.Drawing.Point(152, 13);
            this.cboDataType.Name = "cboDataType";
            this.cboDataType.NoDefaultValue = false;
            this.cboDataType.RepositoryItem = null;
            this.cboDataType.SetField = null;
            this.cboDataType.Size = new System.Drawing.Size(426, 23);
            this.cboDataType.TabIndex = 0;
            this.cboDataType.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.cboDataType_EditValueChanging);
            // 
            // iconPictureBox1
            // 
            this.iconPictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.iconPictureBox1.ForeColor = System.Drawing.Color.Yellow;
            this.iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.ExclamationTriangle;
            this.iconPictureBox1.IconColor = System.Drawing.Color.Yellow;
            this.iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox1.Location = new System.Drawing.Point(112, 322);
            this.iconPictureBox1.Name = "iconPictureBox1";
            this.iconPictureBox1.Size = new System.Drawing.Size(32, 32);
            this.iconPictureBox1.TabIndex = 17;
            this.iconPictureBox1.TabStop = false;
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
            this.mLabel6.Location = new System.Drawing.Point(16, 286);
            this.mLabel6.Name = "mLabel6";
            this.mLabel6.Size = new System.Drawing.Size(102, 13);
            this.mLabel6.TabIndex = 15;
            this.mLabel6.Text = "6. Tải tệp dữ liệu mẫu";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(149, 210);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "2. Nhập khẩu cập nhật";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(149, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "1. Nhập khẩu thêm mới";
            // 
            // rdoImportType
            // 
            this.rdoImportType.Description = null;
            this.rdoImportType.IsSetValueManual = false;
            this.rdoImportType.Location = new System.Drawing.Point(152, 109);
            this.rdoImportType.Name = "rdoImportType";
            this.rdoImportType.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.rdoImportType.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.rdoImportType.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.rdoImportType.Properties.Appearance.Options.UseBackColor = true;
            this.rdoImportType.Properties.Appearance.Options.UseFont = true;
            this.rdoImportType.Properties.Appearance.Options.UseForeColor = true;
            this.rdoImportType.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "Nhập khẩu thêm mới"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(2, "Nhập khẩu cập nhật")});
            this.rdoImportType.SetField = null;
            this.rdoImportType.Size = new System.Drawing.Size(424, 22);
            this.rdoImportType.TabIndex = 5;
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
            this.mLabel5.Location = new System.Drawing.Point(14, 114);
            this.mLabel5.Name = "mLabel5";
            this.mLabel5.Size = new System.Drawing.Size(130, 13);
            this.mLabel5.TabIndex = 8;
            this.mLabel5.Text = "5. Phương thức nhập khẩu:";
            // 
            // nbrRowPosition
            // 
            this.nbrRowPosition.DataType = MTControl.FormatType.None;
            this.nbrRowPosition.DecimalCount = ((byte)(0));
            this.nbrRowPosition.Description = null;
            this.nbrRowPosition.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nbrRowPosition.Grid = null;
            this.nbrRowPosition.IsReadOnly = false;
            this.nbrRowPosition.IsSetValueManual = false;
            this.nbrRowPosition.Location = new System.Drawing.Point(412, 78);
            this.nbrRowPosition.Name = "nbrRowPosition";
            this.nbrRowPosition.SetField = null;
            this.nbrRowPosition.Size = new System.Drawing.Size(69, 22);
            this.nbrRowPosition.TabIndex = 4;
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
            this.mLabel4.Location = new System.Drawing.Point(265, 82);
            this.mLabel4.Name = "mLabel4";
            this.mLabel4.Size = new System.Drawing.Size(140, 13);
            this.mLabel4.TabIndex = 6;
            this.mLabel4.Text = "4. Chọn dòng làm tiêu đề cột:";
            // 
            // cboSheet
            // 
            this.cboSheet.AddFields = null;
            this.cboSheet.AliasFormQuickAdd = null;
            this.cboSheet.ColumnsExtend = null;
            this.cboSheet.Description = null;
            this.cboSheet.DictionaryName = null;
            this.cboSheet.EntityName = null;
            this.cboSheet.Grid = null;
            this.cboSheet.IsAutoLoad = false;
            this.cboSheet.IsHideClearValue = false;
            this.cboSheet.IsReadOnly = false;
            this.cboSheet.IsSetValueManual = false;
            this.cboSheet.KeyStore = null;
            this.cboSheet.Location = new System.Drawing.Point(152, 76);
            this.cboSheet.MapColumnName = null;
            this.cboSheet.Name = "cboSheet";
            this.cboSheet.PrimaryKey = null;
            this.cboSheet.QuickSearchName = null;
            this.cboSheet.RepositoryItem = null;
            this.cboSheet.SetField = null;
            this.cboSheet.Size = new System.Drawing.Size(106, 23);
            this.cboSheet.Sort = null;
            this.cboSheet.TabIndex = 3;
            this.cboSheet.ValueDefault = null;
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
            this.mLabel3.Location = new System.Drawing.Point(14, 80);
            this.mLabel3.Name = "mLabel3";
            this.mLabel3.Size = new System.Drawing.Size(132, 13);
            this.mLabel3.TabIndex = 4;
            this.mLabel3.Text = "3. Chọn Sheet chứa dữ liệu:";
            // 
            // txtBrowserFile
            // 
            this.txtBrowserFile.AutoIncrement = false;
            this.txtBrowserFile.Description = null;
            this.txtBrowserFile.Grid = null;
            this.txtBrowserFile.IsCustomHeight = false;
            this.txtBrowserFile.IsReadOnly = true;
            this.txtBrowserFile.IsSetValueManual = false;
            this.txtBrowserFile.Location = new System.Drawing.Point(152, 44);
            this.txtBrowserFile.MaxLength = 0;
            this.txtBrowserFile.Name = "txtBrowserFile";
            this.txtBrowserFile.RepositoryItem = null;
            this.txtBrowserFile.SetField = null;
            this.txtBrowserFile.Size = new System.Drawing.Size(424, 22);
            this.txtBrowserFile.TabIndex = 1;
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
            this.mLabel2.Location = new System.Drawing.Point(14, 48);
            this.mLabel2.Name = "mLabel2";
            this.mLabel2.Size = new System.Drawing.Size(102, 13);
            this.mLabel2.TabIndex = 2;
            this.mLabel2.Text = "2. Đường dẫn dữ liệu:";
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
            this.mLabel1.Location = new System.Drawing.Point(14, 17);
            this.mLabel1.Name = "mLabel1";
            this.mLabel1.Size = new System.Drawing.Size(69, 13);
            this.mLabel1.TabIndex = 0;
            this.mLabel1.Text = "1. Loại dữ liệu:";
            // 
            // tabMerge
            // 
            this.tabMerge.Appearance.Header.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tabMerge.Appearance.Header.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tabMerge.Appearance.Header.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(118)))));
            this.tabMerge.Appearance.Header.Options.UseBorderColor = true;
            this.tabMerge.Appearance.Header.Options.UseFont = true;
            this.tabMerge.Appearance.Header.Options.UseForeColor = true;
            this.tabMerge.Controls.Add(this.panel3);
            this.tabMerge.Controls.Add(this.panel2);
            this.tabMerge.Name = "tabMerge";
            this.tabMerge.Size = new System.Drawing.Size(900, 583);
            this.tabMerge.Text = "2. Ghép dữ liệu";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.grdColumnMatch);
            this.panel3.Location = new System.Drawing.Point(3, 49);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(897, 531);
            this.panel3.TabIndex = 3;
            // 
            // grdColumnMatch
            // 
            this.grdColumnMatch.Columns = null;
            this.grdColumnMatch.ColumnSortInfoCollectionChanged = null;
            this.grdColumnMatch.CustomModelFields = null;
            this.grdColumnMatch.CustomRowCellEditing = null;
            this.grdColumnMatch.Description = null;
            this.grdColumnMatch.DisableFieldNames = null;
            this.grdColumnMatch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdColumnMatch.FilterObjects = null;
            this.grdColumnMatch.FuncCustomRecordBeforeAddRow = null;
            this.grdColumnMatch.IsEditable = false;
            this.grdColumnMatch.IsHideActionAdd = false;
            this.grdColumnMatch.IsRemoteFilter = false;
            this.grdColumnMatch.IsSetValueManual = false;
            this.grdColumnMatch.IsShowDetailButtons = false;
            this.grdColumnMatch.IsShowFilter = false;
            this.grdColumnMatch.IsShowHorizontalLine = false;
            this.grdColumnMatch.IsShowPaging = false;
            this.grdColumnMatch.IsShowVerticalLine = false;
            this.grdColumnMatch.KeyName = null;
            this.grdColumnMatch.Location = new System.Drawing.Point(0, 0);
            this.grdColumnMatch.MainView = this.mGridView1;
            this.grdColumnMatch.MarkLoading = false;
            this.grdColumnMatch.Name = "grdColumnMatch";
            this.grdColumnMatch.RowCellStyle = null;
            this.grdColumnMatch.SetField = null;
            this.grdColumnMatch.Size = new System.Drawing.Size(897, 531);
            this.grdColumnMatch.Sort = null;
            this.grdColumnMatch.StartRemoteFilterRow = null;
            this.grdColumnMatch.Sumary = null;
            this.grdColumnMatch.TabIndex = 0;
            this.grdColumnMatch.TableName = null;
            this.grdColumnMatch.UserCustomDrawCell = null;
            this.grdColumnMatch.ValidEditValueChanging = null;
            this.grdColumnMatch.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.mGridView1});
            this.grdColumnMatch.ViewName = null;
            // 
            // mGridView1
            // 
            this.mGridView1.GridControl = this.grdColumnMatch;
            this.mGridView1.IsFilterServer = false;
            this.mGridView1.Name = "mGridView1";
            this.mGridView1.OptionsView.ColumnAutoWidth = false;
            this.mGridView1.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            this.mGridView1.RaiseEventCellValueChanged = false;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.label8);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(897, 40);
            this.panel2.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label8.Location = new System.Drawing.Point(4, 4);
            this.label8.Margin = new System.Windows.Forms.Padding(0);
            this.label8.MaximumSize = new System.Drawing.Size(912, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(910, 36);
            this.label8.TabIndex = 22;
            this.label8.Text = "Bước này giúp bạn ghép các cột trên tệp dữ liệu với các cột trên phần mềm. Để thự" +
    "c hiện, bạn chọn các thông tin trên cột <Trường trên tệp nguồn> ghép tương ứng v" +
    "ới <Trường trên phần mềm>.";
            // 
            // tabCheckData
            // 
            this.tabCheckData.Appearance.Header.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tabCheckData.Appearance.Header.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tabCheckData.Appearance.Header.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(118)))));
            this.tabCheckData.Appearance.Header.Options.UseBorderColor = true;
            this.tabCheckData.Appearance.Header.Options.UseFont = true;
            this.tabCheckData.Appearance.Header.Options.UseForeColor = true;
            this.tabCheckData.Controls.Add(this.panel5);
            this.tabCheckData.Controls.Add(this.panel4);
            this.tabCheckData.Name = "tabCheckData";
            this.tabCheckData.Size = new System.Drawing.Size(900, 583);
            this.tabCheckData.Text = "3. Kiểm tra dữ liệu";
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.Controls.Add(this.grdCheckData);
            this.panel5.Controls.Add(this.richTextBoxB3);
            this.panel5.Location = new System.Drawing.Point(3, 96);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(911, 500);
            this.panel5.TabIndex = 1;
            // 
            // grdCheckData
            // 
            this.grdCheckData.Columns = null;
            this.grdCheckData.ColumnSortInfoCollectionChanged = null;
            this.grdCheckData.CustomModelFields = null;
            this.grdCheckData.CustomRowCellEditing = null;
            this.grdCheckData.Description = null;
            this.grdCheckData.DisableFieldNames = null;
            this.grdCheckData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdCheckData.FilterObjects = null;
            this.grdCheckData.FuncCustomRecordBeforeAddRow = null;
            this.grdCheckData.IsEditable = false;
            this.grdCheckData.IsHideActionAdd = false;
            this.grdCheckData.IsRemoteFilter = false;
            this.grdCheckData.IsSetValueManual = false;
            this.grdCheckData.IsShowDetailButtons = false;
            this.grdCheckData.IsShowFilter = false;
            this.grdCheckData.IsShowHorizontalLine = false;
            this.grdCheckData.IsShowPaging = false;
            this.grdCheckData.IsShowVerticalLine = false;
            this.grdCheckData.KeyName = null;
            this.grdCheckData.Location = new System.Drawing.Point(0, 0);
            this.grdCheckData.MainView = this.mGridView2;
            this.grdCheckData.MarkLoading = false;
            this.grdCheckData.Name = "grdCheckData";
            this.grdCheckData.RowCellStyle = null;
            this.grdCheckData.SetField = null;
            this.grdCheckData.Size = new System.Drawing.Size(911, 500);
            this.grdCheckData.Sort = null;
            this.grdCheckData.StartRemoteFilterRow = null;
            this.grdCheckData.Sumary = null;
            this.grdCheckData.TabIndex = 1;
            this.grdCheckData.TableName = null;
            this.grdCheckData.UserCustomDrawCell = null;
            this.grdCheckData.ValidEditValueChanging = null;
            this.grdCheckData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.mGridView2});
            this.grdCheckData.ViewName = null;
            // 
            // mGridView2
            // 
            this.mGridView2.GridControl = this.grdCheckData;
            this.mGridView2.IsFilterServer = false;
            this.mGridView2.Name = "mGridView2";
            this.mGridView2.OptionsView.ColumnAutoWidth = false;
            this.mGridView2.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            this.mGridView2.RaiseEventCellValueChanged = false;
            // 
            // richTextBoxB3
            // 
            this.richTextBoxB3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxB3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.richTextBoxB3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxB3.Enabled = false;
            this.richTextBoxB3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.richTextBoxB3.ForeColor = System.Drawing.Color.Black;
            this.richTextBoxB3.Location = new System.Drawing.Point(61, 37);
            this.richTextBoxB3.Name = "richTextBoxB3";
            this.richTextBoxB3.Size = new System.Drawing.Size(981, 42);
            this.richTextBoxB3.TabIndex = 15;
            this.richTextBoxB3.Text = "Bước này giúp bạn kiểm tra dữ liệu trước khi nhập khẩu, dưới đây hiển thị các dòn" +
    "g dữ liệu không hợp lệ. Bạn có thể sửa lại tệp dữ liệu bằng cách nhấn vào nút <S" +
    "ửa lại tệp dữ liệu>";
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.btnCheckData);
            this.panel4.Controls.Add(this.btnEditFile);
            this.panel4.Controls.Add(this.lblInvalid);
            this.panel4.Controls.Add(this.lblValid);
            this.panel4.Location = new System.Drawing.Point(3, 5);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(911, 85);
            this.panel4.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label4.Location = new System.Drawing.Point(2, 2);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.MaximumSize = new System.Drawing.Size(930, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(913, 36);
            this.label4.TabIndex = 20;
            this.label4.Text = "Bước này giúp bạn kiểm tra dữ liệu trước khi nhập khẩu, dưới đây hiển thị các dòn" +
    "g dữ liệu không hợp lệ. Bạn có thể sửa lại tệp dữ liệu bằng cách nhấn vào nút <S" +
    "ửa lại tệp dữ liệu>";
            // 
            // btnCheckData
            // 
            this.btnCheckData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCheckData.AnimationHoverSpeed = 0.07F;
            this.btnCheckData.AnimationSpeed = 0.03F;
            this.btnCheckData.BackColor = System.Drawing.Color.Transparent;
            this.btnCheckData.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(117)))), ((int)(((byte)(188)))));
            this.btnCheckData.BorderColor = System.Drawing.Color.Black;
            this.btnCheckData.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCheckData.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnCheckData.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(169)))), ((int)(((byte)(25)))));
            this.btnCheckData.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCheckData.ForeColor = System.Drawing.Color.White;
            this.btnCheckData.Image = null;
            this.btnCheckData.ImageSize = new System.Drawing.Size(20, 20);
            this.btnCheckData.Location = new System.Drawing.Point(770, 55);
            this.btnCheckData.Margin = new System.Windows.Forms.Padding(0, 0, 4, 0);
            this.btnCheckData.Name = "btnCheckData";
            this.btnCheckData.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(169)))), ((int)(((byte)(25)))));
            this.btnCheckData.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnCheckData.OnHoverForeColor = System.Drawing.Color.White;
            this.btnCheckData.OnHoverImage = null;
            this.btnCheckData.OnPressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(169)))), ((int)(((byte)(25)))));
            this.btnCheckData.Radius = 2;
            this.btnCheckData.Size = new System.Drawing.Size(132, 27);
            this.btnCheckData.TabIndex = 19;
            this.btnCheckData.Text = "Kiểm tra lại dữ liệu";
            this.btnCheckData.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnCheckData.Click += new System.EventHandler(this.btnCheckData_Click);
            // 
            // btnEditFile
            // 
            this.btnEditFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditFile.AnimationHoverSpeed = 0.07F;
            this.btnEditFile.AnimationSpeed = 0.03F;
            this.btnEditFile.BackColor = System.Drawing.Color.Transparent;
            this.btnEditFile.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(117)))), ((int)(((byte)(188)))));
            this.btnEditFile.BorderColor = System.Drawing.Color.Black;
            this.btnEditFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditFile.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnEditFile.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(169)))), ((int)(((byte)(25)))));
            this.btnEditFile.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnEditFile.ForeColor = System.Drawing.Color.White;
            this.btnEditFile.Image = null;
            this.btnEditFile.ImageSize = new System.Drawing.Size(20, 20);
            this.btnEditFile.Location = new System.Drawing.Point(640, 55);
            this.btnEditFile.Margin = new System.Windows.Forms.Padding(0, 0, 4, 0);
            this.btnEditFile.Name = "btnEditFile";
            this.btnEditFile.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(169)))), ((int)(((byte)(25)))));
            this.btnEditFile.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnEditFile.OnHoverForeColor = System.Drawing.Color.White;
            this.btnEditFile.OnHoverImage = null;
            this.btnEditFile.OnPressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(169)))), ((int)(((byte)(25)))));
            this.btnEditFile.Radius = 2;
            this.btnEditFile.Size = new System.Drawing.Size(120, 27);
            this.btnEditFile.TabIndex = 18;
            this.btnEditFile.Text = "Sửa lại tệp dữ liệu";
            this.btnEditFile.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnEditFile.Click += new System.EventHandler(this.btnEditFile_Click);
            // 
            // lblInvalid
            // 
            this.lblInvalid.AllowHtmlString = true;
            this.lblInvalid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblInvalid.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblInvalid.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblInvalid.Appearance.Options.UseFont = true;
            this.lblInvalid.Appearance.Options.UseForeColor = true;
            this.lblInvalid.Appearance.Options.UseTextOptions = true;
            this.lblInvalid.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lblInvalid.ColumnName = "";
            this.lblInvalid.Description = null;
            this.lblInvalid.IsRequired = false;
            this.lblInvalid.Location = new System.Drawing.Point(337, 63);
            this.lblInvalid.Name = "lblInvalid";
            this.lblInvalid.Size = new System.Drawing.Size(63, 13);
            this.lblInvalid.TabIndex = 17;
            this.lblInvalid.Text = "Không hợp lệ";
            // 
            // lblValid
            // 
            this.lblValid.AllowHtmlString = true;
            this.lblValid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblValid.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblValid.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblValid.Appearance.Options.UseFont = true;
            this.lblValid.Appearance.Options.UseForeColor = true;
            this.lblValid.Appearance.Options.UseTextOptions = true;
            this.lblValid.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lblValid.ColumnName = "";
            this.lblValid.Description = null;
            this.lblValid.IsRequired = false;
            this.lblValid.Location = new System.Drawing.Point(5, 63);
            this.lblValid.Name = "lblValid";
            this.lblValid.Size = new System.Drawing.Size(31, 13);
            this.lblValid.TabIndex = 16;
            this.lblValid.Text = "Hợp lệ";
            // 
            // tabResult
            // 
            this.tabResult.Appearance.Header.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tabResult.Appearance.Header.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tabResult.Appearance.Header.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(118)))));
            this.tabResult.Appearance.Header.Options.UseBorderColor = true;
            this.tabResult.Appearance.Header.Options.UseFont = true;
            this.tabResult.Appearance.Header.Options.UseForeColor = true;
            this.tabResult.Controls.Add(this.btnViewResultImport);
            this.tabResult.Controls.Add(this.lblResultImport);
            this.tabResult.Controls.Add(this.progressBarExeImport);
            this.tabResult.Controls.Add(this.lblUpdateSuccess);
            this.tabResult.Controls.Add(this.lblAddSuccess);
            this.tabResult.Controls.Add(this.label3);
            this.tabResult.Name = "tabResult";
            this.tabResult.Size = new System.Drawing.Size(900, 583);
            this.tabResult.Text = "4. Kết quả nhập khẩu";
            // 
            // btnViewResultImport
            // 
            this.btnViewResultImport.BackColor = System.Drawing.Color.Transparent;
            this.btnViewResultImport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnViewResultImport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(117)))), ((int)(((byte)(188)))));
            this.btnViewResultImport.IconChar = FontAwesome.Sharp.IconChar.Download;
            this.btnViewResultImport.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(117)))), ((int)(((byte)(188)))));
            this.btnViewResultImport.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnViewResultImport.IconSize = 24;
            this.btnViewResultImport.Location = new System.Drawing.Point(287, 149);
            this.btnViewResultImport.Name = "btnViewResultImport";
            this.btnViewResultImport.Size = new System.Drawing.Size(30, 24);
            this.btnViewResultImport.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnViewResultImport.TabIndex = 22;
            this.btnViewResultImport.TabStop = false;
            this.btnViewResultImport.Click += new System.EventHandler(this.btnViewResultImport_Click);
            // 
            // lblResultImport
            // 
            this.lblResultImport.AllowHtmlString = true;
            this.lblResultImport.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblResultImport.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblResultImport.Appearance.Options.UseFont = true;
            this.lblResultImport.Appearance.Options.UseForeColor = true;
            this.lblResultImport.Appearance.Options.UseTextOptions = true;
            this.lblResultImport.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lblResultImport.ColumnName = "";
            this.lblResultImport.Description = null;
            this.lblResultImport.IsRequired = false;
            this.lblResultImport.Location = new System.Drawing.Point(35, 155);
            this.lblResultImport.Name = "lblResultImport";
            this.lblResultImport.Size = new System.Drawing.Size(244, 13);
            this.lblResultImport.TabIndex = 21;
            this.lblResultImport.Text = "Nhấn vào nút bên cạnh để xem kết quả nhập khẩu";
            // 
            // progressBarExeImport
            // 
            this.progressBarExeImport.Location = new System.Drawing.Point(18, 112);
            this.progressBarExeImport.Name = "progressBarExeImport";
            this.progressBarExeImport.Size = new System.Drawing.Size(299, 23);
            this.progressBarExeImport.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBarExeImport.TabIndex = 3;
            // 
            // lblUpdateSuccess
            // 
            this.lblUpdateSuccess.AllowHtmlString = true;
            this.lblUpdateSuccess.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblUpdateSuccess.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblUpdateSuccess.Appearance.Options.UseFont = true;
            this.lblUpdateSuccess.Appearance.Options.UseForeColor = true;
            this.lblUpdateSuccess.Appearance.Options.UseTextOptions = true;
            this.lblUpdateSuccess.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lblUpdateSuccess.ColumnName = "";
            this.lblUpdateSuccess.Description = null;
            this.lblUpdateSuccess.IsRequired = false;
            this.lblUpdateSuccess.Location = new System.Drawing.Point(35, 80);
            this.lblUpdateSuccess.Name = "lblUpdateSuccess";
            this.lblUpdateSuccess.Size = new System.Drawing.Size(81, 13);
            this.lblUpdateSuccess.TabIndex = 2;
            this.lblUpdateSuccess.Text = "Bản ghi cập nhật";
            // 
            // lblAddSuccess
            // 
            this.lblAddSuccess.AllowHtmlString = true;
            this.lblAddSuccess.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblAddSuccess.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblAddSuccess.Appearance.Options.UseFont = true;
            this.lblAddSuccess.Appearance.Options.UseForeColor = true;
            this.lblAddSuccess.Appearance.Options.UseTextOptions = true;
            this.lblAddSuccess.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lblAddSuccess.ColumnName = "";
            this.lblAddSuccess.Description = null;
            this.lblAddSuccess.IsRequired = false;
            this.lblAddSuccess.Location = new System.Drawing.Point(35, 54);
            this.lblAddSuccess.Name = "lblAddSuccess";
            this.lblAddSuccess.Size = new System.Drawing.Size(84, 13);
            this.lblAddSuccess.TabIndex = 1;
            this.lblAddSuccess.Text = "Bản ghi thêm mới:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(14, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(182, 22);
            this.label3.TabIndex = 0;
            this.label3.Text = "Kết quả nhập khẩu";
            // 
            // pnlBody
            // 
            this.pnlBody.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBody.Controls.Add(this.tabControl);
            this.pnlBody.Location = new System.Drawing.Point(4, 6);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(1022, 585);
            this.pnlBody.TabIndex = 1;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.pnlBottom.Controls.Add(this.btnHelp);
            this.pnlBottom.Controls.Add(this.btnPrevious);
            this.pnlBottom.Controls.Add(this.btnNext);
            this.pnlBottom.Controls.Add(this.btnCancel);
            this.pnlBottom.Location = new System.Drawing.Point(4, 597);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(1022, 43);
            this.pnlBottom.TabIndex = 2;
            // 
            // btnHelp
            // 
            this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
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
            this.btnHelp.Location = new System.Drawing.Point(8, 11);
            this.btnHelp.Margin = new System.Windows.Forms.Padding(8, 8, 3, 8);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(71, 24);
            this.btnHelp.TabIndex = 3;
            this.btnHelp.Text = "Trợ giúp";
            // 
            // btnPrevious
            // 
            this.btnPrevious.AllowHtmlDraw = DevExpress.Utils.DefaultBoolean.True;
            this.btnPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrevious.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(107)))), ((int)(((byte)(151)))));
            this.btnPrevious.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(107)))), ((int)(((byte)(151)))));
            this.btnPrevious.Appearance.BorderColor = System.Drawing.Color.Black;
            this.btnPrevious.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnPrevious.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnPrevious.Appearance.Options.UseBackColor = true;
            this.btnPrevious.Appearance.Options.UseBorderColor = true;
            this.btnPrevious.Appearance.Options.UseFont = true;
            this.btnPrevious.Appearance.Options.UseForeColor = true;
            this.btnPrevious.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(136)))), ((int)(((byte)(194)))));
            this.btnPrevious.AppearanceHovered.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(136)))), ((int)(((byte)(194)))));
            this.btnPrevious.AppearanceHovered.BorderColor = System.Drawing.Color.Black;
            this.btnPrevious.AppearanceHovered.Options.UseBackColor = true;
            this.btnPrevious.AppearanceHovered.Options.UseBorderColor = true;
            this.btnPrevious.AppearancePressed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(87)))), ((int)(((byte)(123)))));
            this.btnPrevious.AppearancePressed.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(87)))), ((int)(((byte)(123)))));
            this.btnPrevious.AppearancePressed.BorderColor = System.Drawing.Color.Black;
            this.btnPrevious.AppearancePressed.Options.UseBackColor = true;
            this.btnPrevious.AppearancePressed.Options.UseBorderColor = true;
            this.btnPrevious.ColumnName = "";
            this.btnPrevious.Description = null;
            this.btnPrevious.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnPrevious.ImageOptions.Image")));
            this.btnPrevious.Location = new System.Drawing.Point(781, 9);
            this.btnPrevious.Margin = new System.Windows.Forms.Padding(3, 8, 3, 8);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(72, 24);
            this.btnPrevious.TabIndex = 1;
            this.btnPrevious.Text = "Quay lại";
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(107)))), ((int)(((byte)(151)))));
            this.btnNext.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(107)))), ((int)(((byte)(151)))));
            this.btnNext.Appearance.BorderColor = System.Drawing.Color.Black;
            this.btnNext.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnNext.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnNext.Appearance.Options.UseBackColor = true;
            this.btnNext.Appearance.Options.UseBorderColor = true;
            this.btnNext.Appearance.Options.UseFont = true;
            this.btnNext.Appearance.Options.UseForeColor = true;
            this.btnNext.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(136)))), ((int)(((byte)(194)))));
            this.btnNext.AppearanceHovered.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(136)))), ((int)(((byte)(194)))));
            this.btnNext.AppearanceHovered.BorderColor = System.Drawing.Color.Black;
            this.btnNext.AppearanceHovered.Options.UseBackColor = true;
            this.btnNext.AppearanceHovered.Options.UseBorderColor = true;
            this.btnNext.AppearancePressed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(87)))), ((int)(((byte)(123)))));
            this.btnNext.AppearancePressed.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(87)))), ((int)(((byte)(123)))));
            this.btnNext.AppearancePressed.BorderColor = System.Drawing.Color.Black;
            this.btnNext.AppearancePressed.Options.UseBackColor = true;
            this.btnNext.AppearancePressed.Options.UseBorderColor = true;
            this.btnNext.ColumnName = "";
            this.btnNext.Description = null;
            this.btnNext.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnNext.ImageOptions.Image")));
            this.btnNext.Location = new System.Drawing.Point(861, 9);
            this.btnNext.Margin = new System.Windows.Forms.Padding(3, 8, 3, 8);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(79, 24);
            this.btnNext.TabIndex = 0;
            this.btnNext.Text = "Tiếp theo";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.btnCancel.Location = new System.Drawing.Point(947, 9);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 8, 8, 8);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(68, 24);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Hủy bỏ";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // bgExecuteImport
            // 
            this.bgExecuteImport.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgExecuteImport_DoWork);
            this.bgExecuteImport.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgExecuteImport_RunWorkerCompleted);
            // 
            // frmImportData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1030, 643);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlBody);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmImportData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nhập khẩu";
            this.Load += new System.EventHandler(this.frmImportData_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tabControl)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabSelectFile.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSourcePath)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdoImportType.Properties)).EndInit();
            this.tabMerge.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdColumnMatch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabCheckData.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdCheckData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mGridView2)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.tabResult.ResumeLayout(false);
            this.tabResult.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnViewResultImport)).EndInit();
            this.pnlBody.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MTControl.MXtraTabControl tabControl;
        private DevExpress.XtraTab.XtraTabPage tabSelectFile;
        private DevExpress.XtraTab.XtraTabPage tabMerge;
        private DevExpress.XtraTab.XtraTabPage tabCheckData;
        private DevExpress.XtraTab.XtraTabPage tabResult;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.Panel pnlBottom;
        public MTControl.MSimpleButton btnHelp;
        public MTControl.MSimpleButton btnPrevious;
        public MTControl.MSimpleButton btnNext;
        public MTControl.MSimpleButton btnCancel;
        private System.Windows.Forms.Panel panel3;
        private MTControl.MGridControl grdColumnMatch;
        private MTControl.MGridView mGridView1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private MTControl.MGridControl grdCheckData;
        private MTControl.MGridView mGridView2;
        private System.ComponentModel.BackgroundWorker bgExecuteImport;
        private System.Windows.Forms.Label label3;
        private MTControl.MLabel lblAddSuccess;
        private MTControl.MLabel lblUpdateSuccess;
        private System.Windows.Forms.ProgressBar progressBarExeImport;
        private MTControl.MLabel lblValid;
        private System.Windows.Forms.RichTextBox richTextBoxB3;
        private MTControl.MLabel lblInvalid;
        private Guna.UI.WinForms.GunaButton btnCheckData;
        private System.Windows.Forms.Panel panel1;
        private MTControl.MComboBox cboDataType;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private MTControl.MLabel mLabel6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private MTControl.MRadioGroup rdoImportType;
        private MTControl.MLabel mLabel5;
        private MTControl.MSpinEdit nbrRowPosition;
        private MTControl.MLabel mLabel4;
        private MTControl.MLookUpEdit cboSheet;
        private MTControl.MLabel mLabel3;
        private MTControl.MTextEdit txtBrowserFile;
        private MTControl.MLabel mLabel2;
        private MTControl.MLabel mLabel1;
        private Guna.UI.WinForms.GunaButton btnEditFile;
        private FontAwesome.Sharp.IconPictureBox btnSourcePath;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private FontAwesome.Sharp.IconPictureBox btnViewResultImport;
        private MTControl.MLabel lblResultImport;
    }
}