
namespace FormUI
{
    partial class frmDM_MangLienLacDetail
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
            this.txtsTenMangLienLac = new MTControl.MTextEdit();
            this.mLabel2 = new MTControl.MLabel();
            this.txtsMaMangLienLac = new MTControl.MTextEdit();
            this.mLabel1 = new MTControl.MLabel();
            this.txtsGhiChu = new MTControl.MTextEdit();
            this.mLabel4 = new MTControl.MLabel();
            this.mLookUpThamSoMatMa = new MTControl.MLookUpEdit();
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
            this.lblTitleFormDetail.Size = new System.Drawing.Size(191, 22);
            this.lblTitleFormDetail.Text = "Danh mục mạng liên lạc";
            // 
            // pnlHeader
            // 
            this.pnlHeader.Size = new System.Drawing.Size(563, 56);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.mLookUpThamSoMatMa);
            this.panel3.Controls.Add(this.txtsGhiChu);
            this.panel3.Controls.Add(this.mLabel4);
            this.panel3.Controls.Add(this.mLabel3);
            this.panel3.Controls.Add(this.txtsTenMangLienLac);
            this.panel3.Controls.Add(this.mLabel2);
            this.panel3.Controls.Add(this.txtsMaMangLienLac);
            this.panel3.Controls.Add(this.mLabel1);
            this.panel3.Location = new System.Drawing.Point(0, 56);
            this.panel3.Size = new System.Drawing.Size(563, 145);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Location = new System.Drawing.Point(0, 201);
            this.pnlBottom.Size = new System.Drawing.Size(563, 39);
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
            this.mLabel3.Size = new System.Drawing.Size(83, 16);
            this.mLabel3.TabIndex = 4;
            this.mLabel3.Text = "Tham số mật mã<color=255, 0, 0><size=13>*</size></color>";
            // 
            // txtsTenMangLienLac
            // 
            this.txtsTenMangLienLac.AutoIncrement = false;
            this.txtsTenMangLienLac.Description = null;
            this.txtsTenMangLienLac.Grid = null;
            this.txtsTenMangLienLac.IsCustomHeight = false;
            this.txtsTenMangLienLac.IsReadOnly = false;
            this.txtsTenMangLienLac.IsRequired = true;
            this.txtsTenMangLienLac.IsSetValueManual = false;
            this.txtsTenMangLienLac.Location = new System.Drawing.Point(104, 47);
            this.txtsTenMangLienLac.MaxLength = 255;
            this.txtsTenMangLienLac.Name = "txtsTenMangLienLac";
            this.txtsTenMangLienLac.RepositoryItem = null;
            this.txtsTenMangLienLac.SetField = "sTenMangLienLac";
            this.txtsTenMangLienLac.Size = new System.Drawing.Size(445, 22);
            this.txtsTenMangLienLac.TabIndex = 3;
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
            this.mLabel2.Size = new System.Drawing.Size(46, 16);
            this.mLabel2.TabIndex = 2;
            this.mLabel2.Text = "Tên MLL<color=255, 0, 0><size=13>*</size></color>";
            // 
            // txtsMaMangLienLac
            // 
            this.txtsMaMangLienLac.AutoIncrement = false;
            this.txtsMaMangLienLac.Description = null;
            this.txtsMaMangLienLac.Grid = null;
            this.txtsMaMangLienLac.IsCustomHeight = false;
            this.txtsMaMangLienLac.IsReadOnly = false;
            this.txtsMaMangLienLac.IsRequired = true;
            this.txtsMaMangLienLac.IsSetValueManual = false;
            this.txtsMaMangLienLac.Location = new System.Drawing.Point(104, 18);
            this.txtsMaMangLienLac.MaxLength = 50;
            this.txtsMaMangLienLac.Name = "txtsMaMangLienLac";
            this.txtsMaMangLienLac.RepositoryItem = null;
            this.txtsMaMangLienLac.SetField = "sMaMangLienLac";
            this.txtsMaMangLienLac.Size = new System.Drawing.Size(205, 22);
            this.txtsMaMangLienLac.TabIndex = 1;
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
            this.mLabel1.Size = new System.Drawing.Size(44, 16);
            this.mLabel1.TabIndex = 0;
            this.mLabel1.Text = "Mã MLL<color=255, 0, 0><size=13>*</size></color>";
            // 
            // txtsGhiChu
            // 
            this.txtsGhiChu.AutoIncrement = false;
            this.txtsGhiChu.Description = null;
            this.txtsGhiChu.Grid = null;
            this.txtsGhiChu.IsCustomHeight = false;
            this.txtsGhiChu.IsReadOnly = false;
            this.txtsGhiChu.IsSetValueManual = false;
            this.txtsGhiChu.Location = new System.Drawing.Point(104, 108);
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
            this.mLabel4.Location = new System.Drawing.Point(13, 113);
            this.mLabel4.Name = "mLabel4";
            this.mLabel4.Size = new System.Drawing.Size(39, 13);
            this.mLabel4.TabIndex = 6;
            this.mLabel4.Text = "Ghi chú";
            // 
            // mLookUpThamSoMatMa
            // 
            this.mLookUpThamSoMatMa.AddFields = null;
            this.mLookUpThamSoMatMa.AliasFormQuickAdd = null;
            this.mLookUpThamSoMatMa.ColumnsExtend = null;
            this.mLookUpThamSoMatMa.Description = null;
            this.mLookUpThamSoMatMa.DictionaryName = null;
            this.mLookUpThamSoMatMa.EntityName = null;
            this.mLookUpThamSoMatMa.Grid = null;
            this.mLookUpThamSoMatMa.IsAutoLoad = false;
            this.mLookUpThamSoMatMa.IsReadOnly = false;
            this.mLookUpThamSoMatMa.IsSetValueManual = false;
            this.mLookUpThamSoMatMa.KeyStore = null;
            this.mLookUpThamSoMatMa.Location = new System.Drawing.Point(104, 78);
            this.mLookUpThamSoMatMa.MapColumnName = null;
            this.mLookUpThamSoMatMa.Name = "mLookUpThamSoMatMa";
            this.mLookUpThamSoMatMa.PrimaryKey = null;
            this.mLookUpThamSoMatMa.QuickSearchName = null;
            this.mLookUpThamSoMatMa.RepositoryItem = null;
            this.mLookUpThamSoMatMa.SetField = "sDM_ThamSoMatMa_id";
            this.mLookUpThamSoMatMa.Size = new System.Drawing.Size(205, 23);
            this.mLookUpThamSoMatMa.Sort = null;
            this.mLookUpThamSoMatMa.TabIndex = 5;
            this.mLookUpThamSoMatMa.ValueDefault = null;
            // 
            // frmDM_MangLienLacDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 240);
            this.Name = "frmDM_MangLienLacDetail";
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
        private MTControl.MTextEdit txtsTenMangLienLac;
        private MTControl.MLabel mLabel2;
        private MTControl.MTextEdit txtsMaMangLienLac;
        private MTControl.MLabel mLabel1;
        private MTControl.MTextEdit txtsGhiChu;
        private MTControl.MLabel mLabel4;
        private MTControl.MLookUpEdit mLookUpThamSoMatMa;
    }
}