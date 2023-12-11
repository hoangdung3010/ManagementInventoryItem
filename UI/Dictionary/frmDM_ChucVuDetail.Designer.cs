
namespace FormUI
{
    partial class frmDM_ChucVuDetail
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
            this.txtsGhiChu = new MTControl.MTextEdit();
            this.mLabel3 = new MTControl.MLabel();
            this.mtesTenChucVu = new MTControl.MTextEdit();
            this.mLabel2 = new MTControl.MLabel();
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
            this.lblTitleFormDetail.Size = new System.Drawing.Size(148, 22);
            this.lblTitleFormDetail.Text = "Danh mục chức vụ";
            // 
            // pnlHeader
            // 
            this.pnlHeader.Size = new System.Drawing.Size(546, 56);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtsGhiChu);
            this.panel3.Controls.Add(this.mLabel3);
            this.panel3.Controls.Add(this.mtesTenChucVu);
            this.panel3.Controls.Add(this.mLabel2);
            this.panel3.Location = new System.Drawing.Point(0, 56);
            this.panel3.Size = new System.Drawing.Size(546, 99);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Location = new System.Drawing.Point(0, 155);
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
            this.txtsGhiChu.Location = new System.Drawing.Point(95, 56);
            this.txtsGhiChu.MaxLength = 255;
            this.txtsGhiChu.Name = "txtsGhiChu";
            this.txtsGhiChu.RepositoryItem = null;
            this.txtsGhiChu.SetField = "sGhiChu";
            this.txtsGhiChu.Size = new System.Drawing.Size(440, 22);
            this.txtsGhiChu.TabIndex = 1;
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
            this.mLabel3.Location = new System.Drawing.Point(13, 61);
            this.mLabel3.Name = "mLabel3";
            this.mLabel3.Size = new System.Drawing.Size(39, 13);
            this.mLabel3.TabIndex = 10;
            this.mLabel3.Text = "Ghi chú";
            // 
            // mtesTenChucVu
            // 
            this.mtesTenChucVu.AutoIncrement = false;
            this.mtesTenChucVu.Description = null;
            this.mtesTenChucVu.Grid = null;
            this.mtesTenChucVu.IsCustomHeight = false;
            this.mtesTenChucVu.IsReadOnly = false;
            this.mtesTenChucVu.IsRequired = true;
            this.mtesTenChucVu.IsSetValueManual = false;
            this.mtesTenChucVu.Location = new System.Drawing.Point(95, 26);
            this.mtesTenChucVu.MaxLength = 255;
            this.mtesTenChucVu.Name = "mtesTenChucVu";
            this.mtesTenChucVu.RepositoryItem = null;
            this.mtesTenChucVu.SetField = "sTenChucVu";
            this.mtesTenChucVu.Size = new System.Drawing.Size(440, 22);
            this.mtesTenChucVu.TabIndex = 0;
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
            this.mLabel2.Location = new System.Drawing.Point(13, 31);
            this.mLabel2.Name = "mLabel2";
            this.mLabel2.Size = new System.Drawing.Size(66, 16);
            this.mLabel2.TabIndex = 8;
            this.mLabel2.Text = "Tên chức vụ<color=255, 0, 0><size=13>*</size></color>";
            // 
            // frmDM_ChucVuDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 194);
            this.Name = "frmDM_ChucVuDetail";
            this.Text = "frmDM_DonViDetail";
            this.Load += new System.EventHandler(this.frmDM_DonViTinhDetail_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MTControl.MTextEdit txtsGhiChu;
        private MTControl.MLabel mLabel3;
        private MTControl.MTextEdit mtesTenChucVu;
        private MTControl.MLabel mLabel2;
    }
}