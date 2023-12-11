namespace FormUI
{
    partial class frmRP_QuyetToanTLKTMM_Mau20_13_QLKT_BCY
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBoxInput = new MTControl.MGroupControl();
            this.cboDonViNhan = new MTControl.MTreeLookUpEdit();
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.mLabel4 = new MTControl.MLabel();
            this.cboLoaiPhieuNhap = new MTControl.MComboBox();
            this.mLabel3 = new MTControl.MLabel();
            this.mLabel2 = new MTControl.MLabel();
            this.ucDateRangePeriod = new FormUI.ucDateRange();
            this.cboDonVi = new MTControl.MTreeLookUpEdit();
            this.mTreeLookUpEdit1TreeList = new DevExpress.XtraTreeList.TreeList();
            this.mLabel1 = new MTControl.MLabel();
            this.mUserControlParamRP = new FormUI.Base.MUserControlParamRP();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupBoxInput)).BeginInit();
            this.groupBoxInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboDonViNhan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDonVi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mTreeLookUpEdit1TreeList)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBoxInput);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.splitContainer1.Panel2.Controls.Add(this.mUserControlParamRP);
            this.splitContainer1.Size = new System.Drawing.Size(660, 379);
            this.splitContainer1.SplitterDistance = 176;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBoxInput
            // 
            this.groupBoxInput.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.groupBoxInput.Appearance.Options.UseForeColor = true;
            this.groupBoxInput.ColumnName = "";
            this.groupBoxInput.Controls.Add(this.cboDonViNhan);
            this.groupBoxInput.Controls.Add(this.mLabel4);
            this.groupBoxInput.Controls.Add(this.cboLoaiPhieuNhap);
            this.groupBoxInput.Controls.Add(this.mLabel3);
            this.groupBoxInput.Controls.Add(this.mLabel2);
            this.groupBoxInput.Controls.Add(this.ucDateRangePeriod);
            this.groupBoxInput.Controls.Add(this.cboDonVi);
            this.groupBoxInput.Controls.Add(this.mLabel1);
            this.groupBoxInput.Description = null;
            this.groupBoxInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxInput.Location = new System.Drawing.Point(0, 0);
            this.groupBoxInput.Name = "groupBoxInput";
            this.groupBoxInput.Size = new System.Drawing.Size(660, 176);
            this.groupBoxInput.TabIndex = 1;
            this.groupBoxInput.Text = "1. Thông tin đầu vào";
            // 
            // cboDonViNhan
            // 
            this.cboDonViNhan.AddFields = null;
            this.cboDonViNhan.AliasFormQuickAdd = null;
            this.cboDonViNhan.CustomSetFields = null;
            this.cboDonViNhan.Description = null;
            this.cboDonViNhan.DictionaryName = null;
            this.cboDonViNhan.EntityName = null;
            this.cboDonViNhan.Grid = null;
            this.cboDonViNhan.IsReadOnly = false;
            this.cboDonViNhan.IsRequired = true;
            this.cboDonViNhan.IsSetValueManual = false;
            this.cboDonViNhan.KeyStore = null;
            this.cboDonViNhan.Location = new System.Drawing.Point(116, 137);
            this.cboDonViNhan.MapColumnName = null;
            this.cboDonViNhan.Name = "cboDonViNhan";
            this.cboDonViNhan.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cboDonViNhan.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.cboDonViNhan.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cboDonViNhan.Properties.Appearance.Options.UseBackColor = true;
            this.cboDonViNhan.Properties.Appearance.Options.UseFont = true;
            this.cboDonViNhan.Properties.Appearance.Options.UseForeColor = true;
            this.cboDonViNhan.Properties.AutoHeight = false;
            this.cboDonViNhan.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboDonViNhan.Properties.ImmediatePopup = true;
            this.cboDonViNhan.Properties.NullText = "";
            this.cboDonViNhan.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.cboDonViNhan.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cboDonViNhan.Properties.TreeList = this.treeList1;
            this.cboDonViNhan.QuickSearchName = null;
            this.cboDonViNhan.RepositoryItem = null;
            this.cboDonViNhan.SetField = "sID_MaDonViNhan";
            this.cboDonViNhan.Size = new System.Drawing.Size(372, 23);
            this.cboDonViNhan.TabIndex = 3;
            // 
            // treeList1
            // 
            this.treeList1.KeyFieldName = "";
            this.treeList1.Location = new System.Drawing.Point(86, 1);
            this.treeList1.Name = "treeList1";
            this.treeList1.OptionsView.ShowAutoFilterRow = true;
            this.treeList1.OptionsView.ShowIndentAsRowStyle = true;
            this.treeList1.Size = new System.Drawing.Size(400, 200);
            this.treeList1.TabIndex = 0;
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
            this.mLabel4.IsRequired = true;
            this.mLabel4.Location = new System.Drawing.Point(29, 140);
            this.mLabel4.Name = "mLabel4";
            this.mLabel4.Size = new System.Drawing.Size(63, 16);
            this.mLabel4.TabIndex = 6;
            this.mLabel4.Text = "Đơn vị nhận<color=255, 0, 0><size=13>*</size></color>";
            // 
            // cboLoaiPhieuNhap
            // 
            this.cboLoaiPhieuNhap.DefaultValueEnum = -1;
            this.cboLoaiPhieuNhap.Description = null;
            this.cboLoaiPhieuNhap.EntityName = false;
            this.cboLoaiPhieuNhap.EnumData = null;
            this.cboLoaiPhieuNhap.Grid = null;
            this.cboLoaiPhieuNhap.IsAutoLoad = false;
            this.cboLoaiPhieuNhap.IsReadOnly = false;
            this.cboLoaiPhieuNhap.IsSetValueManual = false;
            this.cboLoaiPhieuNhap.LastAcceptedSelectedIndex = 0;
            this.cboLoaiPhieuNhap.Location = new System.Drawing.Point(116, 107);
            this.cboLoaiPhieuNhap.Name = "cboLoaiPhieuNhap";
            this.cboLoaiPhieuNhap.RepositoryItem = null;
            this.cboLoaiPhieuNhap.SetField = "isKho";
            this.cboLoaiPhieuNhap.Size = new System.Drawing.Size(372, 23);
            this.cboLoaiPhieuNhap.TabIndex = 2;
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
            this.mLabel3.Location = new System.Drawing.Point(29, 111);
            this.mLabel3.Name = "mLabel3";
            this.mLabel3.Size = new System.Drawing.Size(76, 13);
            this.mLabel3.TabIndex = 4;
            this.mLabel3.Text = "Loại phiếu nhập";
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
            this.mLabel2.Location = new System.Drawing.Point(29, 75);
            this.mLabel2.Name = "mLabel2";
            this.mLabel2.Size = new System.Drawing.Size(54, 13);
            this.mLabel2.TabIndex = 3;
            this.mLabel2.Text = "Kỳ báo cáo";
            // 
            // ucDateRangePeriod
            // 
            this.ucDateRangePeriod.AutoSize = true;
            this.ucDateRangePeriod.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(219)))), ((int)(((byte)(223)))));
            this.ucDateRangePeriod.FieldName_Changed = null;
            this.ucDateRangePeriod.FieldNames = null;
            this.ucDateRangePeriod.Location = new System.Drawing.Point(112, 65);
            this.ucDateRangePeriod.Margin = new System.Windows.Forms.Padding(0);
            this.ucDateRangePeriod.MaximumSize = new System.Drawing.Size(400, 32);
            this.ucDateRangePeriod.MinimumSize = new System.Drawing.Size(200, 26);
            this.ucDateRangePeriod.Name = "ucDateRangePeriod";
            this.ucDateRangePeriod.Period_Changed = null;
            this.ucDateRangePeriod.Size = new System.Drawing.Size(379, 32);
            this.ucDateRangePeriod.TabIndex = 1;
            // 
            // cboDonVi
            // 
            this.cboDonVi.AddFields = null;
            this.cboDonVi.AliasFormQuickAdd = null;
            this.cboDonVi.CustomSetFields = null;
            this.cboDonVi.Description = null;
            this.cboDonVi.DictionaryName = null;
            this.cboDonVi.EntityName = null;
            this.cboDonVi.Grid = null;
            this.cboDonVi.IsReadOnly = false;
            this.cboDonVi.IsRequired = true;
            this.cboDonVi.IsSetValueManual = false;
            this.cboDonVi.KeyStore = null;
            this.cboDonVi.Location = new System.Drawing.Point(116, 39);
            this.cboDonVi.MapColumnName = null;
            this.cboDonVi.Name = "cboDonVi";
            this.cboDonVi.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cboDonVi.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.cboDonVi.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cboDonVi.Properties.Appearance.Options.UseBackColor = true;
            this.cboDonVi.Properties.Appearance.Options.UseFont = true;
            this.cboDonVi.Properties.Appearance.Options.UseForeColor = true;
            this.cboDonVi.Properties.AutoHeight = false;
            this.cboDonVi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboDonVi.Properties.ImmediatePopup = true;
            this.cboDonVi.Properties.NullText = "";
            this.cboDonVi.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.cboDonVi.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cboDonVi.Properties.TreeList = this.mTreeLookUpEdit1TreeList;
            this.cboDonVi.QuickSearchName = null;
            this.cboDonVi.RepositoryItem = null;
            this.cboDonVi.SetField = "sID_MaDonVi";
            this.cboDonVi.Size = new System.Drawing.Size(372, 23);
            this.cboDonVi.TabIndex = 0;
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
            this.mLabel1.IsRequired = true;
            this.mLabel1.Location = new System.Drawing.Point(29, 42);
            this.mLabel1.Name = "mLabel1";
            this.mLabel1.Size = new System.Drawing.Size(36, 16);
            this.mLabel1.TabIndex = 0;
            this.mLabel1.Text = "Đơn vị<color=255, 0, 0><size=13>*</size></color>";
            // 
            // mUserControlParamRP
            // 
            this.mUserControlParamRP.ConfigReport = null;
            this.mUserControlParamRP.DicControls = null;
            this.mUserControlParamRP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mUserControlParamRP.Location = new System.Drawing.Point(0, 0);
            this.mUserControlParamRP.MyGetCustomParams = null;
            this.mUserControlParamRP.MySetCustomConfigExcel = null;
            this.mUserControlParamRP.Name = "mUserControlParamRP";
            this.mUserControlParamRP.RootControl = null;
            this.mUserControlParamRP.Size = new System.Drawing.Size(660, 199);
            this.mUserControlParamRP.TabIndex = 0;
            // 
            // frmRP_QuyetToanTLKTMM_Mau20_13_QLKT_BCY
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 379);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmRP_QuyetToanTLKTMM_Mau20_13_QLKT_BCY";
            this.Text = "Báo cáo quyết toán các tài liệu KTMM (Mẫu 20/13/QLKT-BCY)";
            this.Load += new System.EventHandler(this.frmRP_NhapXuatTon_Mau10_13_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupBoxInput)).EndInit();
            this.groupBoxInput.ResumeLayout(false);
            this.groupBoxInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboDonViNhan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDonVi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mTreeLookUpEdit1TreeList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        public MTControl.MGroupControl groupBoxInput;
        private Base.MUserControlParamRP mUserControlParamRP;
        private MTControl.MLabel mLabel1;
        private ucDateRange ucDateRangePeriod;
        private MTControl.MTreeLookUpEdit cboDonVi;
        private DevExpress.XtraTreeList.TreeList mTreeLookUpEdit1TreeList;
        private MTControl.MLabel mLabel2;
        private MTControl.MLabel mLabel3;
        private MTControl.MComboBox cboLoaiPhieuNhap;
        private MTControl.MTreeLookUpEdit cboDonViNhan;
        private DevExpress.XtraTreeList.TreeList treeList1;
        private MTControl.MLabel mLabel4;
    }
}