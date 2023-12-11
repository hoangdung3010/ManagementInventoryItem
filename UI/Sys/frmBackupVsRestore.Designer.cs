
namespace FormUI
{
    partial class frmBackupVsRestore
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.mGroupControl2 = new MTControl.MGroupControl();
            this.panel3 = new System.Windows.Forms.Panel();
            this.grdRestore = new MTControl.MGridControl();
            this.mGridView1 = new MTControl.MGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.mLabel2 = new MTControl.MLabel();
            this.txtDatabaseName = new MTControl.MTextEdit();
            this.mLabel3 = new MTControl.MLabel();
            this.txtPathData = new MTControl.MTextEdit();
            this.pbRestore = new System.Windows.Forms.ProgressBar();
            this.lblStatusRestore = new System.Windows.Forms.Label();
            this.btnExecuteRestore = new MTControl.MSimpleButton();
            this.mGroupControl1 = new MTControl.MGroupControl();
            this.lblStatusBackup = new System.Windows.Forms.Label();
            this.btnExecuteBackup = new MTControl.MSimpleButton();
            this.pbBackup = new System.Windows.Forms.ProgressBar();
            this.txtFolderBackup = new MTControl.MTextEdit();
            this.mLabel1 = new MTControl.MLabel();
            this.bgWKBackup = new System.ComponentModel.BackgroundWorker();
            this.bgWKRestore = new System.ComponentModel.BackgroundWorker();
            this.bgLoadDataBackup = new System.ComponentModel.BackgroundWorker();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mGroupControl2)).BeginInit();
            this.mGroupControl2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdRestore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mGroupControl1)).BeginInit();
            this.mGroupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.mGroupControl2);
            this.panel1.Controls.Add(this.mGroupControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(792, 581);
            this.panel1.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label8.Location = new System.Drawing.Point(13, 32);
            this.label8.Margin = new System.Windows.Forms.Padding(0);
            this.label8.MaximumSize = new System.Drawing.Size(790, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(655, 18);
            this.label8.TabIndex = 23;
            this.label8.Text = "Lưu ý: Đường dẫn thư mục sao lưu và phục hồi phải là đường dẫn tồn tại trên máy c" +
    "hủ cơ sở dữ liệu.";
            // 
            // mGroupControl2
            // 
            this.mGroupControl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mGroupControl2.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.mGroupControl2.Appearance.Options.UseForeColor = true;
            this.mGroupControl2.ColumnName = "";
            this.mGroupControl2.Controls.Add(this.panel3);
            this.mGroupControl2.Controls.Add(this.panel2);
            this.mGroupControl2.Description = null;
            this.mGroupControl2.Location = new System.Drawing.Point(12, 195);
            this.mGroupControl2.Name = "mGroupControl2";
            this.mGroupControl2.Size = new System.Drawing.Size(768, 399);
            this.mGroupControl2.TabIndex = 1;
            this.mGroupControl2.Text = "Phục hồi dữ liệu";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.grdRestore);
            this.panel3.Location = new System.Drawing.Point(5, 161);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(758, 233);
            this.panel3.TabIndex = 8;
            // 
            // grdRestore
            // 
            this.grdRestore.Columns = null;
            this.grdRestore.ColumnSortInfoCollectionChanged = null;
            this.grdRestore.CustomModelFields = null;
            this.grdRestore.CustomRowCellEditing = null;
            this.grdRestore.Description = null;
            this.grdRestore.DisableFieldNames = null;
            this.grdRestore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdRestore.FilterObjects = null;
            this.grdRestore.FuncCustomRecordBeforeAddRow = null;
            this.grdRestore.IsEditable = false;
            this.grdRestore.IsHideActionAdd = false;
            this.grdRestore.IsRemoteFilter = false;
            this.grdRestore.IsSetValueManual = false;
            this.grdRestore.IsShowDetailButtons = false;
            this.grdRestore.IsShowFilter = false;
            this.grdRestore.IsShowHorizontalLine = false;
            this.grdRestore.IsShowPaging = false;
            this.grdRestore.IsShowVerticalLine = false;
            this.grdRestore.KeyName = null;
            this.grdRestore.Location = new System.Drawing.Point(0, 0);
            this.grdRestore.MainView = this.mGridView1;
            this.grdRestore.MarkLoading = false;
            this.grdRestore.Name = "grdRestore";
            this.grdRestore.RowCellStyle = null;
            this.grdRestore.SetField = null;
            this.grdRestore.Size = new System.Drawing.Size(758, 233);
            this.grdRestore.Sort = null;
            this.grdRestore.StartRemoteFilterRow = null;
            this.grdRestore.Sumary = null;
            this.grdRestore.TabIndex = 0;
            this.grdRestore.TableName = null;
            this.grdRestore.UserCustomDrawCell = null;
            this.grdRestore.ValidEditValueChanging = null;
            this.grdRestore.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.mGridView1});
            this.grdRestore.ViewName = null;
            // 
            // mGridView1
            // 
            this.mGridView1.GridControl = this.grdRestore;
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
            this.panel2.Controls.Add(this.mLabel2);
            this.panel2.Controls.Add(this.txtDatabaseName);
            this.panel2.Controls.Add(this.mLabel3);
            this.panel2.Controls.Add(this.txtPathData);
            this.panel2.Controls.Add(this.pbRestore);
            this.panel2.Controls.Add(this.lblStatusRestore);
            this.panel2.Controls.Add(this.btnExecuteRestore);
            this.panel2.Location = new System.Drawing.Point(4, 26);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(759, 129);
            this.panel2.TabIndex = 7;
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
            this.mLabel2.Location = new System.Drawing.Point(11, 49);
            this.mLabel2.Name = "mLabel2";
            this.mLabel2.Size = new System.Drawing.Size(126, 13);
            this.mLabel2.TabIndex = 11;
            this.mLabel2.Text = "Tên cơ sở dữ liệu phục hồi";
            // 
            // txtDatabaseName
            // 
            this.txtDatabaseName.AutoIncrement = false;
            this.txtDatabaseName.Description = null;
            this.txtDatabaseName.Grid = null;
            this.txtDatabaseName.IsCustomHeight = false;
            this.txtDatabaseName.IsReadOnly = false;
            this.txtDatabaseName.IsSetValueManual = false;
            this.txtDatabaseName.Location = new System.Drawing.Point(190, 45);
            this.txtDatabaseName.MaxLength = 0;
            this.txtDatabaseName.Name = "txtDatabaseName";
            this.txtDatabaseName.RepositoryItem = null;
            this.txtDatabaseName.SetField = null;
            this.txtDatabaseName.Size = new System.Drawing.Size(575, 22);
            this.txtDatabaseName.TabIndex = 1;
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
            this.mLabel3.Location = new System.Drawing.Point(11, 19);
            this.mLabel3.Name = "mLabel3";
            this.mLabel3.Size = new System.Drawing.Size(160, 13);
            this.mLabel3.TabIndex = 9;
            this.mLabel3.Text = "Đường dẫn thư mục lưu trữ dữ liệu";
            // 
            // txtPathData
            // 
            this.txtPathData.AutoIncrement = false;
            this.txtPathData.Description = null;
            this.txtPathData.Grid = null;
            this.txtPathData.IsCustomHeight = false;
            this.txtPathData.IsReadOnly = false;
            this.txtPathData.IsSetValueManual = false;
            this.txtPathData.Location = new System.Drawing.Point(190, 15);
            this.txtPathData.MaxLength = 0;
            this.txtPathData.Name = "txtPathData";
            this.txtPathData.RepositoryItem = null;
            this.txtPathData.SetField = null;
            this.txtPathData.Size = new System.Drawing.Size(575, 22);
            this.txtPathData.TabIndex = 0;
            // 
            // pbRestore
            // 
            this.pbRestore.Location = new System.Drawing.Point(190, 97);
            this.pbRestore.Name = "pbRestore";
            this.pbRestore.Size = new System.Drawing.Size(488, 23);
            this.pbRestore.TabIndex = 3;
            // 
            // lblStatusRestore
            // 
            this.lblStatusRestore.AutoSize = true;
            this.lblStatusRestore.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblStatusRestore.Location = new System.Drawing.Point(196, 76);
            this.lblStatusRestore.Name = "lblStatusRestore";
            this.lblStatusRestore.Size = new System.Drawing.Size(117, 18);
            this.lblStatusRestore.TabIndex = 6;
            this.lblStatusRestore.Text = "lblStatusRestore";
            // 
            // btnExecuteRestore
            // 
            this.btnExecuteRestore.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnExecuteRestore.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnExecuteRestore.Appearance.Options.UseFont = true;
            this.btnExecuteRestore.Appearance.Options.UseForeColor = true;
            this.btnExecuteRestore.ColumnName = "";
            this.btnExecuteRestore.Description = null;
            this.btnExecuteRestore.Location = new System.Drawing.Point(684, 96);
            this.btnExecuteRestore.Name = "btnExecuteRestore";
            this.btnExecuteRestore.Size = new System.Drawing.Size(81, 24);
            this.btnExecuteRestore.TabIndex = 2;
            this.btnExecuteRestore.Text = "Phục hồi";
            this.btnExecuteRestore.Click += new System.EventHandler(this.btnExecuteRestore_Click);
            // 
            // mGroupControl1
            // 
            this.mGroupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mGroupControl1.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.mGroupControl1.Appearance.Options.UseForeColor = true;
            this.mGroupControl1.ColumnName = "";
            this.mGroupControl1.Controls.Add(this.lblStatusBackup);
            this.mGroupControl1.Controls.Add(this.btnExecuteBackup);
            this.mGroupControl1.Controls.Add(this.pbBackup);
            this.mGroupControl1.Controls.Add(this.txtFolderBackup);
            this.mGroupControl1.Controls.Add(this.mLabel1);
            this.mGroupControl1.Description = null;
            this.mGroupControl1.Location = new System.Drawing.Point(12, 59);
            this.mGroupControl1.Name = "mGroupControl1";
            this.mGroupControl1.Size = new System.Drawing.Size(768, 130);
            this.mGroupControl1.TabIndex = 0;
            this.mGroupControl1.Text = "Sao lưu dữ liệu";
            // 
            // lblStatusBackup
            // 
            this.lblStatusBackup.AutoSize = true;
            this.lblStatusBackup.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblStatusBackup.Location = new System.Drawing.Point(199, 67);
            this.lblStatusBackup.Name = "lblStatusBackup";
            this.lblStatusBackup.Size = new System.Drawing.Size(114, 18);
            this.lblStatusBackup.TabIndex = 5;
            this.lblStatusBackup.Text = "lblStatusBackup";
            // 
            // btnExecuteBackup
            // 
            this.btnExecuteBackup.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnExecuteBackup.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnExecuteBackup.Appearance.Options.UseFont = true;
            this.btnExecuteBackup.Appearance.Options.UseForeColor = true;
            this.btnExecuteBackup.ColumnName = "";
            this.btnExecuteBackup.Description = null;
            this.btnExecuteBackup.Location = new System.Drawing.Point(691, 88);
            this.btnExecuteBackup.Name = "btnExecuteBackup";
            this.btnExecuteBackup.Size = new System.Drawing.Size(81, 24);
            this.btnExecuteBackup.TabIndex = 1;
            this.btnExecuteBackup.Text = "Sao lưu";
            this.btnExecuteBackup.Click += new System.EventHandler(this.btnExecuteBackup_Click);
            // 
            // pbBackup
            // 
            this.pbBackup.Location = new System.Drawing.Point(197, 89);
            this.pbBackup.Name = "pbBackup";
            this.pbBackup.Size = new System.Drawing.Size(485, 23);
            this.pbBackup.TabIndex = 3;
            // 
            // txtFolderBackup
            // 
            this.txtFolderBackup.AutoIncrement = false;
            this.txtFolderBackup.Description = null;
            this.txtFolderBackup.Grid = null;
            this.txtFolderBackup.IsCustomHeight = false;
            this.txtFolderBackup.IsReadOnly = false;
            this.txtFolderBackup.IsSetValueManual = false;
            this.txtFolderBackup.Location = new System.Drawing.Point(197, 39);
            this.txtFolderBackup.MaxLength = 0;
            this.txtFolderBackup.Name = "txtFolderBackup";
            this.txtFolderBackup.RepositoryItem = null;
            this.txtFolderBackup.SetField = null;
            this.txtFolderBackup.Size = new System.Drawing.Size(575, 22);
            this.txtFolderBackup.TabIndex = 0;
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
            this.mLabel1.Location = new System.Drawing.Point(15, 43);
            this.mLabel1.Name = "mLabel1";
            this.mLabel1.Size = new System.Drawing.Size(176, 13);
            this.mLabel1.TabIndex = 0;
            this.mLabel1.Text = "Đường dẫn thư mục chứa tệp sao lưu";
            // 
            // bgWKBackup
            // 
            this.bgWKBackup.WorkerReportsProgress = true;
            this.bgWKBackup.WorkerSupportsCancellation = true;
            this.bgWKBackup.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWKBackup_DoWork);
            this.bgWKBackup.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgWKBackup_ProgressChanged);
            this.bgWKBackup.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWKBackup_RunWorkerCompleted);
            // 
            // bgWKRestore
            // 
            this.bgWKRestore.WorkerReportsProgress = true;
            this.bgWKRestore.WorkerSupportsCancellation = true;
            this.bgWKRestore.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWKRestore_DoWork);
            this.bgWKRestore.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgWKRestore_ProgressChanged);
            this.bgWKRestore.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWKRestore_RunWorkerCompleted);
            // 
            // bgLoadDataBackup
            // 
            this.bgLoadDataBackup.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgLoadDataBackup_DoWork);
            this.bgLoadDataBackup.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgLoadDataBackup_RunWorkerCompleted);
            // 
            // frmBackupVsRestore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 581);
            this.Controls.Add(this.panel1);
            this.IconOptions.ShowIcon = false;
            this.KeyPreview = true;
            this.Name = "frmBackupVsRestore";
            this.Text = "Sao lưu và Phục hồi cơ sở dữ liệu";
            this.Load += new System.EventHandler(this.frmBackupVsRestore_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mGroupControl2)).EndInit();
            this.mGroupControl2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdRestore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mGroupControl1)).EndInit();
            this.mGroupControl1.ResumeLayout(false);
            this.mGroupControl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private MTControl.MGroupControl mGroupControl1;
        private MTControl.MLabel mLabel1;
        private MTControl.MTextEdit txtFolderBackup;
        private System.Windows.Forms.ProgressBar pbBackup;
        private MTControl.MSimpleButton btnExecuteBackup;
        private MTControl.MGroupControl mGroupControl2;
        private MTControl.MSimpleButton btnExecuteRestore;
        private System.Windows.Forms.ProgressBar pbRestore;
        private System.Windows.Forms.Label lblStatusBackup;
        private System.Windows.Forms.Label lblStatusRestore;
        private System.ComponentModel.BackgroundWorker bgWKBackup;
        private System.ComponentModel.BackgroundWorker bgWKRestore;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private MTControl.MGridControl grdRestore;
        private MTControl.MGridView mGridView1;
        private System.ComponentModel.BackgroundWorker bgLoadDataBackup;
        private MTControl.MTextEdit txtPathData;
        private MTControl.MLabel mLabel3;
        private MTControl.MLabel mLabel2;
        private MTControl.MTextEdit txtDatabaseName;
    }
}