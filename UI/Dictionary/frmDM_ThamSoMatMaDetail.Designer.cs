
namespace FormUI
{
    partial class frmDM_ThamSoMatMaDetail
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
            this.txtsTenThamSoMatMa = new MTControl.MTextEdit();
            this.mLabel2 = new MTControl.MLabel();
            this.txtsMaThamSoMatMa = new MTControl.MTextEdit();
            this.mLabel1 = new MTControl.MLabel();
            this.mLabel4 = new MTControl.MLabel();
            this.txtsGhiChu = new MTControl.MTextEdit();
            this.mLabel5 = new MTControl.MLabel();
            this.dtdNgayHieuLuc = new MTControl.MDateEdit();
            this.mSpinEditiThoiHanSuDung = new MTControl.MSpinEdit();
            this.cboEnumiDonViThoiGianHieuLuc = new MTControl.MComboBox();
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
            this.lblTitleFormDetail.Size = new System.Drawing.Size(212, 22);
            this.lblTitleFormDetail.Text = "Danh mục tham số mật mã";
            // 
            // pnlHeader
            // 
            this.pnlHeader.Size = new System.Drawing.Size(556, 56);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.cboEnumiDonViThoiGianHieuLuc);
            this.panel3.Controls.Add(this.mSpinEditiThoiHanSuDung);
            this.panel3.Controls.Add(this.dtdNgayHieuLuc);
            this.panel3.Controls.Add(this.txtsGhiChu);
            this.panel3.Controls.Add(this.mLabel5);
            this.panel3.Controls.Add(this.mLabel4);
            this.panel3.Controls.Add(this.mLabel3);
            this.panel3.Controls.Add(this.txtsTenThamSoMatMa);
            this.panel3.Controls.Add(this.mLabel2);
            this.panel3.Controls.Add(this.txtsMaThamSoMatMa);
            this.panel3.Controls.Add(this.mLabel1);
            this.panel3.Location = new System.Drawing.Point(0, 56);
            this.panel3.Size = new System.Drawing.Size(556, 148);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Location = new System.Drawing.Point(0, 204);
            this.pnlBottom.Size = new System.Drawing.Size(556, 39);
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
            this.mLabel3.Location = new System.Drawing.Point(13, 82);
            this.mLabel3.Name = "mLabel3";
            this.mLabel3.Size = new System.Drawing.Size(65, 16);
            this.mLabel3.TabIndex = 7;
            this.mLabel3.Text = "Thời hạn SD<color=255, 0, 0><size=13>*</size></color>";
            this.mLabel3.ToolTip = "Thời gian sử dụng";
            // 
            // txtsTenThamSoMatMa
            // 
            this.txtsTenThamSoMatMa.AutoIncrement = false;
            this.txtsTenThamSoMatMa.Description = null;
            this.txtsTenThamSoMatMa.Grid = null;
            this.txtsTenThamSoMatMa.IsCustomHeight = false;
            this.txtsTenThamSoMatMa.IsReadOnly = false;
            this.txtsTenThamSoMatMa.IsRequired = true;
            this.txtsTenThamSoMatMa.IsSetValueManual = false;
            this.txtsTenThamSoMatMa.Location = new System.Drawing.Point(90, 48);
            this.txtsTenThamSoMatMa.MaxLength = 255;
            this.txtsTenThamSoMatMa.Name = "txtsTenThamSoMatMa";
            this.txtsTenThamSoMatMa.RepositoryItem = null;
            this.txtsTenThamSoMatMa.SetField = "sTenThamSoMatMa";
            this.txtsTenThamSoMatMa.Size = new System.Drawing.Size(453, 22);
            this.txtsTenThamSoMatMa.TabIndex = 1;
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
            this.mLabel2.Size = new System.Drawing.Size(55, 16);
            this.mLabel2.TabIndex = 6;
            this.mLabel2.Text = "Tên TSMM<color=255, 0, 0><size=13>*</size></color>";
            this.mLabel2.ToolTip = "Tên tham số mật mã";
            // 
            // txtsMaThamSoMatMa
            // 
            this.txtsMaThamSoMatMa.AutoIncrement = false;
            this.txtsMaThamSoMatMa.Description = null;
            this.txtsMaThamSoMatMa.Grid = null;
            this.txtsMaThamSoMatMa.IsCustomHeight = false;
            this.txtsMaThamSoMatMa.IsReadOnly = false;
            this.txtsMaThamSoMatMa.IsRequired = true;
            this.txtsMaThamSoMatMa.IsSetValueManual = false;
            this.txtsMaThamSoMatMa.Location = new System.Drawing.Point(90, 18);
            this.txtsMaThamSoMatMa.MaxLength = 50;
            this.txtsMaThamSoMatMa.Name = "txtsMaThamSoMatMa";
            this.txtsMaThamSoMatMa.RepositoryItem = null;
            this.txtsMaThamSoMatMa.SetField = "sMaThamSoMatMa";
            this.txtsMaThamSoMatMa.Size = new System.Drawing.Size(206, 22);
            this.txtsMaThamSoMatMa.TabIndex = 0;
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
            this.mLabel1.Size = new System.Drawing.Size(53, 16);
            this.mLabel1.TabIndex = 5;
            this.mLabel1.Text = "Mã TSMM<color=255, 0, 0><size=13>*</size></color>";
            this.mLabel1.ToolTip = "Mã tham số mật mã";
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
            this.mLabel4.Location = new System.Drawing.Point(311, 83);
            this.mLabel4.Name = "mLabel4";
            this.mLabel4.Size = new System.Drawing.Size(65, 13);
            this.mLabel4.TabIndex = 8;
            this.mLabel4.Text = "Ngày hiệu lực";
            // 
            // txtsGhiChu
            // 
            this.txtsGhiChu.AutoIncrement = false;
            this.txtsGhiChu.Description = null;
            this.txtsGhiChu.Grid = null;
            this.txtsGhiChu.IsCustomHeight = false;
            this.txtsGhiChu.IsReadOnly = false;
            this.txtsGhiChu.IsSetValueManual = false;
            this.txtsGhiChu.Location = new System.Drawing.Point(90, 108);
            this.txtsGhiChu.MaxLength = 255;
            this.txtsGhiChu.Name = "txtsGhiChu";
            this.txtsGhiChu.RepositoryItem = null;
            this.txtsGhiChu.SetField = "sGhiChu";
            this.txtsGhiChu.Size = new System.Drawing.Size(453, 22);
            this.txtsGhiChu.TabIndex = 4;
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
            this.mLabel5.Location = new System.Drawing.Point(13, 112);
            this.mLabel5.Name = "mLabel5";
            this.mLabel5.Size = new System.Drawing.Size(39, 13);
            this.mLabel5.TabIndex = 9;
            this.mLabel5.Text = "Ghi chú";
            // 
            // dtdNgayHieuLuc
            // 
            this.dtdNgayHieuLuc.Description = null;
            this.dtdNgayHieuLuc.EditValue = null;
            this.dtdNgayHieuLuc.Grid = null;
            this.dtdNgayHieuLuc.IsReadOnly = false;
            this.dtdNgayHieuLuc.IsSetValueManual = false;
            this.dtdNgayHieuLuc.Location = new System.Drawing.Point(387, 79);
            this.dtdNgayHieuLuc.Name = "dtdNgayHieuLuc";
            this.dtdNgayHieuLuc.RepositoryItem = null;
            this.dtdNgayHieuLuc.SetField = "dNgayHieuLuc";
            this.dtdNgayHieuLuc.Size = new System.Drawing.Size(156, 22);
            this.dtdNgayHieuLuc.TabIndex = 3;
            // 
            // mSpinEditiThoiHanSuDung
            // 
            this.mSpinEditiThoiHanSuDung.DataType = MTControl.FormatType.None;
            this.mSpinEditiThoiHanSuDung.DecimalCount = ((byte)(0));
            this.mSpinEditiThoiHanSuDung.Description = null;
            this.mSpinEditiThoiHanSuDung.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.mSpinEditiThoiHanSuDung.Grid = null;
            this.mSpinEditiThoiHanSuDung.IsReadOnly = false;
            this.mSpinEditiThoiHanSuDung.IsRequired = true;
            this.mSpinEditiThoiHanSuDung.IsSetValueManual = false;
            this.mSpinEditiThoiHanSuDung.Location = new System.Drawing.Point(90, 78);
            this.mSpinEditiThoiHanSuDung.Name = "mSpinEditiThoiHanSuDung";
            this.mSpinEditiThoiHanSuDung.SetField = "iThoiHanSuDung";
            this.mSpinEditiThoiHanSuDung.Size = new System.Drawing.Size(92, 22);
            this.mSpinEditiThoiHanSuDung.TabIndex = 11;
            // 
            // cboEnumiDonViThoiGianHieuLuc
            // 
            this.cboEnumiDonViThoiGianHieuLuc.DefaultValueEnum = -1;
            this.cboEnumiDonViThoiGianHieuLuc.Description = null;
            this.cboEnumiDonViThoiGianHieuLuc.EntityName = false;
            this.cboEnumiDonViThoiGianHieuLuc.EnumData = null;
            this.cboEnumiDonViThoiGianHieuLuc.Grid = null;
            this.cboEnumiDonViThoiGianHieuLuc.IsAutoLoad = false;
            this.cboEnumiDonViThoiGianHieuLuc.IsReadOnly = false;
            this.cboEnumiDonViThoiGianHieuLuc.IsRequired = true;
            this.cboEnumiDonViThoiGianHieuLuc.IsSetValueManual = false;
            this.cboEnumiDonViThoiGianHieuLuc.LastAcceptedSelectedIndex = 0;
            this.cboEnumiDonViThoiGianHieuLuc.Location = new System.Drawing.Point(188, 78);
            this.cboEnumiDonViThoiGianHieuLuc.Name = "cboEnumiDonViThoiGianHieuLuc";
            this.cboEnumiDonViThoiGianHieuLuc.RepositoryItem = null;
            this.cboEnumiDonViThoiGianHieuLuc.SetField = "iDonViThoiGianHieuLuc";
            this.cboEnumiDonViThoiGianHieuLuc.Size = new System.Drawing.Size(108, 23);
            this.cboEnumiDonViThoiGianHieuLuc.TabIndex = 12;
            // 
            // frmDM_ThamSoMatMaDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 243);
            this.Name = "frmDM_ThamSoMatMaDetail";
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
        private MTControl.MTextEdit txtsTenThamSoMatMa;
        private MTControl.MLabel mLabel2;
        private MTControl.MTextEdit txtsMaThamSoMatMa;
        private MTControl.MLabel mLabel1;
        private MTControl.MTextEdit txtsGhiChu;
        private MTControl.MLabel mLabel5;
        private MTControl.MLabel mLabel4;
        private MTControl.MDateEdit dtdNgayHieuLuc;
        private MTControl.MSpinEdit mSpinEditiThoiHanSuDung;
        private MTControl.MComboBox cboEnumiDonViThoiGianHieuLuc;
    }
}