
namespace FormUI
{
    partial class frmDM_NhaCCDetail
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
            this.txtsDiaChi = new MTControl.MTextEdit();
            this.mLabel3 = new MTControl.MLabel();
            this.txtsTenNCC = new MTControl.MTextEdit();
            this.mLabel2 = new MTControl.MLabel();
            this.mLabel1 = new MTControl.MLabel();
            this.txtsSoDienThoai = new MTControl.MTextEdit();
            this.mLabel4 = new MTControl.MLabel();
            this.txtsGhiChu = new MTControl.MTextEdit();
            this.mLabel5 = new MTControl.MLabel();
            this.txtsMaSoThue = new MTControl.MTextEdit();
            this.mTextEdit1 = new MTControl.MTextEdit();
            this.mLabel6 = new MTControl.MLabel();
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
            this.lblTitleFormDetail.Size = new System.Drawing.Size(194, 22);
            this.lblTitleFormDetail.Text = "Danh mục nhà cung cấp";
            // 
            // pnlHeader
            // 
            this.pnlHeader.Size = new System.Drawing.Size(546, 56);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.mTextEdit1);
            this.panel3.Controls.Add(this.mLabel6);
            this.panel3.Controls.Add(this.txtsGhiChu);
            this.panel3.Controls.Add(this.mLabel4);
            this.panel3.Controls.Add(this.txtsMaSoThue);
            this.panel3.Controls.Add(this.mLabel5);
            this.panel3.Controls.Add(this.txtsSoDienThoai);
            this.panel3.Controls.Add(this.mLabel1);
            this.panel3.Controls.Add(this.txtsDiaChi);
            this.panel3.Controls.Add(this.mLabel3);
            this.panel3.Controls.Add(this.txtsTenNCC);
            this.panel3.Controls.Add(this.mLabel2);
            this.panel3.Location = new System.Drawing.Point(0, 56);
            this.panel3.Size = new System.Drawing.Size(546, 211);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Location = new System.Drawing.Point(0, 267);
            this.pnlBottom.Size = new System.Drawing.Size(546, 39);
            // 
            // txtsDiaChi
            // 
            this.txtsDiaChi.AutoIncrement = false;
            this.txtsDiaChi.Description = null;
            this.txtsDiaChi.Grid = null;
            this.txtsDiaChi.IsCustomHeight = false;
            this.txtsDiaChi.IsReadOnly = false;
            this.txtsDiaChi.IsSetValueManual = false;
            this.txtsDiaChi.Location = new System.Drawing.Point(82, 105);
            this.txtsDiaChi.MaxLength = 255;
            this.txtsDiaChi.Name = "txtsDiaChi";
            this.txtsDiaChi.RepositoryItem = null;
            this.txtsDiaChi.SetField = "sDiaChi";
            this.txtsDiaChi.Size = new System.Drawing.Size(453, 22);
            this.txtsDiaChi.TabIndex = 2;
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
            this.mLabel3.Location = new System.Drawing.Point(13, 110);
            this.mLabel3.Name = "mLabel3";
            this.mLabel3.Size = new System.Drawing.Size(33, 13);
            this.mLabel3.TabIndex = 10;
            this.mLabel3.Text = "Địa chỉ";
            // 
            // txtsTenNCC
            // 
            this.txtsTenNCC.AutoIncrement = false;
            this.txtsTenNCC.Description = null;
            this.txtsTenNCC.Grid = null;
            this.txtsTenNCC.IsCustomHeight = false;
            this.txtsTenNCC.IsReadOnly = false;
            this.txtsTenNCC.IsRequired = true;
            this.txtsTenNCC.IsSetValueManual = false;
            this.txtsTenNCC.Location = new System.Drawing.Point(82, 75);
            this.txtsTenNCC.MaxLength = 255;
            this.txtsTenNCC.Name = "txtsTenNCC";
            this.txtsTenNCC.RepositoryItem = null;
            this.txtsTenNCC.SetField = "sTenNCC";
            this.txtsTenNCC.Size = new System.Drawing.Size(453, 22);
            this.txtsTenNCC.TabIndex = 1;
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
            this.mLabel2.Location = new System.Drawing.Point(13, 80);
            this.mLabel2.Name = "mLabel2";
            this.mLabel2.Size = new System.Drawing.Size(46, 16);
            this.mLabel2.TabIndex = 8;
            this.mLabel2.Text = "Tên NCC<color=255, 0, 0><size=13>*</size></color>";
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
            this.mLabel1.Location = new System.Drawing.Point(13, 138);
            this.mLabel1.Name = "mLabel1";
            this.mLabel1.Size = new System.Drawing.Size(63, 13);
            this.mLabel1.TabIndex = 10;
            this.mLabel1.Text = "Số điện thoại";
            // 
            // txtsSoDienThoai
            // 
            this.txtsSoDienThoai.AutoIncrement = false;
            this.txtsSoDienThoai.Description = null;
            this.txtsSoDienThoai.Grid = null;
            this.txtsSoDienThoai.IsCustomHeight = false;
            this.txtsSoDienThoai.IsReadOnly = false;
            this.txtsSoDienThoai.IsSetValueManual = false;
            this.txtsSoDienThoai.Location = new System.Drawing.Point(82, 134);
            this.txtsSoDienThoai.MaxLength = 255;
            this.txtsSoDienThoai.Name = "txtsSoDienThoai";
            this.txtsSoDienThoai.RepositoryItem = null;
            this.txtsSoDienThoai.SetField = "sSoDienThoai";
            this.txtsSoDienThoai.Size = new System.Drawing.Size(181, 22);
            this.txtsSoDienThoai.TabIndex = 3;
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
            this.mLabel4.Location = new System.Drawing.Point(13, 166);
            this.mLabel4.Name = "mLabel4";
            this.mLabel4.Size = new System.Drawing.Size(39, 13);
            this.mLabel4.TabIndex = 10;
            this.mLabel4.Text = "Ghi chú";
            // 
            // txtsGhiChu
            // 
            this.txtsGhiChu.AutoIncrement = false;
            this.txtsGhiChu.Description = null;
            this.txtsGhiChu.Grid = null;
            this.txtsGhiChu.IsCustomHeight = false;
            this.txtsGhiChu.IsReadOnly = false;
            this.txtsGhiChu.IsSetValueManual = false;
            this.txtsGhiChu.Location = new System.Drawing.Point(82, 161);
            this.txtsGhiChu.MaxLength = 255;
            this.txtsGhiChu.Name = "txtsGhiChu";
            this.txtsGhiChu.RepositoryItem = null;
            this.txtsGhiChu.SetField = "sGhiChu";
            this.txtsGhiChu.Size = new System.Drawing.Size(453, 22);
            this.txtsGhiChu.TabIndex = 5;
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
            this.mLabel5.Location = new System.Drawing.Point(288, 138);
            this.mLabel5.Name = "mLabel5";
            this.mLabel5.Size = new System.Drawing.Size(53, 13);
            this.mLabel5.TabIndex = 10;
            this.mLabel5.Text = "Mã số thuế";
            // 
            // txtsMaSoThue
            // 
            this.txtsMaSoThue.AutoIncrement = false;
            this.txtsMaSoThue.Description = null;
            this.txtsMaSoThue.Grid = null;
            this.txtsMaSoThue.IsCustomHeight = false;
            this.txtsMaSoThue.IsReadOnly = false;
            this.txtsMaSoThue.IsSetValueManual = false;
            this.txtsMaSoThue.Location = new System.Drawing.Point(347, 134);
            this.txtsMaSoThue.MaxLength = 255;
            this.txtsMaSoThue.Name = "txtsMaSoThue";
            this.txtsMaSoThue.RepositoryItem = null;
            this.txtsMaSoThue.SetField = "sMaSoThue";
            this.txtsMaSoThue.Size = new System.Drawing.Size(188, 22);
            this.txtsMaSoThue.TabIndex = 4;
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
            this.mTextEdit1.Location = new System.Drawing.Point(81, 45);
            this.mTextEdit1.MaxLength = 4;
            this.mTextEdit1.Name = "mTextEdit1";
            this.mTextEdit1.RepositoryItem = null;
            this.mTextEdit1.SetField = "sMaNCC";
            this.mTextEdit1.Size = new System.Drawing.Size(182, 22);
            this.mTextEdit1.TabIndex = 0;
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
            this.mLabel6.Location = new System.Drawing.Point(12, 50);
            this.mLabel6.Name = "mLabel6";
            this.mLabel6.Size = new System.Drawing.Size(39, 13);
            this.mLabel6.TabIndex = 12;
            this.mLabel6.Text = "Mã NCC";
            this.mLabel6.ToolTip = "Mã nhà cung cấp";
            // 
            // frmDM_NhaCCDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 306);
            this.Name = "frmDM_NhaCCDetail";
            this.Text = "frmDM_DonViDetail";
            this.Load += new System.EventHandler(this.frmDM_DonViDetail_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MTControl.MTextEdit txtsDiaChi;
        private MTControl.MLabel mLabel3;
        private MTControl.MTextEdit txtsTenNCC;
        private MTControl.MLabel mLabel2;
        private MTControl.MTextEdit txtsGhiChu;
        private MTControl.MLabel mLabel4;
        private MTControl.MTextEdit txtsMaSoThue;
        private MTControl.MLabel mLabel5;
        private MTControl.MTextEdit txtsSoDienThoai;
        private MTControl.MLabel mLabel1;
        private MTControl.MTextEdit mTextEdit1;
        private MTControl.MLabel mLabel6;
    }
}