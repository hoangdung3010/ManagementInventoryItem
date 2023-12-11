
namespace FormUI
{
    partial class frmDM_DonViDetail
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
            this.txtsGhiChu = new MTControl.MTextEdit();
            this.mLabel3 = new MTControl.MLabel();
            this.txtsTenDonvi = new MTControl.MTextEdit();
            this.mLabel2 = new MTControl.MLabel();
            this.txtsMaDonvi = new MTControl.MTextEdit();
            this.mLabel1 = new MTControl.MLabel();
            this.mLabel4 = new MTControl.MLabel();
            this.mtreeLookupDonViCha = new MTControl.MTreeLookUpEdit();
            this.mTreeLookUpEdit1TreeList = new DevExpress.XtraTreeList.TreeList();
            this.mLabel5 = new MTControl.MLabel();
            this.rdoLoaiCon = new MTControl.MRadioGroup();
            this.mLabel6 = new MTControl.MLabel();
            this.cboTenCotBaoCao = new MTControl.MComboBox();
            this.pnlHeader.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mtreeLookupDonViCha.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mTreeLookUpEdit1TreeList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdoLoaiCon.Properties)).BeginInit();
            this.SuspendLayout();
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
            this.lblTitleFormDetail.Size = new System.Drawing.Size(134, 22);
            this.lblTitleFormDetail.Text = "Danh mục đơn vị";
            // 
            // pnlHeader
            // 
            this.pnlHeader.Size = new System.Drawing.Size(549, 56);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.cboTenCotBaoCao);
            this.panel3.Controls.Add(this.mLabel6);
            this.panel3.Controls.Add(this.rdoLoaiCon);
            this.panel3.Controls.Add(this.mLabel5);
            this.panel3.Controls.Add(this.mtreeLookupDonViCha);
            this.panel3.Controls.Add(this.mLabel4);
            this.panel3.Controls.Add(this.txtsGhiChu);
            this.panel3.Controls.Add(this.mLabel3);
            this.panel3.Controls.Add(this.txtsTenDonvi);
            this.panel3.Controls.Add(this.mLabel2);
            this.panel3.Controls.Add(this.txtsMaDonvi);
            this.panel3.Controls.Add(this.mLabel1);
            this.panel3.Location = new System.Drawing.Point(0, 56);
            this.panel3.Size = new System.Drawing.Size(549, 230);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Location = new System.Drawing.Point(0, 286);
            this.pnlBottom.Size = new System.Drawing.Size(549, 39);
            // 
            // txtsGhiChu
            // 
            this.txtsGhiChu.AutoIncrement = false;
            this.txtsGhiChu.Description = null;
            this.txtsGhiChu.Grid = null;
            this.txtsGhiChu.IsCustomHeight = false;
            this.txtsGhiChu.IsReadOnly = false;
            this.txtsGhiChu.IsSetValueManual = false;
            this.txtsGhiChu.Location = new System.Drawing.Point(99, 171);
            this.txtsGhiChu.MaxLength = 255;
            this.txtsGhiChu.Name = "txtsGhiChu";
            this.txtsGhiChu.RepositoryItem = null;
            this.txtsGhiChu.SetField = "sGhiChu";
            this.txtsGhiChu.Size = new System.Drawing.Size(436, 22);
            this.txtsGhiChu.TabIndex = 5;
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
            this.mLabel3.Location = new System.Drawing.Point(13, 176);
            this.mLabel3.Name = "mLabel3";
            this.mLabel3.Size = new System.Drawing.Size(39, 13);
            this.mLabel3.TabIndex = 10;
            this.mLabel3.Text = "Ghi chú";
            // 
            // txtsTenDonvi
            // 
            this.txtsTenDonvi.AutoIncrement = false;
            this.txtsTenDonvi.Description = null;
            this.txtsTenDonvi.Grid = null;
            this.txtsTenDonvi.IsCustomHeight = false;
            this.txtsTenDonvi.IsReadOnly = false;
            this.txtsTenDonvi.IsRequired = true;
            this.txtsTenDonvi.IsSetValueManual = false;
            this.txtsTenDonvi.Location = new System.Drawing.Point(99, 47);
            this.txtsTenDonvi.MaxLength = 255;
            this.txtsTenDonvi.Name = "txtsTenDonvi";
            this.txtsTenDonvi.RepositoryItem = null;
            this.txtsTenDonvi.SetField = "sTenDonvi";
            this.txtsTenDonvi.Size = new System.Drawing.Size(436, 22);
            this.txtsTenDonvi.TabIndex = 1;
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
            this.mLabel2.Location = new System.Drawing.Point(13, 52);
            this.mLabel2.Name = "mLabel2";
            this.mLabel2.Size = new System.Drawing.Size(57, 16);
            this.mLabel2.TabIndex = 8;
            this.mLabel2.Text = "Tên đơn vị<color=255, 0, 0><size=13>*</size></color>";
            // 
            // txtsMaDonvi
            // 
            this.txtsMaDonvi.AutoIncrement = false;
            this.txtsMaDonvi.Description = null;
            this.txtsMaDonvi.Grid = null;
            this.txtsMaDonvi.IsCustomHeight = false;
            this.txtsMaDonvi.IsReadOnly = false;
            this.txtsMaDonvi.IsRequired = true;
            this.txtsMaDonvi.IsSetValueManual = false;
            this.txtsMaDonvi.Location = new System.Drawing.Point(99, 18);
            this.txtsMaDonvi.MaxLength = 50;
            this.txtsMaDonvi.Name = "txtsMaDonvi";
            this.txtsMaDonvi.RepositoryItem = null;
            this.txtsMaDonvi.SetField = "sMaDonvi";
            this.txtsMaDonvi.Size = new System.Drawing.Size(221, 22);
            this.txtsMaDonvi.TabIndex = 0;
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
            this.mLabel1.Location = new System.Drawing.Point(13, 22);
            this.mLabel1.Name = "mLabel1";
            this.mLabel1.Size = new System.Drawing.Size(55, 16);
            this.mLabel1.TabIndex = 5;
            this.mLabel1.Text = "Mã đơn vị<color=255, 0, 0><size=13>*</size></color>";
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
            this.mLabel4.Location = new System.Drawing.Point(13, 80);
            this.mLabel4.Name = "mLabel4";
            this.mLabel4.Size = new System.Drawing.Size(63, 13);
            this.mLabel4.TabIndex = 12;
            this.mLabel4.Text = "Thuộc đơn vị";
            // 
            // mtreeLookupDonViCha
            // 
            this.mtreeLookupDonViCha.AddFields = null;
            this.mtreeLookupDonViCha.AliasFormQuickAdd = null;
            this.mtreeLookupDonViCha.CustomSetFields = null;
            this.mtreeLookupDonViCha.Description = null;
            this.mtreeLookupDonViCha.DictionaryName = null;
            this.mtreeLookupDonViCha.EntityName = null;
            this.mtreeLookupDonViCha.Grid = null;
            this.mtreeLookupDonViCha.IsReadOnly = false;
            this.mtreeLookupDonViCha.IsSetValueManual = false;
            this.mtreeLookupDonViCha.KeyStore = null;
            this.mtreeLookupDonViCha.Location = new System.Drawing.Point(99, 77);
            this.mtreeLookupDonViCha.MapColumnName = null;
            this.mtreeLookupDonViCha.Name = "mtreeLookupDonViCha";
            this.mtreeLookupDonViCha.Properties.ActionButtonIndex = 1;
            this.mtreeLookupDonViCha.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.mtreeLookupDonViCha.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.mtreeLookupDonViCha.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mtreeLookupDonViCha.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.mtreeLookupDonViCha.Properties.Appearance.Options.UseBackColor = true;
            this.mtreeLookupDonViCha.Properties.Appearance.Options.UseFont = true;
            this.mtreeLookupDonViCha.Properties.Appearance.Options.UseForeColor = true;
            this.mtreeLookupDonViCha.Properties.AutoHeight = false;
            this.mtreeLookupDonViCha.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete, "", -1, true, false, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "Xóa", "ClearValue", null, DevExpress.Utils.ToolTipAnchor.Default),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.mtreeLookupDonViCha.Properties.ImmediatePopup = true;
            this.mtreeLookupDonViCha.Properties.NullText = "";
            this.mtreeLookupDonViCha.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.mtreeLookupDonViCha.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.mtreeLookupDonViCha.Properties.TreeList = this.mTreeLookUpEdit1TreeList;
            this.mtreeLookupDonViCha.QuickSearchName = null;
            this.mtreeLookupDonViCha.RepositoryItem = null;
            this.mtreeLookupDonViCha.SetField = "sParentId";
            this.mtreeLookupDonViCha.Size = new System.Drawing.Size(436, 23);
            this.mtreeLookupDonViCha.TabIndex = 2;
            this.mtreeLookupDonViCha.EditValueChanged += new System.EventHandler(this.mtreeLookupDonViCha_EditValueChanged);
            this.mtreeLookupDonViCha.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.mtreeLookupDonViCha_EditValueChanging);
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
            this.mLabel5.IsRequired = true;
            this.mLabel5.Location = new System.Drawing.Point(13, 145);
            this.mLabel5.Name = "mLabel5";
            this.mLabel5.Size = new System.Drawing.Size(59, 16);
            this.mLabel5.TabIndex = 15;
            this.mLabel5.Text = "Tên cột BC<color=255, 0, 0><size=13>*</size></color>";
            this.mLabel5.ToolTip = "Tên cột báo cáo";
            // 
            // rdoLoaiCon
            // 
            this.rdoLoaiCon.Description = null;
            this.rdoLoaiCon.IsSetValueManual = false;
            this.rdoLoaiCon.Location = new System.Drawing.Point(99, 110);
            this.rdoLoaiCon.Name = "rdoLoaiCon";
            this.rdoLoaiCon.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.rdoLoaiCon.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.rdoLoaiCon.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.rdoLoaiCon.Properties.Appearance.Options.UseBackColor = true;
            this.rdoLoaiCon.Properties.Appearance.Options.UseFont = true;
            this.rdoLoaiCon.Properties.Appearance.Options.UseForeColor = true;
            this.rdoLoaiCon.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "Cơ cấu tổ chức"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(2, "Nghiệp vụ")});
            this.rdoLoaiCon.SetField = "iType";
            this.rdoLoaiCon.Size = new System.Drawing.Size(221, 22);
            this.rdoLoaiCon.TabIndex = 3;
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
            this.mLabel6.Location = new System.Drawing.Point(14, 115);
            this.mLabel6.Name = "mLabel6";
            this.mLabel6.Size = new System.Drawing.Size(56, 13);
            this.mLabel6.TabIndex = 17;
            this.mLabel6.Text = "Là con theo";
            // 
            // cboTenCotBaoCao
            // 
            this.cboTenCotBaoCao.DefaultValueEnum = -1;
            this.cboTenCotBaoCao.Description = null;
            this.cboTenCotBaoCao.EntityName = false;
            this.cboTenCotBaoCao.EnumData = null;
            this.cboTenCotBaoCao.Grid = null;
            this.cboTenCotBaoCao.IsAutoLoad = false;
            this.cboTenCotBaoCao.IsReadOnly = false;
            this.cboTenCotBaoCao.IsRequired = true;
            this.cboTenCotBaoCao.IsSetValueManual = false;
            this.cboTenCotBaoCao.LastAcceptedSelectedIndex = 0;
            this.cboTenCotBaoCao.Location = new System.Drawing.Point(99, 141);
            this.cboTenCotBaoCao.Name = "cboTenCotBaoCao";
            this.cboTenCotBaoCao.NoDefaultValue = false;
            this.cboTenCotBaoCao.RepositoryItem = null;
            this.cboTenCotBaoCao.SetField = "sTenCotBC";
            this.cboTenCotBaoCao.Size = new System.Drawing.Size(436, 23);
            this.cboTenCotBaoCao.TabIndex = 4;
            // 
            // frmDM_DonViDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 325);
            this.Name = "frmDM_DonViDetail";
            this.Text = "frmDM_DonViDetail";
            this.Load += new System.EventHandler(this.frmDM_DonViDetail_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mtreeLookupDonViCha.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mTreeLookUpEdit1TreeList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdoLoaiCon.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MTControl.MTextEdit txtsGhiChu;
        private MTControl.MLabel mLabel3;
        private MTControl.MTextEdit txtsTenDonvi;
        private MTControl.MLabel mLabel2;
        private MTControl.MTextEdit txtsMaDonvi;
        private MTControl.MLabel mLabel1;
        private MTControl.MLabel mLabel4;
        private MTControl.MTreeLookUpEdit mtreeLookupDonViCha;
        private DevExpress.XtraTreeList.TreeList mTreeLookUpEdit1TreeList;
        private MTControl.MLabel mLabel5;
        private MTControl.MLabel mLabel6;
        private MTControl.MRadioGroup rdoLoaiCon;
        private MTControl.MComboBox cboTenCotBaoCao;
    }
}