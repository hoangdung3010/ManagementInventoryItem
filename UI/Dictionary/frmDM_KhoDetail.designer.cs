
namespace FormUI
{
    partial class frmDM_KhoDetail
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
            this.txtsTenKho = new MTControl.MTextEdit();
            this.mLabel2 = new MTControl.MLabel();
            this.treesDM_Donvi_Id = new MTControl.MLookUpEdit();
            this.txtsGhiChu = new MTControl.MTextEdit();
            this.mLabel1 = new MTControl.MLabel();
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
            this.lblTitleFormDetail.Size = new System.Drawing.Size(115, 22);
            this.lblTitleFormDetail.Text = "Danh mục kho";
            // 
            // pnlHeader
            // 
            this.pnlHeader.Size = new System.Drawing.Size(546, 56);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtsGhiChu);
            this.panel3.Controls.Add(this.mLabel1);
            this.panel3.Controls.Add(this.treesDM_Donvi_Id);
            this.panel3.Controls.Add(this.mLabel3);
            this.panel3.Controls.Add(this.txtsTenKho);
            this.panel3.Controls.Add(this.mLabel2);
            this.panel3.Location = new System.Drawing.Point(0, 56);
            this.panel3.Size = new System.Drawing.Size(546, 119);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Location = new System.Drawing.Point(0, 175);
            this.pnlBottom.Size = new System.Drawing.Size(546, 39);
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
            this.mLabel3.Location = new System.Drawing.Point(13, 57);
            this.mLabel3.Name = "mLabel3";
            this.mLabel3.Size = new System.Drawing.Size(63, 13);
            this.mLabel3.TabIndex = 10;
            this.mLabel3.Text = "Thuộc đơn vị";
            // 
            // txtsTenKho
            // 
            this.txtsTenKho.AutoIncrement = false;
            this.txtsTenKho.Description = null;
            this.txtsTenKho.Grid = null;
            this.txtsTenKho.IsCustomHeight = false;
            this.txtsTenKho.IsReadOnly = false;
            this.txtsTenKho.IsRequired = true;
            this.txtsTenKho.IsSetValueManual = false;
            this.txtsTenKho.Location = new System.Drawing.Point(82, 22);
            this.txtsTenKho.MaxLength = 255;
            this.txtsTenKho.Name = "txtsTenKho";
            this.txtsTenKho.RepositoryItem = null;
            this.txtsTenKho.SetField = "sTenKho";
            this.txtsTenKho.Size = new System.Drawing.Size(453, 22);
            this.txtsTenKho.TabIndex = 0;
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
            this.mLabel2.Location = new System.Drawing.Point(13, 27);
            this.mLabel2.Name = "mLabel2";
            this.mLabel2.Size = new System.Drawing.Size(39, 13);
            this.mLabel2.TabIndex = 8;
            this.mLabel2.Text = "Tên Kho";
            // 
            // treesDM_Donvi_Id
            // 
            this.treesDM_Donvi_Id.AddFields = null;
            this.treesDM_Donvi_Id.AliasFormQuickAdd = null;
            this.treesDM_Donvi_Id.ColumnsExtend = null;
            this.treesDM_Donvi_Id.Description = null;
            this.treesDM_Donvi_Id.DictionaryName = null;
            this.treesDM_Donvi_Id.EntityName = null;
            this.treesDM_Donvi_Id.Grid = null;
            this.treesDM_Donvi_Id.IsAutoLoad = false;
            this.treesDM_Donvi_Id.IsReadOnly = false;
            this.treesDM_Donvi_Id.IsRequired = true;
            this.treesDM_Donvi_Id.IsSetValueManual = false;
            this.treesDM_Donvi_Id.KeyStore = null;
            this.treesDM_Donvi_Id.Location = new System.Drawing.Point(82, 53);
            this.treesDM_Donvi_Id.MapColumnName = null;
            this.treesDM_Donvi_Id.Name = "treesDM_Donvi_Id";
            this.treesDM_Donvi_Id.PrimaryKey = null;
            this.treesDM_Donvi_Id.QuickSearchName = null;
            this.treesDM_Donvi_Id.RepositoryItem = null;
            this.treesDM_Donvi_Id.SetField = "sDM_Donvi_Id";
            this.treesDM_Donvi_Id.Size = new System.Drawing.Size(452, 23);
            this.treesDM_Donvi_Id.Sort = null;
            this.treesDM_Donvi_Id.TabIndex = 1;
            this.treesDM_Donvi_Id.ValueDefault = null;
            // 
            // txtsGhiChu
            // 
            this.txtsGhiChu.AutoIncrement = false;
            this.txtsGhiChu.Description = null;
            this.txtsGhiChu.Grid = null;
            this.txtsGhiChu.IsCustomHeight = false;
            this.txtsGhiChu.IsReadOnly = false;
            this.txtsGhiChu.IsSetValueManual = false;
            this.txtsGhiChu.Location = new System.Drawing.Point(82, 83);
            this.txtsGhiChu.MaxLength = 255;
            this.txtsGhiChu.Name = "txtsGhiChu";
            this.txtsGhiChu.RepositoryItem = null;
            this.txtsGhiChu.SetField = "sGhiChu";
            this.txtsGhiChu.Size = new System.Drawing.Size(453, 22);
            this.txtsGhiChu.TabIndex = 2;
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
            this.mLabel1.Location = new System.Drawing.Point(12, 87);
            this.mLabel1.Name = "mLabel1";
            this.mLabel1.Size = new System.Drawing.Size(39, 13);
            this.mLabel1.TabIndex = 14;
            this.mLabel1.Text = "Ghi chú";
            // 
            // frmDM_KhoDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 214);
            this.Name = "frmDM_KhoDetail";
            this.Text = "frmDM_KhoDetail";
            this.Load += new System.EventHandler(this.frmDM_KhoDetail_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private MTControl.MLabel mLabel3;
        private MTControl.MTextEdit txtsTenKho;
        private MTControl.MLabel mLabel2;
        private MTControl.MLookUpEdit treesDM_Donvi_Id;
        private MTControl.MTextEdit txtsGhiChu;
        private MTControl.MLabel mLabel1;
    }
}