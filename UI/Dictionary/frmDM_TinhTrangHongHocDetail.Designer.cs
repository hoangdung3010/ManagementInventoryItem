
namespace FormUI
{
    partial class frmDM_TinhTrangHongHocDetail
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
            this.txtsTenNoiDungSuaChua = new MTControl.MTextEdit();
            this.mLabel3 = new MTControl.MLabel();
            this.mLabel1 = new MTControl.MLabel();
            this.txtsGhiChu = new MTControl.MTextEdit();
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
            this.lblTitleFormDetail.Size = new System.Drawing.Size(247, 22);
            this.lblTitleFormDetail.Text = "Danh mục Tình trạng hỏng hóc";
            // 
            // pnlHeader
            // 
            this.pnlHeader.Size = new System.Drawing.Size(552, 56);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtsGhiChu);
            this.panel3.Controls.Add(this.mLabel1);
            this.panel3.Controls.Add(this.txtsTenNoiDungSuaChua);
            this.panel3.Controls.Add(this.mLabel3);
            this.panel3.Location = new System.Drawing.Point(0, 56);
            this.panel3.Size = new System.Drawing.Size(552, 79);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Location = new System.Drawing.Point(0, 135);
            this.pnlBottom.Size = new System.Drawing.Size(552, 39);
            // 
            // txtsTenNoiDungSuaChua
            // 
            this.txtsTenNoiDungSuaChua.AutoIncrement = false;
            this.txtsTenNoiDungSuaChua.Description = null;
            this.txtsTenNoiDungSuaChua.Grid = null;
            this.txtsTenNoiDungSuaChua.IsCustomHeight = false;
            this.txtsTenNoiDungSuaChua.IsReadOnly = false;
            this.txtsTenNoiDungSuaChua.IsSetValueManual = false;
            this.txtsTenNoiDungSuaChua.Location = new System.Drawing.Point(122, 14);
            this.txtsTenNoiDungSuaChua.MaxLength = 255;
            this.txtsTenNoiDungSuaChua.Name = "txtsTenNoiDungSuaChua";
            this.txtsTenNoiDungSuaChua.RepositoryItem = null;
            this.txtsTenNoiDungSuaChua.SetField = "sTenNoiDungSuaChua";
            this.txtsTenNoiDungSuaChua.Size = new System.Drawing.Size(418, 22);
            this.txtsTenNoiDungSuaChua.TabIndex = 0;
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
            this.mLabel3.Location = new System.Drawing.Point(18, 19);
            this.mLabel3.Name = "mLabel3";
            this.mLabel3.Size = new System.Drawing.Size(89, 16);
            this.mLabel3.TabIndex = 4;
            this.mLabel3.Text = "Tên TT hỏng hóc<color=255, 0, 0><size=13>*</size></color>";
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
            this.mLabel1.Location = new System.Drawing.Point(18, 47);
            this.mLabel1.Name = "mLabel1";
            this.mLabel1.Size = new System.Drawing.Size(39, 13);
            this.mLabel1.TabIndex = 5;
            this.mLabel1.Text = "Ghi chú";
            // 
            // txtsGhiChu
            // 
            this.txtsGhiChu.AutoIncrement = false;
            this.txtsGhiChu.Description = null;
            this.txtsGhiChu.Grid = null;
            this.txtsGhiChu.IsCustomHeight = false;
            this.txtsGhiChu.IsReadOnly = false;
            this.txtsGhiChu.IsSetValueManual = false;
            this.txtsGhiChu.Location = new System.Drawing.Point(122, 42);
            this.txtsGhiChu.MaxLength = 255;
            this.txtsGhiChu.Name = "txtsGhiChu";
            this.txtsGhiChu.RepositoryItem = null;
            this.txtsGhiChu.SetField = "sGhiChu";
            this.txtsGhiChu.Size = new System.Drawing.Size(418, 22);
            this.txtsGhiChu.TabIndex = 1;
            // 
            // frmDM_TinhTrangHongHocDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 174);
            this.Name = "frmDM_TinhTrangHongHocDetail";
            this.Text = "frmDM_DonViDetail";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MTControl.MTextEdit txtsTenNoiDungSuaChua;
        private MTControl.MLabel mLabel3;
        private MTControl.MTextEdit txtsGhiChu;
        private MTControl.MLabel mLabel1;
    }
}