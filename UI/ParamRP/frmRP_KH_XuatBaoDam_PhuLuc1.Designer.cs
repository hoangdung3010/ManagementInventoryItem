namespace FormUI
{
    partial class frmRP_KH_XuatBaoDam_PhuLuc1
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBoxInput = new MTControl.MGroupControl();
            this.cboNam = new MTControl.MLookUpEdit();
            this.mLabel2 = new MTControl.MLabel();
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
            this.splitContainer1.Size = new System.Drawing.Size(661, 307);
            this.splitContainer1.SplitterDistance = 104;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBoxInput
            // 
            this.groupBoxInput.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.groupBoxInput.Appearance.Options.UseForeColor = true;
            this.groupBoxInput.ColumnName = "";
            this.groupBoxInput.Controls.Add(this.cboNam);
            this.groupBoxInput.Controls.Add(this.mLabel2);
            this.groupBoxInput.Controls.Add(this.cboDonVi);
            this.groupBoxInput.Controls.Add(this.mLabel1);
            this.groupBoxInput.Description = null;
            this.groupBoxInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxInput.Location = new System.Drawing.Point(0, 0);
            this.groupBoxInput.Name = "groupBoxInput";
            this.groupBoxInput.Size = new System.Drawing.Size(661, 104);
            this.groupBoxInput.TabIndex = 1;
            this.groupBoxInput.Text = "1. Thông tin đầu vào";
            // 
            // cboNam
            // 
            this.cboNam.AddFields = null;
            this.cboNam.AliasFormQuickAdd = null;
            this.cboNam.ColumnsExtend = null;
            this.cboNam.Description = null;
            this.cboNam.DictionaryName = null;
            this.cboNam.EntityName = null;
            this.cboNam.Grid = null;
            this.cboNam.IsAutoLoad = false;
            this.cboNam.IsHideClearValue = false;
            this.cboNam.IsReadOnly = false;
            this.cboNam.IsRequired = true;
            this.cboNam.IsSetValueManual = false;
            this.cboNam.KeyStore = null;
            this.cboNam.Location = new System.Drawing.Point(116, 72);
            this.cboNam.MapColumnName = null;
            this.cboNam.Name = "cboNam";
            this.cboNam.PrimaryKey = null;
            this.cboNam.QuickSearchName = null;
            this.cboNam.RepositoryItem = null;
            this.cboNam.SetField = "iNam";
            this.cboNam.Size = new System.Drawing.Size(168, 23);
            this.cboNam.Sort = null;
            this.cboNam.TabIndex = 4;
            this.cboNam.ValueDefault = null;
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
            this.mLabel2.IsRequired = true;
            this.mLabel2.Location = new System.Drawing.Point(29, 75);
            this.mLabel2.Name = "mLabel2";
            this.mLabel2.Size = new System.Drawing.Size(26, 16);
            this.mLabel2.TabIndex = 3;
            this.mLabel2.Text = "Năm<color=255, 0, 0><size=13>*</size></color>";
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
            this.cboDonVi.Properties.ActionButtonIndex = 1;
            this.cboDonVi.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.cboDonVi.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cboDonVi.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.cboDonVi.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cboDonVi.Properties.Appearance.Options.UseBackColor = true;
            this.cboDonVi.Properties.Appearance.Options.UseFont = true;
            this.cboDonVi.Properties.Appearance.Options.UseForeColor = true;
            this.cboDonVi.Properties.AutoHeight = false;
            this.cboDonVi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete, "", -1, true, false, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "Xóa", "ClearValue", null, DevExpress.Utils.ToolTipAnchor.Default),
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
            this.cboDonVi.TabIndex = 1;
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
            this.mUserControlParamRP.Location = new System.Drawing.Point(0, 0);
            this.mUserControlParamRP.MyGetCustomParams = null;
            this.mUserControlParamRP.MySetCustomConfigExcel = null;
            this.mUserControlParamRP.Name = "mUserControlParamRP";
            this.mUserControlParamRP.RootControl = null;
            this.mUserControlParamRP.Size = new System.Drawing.Size(660, 199);
            this.mUserControlParamRP.TabIndex = 0;
            // 
            // frmRP_KH_XuatBaoDam_PhuLuc1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 307);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmRP_KH_XuatBaoDam_PhuLuc1";
            this.Text = "Phụ lục 1 KH bảo đảm";
            this.Load += new System.EventHandler(this.frmRP_KH_XuatBaoDam_PhuLuc1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupBoxInput)).EndInit();
            this.groupBoxInput.ResumeLayout(false);
            this.groupBoxInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboDonVi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mTreeLookUpEdit1TreeList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        public MTControl.MGroupControl groupBoxInput;
        private Base.MUserControlParamRP mUserControlParamRP;
        private MTControl.MLabel mLabel1;
        private MTControl.MTreeLookUpEdit cboDonVi;
        private DevExpress.XtraTreeList.TreeList mTreeLookUpEdit1TreeList;
        private MTControl.MLabel mLabel2;
        private MTControl.MLookUpEdit cboNam;
    }
}