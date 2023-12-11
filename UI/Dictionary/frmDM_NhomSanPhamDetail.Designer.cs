
namespace FormUI
{
    partial class frmDM_NhomSanPhamDetail
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
            this.txtsTenNhomSanPham = new MTControl.MTextEdit();
            this.mLabel2 = new MTControl.MLabel();
            this.mLabel1 = new MTControl.MLabel();
            this.treesParentId = new MTControl.MTreeLookUpEdit();
            this.mTreeLookUpEdit1TreeList = new DevExpress.XtraTreeList.TreeList();
            this.mTextEdit1 = new MTControl.MTextEdit();
            this.mLabel4 = new MTControl.MLabel();
            this.pnlHeader.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treesParentId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mTreeLookUpEdit1TreeList)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitleFormDetail
            // 
            this.lblTitleFormDetail.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblTitleFormDetail.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTitleFormDetail.Appearance.Options.UseFont = true;
            this.lblTitleFormDetail.Appearance.Options.UseForeColor = true;
            this.lblTitleFormDetail.Appearance.Options.UseTextOptions = true;
            this.lblTitleFormDetail.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lblTitleFormDetail.Size = new System.Drawing.Size(213, 22);
            this.lblTitleFormDetail.Text = "Danh mục nhóm sản phẩm";
            // 
            // pnlHeader
            // 
            this.pnlHeader.Size = new System.Drawing.Size(546, 56);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.mTextEdit1);
            this.panel3.Controls.Add(this.mLabel4);
            this.panel3.Controls.Add(this.treesParentId);
            this.panel3.Controls.Add(this.mLabel1);
            this.panel3.Controls.Add(this.txtsGhiChu);
            this.panel3.Controls.Add(this.mLabel3);
            this.panel3.Controls.Add(this.txtsTenNhomSanPham);
            this.panel3.Controls.Add(this.mLabel2);
            this.panel3.Location = new System.Drawing.Point(0, 56);
            this.panel3.Size = new System.Drawing.Size(546, 111);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Location = new System.Drawing.Point(0, 167);
            this.pnlBottom.Size = new System.Drawing.Size(546, 39);
            // 
            // txtsGhiChu
            // 
            this.txtsGhiChu.AutoIncrement = false;
            this.txtsGhiChu.Description = null;
            this.txtsGhiChu.Grid = null;
            this.txtsGhiChu.IsCustomHeight = false;
            this.txtsGhiChu.IsReadOnly = false;
            this.txtsGhiChu.IsSetValueManual = false;
            this.txtsGhiChu.Location = new System.Drawing.Point(98, 68);
            this.txtsGhiChu.MaxLength = 255;
            this.txtsGhiChu.Name = "txtsGhiChu";
            this.txtsGhiChu.RepositoryItem = null;
            this.txtsGhiChu.SetField = "sGhiChu";
            this.txtsGhiChu.Size = new System.Drawing.Size(436, 22);
            this.txtsGhiChu.TabIndex = 3;
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
            this.mLabel3.Location = new System.Drawing.Point(8, 72);
            this.mLabel3.Name = "mLabel3";
            this.mLabel3.Size = new System.Drawing.Size(39, 13);
            this.mLabel3.TabIndex = 10;
            this.mLabel3.Text = "Ghi chú";
            // 
            // txtsTenNhomSanPham
            // 
            this.txtsTenNhomSanPham.AutoIncrement = false;
            this.txtsTenNhomSanPham.Description = null;
            this.txtsTenNhomSanPham.Grid = null;
            this.txtsTenNhomSanPham.IsCustomHeight = false;
            this.txtsTenNhomSanPham.IsReadOnly = false;
            this.txtsTenNhomSanPham.IsRequired = true;
            this.txtsTenNhomSanPham.IsSetValueManual = false;
            this.txtsTenNhomSanPham.Location = new System.Drawing.Point(98, 14);
            this.txtsTenNhomSanPham.MaxLength = 255;
            this.txtsTenNhomSanPham.Name = "txtsTenNhomSanPham";
            this.txtsTenNhomSanPham.RepositoryItem = null;
            this.txtsTenNhomSanPham.SetField = "sTenNhomSanPham";
            this.txtsTenNhomSanPham.Size = new System.Drawing.Size(257, 22);
            this.txtsTenNhomSanPham.TabIndex = 0;
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
            this.mLabel2.Location = new System.Drawing.Point(8, 18);
            this.mLabel2.Name = "mLabel2";
            this.mLabel2.Size = new System.Drawing.Size(71, 16);
            this.mLabel2.TabIndex = 8;
            this.mLabel2.Text = "Tên nhóm SP <color=255, 0, 0><size=13>*</size></color>";
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
            this.mLabel1.Location = new System.Drawing.Point(8, 45);
            this.mLabel1.Name = "mLabel1";
            this.mLabel1.Size = new System.Drawing.Size(74, 13);
            this.mLabel1.TabIndex = 11;
            this.mLabel1.Text = "Thuộc nhóm SP";
            // 
            // treesParentId
            // 
            this.treesParentId.AddFields = null;
            this.treesParentId.AliasFormQuickAdd = null;
            this.treesParentId.CustomSetFields = null;
            this.treesParentId.Description = null;
            this.treesParentId.DictionaryName = null;
            this.treesParentId.EntityName = null;
            this.treesParentId.Grid = null;
            this.treesParentId.IsReadOnly = false;
            this.treesParentId.IsSetValueManual = false;
            this.treesParentId.KeyStore = null;
            this.treesParentId.Location = new System.Drawing.Point(98, 42);
            this.treesParentId.MapColumnName = null;
            this.treesParentId.Name = "treesParentId";
            this.treesParentId.Properties.ActionButtonIndex = 1;
            this.treesParentId.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.treesParentId.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.treesParentId.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treesParentId.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treesParentId.Properties.Appearance.Options.UseBackColor = true;
            this.treesParentId.Properties.Appearance.Options.UseFont = true;
            this.treesParentId.Properties.Appearance.Options.UseForeColor = true;
            this.treesParentId.Properties.AutoHeight = false;
            this.treesParentId.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete, "", -1, true, false, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "Xóa", "ClearValue", null, DevExpress.Utils.ToolTipAnchor.Default),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.treesParentId.Properties.ImmediatePopup = true;
            this.treesParentId.Properties.NullText = "";
            this.treesParentId.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.treesParentId.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.treesParentId.Properties.TreeList = this.mTreeLookUpEdit1TreeList;
            this.treesParentId.QuickSearchName = null;
            this.treesParentId.RepositoryItem = null;
            this.treesParentId.SetField = "sParentId";
            this.treesParentId.Size = new System.Drawing.Size(436, 23);
            this.treesParentId.TabIndex = 2;
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
            // mTextEdit1
            // 
            this.mTextEdit1.AutoIncrement = false;
            this.mTextEdit1.Description = null;
            this.mTextEdit1.Grid = null;
            this.mTextEdit1.IsCustomHeight = false;
            this.mTextEdit1.IsReadOnly = false;
            this.mTextEdit1.IsRequired = true;
            this.mTextEdit1.IsSetValueManual = false;
            this.mTextEdit1.Location = new System.Drawing.Point(425, 14);
            this.mTextEdit1.MaxLength = 255;
            this.mTextEdit1.Name = "mTextEdit1";
            this.mTextEdit1.RepositoryItem = null;
            this.mTextEdit1.SetField = "sMaNhomSanPham";
            this.mTextEdit1.Size = new System.Drawing.Size(109, 22);
            this.mTextEdit1.TabIndex = 1;
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
            this.mLabel4.Location = new System.Drawing.Point(361, 18);
            this.mLabel4.Name = "mLabel4";
            this.mLabel4.Size = new System.Drawing.Size(64, 13);
            this.mLabel4.TabIndex = 14;
            this.mLabel4.Text = "Mã nhóm SP <color=255, 0, 0><size=13></size></color>";
            // 
            // frmDM_NhomSanPhamDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 206);
            this.Name = "frmDM_NhomSanPhamDetail";
            this.Text = "frmDM_DonViDetail";
            this.Load += new System.EventHandler(this.frmDM_NhomSanPhamDetail_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treesParentId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mTreeLookUpEdit1TreeList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MTControl.MTextEdit txtsGhiChu;
        private MTControl.MLabel mLabel3;
        private MTControl.MTextEdit txtsTenNhomSanPham;
        private MTControl.MLabel mLabel2;
        private MTControl.MLabel mLabel1;
        private MTControl.MTreeLookUpEdit treesParentId;
        private DevExpress.XtraTreeList.TreeList mTreeLookUpEdit1TreeList;
        private MTControl.MTextEdit mTextEdit1;
        private MTControl.MLabel mLabel4;
    }
}