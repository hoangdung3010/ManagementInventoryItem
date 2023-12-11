
namespace FormUI
{
    partial class frmDM_PhuKienDetail
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
            this.mLabel3 = new MTControl.MLabel();
            this.txtsTenPhuKien = new MTControl.MTextEdit();
            this.mLabel2 = new MTControl.MLabel();
            this.txtsMaPhuKien = new MTControl.MTextEdit();
            this.mLabel1 = new MTControl.MLabel();
            this.txtsGhiChu = new MTControl.MTextEdit();
            this.mLabel4 = new MTControl.MLabel();
            this.mLookUpSanPham = new MTControl.MLookUpEdit();
            this.mLabel5 = new MTControl.MLabel();
            this.mLookUpDonViTinh = new MTControl.MLookUpEdit();
            this.mLabel6 = new MTControl.MLabel();
            this.mLabel7 = new MTControl.MLabel();
            this.txtsXuatXu = new MTControl.MTextEdit();
            this.spinEditrDonGia = new MTControl.MSpinEdit();
            this.nbrrSoLuong = new MTControl.MSpinEdit();
            this.mLabel8 = new MTControl.MLabel();
            this.pnlHeader.SuspendLayout();
            this.panel3.SuspendLayout();
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
            this.lblTitleFormDetail.Size = new System.Drawing.Size(154, 22);
            this.lblTitleFormDetail.Text = "Danh mục phụ kiện";
            // 
            // pnlHeader
            // 
            this.pnlHeader.Size = new System.Drawing.Size(567, 56);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.nbrrSoLuong);
            this.panel3.Controls.Add(this.mLabel8);
            this.panel3.Controls.Add(this.spinEditrDonGia);
            this.panel3.Controls.Add(this.mLookUpDonViTinh);
            this.panel3.Controls.Add(this.mLookUpSanPham);
            this.panel3.Controls.Add(this.txtsXuatXu);
            this.panel3.Controls.Add(this.mLabel3);
            this.panel3.Controls.Add(this.mLabel7);
            this.panel3.Controls.Add(this.txtsGhiChu);
            this.panel3.Controls.Add(this.mLabel6);
            this.panel3.Controls.Add(this.mLabel5);
            this.panel3.Controls.Add(this.mLabel4);
            this.panel3.Controls.Add(this.txtsTenPhuKien);
            this.panel3.Controls.Add(this.mLabel2);
            this.panel3.Controls.Add(this.txtsMaPhuKien);
            this.panel3.Controls.Add(this.mLabel1);
            this.panel3.Location = new System.Drawing.Point(0, 56);
            this.panel3.Size = new System.Drawing.Size(567, 235);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Location = new System.Drawing.Point(0, 291);
            this.pnlBottom.Size = new System.Drawing.Size(567, 39);
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
            this.mLabel3.IsRequired = true;
            this.mLabel3.Location = new System.Drawing.Point(12, 26);
            this.mLabel3.Name = "mLabel3";
            this.mLabel3.Size = new System.Drawing.Size(85, 16);
            this.mLabel3.TabIndex = 9;
            this.mLabel3.Text = "Thuộc sản phẩm<color=255, 0, 0><size=13>*</size></color>";
            // 
            // txtsTenPhuKien
            // 
            this.txtsTenPhuKien.AutoIncrement = false;
            this.txtsTenPhuKien.Description = null;
            this.txtsTenPhuKien.Grid = null;
            this.txtsTenPhuKien.IsCustomHeight = false;
            this.txtsTenPhuKien.IsReadOnly = false;
            this.txtsTenPhuKien.IsRequired = true;
            this.txtsTenPhuKien.IsSetValueManual = false;
            this.txtsTenPhuKien.Location = new System.Drawing.Point(107, 111);
            this.txtsTenPhuKien.MaxLength = 255;
            this.txtsTenPhuKien.Name = "txtsTenPhuKien";
            this.txtsTenPhuKien.RepositoryItem = null;
            this.txtsTenPhuKien.SetField = "sTenPhuKien";
            this.txtsTenPhuKien.Size = new System.Drawing.Size(445, 22);
            this.txtsTenPhuKien.TabIndex = 3;
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
            this.mLabel2.Location = new System.Drawing.Point(13, 116);
            this.mLabel2.Name = "mLabel2";
            this.mLabel2.Size = new System.Drawing.Size(68, 16);
            this.mLabel2.TabIndex = 8;
            this.mLabel2.Text = "Tên phụ kiện<color=255, 0, 0><size=13>*</size></color>";
            // 
            // txtsMaPhuKien
            // 
            this.txtsMaPhuKien.AutoIncrement = false;
            this.txtsMaPhuKien.Description = null;
            this.txtsMaPhuKien.Grid = null;
            this.txtsMaPhuKien.IsCustomHeight = false;
            this.txtsMaPhuKien.IsReadOnly = false;
            this.txtsMaPhuKien.IsRequired = true;
            this.txtsMaPhuKien.IsSetValueManual = false;
            this.txtsMaPhuKien.Location = new System.Drawing.Point(107, 81);
            this.txtsMaPhuKien.MaxLength = 50;
            this.txtsMaPhuKien.Name = "txtsMaPhuKien";
            this.txtsMaPhuKien.RepositoryItem = null;
            this.txtsMaPhuKien.SetField = "sMaPhuKien";
            this.txtsMaPhuKien.Size = new System.Drawing.Size(205, 22);
            this.txtsMaPhuKien.TabIndex = 2;
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
            this.mLabel1.Location = new System.Drawing.Point(13, 85);
            this.mLabel1.Name = "mLabel1";
            this.mLabel1.Size = new System.Drawing.Size(64, 16);
            this.mLabel1.TabIndex = 7;
            this.mLabel1.Text = "Mã phụ kiện<color=255, 0, 0><size=13>*</size></color>";
            // 
            // txtsGhiChu
            // 
            this.txtsGhiChu.AutoIncrement = false;
            this.txtsGhiChu.Description = null;
            this.txtsGhiChu.Grid = null;
            this.txtsGhiChu.IsCustomHeight = false;
            this.txtsGhiChu.IsReadOnly = false;
            this.txtsGhiChu.IsSetValueManual = false;
            this.txtsGhiChu.Location = new System.Drawing.Point(107, 195);
            this.txtsGhiChu.MaxLength = 255;
            this.txtsGhiChu.Name = "txtsGhiChu";
            this.txtsGhiChu.RepositoryItem = null;
            this.txtsGhiChu.SetField = "sGhiChu";
            this.txtsGhiChu.Size = new System.Drawing.Size(445, 22);
            this.txtsGhiChu.TabIndex = 7;
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
            this.mLabel4.Location = new System.Drawing.Point(13, 200);
            this.mLabel4.Name = "mLabel4";
            this.mLabel4.Size = new System.Drawing.Size(39, 13);
            this.mLabel4.TabIndex = 13;
            this.mLabel4.Text = "Ghi chú";
            // 
            // mLookUpSanPham
            // 
            this.mLookUpSanPham.AddFields = null;
            this.mLookUpSanPham.AliasFormQuickAdd = null;
            this.mLookUpSanPham.ColumnsExtend = null;
            this.mLookUpSanPham.Description = null;
            this.mLookUpSanPham.DictionaryName = null;
            this.mLookUpSanPham.EntityName = null;
            this.mLookUpSanPham.Grid = null;
            this.mLookUpSanPham.IsAutoLoad = false;
            this.mLookUpSanPham.IsReadOnly = false;
            this.mLookUpSanPham.IsRequired = true;
            this.mLookUpSanPham.IsSetValueManual = false;
            this.mLookUpSanPham.KeyStore = null;
            this.mLookUpSanPham.Location = new System.Drawing.Point(107, 22);
            this.mLookUpSanPham.MapColumnName = null;
            this.mLookUpSanPham.Name = "mLookUpSanPham";
            this.mLookUpSanPham.PrimaryKey = null;
            this.mLookUpSanPham.QuickSearchName = null;
            this.mLookUpSanPham.RepositoryItem = null;
            this.mLookUpSanPham.SetField = "sDM_SanPham_Id";
            this.mLookUpSanPham.Size = new System.Drawing.Size(445, 23);
            this.mLookUpSanPham.Sort = null;
            this.mLookUpSanPham.TabIndex = 0;
            this.mLookUpSanPham.ValueDefault = null;
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
            this.mLabel5.Location = new System.Drawing.Point(321, 143);
            this.mLabel5.Name = "mLabel5";
            this.mLabel5.Size = new System.Drawing.Size(58, 16);
            this.mLabel5.TabIndex = 11;
            this.mLabel5.Text = "Đơn vị tính<color=255, 0, 0><size=13>*</size></color>";
            // 
            // mLookUpDonViTinh
            // 
            this.mLookUpDonViTinh.AddFields = null;
            this.mLookUpDonViTinh.AliasFormQuickAdd = null;
            this.mLookUpDonViTinh.ColumnsExtend = null;
            this.mLookUpDonViTinh.Description = null;
            this.mLookUpDonViTinh.DictionaryName = null;
            this.mLookUpDonViTinh.EntityName = null;
            this.mLookUpDonViTinh.Grid = null;
            this.mLookUpDonViTinh.IsAutoLoad = false;
            this.mLookUpDonViTinh.IsReadOnly = false;
            this.mLookUpDonViTinh.IsRequired = true;
            this.mLookUpDonViTinh.IsSetValueManual = false;
            this.mLookUpDonViTinh.KeyStore = null;
            this.mLookUpDonViTinh.Location = new System.Drawing.Point(392, 138);
            this.mLookUpDonViTinh.MapColumnName = null;
            this.mLookUpDonViTinh.Name = "mLookUpDonViTinh";
            this.mLookUpDonViTinh.PrimaryKey = null;
            this.mLookUpDonViTinh.QuickSearchName = null;
            this.mLookUpDonViTinh.RepositoryItem = null;
            this.mLookUpDonViTinh.SetField = "sDM_DonViTinh_Id";
            this.mLookUpDonViTinh.Size = new System.Drawing.Size(160, 23);
            this.mLookUpDonViTinh.Sort = null;
            this.mLookUpDonViTinh.TabIndex = 5;
            this.mLookUpDonViTinh.ValueDefault = null;
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
            this.mLabel6.IsRequired = true;
            this.mLabel6.Location = new System.Drawing.Point(13, 142);
            this.mLabel6.Name = "mLabel6";
            this.mLabel6.Size = new System.Drawing.Size(42, 16);
            this.mLabel6.TabIndex = 10;
            this.mLabel6.Text = "Đơn giá<color=255, 0, 0><size=13>*</size></color>";
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
            this.mLabel7.Location = new System.Drawing.Point(13, 172);
            this.mLabel7.Name = "mLabel7";
            this.mLabel7.Size = new System.Drawing.Size(36, 13);
            this.mLabel7.TabIndex = 12;
            this.mLabel7.Text = "Xuất sứ";
            // 
            // txtsXuatXu
            // 
            this.txtsXuatXu.AutoIncrement = false;
            this.txtsXuatXu.Description = null;
            this.txtsXuatXu.Grid = null;
            this.txtsXuatXu.IsCustomHeight = false;
            this.txtsXuatXu.IsReadOnly = false;
            this.txtsXuatXu.IsSetValueManual = false;
            this.txtsXuatXu.Location = new System.Drawing.Point(107, 167);
            this.txtsXuatXu.MaxLength = 255;
            this.txtsXuatXu.Name = "txtsXuatXu";
            this.txtsXuatXu.RepositoryItem = null;
            this.txtsXuatXu.SetField = "sXuatXu";
            this.txtsXuatXu.Size = new System.Drawing.Size(445, 22);
            this.txtsXuatXu.TabIndex = 6;
            // 
            // spinEditrDonGia
            // 
            this.spinEditrDonGia.DataType = MTControl.FormatType.None;
            this.spinEditrDonGia.DecimalCount = ((byte)(0));
            this.spinEditrDonGia.Description = null;
            this.spinEditrDonGia.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEditrDonGia.Grid = null;
            this.spinEditrDonGia.IsReadOnly = false;
            this.spinEditrDonGia.IsSetValueManual = false;
            this.spinEditrDonGia.Location = new System.Drawing.Point(107, 139);
            this.spinEditrDonGia.Name = "spinEditrDonGia";
            this.spinEditrDonGia.SetField = "rDonGia";
            this.spinEditrDonGia.Size = new System.Drawing.Size(205, 22);
            this.spinEditrDonGia.TabIndex = 4;
            // 
            // nbrrSoLuong
            // 
            this.nbrrSoLuong.DataType = MTControl.FormatType.None;
            this.nbrrSoLuong.DecimalCount = ((byte)(0));
            this.nbrrSoLuong.Description = null;
            this.nbrrSoLuong.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nbrrSoLuong.Grid = null;
            this.nbrrSoLuong.IsReadOnly = false;
            this.nbrrSoLuong.IsRequired = true;
            this.nbrrSoLuong.IsSetValueManual = false;
            this.nbrrSoLuong.Location = new System.Drawing.Point(107, 51);
            this.nbrrSoLuong.Name = "nbrrSoLuong";
            this.nbrrSoLuong.SetField = "rSoLuong";
            this.nbrrSoLuong.Size = new System.Drawing.Size(205, 22);
            this.nbrrSoLuong.TabIndex = 1;
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
            this.mLabel8.IsRequired = true;
            this.mLabel8.Location = new System.Drawing.Point(14, 54);
            this.mLabel8.Name = "mLabel8";
            this.mLabel8.Size = new System.Drawing.Size(47, 16);
            this.mLabel8.TabIndex = 15;
            this.mLabel8.Text = "Số lượng<color=255, 0, 0><size=13>*</size></color>";
            // 
            // frmDM_PhuKienDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 330);
            this.Name = "frmDM_PhuKienDetail";
            this.Text = "frmDM_DonViDetail";
            this.Load += new System.EventHandler(this.frmDM_DonViDetail_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private MTControl.MLabel mLabel3;
        private MTControl.MTextEdit txtsTenPhuKien;
        private MTControl.MLabel mLabel2;
        private MTControl.MTextEdit txtsMaPhuKien;
        private MTControl.MLabel mLabel1;
        private MTControl.MTextEdit txtsGhiChu;
        private MTControl.MLabel mLabel4;
        private MTControl.MLookUpEdit mLookUpSanPham;
        private MTControl.MLookUpEdit mLookUpDonViTinh;
        private MTControl.MLabel mLabel5;
        private MTControl.MTextEdit txtsXuatXu;
        private MTControl.MLabel mLabel7;
        private MTControl.MLabel mLabel6;
        private MTControl.MSpinEdit spinEditrDonGia;
        private MTControl.MSpinEdit nbrrSoLuong;
        private MTControl.MLabel mLabel8;
    }
}